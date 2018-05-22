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
using System.Windows.Forms;
using System.Globalization;
using GTI.Controls;
using GTI.Modules.Shared;
using GTI.Modules.PlayerCenter.Business;
using GTI.Modules.PlayerCenter.Properties;
using GTI.Modules.PlayerCenter.Data;

namespace GTI.Modules.PlayerCenter.UI
{
    /// <summary>
    /// The form that allows the adding and editing of players.
    /// </summary>
    internal partial class PlayerManagementForm : PlayerForm
    {
        #region Member Variables

        private DateTime LimitedBirthDate = new DateTime(1900, 1, 1);
        protected object m_lastFocus = null;
        protected bool m_dataChanged = false;
        protected Player m_player = new Player();
        protected Player m_playerToSet = null;
        protected bool m_playersSaved = false;
        protected byte[] m_pinNumber = new byte[DataSizes.PasswordHash]; // FIX: DE3134
        protected List<PlayerStatus> m_playerStatuses;//RALLY DE8537
        protected string mstrCredits = "";
        protected string mstrCreditsNonRef = "";
        
        protected bool mbolCreditOnline = true;
        #endregion

        #region Constructors
        /// <summary>
        /// Initializes a new instance of the PlayerManagementForm class.
        /// </summary>
        /// <param name="parent">The PlayerManager to which this form 
        /// belongs.</param>
        /// <param name="displayMode">The display mode used to show this 
        /// form.</param>
        public PlayerManagementForm(PlayerManager parent, DisplayMode displayMode)
            : base(parent, displayMode)
        {
            string strErr = "set touch screen.";

            try
            {
                strErr = "Initialize.";
                InitializeComponent();

                if (m_parent.Settings.UsePlayerIdentityAsAccountNumber)
                {
                    m_playerIdentLabel.Text = "Identity/Account";
                    m_playerIdent.UseSystemPasswordChar = false;
                    m_playerIdent.ReadOnly = false;
                }

                strErr = "apply display.";
                ApplyDisplayMode();
                strErr = "set max lengths.";
                SetMaxTextLengths();

                strErr = "set IsCreditOnline.";
                // Rally TA7897
                mbolCreditOnline = parent.Settings.CreditEnabled;

                // Set the last focused control to the first field.
                m_lastFocus = m_firstName;

                // Set the labels and textboxes for credit
                // visisble (T or F) properties
                strErr = "set credit controls visible.";
                SetCreditControls();

                m_playerStatuses = new List<PlayerStatus>();//RALLY DE8358

                // Load up the Operator Player Status listview
                LoadOperatorPlayerStatusCodes();

                strErr = "test touch screen.";
                // Do they have a player already selected?
                // FIX: DE2476
                if (m_parent.IsTouchScreen)
                {
                // END: DE2476
                    strErr = "test current player.";
                    if (m_parent.CurrentPlayer != null)
                    {
                        m_player = m_parent.CurrentPlayer;

                        strErr = "set current player values.";
                        // Fill in the default player values.
                        SetPlayerValues(false);//RALLY DE8537
                    }
                }

                // Reset the data changed value.
                m_dataChanged = false;

                // Can we take pictures?
                //TODO Take VIP Pictures
                //m_takePictureButton.Enabled = m_parent.AllowPictureCapture;


                strErr = "test culture.";
                // Which keyboard do we need to use?
                // PDTS 964
                m_virtualKeyboard.SetLayoutByCulture(CultureInfo.CurrentUICulture);

                if(CultureInfo.CurrentUICulture.TwoLetterISOLanguageName == "es")
                    m_virtualKeyboard.ShiftImageIcon = Resources.ArrowUp;

                strErr = "create pin button event.";
                this.takePINImageButton.Click += new EventHandler(takePINImageButton_Click);
            }
            catch (Exception ex)
            {
                throw new Exception("PlayerManagementForm()....Exception: " + ex.Message + "...last step: " + strErr);
            }
        }
        #endregion

        #region Operator and Player Status methods
        private void LoadOperatorPlayerStatusCodes()
        {
            // Load all operator player status values into listbox, 
            m_activeStatusList.Items.Clear();
            foreach (PlayerStatus status in PlayerManager.OperatorPlayerStatusList)
            {
                if(status.IsActive)
                    m_activeStatusList.Items.Add(status);
            }
        }

        private void GetPlayerStatusFromListBox()
        {
            m_player.ActiveStatusList.Clear();
            foreach(PlayerStatus item in m_activeStatusList.SelectedItems)
            {
                foreach(PlayerStatus status in PlayerManager.OperatorPlayerStatusList)
                {
                    if(status.Id == item.Id)
                    {
                        m_player.ActiveStatusList.Add(status);
                        break;
                    }
                }
            }
            
        }

