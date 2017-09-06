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

namespace GTI.Modules.PlayerCenter.UI
{


    public partial class Raffle : GradientForm
    {
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
        private int N_oFDefaultPlayer;
        private bool N_OfPlayersReqMet;
        int[] RaffleSettingID = new int[] { 214 };//, 22, 182, 38, 37, 3, 189, 190 };//, 77 };
        Vouchers vouchers = new Vouchers();
        Printer globalPrinter;
        DataRafflePrizes dataRafflePrize = new DataRafflePrizes();
        RaffleWinner raffleWinner = new RaffleWinner();
        Dictionary<int, int> IndexToDefID = new Dictionary<int, int>();
        private Operator ActiveOperatorsData;

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

        public Raffle()
        {
            InitializeComponent();
            loadListRaffle();

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
        }



        #region METHODS

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

            GetPlayerListDefinition get_pld = new GetPlayerListDefinition();
            List<PlayerListDefinition> List_pld = get_pld.GetPlayerListDefinitionMSG();

            int indexOf = 0;

            var sortPlayerListDef = List_pld.OrderBy(x => x.DefinitionName);
            cmbxPlayerList.Items.Add("Use Current Players");
            foreach (PlayerListDefinition pld in sortPlayerListDef)
            {
                cmbxPlayerList.Items.Add(pld.DefinitionName);
                indexOf = indexOf + 1;
                IndexToDefID.Add(indexOf, pld.DefId);
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
            bool result = false;
            if (RaffleInfo.m_currentPlayerCount >= RaffleInfo.m_playersReq) //Check if the players requirements was met.
            {
                result = true;
            }

            return result;
        }

        /// <summary>
        /// Check if the current player entry is enough to win the no of prize per raffle. 
        /// </summary>
        /// <returns></returns>
        private bool doWeHaveEnoughPlayerToWinTheRafflePrize()
        {
            bool result = false;
            if (dataRafflePrize.NoOfRafflePrize <= RaffleInfo.m_currentPlayerCount)
            {
                result = true;
            }

            return result;
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
            vouchers.RaffleID = dataRafflePrize.RaffleID;
            vouchers.NoOfWinners = dataRafflePrize.NoOfRafflePrize;
            vouchers.RaffleName = dataRafflePrize.RaffleName;
            vouchers.RaffleDate = DateTime.Now; // format 01/01/2001 11:11:11AM
            vouchers.RaffleDescription = dataRafflePrize.RafflePrizeDescription;
            vouchers.RaffleDisclaimer = dataRafflePrize.RaffleDisclaimer;

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
            //
            //displayedText = (Convert.ToInt32(RaffleSettings.data[2].RaffleSettingValue.ToString()) == 1) ? "Raffle" : "Drawing";
            displayedText = (raffle_Setting.RaffleTextSetting == 1) ? "Raffle" : "Drawing";
            if (displayedText != "")
            {
                groupBox1.Text = displayedText;
                tabPage2.Text = displayedText;
                btnRunRaffle.Text = "&Run " + displayedText;
                label5.Text = displayedText;
                //lblWarningMessage.Text =  (lblWarningMessage.Text.ToString()).Replace("raffle", displayedText.ToLower());
                btnClearRaffle.Text = "Cle&ar " + displayedText;
                this.Text = displayedText;
            }
        }


        /// <summary>
        /// Enable controls in Raffle Settings.
        /// </summary>
        ///        
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

