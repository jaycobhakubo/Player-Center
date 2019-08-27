using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using GTI.Modules.Shared;
using System.Text.RegularExpressions;
using GameTech.Elite.Base;
using GameTech.Elite.Client;

namespace GTI.Modules.PlayerCenter.UI
{
    public partial class GeneralPlayerDrawingForm : GradientForm
    {
        public static int? UILimitToNInt(object uiVal)
        {
            string stringVal = uiVal == DBNull.Value ? null : (string)uiVal;
            int parseVal;
            if(String.IsNullOrWhiteSpace(stringVal) || !int.TryParse(stringVal, out parseVal))
                return null;
            else
                return parseVal;
        }

        public static string NIntToString(int? nintVal) { return nintVal.HasValue ? nintVal.Value.ToString() : String.Empty; }
        public static string UILimitToString(object uiVal) { return NIntToString(UILimitToNInt(uiVal)); }

        private static SortedSet<GeneralPlayerDrawing.EntryTier<T>> UIEntryScaleToEntryScale<T>(DataTable dt)
            where T : IComparable<T>
        {
            var candidateScale = new SortedSet<GeneralPlayerDrawing.EntryTier<T>>(GeneralPlayerDrawing.EntryTier<T>.OverlapComparer);
            try
            {
                foreach(System.Data.DataRow dr in dt.Rows)
                {
                    if(dr[0] == DBNull.Value || dr[1] == DBNull.Value || dr[2] == DBNull.Value)
                        throw new Exception("Incomplete tier definition");
                    var et = new GeneralPlayerDrawing.EntryTier<T>((T)dr[0], (T)dr[1], (int)dr[2]);
                    candidateScale.Add(et);
                }
            }
            catch(Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.Message);
                candidateScale = null;
            }
            return candidateScale;
        }

        private class DrawingSortComparer : IComparer<GeneralPlayerDrawing>
        {
            public static readonly DrawingSortComparer Comparer = new DrawingSortComparer();

            public int Compare(GeneralPlayerDrawing x, GeneralPlayerDrawing y)
            {
                var c = x.Name.CompareTo(y.Name);
                if(c != 0)
                    return c;
                else
                    return x.Active == y.Active ? 0 : (x.Active ? -1 : 1);
            }
        }

        private class SessionNumberListing
        {
            public Byte SessionNumber { get; private set; }
            public string DisplayString { get; private set; }
            public override string ToString() { return DisplayString; }

            public SessionNumberListing(Byte sessionNumber)
            {
                SessionNumber = sessionNumber;
                DisplayString = String.Format("Session {0}", SessionNumber);
            }
        }

        private class PurchaseItemListing
        {
            private int m_id;
            private string m_name;
            private Shared.Business.ProductItem m_productItem;
            private Shared.Business.PackageItem m_packageItem;

            public int Id
            {
                get
                {
                    if(m_packageItem != null)
                        return m_packageItem.PackageId;
                    if(m_productItem != null)
                        return m_productItem.ProductItemId;
                    return m_id;
                }
            }
            public string Name
            {
                get
                {
                    if(m_packageItem != null)
                        return m_packageItem.PackageName;
                    if(m_productItem != null)
                        return m_productItem.ProductItemName;
                    return m_name;
                }
            }
            public bool IsActive
            {
                get
                {
                    if(m_packageItem != null)
                        return true;
                    if(m_productItem != null)
                        return m_productItem.IsActive;
                    return true;
                }
            }

            public PurchaseItemListing(int id, string name)
            {
                m_id = id;
                m_name = name;
            }

            public PurchaseItemListing(Shared.Business.ProductItem item)
            {
                this.m_productItem = item;
            }

            public PurchaseItemListing(Shared.Business.PackageItem item)
            {
                this.m_packageItem = item;
            }

            public override string ToString() { return Name; }
        }

        public List<GeneralPlayerDrawing> Drawings
        {
            get { return m_drawings; }
        }

        #region Member Variables
        private bool m_editMode = false;
        private List<Control> m_erroredControls = new List<Control>();
        private GeneralPlayerDrawing m_currentGPD = null;
        private bool m_loadingDetails;
        private List<PurchaseItemListing> m_productsAvailable = new List<PurchaseItemListing>();
        private List<PurchaseItemListing> m_packagesAvailable = new List<PurchaseItemListing>();
        private List<int> m_pendingProductSelections = new List<int>();
        private List<int> m_pendingPackageSelections = new List<int>();
        private System.Data.DataTable m_entrySpendScaleDT;
        private System.Data.DataTable m_entryVisitScaleDT;
        private System.Data.DataTable m_entryPurchaseScaleDT;
        private List<GeneralPlayerDrawing> m_drawings;
        private string m_displayedText = "";
        private Type m_selectedColumnDataType;
        private const bool c_enablePurchaseUI = false;
        #endregion
        #region Constructor
        public GeneralPlayerDrawingForm(string displayText)
        {
            InitializeComponent();
            LoadEntrySessionsCheckList();
            ChangeDateFormatToSavedSpace();
            HideOrShowRepeatsPerCheckedStatus();
            InitEntryScaleElements();

            if(!c_enablePurchaseUI)
                entryMethodsTC.TabPages.Remove(entryPurchasesTP);
            else
            {
                LoadPackages();
                LoadProducts();
            }

            LoadGeneralDrawings();
            m_displayedText = displayText;
            AppliedSystemSettingDisplayedText();
            ToggleEditMode(false);
        }
        #endregion
        #region Member Methods

        private void AppliedSystemSettingDisplayedText()
        {
            drawingsLbl.Text = m_displayedText + "s";            
        }

        private void ChangeDateFormatToSavedSpace()
        {
            initialEventEntryPeriodBeginDTP.Format = DateTimePickerFormat.Custom;
            initialEventEntryPeriodBeginDTP.CustomFormat = "ddd, MMM dd, yyyy";
            initialEventEntryPeriodEndDTP.Format = DateTimePickerFormat.Custom;
            initialEventEntryPeriodEndDTP.CustomFormat = "ddd, MMM dd, yyyy";
            initialEventScheduledForDTP.Format = DateTimePickerFormat.Custom;
            initialEventScheduledForDTP.CustomFormat = "ddd, MMM dd, yyyy";
            eventRepetitionEndsDTP.Format = DateTimePickerFormat.Custom;
            eventRepetitionEndsDTP.CustomFormat = "ddd, MMM dd, yyyy";
        }

        private void InitEntryScaleElements()
        {
            m_entrySpendScaleDT = new DataTable();
            m_entrySpendScaleDT.Columns.Add("From", typeof(decimal));
            m_entrySpendScaleDT.Columns.Add("To", typeof(decimal));
            m_entrySpendScaleDT.Columns.Add("Entries", typeof(int));
            entrySpendScaleDGV.DataSource = m_entrySpendScaleDT;

            //Set Maxlenght to 10 character; Set column width to fit 10 character
            var dgvClmnFrom = (DataGridViewTextBoxColumn)entrySpendScaleDGV.Columns["From"];
            dgvClmnFrom.MaxInputLength = 10;
            dgvClmnFrom.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            dgvClmnFrom.Width = 100;

            var dgvClmnTo = (DataGridViewTextBoxColumn)entrySpendScaleDGV.Columns["To"];
            dgvClmnTo.MaxInputLength = 10;
            dgvClmnTo.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            dgvClmnTo.Width = 100;

            var dgvClmnEntries = (DataGridViewTextBoxColumn)entrySpendScaleDGV.Columns["Entries"];
            dgvClmnEntries.MaxInputLength = 10;
            dgvClmnEntries.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            dgvClmnEntries.Width = 100;
               
            m_entryVisitScaleDT = new DataTable();
            m_entryVisitScaleDT.Columns.Add("From", typeof(int));
            m_entryVisitScaleDT.Columns.Add("To", typeof(int));
            m_entryVisitScaleDT.Columns.Add("Entries", typeof(int));
            entryVisitScaleDGV.DataSource = m_entryVisitScaleDT;

            //Set Maxlenght to 10 character; Set column width to fit 10 character
            dgvClmnFrom = (DataGridViewTextBoxColumn)entryVisitScaleDGV.Columns["From"];
            dgvClmnFrom.MaxInputLength = 10;
            dgvClmnFrom.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            dgvClmnFrom.Width = 100;

            dgvClmnTo = (DataGridViewTextBoxColumn)entryVisitScaleDGV.Columns["To"];
            dgvClmnTo.MaxInputLength = 10;
            dgvClmnTo.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            dgvClmnTo.Width = 100;

            dgvClmnEntries = (DataGridViewTextBoxColumn)entryVisitScaleDGV.Columns["Entries"];
            dgvClmnEntries.MaxInputLength = 10;
            dgvClmnEntries.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            dgvClmnEntries.Width = 100;

            m_entryPurchaseScaleDT = new DataTable();
            m_entryPurchaseScaleDT.Columns.Add("From", typeof(int));
            m_entryPurchaseScaleDT.Columns.Add("To", typeof(int));
            m_entryPurchaseScaleDT.Columns.Add("Entries", typeof(int));
            entryPurchaseScaleDGV.DataSource = m_entryPurchaseScaleDT;

         
            foreach (var dgv in new DataGridView[] { entrySpendScaleDGV, entryVisitScaleDGV, entryPurchaseScaleDGV })
            {
                dgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells;

                var removeDGVBC = new DataGridViewButtonColumn();
                removeDGVBC.Name = "removeDGVBC";
                removeDGVBC.HeaderText = "";
                removeDGVBC.Text = "Remove";
                removeDGVBC.UseColumnTextForButtonValue = true;
                dgv.Columns.Add(removeDGVBC);
                removeDGVBC.AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;

                foreach(DataGridViewColumn c in dgv.Columns)
                    c.SortMode = DataGridViewColumnSortMode.NotSortable;

                dgv.CellContentClick += entryScaleDGV_CellContentClick;
                dgv.CellValueChanged += entryScaleDGV_CellValueChanged;
                dgv.RowsRemoved += entryScaleDGV_RowsRemoved;
                dgv.RowsAdded += entryScaleDGV_RowsAdded;
                dgv.Leave += entryScaleDGV_Leave;
            }

        }


