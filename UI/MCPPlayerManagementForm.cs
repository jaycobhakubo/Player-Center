#region Copyright
// This is an unpublished work protected under the copyright laws of the
// United States and other countries.  All rights reserved.  Should
// publication occur the following will apply:  © 2008 GameTech
// International, Inc.
#endregion

using System;
using System.Collections.Generic;
using System.Threading;
using System.Drawing;
using System.Web.UI.WebControls;
using System.Windows.Forms;
using System.Reflection;
using GTI.Modules.PlayerCenter.Data;
using GTI.Modules.Shared;
using GTI.Modules.PlayerCenter.Business;
using GTI.Modules.PlayerCenter.Properties;

namespace GTI.Modules.PlayerCenter.UI
{
    /// <summary>
    /// The form that allows the adding and editing of players.
    /// </summary>
    public partial class MCPPlayerManagementForm : GradientForm
    {
        #region Member Variables

        private readonly DateTime limitedBirthDate = new DateTime(1900, 1, 1);
        protected object m_lastFocus;
        protected bool m_dataChanged;
        protected Player m_player = new Player();
        protected Player m_playerToSet;
        protected List<PlayerStatus> m_playerStatusList;//RALLY DE8358
        protected bool m_playersSaved;
        protected byte[] m_pinNumber = new byte[DataSizes.PasswordHash]; // FIX: DE3134 - PIN required and a new player error.

        protected bool mbolCreditOnline = true;
      //  private clsUSB mobjUSB = null;

        private PlayerManager m_parent;

        private string mstrComments = String.Empty;
        //private bool mbolClickComment;

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the PlayerManagementForm class.
        /// </summary>
        /// <param name="parent">The PlayerManager to which this form 
        /// belongs.</param>
        public MCPPlayerManagementForm(PlayerManager parent)
        {
            try
            {
                m_parent = parent;
                InitializeComponent();
                commentsGroupBox.DoubleClick += CommentsGroupBoxDoubleClick;
                //ApplyDisplayMode();
                SetMaxTextLengths();

                m_playerStatusList = new List<PlayerStatus>();//RALLY DE8358

                // Rally TA7897
                mbolCreditOnline = parent.Settings.CreditEnabled;

                //   Set the labels and textboxes for credit
                // visisble (T or F) properties.
                SetCreditControls();

                // Set the last focused control to the first field.
                m_lastFocus = txtFirstName;

                LoadOperatorPlayerStatusCodes();

                LoadGenders(); // FIX: DE1891

                // Do they have a player already selected?
                if (m_parent.CurrentPlayer != null)
                {
                    m_player = m_parent.CurrentPlayer;

                    // Fill in the default player values.
                    SetPlayerValues(false);//RALLY DE8358
                }

                personalInfoGroupBox.Text = "Personal Information";

                // Reset the data changed value.
                m_dataChanged = false;

                ChkSystemCamera();
                AddToolStripMenuItem();
            }
            catch (Exception)
            {
                MessageForm.Show("Player Management initializing error ");
                return;
            }
        }

        #region Operator and Player Status methods


        private void AddToolStripMenuItem()
        {
            if (m_parent.Settings.RaffleRunLocation == 2)
            {
                //get the system settings 
                string DisplayText = (m_parent.Settings.RaffleDrawingSetting == 2) ? "Drawing..." : "Raffle...";
                string NewItem = "Player " + DisplayText;  //"Raffle"; //This will be change base on system setting Raffle or Drawing lets use Raffle for now
                ToolStripItem RaffleToolStripMenuItem = new ToolStripMenuItem();
                RaffleToolStripMenuItem.Text = NewItem;
                RaffleToolStripMenuItem.Click += new EventHandler(RaffleToolStripMenuItem_Click);
                viewToolStripMenuItem.DropDownItems.Add(RaffleToolStripMenuItem);
            }
        }
    
        private void RaffleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Raffle RaffleForm = new Raffle();
            RaffleForm.Show(this);       
        }


        /// <summary>
        /// Loads the ActiveStatus listview with currently active OperatorPlayer statuses
        /// </summary>
        private void LoadOperatorPlayerStatusCodes()
        {
            // Load all operator player status values into listbox, 
            lvActiveStatus.Items.Clear();
            foreach (PlayerStatus status in PlayerManager.OperatorPlayerStatusList)
            {
                if (status.IsActive)
                {
                    ListViewItem lvi = new ListViewItem(status.Name) { Tag = status };
                    lvActiveStatus.Items.Add(lvi);
                }
            }

            lvActiveStatus.Sort();
        }

