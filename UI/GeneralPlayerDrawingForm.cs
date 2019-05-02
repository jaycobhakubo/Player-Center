using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using GTI.Modules.Shared;
using GeneralPlayerDrawing = GTI.Modules.Shared.Business.GeneralPlayerDrawing;
using System.Text.RegularExpressions;


namespace GTI.Modules.PlayerCenter.UI
{
    public partial class GeneralPlayerDrawingForm : GradientForm
    {
        #region VARIABLES

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
        private const bool c_enablePurchaseUI = false;
        private Type m_selectedColumnDataType;
        private bool m_cellLastEntry = false;
        private string m_cellActualValue = "";
        private DataGridView m_selectedDataGridView = new DataGridView();
        private bool m_isUserInputValid = false;

        #endregion

        #region STATIC METHODS

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

        #endregion

        #region OTHER CLASS

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
                if (sessionNumber != 0)
                {
                    DisplayString = String.Format("Session {0}", SessionNumber);
                }
                else
                {
                    DisplayString = String.Format("All Session");
                }
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

        #endregion

        #region CONSTRUCTOR

        public GeneralPlayerDrawingForm()
        {
            InitializeComponent();

            LoadEntrySessionsCheckList();
            InitEntryScaleElements();
            ChangeDateFormatToSavedSpace();
            HideOrShowRepeatsPerCheckedStatus();

            if(!c_enablePurchaseUI)
                entryMethodsTC.TabPages.Remove(entryPurchasesTP);
            else
            {
                LoadPackages();
                LoadProducts();
            }

            LoadGeneralDrawings();

            ToggleEditMode(false);
        }

        #endregion

        #region METHOD(member)


        private bool IsCellLastEntry(DataGridViewRow dgvr)
        {
            bool result = true;
            for (int i = 0; i < 3; ++i)
            {
                if (dgvr.Cells[i + 1].Style.ForeColor == Color.LightGray)
                {
                    result = false;
                }
            }
            m_cellLastEntry = result;
            return result;
        }

