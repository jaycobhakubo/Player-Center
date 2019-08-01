using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using GTI.Modules.Shared;
using GTI.Modules.PlayerCenter.Data;
using System.Timers;
using GTI.Modules.PlayerCenter.Business;
using System.Management;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using GameTech.Elite.Base;
using GameTech.Elite.Client;
using GetPlayerDataMessage = GTI.Modules.Shared.GetPlayerDataMessage;
using LoggerLevel = GTI.Modules.Shared.LoggerLevel;
using Operator = GTI.Modules.Shared.Operator;


//04.19.2019-jkim: US5766: Caller - Allow the user to run Player Center style raffles on the Caller


namespace GTI.Modules.PlayerCenter.UI
{

    public partial class Raffle : GradientForm
    {
        #region Private Members

        #region Monetary Raffle Members
        private BackgroundWorker m_monRaffleLoader;
        private List<MonetaryRaffle> m_monRaffles;
        private MonetaryRaffle m_editingMonRaffle = null;
        private bool _editingMonRaffle = false;
        #endregion

        #region Wheel Raffle Members
        private BackgroundWorker m_wheelRaffleLoader;
        private List<WheelRaffle> m_wheelRaffles;
        private WheelRaffle m_editingWheelRaffle = null;
        private bool _editingWheelRaffle = false;
        #endregion

        private bool isNew = false;
        private bool isModify = false;
        private bool isUpdate = false;
        private bool isDisclaimerEnable = false;
        private bool isNew2 = false;
        private bool isUpdate2 = false;
        private bool isDelete = false;
        private bool isCancel = false;
        private bool isSave = false;
        private bool isClose = false;
        private int DefID;
        private string RaffleName = "";
        private string displayedText = "";
        private string PrinterName = "";
        private bool N_OfPlayersReqMet;
        int[] RaffleSettingID = new int[] { 214 };//, 22, 182, 38, 37, 3, 189, 190 };//, 77 };
        Vouchers vouchers = new Vouchers();
        Printer globalPrinter;
        RafflePrize dataRafflePrize = new RafflePrize();
        Dictionary<int, int> IndexToDefID = new Dictionary<int, int>();
        private Operator ActiveOperatorsData;
        private RaffleEntryInformation m_raffleEntryInfo;

        //System Setting reference
        //==========================
        //214 = delaytimer; [0]
        //22 = swipeorentry; [1]
        //182 raffle or drawing; [2] (1 for raffle 2 for drawing)
        //38 remove previous winner  on the next raffle; [3]
        //37 = minimum player participant [4]
        //3 = Printer Name [5]
        //189 OperatorName[6]
        //190 Sponsored by: *****[7]
        //271 RunFromLocation 1 = Caller; 2 = Player Center 

        //77 Global printer 
        //==================================

        #endregion

        public Raffle()
        {
            InitializeComponent();

            var prizes = GetPlayerRafflePrizesMessage.GetRafflePrizes();
            loadListRaffle(prizes);
            loadcmbxRafle(prizes);

            RaffleSettings.data.Clear();
            foreach (int globalsettingID in RaffleSettingID)
            {
                GetRaffleDelaySettings.RunGetRaffleDelaySetting(globalsettingID, GetOperatorID.operatorID);
            }
            AppliedSystemSettingDisplayedText();

            if (btnSetupSave.Enabled != false) { btnSetupSave.Enabled = false; }
            if (btnSetupCancel.Enabled != false) { btnSetupCancel.Enabled = false; }

            tbctrlRafle.SelectedIndexChanged += new EventHandler(tbctrlRafle_SelectedIndexChanged);
            GetAndLoadPlayerListComboBox();

            SetupMonetaryRaffle();
            SetupWheelRaffle();
        }

        #region METHODS

        // US5414
        #region Monetary Raffle Methods

        /// <summary>
        /// Sets whether or not UI elements are enabled on the monetary raffle UI
        /// </summary>
        private void SetEnableMonetaryRaffleFields()
        {
            monRaffleGroupBox2.Enabled = m_editingMonRaffle != null;

            if (monRaffleGroupBox2.Enabled) // the group box may be enabled, but the fields shouldn't be until the user clicks the edit button
            {
                monRafNameTxtBx.Enabled = monRafDescTxtBx.Enabled = monRafPrizeWeightTxtBx.Enabled = monRafPrizeValTxtBx.Enabled =
                    addMonRafPrizeBtn.Enabled = monRafPrizeListBx.Enabled = removeMonRafPrizeBtn.Enabled = _editingMonRaffle;
            }

            monRafSaveBtn.Enabled = (_editingMonRaffle && m_editingMonRaffle != null && !String.IsNullOrWhiteSpace(monRafNameTxtBx.Text));

            btnRunMonetary.Enabled = (m_editingMonRaffle != null && m_editingMonRaffle.ID.HasValue);

            addMonRafPrizeBtn.Enabled = (!String.IsNullOrWhiteSpace(monRafPrizeWeightTxtBx.Text) && !String.IsNullOrWhiteSpace(monRafPrizeValTxtBx.Text));

            removeMonRafPrizeBtn.Enabled = (monRafPrizeListBx.SelectedIndex != -1);

            deleteMonRafBtn.Enabled = (monRaffleListBox.SelectedIndex != -1);

            editMonRafBtn.Enabled = (monRaffleListBox.SelectedIndex != -1);
        }

        /// <summary>
        /// Clears out the monetary raffle fields
        /// </summary>
        private void ClearMonRaffleFields()
        {
            //monRafStatusLabel.Text = "";
            monRafNameTxtBx.Text = "";
            monRafDescTxtBx.Text = "";
            monRafPrizeWeightTxtBx.Text = "";
            monRafPrizeValTxtBx.Text = "";
            monRafPrizeListBx.Items.Clear();
            monRafSaveLbl.Visible = false;
        }

        /// <summary>
        /// Sets the monetary raffle fields to the values in the raffle being edited
        /// </summary>
        private void SetMonRaffleFields()
        {
            if (m_editingMonRaffle == null)
            {
                ClearMonRaffleFields();
            }
            else
            {
                //monRafStatusLabel.Text = "";
                monRafNameTxtBx.Text = m_editingMonRaffle.Name;
                monRafDescTxtBx.Text = m_editingMonRaffle.Description;
                monRafPrizeWeightTxtBx.Text = "";
                monRafPrizeValTxtBx.Text = "";
                monRafPrizeListBx.Items.Clear();
                if (m_editingMonRaffle.Options != null && m_editingMonRaffle.Options.Count > 0)
                {
                    foreach (var opt in m_editingMonRaffle.Options)
                    {
                        monRafPrizeListBx.Items.Add(opt);
                    }
                }
            }

            SetEnableMonetaryRaffleFields();
        }

        /// <summary>
        /// Initializes the monetary raffle data
        /// </summary>
        private void SetupMonetaryRaffle()
        {
            m_monRaffleLoader = new BackgroundWorker();
            m_monRaffleLoader.DoWork += new DoWorkEventHandler(MonRaffleLoader_DoWork);
            m_monRaffleLoader.RunWorkerCompleted += new RunWorkerCompletedEventHandler(MonRaffleLoader_RunWorkerCompleted);
            LoadMonetaryRaffle();
        }

        /// <summary>
        /// Loads the list of monetary raffles from the server
        /// </summary>
        private void LoadMonetaryRaffle()
        {
            ClearMonRaffleFields();
            //monRafStatusLabel.Text = "Loading...";
            monRaffleGroupBox1.Enabled = false;
            monRaffleGroupBox2.Enabled = false;
            if(!m_monRaffleLoader.IsBusy)
                m_monRaffleLoader.RunWorkerAsync();
        }

        /// <summary>
        /// Loads the monetary raffles
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MonRaffleLoader_DoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                m_monRaffles = GetMonetaryRaffleDefinitions.GetMonetaryRaffles();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Actions that occur when the monetary raffles are done loading
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MonRaffleLoader_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            monRaffleGroupBox1.Enabled = true;
            if (e.Error == null)
            {
                //monRafStatusLabel.Text = "";
                monRaffleListBox.Items.Clear();
                if (m_monRaffles != null && m_monRaffles.Count > 0)
                {
                    monRaffleListBox.SuspendLayout();
                    foreach (var monRaf in m_monRaffles)
                    {
                        monRaffleListBox.Items.Add(monRaf);
                    }
                    monRaffleListBox.ResumeLayout();
                }
                else
                {
                   // monRafStatusLabel.Text = "No Monetary Raffles Found";
                }
            }
            else
            {
                if (e.Error is ServerException)
                {
                    ServerException ex = e.Error as ServerException;
                    PlayerManager.Log("Error getting monetary raffles: " + e.Error.ToString(), LoggerLevel.Severe);
                    MessageForm.Show(String.Format("Unable to get monetary raffles. Reason: {0} ",
                        GameTech.Elite.Client.ServerErrorTranslator.GetReturnCodeMessage((GameTech.Elite.Client.ServerReturnCode)ex.ReturnCode)));
                }
                else
                {
                    PlayerManager.Log("Error getting monetary raffles: " + e.Error.ToString(), LoggerLevel.Severe);
                    MessageForm.Show("Unable to get monetary raffles. Reason: " + e.Error.Message);
                }
            }
            SetEnableMonetaryRaffleFields();
        }

        /// <summary>
        /// Actions that occur when a new prize is selected on the monetary raffle
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void monRafPrizeListBx_SelectedIndexChanged(object sender, EventArgs e)
        {
            SetEnableMonetaryRaffleFields();
        }

        /// <summary>
        /// Actions that occur when the user presses the button to create a new monetary raffle
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void newMonRafBtn_Click(object sender, EventArgs e)
        {
            _editingMonRaffle = true;
            monRaffleListBox.SelectedIndex = -1;
            ClearMonRaffleFields();
            m_editingMonRaffle = new MonetaryRaffle();
            SetEnableMonetaryRaffleFields();
        }