        private bool listViewSetup;
        private void SelectPlayersStatusInListBox()
        {
            listViewSetup = true;
            m_activeStatusList.ClearSelected();
            m_playerStatuses.Clear();//RALLY DE8358
            if (m_player.Id > 0)
            {
                foreach (PlayerStatus status in m_player.ActiveStatusList)
                {
                    for(int x = 0; x < m_activeStatusList.Items.Count; x++)
                    {
                        if(status.Id == ((PlayerStatus)m_activeStatusList.Items[x]).Id)
                        {
                            m_activeStatusList.SelectedIndices.Add(x);
                            m_playerStatuses.Add(status);//RALLY DE8358
                            break;
                        }
                    }
                }
            }
            listViewSetup = false;
        }
        //START RALLY DE8358
        private void SelectPlayersStatusFromList()
        {
            listViewSetup = true;
            m_activeStatusList.ClearSelected();
            if (m_player.Id > 0)
            {
                foreach (PlayerStatus status in m_playerStatuses)
                {
                    for (int x = 0; x < m_activeStatusList.Items.Count; x++)
                    {
                        if (status.Id == ((PlayerStatus)m_activeStatusList.Items[x]).Id)
                        {
                            m_activeStatusList.SelectedIndices.Add(x);

                            break;
                        }
                    }
                }
            }
            listViewSetup = false;
        }
        //END RALLY DE8358

        private void ActiveStatusList_ItemSelectionChanged(object sender, EventArgs e)
        {
            if (!listViewSetup)
            {
                GetPlayerStatusFromListBox();
                m_dataChanged = true; //RALLY DE8358
            }
        }

        #endregion

        #region Events

        private void receiptUpImageButton_Click(object sender, EventArgs e)
        {
            if (m_ReceiptNumberColorListBox.SelectedIndex > 0)
                m_ReceiptNumberColorListBox.SelectedIndex = m_ReceiptNumberColorListBox.SelectedIndex - 1;

        }

        private void receiptDownImageButton_Click(object sender, EventArgs e)
        {
            if (m_ReceiptNumberColorListBox.SelectedIndex < m_ReceiptNumberColorListBox.Items.Count - 1)
                m_ReceiptNumberColorListBox.SelectedIndex = m_ReceiptNumberColorListBox.SelectedIndex + 1;

        }

        // Rally US493
        /// <summary>
        /// Handles the status list up button's click event.
        /// </summary>
        /// <param name="sender">The sender of the event.</param>
        /// <param name="e">An EventArgs object that contains the 
        /// event data.</param>
        private void StatusUpButtonClick(object sender, EventArgs e)
        {
            if(m_activeStatusList.Items.Count > 0)
            {
                int top = m_activeStatusList.TopIndex - 1;

                if(top < 0)
                    top = 0;

                m_activeStatusList.TopIndex = top;
            }
        }

        /// <summary>
        /// Handles the status list down button's click event.
        /// </summary>
        /// <param name="sender">The sender of the event.</param>
        /// <param name="e">An EventArgs object that contains the 
        /// event data.</param>
        private void StatusDownButtonClick(object sender, EventArgs e)
        {
            if(m_activeStatusList.Items.Count > 0)
            {
                int top = m_activeStatusList.TopIndex + 1;

                if(top >= m_activeStatusList.Items.Count)
                    top = m_activeStatusList.Items.Count - 1;

                if(top < 0)
                    top = 0;

                m_activeStatusList.TopIndex = top;
            }
        }  