        // FIX: DE1891
        /// <summary>
        /// Loads the gender list box.
        /// </summary>
        private void LoadGenders()
        {
            m_genderList.Items.Clear();
            
            m_genderList.Items.Add(string.Empty);
            m_genderList.Items.Add(Resources.GenderMale);
            m_genderList.Items.Add(Resources.GenderFemale);

            m_genderList.SelectedIndex = 0;
        }
        // END: DE1891

        // FIX: TA4069
        /// <summary>
        /// Sets the current players active status values to the 
        /// values selected in the listview.
        /// </summary>
        private void GetPlayerStatusFromListBox()
        {
            m_player.ActiveStatusList.Clear();

            foreach(ListViewItem item in lvActiveStatus.Items)
            {
                if(item.Checked)
                {
                    foreach(PlayerStatus status in PlayerManager.OperatorPlayerStatusList)
                    {
                        if(status.Id == ((PlayerStatus)item.Tag).Id)
                        {
                            m_player.ActiveStatusList.Add(status);
                            break;
                        }
                    }
                }
            }
        }

        private bool listViewSetup;
        /// <summary>
        /// Selects the player status values in the listview that are in
        /// the current players list.
        /// </summary>
        private void SelectPlayersStatusInListBox()
        {
            listViewSetup = true;
            m_playerStatusList.Clear();//RALLY DE8358

            foreach(ListViewItem item in lvActiveStatus.Items)
            {
                item.Checked = false;
            }

            if(m_player.Id > 0)
            {
                foreach(PlayerStatus status in m_player.ActiveStatusList)
                {
                    foreach(ListViewItem item in lvActiveStatus.Items)
                    {
                        if(status.Id == ((PlayerStatus)item.Tag).Id)
                        {
                            item.Checked = true;
                            m_playerStatusList.Add(status);//RALLY DE8358
                        }
                    }
                }
            }

            listViewSetup = false;
        }
        // END: TA4069

        //START RALLY DE8358
        /// <summary>
        /// Selects the player status from the local list instead of the player list
        /// </summary>
        private void SelectPlayerStatusFromList()
        {
            listViewSetup = true;
           

            foreach (ListViewItem item in lvActiveStatus.Items)
            {
                item.Checked = false;
            }

            if (m_player.Id > 0)
            {
                foreach (PlayerStatus status in m_playerStatusList)
                {
                    foreach (ListViewItem item in lvActiveStatus.Items)
                    {
                        if (status.Id == ((PlayerStatus)item.Tag).Id)
                        {
                            item.Checked = true;
                        }
                    }
                }
            }

            listViewSetup = false;
        }
        //END RALLY DE8358
        private void lvActiveStatus_ItemSelectionChanged(object sender, ListViewItemSelectionChangedEventArgs e)
        {
            if (!listViewSetup)
                GetPlayerStatusFromListBox();
        }