        private bool IsFromOk()
        {
            bool result = false;

            
            return result;
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

        private void SetAllItemCheck(bool check)
        {
            entrySessionNumbersCL.ItemCheck -= new ItemCheckEventHandler(entrySessionNumbersCL_ItemCheck);

            for (int i = 1; i != entrySessionNumbersCL.Items.Count; ++i)
            {
                if (entrySessionNumbersCL.GetItemChecked(i) != check)
                {
                    entrySessionNumbersCL.SetItemChecked(i, check);
                }
            }

            entrySessionNumbersCL.ItemCheck += new ItemCheckEventHandler(entrySessionNumbersCL_ItemCheck);
        }

        private void SetEntryMethodBothUI()
        {
            entryMethodsTC.Appearance = TabAppearance.Normal;
            entryMethodsTC.ItemSize = new Size(79, 27);
            entryMethodsTC.SizeMode = TabSizeMode.Normal;
        }

        private void HideEntryMethodBothUI()
        {
            entryMethodsTC.Appearance = TabAppearance.FlatButtons;
            entryMethodsTC.ItemSize = new Size(0, 1);
            entryMethodsTC.SizeMode = TabSizeMode.Fixed;
        }

        private void SetIndicatorOnOff(bool set, DataGridView activeDGV)
        {
            //if (set)
            //{
            //    if (m_selectedColumnDataType == typeof(int))
            //    {
            //        dgv.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = "0";
            //        dgvr.Cells[e.ColumnIndex].Style.ForeColor = Color.LightGray;
            //    }
            //    else if (m_selectedColumnDataType == typeof(decimal))
            //    {
            //        dgv.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = "00.00";
            //        dgvr.Cells[e.ColumnIndex].Style.ForeColor = Color.LightGray;
            //    }
            //}
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

        private void SetError(Control c, String errMsg)
        {
            errorProvider.SetIconPadding(c, -15); 
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
                , m_currentGPD.Id);

            return dfd;
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
            //Set default 
            rdobtn_Spend.Checked = true;
            #endregion
            #endregion

            if (m_currentGPD != null)
            {
                drawingNameTxt.Text = m_currentGPD.Name;
                drawingActiveChk.Checked = m_currentGPD.Active;
                drawingDescriptionTxt.Text = m_currentGPD.Description;
                drawingEntriesDrawnTxt.Text = m_currentGPD.EntriesDrawn.ToString();
                minimumEntriesToRunTxt.Text = m_currentGPD.MinimumEntries.ToString();
                maximumDrawsPerPlayerTxt.Text = m_currentGPD.MaximumDrawsPerPlayer.ToString();
                showEntryCountOnReceiptsChk.Checked = m_currentGPD.ShowEntriesOnReceipts;
                playerPresenceRequiredChk.Checked = m_currentGPD.PlayerPresenceRequired;

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

        private bool IsCellIndicator(int rowIndex, int columnIndex, DataGridView dgv)
        {
            bool result = false;
            var dgvr = dgv.Rows[rowIndex];
            if (dgvr.Cells[columnIndex + 1].Style.ForeColor == Color.LightGray)
            {
                result = true;
            }
            return result;
        }

        private bool IsUserInputValid()
        {
            bool result = false;
            int intResult;
            decimal decResult;

            if (m_selectedColumnDataType == typeof(int))
            {
                result = int.TryParse(m_cellActualValue, out intResult);
            }
            else if(m_selectedColumnDataType == typeof(decimal))
            {
                result =  decimal.TryParse(m_cellActualValue, out decResult);
            }

            return result;
        }

        private void CheckEntryMethods()
        {
            if (PendingEntrySpendGrouping == GeneralPlayerDrawing.SpendGrouping.NONE
                && PendingEntryVisitType == GeneralPlayerDrawing.VisitType.NONE
                && (PendingEntryPurchaseGrouping == GeneralPlayerDrawing.PurchaseGrouping.NONE
                    || PendingEntryPurchaseType == GeneralPlayerDrawing.PurchaseType.NONE
                    )
                )
                SetError(entryMethodsTP, "No entry method specified.");
            else
                SetError(entryMethodsTP, null);
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
                        {
                            if (IsCellIndicator(dt.Rows.IndexOf(dr), i, dgv))
                            {
                                SetError(dgv, String.Format("Tier entry missing {0} value.", dt.Columns[i].ColumnName));
                                return;
                            }

                            if (m_cellLastEntry)
                            {
                                if (!IsUserInputValid())
                                {
                                    SetError(dgv, String.Format("Tier entry missing {0} value.", dt.Columns[i].ColumnName));
                                    return;
                                }
                            }


                          
                                if (dr[i] == DBNull.Value) 
                                {
                                    bool result = false;
                                    decimal decResult;
                                    int intResult;

                                    if (dt.Columns[i].DataType == typeof(decimal))
                                    {
                                        result = decimal.TryParse(m_cellActualValue.ToString(), out decResult);
                                        if (result)
                                        {
                                            dr[i] = Convert.ToDecimal(m_cellActualValue.ToString());
                                        }
                                    }
                                    else if (dt.Columns[i].DataType == typeof(int))
                                    {
                                        result = int.TryParse(m_cellActualValue.ToString(), out intResult);
                                        if (result)
                                        {
                                            dr[i] = Convert.ToInt32(m_cellActualValue.ToString());
                                        }
                                    }

                                    if (result == false)
                                    {
                                        SetError(dgv, String.Format("Tier entry missing {0} value.", dt.Columns[i].ColumnName));
                                        return;
                                    }
                                }
                                else
                                {

                                    //SetError(dgv, String.Format("Tier entry missing {0} value.", dt.Columns[i].ColumnName));
                                    //return;
                                }
                            
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

            //for(int i = 0; i < 100; ++i)
            //    m_packagesAvailable.Add(new PurchaseItemListing(i, String.Format("Package {0}", i)));
        }

        private void LoadProducts()
        {
            var p = GTI.Modules.Shared.Data.GetProductItemsMessage.GetProductItems(0).OrderBy((i) => i.ProductItemName);

            foreach (var prod in p)
                m_productsAvailable.Add(new PurchaseItemListing(prod));

            //for(int i = 0; i < 100; ++i)
            //    m_productsAvailable.Add(new PurchaseItemListing(i, String.Format("Product {0}", i)));
        }

        private void LoadGeneralDrawings()
        {
            m_drawings = GTI.Modules.Shared.Data.GetGeneralDrawingsMessage.GetDrawings();
            m_drawings.Sort(DrawingSortComparer.Comparer);
            ListDrawings();
        }

        private void ListDrawings(int? selectId = null)
        {
            SetCurrentDrawing(null);

            drawingsLV.BeginUpdate();

            try
            {
                var inactiveFont = new Font(drawingsLV.Font, FontStyle.Bold | /*FontStyle.Italic*/FontStyle.Regular);
                drawingsLV.Columns.Clear();
                //drawingsLV.Columns.Add("Name");
                ColumnHeader columnHeaderShowOnlyThis = new ColumnHeader();
                columnHeaderShowOnlyThis.Text = "";
                columnHeaderShowOnlyThis.Name = "clmnHeader";
                drawingsLV.Columns.Add(columnHeaderShowOnlyThis);
                drawingsLV.HeaderStyle = ColumnHeaderStyle.None;

                if (selectId == null && drawingsLV.SelectedItems.Count == 1)
                    selectId = (drawingsLV.SelectedItems[0].Tag as GeneralPlayerDrawing).Id;

                drawingsLV.Items.Clear();
                if (m_drawings != null)
                    foreach (var d in m_drawings)
                        if (d.Active || showInactiveDrawingsChk.Checked)
                        {
                            var lvi = drawingsLV.Items.Add(d.Name);
                            lvi.Tag = d;

                            if (!d.Active)
                                lvi.Font = inactiveFont;

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
            //entrySessionNumbersCL.Items.Add(new  "All Session");
            for (Byte i = 0; i <= 16; ++i)
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

        private void ChangeDateFormatToSavedSpace()
        {
            initialEventEntryPeriodBeginDTP.Format = DateTimePickerFormat.Custom;
            initialEventEntryPeriodBeginDTP.CustomFormat = "ddd, MMM dd, yyyy";
            initialEventEntryPeriodEndDTP.Format = DateTimePickerFormat.Custom;
            initialEventEntryPeriodEndDTP.CustomFormat = "ddd, MMM dd, yyyy";
            initialEventScheduledForDTP.Format = DateTimePickerFormat.Custom;
            initialEventScheduledForDTP.CustomFormat = "ddd, MMM dd, yyyy";
        }

        private void HideOrShowRepeatsPerCheckedStatus()
        {
            if (eventRepeatsChk.Checked)
            {
                m_pnlHideRepeats.Visible = false;
                m_pnlHideRepeats.SendToBack();
            }
            else
            {
                m_pnlHideRepeats.Visible = true;
                m_pnlHideRepeats.BringToFront();
            }
        }

        private void SetHeaderWidth(DataGridView DGV)
        {
            for (int i = 0; i != 3; i++)
            {
                DGV.Columns[i].Width = 300;
            }
        }

        #region POPULATE DATATABLE TO DATAGRIDVIEW STRUCTURE
        private void InitEntryScaleElements()
        {
            m_entrySpendScaleDT = new DataTable();
            m_entrySpendScaleDT.Columns.Add("From", typeof(decimal));
            m_entrySpendScaleDT.Columns.Add("To", typeof(decimal));
            m_entrySpendScaleDT.Columns.Add("Entries", typeof(int));
            entrySpendScaleDGV.DataSource = m_entrySpendScaleDT;

            m_entryVisitScaleDT = new DataTable();
            m_entryVisitScaleDT.Columns.Add("From", typeof(int));
            m_entryVisitScaleDT.Columns.Add("To", typeof(int));
            m_entryVisitScaleDT.Columns.Add("Entries", typeof(int));
            entryVisitScaleDGV.DataSource = m_entryVisitScaleDT;

            m_entryPurchaseScaleDT = new DataTable();
            m_entryPurchaseScaleDT.Columns.Add("From", typeof(int));
            m_entryPurchaseScaleDT.Columns.Add("To", typeof(int));
            m_entryPurchaseScaleDT.Columns.Add("Entries", typeof(int));
            entryPurchaseScaleDGV.DataSource = m_entryPurchaseScaleDT;

            foreach(var dgv in new DataGridView[] { entrySpendScaleDGV, entryVisitScaleDGV, entryPurchaseScaleDGV })
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
                //dgv.CellClick += entrySpendScaleDGV_CellClick;
              
                dgv.RowsRemoved += entryScaleDGV_RowsRemoved;
                dgv.RowsAdded += entryScaleDGV_RowsAdded;
                dgv.Leave += entryScaleDGV_Leave;
            }

        }

        #endregion

        #endregion

        #region EVENT

             #region ENTRY-spend

        private void entrySpendScaleDGV_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            DataGridView dgv = (DataGridView)sender;
            DataGridViewRow dgvr = dgv.Rows[e.RowIndex];

            if (Convert.ToInt32(dgv.Tag) == 2)
            {
                for (int i = 1; i < 4; i++)
                {
                    var currentValue = /*entrySpendScaleDGV*/dgv.Rows[e.RowIndex].Cells[i].Value.ToString();
                    if (currentValue == string.Empty || currentValue == null)
                    {                                 
                            dgv.Rows[e.RowIndex].Cells[i].Value = "0";
                            dgvr.Cells[i].Style.ForeColor = Color.LightGray;                      
                    }
                }
            }
            else
                if (Convert.ToInt32(dgv.Tag) == 1)
                {
                    for (int i = 1; i < 4; i++)
                    {
                        var currentValue = /*entrySpendScaleDGV*/dgv.Rows[e.RowIndex].Cells[i].Value.ToString();
                        if (currentValue == string.Empty || currentValue == null)
                        {
                            if (i != 3)
                            {
                                dgv.Rows[e.RowIndex].Cells[i].Value = "00.00";//If this is decimal how did you add this?
                                dgvr.Cells[i].Style.ForeColor = Color.LightGray;
                            }
                            else
                            {
                                dgv.Rows[e.RowIndex].Cells[i].Value = "0";
                                dgvr.Cells[i].Style.ForeColor = Color.LightGray;
                            }
                        }
                    }
                }
        }

       //This trigger when clicking a cell
        //CELLCLICK
       

        //This trigger on the first keystroke
        private void entrySpendScaleDGV_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            var dgv = (DataGridView)sender;//Current DataGridView
            var dgvr = dgv.Rows[e.RowIndex];
            dgvr.Cells[e.ColumnIndex].Style.ForeColor = SystemColors.WindowText;
            dgv.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = DBNull.Value;
            var dgvc = dgv.Columns[e.ColumnIndex];
            m_selectedColumnDataType = dgvc.ValueType;
            IsCellLastEntry(dgvr);
        }

        private void entrySpendScaleDGV_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            var dgv = (DataGridView)sender;//Current DataGridView
            var dgvr = dgv.Rows[e.RowIndex];
            var testee = dgv.Rows[e.RowIndex].Cells[e.ColumnIndex].Value;

            if (dgv.Rows[e.RowIndex].Cells[e.ColumnIndex].Value == DBNull.Value)
            {
                if (m_selectedColumnDataType == typeof(int))
                {
                    dgv.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = "0";
                    dgvr.Cells[e.ColumnIndex].Style.ForeColor = Color.LightGray;
                }
                else if (m_selectedColumnDataType == typeof(decimal))
                {
                    dgv.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = "00.00";
                    dgvr.Cells[e.ColumnIndex].Style.ForeColor = Color.LightGray;
                }
            }
            else
            {
                if (m_selectedColumnDataType == typeof(int))
                {
                    //dgv.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = "0";
                    dgvr.Cells[e.ColumnIndex].Style.ForeColor = SystemColors.WindowText; 
                }
                else if (m_selectedColumnDataType == typeof(decimal))
                {
                    //dgv.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = "00.00";
                    dgvr.Cells[e.ColumnIndex].Style.ForeColor = SystemColors.WindowText; ;
                }
            }
        }

        //This trigger every key stroke
        private void entrySpendScaleDGV_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {

            //e.Control.KeyUp -= new KeyEventHandler(ManageUserInput2);
            //e.Control.KeyUp += new KeyEventHandler(ManageUserInput2);

            e.Control.KeyDown -= new KeyEventHandler(ManageUserInput3);
            e.Control.KeyDown += new KeyEventHandler(ManageUserInput3);

            e.Control.KeyPress -= new KeyPressEventHandler(ManageUserInput);
            e.Control.KeyPress += new KeyPressEventHandler(ManageUserInput);

            //if (m_cellLastEntry)
            //{
            //    if (e.Control is TextBox)
            //    {
            //        m_cellActualValue = GetCellActualValue((TextBox)e.Control);
            //    }
            //}
        }

        private void ManageUserInput3(object sender, KeyEventArgs e)
        {
            var txtbxValue = (TextBox)sender;
            bool result = true;
            int keyValue = e.KeyValue;

            if (m_selectedColumnDataType == typeof(int))
            {
                if (e.KeyCode == Keys.Back)
                {
                    result = false;
                }
                if (result)
                {
                    result = !char.IsDigit(/*e.KeyChar*/(char)keyValue);
                }
            }
            else if (m_selectedColumnDataType == typeof(decimal))
            {
                if (sender is TextBox)
                {
                    txtbxValue = (TextBox)sender;
                    result = false;

                    string x = txtbxValue.Text;
                    if (txtbxValue.SelectionLength > 0)
                    {
                        int tlen = x.Length - txtbxValue.SelectionLength;
                        x = x.Substring(0, tlen);
                    }
         
                    int count = x.Split('.').Length - 1;

                    if (!char.IsControl((char)keyValue))
                    {
                        switch ((char)keyValue)
                        {
                            case (char)190://period
                                //allow 1 decimal point
                                if (count > 0)
                                {
                                    result = true;
                                }
                                else
                                {
                                    result = false;
                                }
                                break;
                                    default:
                                    result = !char.IsDigit((char)keyValue);
                                break;
                        }
                    }

                    if ((char)keyValue == (char)Keys.Back)
                    {
                        result = false;
                    }

                    else if (Regex.IsMatch(x, @"\.\d\d"))
                    {
                        result = true;
                    }
                }
            }

            m_invalidUserInput = result;
            
            if (!m_invalidUserInput)
            {
                m_cellActualValue = txtbxValue.Text + ((char)e.KeyValue).ToString();
            }

            e.Handled = result;
        }

        private void ManageUserInput2(object sender, KeyEventArgs e)
        {
        }

        private bool m_invalidUserInput = false;
        /// <summary>
        /// Allow user to input specific character per column data type
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ManageUserInput(object sender, KeyPressEventArgs e)
        {         
            e.Handled = m_invalidUserInput;

            if (m_cellLastEntry)
            {        
                CheckEntryScale(/*entrySpendScaleDGV*/m_selectedDataGridView);
            }      
        }

        private string GetCellActualValue(TextBox txtvalue)
        {
            string result = "";
            m_cellActualValue = txtvalue.Text;
            //CheckEntryScale(/*entrySpendScaleDGV*/m_selectedDataGridView);        
            return result;
        }
            #endregion

        private void EnterPlayerBasedOn_RdoClick(object sender, EventArgs e)
        {
            RadioButton rd_current = (RadioButton)sender;
            int test;
            bool result = Int32.TryParse(rd_current.Tag.ToString(), out test);

            if (rd_current.Checked == true)
            {
                if (test == 3)
                {
                    SetEntryMethodBothUI();
                    m_selectedDataGridView = entrySpendScaleDGV;
                    entryMethodsTC.SelectedIndex = test - 1;
                }
                else if (test != 3)
                {
                    HideEntryMethodBothUI();//SPEND
                    if (test == 1)
                    {
                        m_selectedDataGridView = entrySpendScaleDGV;
                        entryMethodsTC.SelectedIndex = 1;
                    }
                    if (test == 2)//VISIT
                    {
                        m_selectedDataGridView = entryVisitScaleDGV;
                        entryMethodsTC.SelectedIndex = 0;
                    }
                }
            }
        }
            #region unspecify yet

        private void showInactiveDrawingsChk_CheckedChanged(object sender, EventArgs e) { ListDrawings(); }

        private void drawingNameTxt_TextChanged(object sender, EventArgs e)
        {
            String errMsg = null;
            int drawingNameLenLimit = 48;
            int drawingNameLen = drawingNameTxt.Text.Length;
            if (drawingNameLen > drawingNameLenLimit)
                errMsg = String.Format("Drawing name may be no longer than {0} characters, currently {1}.", drawingNameLenLimit, drawingNameLen);
            else
            {
                var namingConflict = m_drawings.FirstOrDefault((d) => d.Name.ToLower() == drawingNameTxt.Text.ToLower() && (m_currentGPD.Id == null || m_currentGPD.Id != d.Id));
                if (namingConflict != null)
                    errMsg = String.Format("Drawings must have unique names{0}", namingConflict.Active ? "." : ", even considering drawings that are no longer active.");
            }
            SetError(drawingNameTxt, errMsg);
        }

        private void entrySessionNumbersCL_ItemCheck(object sender, ItemCheckEventArgs e)
        {

            if (entrySessionNumbersCL.SelectedIndex != -1)
            {
                CheckedListBox chkListBoxCurrent = (CheckedListBox)sender;
                var numberOfCheckedItem = chkListBoxCurrent.CheckedItems.Cast<SessionNumberListing>().Where(l => l.SessionNumber != 0).Count();
                numberOfCheckedItem = (e.NewValue == CheckState.Checked) ? numberOfCheckedItem += 1 : numberOfCheckedItem -= 1;
                var tnumOfCurrentSession = chkListBoxCurrent.Items.Cast<SessionNumberListing>().Where(l => l.SessionNumber != 0).Count();

                if (entrySessionNumbersCL.SelectedIndex == 0)
                {
                    if (e.NewValue == CheckState.Checked)
                    {
                        SetAllItemCheck(true);
                    }
                    else
                    {
                        SetAllItemCheck(false);
                    }
                }

                else
                {
                    if (numberOfCheckedItem == tnumOfCurrentSession)
                    {
                        entrySessionNumbersCL.ItemCheck -= new ItemCheckEventHandler(entrySessionNumbersCL_ItemCheck);
                        entrySessionNumbersCL.SetItemChecked(0, true);
                        entrySessionNumbersCL.ItemCheck += new ItemCheckEventHandler(entrySessionNumbersCL_ItemCheck);
                    }
                    else
                    {
                        if (entrySessionNumbersCL.GetItemChecked(0) == true)
                        {
                            entrySessionNumbersCL.ItemCheck -= new ItemCheckEventHandler(entrySessionNumbersCL_ItemCheck);
                            entrySessionNumbersCL.SetItemChecked(0, false);
                            entrySessionNumbersCL.ItemCheck += new ItemCheckEventHandler(entrySessionNumbersCL_ItemCheck);
                        }
                    }
                }
            }
        }

        private void testEventsBtn_Click(object sender, EventArgs e)
        {
            var f = new GeneralPlayerDrawingEventsTestForm(m_drawings);
            f.ShowDialog(this);
            f.Dispose();
        }

        private void editDrawingBtn_Click(object sender, EventArgs e) { ToggleEditMode(true); }

        private void copyDrawingBtn_Click(object sender, EventArgs e)
        {
            var gpd = new GeneralPlayerDrawing(m_currentGPD, true);
            gpd.Name = String.Format("Copy of {0}", gpd.Name);
            SetCurrentDrawing(gpd);
            ToggleEditMode(true);
        }

        private void newDrawingBtn_Click(object sender, EventArgs e)
        {
            SetCurrentDrawing(new GeneralPlayerDrawing());
            ToggleEditMode(true);
        }

        private void cancelDrawingChangesBtn_Click(object sender, EventArgs e)
        {
            drawingsLV_SelectedIndexChanged(null, null);
            ToggleEditMode(false);
        }

        private void revertDrawingChangesBtn_Click(object sender, EventArgs e) { LoadCurrentDrawingDetails(); }

        private void saveDrawingChangesBtn_Click(object sender, EventArgs e)
        {
            var candidate = GeneratePendingDrawing();

            if (candidate.Id == null && !candidate.Active)
            {
                var dr = MessageForm.Show(this
                    , "You are about to save a new drawing without it first being active." + Environment.NewLine
                        + "Would you like to saved as Active?"
                    , "New Drawing not Active"
                    , MessageFormTypes.YesNoCancel
                    );

                switch (dr)
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

            var saveResult = GTI.Modules.Shared.Data.SetGeneralDrawingMessage.SetDrawing(candidate);

            if (saveResult != null)
            {
                if (candidate.Id == null)
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

            }
            else
            {
                //Save failed
                MessageBox.Show("Save Failed", "Save Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void closeBtn_Click(object sender, EventArgs e) { this.Close(); }

        private void GeneralPlayerDrawingForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (m_editMode)
            {
                var r = MessageForm.Show(this, "Current changes will be lost if not saved before closing this form. Close anyway?"
                                        , "Confirm Close"
                                        , MessageFormTypes.YesNo
                                        );
                if (r != System.Windows.Forms.DialogResult.Yes)
                    e.Cancel = true;
            }
        }

        private void requiredUIntTxt_TextChanged(object sender, EventArgs e)
        {
            var tb = sender as TextBox;
            uint parseUInt;
            if (!uint.TryParse(tb.Text, out parseUInt) || parseUInt == 0)
                SetError(tb, "Must be whole number greater than 0.");
            else
                SetError(tb, null);
        }

        private void requiredIntTxt_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar))
                e.Handled = true;
        }

        private void addEntrySpendTierBtn_Click(object sender, EventArgs e)
        {
            m_entrySpendScaleDT.Rows.Add();
            entrySpendScaleDGV.Focus();
        }

        private void addEntryVisitTierBtn_Click(object sender, EventArgs e)
        {
            m_cellLastEntry = false;
            m_cellActualValue = "";
            m_entryVisitScaleDT.Rows.Add();
            entryVisitScaleDGV.Focus();
        }

        private void addEntryPurchaseTierBtn_Click(object sender, EventArgs e)
        {
            m_cellLastEntry = false;
            m_cellActualValue = "";
            m_entryPurchaseScaleDT.Rows.Add();
            entryPurchaseScaleDGV.Focus();
        }

        private void entryPurchaseSelectionsCL_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            var item = entryPurchaseSelectionsCL.Items[e.Index] as PurchaseItemListing;
            var checking = e.NewValue == CheckState.Checked;
            if (checking)
            {
                if (PendingEntryPurchaseType == GeneralPlayerDrawing.PurchaseType.PACKAGE)
                    m_pendingPackageSelections.Add(item.Id);
                if (PendingEntryPurchaseType == GeneralPlayerDrawing.PurchaseType.PRODUCT)
                    m_pendingProductSelections.Add(item.Id);
            }
            else
            {
                if (PendingEntryPurchaseType == GeneralPlayerDrawing.PurchaseType.PACKAGE)
                    m_pendingPackageSelections.Remove(item.Id);
                if (PendingEntryPurchaseType == GeneralPlayerDrawing.PurchaseType.PRODUCT)
                    m_pendingProductSelections.Remove(item.Id);
            }

        }

        private void initialEventEntryPeriodBeginDTP_ValueChanged(object sender, EventArgs e)
        {
            if (m_loadingDetails)
                return;

            CheckEventDates();
            UpdateEventExamples();
        }

        private void initialEventEntryPeriodEndDTP_ValueChanged(object sender, EventArgs e)
        {
            if (m_loadingDetails)
                return;

            CheckEventDates();
            eventRepetitionEndsDTP_ValueChanged(null, null);
            UpdateEventExamples();
        }

        private void initialEventScheduledForDTP_ValueChanged(object sender, EventArgs e)
        {
            if (m_loadingDetails)
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
            if (eventRepeatsChk.Checked && String.IsNullOrWhiteSpace((String)eventRepeatIntervalCB.SelectedItem))
                err = "Interval must be selected for repeating drawings.";
            SetError(eventRepeatIntervalCB, err);

            if (sender != null)
                UpdateEventExamples();
        }

        private void eventRepetitionEndsDTP_ValueChanged(object sender, EventArgs e)
        {
            String err = null;
            if (eventRepeatsChk.Checked && eventRepetitionEndsDTP.Checked && eventRepetitionEndsDTP.Value.Date < initialEventEntryPeriodEndDTP.Value.Date)
                err = "When provided, repeat 'until' date must be later than initial entry window.";
            SetError(eventRepetitionEndsDTP, err);

            if (sender != null)
                UpdateEventExamples();
        }

        private void entrySpendGroupingRB_CheckedChanged(object sender, EventArgs e)
        {
            var rb = sender as RadioButton;
            if (rb.Checked)
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
            if (rb.Checked)
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
            if (rb.Checked)
            {

                var entryMethodUsed = !Object.ReferenceEquals(rb, entryPurchaseTypeNoneRB);

                entryPurchaseScaleDGV.Visible = entryMethodUsed;
                addEntryPurchaseTierBtn.Visible = entryMethodUsed;
                entryPurchaseSelectionsCL.Visible = entryMethodUsed;
                CheckEntryScale(entryPurchaseScaleDGV);

                if (Object.ReferenceEquals(rb, entryPurchaseTypePackageRB))
                {
                    entryPurchaseSelectionsCL.Items.Clear();
                    foreach (var p in m_packagesAvailable)
                        if (p.IsActive || m_pendingPackageSelections.Contains(p.Id))
                            entryPurchaseSelectionsCL.Items.Add(p, m_pendingPackageSelections.Contains(p.Id));
                }
                if (Object.ReferenceEquals(rb, entryPurchaseTypeProductRB))
                {
                    entryPurchaseSelectionsCL.Items.Clear();
                    foreach (var p in m_productsAvailable)
                        if (p.IsActive || m_pendingProductSelections.Contains(p.Id))
                            entryPurchaseSelectionsCL.Items.Add(p, m_pendingProductSelections.Contains(p.Id));
                }
            }
            CheckEntryMethods();
        }

        private void entryLimitTxt_TextChanged(object sender, EventArgs e)
        {
            var tb = sender as TextBox;
            int parseTarget = 0;

            if (String.IsNullOrWhiteSpace(tb.Text))
                SetError(tb, null);
            else if (!int.TryParse(tb.Text, out parseTarget))
                SetError(tb, "Limit must be numeric");
            else if (parseTarget <= 0)
                SetError(tb, "Limit must be greater than 0.");
            else
                SetError(tb, null);
        }

        private void entryLimitTxt_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsNumber(e.KeyChar) && !char.IsControl(e.KeyChar))
                e.Handled = true;
        }