        /// <summary>
        /// Actions that occus when a new item is selected on the monetary raffle list box
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void monRaffleListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (monRaffleListBox.SelectedIndex != -1)
            {
                m_editingMonRaffle = (MonetaryRaffle)monRaffleListBox.SelectedItem;
            }
            else
            {
                m_editingMonRaffle = null;
            }
            _editingMonRaffle = false;
            SetMonRaffleFields();
        }

        /// <summary>
        /// Actions that occur when a user presses the close button on the monetary raffle form
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void closeBtn3_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        /// <summary>
        /// Actions that occur when the user presses the cancel button
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void monRafCancelBtn_Click(object sender, EventArgs e)
        {
            m_editingMonRaffle = null;
            LoadMonetaryRaffle();
        }

        /// <summary>
        /// Actions that occur when the user presses the save button
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void monRafSaveBtn_Click(object sender, EventArgs e)
        {
            if (m_editingMonRaffle != null)
            {
                m_editingMonRaffle.Name = monRafNameTxtBx.Text;
                m_editingMonRaffle.Description = monRafDescTxtBx.Text;
                m_editingMonRaffle.Options.Clear();
                foreach (var option in monRafPrizeListBx.Items)
                {
                    if (option is MonetaryRafflePrizes) // sanity check. Should never get bad ones
                        m_editingMonRaffle.Options.Add((MonetaryRafflePrizes)option);
                }

                try
                {
                    SetMonetaryRaffleDefinition.SetMonetaryRaffle(m_editingMonRaffle);

                    m_editingMonRaffle = null;
                    LoadMonetaryRaffle();
                    monRafSaveLbl.Visible = true;
                }
                catch (ServerException ex)
                {
                    string err = String.Format("Unable to save monetary raffle. Reason: {0}",
                        GameTech.Elite.Client.ServerErrorTranslator.GetReturnCodeMessage((GameTech.Elite.Client.ServerReturnCode)ex.ReturnCode));
                    MessageForm.Show(err);
                    PlayerManager.Log(err, LoggerLevel.Severe);
                }
                catch (Exception ex)
                {
                    MessageForm.Show(String.Format("Unable to save monetary raffle. Reason: {0}", ex.Message));
                    PlayerManager.Log(String.Format("Unable to save monetary raffle. Reason: {0}", ex.ToString()), LoggerLevel.Severe);
                }
            }
            SetEnableMonetaryRaffleFields();
        }

        /// <summary>
        /// Actions that occur when the user presses the button to run the selected raffle
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnRunMonetary_Click(object sender, EventArgs e)
        {
            if (m_editingMonRaffle != null && m_editingMonRaffle.ID.HasValue)
            {
                decimal wonVal = 0.00m;
                try
                {
                    wonVal = RunMonetaryRaffle.RunRaffle(m_editingMonRaffle.ID.Value);

                    MessageForm.Show(String.Format("Raffle paid out: {0:C}", wonVal));
                }
                catch (ServerException ex)
                {
                    string err = String.Format("Unable to run monetary raffle. Reason: {0}",
                        GameTech.Elite.Client.ServerErrorTranslator.GetReturnCodeMessage((GameTech.Elite.Client.ServerReturnCode)ex.ReturnCode));
                    MessageForm.Show(err);
                    PlayerManager.Log(err, LoggerLevel.Severe);
                }
                catch (Exception ex)
                {
                    MessageForm.Show(String.Format("Unable to run monetary raffle. Reason: {0}", ex.Message));
                    PlayerManager.Log(String.Format("Unable to run monetary raffle. Reason: {0}", ex.ToString()), LoggerLevel.Severe);
                }
            }
        }

        private void addMonRafPrizeBtn_Click(object sender, EventArgs e)
        {
            int weight;
            decimal val;
            if (Int32.TryParse(monRafPrizeWeightTxtBx.Text, out weight) && weight > 0 && Decimal.TryParse(monRafPrizeValTxtBx.Text, out val))
            {
                MonetaryRafflePrizes prize = new MonetaryRafflePrizes();
                prize.Weight = weight;
                prize.Value = val;
                monRafPrizeListBx.Items.Add(prize);
                monRafPrizeWeightTxtBx.Text = "1";
                monRafPrizeValTxtBx.Text = "";
                monRafPrizeWeightTxtBx.Focus();
            }
            SetEnableMonetaryRaffleFields();
        }

        private void removeMonRafPrizeBtn_Click(object sender, EventArgs e)
        {
            if (monRafPrizeListBx.SelectedIndex != -1)
            {
                monRafPrizeListBx.Items.RemoveAt(monRafPrizeListBx.SelectedIndex);
            }
            SetEnableMonetaryRaffleFields();
        }

        /// <summary>
        /// Actions that occur when the "delete" button is pressed on the monetary raffle tab
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void deleteMonRafBtn_Click(object sender, EventArgs e)
        {
            if (m_editingMonRaffle != null)
            {
                try
                {
                    SetMonetaryRaffleDefinition.SetMonetaryRaffle(m_editingMonRaffle, true);
                    LoadMonetaryRaffle();
                    monRafSaveLbl.Visible = true;
                }
                catch (ServerException ex)
                {
                    string err = String.Format("Unable to delete monetary raffle. Reason: {0}",
                        GameTech.Elite.Client.ServerErrorTranslator.GetReturnCodeMessage((GameTech.Elite.Client.ServerReturnCode)ex.ReturnCode));
                    MessageForm.Show(err);
                    PlayerManager.Log(err, LoggerLevel.Severe);
                }
                catch (Exception ex)
                {
                    MessageForm.Show(String.Format("Unable to delete monetary raffle. Reason: {0}", ex.Message));
                    PlayerManager.Log(String.Format("Unable to delete monetary raffle. Reason: {0}", ex.ToString()), LoggerLevel.Severe);
                }
            }
            SetEnableMonetaryRaffleFields();
        }

        /// <summary>
        /// Actions that occur when the "edit" button is pressed on the monetary raffle tab
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void editMonRafBtn_Click(object sender, EventArgs e)
        {
            if (monRaffleListBox.SelectedIndex != -1)
            {
                _editingMonRaffle = true;
                SetEnableMonetaryRaffleFields();
            }

        }

        /// <summary>
        /// Actions that occur when a text field in the monetary raffle is updated
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void monRafTxtBx_TextChanged(object sender, EventArgs e)
        {
            SetEnableMonetaryRaffleFields();
        }

        private void monRafPrizeValTxtBx_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                addMonRafPrizeBtn_Click(this, new EventArgs());
        }
        #endregion Monetary Raffle Methods

        // US5427
        #region Wheel Raffle Methods

        /// <summary>
        /// Sets whether or not UI elements are enabled on the monetary raffle UI
        /// </summary>
        private void SetEnableWheelRaffleFields()
        {
            wheelRaffleGroupBox2.Enabled = (m_editingWheelRaffle != null);

            if (wheelRaffleGroupBox2.Enabled) // the group box may be enabled, but the fields shouldn't be until the user clicks the edit button
            {
                wheelRafNameTxtBx.Enabled = wheelRafDescTxtBx.Enabled = wheelRafPrizeWeightTxtBx.Enabled = wheelRafPrizeValTxtBx.Enabled =
                    addWheelRafPrizeBtn.Enabled = wheelRafPrizeListBx.Enabled = removeWheelRafPrizeBtn.Enabled = btnBrowseWheel.Enabled =
                    txtWheelImageLoc.Enabled = btnBrowseOverlay.Enabled = txtOverlayImageLoc.Enabled = _editingWheelRaffle;
            }

            wheelRafSaveBtn.Enabled = (_editingWheelRaffle && m_editingWheelRaffle != null && !String.IsNullOrWhiteSpace(wheelRafNameTxtBx.Text));

            btnRunWheel.Visible = (m_editingWheelRaffle != null && m_editingWheelRaffle.ID.HasValue);

            wheelRafInstructionLabel.Visible = !btnRunWheel.Visible;

            addWheelRafPrizeBtn.Enabled = (!String.IsNullOrWhiteSpace(wheelRafPrizeWeightTxtBx.Text) && !String.IsNullOrWhiteSpace(wheelRafPrizeValTxtBx.Text));

            removeWheelRafPrizeBtn.Enabled = (wheelRafPrizeListBx.SelectedIndex != -1);

            deleteWheelRafBtn.Enabled = (wheelRaffleListBox.SelectedIndex != -1);

            editWheelRafBtn.Enabled = (wheelRaffleListBox.SelectedIndex != -1);
        }

        /// <summary>
        /// Clears out the wheel raffle fields
        /// </summary>
        private void ClearWheelRaffleFields()
        {
            //wheelRafStatusLabel.Text = "";
            wheelRafNameTxtBx.Text = "";
            wheelRafDescTxtBx.Text = "";
            txtWheelImageLoc.Text = "";
            txtOverlayImageLoc.Text = "";
            Image temp = wheelImageBox.Image;
            wheelImageBox.Image = null;
            if (temp != null)
                temp.Dispose();
            wheelRafPrizeWeightTxtBx.Text = "";
            wheelRafPrizeValTxtBx.Text = "";
            wheelRafPrizeListBx.Items.Clear();
            wheelRafSaveLbl.Visible = false;
        }

        /// <summary>
        /// Sets the wheel raffle fields to the values in the raffle being edited
        /// </summary>
        private void SetWheelRaffleFields()
        {
            if (m_editingWheelRaffle == null)
            {
                ClearWheelRaffleFields();
            }
            else
            {
                //wheelRafStatusLabel.Text = "";
                wheelRafNameTxtBx.Text = m_editingWheelRaffle.Name;
                wheelRafDescTxtBx.Text = m_editingWheelRaffle.Description;
                wheelRafPrizeWeightTxtBx.Text = "";
                wheelRafPrizeValTxtBx.Text = "";
                txtWheelImageLoc.Text = "";
                txtOverlayImageLoc.Text = "";
                wheelRafSaveLbl.Visible = false;
                SetWheelRaffleImage();
                wheelRafPrizeListBx.Items.Clear();
                if (m_editingWheelRaffle.Options != null && m_editingWheelRaffle.Options.Count > 0)
                {
                    foreach (var opt in m_editingWheelRaffle.Options)
                    {
                        wheelRafPrizeListBx.Items.Add(opt);
                    }
                }
            }

            SetEnableWheelRaffleFields();
        }

        /// <summary>
        /// Sets the UI to an overlayed combination of the wheel and the overlay
        /// </summary>
        private void SetWheelRaffleImage()
        {
            wheelImageBox.Image = new Bitmap(wheelImageBox.Width, wheelImageBox.Height); // have to layer things ourselves
            Graphics overlay = Graphics.FromImage(wheelImageBox.Image);
            if (m_editingWheelRaffle.WheelImage != null)
                overlay.DrawImage(m_editingWheelRaffle.WheelImage, new Rectangle(0, 0, wheelImageBox.Width, wheelImageBox.Height));
            if (m_editingWheelRaffle.OverlayImage != null)
                overlay.DrawImage(m_editingWheelRaffle.OverlayImage, new Rectangle(0, 0, wheelImageBox.Width, wheelImageBox.Height));
        }

        /// <summary>
        /// Initializes the wheel raffle data
        /// </summary>
        private void SetupWheelRaffle()
        {
            m_wheelRaffleLoader = new BackgroundWorker();
            m_wheelRaffleLoader.DoWork += new DoWorkEventHandler(WheelRaffleLoader_DoWork);
            m_wheelRaffleLoader.RunWorkerCompleted += new RunWorkerCompletedEventHandler(WheelRaffleLoader_RunWorkerCompleted);
            LoadWheelRaffle();
        }

        /// <summary>
        /// Loads the list of wheel raffles from the server
        /// </summary>
        private void LoadWheelRaffle()
        {
            ClearWheelRaffleFields();
            //wheelRafStatusLabel.Text = "Loading...";
            wheelRaffleGroupBox1.Enabled = false;
            wheelRaffleGroupBox2.Enabled = false;
            if(!m_wheelRaffleLoader.IsBusy)
                m_wheelRaffleLoader.RunWorkerAsync();
        }

        /// <summary>
        /// Loads the wheel raffles
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void WheelRaffleLoader_DoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                m_wheelRaffles = GetPrizeWheelRaffleDefinitions.GetPrizeWheelRaffles();

                Dictionary<int, Bitmap> images = new Dictionary<int, Bitmap>(); // photo IDs => image; This is for use if we re-use images. Note: Not possible with current architecture, but it makes more sense than saving the same image a ton of times
                bool anyImageFailed = false;
                foreach (var raf in m_wheelRaffles) // load the images in
                {
                    if (raf.WheelPhotoId.HasValue && raf.WheelPhotoId.Value != 0)
                    {
                        if (images.ContainsKey(raf.WheelPhotoId.Value))
                        {
                            raf.WheelImage = images[raf.WheelPhotoId.Value];
                        }
                        else
                        {
                            try
                            {
                                Bitmap image = GetPhotoMessage.GetPhoto(raf.WheelPhotoId.Value);
                                images.Add(raf.WheelPhotoId.Value, image);
                                raf.WheelImage = image;
                            }
                            catch
                            {
                                anyImageFailed = true;
                            }
                        }
                    }
                    if (raf.OverlayPhotoId.HasValue && raf.OverlayPhotoId.Value != 0)
                    {
                        if (images.ContainsKey(raf.OverlayPhotoId.Value))
                        {
                            raf.WheelImage = images[raf.OverlayPhotoId.Value];
                        }
                        else
                        {
                            try
                            {
                                Bitmap image = GetPhotoMessage.GetPhoto(raf.OverlayPhotoId.Value);
                                images.Add(raf.OverlayPhotoId.Value, image);
                                raf.OverlayImage = image;
                            }
                            catch
                            {
                                anyImageFailed = true;
                            }
                        }
                    }
                }

                //if (anyImageFailed)
                //    wheelRafStatusLabel.Text = "Some raffle wheel images have failed to load";
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Actions that occur when the wheel raffles are done loading
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void WheelRaffleLoader_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            wheelRaffleGroupBox1.Enabled = true;
            if (e.Error == null)
            {
                //wheelRafStatusLabel.Text = "";
                wheelRaffleListBox.Items.Clear();
                if (m_wheelRaffles != null && m_wheelRaffles.Count > 0)
                {
                    wheelRaffleListBox.SuspendLayout();
                    foreach (var wheelRaf in m_wheelRaffles)
                    {
                        wheelRaffleListBox.Items.Add(wheelRaf);
                    }
                    wheelRaffleListBox.ResumeLayout();
                }
                else
                {
                    //wheelRafStatusLabel.Text = "No Wheel Raffles Found";
                }
            }
            else
            {
                if (e.Error is ServerException)
                {
                    ServerException ex = e.Error as ServerException;
                    PlayerManager.Log("Error getting wheel raffles: " + e.Error.ToString(), LoggerLevel.Severe);
                    MessageForm.Show(String.Format("Unable to get wheel raffles. Reason: {0} ",
                        GameTech.Elite.Client.ServerErrorTranslator.GetReturnCodeMessage((GameTech.Elite.Client.ServerReturnCode)ex.ReturnCode)));
                }
                else
                {
                    PlayerManager.Log("Error getting wheel raffles: " + e.Error.ToString(), LoggerLevel.Severe);
                    MessageForm.Show("Unable to get wheel raffles. Reason: " + e.Error.Message);
                }
            }
            SetEnableWheelRaffleFields();
        }

        /// <summary>
        /// Actions that occur when a new prize is selected on the wheel raffle
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void wheelRafPrizeListBx_SelectedIndexChanged(object sender, EventArgs e)
        {
            SetEnableWheelRaffleFields();
        }

        /// <summary>
        /// Actions that occur when the user presses the button to create a new wheel raffle
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void newWheelRafBtn_Click(object sender, EventArgs e)
        {
            _editingWheelRaffle = true;
            wheelRaffleListBox.SelectedIndex = -1;
            ClearWheelRaffleFields();
            m_editingWheelRaffle = new WheelRaffle();
            SetEnableWheelRaffleFields();
        }

        /// <summary>
        /// Actions that occus when a new item is selected on the wheel raffle list box
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void wheelRaffleListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (wheelRaffleListBox.SelectedIndex != -1)
            {
                m_editingWheelRaffle = (WheelRaffle)wheelRaffleListBox.SelectedItem;
            }
            else
            {
                m_editingWheelRaffle = null;
            }
            _editingWheelRaffle = false;
            SetWheelRaffleFields();
        }

        /// <summary>
        /// Actions that occur when a user presses the close button on the wheel raffle form
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void closeBtn4_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        /// <summary>
        /// Actions that occur when the user presses the cancel button
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void wheelRafCancelBtn_Click(object sender, EventArgs e)
        {
            m_editingWheelRaffle = null;
            LoadWheelRaffle();
        }

        /// <summary>
        /// Actions that occur when the user presses the save button
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void wheelRafSaveBtn_Click(object sender, EventArgs e)
        {
            if (m_editingWheelRaffle != null)
            {
                m_editingWheelRaffle.Name = wheelRafNameTxtBx.Text;
                m_editingWheelRaffle.Description = wheelRafDescTxtBx.Text;
                m_editingWheelRaffle.Options.Clear();
                foreach (var option in wheelRafPrizeListBx.Items)
                {
                    if (option is WheelRafflePrizes) // sanity check. Should never get bad ones
                        m_editingWheelRaffle.Options.Add((WheelRafflePrizes)option);
                }

                try
                {
                    Tuple<int, int, int> ids = SetPrizeWheelRaffleDefinition.SetPrizeWheelRaffle(m_editingWheelRaffle);
                    SetPhotoMessage.SetPhoto(ids.Item2, m_editingWheelRaffle.WheelImage);
                    SetPhotoMessage.SetPhoto(ids.Item3, m_editingWheelRaffle.OverlayImage);

                    m_editingWheelRaffle = null;
                    LoadWheelRaffle();
                    wheelRafSaveLbl.Visible = true;
                }
                catch (ServerException ex)
                {
                    string err = String.Format("Unable to save wheel raffle. Reason: {0}",
                        GameTech.Elite.Client.ServerErrorTranslator.GetReturnCodeMessage((GameTech.Elite.Client.ServerReturnCode)ex.ReturnCode));
                    MessageForm.Show(err);
                    PlayerManager.Log(err, LoggerLevel.Severe);
                }
                catch (Exception ex)
                {
                    MessageForm.Show(String.Format("Unable to save wheel raffle. Reason: {0}", ex.Message));
                    PlayerManager.Log(String.Format("Unable to save wheel raffle. Reason: {0}", ex.ToString()), LoggerLevel.Severe);
                }
            }
            SetEnableWheelRaffleFields();
        }

        /// <summary>
        /// Actions that occur when the user presses the button to run the selected raffle
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnRunWheel_Click(object sender, EventArgs e)
        {
            if (m_editingWheelRaffle != null && m_editingWheelRaffle.ID.HasValue)
            {
                string prize = "";
                try
                {
                    prize = RunPrizeWheelRaffle.RunRaffle(m_editingWheelRaffle.ID.Value);

                    MessageForm.Show(String.Format("Raffle paid out: {0}", prize));
                }
                catch (ServerException ex)
                {
                    string err = String.Format("Unable to run wheel raffle. Reason: {0}",
                        GameTech.Elite.Client.ServerErrorTranslator.GetReturnCodeMessage((GameTech.Elite.Client.ServerReturnCode)ex.ReturnCode));
                    MessageForm.Show(err);
                    PlayerManager.Log(err, LoggerLevel.Severe);
                }
                catch (Exception ex)
                {
                    MessageForm.Show(String.Format("Unable to run wheel raffle. Reason: {0}", ex.Message));
                    PlayerManager.Log(String.Format("Unable to run wheel raffle. Reason: {0}", ex.ToString()), LoggerLevel.Severe);
                }
            }
        }

        private void addWheelRafPrizeBtn_Click(object sender, EventArgs e)
        {
            int weight;
            if (Int32.TryParse(wheelRafPrizeWeightTxtBx.Text, out weight) && weight > 0 && !String.IsNullOrWhiteSpace(wheelRafPrizeValTxtBx.Text))
            {
                WheelRafflePrizes prize = new WheelRafflePrizes();
                prize.Weight = weight;
                prize.Prize = wheelRafPrizeValTxtBx.Text;
                wheelRafPrizeListBx.Items.Add(prize);
                wheelRafPrizeWeightTxtBx.Text = "1";
                wheelRafPrizeListBx.Text = "";
                wheelRafPrizeWeightTxtBx.Focus();
            }
            SetEnableWheelRaffleFields();
        }

        private void removeWheelRafPrizeBtn_Click(object sender, EventArgs e)
        {
            if (wheelRafPrizeListBx.SelectedIndex != -1)
            {
                wheelRafPrizeListBx.Items.RemoveAt(wheelRafPrizeListBx.SelectedIndex);
            }
            SetEnableWheelRaffleFields();
        }

        /// <summary>
        /// Actions that occur when the "delete" button is pressed on the wheel raffle tab
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void deleteWheelRafBtn_Click(object sender, EventArgs e)
        {
            if (m_editingWheelRaffle != null)
            {
                try
                {
                    SetPrizeWheelRaffleDefinition.SetPrizeWheelRaffle(m_editingWheelRaffle, true);
                    LoadWheelRaffle();
                    wheelRafSaveLbl.Visible = true;
                }
                catch (ServerException ex)
                {
                    string err = String.Format("Unable to delete wheel raffle. Reason: {0}",
                        GameTech.Elite.Client.ServerErrorTranslator.GetReturnCodeMessage((GameTech.Elite.Client.ServerReturnCode)ex.ReturnCode));
                    MessageForm.Show(err);
                    PlayerManager.Log(err, LoggerLevel.Severe);
                }
                catch (Exception ex)
                {
                    MessageForm.Show(String.Format("Unable to delete wheel raffle. Reason: {0}", ex.Message));
                    PlayerManager.Log(String.Format("Unable to delete wheel raffle. Reason: {0}", ex.ToString()), LoggerLevel.Severe);
                }
            }
            SetEnableWheelRaffleFields();
        }

        /// <summary>
        /// Actions that occur when the "edit" button is pressed on the wheel raffle tab
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void editWheelRafBtn_Click(object sender, EventArgs e)
        {
            if (wheelRaffleListBox.SelectedIndex != -1)
            {
                _editingWheelRaffle = true;
                SetEnableWheelRaffleFields();
            }
        }

        /// <summary>
        /// Actions that occur when a text field in the wheel raffle is updated
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void wheelRafTxtBx_TextChanged(object sender, EventArgs e)
        {
            SetEnableWheelRaffleFields();
        }

        private void wheelRafPrizeValTxtBx_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                addWheelRafPrizeBtn_Click(this, new EventArgs());
        }
        
        /// <summary>
        /// Browses for an image and then sets the UI to an overlayed combination
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnBrowse_Click(object sender, EventArgs e)
        {
            OpenFileDialog fileDiag = new OpenFileDialog();
            DialogResult result = fileDiag.ShowDialog(this);
            if (result == DialogResult.OK)
            {
                try
                {
                    string file = fileDiag.FileName;
                    Bitmap imgTmp;
                    using (var bmpTemp = new Bitmap(file)) // make a copy so we don't lock what's on disk
                    {
                        imgTmp = new Bitmap(bmpTemp);
                    }

                    if (sender == btnBrowseWheel)
                    {
                        txtWheelImageLoc.Text = file;
                        if (m_editingWheelRaffle != null)
                            m_editingWheelRaffle.WheelImage = imgTmp;
                    }
                    else if (sender == btnBrowseOverlay)
                    {
                        txtOverlayImageLoc.Text = file;
                        if (m_editingWheelRaffle != null)
                            m_editingWheelRaffle.OverlayImage = imgTmp;
                    }

                    SetWheelRaffleImage();
                }
                catch (Exception ex)
                {
                    MessageForm.Show("Error loading image: "+ex.ToString());
                }
            }
        }
        #endregion Wheel Raffle Methods

        private void GetAndLoadPlayerListComboBox()
        {

            if (cmbxPlayerList.Items.Count > 0)
            {
                cmbxPlayerList.Items.Clear();
            }

            if (IndexToDefID.Count > 0)
            {
                IndexToDefID.Clear();
            }

            var getPlayerListDefinition = new GetPlayerListDefinition();
            var List_pld = getPlayerListDefinition.GetPlayerListDefinitionMessage();

            int indexOf = 0;

            var sortPlayerListDef = List_pld.OrderBy(x => x.StringValue);
            cmbxPlayerList.Items.Add("Use Current Players");
            foreach (var pld in sortPlayerListDef)
            {
                cmbxPlayerList.Items.Add(pld.StringValue);
                indexOf = indexOf + 1;
                IndexToDefID.Add(indexOf, pld.IntValue);
            }
        }

        private void setControlsToFalse2()
        {
            if (isNew2 != false) { isNew2 = false; }
            if (isUpdate2 != false) { isUpdate2 = false; }
            if (isDelete != false) { isDelete = false; }
            if (isCancel != false) { isCancel = false; }
            if (isSave != false) { isSave = false; }
            if (isClose != false) { isClose = false; }
        }

        private void HandleControlsFromInsertUpdateDeleteCancelSaveClose(int type)
        {
            //type; 1 = new; 2 = update; 3 = delete; 4 = cancel; 5 = close; 6 = save
            setControlsToFalse2();
            if (type == 1)//disable update, delete, listboxraffle, 
            {
                ReadOnlyFRaffleSettingControls();
                if (imgbtnUpdate.Enabled != false) { imgbtnUpdate.Enabled = false; }
                if (btnSetupDelete.Enabled != false) { btnSetupDelete.Enabled = false; }
                if (btnSetupNew.Enabled != false) { btnSetupNew.Enabled = false; }
                enableSaveCancelClose();
            }
            else if (type == 2)
            {

            }
            else if (type == 3)
            {
                if (isUpdate2 != true) { isUpdate2 = true; }
                ReadOnlyFRaffleSettingControls();
                enableSaveCancelClose();
                if (imgbtnUpdate.Enabled != false) { imgbtnUpdate.Enabled = false; }
                if (btnSetupDelete.Enabled != false) { btnSetupDelete.Enabled = false; }
                if (btnSetupNew.Enabled != false) { btnSetupNew.Enabled = false; }
            }
            else if (type == 4)//cancel
            {
                //cancel setback to default
                if (btnSetupDelete.Enabled != true) { btnSetupDelete.Enabled = true; }
                if (imgbtnUpdate.Enabled != true) { imgbtnUpdate.Enabled = true; }
                if (btnSetupNew.Enabled != true) { btnSetupNew.Enabled = true; }
                if (lstBxRafflePrizes2.Enabled != true) { lstBxRafflePrizes2.Enabled = true; }

                if (lstBxRafflePrizes2.SelectedIndex == -1)
                {
                    clearAllContentsRaffleSettings();
                    disableRaffleSettingsControls();
                }
                if (btnSetupSave.Enabled != false) { btnSetupSave.Enabled = false; }
                if (btnSetupCancel.Enabled != false) { btnSetupCancel.Enabled = false; }
            }
        }

        /// <summary>
        /// Check if the current entry is enough to run the raffle. 
        /// </summary>
        /// <returns></returns>
        private bool canWeRunTheRaffleWithTheCurrentPlayerEntry()
        {
            if (m_raffleEntryInfo == null)
            {
                return false;
            }

            return m_raffleEntryInfo.CurrentPlayerCount >= m_raffleEntryInfo.PlayersRequired;
        }

        /// <summary>
        /// Check if the current player entry is enough to win the no of prize per raffle. 
        /// </summary>
        /// <returns></returns>
        private bool doWeHaveEnoughPlayerToWinTheRafflePrize()
        {
            if (m_raffleEntryInfo == null)
            {
                return false;
            }

            return dataRafflePrize.NumberOfPrizes <= m_raffleEntryInfo.CurrentPlayerCount;;
        }

        private bool DisableOrEnableRunRaffle()
        {
            bool tempresult = canWeRunTheRaffleWithTheCurrentPlayerEntry();
            if (tempresult == false)
            {
                if (btnRunRaffle.Enabled != false) { btnRunRaffle.Enabled = false; }
            }
            else
            {
                if (btnRunRaffle.Enabled != true) { btnRunRaffle.Enabled = true; }
            }
            return tempresult;
        }

        /// <summary>
        /// Assign value to the vouchers.
        /// </summary>
        /// <param name="PlayerID"></param>
        private void getVouchersInfo(int PlayerID)
        {
            //INFO
            if (ActiveOperatorsData == null)
            {
                GetOperatorCompleteMessage getDataForReceipt = new GetOperatorCompleteMessage(GetOperatorID.operatorID);        //Run 18053 to get operator info           //Charity and operator 
                getDataForReceipt.Send();
                ActiveOperatorsData = getDataForReceipt.OperatorList.Single(l => l.Id == GetOperatorID.operatorID);
            }
            vouchers.OperatorsName = ActiveOperatorsData.Name;
            vouchers.OperatorsLicenseNumber = "";//null for now till i locate that license 
            vouchers.OperatorAddress1 = ((ActiveOperatorsData.Address1 != "") ? ActiveOperatorsData.Address1 + " " : "") + ((ActiveOperatorsData.Address2 != "") ? ActiveOperatorsData.Address2 + " " : "");
            vouchers.OperatorAddress2 = ((ActiveOperatorsData.City != "") ? ActiveOperatorsData.City + " " : "") + ((ActiveOperatorsData.State != "") ? ActiveOperatorsData.State + " " : "") + ((ActiveOperatorsData.Zip != "") ? ActiveOperatorsData.Zip + " " : "");//+ ((ActiveOperatorsData.Country != "") ? ActiveOperatorsData.Country + " " : "");
            //Skip charity for now
            vouchers.CharityName = "";
            vouchers.CharityLicenseNumber = "";

            //RAFFLE
            vouchers.RaffleID = dataRafflePrize.Id;
            vouchers.NoOfWinners = dataRafflePrize.NumberOfPrizes;
            vouchers.RaffleName = dataRafflePrize.Name;
            vouchers.RaffleDate = DateTime.Now; // format 01/01/2001 11:11:11AM
            vouchers.RaffleDescription = dataRafflePrize.Description;
            vouchers.RaffleDisclaimer = dataRafflePrize.Disclaimer;

            RafflePlayerWinnerInfo(PlayerID);
        }

        /// <summary>
        /// Get the player info and assign it to the voucher
        /// </summary>
        /// <param name="PlayerID"></param>
        private void RafflePlayerWinnerInfo(int PlayerID)
        {
            //run 8009 to get playerinfo
            GetPlayerDataMessage runGetPlayerInfo = new GetPlayerDataMessage(PlayerID);//now you have all his info
            runGetPlayerInfo.Send();
            //vouchers.RafflesWinnerID = runGetPlayerInfo.Id;
            vouchers.RafflesWinnersName = runGetPlayerInfo.FirstName + " " + runGetPlayerInfo.LastName; //raffleWinner.FirstName + " " + raffleWinner.LastName;
            vouchers.RafflesWinnerID = runGetPlayerInfo.PlayerId;//raffleWinner.PlayerID; //this is the current winner on the current raffle that is running
            vouchers.RafflesWinnerMagCard = runGetPlayerInfo.MagCardNumber;
            vouchers.RafflesWinnerMailingAddress1 = ((runGetPlayerInfo.Address1 != "") ? runGetPlayerInfo.Address1 + " " : "") + ((runGetPlayerInfo.Address2 != "") ? runGetPlayerInfo.Address2 + " " : "");
            vouchers.RafflesWinnerMailingAddress2 = ((runGetPlayerInfo.City != "") ? runGetPlayerInfo.City + " " : "") + ((runGetPlayerInfo.State != "") ? runGetPlayerInfo.State + " " : "") + ((runGetPlayerInfo.Zip != "") ? runGetPlayerInfo.Zip + " " : "");// +((runGetPlayerInfo.Country != "") ? runGetPlayerInfo.Country + " " : "");
            vouchers.RafflesWinnerPhoneNumber = runGetPlayerInfo.PhoneNumber;
        }

        /// <summary>
        /// Check if the receipt printer is installed
        /// </summary>
        private bool CheckForReceiptPrinter()
        {
            bool exists = false;
            PrinterName = raffle_Setting.posRafflePrinterName;

            if (PrinterName != null)
            {
                foreach (string printer in System.Drawing.Printing.PrinterSettings.InstalledPrinters)
                {
                    if (PrinterName == printer)//check if the receipt printer is installed
                    {
                        //it exists, check the status
                        if (checkReceiptPrinterStatus(PrinterName))
                        {
                            exists = true;
                            globalPrinter = new Printer(PrinterName);//Assign Printer
                            break;
                        }
                    }
                }
            }

            return exists;
        }

        private bool checkReceiptPrinterStatus(string printerName)
        {
            bool printerRunning = false;

            string query = string.Format("SELECT * from Win32_Printer WHERE Name LIKE '%{0}'", printerName);
            ManagementObjectSearcher searcher = new ManagementObjectSearcher(query);
            ManagementObjectCollection coll = searcher.Get();

            foreach (ManagementObject printer in coll)
            {
                int count = 0;
                foreach (PropertyData property in printer.Properties)
                {
                    //if (count == 18)//is printer default
                    //{
                    //    if (Convert.ToBoolean(property.Value) == false)
                    //    {
                    //        //  MessageBox.Show(property.Value.ToString());
                    //        isReceiptPrinterExists = false;
                    //        count = -1;
                    //        break;

                    //    }
                    //    else
                    //    {
                    //        isReceiptPrinterExists = true;
                    //    }
                    //}
                    //else 
                    if (count == 64)//printer state
                    {
                        // MessageBox.Show(property.Value.ToString());
                        if (Convert.ToInt32(property.Value) != 0)
                        {
                            printerRunning = false;
                        }
                        else
                        {
                            printerRunning = true;
                        }
                        count = -1;
                        break;
                    }

                    count = count + 1;
                }
                if (count == -1)
                {
                    break;
                }
            }

            //Reference for printer
            //default index = 18  true
            //detected error state = 27 0
            //printer state = 64  0
            //printer status = 65  3
            //extended printer status = 38  2
            //What is the statsu for offline?

            return printerRunning;
        }

        /// <summary>
        /// Replace proper displayed according to setting.
        /// </summary>
        private void AppliedSystemSettingDisplayedText()
        {
            displayedText = (raffle_Setting.RaffleTextSetting == 1) ? "Raffle" : "Drawing";
            if (displayedText != "")
            {
                wheelRaffleGroupBox1.Text = monRaffleGroupBox1.Text = groupBox1.Text = displayedText;
                tabPage2.Text = displayedText;
                btnRunRaffle.Text = "&Run " + displayedText;
                label5.Text = displayedText;
                //lblWarningMessage.Text =  (lblWarningMessage.Text.ToString()).Replace("raffle", displayedText.ToLower());
                btnClearRaffle.Text = "Cle&ar " + displayedText;
                this.Text = displayedText;

                btnRunMonetary.Text = String.Format("&Run Monetary {0}", displayedText);
                btnRunWheel.Text = String.Format("&Run Prize Wheel Raffle", displayedText);
            }
        }

        /// <summary>
        /// Enable controls in Raffle Settings.
        /// </summary>      
        private void enableRaffleSettingsControls()
        {
            if (txtbxSetupName.Enabled != true) { txtbxSetupName.Enabled = true; }
            if (txtbxSetupNumberofWinners.Enabled != true) { txtbxSetupNumberofWinners.Enabled = true; }
            if (txtbxSetupPrizeDescription.Enabled != true) { txtbxSetupPrizeDescription.Enabled = true; }
            if (txtbxDisclaimer.Enabled != true) { txtbxDisclaimer.Enabled = true; }
        }

        private void disableRaffleSettingsControls()
        {
            if (txtbxSetupName.Enabled != false) { txtbxSetupName.Enabled = false; }
            if (txtbxSetupNumberofWinners.Enabled != false) { txtbxSetupNumberofWinners.Enabled = false; }
            if (txtbxSetupPrizeDescription.Enabled != false) { txtbxSetupPrizeDescription.Enabled = false; }
            if (txtbxDisclaimer.Enabled != false) { txtbxDisclaimer.Enabled = false; }
        }

        private void clearAllContentsRaffleSettings()
        {
            if (txtbxSetupName.Text != string.Empty) { txtbxSetupName.Text = string.Empty; }
            if (txtbxSetupNumberofWinners.Text != string.Empty) { txtbxSetupNumberofWinners.Text = string.Empty; }
            if (txtbxSetupPrizeDescription.Text != string.Empty) { txtbxSetupPrizeDescription.Text = string.Empty; }
            if (txtbxDisclaimer.Text != string.Empty) { txtbxDisclaimer.Text = string.Empty; }
            // if (chkbxDisclaimer.Checked != false) { chkbxDisclaimer.Checked = false; }
        }

        private void ReadOnlyTRaffleSettingControls()
        {
            if (txtbxSetupName.ReadOnly != true) { txtbxSetupName.ReadOnly = true; }
            if (txtbxSetupNumberofWinners.ReadOnly != true) { txtbxSetupNumberofWinners.ReadOnly = true; }
            if (txtbxSetupPrizeDescription.ReadOnly != true) { txtbxSetupPrizeDescription.ReadOnly = true; }
            if (txtbxDisclaimer.ReadOnly != true) { txtbxDisclaimer.ReadOnly = true; }
        }

        private void ReadOnlyFRaffleSettingControls()
        {
            if (txtbxSetupName.ReadOnly != false) { txtbxSetupName.ReadOnly = false; }
            if (txtbxSetupNumberofWinners.ReadOnly != false) { txtbxSetupNumberofWinners.ReadOnly = false; }
            if (txtbxSetupPrizeDescription.ReadOnly != false) { txtbxSetupPrizeDescription.ReadOnly = false; }
            if (txtbxDisclaimer.ReadOnly != false) { txtbxDisclaimer.ReadOnly = false; }
        }

        private void disableSaveCancelClose()
        {
            if (btnSetupSave.Enabled != false) { btnSetupSave.Enabled = false; }
            if (btnSetupCancel.Enabled != false) { btnSetupCancel.Enabled = false; }
            if (btnSetupClose.Enabled != false) { btnSetupClose.Enabled = false; }
        }

        private void enableSaveCancelClose()
        {
            if (btnSetupSave.Enabled != true) { btnSetupSave.Enabled = true; }
            if (btnSetupCancel.Enabled != true) { btnSetupCancel.Enabled = true; }
            if (btnSetupClose.Enabled != true) { btnSetupClose.Enabled = true; }
        }

        private void enableInsertUpdateDeleteControls()
        {
            if (btnSetupNew.Enabled != true) { btnSetupNew.Enabled = true; }
            if (imgbtnUpdate.Enabled != true) { imgbtnUpdate.Enabled = true; }
            if (btnSetupDelete.Enabled != true) { btnSetupDelete.Enabled = true; }
        }

        private void disableInsertUpdateDeleteControls()
        {
            if (btnSetupNew.Enabled != false) { btnSetupNew.Enabled = false; }
            if (imgbtnUpdate.Enabled != false) { imgbtnUpdate.Enabled = false; }
            if (btnSetupDelete.Enabled != false) { btnSetupDelete.Enabled = false; }
        }

        private void clearAllMessages()
        {
            errorProvider1.Clear();
            if (isSave == false)
            {
                if (lblSavedSuccessfully.Visible != false)
                {
                    lblSavedSuccessfully.Visible = false;
                }
            }
            isSave = false;

        }

        private void loadcmbxRafle(List<RafflePrize> rafflePrizes)
        {
            //get the current item
            string CurrentRaffle = "";
            if (cmbxRaffle.SelectedIndex != -1)
            {
                CurrentRaffle = cmbxRaffle.SelectedItem.ToString();
            }

            if (cmbxRaffle.Items.Count > 0)
            {
                cmbxRaffle.Items.Clear();
            }

            foreach (RafflePrize drf in rafflePrizes)
            {
                cmbxRaffle.Items.Add(drf);
            }

            if (cmbxRaffle.Items.Count > 0)
            {
                cmbxRaffle.Sorted = true;
                cmbxRaffle.SelectedIndex = -1;
            }

            if (CurrentRaffle != "")
            {
                //select the current raffle
                cmbxRaffle.SelectedIndex = cmbxRaffle.Items.IndexOf(CurrentRaffle);
            }
        }

        private void loadRaffleInfo()
        {
            this.Cursor = Cursors.WaitCursor;
            
            var executeMe = System.Threading.Tasks.Task.Factory.StartNew(() => RunGetRaffleEntryInformationMessage(DefID));
            executeMe.Wait();

            if (m_raffleEntryInfo != null)
            {
                lblRaffleInfo.Text = string.Format("{0} Player(s) Entered / {1} Player(s) Required", m_raffleEntryInfo.CurrentPlayerCount, m_raffleEntryInfo.PlayersRequired);
            }

            N_OfPlayersReqMet = DisableOrEnableRunRaffle();
            if (cmbxRaffle.SelectedIndex != -1 && N_OfPlayersReqMet == true) { btnRunRaffle.Enabled = true; } else { btnRunRaffle.Enabled = false; }
            this.Cursor = Cursors.Default;
        }

        public void RunGetRaffleEntryInformationMessage(int playerListId)
        {
            var msg = new GetRaffleEntryInformationMessage(playerListId);
            try
            {
                msg.Send();
                m_raffleEntryInfo = msg.RaffleEntryInfo;
            }
            catch (Exception ex)
            {
                throw new Exception("GetRaffleEntryInformationMessage: " + ex.Message);
            }
        }

        private void loadListRaffle(List<RafflePrize> rafflePrizes )
        {
            if (lstBxRafflePrizes2.Items.Count > 0)
            {
                lstBxRafflePrizes2.Items.Clear();
            }

            foreach (RafflePrize drf in rafflePrizes)
            {
                //lstBxRafflePrizes.Items.Add(drf.RaffleName);
                lstBxRafflePrizes2.Items.Add(drf);
            }


            if (lstBxRafflePrizes2.Items.Count > 0)
            {
                lstBxRafflePrizes2.Sorted = true;

                if (isUpdate == true)
                {
                    int indexItem = lstBxRafflePrizes2.Items.IndexOf(RaffleName);
                    lstBxRafflePrizes2.SelectedIndex = indexItem;
                }
                else//for insert and delete
                {
                    lstBxRafflePrizes2.SelectedIndex = -1;
                }
            }
        }

        private void loadRaffleSettings()
        {
            txtbxSetupName.Text = dataRafflePrize.Name;
            txtbxSetupNumberofWinners.Text = dataRafflePrize.NumberOfPrizes.ToString(); ;
            txtbxSetupPrizeDescription.Text = dataRafflePrize.Description;
            txtbxDisclaimer.Text = dataRafflePrize.Disclaimer;
        }

        private void isRaffleSettingModify()
        {
            if (isUpdate == true)
            {
                if (dataRafflePrize.Name != txtbxSetupName.Text.ToString())
                {
                    isModify = true;
                }
                else if (dataRafflePrize.NumberOfPrizes != Convert.ToInt32(txtbxSetupNumberofWinners.Text))
                {
                    isModify = true;
                }
                else if (dataRafflePrize.Description != txtbxSetupPrizeDescription.Text.ToString())
                {
                    isModify = true;
                }
                else if (dataRafflePrize.Disclaimer != txtbxDisclaimer.Text.ToString())
                {
                    isModify = true;
                }
            }
        }

        private void SetAllCommandsToFalse()
        {
            isNew = false;
            isModify = false;
            isUpdate = false;
        }

        private void SaveOrUpdateRaffleDefinitions(int saveorupdate, bool isdelete)//0 = insert; !0 = update ; -1 delete
        {
            var drp = new RafflePrize(); // RaffleDefinition rd = new RaffleDefinition();
            drp.Id = saveorupdate;
            drp.Name = txtbxSetupName.Text;
            drp.NumberOfPrizes = Convert.ToInt32(txtbxSetupNumberofWinners.Text);
            drp.Description = txtbxSetupPrizeDescription.Text;
            drp.Disclaimer = txtbxDisclaimer.Text;
            int RaffleID = SetPlayerRaffleDefinitions.Set(drp, isdelete);
        }

        #endregion

        #region VALIDATING

        /// <summary>
        /// Validate disclaimer if its empty.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtbxDisclaimer_Validating(object sender, CancelEventArgs e)
        {
            if (isDisclaimerEnable == true)//only validate if its true
            {
                if (string.IsNullOrEmpty(txtbxDisclaimer.Text))
                {
                    errorProvider1.SetError(txtbxDisclaimer, "Invalid entry");
                    e.Cancel = true;
                }
            }
        }



        /// <summary>
        /// Validate raffle setting name.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtbxSetupPrizeDescription_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtbxSetupPrizeDescription.Text))
            {
                errorProvider1.SetError(txtbxSetupPrizeDescription, "Invalid entry");
                e.Cancel = true;
            }
        }

        private void txtbxSetupName_Validating(object sender, CancelEventArgs e)
        {
            string NewRaffleName = txtbxSetupName.Text;
            if (string.IsNullOrWhiteSpace(txtbxSetupName.Text))
            {
                errorProvider1.SetError(txtbxSetupName, "Invalid entry");
                e.Cancel = true;
            }
            else
            {

                if (lstBxRafflePrizes2.SelectedIndex == -1)//New insert
                {
                    foreach (RafflePrize rn in lstBxRafflePrizes2.Items)//Find if it exists
                    {

                        if (rn.Name.Equals(NewRaffleName, StringComparison.InvariantCultureIgnoreCase))
                        {
                            errorProvider1.SetError(txtbxSetupName, "Raffle name already exists.");
                            e.Cancel = true;
                        }
                    }
                }
                else //delete or update
                {
                    if (isNew == false && isUpdate == true)//check if the new name already exists.
                    {
                        foreach (RafflePrize rn in lstBxRafflePrizes2.Items)//Find if it exists
                        {
                           
                            int findIndex = lstBxRafflePrizes2.Items.IndexOf(rn);    //find the index of each item
                            
                            if (lstBxRafflePrizes2.SelectedIndex != findIndex)//exclude itself
                            {
                                
                                if (rn.Name.Equals(NewRaffleName, StringComparison.InvariantCultureIgnoreCase))
                                {
                                    errorProvider1.SetError(txtbxSetupName, "Raffle name already exists.");
                                    e.Cancel = true;
                                }
                            }
                        }
                    }
                }

            }
        }

        /// <summary>
        /// Validate raffle setting number of winners.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtbxSetupNumberofWinners_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtbxSetupNumberofWinners.Text))
            {
                errorProvider1.SetError(txtbxSetupNumberofWinners, "Invalid entry.");
                e.Cancel = true;
            }
        }


        /// <summary>
        /// Validate if the user selected a raffle to run.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmbxRaffle_Validating(object sender, CancelEventArgs e)
        {
            if (cmbxRaffle.SelectedIndex == -1)//&& isRunRaffle == true)
            {
                //lblWarningMessage.Text = "Invalid entry. Please select a raffle.";
                //lblWarningMessage.Visible = true;
                e.Cancel = true;
            }
        }

        #endregion

        #region EVENTS

        /// <summary>
        /// Allow numeric only input on Number of Winners Textbox.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtbxSetupNumberofWinners_KeyPress(object sender, KeyPressEventArgs e)
        {
            bool result = false;

            if (!char.IsControl(e.KeyChar))
            {
                switch (e.KeyChar)
                {
                    case (char)46://period
                        result = false;
                        break;
                    default:
                        result = !char.IsDigit(e.KeyChar);
                        break;
                }
            }

            if (result == false)
            {
                //m_bModified = true;
            }

            e.Handled = result;
        }

        private void cmbxPlayerList_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbxPlayerList.SelectedIndex != 0 && cmbxPlayerList.SelectedIndex != -1)
            {
                if (IndexToDefID.ContainsKey(cmbxPlayerList.SelectedIndex))
                {
                    DefID = IndexToDefID[cmbxPlayerList.SelectedIndex];
                    loadRaffleInfo();
                }
            }
            else if (cmbxPlayerList.SelectedIndex == 0)
            {
                DefID = 0;
                loadRaffleInfo();
                N_OfPlayersReqMet = DisableOrEnableRunRaffle();
                if (cmbxRaffle.SelectedIndex != -1 && N_OfPlayersReqMet == true) { btnRunRaffle.Enabled = true; } else { btnRunRaffle.Enabled = false; }
            }
            else if (cmbxPlayerList.SelectedIndex == -1)
            {
                lblRaffleInfo.Text = string.Empty;
            }
        }

        private void imgbtnUpdate_Click(object sender, EventArgs e)
        {
            // if (isUpdate2 != true) isUpdate2 = true;
            if (lstBxRafflePrizes2.Items.Count > 0)
            {
                if (lstBxRafflePrizes2.SelectedIndex == -1)
                {
                    errorProvider1.SetError(imgbtnUpdate, "No raffle was selected on the list.");
                    //clearAllContentsRaffleSettings();
                    return;
                }
            }
            else if (lstBxRafflePrizes2.Items.Count == 0)
            {
                errorProvider1.SetError(imgbtnUpdate, "No raffle was selected on the list.");
                return;
            }
            HandleControlsFromInsertUpdateDeleteCancelSaveClose(3);
        }

        /// <summary>
        /// Add new raffle prize.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSetupNew_Click(object sender, EventArgs e)
        {
            clearAllMessages();
            isNew = true;
            isUpdate = false;
            enableRaffleSettingsControls();
            clearAllContentsRaffleSettings();
            // lstBxRafflePrizes.SelectedIndex = -1; 
            lstBxRafflePrizes2.SelectedIndex = -1;
            txtbxSetupName.Focus();
            HandleControlsFromInsertUpdateDeleteCancelSaveClose(1);
        }

        /// <summary>
        /// Close application.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSetupClose_Click(object sender, EventArgs e)
        {
            isClose = true;
            bool saveChanges = false;
            if (isUpdate2 == true)
            {
                //check if something is modify
                isRaffleSettingModify();

                if (isModify == true)
                {
                    saveChanges = openActivity(2);
                }
                isModify = false;
                if (saveChanges == true)
                {
                    btnSetupSave.PerformClick();
                    isClose = false;
                    // e.Cancel = true;
                    return;
                }
                else
                {
                    lstBxRafflePrizes2.SelectedIndex = -1;
                    setControlsToFalse2();
                    SetAllCommandsToFalse();
                }
            }
            else if (isNew == true)
            {
                saveChanges = openActivity(1);
                if (saveChanges == true)
                {
                    isSave = true;
                    //btnSetupSave.PerformClick();
                    isClose = false;
                    return;
                    //e.Cancel = true;
                }
                else
                {
                    lstBxRafflePrizes2.SelectedIndex = -1;
                    setControlsToFalse2();
                    SetAllCommandsToFalse();
                }
            }

            clearAllMessages();
            isNew = false;
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        /// <summary>
        /// Clear all contents on raffle settings.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSetupCancel_Click(object sender, EventArgs e)//knc
        {
            clearAllMessages();

            if (isNew == true)
            {
                clearAllContentsRaffleSettings();
                HandleControlsFromInsertUpdateDeleteCancelSaveClose(4);
            }
            else if (isUpdate == true)
            {
                string tempRaffleName = dataRafflePrize.Name;
                lstBxRafflePrizes2.SelectedIndex = -1;       
                int tempIndex = lstBxRafflePrizes2.Items.IndexOf(tempRaffleName);      
                lstBxRafflePrizes2.SelectedIndex = tempIndex;
                //Enable new,edit and delete button.
                if (btnSetupDelete.Enabled != true) { btnSetupDelete.Enabled = true; }
                if (imgbtnUpdate.Enabled != true) { imgbtnUpdate.Enabled = true; }
                if (btnSetupNew.Enabled != true) { btnSetupNew.Enabled = true; }
            }
            setControlsToFalse2();
        }

        private bool SaveAddNewRaffle()
        {
            bool tempResult = false;
            if (!string.IsNullOrEmpty(txtbxSetupName.Text) && !string.IsNullOrEmpty(txtbxSetupNumberofWinners.Text) && !string.IsNullOrEmpty(txtbxSetupPrizeDescription.Text))
            {
                DialogResult dialogResult = MessageForm.Show("Do you want to add this new raffle?", "Confirm", MessageFormTypes.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    tempResult = true;
                    btnSetupSave.PerformClick();
                }
                else
                {
                    tempResult = false;
                }
            }
            else if (!string.IsNullOrEmpty(txtbxSetupName.Text) || !string.IsNullOrEmpty(txtbxSetupNumberofWinners.Text) || !string.IsNullOrEmpty(txtbxSetupPrizeDescription.Text) || !string.IsNullOrEmpty(txtbxDisclaimer.Text))
            {
                DialogResult dialogResult = MessageForm.Show("Do you want to continue adding the new raffle?", "Confirm", MessageFormTypes.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    tempResult = true;
                }
                else
                {
                    tempResult = false;
                }
            }

            return tempResult;
        }

        private bool openActivity(int type)//2 = update
        {
            bool tempResult = false;
            if (type == 2)
            {
                DialogResult dialogResult = MessageForm.Show("Do you want save your changes?", "Confirm", MessageFormTypes.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    tempResult = true;
                }
                else
                {
                    tempResult = false;
                }
            }
            else if (type == 1)//insert
            {
                tempResult = SaveAddNewRaffle();
            }

            return tempResult;
        }

        /// <summary>
        /// Delete raffle
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSetupDelete_Click(object sender, EventArgs e)
        {
            clearAllMessages();
            disableRaffleSettingsControls();

            if (lstBxRafflePrizes2.Items.Count == 0)
            {
                errorProvider1.SetError(btnSetupDelete, "Raffle list is empty, create a new raffle.");
                clearAllContentsRaffleSettings();
                return;
            }

            //if (lstBxRafflePrizes.SelectedIndex != -1)

            SetAllCommandsToFalse();
            setControlsToFalse2();
            if (lstBxRafflePrizes2.SelectedIndex != -1)
            {
                // DeleteRafflePrizeSQL run = new DeleteRafflePrizeSQL(dataRafflePrize.RaffleID);
                var Exists = ListPreviousWinner.data.Exists(l => l.RaffleID == dataRafflePrize.Id);
                if (Exists == true)
                {
                    ListPreviousWinner.data.RemoveAll(l => l.RaffleID == dataRafflePrize.Id);
                }
                if (cmbxRaffle.SelectedIndex != -1)
                {
                    if (cmbxRaffle.SelectedItem.ToString() == dataRafflePrize.Name)
                    {
                        if (cmbxRaffle.Items.Count != 0)
                        {
                            cmbxRaffle.SelectedIndex = 0;
                        }
                        else
                        {
                            cmbxRaffle.SelectedIndex = -1;
                        }
                    }
                }

                SaveOrUpdateRaffleDefinitions(dataRafflePrize.Id, true);
                loadListRaffle(GetPlayerRafflePrizesMessage.GetRafflePrizes());
                clearAllContentsRaffleSettings();
                SetAllCommandsToFalse();
            }
            else
            {
                errorProvider1.SetError(btnSetupDelete, "No raffle was selected on the list.");
                clearAllContentsRaffleSettings();
                return;
            }
        }

        private void ClearErrorProvider(object sender, EventArgs e)
        {
            clearAllMessages();
        }

        private void colorListBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lstBxRafflePrizes2.SelectedIndex != -1)
            {
                isNew = false;
                isUpdate = true;
                //dataRafflePrize = List_DataRafflePrize.LDataRafflePrize.Single(l => l.RaffleName == lstBxRafflePrizes.SelectedItem.ToString());
                dataRafflePrize = (RafflePrize)lstBxRafflePrizes2.SelectedItem;
                loadRaffleSettings();
                enableRaffleSettingsControls();

                ReadOnlyTRaffleSettingControls();
                enableInsertUpdateDeleteControls();

                if (btnSetupSave.Enabled != false) { btnSetupSave.Enabled = false; }
                if (btnSetupCancel.Enabled != false) { btnSetupCancel.Enabled = false; }

            }
            else
            {
                clearAllContentsRaffleSettings();
            }
        }

        /// <summary>
        /// For changing tab
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tbctrlRafle_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (Convert.ToInt32(tbctrlRafle.SelectedTab.Tag) == 1)//RaffleSetup Tab
            {
                HandleControlsFromInsertUpdateDeleteCancelSaveClose(4);
            }
            else if (Convert.ToInt32(tbctrlRafle.SelectedTab.Tag) == 2)//Raffle Tab
            {
                //loadRaffleInfo();
                DisableOrEnableRunRaffle();
                cmbxRaffle.SelectedIndex = -1;
                cmbxPlayerList.SelectedIndex = -1;
                btnRunRaffle.Enabled = false;
                label6.Text = "Winners";
            }
            clearAllMessages();
        }

        private void btnRaffleClose_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        /// <summary>
        /// Select a available raffle.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmbxRaffle_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                lstbxRaffleWinners2.Items.Clear();

                if (cmbxRaffle.SelectedIndex != -1)
                {
                    dataRafflePrize = (RafflePrize)cmbxRaffle.SelectedItem;
                }
                else
                {
                    if (btnRunRaffle.Enabled != false) { btnRunRaffle.Enabled = false; }
                    return;
                }

                if (cmbxRaffle.SelectedIndex != -1 && cmbxPlayerList.SelectedIndex != -1)
                {
                    //Check if the number of player is enough to win the raffle prize
                    if (!DisableOrEnableRunRaffle())
                    {
                        return;
                    }

                    if (doWeHaveEnoughPlayerToWinTheRafflePrize())
                    {
                        btnRunRaffle.Enabled = true;
                    }
                    else
                    {
                        btnRunRaffle.Enabled = false;
                    }

                    //check if the selected raffle have previous winner 
                    if (ListPreviousWinner.data.Count != 0 && ListPreviousWinner.data.Exists(l => l.RaffleID == dataRafflePrize.Id))
                    {
                        string messagetext = "";
                        DataPreviousWinner dpw = ListPreviousWinner.data.First(l => l.RaffleID == dataRafflePrize.Id);
                        if (dpw.WinnerPlayerID.Count > 1)
                        {
                            messagetext = "Previous Winners";
                        }
                        else
                        {
                            messagetext = "Previous Winner";
                        }
                        label6.Text = messagetext;

                        if (!string.IsNullOrEmpty(dpw.RaffleName))
                        {
                            for (int i = 0; i < dpw.WinnerPlayerID.Count; i++)
                            {
                                lstbxRaffleWinners2.Items.Add((i + 1).ToString() + ". " + dpw.WinnerPlayerFName[i].ToString() + " " + dpw.WinnerPlayerLName[i].ToString());
                            }
                        }
                    }
                    else
                    {
                        label6.Text = "Winners";
                    }
                }
                else if (cmbxRaffle.SelectedIndex != -1)
                {
                    //check if the selected raffle have previous winner 
                    if (ListPreviousWinner.data.Count != 0 && ListPreviousWinner.data.Exists(l => l.RaffleID == dataRafflePrize.Id))
                    {
                        DataPreviousWinner dpw = ListPreviousWinner.data.Single(l => l.RaffleID == dataRafflePrize.Id);//This will commit an error if it did not found.
                        string messagetext = "";
                        if (dpw.WinnerPlayerID.Count > 1)//ERROR
                        {
                            messagetext = "Previous Winners";
                        }
                        else
                        {
                            messagetext = "Previous Winner";
                        }
                        label6.Text = messagetext;

                        if (!string.IsNullOrEmpty(dpw.RaffleName))
                        {
                            for (int i = 0; i < dpw.WinnerPlayerID.Count; i++)
                            {
                                lstbxRaffleWinners2.Items.Add((i + 1).ToString() + ". " + dpw.WinnerPlayerFName[i].ToString() + " " + dpw.WinnerPlayerLName[i].ToString());
                            }
                        }
                    }
                    else
                    {
                        label6.Text = "Winners";
                    }
                }
            }
            catch (Exception ex)
            {
                PlayerManager.Log(String.Format("Error selecting {0} in drop-down: {1}", label5.Text, ex.ToString()), LoggerLevel.Severe);
                MessageForm.Show(String.Format("Error selecting {0} in drop-down: {1}", label5.Text, ex.Message));
            }
        }

        /// <summary>
        /// Save or update raffle prize.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSetupSave_Click(object sender, EventArgs e)
        {
            clearAllMessages();

            ///Check all input entry

            if (!ValidateChildren(ValidationConstraints.Enabled | ValidationConstraints.Visible))
                return;

            if (isNew == false && isUpdate == false)
            {
                errorProvider1.SetError(btnSetupSave, "Create new raffle or select a raffle in the list to update.");
                return;
            }
            else if (isNew == true && isUpdate == false)//Insert new entry
            {
                SaveOrUpdateRaffleDefinitions(0, false);
                clearAllContentsRaffleSettings();
                txtbxSetupName.Focus();
            }
            else if (isNew == false && isUpdate == true) //Update
            {
                isRaffleSettingModify();
                if (isModify == true)
                {
                    RaffleName = txtbxSetupName.Text.ToString();
                    SaveOrUpdateRaffleDefinitions(dataRafflePrize.Id, false);
                }
                else
                {
                    return;
                }
            }

            if (isNew == true || isModify == true)
            {
                loadListRaffle(GetPlayerRafflePrizesMessage.GetRafflePrizes());
            }
            isModify = false;

            if (lblSavedSuccessfully.Visible != true)
            {
                lblSavedSuccessfully.Visible = true;
                setControlsToFalse2();
                //SetAllCommandsToFalse();                
            }
        }

        //RUN RAFFLE
        private void btnRunRaffle_Click(object sender, EventArgs e)
        {
            if (!ValidateChildren(ValidationConstraints.Enabled | ValidationConstraints.Visible))
                return;

            if (dataRafflePrize.NumberOfPrizes > 1) { label6.Text = "Winners"; } else { label6.Text = "Winner"; }

            if (lstbxRaffleWinners2.Items.Count != 0)
            {
                lstbxRaffleWinners2.Items.Clear();
            }

            List<RaffleWinner> raffleWinners = new List<RaffleWinner>();

            //disable Run button and close button
            btnRunRaffle.Enabled = false;
            btnRaffleClose.Enabled = false;
            btnClearRaffle.Enabled = false;
            btnRaffleReprintVoucher.Enabled = false;

            int delaytime = 0;
            bool resultTryParse = Int32.TryParse(RaffleDelayValue.Value.ToString(), out delaytime);//what happen if this is 0 or empty  //Get the raffle duration delay  

            RaffleWinner raffleWinner = new RaffleWinner();//Winner should be clear in runnning a new raffle.
            Cursor.Current = Cursors.WaitCursor;

            for (int startcount = 0; startcount < dataRafflePrize.NumberOfPrizes; startcount++)
            {
                int tempRaffleHistory = 0; //check if the raffleHistory already exists if not then set to 0 = new;
                tempRaffleHistory = raffleWinner.HistoryId;
                try
                {
                    var runRaffleMessage = new RunPlayerRaffleMessage(dataRafflePrize.Id, tempRaffleHistory, DefID);
                    runRaffleMessage.Send();

                    raffleWinner = runRaffleMessage.Winner;
                }
                catch (Exception ex)
                {
                    MessageForm.Show(String.Format("Unable get run raffle: {0}", ex.Message));
                    return;
                }
                
                raffleWinners.Add(raffleWinner);
                if (String.IsNullOrWhiteSpace(raffleWinner.FirstName) && String.IsNullOrWhiteSpace(raffleWinner.LastName))
                    lstbxRaffleWinners2.Items.Add((startcount + 1).ToString() + ". " + String.Format("[Player Id {0}]", raffleWinner.PlayerId));
                else
                    lstbxRaffleWinners2.Items.Add((startcount + 1).ToString() + ". " + raffleWinner.FirstName + " " + raffleWinner.LastName);

                getVouchersInfo(raffleWinner.PlayerId);
                RaffleReceipt raffleReceipt = new RaffleReceipt();
                AssignValueToReceipt(raffleReceipt, startcount);

                lstbxRaffleWinners2.SelectedIndex = startcount;
                lstbxRaffleWinners2.SetSelected(startcount, false);

                if (CheckForReceiptPrinter())
                {
                    raffleReceipt.Print(globalPrinter, 1);//Just print one copy  //Print the winners vouchers
                }

                Application.DoEvents();
                if (delaytime > 0 && startcount + 1 < dataRafflePrize.NumberOfPrizes) // if there is another winner after this one, we should delay.
                    System.Threading.Thread.Sleep(((delaytime + 1) * 1000)); // note: same setting that remote display listens to. Can take a bit to load player images
            }

            btnRunRaffle.Enabled = true;
            btnRaffleClose.Enabled = true;
            btnClearRaffle.Enabled = true;
            btnRaffleReprintVoucher.Enabled = true;
            Cursor.Current = Cursors.Default;

            //save to datapreviouswinner
            if (ListPreviousWinner.data.Count != 0)
            {
                var isRaffleExists = ListPreviousWinner.data.Exists(l => l.RaffleID == dataRafflePrize.Id);       //check if the raffleName alrady exists
                if (isRaffleExists == true)
                {
                    //delete it 
                    ListPreviousWinner.data.RemoveAll(l => l.RaffleID == dataRafflePrize.Id);

                }
            }


            DataPreviousWinner dpw = new DataPreviousWinner();
            dpw.RaffleID = dataRafflePrize.Id;
            dpw.RaffleName = dataRafflePrize.Name;

            foreach (RaffleWinner rw in raffleWinners)
            {
                dpw.WinnerPlayerID.Add(rw.PlayerId);
                dpw.WinnerPlayerFName.Add(rw.FirstName);
                dpw.WinnerPlayerLName.Add(rw.LastName);
            }

            ListPreviousWinner.data.Add(dpw);
            //loadRaffleInfo(); //Update the raffleInfo
            //DisableOrEnableRunRaffle();

        }

        private void AssignValueToReceipt(RaffleReceipt raffleReceipt1, int count)
        {
            raffleReceipt1.OperatorHeaderLine1 = raffle_Setting.OperatorName; //RaffleSettings.data[6].RaffleSettingValue; //"Bingo Rama";//test
            raffleReceipt1.OperatorHeaderLine2 = raffle_Setting.SponsoredBy; //RaffleSettings.data[7].RaffleSettingValue; //"NDAD";//test
            raffleReceipt1.OperatorHeaderLine3 = vouchers.OperatorAddress1;
            raffleReceipt1.OperatorHeaderLine4 = vouchers.OperatorAddress2;
            raffleReceipt1.HeaderLine1 = displayedText;
            raffleReceipt1.RaffleID = vouchers.RaffleID;
            raffleReceipt1.NoOfWinners = vouchers.NoOfWinners;
            raffleReceipt1.WinnersCount = count + 1;
            raffleReceipt1.RaffleName = vouchers.RaffleName;
            raffleReceipt1.RaflleDate = vouchers.RaffleDate;
            //remove the new entry line and replace it with space
            raffleReceipt1.RaffleDescription = vouchers.RaffleDescription.Replace("'\n'", "");
            raffleReceipt1.RafflesWinnersID = vouchers.RafflesWinnerID;
            raffleReceipt1.RafflesWinnerName = vouchers.RafflesWinnersName;
            raffleReceipt1.RafflesWinnerMagCard = vouchers.RafflesWinnerMagCard;
            raffleReceipt1.RafflesWinnerMailingAddress1 = vouchers.RafflesWinnerMailingAddress1;
            raffleReceipt1.RafflesWinnerMailingAddress2 = vouchers.RafflesWinnerMailingAddress2;
            raffleReceipt1.RafflesWinnerPhoneNumber = vouchers.RafflesWinnerPhoneNumber;
            raffleReceipt1.RaffleDisclaimer = vouchers.RaffleDisclaimer;
        }

        private void btnRaffleReprintVoucher_Click(object sender, EventArgs e)
        {

            //Do we have a winner in the listbox? If not then exit
            if (lstbxRaffleWinners2.Items.Count == 0)// && isReprint == true)
            {
                //lblWarningMessage.Text = "There are no winners on the raffle list.";
                //lblWarningMessage.Visible = true;
                return;
            }

            DataPreviousWinner RafflePreviousWinner = ListPreviousWinner.data.Single(l => l.RaffleID == dataRafflePrize.Id);

            //Print only selected winner
            if (lstbxRaffleWinners2.SelectedIndex == -1)//print all
            {
                int count = 0;
                // foreach (RaffleWinner rw in ListOfCurrentRaffleWinner.ListOfRaffleWinners)
                foreach (int playerID in RafflePreviousWinner.WinnerPlayerID)
                {
                    //get the playerID
                    getVouchersInfo(playerID);
                    RaffleReceipt raffleReceipt = new RaffleReceipt();
                    AssignValueToReceipt(raffleReceipt, count);

                    if (CheckForReceiptPrinter())
                    {
                        raffleReceipt.Print(globalPrinter, 1);//Just print one copy  //Print the winners vouchers
                    }
                    count = count + 1;
                }
            }
            else //print a single winner
            {
                //Get the player ID of the selected winner
                //Its the same index order of RafflePreviousWinner
                //get the index 
                int indexOfPlayerWinner = lstbxRaffleWinners2.SelectedIndex;
                //get the playerID of the selected index
                int PlayerID = RafflePreviousWinner.WinnerPlayerID[indexOfPlayerWinner];
                getVouchersInfo(PlayerID);
                RaffleReceipt raffleReceipt = new RaffleReceipt();
                AssignValueToReceipt(raffleReceipt, 0);
                if (CheckForReceiptPrinter())
                {
                    raffleReceipt.Print(globalPrinter, 1);//Just print one copy  //Print the winners vouchers
                }
            }
        }

        private void btnClearRaffle_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageForm.Show("Are you sure you want to permanently delete the players entered into the raffle?", "Confirm", MessageFormTypes.YesNo);

            if (dialogResult == DialogResult.Yes)
            {
                ClearPlayerRaffleMessage clearplayerraffle = new ClearPlayerRaffleMessage();
                clearplayerraffle.Send();
                //loadRaffleInfo();

            }
            else
            {

            }
        }

        private void tbctrlRafle_Selecting(object sender, TabControlCancelEventArgs e)
        {
            if (tbctrlRafle.SelectedIndex != 0)
            {
                bool saveChanges = false;

                if (isUpdate2 == true)
                {
                    //check if something is modify
                    isRaffleSettingModify();

                    if (isModify == true)
                    {
                        saveChanges = openActivity(2);

                    }
                    isModify = false;
                    if (saveChanges == true)
                    {
                        btnSetupSave.PerformClick();
                        e.Cancel = true;
                    }
                    else
                    {

                        lstBxRafflePrizes2.SelectedIndex = -1;
                        setControlsToFalse2();
                        SetAllCommandsToFalse();

                    }
                }
                else if (isNew == true)
                {
                    saveChanges = openActivity(1);
                    if (saveChanges == true)
                    {
                        isSave = true;
                        e.Cancel = true;
                    }
                    else
                    {

                        lstBxRafflePrizes2.SelectedIndex = -1;
                        setControlsToFalse2();
                        SetAllCommandsToFalse();

                    }

                }

                lblRaffleInfo.Text = string.Empty;
            }
        }

        private void Raffle_FormClosing(object sender, FormClosingEventArgs e)
        {
            // MessageBox.Show("Test");
            if (isClose == false)
            {
                bool saveChanges = false;
                if (isUpdate2 == true)
                {
                    //check if something is modify
                    isRaffleSettingModify();

                    if (isModify == true)
                    {
                        saveChanges = openActivity(2);

                    }
                    isModify = false;
                    if (saveChanges == true)
                    {
                        btnSetupSave.PerformClick();
                        //isClose = false;
                        e.Cancel = true;
                        return;
                    }
                    else
                    {

                        lstBxRafflePrizes2.SelectedIndex = -1;
                        setControlsToFalse2();
                        SetAllCommandsToFalse();

                    }
                }
                else if (isNew == true)
                {
                    saveChanges = openActivity(1);
                    if (saveChanges == true)
                    {
                        isSave = true;
                        //btnSetupSave.PerformClick();
                        //isClose = false;
                        //return;
                        e.Cancel = true;
                        return;
                    }
                    else
                    {

                        lstBxRafflePrizes2.SelectedIndex = -1;
                        setControlsToFalse2();
                        SetAllCommandsToFalse();

                    }

                }

                clearAllMessages();
                isNew = false;
                isClose = false;
            }
        }

        #endregion

        private class Vouchers
        {
            public string OperatorsName { get; set; }
            public string OperatorsLicenseNumber { get; set; }
            public string OperatorAddress1 { get; set; }
            public string OperatorAddress2 { get; set; }
            public string CharityName { get; set; }
            public string CharityLicenseNumber { get; set; }
            public int RaffleID { get; set; }
            public int NoOfWinners { get; set; }
            public string RaffleName { get; set; }
            public DateTime RaffleDate { get; set; }
            public string RaffleDescription { get; set; }
            public string RafflesWinnersName { get; set; }
            public int RafflesWinnerID { get; set; }
            public string RafflesWinnerMagCard { get; set; }
            public string RafflesWinnerMailingAddress1 { get; set; }
            public string RafflesWinnerMailingAddress2 { get; set; }
            public string RafflesWinnerPhoneNumber { get; set; }
            public string RaffleDisclaimer { get; set; }
        }
    }

    public class raffle_Setting
    {
        public static string posRafflePrinterName;
        public static int RaffleTextSetting;
        public static string OperatorName;
        public static string SponsoredBy;
        public static int RaffleRunLocation;
    }
}