                //if (lblWarningMessage.Visible != false)
                //{
                //    lblWarningMessage.Visible = false;
                //}
            }
            isSave = false;

        }

        private void loadcmbxRafle()
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

            foreach (DataRafflePrizes drf in List_DataRafflePrize.LDataRafflePrize)
            {
                cmbxRaffle.Items.Add(drf.RaffleName);
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

            GetRaffleInformation gri = new GetRaffleInformation(DefID);
            this.Cursor = Cursors.WaitCursor;
            //var ExecuteMe = System.Threading.Tasks.Task.Factory.StartNew(() => NOfPlayer = gri.GetNumberOfPlayerPerPlayerList(GetOperatorID.operatorID, DefID));//SQL
            var ExecuteMe = System.Threading.Tasks.Task.Factory.StartNew(() => gri.GetNumberOfPlayersRaffleEntry(DefID));
            ExecuteMe.Wait();
            lblRaffleInfo.Text = RaffleInfo.m_currentPlayerCount + " Player(s) Entered / " + RaffleInfo.m_playersReq.ToString() + " Player(s) Required";
            N_OfPlayersReqMet = DisableOrEnableRunRaffle();
            if (cmbxRaffle.SelectedIndex != -1 && N_OfPlayersReqMet == true) { btnRunRaffle.Enabled = true; } else { btnRunRaffle.Enabled = false; }
            this.Cursor = Cursors.Default;

        }

        private void loadListRaffle()
        {

            GetRafflePlayerDefinitions run = new GetRafflePlayerDefinitions();
            run.runGetRafflePlayerDefinitions();

            if (lstBxRafflePrizes2.Items.Count > 0)
            {
                lstBxRafflePrizes2.Items.Clear();
            }

            foreach (DataRafflePrizes drf in List_DataRafflePrize.LDataRafflePrize)
            {
                //lstBxRafflePrizes.Items.Add(drf.RaffleName);
                lstBxRafflePrizes2.Items.Add(drf.RaffleName);
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
            txtbxSetupName.Text = dataRafflePrize.RaffleName;
            txtbxSetupNumberofWinners.Text = dataRafflePrize.NoOfRafflePrize.ToString(); ;
            txtbxSetupPrizeDescription.Text = dataRafflePrize.RafflePrizeDescription;
            txtbxDisclaimer.Text = dataRafflePrize.RaffleDisclaimer;
        }


        private void isRaffleSettingModify()
        {
            if (isUpdate == true)
            {
                if (dataRafflePrize.RaffleName != txtbxSetupName.Text.ToString())
                {
                    isModify = true;

                }
                else
                    if (dataRafflePrize.NoOfRafflePrize != Convert.ToInt32(txtbxSetupNumberofWinners.Text))
                    {
                        isModify = true;
                    }
                    else

                        if (dataRafflePrize.RafflePrizeDescription != txtbxSetupPrizeDescription.Text.ToString())
                        {
                            isModify = true;
                        }
                        else
                            if (dataRafflePrize.RaffleDisclaimer != txtbxDisclaimer.Text.ToString())
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
            DataRafflePrizes drp = new DataRafflePrizes(); // RaffleDefinition rd = new RaffleDefinition();
            drp.RaffleID = saveorupdate;
            drp.RaffleName = txtbxSetupName.Text;
            drp.NoOfRafflePrize = Convert.ToInt32(txtbxSetupNumberofWinners.Text);
            drp.RafflePrizeDescription = txtbxSetupPrizeDescription.Text;
            drp.RaffleDisclaimer = txtbxDisclaimer.Text;
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
                    foreach (string rn in lstBxRafflePrizes2.Items)//Find if it exists
                    {
                        if (rn.Equals(NewRaffleName, StringComparison.InvariantCultureIgnoreCase))
                        {
                            errorProvider1.SetError(txtbxSetupName, "Raffle name already exists.");
                            e.Cancel = true;
                        }
                    }
                }
                else //delete or updarte
                {
                    if (isNew == false && isUpdate == true)//check if the new name already exists.
                    {
                        foreach (string rn in lstBxRafflePrizes2.Items)//Find if it exists
                        {
                            //find the index of each item
                            int findIndex = lstBxRafflePrizes2.Items.IndexOf(rn);

                            if (lstBxRafflePrizes2.SelectedIndex != findIndex)//exclude itself
                            {

                                if (rn.Equals(NewRaffleName, StringComparison.InvariantCultureIgnoreCase))
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

                DefID = IndexToDefID[cmbxPlayerList.SelectedIndex];
                loadRaffleInfo();

            }
            else
            {
                if (cmbxPlayerList.SelectedIndex == 0)
                {
                    DefID = 0;
                    loadRaffleInfo();
                    N_OfPlayersReqMet = DisableOrEnableRunRaffle();
                    if (cmbxRaffle.SelectedIndex != -1 && N_OfPlayersReqMet == true) { btnRunRaffle.Enabled = true; } else { btnRunRaffle.Enabled = false; }
                }
                else
                    if (cmbxPlayerList.SelectedIndex == -1)
                    {
                        lblRaffleInfo.Text = string.Empty;
                    }
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
        private void btnSetupCancel_Click(object sender, EventArgs e)
        {
            clearAllMessages();

            if (isNew == true)
            {

                clearAllContentsRaffleSettings();
                HandleControlsFromInsertUpdateDeleteCancelSaveClose(4);
            }
            else if (isUpdate == true)
            {
                //loadListRaffle();
                string tempRaffleName = dataRafflePrize.RaffleName;
                //  lstBxRafflePrizes.SelectedIndex = -1;
                lstBxRafflePrizes2.SelectedIndex = -1;
                // int tempIndex = lstBxRafflePrizes.Items.IndexOf(tempRaffleName);
                int tempIndex = lstBxRafflePrizes2.Items.IndexOf(tempRaffleName);
                //  lstBxRafflePrizes.SelectedIndex = tempIndex;
                lstBxRafflePrizes2.SelectedIndex = tempIndex;
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
                var Exists = ListPreviousWinner.data.Exists(l => l.RaffleID == dataRafflePrize.RaffleID);
                if (Exists == true)
                {
                    ListPreviousWinner.data.RemoveAll(l => l.RaffleID == dataRafflePrize.RaffleID);
                }
                if (cmbxRaffle.SelectedIndex != -1)
                {
                    if (cmbxRaffle.SelectedItem.ToString() == dataRafflePrize.RaffleName)
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

                SaveOrUpdateRaffleDefinitions(dataRafflePrize.RaffleID, true);
                loadListRaffle();
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


            //if (lstBxRafflePrizes.SelectedIndex != -1)
            if (lstBxRafflePrizes2.SelectedIndex != -1)
            {
                isNew = false;
                isUpdate = true;
                //dataRafflePrize = List_DataRafflePrize.LDataRafflePrize.Single(l => l.RaffleName == lstBxRafflePrizes.SelectedItem.ToString());
                dataRafflePrize = List_DataRafflePrize.LDataRafflePrize.Single(l => l.RaffleName == lstBxRafflePrizes2.SelectedItem.ToString());
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
            else
                if (Convert.ToInt32(tbctrlRafle.SelectedTab.Tag) == 2)//Raffle Tab
                {
                    loadcmbxRafle();
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
        /// Get the number of player in the player list per definition.
        /// </summary>
        private void GetTheNumberOfPlayerInTheRafflePerPlayerList()
        {

        }


        /// <summary>
        /// Select a available raffle.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmbxRaffle_SelectedIndexChanged(object sender, EventArgs e)
        {
            lstbxRaffleWinners2.Items.Clear();

            if (cmbxRaffle.SelectedIndex != -1)
            {
                dataRafflePrize = List_DataRafflePrize.LDataRafflePrize.Single(l => l.RaffleName == cmbxRaffle.SelectedItem.ToString());
                //if (cmbxPlayerList.SelectedIndex != -1)
                //{
                //    if (btnRunRaffle.Enabled != true) { btnRunRaffle.Enabled = true; }
                //}
                //else
                //{
                //    if (btnRunRaffle.Enabled != false) { btnRunRaffle.Enabled = false; }
                //}
            }
            else
            {
                if (btnRunRaffle.Enabled != false) { btnRunRaffle.Enabled = false; }
                return;
            }


            if (cmbxRaffle.SelectedIndex != -1 && cmbxPlayerList.SelectedIndex != -1)
            {
                //Check if the number of player is enough to win the raffle prize
                bool RunOk = DisableOrEnableRunRaffle();
                if (RunOk == false)
                {
                    return;
                }

                bool tempResult = doWeHaveEnoughPlayerToWinTheRafflePrize();
                if (tempResult == false)
                {
                    if (btnRunRaffle.Enabled != false) { btnRunRaffle.Enabled = false; return; }
                }
                else
                    if (tempResult == true)
                    {
                        if (btnRunRaffle.Enabled != true) { btnRunRaffle.Enabled = true; }
                    }

                //check if the selected raffle have previous winner 
                if (ListPreviousWinner.data.Count != 0)
                {

                    //check if it exists
                    var check = ListPreviousWinner.data.Exists(l => l.RaffleID == dataRafflePrize.RaffleID);
                    if (check == true)
                    {
                        string messagetext = "";
                        if (ListPreviousWinner.data[cmbxRaffle.SelectedIndex].WinnerPlayerID.Count > 1)//ERROR
                        {
                            messagetext = "Previous Winners";
                        }
                        else
                        {
                            messagetext = "Previous Winner";
                        }
                        label6.Text = messagetext;

                        DataPreviousWinner dpw = ListPreviousWinner.data.Single(l => l.RaffleID == dataRafflePrize.RaffleID);//This will commit an error if it did not found.
                        if (!string.IsNullOrEmpty(dpw.RaffleName))
                        {
                            int count = 0;
                            foreach (int id in dpw.WinnerPlayerID)
                            {
                                lstbxRaffleWinners2.Items.Add((count + 1).ToString() + ". " + dpw.WinnerPlayerFName[count].ToString() + " " + dpw.WinnerPlayerLName[count].ToString());
                                count = count + 1;
                            }
                        }
                    }
                    else
                    {
                        label6.Text = "Winners";
                    }
                    //}
                }
                else
                {
                    label6.Text = "Winners";
                }
            }
            else if (cmbxRaffle.SelectedIndex != -1)
            {
                //check if the selected raffle have previous winner 
                if (ListPreviousWinner.data.Count != 0)
                {
                    //check if it exists
                    var check = ListPreviousWinner.data.Exists(l => l.RaffleID == dataRafflePrize.RaffleID);
                    if (check == true)
                    {
                        string messagetext = "";
                        if (ListPreviousWinner.data[cmbxRaffle.SelectedIndex].WinnerPlayerID.Count > 1)//ERROR
                        {
                            messagetext = "Previous Winners";
                        }
                        else
                        {
                            messagetext = "Previous Winner";
                        }
                        label6.Text = messagetext;

                        DataPreviousWinner dpw = ListPreviousWinner.data.Single(l => l.RaffleID == dataRafflePrize.RaffleID);//This will commit an error if it did not found.
                        if (!string.IsNullOrEmpty(dpw.RaffleName))
                        {
                            int count = 0;
                            foreach (int id in dpw.WinnerPlayerID)
                            {
                                lstbxRaffleWinners2.Items.Add((count + 1).ToString() + ". " + dpw.WinnerPlayerFName[count].ToString() + " " + dpw.WinnerPlayerLName[count].ToString());
                                count = count + 1;
                            }
                        }
                    }
                    else
                    {
                        label6.Text = "Winners";
                    }
                }
                else
                {
                    label6.Text = "Winners";
                }
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
                    SaveOrUpdateRaffleDefinitions(dataRafflePrize.RaffleID, false);

                }
                else
                {

                }
            }

            if (isNew == true || isModify == true)
            {

                loadListRaffle();

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

            if (dataRafflePrize.NoOfRafflePrize > 1) { label6.Text = "Winners"; } else { label6.Text = "Winner"; }

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

            raffleWinner = new RaffleWinner();//Winner should be clear in runnning a new raffle.
            Cursor.Current = Cursors.WaitCursor;

            for (int startcount = 0; startcount < dataRafflePrize.NoOfRafflePrize; startcount++)
            {
                int tempRaffleHistory = 0; //check if the raffleHistory already exists if not then set to 0 = new;
                tempRaffleHistory = (raffleWinner.HistoryID == null) ? 0 : raffleWinner.HistoryID;

                raffleWinner = RunPlayerRaffleMessage.GetRaffleWinner(dataRafflePrize.RaffleID, tempRaffleHistory, DefID);   //Raffle winner here //What raffle is being run and is PlayerHistory = 0; //How to change the value from the existing raffleHistoryID
                raffleWinners.Add(raffleWinner);
                if (String.IsNullOrWhiteSpace(raffleWinner.FirstName) && String.IsNullOrWhiteSpace(raffleWinner.LastName))
                    lstbxRaffleWinners2.Items.Add((startcount + 1).ToString() + ". " + raffleWinner.PlayerID.ToString());
                else
                    lstbxRaffleWinners2.Items.Add((startcount + 1).ToString() + ". " + raffleWinner.FirstName + " " + raffleWinner.LastName);

                getVouchersInfo(raffleWinner.PlayerID);
                RaffleReceipt raffleReceipt = new RaffleReceipt();
                AssignValueToReceipt(raffleReceipt, startcount);

                lstbxRaffleWinners2.SelectedIndex = startcount;
                lstbxRaffleWinners2.SetSelected(startcount, false);

                if (CheckForReceiptPrinter())
                {
                    raffleReceipt.Print(globalPrinter, 1);//Just print one copy  //Print the winners vouchers
                }

                if (delaytime > 1 && startcount + 1 < dataRafflePrize.NoOfRafflePrize) // if there is another winner after this one, we should delay.
                    System.Threading.Thread.Sleep(((delaytime -1) * 1000)); // note: takes over a second between winners without a delay
            }

            btnRunRaffle.Enabled = true;
            btnRaffleClose.Enabled = true;
            btnClearRaffle.Enabled = true;
            btnRaffleReprintVoucher.Enabled = true;
            Cursor.Current = Cursors.Default;

            //save to datapreviouswinner
            if (ListPreviousWinner.data.Count != 0)
            {
                var isRaffleExists = ListPreviousWinner.data.Exists(l => l.RaffleID == dataRafflePrize.RaffleID);       //check if the raffleName alrady exists
                if (isRaffleExists == true)
                {
                    //delete it 
                    ListPreviousWinner.data.RemoveAll(l => l.RaffleID == dataRafflePrize.RaffleID);

                }
            }


            DataPreviousWinner dpw = new DataPreviousWinner();
            dpw.RaffleID = dataRafflePrize.RaffleID;
            dpw.RaffleName = dataRafflePrize.RaffleName;

            foreach (RaffleWinner rw in raffleWinners)
            {
                dpw.WinnerPlayerID.Add(rw.PlayerID);
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

            DataPreviousWinner RafflePreviousWinner = ListPreviousWinner.data.Single(l => l.RaffleID == dataRafflePrize.RaffleID);

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