        private void eventRepeatIncrementTxt_TextChanged(object sender, EventArgs e)
        {
            var tb = sender as TextBox;
            int parseTarget = 0;

            string errMsg = null;

            if (eventRepeatsChk.Checked)
            {
                if (String.IsNullOrWhiteSpace(tb.Text) || !int.TryParse(tb.Text, out parseTarget) || parseTarget < 0)
                    errMsg = "Event repeat increment must be a non-negative whole number.";
                else if (parseTarget > Int16.MaxValue)
                    errMsg = "Event repeat increment too large.";
            }

            SetError(tb, errMsg);

            if (sender != null)
                UpdateEventExamples();
        }

        private void entryPeriodRepeatIncrementTxt_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsNumber(e.KeyChar) && !char.IsControl(e.KeyChar))
                e.Handled = true;

            if (sender != null)
                UpdateEventExamples();
        }

        private void drawingsLV_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (drawingsLV.SelectedItems.Count == 1)
                SetCurrentDrawing(drawingsLV.SelectedItems[0].Tag as GeneralPlayerDrawing);
            else
                SetCurrentDrawing(null);
        }

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

            if (col is DataGridViewButtonColumn && col.Name == "removeDGVBC" && e.RowIndex < dgv.Rows.Count)
                dgv.Rows.RemoveAt(e.RowIndex);
        }

        void entryScaleDGV_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {     
            if(m_loadingDetails)
                return;
        }
      
        void entryScaleDGV_RowsRemoved(object sender, DataGridViewRowsRemovedEventArgs e)
        {
            if(m_loadingDetails)
                return;
                CheckEntryScale(sender as DataGridView);                   
        }

        void entryScaleDGV_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)//knc
        {
            if(m_loadingDetails)
                return;          
            CheckEntryScale(sender as DataGridView);
        }

            #endregion

        #endregion

        #region PROPERTIES (pending)
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
        public String PendingEventRepeatInterval { get { return eventRepeatsChk.Checked ? (String)eventRepeatIntervalCB.SelectedItem : ""; } }
        public DateTime? PendingEventRepeatUntil { get { return (eventRepetitionEndsDTP.Checked ? (DateTime?)eventRepetitionEndsDTP.Value.Date : null); } }
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

        public int? PendingPlayerEntryMaximum { get { return UILimitToNInt(entryLimitEventTxt.Text); } }

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

        public List<int> PendingEntryPurchasePackages { get { return m_pendingPackageSelections; } }

        public List<int> PendingEntryPurchaseProducts { get { return m_pendingProductSelections; } }

        #endregion



    }
}