        /// <summary>
        /// Handles when the focus changes on a form.
        /// </summary>
        /// <param name="sender">The sender of the event.</param>
        /// <param name="e">An EventArgs object that contains the 
        /// event data.</param>
        private void FocusChanged(object sender, EventArgs e)
        {
            if (sender is Control && (sender != m_virtualKeyboard))
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
            bool discardChanges = true;

            if (m_dataChanged)
                discardChanges = ShouldWeDiscardChanges();

            if (discardChanges)
            {
                FindPlayerForm findForm = new FindPlayerForm(m_parent, m_displayMode);

                if(findForm.ShowDialog() == DialogResult.OK)
                {
                    m_player = findForm.SelectedPlayer;
                    SetPlayerValues(false);//RALLY DE8537
                    m_dataChanged = false;
                }
                else if(m_parent.LastAsyncException is ServerCommException) // TTP 50120
                    Close();
            }

            GC.Collect(); // DE2476
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
            bool discardChanges = true;

            if (m_dataChanged)
                discardChanges = ShouldWeDiscardChanges();

            if (discardChanges)
            {
                m_player = new Player();
                SetPlayerValues(false);//RALLY DE8537
                m_dataChanged = false;
                m_firstName.Focus();
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
            // PDTS 1064
            GTI.Modules.Shared.MagCardForm magForm = new GTI.Modules.Shared.MagCardForm(m_displayMode, m_parent.MagCardReader);

            if (magForm.ShowDialog() == DialogResult.OK)
            {
//                m_magCardImageLabel.Text = magForm.MagCardNumber;
                m_magCard.Text = magForm.MagCardNumber;
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

            EventWaitHandle waitHandle = new EventWaitHandle(false, EventResetMode.AutoReset, "Player Picture Wait Handle");
            waitHandle.WaitOne();

            try
            {
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
                MessageForm.Show(m_displayMode, string.Format(Resources.LoadPictureFailed, ex.Message));
            }
        }

        /// <summary>
        /// Handles the save changes button click.
        /// </summary>
        /// <param name="sender">The sender of the event.</param>
        /// <param name="e">An EventArgs object that contains the 
        /// event data.</param>
        private void SaveChangesClick(object sender, EventArgs e)
        {
            if (ValidateData())
            {
                // Get the player's values from the UI.
                GetPlayerValues();
                
                // If this player is new, make the join date right now.
                if (m_player.Id == 0)
                    m_player.JoinDate = DateTime.Now;

                // Spawn a new thread to save the player and wait until done.
                // FIX: DE2476
                m_parent.SavePlayer(m_player);
                m_parent.ShowWaitForm(this); // Block until we are done.
                // END: DE2476

                if (m_parent.LastAsyncException != null)
                {
                    if(m_parent.LastAsyncException is ServerCommException)
                        Close(); // TTP 50120
                    else
                        MessageForm.Show(m_displayMode, m_parent.LastAsyncException.Message);
                }
                else
                {
                    m_player = m_parent.LastPlayerFromServer; // TTP 50067

                    // Set the saved player's values back to the UI.
                    SetPlayerValues(false);//RALLY DE8537

                    m_dataChanged = false;
                    m_playersSaved = true;

                    MessageForm.Show(m_displayMode, Properties.Resources.InfoSaveSuccessed);
                }
            }

            GC.Collect(); // DE2476
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
            bool discardChanges = true;

            if (m_dataChanged)
                discardChanges = ShouldWeDiscardChanges();

            if (discardChanges)
            {
                SetPlayerValues(true);//RALLY DE8537
                m_dataChanged = false;
            }

            GC.Collect(); // DE2476
        }

        /// <summary>
        /// Handles the set as current player button click and
        /// sets the POS's player.
        /// </summary>
        /// <param name="sender">The sender of the event.</param>
        /// <param name="e">An EventArgs object that contains the 
        /// event data.</param>
        private void SetAsCurrentPlayerClick(object sender, EventArgs e)
        {
            if (m_player.Id > 0)
            {
                bool discardChanges = true;

                if (m_dataChanged)
                    discardChanges = ShouldWeDiscardChanges();

                if (discardChanges)
                {
                    m_playerToSet = m_player;
                    Close();
                }
            }
            else
            {
                MessageForm.Show(m_displayMode, Resources.NoPlayer);
            }
        }

        /// <summary>
        /// Handles the exit button click and closes the form.
        /// </summary>
        /// <param name="sender">The sender of the event.</param>
        /// <param name="e">An EventArgs object that contains the 
        /// event data.</param>
        private void ExitClick(object sender, EventArgs e)
        {
            bool discardChanges = true;

            if (m_dataChanged)
                discardChanges = ShouldWeDiscardChanges();

            if (discardChanges)
            {
                m_playerToSet = null;
                Close();
            }
        }

        private bool ShouldWeDiscardChanges()
        {
            return MessageForm.ShowCustomTwoButton(this, m_displayMode, Resources.Changes, Resources.PlayerCenterName, true, 1, "Keep", "Discard", 0) == 2;
        }

        /// <summary>
        /// Handles when a key on the virtual keyboard is clicked.
        /// </summary>
        /// <param name="sender">The sender of the event.</param>
        /// <param name="e">A KeyboardEventArgs object that contains the 
        /// event data.</param>
        private void KeyboardKeyPressed(object sender, KeyboardEventArgs e)
        {
            if (m_lastFocus is Control && (m_lastFocus != m_virtualKeyboard))
            {
                ((Control)m_lastFocus).Focus();
                SendKeys.Send(e.KeyPressed);
            }
        }

        /// <summary>
        /// Handles when the player data has changed.
        /// </summary>
        /// <param name="sender">The sender of the event.</param>
        /// <param name="e">A EventArgs object that contains the 
        /// event data.</param>
        private void PlayerDataChanged(object sender, EventArgs e)
        {
            m_dataChanged = true;
        }
        private void takePINImageButton_Click(object sender, EventArgs e)
        {
            TakePIN pinform = new TakePIN(m_parent.Settings.DisplayMode);
            pinform.ShowDialog();
            if (!string.IsNullOrEmpty(pinform.PIN) && pinform.DialogResult == DialogResult.OK) //DE12758
            {
                m_pinNumber = SecurityHelper.HashPassword(pinform.PIN.ToString()); // Rally TA1583
            }
            
        }
        #endregion

        #region Member Methods
        /// <summary>
        /// Sets the settings of this form based on the current display mode.
        /// </summary>
        protected override void ApplyDisplayMode()
        {
            base.ApplyDisplayMode();

            if(m_displayMode is CompactDisplayMode)
            {
                // Adjust controls for small screen.
                Font bigFont = new Font("Tahoma", 14F, FontStyle.Bold);
                Font mediumFont = new Font("Tahoma", 12F, FontStyle.Bold);
                Font smallFont = new Font("Tahoma", 9F, FontStyle.Bold);
                Font labelFont = new Font("Tahoma", 7F, FontStyle.Bold);
                Font buttonFont = new Font("Tahoma", 8F, FontStyle.Bold);

                Color lineColor1 = Color.FromArgb(160, 180, 212);
                Color lineColor2 = Color.FromArgb(163, 182, 211);
                Color lineColor3 = Color.FromArgb(167, 184, 210);
                Color lineColor4 = Color.FromArgb(174, 187, 209);
                Color lowerLineColor1 = Color.FromArgb(81, 71, 59);
                Color lowerLineColor2 = Color.FromArgb(77, 67, 54);

                int labelHeight = 12;

                Size buttonSize = new Size(90, 45);

                BackgroundImage = Resources.PlayerMgmtBack800;

                m_playerPicture.Location = new Point(26, 15);
                m_playerPicture.Size = new Size(224, 168);
                m_noPic.Location = m_playerPicture.Location;
                m_noPic.Size = m_playerPicture.Size;

                m_firstName.Location = new Point(280, 8);
                m_firstName.Size = new Size(222, 23);
                m_firstName.Font = bigFont;
                m_firstNameLabel.Location = new Point(277, 36);
                m_firstNameLabel.Size = new Size(m_firstNameLabel.Size.Width, labelHeight);
                m_firstNameLabel.Font = labelFont;
                m_firstNameLabel.BackColor = lineColor1;



                m_middleInitial.Location = new Point(518, 8);
                m_middleInitial.Size = new Size(34, 23);
                m_middleInitial.Font = bigFont;
                m_middleInitialLabel.Location = new Point(517, 36);
                m_middleInitialLabel.Size = new Size(m_middleInitialLabel.Size.Width, labelHeight);
                m_middleInitialLabel.Font = labelFont;
                m_middleInitialLabel.BackColor = lineColor1;

                m_lastName.Location = new Point(567, 8);
                m_lastName.Size = new Size(220, 23);
                m_lastName.Font = bigFont;
                m_lastNameLabel.Location = new Point(564, 36);
                m_lastNameLabel.Size = new Size(m_lastNameLabel.Size.Width, labelHeight);
                m_lastNameLabel.Font = labelFont;
                m_lastNameLabel.BackColor = lineColor1;

                m_birthDate.Location = new Point(281, 52);
                m_birthDate.Size = new Size(107, 20);
                m_birthDate.Font = mediumFont;
                m_birthDateLabel.Location = new Point(278, 75);
                m_birthDateLabel.Size = new Size(m_birthDateLabel.Size.Width, labelHeight);
                m_birthDateLabel.Font = labelFont;
                m_birthDateLabel.BackColor = lineColor2;

                m_gender.Location = new Point(406, 52);
                m_gender.Size = new Size(32, 20);
                m_gender.Font = mediumFont;
                m_genderLabel.Location = new Point(403, 75);
                m_genderLabel.Size = new Size(m_genderLabel.Size.Width, labelHeight);
                m_genderLabel.Font = labelFont;
                m_genderLabel.BackColor = lineColor2;

                m_phoneNum.Location = new Point(456, 52);
                m_phoneNum.Size = new Size(127, 20);
                m_phoneNum.Font = mediumFont;
                m_phoneNumLabel.Location = new Point(453, 75);
                m_phoneNumLabel.Size = new Size(m_phoneNumLabel.Size.Width, labelHeight);
                m_phoneNumLabel.Font = labelFont;
                m_phoneNumLabel.BackColor = lineColor2;

                //m_pinNum.Location = new Point(601, 52);
                //m_pinNum.Size = new Size(43, 20);
                //m_pinNum.Font = mediumFont;
                //m_pinNumLabel.Location = new Point(598, 75);
                //m_pinNumLabel.Size = new Size(m_pinNumLabel.Size.Width, labelHeight);
                //m_pinNumLabel.Font = labelFont;
                //m_pinNumLabel.BackColor = lineColor2;

                m_socialSecurityNum.Location = new Point(662, 52);
                m_socialSecurityNum.Size = new Size(123, 20);
                m_socialSecurityNum.Font = mediumFont;
                m_socialSecurityNumLabel.Location = new Point(659, 75);
                m_socialSecurityNumLabel.Size = new Size(m_socialSecurityNumLabel.Size.Width, labelHeight);
                m_socialSecurityNumLabel.Font = labelFont;
                m_socialSecurityNumLabel.BackColor = lineColor2;

                // FIX: DE6690
                m_credits.Location = new Point(850, 168);
                m_credits.Size = new Size(140, 20);
                m_credits.Font = mediumFont;

                lblCredits.Location = new Point(850, 148);
                lblCredits.Size = new Size(116, 13);
                lblCredits.Font = labelFont;
                lblCredits.BackColor = lineColor2;

                m_creditsNon.Location = new Point(850, 168);
                m_creditsNon.Size = new Size(140, 20);
                m_creditsNon.Font = mediumFont;
                // END: DE6690

                lblCreditNonRef.Location = new Point(850, 193);
                lblCreditNonRef.Size = new Size(116, 13);
                lblCreditNonRef.Font = labelFont;
                lblCreditNonRef.BackColor = lineColor2;

                m_email.Location = new Point(281, 91);
                m_email.Size = new Size(302, 20);
                m_email.Font = mediumFont;
                m_emailLabel.Location = new Point(278, 114);
                m_emailLabel.Size = new Size(m_emailLabel.Size.Width, labelHeight);
                m_emailLabel.Font = labelFont;
                m_emailLabel.BackColor = lineColor3;

                m_playerIdent.Location = new Point(601, 91);
                m_playerIdent.Size = new Size(186, 20);
                m_playerIdent.Font = mediumFont;
                m_playerIdentLabel.Location = new Point(598, 114);
                m_playerIdentLabel.Size = new Size(m_playerIdentLabel.Size.Width, labelHeight);
                m_playerIdentLabel.Font = labelFont;
                m_playerIdentLabel.BackColor = lineColor3;

                m_comments.Location = new Point(281, 131);
                m_comments.Size = new Size(506, 41);
                m_comments.Font = mediumFont;
                m_commentsLabel.Location = new Point(278, 175);
                m_commentsLabel.Size = new Size(m_commentsLabel.Size.Width, labelHeight);
                m_commentsLabel.Font = labelFont;
                m_commentsLabel.BackColor = lineColor4;

                m_address1.Location = new Point(21, 197);
                m_address1.Size = new Size(249, 20);
                m_address1.Font = mediumFont;
                m_address1Label.Location = new Point(18, 221);
                m_address1Label.Size = new Size(m_address1Label.Size.Width, labelHeight);
                m_address1Label.Font = labelFont;
                m_address1Label.BackColor = lowerLineColor1;

                m_address2.Location = new Point(287, 197);
                m_address2.Size = new Size(83, 20);
                m_address2.Font = mediumFont;
                m_address2Label.Location = new Point(285, 221);
                m_address2Label.Size = new Size(m_address2Label.Size.Width, labelHeight);
                m_address2Label.Font = labelFont;
                m_address2Label.BackColor = lowerLineColor1;

                m_city.Location = new Point(387, 197);
                m_city.Size = new Size(129, 20);
                m_city.Font = mediumFont;
                m_cityLabel.Location = new Point(385, 221);
                m_cityLabel.Size = new Size(m_cityLabel.Size.Width, labelHeight);
                m_cityLabel.Font = labelFont;
                m_cityLabel.BackColor = lowerLineColor1;

                m_state.Location = new Point(533, 197);
                m_state.Size = new Size(22, 20);
                m_state.Font = mediumFont;
                m_stateLabel.Location = new Point(525, 221);
                m_stateLabel.Size = new Size(m_stateLabel.Size.Width, labelHeight);
                m_stateLabel.Font = labelFont;
                m_stateLabel.BackColor = lowerLineColor1;

                m_zipCode.Location = new Point(572, 197);
                m_zipCode.Size = new Size(89, 20);
                m_zipCode.Font = mediumFont;
                m_zipCodeLabel.Location = new Point(570, 221);
                m_zipCodeLabel.Size = new Size(m_zipCodeLabel.Size.Width, labelHeight);
                m_zipCodeLabel.Font = labelFont;
                m_zipCodeLabel.BackColor = lowerLineColor1;

                m_country.Location = new Point(678, 197);
                m_country.Size = new Size(102, 20);
                m_country.Font = mediumFont;
                m_countryLabel.Location = new Point(676, 221);
                m_countryLabel.Size = new Size(m_countryLabel.Size.Width, labelHeight);
                m_countryLabel.Font = labelFont;
                m_countryLabel.BackColor = lowerLineColor1;

                m_pointsBalance.Location = new Point(21, 236);
                m_pointsBalance.Size = new Size(60, 21);
                m_pointsBalance.Font = smallFont;
                m_pointsBalanceLabel.Location = new Point(19, 260);
                m_pointsBalanceLabel.Size = new Size(m_pointsBalanceLabel.Size.Width, labelHeight);
                m_pointsBalanceLabel.Font = labelFont;
                m_pointsBalanceLabel.BackColor = lowerLineColor2;

                m_lastVisit.Location = new Point(98, 236);
                m_lastVisit.Size = new Size(95, 21);
                m_lastVisit.Font = smallFont;
                m_lastVisitLabel.Location = new Point(99, 260);
                m_lastVisitLabel.Size = new Size(m_lastVisitLabel.Size.Width, labelHeight);
                m_lastVisitLabel.Font = labelFont;
                m_lastVisitLabel.BackColor = lowerLineColor2;

                m_joinDate.Location = new Point(210, 236);
                m_joinDate.Size = new Size(92, 21);
                m_joinDate.Font = smallFont;
                m_joinDateLabel.Location = new Point(211, 260);
                m_joinDateLabel.Size = new Size(m_joinDateLabel.Size.Width, labelHeight);
                m_joinDateLabel.Font = labelFont;
                m_joinDateLabel.BackColor = lowerLineColor2;

                m_visitCount.Location = new Point(319, 236);
                m_visitCount.Size = new Size(36, 21);
                m_visitCount.Font = smallFont;
                m_visitCountLabel.Location = new Point(320, 260);
                m_visitCountLabel.Size = new Size(m_visitCountLabel.Size.Width, labelHeight);
                m_visitCountLabel.Font = labelFont;
                m_visitCountLabel.BackColor = lowerLineColor2;

                m_playerId.Location = new Point(372, 236);
                m_playerId.Size = new Size(93, 21);
                m_playerId.Font = smallFont;
                m_playerIdLabel.Location = new Point(373, 260);
                m_playerIdLabel.Size = new Size(m_playerIdLabel.Size.Width, labelHeight);
                m_playerIdLabel.Font = labelFont;
                m_playerIdLabel.BackColor = lowerLineColor2;

                m_playerTier.Location = new Point(482, 236);
                m_playerTier.Size = new Size(102, 21);
                m_playerTier.Font = smallFont;
                m_playerTierLabel.Location = new Point(483, 260);
                m_playerTierLabel.Size = new Size(m_playerTierLabel.Size.Width, labelHeight);
                m_playerTierLabel.Font = labelFont;
                m_playerTierLabel.BackColor = lowerLineColor2;

                //m_magCardNum.Location = new Point(601, 236);
                //m_magCardNum.Size = new Size(178, 21);
                //m_magCardNum.Font = smallFont;
                m_magCardNumLabel.Location = new Point(602, 260);
                m_magCardNumLabel.Size = new Size(m_magCardNumLabel.Size.Width, labelHeight);
                m_magCardNumLabel.Font = labelFont;
                m_magCardNumLabel.BackColor = lowerLineColor2;

                m_findPlayerButton.Location = new Point(23, 277);
                m_findPlayerButton.Size = buttonSize;
                m_findPlayerButton.Font = buttonFont;

                m_newPlayerButton.Location = new Point(118, 277);
                m_newPlayerButton.Size = buttonSize;
                m_newPlayerButton.Font = buttonFont;

                m_assignCardButton.Location = new Point(213, 277);
                m_assignCardButton.Size = buttonSize;
                m_assignCardButton.Font = buttonFont;

                m_takePictureButton.Location = new Point(308, 277);
                m_takePictureButton.Size = buttonSize;
                m_takePictureButton.Font = buttonFont;

                m_saveChangesButton.Location = new Point(403, 277);
                m_saveChangesButton.Size = buttonSize;
                m_saveChangesButton.Font = buttonFont;

                m_cancelChangesButton.Location = new Point(498, 277);
                m_cancelChangesButton.Size = buttonSize;
                m_cancelChangesButton.Font = buttonFont;

                m_setPlayerButton.Location = new Point(593, 277);
                m_setPlayerButton.Size = buttonSize;
                m_setPlayerButton.Font = buttonFont;

                m_exitButton.Location = new Point(688, 277);
                m_exitButton.Size = buttonSize;
                m_exitButton.Font = buttonFont;

                m_virtualKeyboard.Location = new Point(25, 334);
                m_virtualKeyboard.SpaceImageNormal = Resources.SpacebarUp;
                m_virtualKeyboard.SpaceImagePressed = Resources.SpacebarDown;
                m_virtualKeyboard.SpaceStretch = false;
            }
        }

        /// <summary>
        /// Sets the MaxLength property of all the text boxes based on
        /// the Set Player Data server message.
        /// </summary>
        protected void SetMaxTextLengths()
        {
            m_firstName.MaxLength = StringSizes.MaxNameLength;
            m_middleInitial.MaxLength = StringSizes.MaxMiddleNameLength;
            m_lastName.MaxLength = StringSizes.MaxNameLength;
            m_socialSecurityNum.MaxLength = StringSizes.MaxGovIssuedIdNumLength;
            m_birthDate.MaxLength = StringSizes.MaxDateLength;
            m_email.MaxLength = StringSizes.MaxEmailLength;
            m_playerIdent.MaxLength = StringSizes.MaxPlayerIdentLength;
            m_phoneNum.MaxLength = StringSizes.MaxPhoneNumberLength;
            m_address1.MaxLength = StringSizes.MaxAddressLength;
            m_address2.MaxLength = StringSizes.MaxAddressLength;
            m_city.MaxLength = StringSizes.MaxCityStateZipCountryLength;
            m_state.MaxLength = StringSizes.MaxCityStateZipCountryLength;
            m_zipCode.MaxLength = StringSizes.MaxCityStateZipCountryLength;
            m_country.MaxLength = StringSizes.MaxCityStateZipCountryLength;
            m_comments.MaxLength = StringSizes.MaxPlayerCommentLength;
        }

        /// <summary>
        /// Sets the player's values in the UI.
        /// </summary>
        protected void SetPlayerValues(bool isCanceled)//RALLY DE8358
        {
            m_playerId.Text = m_player.Id.ToString();
            m_firstName.Text = m_player.FirstName;
            m_middleInitial.Text = m_player.MiddleInitial;
            m_lastName.Text = m_player.LastName;
            m_socialSecurityNum.Text = m_player.GovIssuedIdNumber;

            if(m_player.BirthDate != DateTime.MinValue)
                m_birthDate.Text = m_player.BirthDate.ToShortDateString();
            else
                m_birthDate.Text = string.Empty;

            m_email.Text = m_player.Email;
            m_playerIdent.Text = m_player.PlayerIdentity;
            m_phoneNum.Text = m_player.PhoneNumber;

            // FIX: DE1891
            if(m_player.Gender == Resources.GenderMale)
                m_gender.Text = Resources.GenderMale;
            else if(m_player.Gender == Resources.GenderFemale)
                m_gender.Text = Resources.GenderFemale;
            else if (m_player.Gender == Resources.GenderOther)
                m_gender.Text = Resources.GenderOther;
            else
                m_gender.Text = string.Empty;
            // END: DE1891
            
            m_address1.Text = m_player.Address1;
            m_address2.Text = m_player.Address2;
            m_city.Text = m_player.City;
            m_state.Text = m_player.State;
            m_zipCode.Text = m_player.Zip;
            m_country.Text = m_player.Country;

            if(m_player.JoinDate != DateTime.MinValue)
                m_joinDate.Text = m_player.JoinDate.ToShortDateString();
            else
                m_joinDate.Text = string.Empty;

            if(m_player.LastVisit != DateTime.MinValue)
                m_lastVisit.Text = m_player.LastVisit.ToShortDateString();
            else
                m_lastVisit.Text = string.Empty;

            m_pointsBalance.Text = m_player.PointsBalance.ToString("N");
            m_visitCount.Text = m_player.VisitCount.ToString();
//            m_magCardImageLabel.Text = m_player.MagneticCardNumber;
            m_magCard.Text = m_player.MagneticCardNumber;
            m_comments.Text = m_player.Comment;

            mstrCredits = m_player.RefundableCredit.ToString();
            mstrCreditsNonRef = m_player.NonRefundableCredit.ToString();
            m_pinNumber =  m_player.PinNumber;

            SetCreditControls();

            // FIX: DE6690 
            if(mbolCreditOnline)
            {
                this.lblCredits.Visible = true;
                this.lblCreditNonRef.Visible = true;
                this.m_credits.Visible = true;
                this.m_creditsNon.Visible = true;

                // Rally DE1890
                this.m_credits.Text = String.Format("{0:N}", m_player.RefundableCredit);
                this.m_creditsNon.Text = String.Format("{0:N}", m_player.NonRefundableCredit);
            }
            else
            {
                this.lblCredits.Visible = false;
                this.lblCreditNonRef.Visible = false;
                this.m_credits.Visible = false;
                this.m_creditsNon.Visible = false;
            }
            // END: DE6690

            if(m_player.LoyaltyTier != null)
                m_playerTier.Text = m_player.LoyaltyTier.Name;
            else
                m_playerTier.Text = string.Empty;

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

            //newly added
            m_TotalSpend.Text = m_player.TotalSpend.ToString("N"); // FIX: DE3341
            m_LoginStatusImageLabel.Text = m_player.IsLoggedIn ? Properties.Resources.Yes : Properties.Resources.No;
            m_ReceiptNumberColorListBox.Items.Clear();
            if (m_player.ReceiptNumbers != null)
            {

                for (int iReceipt = 0; iReceipt < m_player.ReceiptNumbers.Length; iReceipt++)
                {
                    m_ReceiptNumberColorListBox.Items.Add(m_player.ReceiptNumbers[iReceipt]);
                }
                //alway select the first one
                m_ReceiptNumberColorListBox.SelectedIndex = 0;
            }

            //START RALLY DE8358
            if (!isCanceled)
            {
                SelectPlayersStatusInListBox();
            }
            else
            {
                SelectPlayersStatusFromList();
            }
            //END RALLY DE8358
        }

        /// <summary>
        /// Gets the player values from the UI.
        /// </summary>
        protected void GetPlayerValues()
        {
            m_player.FirstName = m_firstName.Text.Trim();
            m_player.MiddleInitial = m_middleInitial.Text.Trim();
            m_player.LastName = m_lastName.Text.Trim();
            m_player.GovIssuedIdNumber = m_socialSecurityNum.Text.Trim();

            try
            {
                m_player.BirthDate = DateTime.Parse(m_birthDate.Text.Trim());
            }
            catch(FormatException)
            {
                m_player.BirthDate = DateTime.MinValue;
            }

            m_player.Email = m_email.Text.Trim();
            m_player.PlayerIdentity = m_playerIdent.Text.Trim();
            m_player.PhoneNumber = m_phoneNum.Text.Trim();
            // FIX: DE1891
            m_player.Gender = m_gender.Text;
            m_player.PinNumber = m_pinNumber; //m_pinNum.Text.Trim();
            m_player.Address1 = m_address1.Text.Trim();
            m_player.Address2 = m_address2.Text.Trim();
            m_player.City = m_city.Text.Trim();
            m_player.State = m_state.Text.Trim();
            m_player.Zip = m_zipCode.Text.Trim();
            m_player.Country = m_country.Text.Trim();
//            m_player.MagneticCardNumber = m_magCardImageLabel.Text;
            m_player.MagneticCardNumber = m_magCard.Text;
            /* Credits are Read-Only properties  */
            m_player.RefundableCredit = Convert.ToDecimal((mstrCredits != "" ? mstrCredits : "0"));
            m_player.NonRefundableCredit = Convert.ToDecimal((mstrCreditsNonRef!="" ? mstrCreditsNonRef : "0"));
            m_player.PinNumber = m_pinNumber;

            if(m_comments.Text.Trim().Length <= StringSizes.MaxPlayerCommentLength)
                m_player.Comment = m_comments.Text.Trim();
            else
                m_player.Comment = m_comments.Text.Trim().Substring(0, StringSizes.MaxPlayerCommentLength);

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
//            if(m_lastName.Text.Trim() == string.Empty && m_magCardImageLabel.Text.Trim() == string.Empty)
            if (m_lastName.Text.Trim() == string.Empty && m_magCard.Text.Trim() == string.Empty)
            {
                MessageForm.Show(m_displayMode, Resources.NoNameOrCard);
                valid = false;
            }

            // Check the birth date.
            if(m_birthDate.Text.Trim() != string.Empty)
            {
                DateTime temp;
                try
                {
                    temp = DateTime.Parse(m_birthDate.Text);
                    if (temp.CompareTo(LimitedBirthDate) <0)
                    {
                        throw new Exception (Resources.warningBirthDate);
                    }
                }
                catch(Exception)
                {
                    MessageForm.Show(m_displayMode, Resources.InvalidBirthDate);
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

            return valid;
        }

        private void SetCreditControls()
        {
            string strErr = "";

            lock (this)
            {
                try
                {
                    /*     Set properties on Credit specfic controls
                     *     Also set the form BackGround Image    
                     */

                    // FIX: DE6690
//                  m_credits.Text = "";
//                  m_creditsNon.Text = "";
//                  m_socialSecurityNum.Text = "";
//                  m_playerIdent.Text = "";

                    strErr = "test credit online.";
                    if (  this.mbolCreditOnline )
                    {
                        strErr = "set credit controls...true.";
                        this.lblCredits.Visible = true;
                        this.lblCreditNonRef.Visible = true;
                        this.m_credits.Visible = true;
                        this.m_creditsNon.Visible = true;

                        strErr = "set BackgroundImage...true.";
                        this.BackgroundImage = Resources.PlayerScreenCredits1024;

                    }
                    else
                    {
                        strErr = "set credit controls...false.";
                        this.lblCredits.Visible = false;
                        this.lblCreditNonRef.Visible = false;
                        this.m_credits.Visible = false;
                        this.m_creditsNon.Visible = false;
                        this.m_socialSecurityNum.Width = (this.m_credits.Location.X + this.m_credits.Width) - this.m_socialSecurityNum.Location.X;
                        this.m_playerIdent.Width = (this.m_creditsNon.Location.X + this.m_creditsNon.Width) - this.m_playerIdent.Location.X;
                        strErr = "set BackgroundImage...false.";
                        this.BackgroundImage = Resources.PlayerScreen1024;
                    }
                    // END: DE6690

                    Application.DoEvents();


                }
                catch (Exception ex)
                {
                    throw new Exception("SetCreditControls()...Exception: "+ex.Message + "....last step: "+strErr );
                }
                
            }

        }

        // FIX: DE1891
        /// <summary>
        /// Handles the cycle gender button's click event.
        /// </summary>
        /// <param name="sender">The sender of the event.</param>
        /// <param name="e">A EventArgs object that contains the 
        /// event data.</param>
        private void GenderCycleClick(object sender, EventArgs e)
        {
            if(m_gender.Text == Resources.GenderMale)
                m_gender.Text = Resources.GenderFemale;
            else if(m_gender.Text == Resources.GenderFemale)
                m_gender.Text = Resources.GenderOther;
            else if (m_gender.Text == Resources.GenderOther)
                m_gender.Text = string.Empty;
            else
                m_gender.Text = Resources.GenderMale;
            m_dataChanged = true;//RALLY DE8537
        }
        // END: DE1891
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
                return m_setPlayerButton.Enabled;
            }
            set
            {
                m_setPlayerButton.Enabled = value;
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
    }
}