        void CheckEntryScale(DataGridView dgv)
        {
            try
            {
                if (dgv.Visible)
                {
                    var dt = dgv.DataSource as DataTable;

                    if (dt.Rows.Count == 0)
                    {
                        SetError(dgv, "No entry tiers specified.");
                        return;
                    }

                    #region Check for incompletely defined tiers
                    foreach (System.Data.DataRow dr in dt.Rows)
                    {
                        for (int i = 0; i < 3; ++i)
                            if (dr[i] == DBNull.Value)
                            {
                                SetError(dgv, String.Format("Tier entry missing {0} value.", dt.Columns[i].ColumnName));
                                return;
                            }
                    }
                    #endregion

                    if (dt.Columns[0].DataType == typeof(decimal))
                    {
                        var candidateScale = new List<GeneralPlayerDrawing.EntryTier<decimal>>();

                        #region Build EntryTier list, and make sure tiers have valid relative begin-end
                        foreach (System.Data.DataRow dr in dt.Rows)
                        {
                            var et = new GeneralPlayerDrawing.EntryTier<decimal>((decimal)dr[0], (decimal)dr[1], (int)dr[2]);
                            if (et.TierBegin > et.TierEnd)
                            {
                                SetError(dgv, String.Format("Invalid tier range, {0}-{1}, tier begin must be less than tier end.", et.TierBegin, et.TierEnd));
                                return;
                            }
                            candidateScale.Add(et);
                        }
                        #endregion

                        #region Check for overlapping tiers
                        for (int i = 0; i < candidateScale.Count; ++i)
                        {
                            var et = candidateScale[i];
                            var overlap = candidateScale.FirstOrDefault(
                                            (et2) => !object.ReferenceEquals(et, et2)
                                                     && GeneralPlayerDrawing.EntryTier<decimal>.OverlapComparer.Compare(et, et2) == 0
                                            );
                            if (overlap != null)
                            {
                                SetError(dgv, String.Format("Overlapping tier ranges, {0}-{1} and {2}-{3}.", et.TierBegin, et.TierEnd, overlap.TierBegin, overlap.TierEnd));
                                return;
                            }
                        }
                        #endregion

                        #region Check for gaps and entry losses
                        candidateScale.Sort(GeneralPlayerDrawing.EntryTier<decimal>.SortComparer);
                        for (int i = 1; i < candidateScale.Count; ++i)
                        {
                            var prevET = candidateScale[i - 1];
                            var et = candidateScale[i];
                            if ((et.TierBegin - prevET.TierEnd) > 0.01m)
                            {
                                SetError(dgv, String.Format("Gap between tier ranges, {0}-{1} and {2}-{3}.", prevET.TierBegin, prevET.TierEnd, et.TierBegin, et.TierEnd));
                                return;
                            }
                            if (et.Entries < prevET.Entries)
                            {
                                SetError(dgv, String.Format("Entries decrease between tiers {0}-{1} to {2}-{3}.", prevET.TierBegin, prevET.TierEnd, et.TierBegin, et.TierEnd));
                                return;
                            }
                            prevET = et;
                        }
                        #endregion

                    }
                    else if (dt.Columns[0].DataType == typeof(int))
                    {
                        var candidateScale = new List<GeneralPlayerDrawing.EntryTier<int>>();

                        #region Build EntryTier list, and make sure tiers have valid relative begin-end
                        foreach (System.Data.DataRow dr in dt.Rows)
                        {
                            var et = new GeneralPlayerDrawing.EntryTier<int>((int)dr[0], (int)dr[1], (int)dr[2]);
                            if (et.TierBegin > et.TierEnd)
                            {
                                SetError(dgv, String.Format("Invalid tier range, {0}-{1}, tier begin must be less than tier end.", et.TierBegin, et.TierEnd));
                                return;
                            }
                            candidateScale.Add(et);
                        }
                        #endregion

                        #region Check for overlapping tiers
                        for (int i = 0; i < candidateScale.Count; ++i)
                        {
                            var et = candidateScale[i];
                            var overlap = candidateScale.FirstOrDefault(
                                            (et2) => !object.ReferenceEquals(et, et2)
                                                     && GeneralPlayerDrawing.EntryTier<int>.OverlapComparer.Compare(et, et2) == 0
                                            );
                            if (overlap != null)
                            {
                                SetError(dgv, String.Format("Overlapping tier ranges, {0}-{1} and {2}-{3}.", et.TierBegin, et.TierEnd, overlap.TierBegin, overlap.TierEnd));
                                return;
                            }
                        }
                        #endregion

                        #region Check for gaps and entry losses
                        candidateScale.Sort(GeneralPlayerDrawing.EntryTier<int>.SortComparer);
                        for (int i = 1; i < candidateScale.Count; ++i)
                        {
                            var prevET = candidateScale[i - 1];
                            var et = candidateScale[i];
                            if ((et.TierBegin - prevET.TierEnd) > 1)
                            {
                                SetError(dgv, String.Format("Gap between tier ranges, {0}-{1} and {2}-{3}.", prevET.TierBegin, prevET.TierEnd, et.TierBegin, et.TierEnd));
                                return;
                            }
                            if (et.Entries < prevET.Entries)
                            {
                                SetError(dgv, String.Format("Entries decrease between tiers {0}-{1} to {2}-{3}.", prevET.TierBegin, prevET.TierEnd, et.TierBegin, et.TierEnd));
                                return;
                            }
                            prevET = et;
                        }
                        #endregion
                    }

                }

                SetError(dgv, null);

            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.Message);
                SetError(dgv, "Invalid scale");
            }
        }

        private void LoadPackages()
        {
            var p = GetPackageItemMessage.GetPackageList(0).OrderBy((i) => i.PackageName);

            foreach (var pkg in p)
                m_packagesAvailable.Add(new PurchaseItemListing(pkg));       
        }

        private void LoadProducts()
        {
            var p = GTI.Modules.Shared.Data.GetProductItemsMessage.GetProductItems(0).OrderBy((i) => i.ProductItemName);

            foreach (var prod in p)
                m_productsAvailable.Add(new PurchaseItemListing(prod));         
        }

        private void LoadGeneralDrawings()
        {
            m_drawings = GetGeneralDrawingsMessage.GetDrawings();
            m_drawings.Sort(DrawingSortComparer.Comparer);
            ListDrawings();
        }

        private void ListDrawings(int? selectId = null)
        {
            SetCurrentDrawing(null);

            drawingsLV.BeginUpdate();

            try
            {
                var inactiveFont = new Font(drawingsLV.Font, FontStyle.Regular | FontStyle.Italic);
                var activeFont = new Font(drawingsLV.Font, FontStyle.Regular);
                drawingsLV.Columns.Clear();
                drawingsLV.Columns.Add("Name");

                if (selectId == null && drawingsLV.SelectedItems.Count == 1)
                    selectId = (drawingsLV.SelectedItems[0].Tag as GeneralPlayerDrawing).Id;

                drawingsLV.Items.Clear();
                if (m_drawings != null)
                    foreach (var d in m_drawings)
                        if (d.Active || showInactiveDrawingsChk.Checked)
                        {

                            var lvi = drawingsLV.Items.Add(d.Name);
                            lvi.Font = activeFont;
                            lvi.Tag = d;

                            if (!d.Active)
                            {
                                lvi.Font = inactiveFont;
                            }
                            if (selectId.HasValue && d.Id == selectId.Value)
                            {
                                lvi.Selected = true;
                                SetCurrentDrawing(d);
                            }
                        }
            }
            finally
            {
                foreach (ColumnHeader ch in drawingsLV.Columns)
                    ch.AutoResize(ColumnHeaderAutoResizeStyle.ColumnContent);
                drawingsLV.EndUpdate();
            }
        }

        private void LoadEntrySessionsCheckList()
        {
            for (Byte i = 1; i <= 16; ++i)
                entrySessionNumbersCL.Items.Add(new SessionNumberListing(i));
        }

        private void ToggleEditMode(bool enterEditMode)
        {
            if (enterEditMode)
                m_editMode = enterEditMode;

            showInactiveDrawingsChk.Enabled = !enterEditMode;
            drawingsLV.Enabled = !enterEditMode;
            newDrawingBtn.Enabled = !enterEditMode;
            copyDrawingBtn.Enabled = !enterEditMode && m_currentGPD != null;
            editDrawingBtn.Enabled = !enterEditMode && m_currentGPD != null;

            drawingNameTxt.Enabled = enterEditMode;
            drawingActiveChk.Enabled = enterEditMode;

            commonOptionsTP.Enabled = enterEditMode;
            eventTP.Enabled = enterEditMode;
            foreach (TabPage tp in entryMethodsTC.TabPages)
                tp.Enabled = enterEditMode;

            saveDrawingChangesBtn.Enabled = enterEditMode && m_erroredControls.Count == 0;
            revertDrawingChangesBtn.Enabled = enterEditMode;
            cancelDrawingChangesBtn.Enabled = enterEditMode;

            if (!enterEditMode)
            {
                m_editMode = enterEditMode;
                drawingsLV.Focus();
            }
        }

        void UpdateEntryPurchaseTPHeader()
        {
            if (entryPurchaseTypeNoneRB.Checked)
                entryPurchasesTP.Text = "Purchase (None)";
            else
            {
                String grouping = "";
                foreach (RadioButton rb in entryPurchaseGroupingFLP.Controls)
                    if (rb.Checked)
                        grouping = rb.Text + " ";

                String purchaseType = "";
                foreach (RadioButton rb in entryPurchaseTypeFLP.Controls)
                    if (rb.Checked)
                        purchaseType = rb.Text;

                entryPurchasesTP.Text = String.Format("Purchase ({0}/{1})", purchaseType, grouping);
            }
        }

        private void CheckEntryMethods()
        {
            if (PendingEntrySpendGrouping == GeneralPlayerDrawing.SpendGrouping.NONE
                && PendingEntryVisitType == GeneralPlayerDrawing.VisitType.NONE
                && (PendingEntryPurchaseGrouping == GeneralPlayerDrawing.PurchaseGrouping.NONE
                    || PendingEntryPurchaseType == GeneralPlayerDrawing.PurchaseType.NONE
                    )
                )
            {
                //SetError(entryMethodsTP, "No entry method specified.");
                //Lets put the error in to the tab page
                SetError(entrySpendGroupingNoneRB, "No entry method specified.");
                SetError(entryVisitTypeNoneRB, "No entry method specified.");
            }
            else
            {
                SetError(entrySpendGroupingNoneRB, null);
                SetError(entryVisitTypeNoneRB, null);
                //SetError(entryMethodsTP, null);
            }
        }

        private void SetCurrentDrawing(GeneralPlayerDrawing gpd)
        {
            m_currentGPD = gpd;
            
            if (m_currentGPD == null || m_editMode)
            {
                editDrawingBtn.Enabled = false;
                copyDrawingBtn.Enabled = false;
            }
            else
            {
                editDrawingBtn.Enabled = true;
                copyDrawingBtn.Enabled = true;
            }

            LoadCurrentDrawingDetails();
        }

        private void LoadCurrentDrawingDetails()
        {
            m_loadingDetails = true;

            if (m_currentGPD == null)
            {
                drawingDetailsGB.Visible = false;
            }

            #region Reset before loading

            drawingNameTxt.Text = "";
            drawingActiveChk.Checked = false;
            drawingDescriptionTxt.Text = "";
            drawingEntriesDrawnTxt.Text = "";
            minimumEntriesToRunTxt.Text = "";
            maximumDrawsPerPlayerTxt.Text = "";
            showEntryCountOnReceiptsChk.Checked = false;
            playerPresenceRequiredChk.Checked = false;
            txtbx_PrizeDescription.Text = "";
            txtbx_disclaimer.Text = "";

            #region Entry Window
            initialEventEntryPeriodBeginDTP.Value = initialEventEntryPeriodBeginDTP.MinDate;
            initialEventEntryPeriodEndDTP.Value = initialEventEntryPeriodEndDTP.MaxDate;

            eventRepeatsChk.Checked = false;
            eventRepeatIncrementTxt.Text = "";
            eventRepeatIntervalCB.SelectedItem = null;
            eventRepetitionEndsDTP.Value = eventRepetitionEndsDTP.MaxDate;

            entrySessionNumbersCL.SelectedItems.Clear();
            #endregion

            #region Entry Limits
            entryLimitEventTxt.Text = "";
            #endregion

            #region Entry Qualifications

            entrySpendGroupingNoneRB.Checked = true;
            m_entrySpendScaleDT.Rows.Clear();

            entryVisitTypeNoneRB.Checked = true;
            m_entryVisitScaleDT.Rows.Clear();

            entryPurchaseTypeNoneRB.Checked = true;
            m_entryPurchaseScaleDT.Rows.Clear();
            m_pendingPackageSelections.Clear();
            m_pendingProductSelections.Clear();
            entryPurchaseSelectionsCL.Items.Clear();
            #endregion
            #endregion

            if (m_currentGPD != null)
            {
                drawingNameTxt.Text = m_currentGPD.Name;
                drawingActiveChk.Checked = !m_currentGPD.Active;
                drawingDescriptionTxt.Text = m_currentGPD.Description;
                drawingEntriesDrawnTxt.Text = m_currentGPD.EntriesDrawn.ToString();
                minimumEntriesToRunTxt.Text = m_currentGPD.MinimumEntries.ToString();
                maximumDrawsPerPlayerTxt.Text = m_currentGPD.MaximumDrawsPerPlayer.ToString();
                showEntryCountOnReceiptsChk.Checked = m_currentGPD.ShowEntriesOnReceipts;
                playerPresenceRequiredChk.Checked = m_currentGPD.PlayerPresenceRequired;
                txtbx_PrizeDescription.Text = m_currentGPD.PrizeDescription;
                txtbx_disclaimer.Text = m_currentGPD.Disclaimer;
                showZeroEntryCountChk.Checked = m_currentGPD.ShowZeroEntryDrawingOnReceipt;

                #region Entry Window
                initialEventEntryPeriodBeginDTP.Value = m_currentGPD.InitialEventEntryPeriodBegin;
                initialEventEntryPeriodEndDTP.Value = m_currentGPD.InitialEventEntryPeriodEnd;

                if (m_currentGPD.InitialEventScheduledForWhen == null)
                {
                    initialEventScheduledForDTP.Value = m_currentGPD.InitialEventEntryPeriodEnd;
                    initialEventScheduledForDTP.Checked = false;
                }
                else
                {
                    initialEventScheduledForDTP.Checked = true;
                    initialEventScheduledForDTP.Value = m_currentGPD.InitialEventScheduledForWhen.Value;
                }

                eventRepeatsChk.Checked = m_currentGPD.EventRepeatIncrement > 0;
                eventRepeatIncrementTxt.Text = m_currentGPD.EventRepeatIncrement.ToString();
                eventRepeatIntervalCB.SelectedItem = m_currentGPD.EventRepeatInterval;

                if (m_currentGPD.EventRepeatUntil == null)
                {
                    eventRepetitionEndsDTP.Value = m_currentGPD.InitialEventEntryPeriodEnd;
                    eventRepetitionEndsDTP.Checked = false;
                }
                else
                {
                    eventRepetitionEndsDTP.Value = m_currentGPD.EventRepeatUntil.Value;
                    eventRepetitionEndsDTP.Checked = true;
                }

                CheckEventDates();
                UpdateEventExamples();

                SortedSet<Byte> sessionNumbersChecked = new SortedSet<byte>();
                for (int i = 0; i < entrySessionNumbersCL.Items.Count; ++i)
                {
                    var sl = entrySessionNumbersCL.Items[i] as SessionNumberListing;
                    var check = m_currentGPD.EntrySessionNumbers.Contains(sl.SessionNumber);
                    entrySessionNumbersCL.SetItemChecked(i, check);
                    if (check)
                        sessionNumbersChecked.Add(sl.SessionNumber);
                }

                if (m_currentGPD.EntrySessionNumbers.Count > sessionNumbersChecked.Count)
                {
                    var nondefaultSessionNumbers = m_currentGPD.EntrySessionNumbers.Except(sessionNumbersChecked);
                    foreach (var sn in nondefaultSessionNumbers)
                        entrySessionNumbersCL.Items.Add(new SessionNumberListing(sn), true);
                }

                entrySessionNumbersCL_ItemCheck(null, null);
                #endregion

                #region Entry Limits
                entryLimitEventTxt.Text = NIntToString(m_currentGPD.PlayerEntryMaximum);
                #endregion

                #region Entry Qualifications
                switch (m_currentGPD.EntrySpendGrouping)
                {
                    case GeneralPlayerDrawing.SpendGrouping.BY_TRANSACTION:
                        entrySpendGroupingByTransactionRB.Checked = true;
                        break;
                    case GeneralPlayerDrawing.SpendGrouping.BY_SESSION:
                        entrySpendGroupingBySessionRB.Checked = true;
                        break;
                    case GeneralPlayerDrawing.SpendGrouping.BY_DAY:
                        entrySpendGroupingByDayRB.Checked = true;
                        break;
                    case GeneralPlayerDrawing.SpendGrouping.WITHIN_ENTRY_WINDOW:
                        entrySpendGroupingEntryPeriodRB.Checked = true;
                        break;
                    case GeneralPlayerDrawing.SpendGrouping.NONE:
                        entrySpendGroupingNoneRB.Checked = true;
                        break;
                    default:
                        foreach (var c in entrySpendGroupingFLP.Controls)
                            if (c is RadioButton)
                                (c as RadioButton).Checked = false;
                        break;
                }
                m_entrySpendScaleDT.Rows.Clear();
                foreach (var et in m_currentGPD.EntrySpendTiers)
                    m_entrySpendScaleDT.Rows.Add(et.TierBegin, et.TierEnd, et.Entries);
                CheckEntryScale(entrySpendScaleDGV);

                switch (m_currentGPD.EntryVisitType)
                {
                    case GeneralPlayerDrawing.VisitType.SESSIONS_PER_DAY:
                        entryVisitTypeSessionsPerDayRB.Checked = true;
                        break;
                    case GeneralPlayerDrawing.VisitType.SESSIONS_IN_ENTRY_PERIOD:
                        entryVisitTypeSessionsInEntryPeriodRB.Checked = true;
                        break;
                    case GeneralPlayerDrawing.VisitType.DAYS_IN_ENTRY_PERIOD:
                        entryVisitTypeDaysInEntryPeriodWindowRB.Checked = true;
                        break;
                    case GeneralPlayerDrawing.VisitType.NONE:
                        entryVisitTypeNoneRB.Checked = true;
                        break;
                    default:
                        foreach (var c in entryVisitsTypeFLP.Controls)
                            if (c is RadioButton)
                                (c as RadioButton).Checked = false;
                        break;
                }
                m_entryVisitScaleDT.Rows.Clear();
                foreach (var et in m_currentGPD.EntryVisitTiers)
                    m_entryVisitScaleDT.Rows.Add(et.TierBegin, et.TierEnd, et.Entries);
                CheckEntryScale(entryVisitScaleDGV);

                switch (m_currentGPD.EntryPurchaseType)
                {
                    case GeneralPlayerDrawing.PurchaseType.PACKAGE:
                        entryPurchaseTypePackageRB.Checked = true;
                        break;
                    case GeneralPlayerDrawing.PurchaseType.PRODUCT:
                        entryPurchaseTypeProductRB.Checked = true;
                        break;
                    case GeneralPlayerDrawing.PurchaseType.NONE:
                        entryPurchaseTypeNoneRB.Checked = true;
                        break;
                    default:
                        foreach (var c in entryPurchaseTypeFLP.Controls)
                            if (c is RadioButton)
                                (c as RadioButton).Checked = false;
                        break;
                }
                m_entryPurchaseScaleDT.Rows.Clear();
                foreach (var et in m_currentGPD.EntryPurchaseTiers)
                    m_entryPurchaseScaleDT.Rows.Add(et.TierBegin, et.TierEnd, et.Entries);
                CheckEntryScale(entryPurchaseScaleDGV);

                m_pendingPackageSelections.Clear();
                foreach (var id in m_currentGPD.EntryPurchasePackageIds)
                    m_pendingPackageSelections.Add(id);

                m_pendingProductSelections.Clear();
                foreach (var id in m_currentGPD.EntryPurchaseProductIds)
                    m_pendingProductSelections.Add(id);

                entryPurchaseSelectionsCL.Items.Clear();
                if (m_currentGPD.EntryPurchaseType == GeneralPlayerDrawing.PurchaseType.PACKAGE)
                    foreach (var p in m_packagesAvailable)
                        entryPurchaseSelectionsCL.Items.Add(p, m_pendingPackageSelections.Contains(p.Id));
                if (m_currentGPD.EntryPurchaseType == GeneralPlayerDrawing.PurchaseType.PRODUCT)
                    foreach (var p in m_productsAvailable)
                        entryPurchaseSelectionsCL.Items.Add(p, m_pendingProductSelections.Contains(p.Id));

                #endregion

                drawingDetailsGB.Visible = true;
                m_loadingDetails = false;
            }
        }

        private GeneralPlayerDrawing GeneratePendingDrawing()
        {
            var dfd = new GeneralPlayerDrawing(PendingName, PendingActive, PendingDescription
                , PendingEntriesDrawn, PendingMinimumEntries, PendingMaxDrawsPerPlayer, PendingShowEntriesOnReceipts, PendingPlayerPresenceRequired
                , PendingInitialEventEntryPeriodBegin, PendingInitialEventEntryPeriodEnd, PendingInitialEventScheduledForWhen
                , PendingEventRepeatIncrement, PendingEventRepeatInterval, PendingEventRepeatUntil
                , PendingEntrySessions
                , PendingPlayerEntryMaximum
                , PendingEntrySpendGrouping, PendingEntrySpendGrouping != GeneralPlayerDrawing.SpendGrouping.NONE ? PendingEntrySpendTiers : null
                , PendingEntryVisitType, PendingEntryVisitType != GeneralPlayerDrawing.VisitType.NONE ? PendingEntryVisitTiers : null
                , PendingEntryPurchaseType, PendingEntryPurchaseGrouping
                , PendingEntryPurchaseType != GeneralPlayerDrawing.PurchaseType.NONE ? PendingEntryPurchaseTiers : null
                , PendingEntryPurchaseType == GeneralPlayerDrawing.PurchaseType.PACKAGE ? PendingEntryPurchasePackages : null
                , PendingEntryPurchaseType == GeneralPlayerDrawing.PurchaseType.PRODUCT ? PendingEntryPurchaseProducts : null
                , PendingPrizeDescription
                , PendingDisclaimer
                , showZeroEntryCountChk.Checked
                , m_currentGPD.Id);

            return dfd;
        }


        private void SetAllItemCheck(bool check)
        {
            entrySessionNumbersCL.ItemCheck -= new ItemCheckEventHandler(entrySessionNumbersCL_ItemCheck);

            for (int i = 0; i != entrySessionNumbersCL.Items.Count; ++i)
            {
                if (entrySessionNumbersCL.GetItemChecked(i) != check)
                {
                    entrySessionNumbersCL.SetItemChecked(i, check);
                }
            }

            entrySessionNumbersCL.ItemCheck += new ItemCheckEventHandler(entrySessionNumbersCL_ItemCheck);
        }

        private void HideOrShowRepeatsPerCheckedStatus()
        {
            if (eventRepeatsChk.Checked)
            {
                eventRepeatDetailsPnl.Visible = true;
            }
            else
            {
                eventRepeatDetailsPnl.Visible = false;
            }
        }

        private void SetError(Control c, String errMsg)
        {
            errorProvider.SetIconAlignment(c, ErrorIconAlignment.MiddleRight);
            errorProvider.SetIconPadding(c, -2);
            errorProvider.SetError(c, errMsg);

            if (String.IsNullOrEmpty(errMsg))
                m_erroredControls.Remove(c);
            else if (!m_erroredControls.Contains(c))
                m_erroredControls.Add(c);
            saveDrawingChangesBtn.Enabled = m_editMode && m_erroredControls.Count == 0;

            if (m_erroredControls.Count > 0)
            {
                StringBuilder sb = new StringBuilder();
                foreach (var ec in m_erroredControls)
                sb.AppendLine(errorProvider.GetError(ec));
                errorProvider.SetError(saveDrawingChangesBtn, sb.ToString());
            }
            else
            {
                errorProvider.SetError(saveDrawingChangesBtn, null);
            }
        }

        void CheckEventDates()
        {
            if (initialEventEntryPeriodBeginDTP.Value.Date > initialEventEntryPeriodEndDTP.Value.Date)
                SetError(entryPeriodLbl, "Entry period begin must be before its end.");
            else
                SetError(entryPeriodLbl, null);

            if (!initialEventScheduledForDTP.Checked || initialEventScheduledForDTP.Value >= initialEventEntryPeriodEndDTP.Value.Date)
                SetError(initialEventScheduledForLbl, null);
            else
                SetError(initialEventScheduledForLbl, "Scheduled date should be on or after the end of the entry period.");
        }

        private void UpdateEventExamples()
        {
            eventExamplesLV.Items.Clear();
            eventExamplesLV.Columns.Clear();
            eventExamplesLV.BeginUpdate();
            try
            {
                if (initialEventEntryPeriodBeginDTP.Value.Date > initialEventEntryPeriodEndDTP.Value.Date)
                {
                    eventExamplesLV.Columns.Add("");
                    eventExamplesLV.Items.Add("(Invalid Entry Period)");
                    eventExamplesLV.Columns[0].AutoResize(ColumnHeaderAutoResizeStyle.ColumnContent);
                }
                else
                {
                    eventExamplesLV.Columns.Add("Entry Period");
                    eventExamplesLV.Columns.Add("Scheduled");

                    bool repeats = eventRepeatsChk.Checked;

                    DateTime b0 = initialEventEntryPeriodBeginDTP.Value.Date;
                    DateTime e0 = initialEventEntryPeriodEndDTP.Value.Date;
                    DateTime? s0 = initialEventScheduledForDTP.Checked ? (DateTime?)initialEventScheduledForDTP.Value.Date : null;
                    DateTime bN = b0;
                    DateTime eN = e0;
                    DateTime? sN = s0;

                    if (!repeats)
                    {
                        var lvi = eventExamplesLV.Items.Add(bN.ToShortDateString() + "-" + eN.ToShortDateString());
                        lvi.SubItems.Add(sN == null ? "---" : sN.Value.ToShortDateString());
                    }
                    else
                    {
                        int limit = repeats ? 100 : 1;
                        int lines = 0;

                        DateTime f = eventRepetitionEndsDTP.Checked ? eventRepetitionEndsDTP.Value.Date : DateTime.MaxValue;
                        DateTime listingF = DateTime.Now.AddYears(100);
                        int increment0 = PendingEventRepeatIncrement; ;
                        if (increment0 == 0)
                            limit = 1;

                        var interval = (string)eventRepeatIntervalCB.SelectedItem;

                        switch (interval)
                        {
                            case "day":
                            case "week":
                                if (interval == "week")
                                    increment0 *= 7;
                                while (lines < limit && bN < f && bN < listingF)
                                {
                                    if (eN > f)
                                        eN = f;

                                    if (sN.HasValue && sN.Value > f)
                                        sN = f;

                                    var lvi = eventExamplesLV.Items.Add(bN.ToShortDateString() + "-" + eN.ToShortDateString());
                                    lvi.SubItems.Add(sN == null ? "---" : sN.Value.ToShortDateString());
                                    lines++;

                                    try
                                    {
                                        bN = b0.AddDays(lines * increment0);
                                        eN = e0.AddDays(lines * increment0);
                                        if (s0.HasValue)
                                            sN = s0.Value.AddDays(lines * increment0);
                                    }
                                    catch { break; }
                                }
                                if (bN < f)
                                    eventExamplesLV.Items.Add("...and so on.");
                                break;

                            case "month":
                            case "quarter":
                                if (interval == "quarter")
                                    increment0 *= 3;
                                while (lines < limit && bN < f && bN < listingF)
                                {
                                    if (eN > f)
                                        eN = f;

                                    if (sN.HasValue && sN.Value > f)
                                        sN = f;

                                    var lvi = eventExamplesLV.Items.Add(bN.ToShortDateString() + "-" + eN.ToShortDateString());
                                    lvi.SubItems.Add(sN == null ? "---" : sN.Value.ToShortDateString());
                                    lines++;

                                    try
                                    {
                                        bN = b0.AddMonths(lines * increment0);
                                        eN = e0.AddMonths(lines * increment0);
                                        if (s0.HasValue)
                                            sN = s0.Value.AddMonths(lines * increment0);
                                    }
                                    catch { break; }
                                }
                                if (bN < f)
                                    eventExamplesLV.Items.Add("...and so on.");
                                break;

                            case "year":
                                while (lines < limit && bN < f && bN < listingF)
                                {
                                    if (eN > f)
                                        eN = f;

                                    if (sN.HasValue && sN.Value > f)
                                        sN = f;

                                    var lvi = eventExamplesLV.Items.Add(bN.ToShortDateString() + "-" + eN.ToShortDateString());
                                    lvi.SubItems.Add(sN == null ? "---" : sN.Value.ToShortDateString());
                                    lines++;

                                    try
                                    {
                                        bN = b0.AddYears(lines * increment0);
                                        eN = e0.AddYears(lines * increment0);
                                        if (s0.HasValue)
                                            sN = s0.Value.AddYears(lines * increment0);
                                    }
                                    catch { break; }
                                }
                                if (bN < f)
                                    eventExamplesLV.Items.Add("...and so on.");
                                break;

                            case "":
                            case null:
                                eventExamplesLV.Items.Add("(No Interval Specified)");
                                break;

                            default:
                                eventExamplesLV.Items.Add("(Unrecognized Interval)");
                                break;
                        }
                    }

                    eventExamplesLV.Columns[0].AutoResize(ColumnHeaderAutoResizeStyle.ColumnContent);
                    eventExamplesLV.Columns[1].AutoResize(ColumnHeaderAutoResizeStyle.HeaderSize);

                }
            }
            finally
            {
                eventExamplesLV.EndUpdate();
            }
        }

        #endregion
        #region Events

        void entryScaleDGV_Leave(object sender, EventArgs e)
        {
            var dgv = sender as DataGridView;
            if(dgv.IsCurrentCellDirty)
                dgv.CommitEdit(new DataGridViewDataErrorContexts());
        }

        private void entryScaleDGV_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            var dgv = sender as DataGridView;
            var col = dgv.Columns[e.ColumnIndex];

            if(col is DataGridViewButtonColumn && col.Name == "removeDGVBC" && e.RowIndex < dgv.Rows.Count)
                dgv.Rows.RemoveAt(e.RowIndex);
        }

        void entryScaleDGV_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if(m_loadingDetails)
                return;
            CheckEntryScale(sender as DataGridView);
        }

        void entryScaleDGV_RowsRemoved(object sender, DataGridViewRowsRemovedEventArgs e)
        {
            if(m_loadingDetails)
                return;
            CheckEntryScale(sender as DataGridView);
        }

        void entryScaleDGV_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            if(m_loadingDetails)
                return;
            CheckEntryScale(sender as DataGridView);
        }

      
        private void entrySpendGroupingRB_CheckedChanged(object sender, EventArgs e)
        {
            var rb = sender as RadioButton;
            if(rb.Checked)
            {
                entrySpendTP.Text = "Spend (" + rb.Text + ")";

                var entryMethodUsed = !Object.ReferenceEquals(rb, entrySpendGroupingNoneRB);

                entrySpendScaleDGV.Visible = entryMethodUsed;
                addEntrySpendTierBtn.Visible = entryMethodUsed;
                CheckEntryScale(entrySpendScaleDGV);
            }
            CheckEntryMethods();
        }

        private void entryVisitTypeRB_CheckedChanged(object sender, EventArgs e)
        {
            var rb = sender as RadioButton;
            if(rb.Checked)
            {
                entryVisitsTP.Text = "Visits (" + rb.Text + ")";

                var entryMethodUsed = !Object.ReferenceEquals(rb, entryVisitTypeNoneRB);

                entryVisitScaleDGV.Visible = entryMethodUsed;
                addEntryVisitTierBtn.Visible = entryMethodUsed;
                CheckEntryScale(entryVisitScaleDGV);
            }
            CheckEntryMethods();
        }

        private void entryPurchaseGroupingRB_CheckedChanged(object sender, EventArgs e)
        {
            var rb = sender as RadioButton;
            UpdateEntryPurchaseTPHeader();
            CheckEntryMethods();
        }

        private void entryPurchaseTypeRB_CheckedChanged(object sender, EventArgs e)
        {
            var rb = sender as RadioButton;
            UpdateEntryPurchaseTPHeader();
            if(rb.Checked)
            {

                var entryMethodUsed = !Object.ReferenceEquals(rb, entryPurchaseTypeNoneRB);

                entryPurchaseScaleDGV.Visible = entryMethodUsed;
                addEntryPurchaseTierBtn.Visible = entryMethodUsed;
                entryPurchaseSelectionsCL.Visible = entryMethodUsed;
                CheckEntryScale(entryPurchaseScaleDGV);

                if(Object.ReferenceEquals(rb, entryPurchaseTypePackageRB))
                {
                    entryPurchaseSelectionsCL.Items.Clear();
                    foreach(var p in m_packagesAvailable)
                        if(p.IsActive || m_pendingPackageSelections.Contains(p.Id))
                            entryPurchaseSelectionsCL.Items.Add(p, m_pendingPackageSelections.Contains(p.Id));
                }
                if(Object.ReferenceEquals(rb, entryPurchaseTypeProductRB))
                {
                    entryPurchaseSelectionsCL.Items.Clear();
                    foreach(var p in m_productsAvailable)
                        if(p.IsActive || m_pendingProductSelections.Contains(p.Id))
                            entryPurchaseSelectionsCL.Items.Add(p, m_pendingProductSelections.Contains(p.Id));
                }
            }
            CheckEntryMethods();
        }

      
        private void entryLimitTxt_TextChanged(object sender, EventArgs e)
        {
            //var tb = sender as TextBox;
            //int parseTarget = 0;

            //if(String.IsNullOrWhiteSpace(tb.Text))
            //    SetError(tb, null);
            //else if(!int.TryParse(tb.Text, out parseTarget))
            //    SetError(tb, "Limit must be numeric");
            //else if(parseTarget <= 0)
            //    SetError(tb, "Limit must be greater than 0.");
            //else
            //    SetError(tb, null);
        }

        private void entryLimitTxt_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Back)
            {
                e.Handled = false;
            }
            else
                if (!char.IsNumber(e.KeyChar) && !char.IsControl(e.KeyChar))
                {
                    e.Handled = true;
                }
                else
                {
                    var tb = sender as TextBox;
                    int parseTarget = 0;

                    if (String.IsNullOrWhiteSpace(tb.Text))
                    {
                        e.Handled = false;
                       // SetError(tb, null);
                    }
                    else if (!int.TryParse(tb.Text, out parseTarget))
                    {
                        e.Handled = true;
                        //SetError(tb, "Limit must be numeric");
                    }
                    else if (parseTarget <= 0)
                    {
                        e.Handled = true;
                        //SetError(tb, "Limit must be greater than 0.");
                    }
                    else
                        SetError(tb, null);
                }
        }

        private void requiredUIntTxt_TextChanged(object sender, EventArgs e)
        {
            //var tb = sender as TextBox;
            //uint parseUInt;
            //if(!uint.TryParse(tb.Text, out parseUInt) || parseUInt == 0)
            //    SetError(tb, "Must be whole number greater than 0.");
            //else
            //    SetError(tb, null);
        }

        private void requiredIntTxt_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Back)
            {
                e.Handled = false;
            }
            else
                if (!Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar))
                    e.Handled = true;
                else
                {
                    var tb = sender as TextBox;
                    uint parseUInt;
                    if (!uint.TryParse(tb.Text, out parseUInt) || parseUInt == 0)
                    {
                        e.Handled = true;
                    }
                }
        }


        private void eventRepeatIncrementTxt_TextChanged(object sender, EventArgs e)
        {
            var tb = sender as TextBox;
            int parseTarget = 0;
            string errMsg = null;

            if(eventRepeatsChk.Checked)
            {
                if(String.IsNullOrWhiteSpace(tb.Text) || !int.TryParse(tb.Text, out parseTarget) || parseTarget < 0)
                    errMsg = "Event repeat increment must be a non-negative whole number.";
                else if(parseTarget > Int16.MaxValue)
                    errMsg = "Event repeat increment too large.";
            }

            SetError(tb, errMsg);

            if(sender != null)
                UpdateEventExamples();
        }

        private void entryPeriodRepeatIncrementTxt_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(!char.IsNumber(e.KeyChar) && !char.IsControl(e.KeyChar))
                e.Handled = true;

            if(sender != null)
                UpdateEventExamples();
        }

        private void drawingsLV_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(drawingsLV.SelectedItems.Count == 1)
                SetCurrentDrawing(drawingsLV.SelectedItems[0].Tag as GeneralPlayerDrawing);
            else
                SetCurrentDrawing(null);
        }

      
        private void editDrawingBtn_Click(object sender, EventArgs e) 
        { 
            ToggleEditMode(true); 
        }

        private void copyDrawingBtn_Click(object sender, EventArgs e)
        {
            drawingsLV.HideSelection = true;
            var gpd = new GeneralPlayerDrawing(m_currentGPD, true);
            gpd.Name = String.Format("Copy of {0}", gpd.Name);
            SetCurrentDrawing(gpd);
            ToggleEditMode(true);
        }

        private void newDrawingBtn_Click(object sender, EventArgs e)
        {
            if (drawingDetailsTC.SelectedIndex != 0) drawingDetailsTC.SelectedIndex = 0;
            drawingsLV.HideSelection = true;
            SetCurrentDrawing(new GeneralPlayerDrawing());
            SetAllItemCheck(true);
            SetError(entrySessionsLbl, null);
            drawingNameTxt.Text = "New " + m_displayedText;          
            ToggleEditMode(true);
           
        }

        private void cancelDrawingChangesBtn_Click(object sender, EventArgs e)
        {
            drawingsLV_SelectedIndexChanged(null, null);
            ToggleEditMode(false);
            drawingsLV.HideSelection = false;
        }

        private void revertDrawingChangesBtn_Click(object sender, EventArgs e) { LoadCurrentDrawingDetails(); }

        private void saveDrawingChangesBtn_Click(object sender, EventArgs e)
        {
            var candidate = GeneratePendingDrawing();

            if(candidate.Id == null && !candidate.Active)
            {
                var dr = MessageForm.Show(this
                    , "You are about to save a new drawing without it first being active." + Environment.NewLine
                        + "Would you like to saved as Active?"
                    , "New Drawing not Active"
                    , MessageFormTypes.YesNoCancel
                    );

                switch(dr)
                {
                    case System.Windows.Forms.DialogResult.Yes:
                        candidate.Active = true;
                        break;
                    case System.Windows.Forms.DialogResult.Cancel:
                        return;
                    case System.Windows.Forms.DialogResult.No:
                        break;
                }
            }

            var saveResult = SetGeneralDrawingMessage.SetDrawing(candidate);

            if(saveResult != null)
            {
                if(candidate.Id == null)
                    m_drawings.Add(saveResult);
                else
                {
                    var orig = m_drawings.FirstOrDefault((d) => d.Id == saveResult.Id);
                    m_drawings.Remove(orig);
                    m_drawings.Add(saveResult);
                }

                m_drawings.Sort(DrawingSortComparer.Comparer);
                ListDrawings(saveResult.Id);
                ToggleEditMode(false);
                drawingsLV.HideSelection = false;

            }
            else
            {
                //Save failed
                MessageBox.Show("Save Failed", "Save Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void closeBtn_Click(object sender, EventArgs e) 
        { 
            this.Close(); 
        }

        private void GeneralPlayerDrawingForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if(m_editMode)
            {
                var r = MessageForm.Show(this, "Current changes will be lost if not saved before closing this form. Close anyway?"
                                        , "Confirm Close"
                                        , MessageFormTypes.YesNo
                                        );
                if(r != System.Windows.Forms.DialogResult.Yes)
                    e.Cancel = true;
            }
        }

      
        private void addEntrySpendTierBtn_Click(object sender, EventArgs e)
        {
            m_entrySpendScaleDT.Rows.Add();
            entrySpendScaleDGV.Focus();
        }

        private void addEntryVisitTierBtn_Click(object sender, EventArgs e)
        {
            m_entryVisitScaleDT.Rows.Add();
            entryVisitScaleDGV.Focus();
        }

        private void addEntryPurchaseTierBtn_Click(object sender, EventArgs e)
        {
            m_entryPurchaseScaleDT.Rows.Add();
            entryPurchaseScaleDGV.Focus();
        }

        private void entryPurchaseSelectionsCL_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            var item = entryPurchaseSelectionsCL.Items[e.Index] as PurchaseItemListing;
            var checking = e.NewValue == CheckState.Checked;
            if(checking)
            {
                if(PendingEntryPurchaseType == GeneralPlayerDrawing.PurchaseType.PACKAGE)
                    m_pendingPackageSelections.Add(item.Id);
                if(PendingEntryPurchaseType == GeneralPlayerDrawing.PurchaseType.PRODUCT)
                    m_pendingProductSelections.Add(item.Id);
            }
            else
            {
                if(PendingEntryPurchaseType == GeneralPlayerDrawing.PurchaseType.PACKAGE)
                    m_pendingPackageSelections.Remove(item.Id);
                if(PendingEntryPurchaseType == GeneralPlayerDrawing.PurchaseType.PRODUCT)
                    m_pendingProductSelections.Remove(item.Id);
            }

        }

        private void initialEventEntryPeriodBeginDTP_ValueChanged(object sender, EventArgs e)
        {
            if(m_loadingDetails)
                return;

            CheckEventDates();
            UpdateEventExamples();
        }

        private void initialEventEntryPeriodEndDTP_ValueChanged(object sender, EventArgs e)
        {
            if(m_loadingDetails)
                return;

            CheckEventDates();
            eventRepetitionEndsDTP_ValueChanged(null, null);
            UpdateEventExamples();
        }

        private void initialEventScheduledForDTP_ValueChanged(object sender, EventArgs e)
        {
            if(m_loadingDetails)
                return;

            CheckEventDates();
            UpdateEventExamples();
        }

        private void eventRepeatsChk_CheckedChanged(object sender, EventArgs e)
        {
            HideOrShowRepeatsPerCheckedStatus();
            eventRepeatDetailsPnl.Enabled = eventRepeatsChk.Checked;
            eventRepeatIncrementTxt_TextChanged(eventRepeatIncrementTxt, null);
            eventRepeatIntervalCB_SelectedIndexChanged(null, null);
            eventRepetitionEndsDTP_ValueChanged(null, null);
            UpdateEventExamples();
        }

        private void eventRepeatIntervalCB_SelectedIndexChanged(object sender, EventArgs e)
        {
            String err = null;
            if(eventRepeatsChk.Checked && String.IsNullOrWhiteSpace((String)eventRepeatIntervalCB.SelectedItem))
                err = "Interval must be selected for repeating drawings.";
            SetError(eventRepeatIntervalCB, err);

            if(sender != null)
                UpdateEventExamples();
        }

        private void eventRepetitionEndsDTP_ValueChanged(object sender, EventArgs e)
        {
            String err = null;
            if(eventRepeatsChk.Checked && eventRepetitionEndsDTP.Checked && eventRepetitionEndsDTP.Value.Date < initialEventEntryPeriodEndDTP.Value.Date)
                err = "When provided, repeat 'until' date must be later than initial entry window.";
            SetError(eventRepetitionEndsDTP, err);

            if(sender != null)
                UpdateEventExamples();
        }

     

        private void showInactiveDrawingsChk_CheckedChanged(object sender, EventArgs e) { ListDrawings(); }

        private void drawingNameTxt_TextChanged(object sender, EventArgs e)
        {
            String errMsg = null;

            int drawingNameLenLimit = 48;
            int drawingNameLen = drawingNameTxt.Text.Length;
            if(drawingNameLen > drawingNameLenLimit)
                errMsg = String.Format( m_displayedText + " name may be no longer than {0} characters, currently {1}.", drawingNameLenLimit, drawingNameLen);
            else
            {
                var namingConflict = m_drawings.FirstOrDefault((d) => d.Name.ToLower() == drawingNameTxt.Text.ToLower() && (m_currentGPD.Id == null || m_currentGPD.Id != d.Id));
                if(namingConflict != null)
                    errMsg = String.Format(m_displayedText + " must have unique names{0}", namingConflict.Active ? "." : ", even considering drawings that are no longer active.");
            }

            SetError(drawingNameTxt, errMsg);

        }

        private void entrySessionNumbersCL_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            bool hasChecks = false;

            if(e == null)
                hasChecks = entrySessionNumbersCL.CheckedItems.Count > 0;
            else if (e.NewValue == CheckState.Checked || entrySessionNumbersCL.CheckedItems.Count > 1)
                hasChecks = true;

            if (hasChecks)
                SetError(entrySessionsLbl, null);
            else
                SetError(entrySessionsLbl, m_displayedText +" should have one or more sessions selected for entries to be accepted.");
        }

        private void testEventsBtn_Click(object sender, EventArgs e)
        {
            var f = new GeneralPlayerDrawingEventsTestForm(m_drawings, m_displayedText);
            f.ShowDialog(this);
            f.Dispose();
        }

        private void m_imgbtnSelectAllSession_Click(object sender, EventArgs e)
        {
            //Check if all session are check
            var tCheckedItem = entrySessionNumbersCL.CheckedItems.Count;
            var tSession = entrySessionNumbersCL.Items.Count;

            if (tCheckedItem == tSession)
            {
                SetAllItemCheck(false);
                 SetError(entrySessionsLbl, m_displayedText + " should have one or more sessions selected for entries to be accepted.");
            }
            else
            {
                SetAllItemCheck(true);
                SetError(entrySessionsLbl, null);
            }                           
        }

        private void entrySpendScaleDGV_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            var dgv = (DataGridView)sender;
           m_selectedColumnDataType = dgv.CurrentCell.ValueType;

            e.Control.KeyPress -= new KeyPressEventHandler(Cell_KeyPress);
            e.Control.KeyPress += new KeyPressEventHandler(Cell_KeyPress);
        }

        private void Cell_KeyPress(object sender, KeyPressEventArgs e)
        {
            var txtbxValue = (TextBox)sender;      
            bool result = true;

            if (m_selectedColumnDataType == typeof(int))
            {
                if (e.KeyChar == (char)Keys.Back)
                {
                    result = false;

                }
                if (result)
                {
                    result = !char.IsDigit(e.KeyChar);
                }
            }
            else if (m_selectedColumnDataType == typeof(decimal))
            {
                result = false;

                if (!char.IsControl(e.KeyChar)
                    && !char.IsDigit(e.KeyChar)
                    && e.KeyChar != '.')
                {
                    e.Handled = true;
                    result = e.Handled;
                }

                if (e.KeyChar == '.'
                    && (sender as TextBox).Text.IndexOf('.') > -1)
                {
                    e.Handled = true;
                    result = e.Handled;
                }
            }
            e.Handled = result;
        }

        private void showEntryCountOnReceiptsChk_CheckedChanged(object sender, EventArgs e)
        {
            if (showEntryCountOnReceiptsChk.Checked)
                showZeroEntryCountChk.Enabled = true;
            else
                showZeroEntryCountChk.Enabled = false;
        }

        private void entryMethodsTC_DrawItem(object sender, DrawItemEventArgs e)
        {
            e.DrawBackground();            //we want the tab control to paint with the top area to the right of the last tab as invisible.
            Rectangle rect = entryMethodsTC.ClientRectangle; //find the control's rectangle and make it into a rectangle covering the area we want to fix
            rect.X = entryMethodsTC.GetTabRect(entryMethodsTC.TabCount - 1).X + entryMethodsTC.GetTabRect(entryMethodsTC.TabCount - 1).Width;
            rect.Width -= entryMethodsTC.GetTabRect(entryMethodsTC.TabCount - 1).X;
            rect.Height = entryMethodsTC.GetTabRect(entryMethodsTC.TabCount - 1).Height;
            e.Graphics.FillRectangle(new SolidBrush(Color.LightSteelBlue), rect); //draw the rectangle filled with the color from that area of the background image
            rect = entryMethodsTC.GetTabRect(e.Index);//draw our tab
            rect.Height += 2; //covers small "selected" color under tab
            e.Graphics.FillRectangle(e.State == DrawItemState.Selected ? SystemBrushes.Control : SystemBrushes.ControlLight, rect);   //we'll make our unselected tabs a little lighter than the selected tab

            if (!entryMethodsTC.Enabled)
            {
                e.Graphics.DrawString(entryMethodsTC.TabPages[e.Index].Text, entryMethodsTC.Font, System.Drawing.Brushes.Black, new PointF(e.Bounds.X - 1, e.Bounds.Y - 1));
                e.Graphics.DrawString(entryMethodsTC.TabPages[e.Index].Text, entryMethodsTC.Font, System.Drawing.Brushes.White, new PointF(e.Bounds.X + 1, e.Bounds.Y + 1));
                e.Graphics.DrawString(entryMethodsTC.TabPages[e.Index].Text, entryMethodsTC.Font, System.Drawing.Brushes.Gray, new PointF(e.Bounds.X, e.Bounds.Y));
            }
            else
            {
                e.Graphics.DrawString(entryMethodsTC.TabPages[e.Index].Text, entryMethodsTC.Font, System.Drawing.Brushes.Black, new PointF(e.Bounds.X, e.Bounds.Y));
            }
        }

        private void dgv_EnabledChanged(object sender, EventArgs e)
        {
            DataGridView selectedDgv = (DataGridView)sender;
            if (!selectedDgv.Enabled)
            {
                selectedDgv.DefaultCellStyle.BackColor = SystemColors.Control;
                selectedDgv.DefaultCellStyle.ForeColor = SystemColors.GrayText;
                selectedDgv.ColumnHeadersDefaultCellStyle.BackColor = SystemColors.Control;
                selectedDgv.ColumnHeadersDefaultCellStyle.ForeColor = SystemColors.GrayText;
                selectedDgv.CurrentCell = null;
                selectedDgv.ReadOnly = true;
                selectedDgv.EnableHeadersVisualStyles = false;
            }
            else
            {
                selectedDgv.DefaultCellStyle.BackColor = SystemColors.Window;
                selectedDgv.DefaultCellStyle.ForeColor = SystemColors.ControlText;
                selectedDgv.ColumnHeadersDefaultCellStyle.BackColor = SystemColors.Window;
                selectedDgv.ColumnHeadersDefaultCellStyle.ForeColor = SystemColors.ControlText;
                selectedDgv.ReadOnly = false;
                selectedDgv.EnableHeadersVisualStyles = true;
            }
        }
        #endregion
        #region Pending Drawing Properties
        public string PendingName { get { return drawingNameTxt.Text.Trim(); } }
        public bool PendingActive { get { return drawingActiveChk.Checked; } }
        public string PendingDescription { get { return drawingDescriptionTxt.Text.Trim(); } }
        public int PendingEntriesDrawn { get { return int.Parse(drawingEntriesDrawnTxt.Text); } }
        public int PendingMinimumEntries { get { return int.Parse(minimumEntriesToRunTxt.Text); } }
        public int PendingMaxDrawsPerPlayer { get { return int.Parse(maximumDrawsPerPlayerTxt.Text); } }
        public bool PendingShowEntriesOnReceipts { get { return showEntryCountOnReceiptsChk.Checked; } }
        public bool PendingPlayerPresenceRequired { get { return playerPresenceRequiredChk.Checked; } }
        public DateTime PendingInitialEventEntryPeriodBegin { get { return initialEventEntryPeriodBeginDTP.Value.Date; } }
        public DateTime PendingInitialEventEntryPeriodEnd { get { return initialEventEntryPeriodEndDTP.Value.Date; } }
        public DateTime? PendingInitialEventScheduledForWhen { get { return (initialEventScheduledForDTP.Checked ? (DateTime?)initialEventScheduledForDTP.Value.Date : null); } }
        public String PendingEventRepeatInterval { get { return eventRepeatsChk.Checked ? (String)eventRepeatIntervalCB.SelectedItem : ""; } }
        public DateTime? PendingEventRepeatUntil { get { return (eventRepetitionEndsDTP.Checked ? (DateTime?)eventRepetitionEndsDTP.Value.Date : null); } }
        public int? PendingPlayerEntryMaximum { get { return UILimitToNInt(entryLimitEventTxt.Text); } }
        public List<int> PendingEntryPurchasePackages { get { return m_pendingPackageSelections; } }
        public List<int> PendingEntryPurchaseProducts { get { return m_pendingProductSelections; } }
        public string PendingPrizeDescription { get { return txtbx_PrizeDescription.Text.Trim(); } }
        public string PendingDisclaimer { get { return txtbx_disclaimer.Text.Trim(); } }

        public Int16 PendingEventRepeatIncrement
        {
            get
            {
                if (!eventRepeatsChk.Checked)
                    return 0;
                else
                {
                    Int16 parseVal = 0;
                    Int16.TryParse(eventRepeatIncrementTxt.Text, out parseVal);
                    return parseVal;
                }
            }
        }
      
        public List<byte> PendingEntrySessions
        {
            get
            {
                var pes = new List<byte>();
                foreach (var i in entrySessionNumbersCL.CheckedItems)
                    pes.Add((i as SessionNumberListing).SessionNumber);
                return pes;
            }
        }

        public GeneralPlayerDrawing.SpendGrouping PendingEntrySpendGrouping
        {
            get
            {
                if (entrySpendGroupingByTransactionRB.Checked)
                    return GeneralPlayerDrawing.SpendGrouping.BY_TRANSACTION;

                if (entrySpendGroupingBySessionRB.Checked)
                    return GeneralPlayerDrawing.SpendGrouping.BY_SESSION;

                if (entrySpendGroupingByDayRB.Checked)
                    return GeneralPlayerDrawing.SpendGrouping.BY_DAY;

                if (entrySpendGroupingEntryPeriodRB.Checked)
                    return GeneralPlayerDrawing.SpendGrouping.WITHIN_ENTRY_WINDOW;

                return GeneralPlayerDrawing.SpendGrouping.NONE;
            }
        }

        public SortedSet<GeneralPlayerDrawing.EntryTier<decimal>> PendingEntrySpendTiers
        {
            get
            {
                var candidateScale = UIEntryScaleToEntryScale<decimal>(m_entrySpendScaleDT);
                return candidateScale ?? new SortedSet<GeneralPlayerDrawing.EntryTier<decimal>>();
            }
        }

        public GeneralPlayerDrawing.VisitType PendingEntryVisitType
        {
            get
            {
                if (entryVisitTypeSessionsPerDayRB.Checked)
                    return GeneralPlayerDrawing.VisitType.SESSIONS_PER_DAY;

                if (entryVisitTypeDaysInEntryPeriodWindowRB.Checked)
                    return GeneralPlayerDrawing.VisitType.DAYS_IN_ENTRY_PERIOD;

                if (entryVisitTypeSessionsInEntryPeriodRB.Checked)
                    return GeneralPlayerDrawing.VisitType.SESSIONS_IN_ENTRY_PERIOD;

                return GeneralPlayerDrawing.VisitType.NONE;
            }
        }

        public SortedSet<GeneralPlayerDrawing.EntryTier<int>> PendingEntryVisitTiers
        {
            get
            {
                var candidateScale = UIEntryScaleToEntryScale<int>(m_entryVisitScaleDT);
                return candidateScale ?? new SortedSet<GeneralPlayerDrawing.EntryTier<int>>();
            }
        }

        public GeneralPlayerDrawing.PurchaseType PendingEntryPurchaseType
        {
            get
            {
                if (entryPurchaseTypePackageRB.Checked)
                    return GeneralPlayerDrawing.PurchaseType.PACKAGE;

                if (entryPurchaseTypeProductRB.Checked)
                    return GeneralPlayerDrawing.PurchaseType.PRODUCT;

                return GeneralPlayerDrawing.PurchaseType.NONE;
            }
        }

        public GeneralPlayerDrawing.PurchaseGrouping PendingEntryPurchaseGrouping
        {
            get
            {
                if (entryPurchaseGroupingByTransactionRB.Checked)
                    return GeneralPlayerDrawing.PurchaseGrouping.BY_TRANSACTION;

                if (entryPurchaseGroupingBySessionRB.Checked)
                    return GeneralPlayerDrawing.PurchaseGrouping.BY_SESSION;

                if (entryPurchaseGroupingByDayRB.Checked)
                    return GeneralPlayerDrawing.PurchaseGrouping.BY_DAY;

                if (entryPurchaseGroupingEntryPeriodRB.Checked)
                    return GeneralPlayerDrawing.PurchaseGrouping.WITHIN_ENTRY_WINDOW;

                return GeneralPlayerDrawing.PurchaseGrouping.NONE;
            }
        }

        public SortedSet<GeneralPlayerDrawing.EntryTier<int>> PendingEntryPurchaseTiers
        {
            get
            {
                var candidateScale = UIEntryScaleToEntryScale<int>(m_entryPurchaseScaleDT);
                return candidateScale ?? new SortedSet<GeneralPlayerDrawing.EntryTier<int>>();
            }
        }
        #endregion
    }
}