        private void playerStatusToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ActiveStatusEditor editor = new ActiveStatusEditor(PlayerManager.OperatorID);
            if (editor.ShowDialog() == DialogResult.OK)
            {
                // The editor must have already reloaded the OperatorPlayerStatusList
                LoadOperatorPlayerStatusCodes();
                SelectPlayersStatusInListBox();
            }
        }

        #endregion

        private void SetCreditControls()
        {
            lock (this)
            {
                try
                {
                    /*     Set properties on Credit specfic controls
                     *     Also set the form BackGround Image    
                     */
                    // FIX: DE6690
                    m_credits.Text = "";
                    m_creditNonRef.Text = "";

                    if (mbolCreditOnline)
                    {
                        lblCredits.Visible = true;
                        lblCreditsNonRef.Visible = true;
                        m_credits.Visible = true;
                        m_creditNonRef.Visible = true;
                    }
                    else
                    {
                        lblCredits.Visible = false;
                        lblCreditsNonRef.Visible = false;
                        m_credits.Visible = false;
                        m_creditNonRef.Visible = false;
                    }
                    // END: DE6690
                    Application.DoEvents();
                }
                catch (Exception ex)
                {
                    throw new Exception("SetCreditControls()...Exception: " + ex.Message);
                }
            }
        }

        #endregion

        #region Events
        /// <summary>
        /// Handles when the focus changes on a form.
        /// </summary>
        /// <param name="sender">The sender of the event.</param>
        /// <param name="e">An EventArgs object that contains the 
        /// event data.</param>
        private void FocusChanged(object sender, EventArgs e)
        {
            m_lastFocus = sender;
        }

        /// <summary>
        /// Handles the find player button click.
        /// </summary>
        /// <param name="sender">The sender of the event.</param>
        /// <param name="e">An EventArgs object that contains the 
        /// event data.</param>
        private void FindPlayerClick(object sender, EventArgs e)
        {
            personalInfoGroupBox.Text = "Personal Information";

            if (ChkDataChange())
            {
                MCPFindPlayerForm findForm = new MCPFindPlayerForm(m_parent);

                Application.DoEvents();

                if (findForm.ShowDialog(this) == DialogResult.OK)
                {
                    Application.DoEvents();
                    m_player = findForm.SelectedPlayer;
                    SetPlayerValues(false);//RALLY DE8358
                    m_dataChanged = false;

                    if (m_player != null)
                    {
                        if (!m_isManualAwardPointsEnable)
                        ShowManualAwardPointsButton(true);
                    }

                }
            }

            GC.Collect(); // DE2476 - Try to clean up memory after a player is saved and reloaded.
        }


       // US2100/TA15670
        private bool m_isManualAwardPointsEnable = false;

        private void ShowManualAwardPointsButton(bool isManualAwardPointsEnable)
        {
            m_isManualAwardPointsEnable = isManualAwardPointsEnable;
            if (isManualAwardPointsEnable)
            {
                groupBox1.Size = new Size(331, 274);
                groupBox1.Location = new Point(35, 30);
                m_playerPicture.Size = new Size(320, 247);
                m_noPic.Size = m_playerPicture.Size;
                m_playerPicture.Location = new Point(5, 21);
                m_noPic.Location = m_playerPicture.Location;
                m_btnImgAwardPointManual.Visible = true;
                m_btnImgAwardPointManual.BringToFront();
            }
            else
            {
                groupBox1.Size = new Size(331, 333);
                groupBox1.Location = new Point(35, 30);
                m_playerPicture.Size = new Size(320, 240);
                m_noPic.Size = m_playerPicture.Size;
                m_playerPicture.Location = new Point(6, 44);
                m_noPic.Location = m_playerPicture.Location;
                m_btnImgAwardPointManual.Visible = false;
                m_btnImgAwardPointManual.SendToBack();
            }
        }

        // US2100/TA15670
        private void HideManualAwardPointsButton()
        {
            groupBox1.Size = new Size(331, 333);
            groupBox1.Location = new Point(35, 30);
            m_playerPicture.Size = new Size(320, 240);
            m_noPic.Size = m_playerPicture.Size;
            m_playerPicture.Location = new Point(6, 44);
            m_noPic.Location = m_playerPicture.Location;
            m_btnImgAwardPointManual.Visible = false;
            m_btnImgAwardPointManual.SendToBack();
        }

        /// <summary>
        /// Handles the new player button click and clears out
        /// the current player.
        /// </summary>
        /// <param name="sender">The sender of the event.</param>
        /// <param name="e">An EventArgs object that contains the 
        /// event data.</param>
        private void NewPlayerClick(object sender, EventArgs e)
        {
            if (ChkDataChange())
            {
                m_player = new Player();
                SetPlayerValues(false);//RALLY DE8358
                m_dataChanged = false;
                txtFirstName.Focus();
                personalInfoGroupBox.Text = "Personal Information - Add New";
               if (m_isManualAwardPointsEnable) ShowManualAwardPointsButton(false);
                Application.DoEvents();
            }

            GC.Collect(); // DE2476
        }

        /// <summary>
        /// Handles the assign card button click and prompts 
        /// for a card.
        /// </summary>
        /// <param name="sender">The sender of the event.</param>
        /// <param name="e">An EventArgs object that contains the 
        /// event data.</param>
        private void AssignCardClick(object sender, EventArgs e)
        {
            personalInfoGroupBox.Text = "Personal Information";
            // PDTS 1064
            MagCardForm magForm = new MagCardForm(m_parent.MagCardReader);

            Application.DoEvents();
            if (magForm.ShowDialog() == DialogResult.OK)
            {
                Application.DoEvents();
//                m_magCardNum.Text = magForm.MagCardNumber; // FIX: DE6690
                txtMagCard.Text = magForm.MagCardNumber;
                m_dataChanged = true;
            }
        }

        /// <summary>
        /// Handles the take picture button click.
        /// </summary>
        /// <param name="sender">The sender of the event.</param>
        /// <param name="e">An EventArgs object that contains the 
        /// event data.</param>
        private void TakePictureClick(object sender, EventArgs e)
        {            
            Thread picThread = new Thread(m_parent.ShowPictureCapture);
            picThread.SetApartmentState(ApartmentState.STA);
            picThread.Start();

            personalInfoGroupBox.Text = "Personal Information";

            EventWaitHandle waitHandle = new EventWaitHandle(false, EventResetMode.AutoReset, "Player Picture Wait Handle");
            waitHandle.WaitOne();
            
            try
            {
                Application.DoEvents();
                if (m_parent.LastPlayerPic != null)
                {
                    m_playerPicture.Image = m_parent.LastPlayerPic;

                    if (m_playerPicture.Image == null)
                    {
                        m_playerPicture.Visible = false;
                        m_noPic.Visible = true;
                    }
                    else
                    {
                        m_playerPicture.Visible = true;
                        m_noPic.Visible = false;
                    }

                    m_dataChanged = true;
                }
            }
            catch (Exception ex)
            {
                MessageForm.Show(string.Format(Resources.LoadPictureFailed, ex.Message));
            }
        }

        /// <summary>
        /// Handles the take pin button click.
        /// </summary>
        /// <param name="sender">The sender of the event.</param>
        /// <param name="e">An EventArgs object that contains the 
        /// event data.</param>
        private void takePINImageButton_Click(object sender, EventArgs e)
        {
            TakePIN pinform = new TakePIN();
            Application.DoEvents();
            pinform.ShowDialog();
            Application.DoEvents();
            m_pinNumber = SecurityHelper.HashPassword(pinform.PIN.ToString()); // Rally TA1583, RALLY US1955
        }

        private string GetPlayerName()
        {
            var FullName = "";
            if (m_player != null)
            {
                FullName = m_player.FirstName + " " + m_player.MiddleInitial + " " + m_player.LastName;
            }
            return FullName;
        }

        private void AwardPointsImageButton_Click(object sender, EventArgs e)
        {
      
            AwardPoints pinform = new AwardPoints(GetPlayerName());
            Application.DoEvents();
            pinform.ShowDialog();
            Application.DoEvents();
           // m_pinNumber = SecurityHelper.HashPassword(pinform.PIN.ToString()); // Rally TA1583, RALLY US1955
        }

        /// <summary>
        /// Handles the save changes button click.
        /// </summary>
        /// <param name="sender">The sender of the event.</param>
        /// <param name="e">An EventArgs object that contains the 
        /// event data.</param>
        private void SaveChangesClick(object sender, EventArgs e)//lnc
        {
            if (ValidateData())
            {
                Application.DoEvents();
                // Get the player's values from the UI.
                GetPlayerValues();
                Application.DoEvents();
                // If this player is new, make the join date right now.
                if (m_player.Id == 0)
                    m_player.JoinDate = DateTime.Now;

                // Spawn a new thread to save the player and wait until done.
                // FIX: DE2476
                Application.DoEvents();

                // save teh active status list for the current player
                //SetPlayerStatusCode.Save(PlayerManager.OperatorID, m_player.Id, m_player.ActiveStatusList);

                m_parent.SavePlayer(m_player);
                m_parent.ShowWaitForm(this); // Block until we are done.
                // END: DE2476
                Application.DoEvents();

                if (m_parent.LastAsyncException != null)
                {
                    if (m_parent.LastAsyncException is ServerCommException)
                    {
                        m_parent.ServerCommFailed();
                    }
                    else if (m_parent.LastAsyncException is DuplicateException)
                    {
                        MessageForm.Show(Resources.errorDupMagCard, Resources.PlayerCenterName);
                        Application.DoEvents();
                    }
                    else
                    {
                        MessageForm.Show(m_parent.LastAsyncException.Message);
                        Application.DoEvents();
                    }
                }
                else
                {
                    m_player = m_parent.LastPlayerFromServer; // TTP 50067

                    // Set the saved player's values back to the UI.
                    SetPlayerValues(false);//RALLY DE8358
                    Application.DoEvents();
                    m_dataChanged = false;
                    m_playersSaved = true;
                    if (!m_isManualAwardPointsEnable) ShowManualAwardPointsButton(true);
                    MessageForm.Show(Resources.infoSaveSuccessed, Resources.PlayerCenterName);
                }
                personalInfoGroupBox.Text = "Personal Information";

                GC.Collect(); // DE2476
            }
        }

        /// <summary>
        /// Handles the cancel changes button click and restores
        /// the original values of the player to the UI.
        /// </summary>
        /// <param name="sender">The sender of the event.</param>
        /// <param name="e">An EventArgs object that contains the 
        /// event data.</param>
        private void CancelChangesClick(object sender, EventArgs e)
        {
            personalInfoGroupBox.Text = "Personal Information";
           
            if (ChkDataChange())
            {
                Application.DoEvents();

                SetPlayerValues(true);//RALLY DE8358
                m_dataChanged = false;
            }

            GC.Collect(); // DE2476
        }

        ///// <summary>
        ///// Handles the set as current player button click and
        ///// sets the POS's player.
        ///// </summary>
        ///// <param name="sender">The sender of the event.</param>
        ///// <param name="e">An EventArgs object that contains the 
        ///// event data.</param>
        //private void SetAsCurrentPlayerClick(object sender, EventArgs e)
        //{
        //    if (m_player.Id > 0)
        //    {
        //        if (ChkDataChange())
        //        {
        //            m_playerToSet = m_player;
        //            Close();
        //        }
        //    }
        //    else
        //    {
        //        MessageForm.Show(Resources.NoPlayer, Resources.PlayerCenterName);
        //    }
        //}

        ///// <summary>
        ///// Handles the exit button click and closes the form.
        ///// </summary>
        ///// <param name="sender">The sender of the event.</param>
        ///// <param name="e">An EventArgs object that contains the 
        ///// event data.</param>
        //private void ExitClick(object sender, EventArgs e)
        //{

        //    if (ChkDataChange())
        //    {
        //        m_playerToSet = null;
        //        Close();
        //    }
        //}

        ///// <summary>
        ///// Handles when a key on the virtual keyboard is clicked.
        ///// </summary>
        ///// <param name="sender">The sender of the event.</param>
        ///// <param name="e">A KeyboardEventArgs object that contains the 
        ///// event data.</param>
        //private void KeyboardKeyPressed(object sender, KeyboardEventArgs e)
        //{
        //    //if(m_lastFocus is Control && (m_lastFocus != m_virtualKeyboard))
        //    //{
        //    //    ((Control)m_lastFocus).Focus();
        //    //    SendKeys.Send(e.KeyPressed);
        //    //}
        //}

        /// <summary>
        /// Handles when the player data has changed.
        /// </summary>
        /// <param name="sender">The sender of the event.</param>
        /// <param name="e">A EventArgs object that contains the 
        /// event data.</param>
        private void PlayerDataChanged(object sender, EventArgs e)
        {
            Control ctl = (Control)sender;

            m_dataChanged = true;
        }

      

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AboutBox about = new AboutBox
                        {
                            AssemblyDescription = Resources.ModuleDescription,
                            AssemblyProduct = AssemblyProduct,
                            AssemblyVersion = AssemblyVersion,
                            AssemblyTitle = AssemblyTitle
                        };
            about.ShowDialog();
        }

        // PDTS 312
        private void playerListToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PlayerListForm listForm = new PlayerListForm(m_parent);
            listForm.ShowDialog(this);

            if(m_parent.LastAsyncException is ServerCommException)
                m_parent.ServerCommFailed();
        }

        private void CommentsGroupBoxDoubleClick(object sender, EventArgs e)
        {
            try
            {
                //if (mobjUSB != null)
                //{
                //    if (!mbolClickComment)
                //    {
                //        mstrComments = this.txtComments.Text;
                //        this.txtComments.Text = mobjUSB.ToString();
                //        this.txtComments.Text += mobjUSB.ErrorMsg;
                //        mbolClickComment = true;
                //    }
                //    else
                //    {
                //        this.txtComments.Text = mstrComments;
                //        mstrComments = "";
                //        mbolClickComment = false;
                //    }
                //}
            }
            catch (Exception ex)
            {
                MessageForm.Show("CommentsGroupBoxDoubleClick()...Exception: " + ex.Message, Resources.PlayerCenterName);
            }
            finally
            {
                m_dataChanged = false;
            }
        }

        private bool ChkDataChange()
        {
            if (m_dataChanged)
            {
                return MessageForm.Show(Resources.Changes, Resources.PlayerCenterName, MessageFormTypes.YesNo) == DialogResult.Yes;
            }
            return true;
        }
        #endregion

        #region Member Methods
     
        // 1-24-2008 JW: I removed old code here while doing "house cleaning" duties. 
        // I saved it in a text file. PlayerCenter.MCPPlayerForm.ApplyDisplayMode.txt

        /// <summary>
        /// Sets the MaxLength property of all the text boxes based on
        /// the Set Player Data server message.
        /// </summary>
        protected void SetMaxTextLengths()
        {
            txtFirstName.MaxLength = StringSizes.MaxNameLength;
            txtMiddleInitial.MaxLength = StringSizes.MaxMiddleNameLength;
            txtLastName.MaxLength = StringSizes.MaxNameLength;
            txtSocialSecurityNum.MaxLength = StringSizes.MaxGovIssuedIdNumLength;
            txtBirthDate.MaxLength = StringSizes.MaxDateLength;
            txtEmail.MaxLength = StringSizes.MaxEmailLength;
            txtPlayerIdent.MaxLength = StringSizes.MaxPlayerIdentLength;
            txtPhoneNum.MaxLength = StringSizes.MaxPhoneNumberLength;
            txtAddress1.MaxLength = StringSizes.MaxAddressLength;
            txtAddress2.MaxLength = StringSizes.MaxAddressLength;
            txCity.MaxLength = StringSizes.MaxCityStateZipCountryLength;
            txtState.MaxLength = StringSizes.MaxCityStateZipCountryLength;
            txtZipCode.MaxLength = StringSizes.MaxCityStateZipCountryLength;
            txtCountry.MaxLength = StringSizes.MaxCityStateZipCountryLength;
            txtComments.MaxLength = StringSizes.MaxPlayerCommentLength;
        }

        /// <summary>
        /// Sets the player's values in the UI.
        /// </summary>
        protected void SetPlayerValues(bool canceled)//RALLY DE8358
        {
            personalInfoGroupBox.Text = "Personal Information";
            m_playerId.Text = m_player.Id.ToString();
            txtFirstName.Text = m_player.FirstName;
            txtMiddleInitial.Text = m_player.MiddleInitial;
            txtLastName.Text = m_player.LastName;
            txtSocialSecurityNum.Text = m_player.GovIssuedIdNumber;

            txtBirthDate.Text = m_player.BirthDate != DateTime.MinValue ? m_player.BirthDate.ToShortDateString() : string.Empty;

            txtEmail.Text = m_player.Email;
            txtPlayerIdent.Text = m_player.PlayerIdentity;
            txtPhoneNum.Text = m_player.PhoneNumber;

            // FIX: DE1891
            m_genderList.SelectedIndex = 0;

            int index = m_genderList.FindStringExact(m_player.Gender);

            if(index > -1)
                m_genderList.SelectedIndex = index;
            // END: DE1891
             
            /*  Is Player PIN is Read Only. Not displayed on this form? */              
            m_pinNumber = m_player.PinNumber;            

            txtAddress1.Text = m_player.Address1;
            txtAddress2.Text = m_player.Address2;
            txCity.Text = m_player.City;
            txtState.Text = m_player.State;
            txtZipCode.Text = m_player.Zip;
            txtCountry.Text = m_player.Country;

            m_joinDate.Text = m_player.JoinDate != DateTime.MinValue ? m_player.JoinDate.ToShortDateString() : string.Empty;

            m_lastVisit.Text = m_player.LastVisit != DateTime.MinValue ? m_player.LastVisit.ToShortDateString() : string.Empty;

            m_pointsBalance.Text = m_player.PointsBalance.ToString("N");
            m_visitCount.Text = m_player.VisitCount.ToString();
            // FIX: DE6690
//            m_magCardNum.Text = m_player.MagneticCardNumber;
            txtMagCard.Text = m_player.MagneticCardNumber;
            txtComments.Text = m_player.Comment;

            if (m_player.IsCreditOnline)
            {
                // Rally DE1890 - Credits and NR Credits have $ which is inconsistent with the rest of the screen.
                m_credits.Text = String.Format("{0:N}", m_player.RefundableCredit);
                m_creditNonRef.Text = String.Format("{0:N}", m_player.NonRefundableCredit);
            }
            else
            {
                m_credits.Text = String.Empty;
                m_creditNonRef.Text = String.Empty;
            }
            // END: DE6690

            m_playerTier.Text = m_player.LoyaltyTier != null ? m_player.LoyaltyTier.Name : string.Empty;

            m_playerPicture.Image = m_player.Image;

            if(m_playerPicture.Image == null)
            {
                m_playerPicture.Visible = false;
                m_noPic.Visible = true;
            }
            else
            {
                m_playerPicture.Visible = true;
                m_noPic.Visible = false;
            }

            m_SpendDataImageLabel.Text = m_player.TotalSpend.ToString("N"); // FIX: DE3341
            m_IsLogInStatusImageLabel.Text = m_player.IsLoggedIn ? Resources.Yes : Resources.No;
            lstReceiptNumber.Items.Clear();
            if (m_player.ReceiptNumbers != null)
            {
                for (int iReceipt = 0; iReceipt < m_player.ReceiptNumbers.Length; iReceipt++)
                {
                    lstReceiptNumber.Items.Add(m_player.ReceiptNumbers[iReceipt]);
                }
                //alway select the first one
                //m_ReceiptNumberColorListBox.SelectedIndex = 0;
            }

            //START RALLY DE8358
            if (canceled)
            {
                SelectPlayerStatusFromList();
            }
            else
            {
                SelectPlayersStatusInListBox();
            }
            //END RALLY DE8358
        }

        /// <summary>
        /// Gets the player values from the UI.
        /// </summary>
        protected void GetPlayerValues()
        {
            personalInfoGroupBox.Text = "Personal Information";
            m_player.FirstName = txtFirstName.Text.Trim();
            m_player.MiddleInitial = txtMiddleInitial.Text.Trim();
            m_player.LastName = txtLastName.Text.Trim();
            m_player.GovIssuedIdNumber = txtSocialSecurityNum.Text.Trim();

            try
            {
                m_player.BirthDate = DateTime.Parse(txtBirthDate.Text.Trim());
            }
            catch(FormatException)
            {
                m_player.BirthDate = DateTime.MinValue;
            }

            m_player.Email = txtEmail.Text.Trim();
            m_player.PlayerIdentity = txtPlayerIdent.Text.Trim();
            m_player.PhoneNumber = txtPhoneNum.Text.Trim();

            // FIX: DE1891
            if(m_genderList.SelectedIndex > -1)
                m_player.Gender = (string)m_genderList.SelectedItem;
            // END: DE1891

            // Is Player PIN is Read Only on this form? 
            m_player.PinNumber = m_pinNumber; // m_pinNum.Text.Trim();

            m_player.Address1 = txtAddress1.Text.Trim();
            m_player.Address2 = txtAddress2.Text.Trim();
            m_player.City = txCity.Text.Trim();
            m_player.State = txtState.Text.Trim();
            m_player.Zip = txtZipCode.Text.Trim();
            m_player.Country = txtCountry.Text.Trim();
//            m_player.MagneticCardNumber = m_magCardNum.Text; // FIX: DE6690
            m_player.MagneticCardNumber = txtMagCard.Text.Trim();

            //this.txtCredits.Text = String.Format("{0:C}", m_player.RefundableCredit);
            //this.txtCreditNonRef.Text = String.Format("{0:C}", m_player.NonRefundableCredit);


            m_player.Comment = txtComments.Text.Trim().Length <= StringSizes.MaxPlayerCommentLength ? txtComments.Text.Trim() : txtComments.Text.Trim().Substring(0, StringSizes.MaxPlayerCommentLength);

            if(m_playerPicture.Image != null)
                m_player.Image = (Bitmap)m_playerPicture.Image;
            else
                m_player.Image = null;

            GetPlayerStatusFromListBox();
        }

        /// <summary>
        /// Checks all data entered by the user for validity.  Will display
        /// messages about invalid data.
        /// </summary>
        /// <returns>true if all data is valid; otherwise false.</returns>
        protected bool ValidateData()
        {
            bool valid = true;

            // Check to make sure they have a mag. card number or last name.
            if(txtLastName.Text.Trim() == string.Empty && txtMagCard.Text.Trim() == string.Empty/*m_magCardNum.Text.Trim() == string.Empty*/) // FIX: DE6690
            {
                MessageForm.Show(Resources.NoNameOrCard, Resources.PlayerCenterName);
                valid = false;
            }

            // Check the birth date.
            if(txtBirthDate.Text.Trim() != string.Empty)
            {
                DateTime temp;
                try
                {
                    temp = DateTime.Parse(txtBirthDate.Text);
                    if (temp.CompareTo(limitedBirthDate) < 0)
                    {
                        throw new Exception(Resources.warningBirthDate);
                    }
                }
                catch (Exception)
                {
                    MessageForm.Show(Resources.InvalidBirthDate, Resources.PlayerCenterName);
                    valid = false;
                }
            }

            // Ensure pin is set when required
            if (m_parent.Settings.PinRequired)
            {
                byte bb = 0;
                foreach (byte b in m_pinNumber)
                    bb |= b;

                if (bb == 0)
                {
                    MessageForm.Show(Resources.PinRequired, Resources.PlayerCenterName);
                    valid = false;
                }
            }

            if (txtCountry.Text != "" )
            {
                if (txtCountry.Text.Trim().ToUpper() == "USA" || txtCountry.Text.Trim().ToUpper() == "UNITED STATES" || txtCountry.Text.Trim().ToUpper() == "US")
                {
                    txtCountry.Text = "USA";
                }
            }
            return valid;
        }

        private void ChkSystemCamera()
        {
            try
            {
                //mobjUSB = new clsUSB();
                //mobjUSB.Load();

                //while (mobjUSB.pIsLoading)
                //{
                //    Thread.Sleep(200);
                //    Application.DoEvents();
                //}

                //if (!mobjUSB.pHasCamera)
                //{
                //    this.m_takePictureButton.Enabled = false;
                //    txtComments.Text = "No camera installed.";
                //}               
            }
            catch (Exception ex)
            {
                MessageForm.Show("ChkSystemCamera()...Exception: " + ex.Message, Resources.PlayerCenterName);
            }
            finally
            {
                m_dataChanged = false;
            }
        }
       
        #endregion

        #region Member Properties
        /// <summary>
        /// Gets whether the user saved one or more players to the server while 
        /// the dialog was open.
        /// </summary>
        public bool PlayersSaved
        {
            get
            {
                return m_playersSaved;
            }
        }

        /// <summary>
        /// Enables or disables the Set As Current Player button.
        /// </summary>
        public bool EnableSetAsCurrentPlayer
        {
            get
            {
                return false; //return m_setPlayerButton.Enabled;
            }
        }

        /// <summary>
        /// Gets the player that the user was viewing when the pressed the 'Set 
        /// As Current' button. If null, then the user didn't press the button.
        /// </summary>
        public Player PlayerToSet
        {
            get
            {
                return m_playerToSet;
            }
        }
        #endregion
        
        #region Assembly Attribute Accessors

        public string AssemblyTitle
        {
            get
            {
                // Get all Title attributes on this assembly
                object[] attributes = Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(AssemblyTitleAttribute), false);
                // If there is at least one Title attribute
                if (attributes.Length > 0)
                {
                    // Select the first one
                    AssemblyTitleAttribute titleAttribute = (AssemblyTitleAttribute)attributes[0];
                    // If it is not an empty string, return it
                    if (titleAttribute.Title != "")
                        return titleAttribute.Title;
                }
                // If there was no Title attribute, or if the Title attribute was the empty string, return the .exe name
                return System.IO.Path.GetFileNameWithoutExtension(Assembly.GetExecutingAssembly().CodeBase);
            }
        }

        public string AssemblyVersion
        {
            get
            {
                return Assembly.GetExecutingAssembly().GetName().Version.ToString();
            }
        }

        public string AssemblyDescription
        {

            get
            {
                // Get all Description attributes on this assembly
                object[] attributes = Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(AssemblyDescriptionAttribute), false);
                // If there aren't any Description attributes, return an empty string
                // If there is a Description attribute, return its value
                return attributes.Length == 0 ? "" : ((AssemblyDescriptionAttribute)attributes[0]).Description;
            }
        }

        public string AssemblyProduct
        {

            get
            {
                // Get all Product attributes on this assembly
                object[] attributes = Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(AssemblyProductAttribute), false);
                // If there aren't any Product attributes, return an empty string
                // If there is a Product attribute, return its value
                return attributes.Length == 0 ? "" : ((AssemblyProductAttribute)attributes[0]).Product;
            }
        }

        public string AssemblyCopyright
        {
            get
            {
                // Get all Copyright attributes on this assembly
                object[] attributes = Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(AssemblyCopyrightAttribute), false);
                // If there aren't any Copyright attributes, return an empty string
                // If there is a Copyright attribute, return its value
                return attributes.Length == 0 ? "" : ((AssemblyCopyrightAttribute)attributes[0]).Copyright;
            }
        }

        public string AssemblyCompany
        {

            get
            {
                // Get all Company attributes on this assembly
                object[] attributes = Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(AssemblyCompanyAttribute), false);
                // If there aren't any Company attributes, return an empty string
                // If there is a Company attribute, return its value
                return attributes.Length == 0 ? "" : ((AssemblyCompanyAttribute)attributes[0]).Company;
            }
        }

        #endregion

        //private void playerLoyaltyToolStripMenuItem_Click(object sender, EventArgs e)
        //{
        //    PlayerLoyaltyForm playerLoyalty = new PlayerLoyaltyForm();
        //        playerLoyalty.Show(this);
        //}

    }
}