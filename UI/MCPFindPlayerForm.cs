#region Copyright
// This is an unpublished work protected under the copyright laws of the
// United States and other countries.  All rights reserved.  Should
// publication occur the following will apply:  © 2008 GameTech
// International, Inc.
#endregion

using System;
using System.Drawing;
using System.Windows.Forms;
using System.Globalization;
using GTI.Controls;
using GTI.Modules.Shared;
using GTI.Modules.PlayerCenter.Data;
using GTI.Modules.PlayerCenter.Business;
using GTI.Modules.PlayerCenter.Properties;

namespace GTI.Modules.PlayerCenter.UI
{
    /// <summary>
    /// A form that allows the searching of players.
    /// </summary>
    internal partial class MCPFindPlayerForm :GradientForm
    {
        #region Member Variables
        protected object m_lastFocus = null;
        protected Player m_selectedPlayer = null;

        protected PlayerManager m_parent;

        #endregion

        #region Member Properties

        /// <summary>
        /// Gets the player selected by the user.
        /// </summary>
        public Player SelectedPlayer
        {
            get
            {
                return m_selectedPlayer;
            }
        }



        #endregion

        #region Constructors
        /// <summary>
        /// Initializes a new instance of the FindPlayerForm class.
        /// </summary>
        /// <param name="parent">The PlayerManager to which this form 
        /// belongs.</param>
        /// <param name="displayMode">The display mode used to show this 
        /// form.</param>
        public MCPFindPlayerForm(PlayerManager parent) // DisplayMode displayMode) : base(parent, displayMode)
        {
            m_parent = parent;
            InitializeComponent();
            //ApplyDisplayMode();
            Application.DoEvents();
            Application.DoEvents();
            // Set the last focused control to the first field.
            m_lastFocus = m_firstName;

            // Set the max text lengths.
            m_firstName.MaxLength = StringSizes.MaxNameLength;
            m_lastName.MaxLength = StringSizes.MaxNameLength;

            // Which keyboard do we need to use?
            //switch(CultureInfo.CurrentUICulture.TwoLetterISOLanguageName)
            //{
            //    case "es":
            //        m_virtualKeyboard.KeyLayout = VirtualKeyboard.KeyboardLayout.Spanish;
            //        m_virtualKeyboard.ShiftImageIcon = Resources.ArrowUp;
            //        break;

            //    default: // Use the default.
            //        break;
            //}
            Application.DoEvents();
           
        }
        #endregion

        #region Button Events

        
        /// <summary>
        /// Handles the search button click.
        /// </summary>
        /// <param name="sender">The sender of the event.</param>
        /// <param name="e">An EventArgs object that contains the 
        /// event data.</param>
        private void SearchClick(object sender, EventArgs e)
        {
            // Remove the previous results.
            m_resultsList.Items.Clear();

            // Spawn a new thread to find players and wait until done.
            // FIX: DE2476
            m_parent.FindPlayers(string.Empty, m_firstName.Text.Trim(), m_lastName.Text.Trim());
            m_parent.ShowWaitForm(this); // Block until we are done.
            // END: DE2476

            if(m_parent.LastAsyncException != null)
            {
                if (m_parent.LastAsyncException is ServerCommException)
                    m_parent.ServerCommFailed();
                else
                    MessageForm.Show(m_parent.LastAsyncException.Message);
            }
            else
            {
                // Add the player(s) to the result list.
                PlayerListItem[] players = m_parent.LastFindPlayersResults;

                if (players != null && players.Length > 0)
                {
                    m_resultsList.Items.AddRange(players);

                    // Rally DE1889 - If only one player, automatically select.
                    if(m_resultsList.Items.Count > 0)
                        m_resultsList.SelectedIndex = 0;

                    if(m_resultsList.Items.Count == 1)
                        m_selectPlayerButton.PerformClick();
                }
                else
                {
                    MessageForm.Show(Properties.Resources.infoPlayerNotFound, Properties.Resources.PlayerCenterName);
                }
            }
        }

        /// <summary>
        /// Handles the search by card button click.
        /// </summary>
        /// <param name="sender">The sender of the event.</param>
        /// <param name="e">An EventArgs object that contains the 
        /// event data.</param>
        private void SearchByCardClick(object sender, EventArgs e)
        {
            // PDTS 1064
            GTI.Modules.Shared.MagCardForm magForm = new GTI.Modules.Shared.MagCardForm(m_parent.MagCardReader);
            magForm.ClearCardButtonVisible = false;

            if(magForm.ShowDialog() == DialogResult.OK)
            {
                // Remove the previous results.
                m_resultsList.Items.Clear();

                // Spawn a new thread to find players and wait until done.
                // FIX: DE2476
                m_parent.FindPlayers(magForm.MagCardNumber, string.Empty, string.Empty);
                m_parent.ShowWaitForm(this); // Block until we are done.
                // END: DE2476

                if(m_parent.LastAsyncException != null)
                {
                    if(m_parent.LastAsyncException is ServerCommException)
                        m_parent.ServerCommFailed();
                    else
                        MessageForm.Show(m_parent.LastAsyncException.Message);
                }
                else
                {
                    // Add the player(s) to the result list.
                    PlayerListItem[] players = m_parent.LastFindPlayersResults;

                    if (players != null && players.Length > 0)
                    {
                        m_resultsList.Items.AddRange(players);
                        m_resultsList.SelectedIndex = 0;

                        // Rally DE1889 - If only one player, automatically select.
                        if(m_resultsList.Items.Count == 1)
                            m_selectPlayerButton.PerformClick();
                    }
                    else
                    {
                        MessageForm.Show(Properties.Resources.infoPlayerNotFound, Properties.Resources.PlayerCenterName);
                    }
                }
            }
        }

       
        /// <summary>
        /// Handles the select player button click.
        /// </summary>
        /// <param name="sender">The sender of the event.</param>
        /// <param name="e">An EventArgs object that contains the 
        /// event data.</param>
        private void SelectPlayerClick(object sender, EventArgs e)
        {
            int intPlayerID = 0;
            Application.DoEvents();
            if(m_resultsList.SelectedIndex == -1)
            {
                MessageForm.Show(Resources.FindPlayerFormNoPlayer);
                return;
            }

            intPlayerID = ((PlayerListItem)m_resultsList.SelectedItem).Id;

            // Spawn a new thread to get the player's data and wait until done.
            // FIX: DE2476
            m_parent.GetPlayer(intPlayerID);
            m_parent.ShowWaitForm(this); // Block until we are done.
            // END: DE2476
            Application.DoEvents();

            if(m_parent.LastAsyncException != null)
            {
                if(m_parent.LastAsyncException is ServerCommException)
                    m_parent.ServerCommFailed();
                else
                {
                    MessageForm.Show(m_parent.LastAsyncException.Message);
                    Application.DoEvents();
                }

                return;
            }
            else
                m_selectedPlayer = m_parent.LastPlayerFromServer; // TTP 50067

            DialogResult = DialogResult.OK;
            Close();
            Application.DoEvents();
        }

        /// <summary>
        /// Handles the cancel buton click.
        /// </summary>
        /// <param name="sender">The sender of the event.</param>
        /// <param name="e">An EventArgs object that contains the 
        /// event data.</param>
        private void CancelClick(object sender, EventArgs e)
        {
            m_selectedPlayer = null;
            DialogResult = DialogResult.Cancel;
            Close();
        }

        

        #endregion

        #region List Events

        /// <summary>
        /// Handles the results list up button click.
        /// </summary>
        /// <param name="sender">The sender of the event.</param>
        /// <param name="e">An EventArgs object that contains the 
        /// event data.</param>
        private void ResultsListUpClick(object sender, EventArgs e)
        {
            if (m_resultsList.Items.Count > 0)
            {
                if (m_resultsList.SelectedIndices.Count == 0)
                    m_resultsList.SelectedIndex = 0;
                else
                {
                    int newIndex = m_resultsList.SelectedIndex - 1;

                    if (newIndex >= 0)
                        m_resultsList.SelectedIndex = newIndex;
                }
            }
        }

        /// <summary>
        /// Handles the results list down button click.
        /// </summary>
        /// <param name="sender">The sender of the event.</param>
        /// <param name="e">An EventArgs object that contains the 
        /// event data.</param>
        private void ResultsListDownClick(object sender, EventArgs e)
        {
            Application.DoEvents();
            if (m_resultsList.Items.Count > 0)
            {
                if (m_resultsList.SelectedIndices.Count == 0)
                    m_resultsList.SelectedIndex = 0;
                else
                {
                    int newIndex = m_resultsList.SelectedIndex + 1;

                    if (newIndex < m_resultsList.Items.Count)
                        m_resultsList.SelectedIndex = newIndex;
                }
            }
        }


        /// <summary>
        /// Sets the settings of this form based on the current display mode.
        /// </summary>
        //protected override void ApplyDisplayMode()
        //{
        //    base.ApplyDisplayMode();

        //    // This is a dialog, so override the default size.
        //    Size = m_displayMode.LargeDialogSize;

        //    if(m_displayMode is NormalDisplayMode)
        //    {
        //        StartPosition = FormStartPosition.Manual;
        //        Location = new Point(112, 153);
        //    }
        //    else if(m_displayMode is CompactDisplayMode)
        //    {
        //        BackgroundImage = Resources.FindPlayerBack800;
        //        //m_virtualKeyboard.SpaceImageNormal = Resources.SpacebarUp;
        //        //m_virtualKeyboard.SpaceImagePressed = Resources.SpacebarDown;
        //        //m_virtualKeyboard.SpaceStretch = false;
        //    }
        //}

        /// <summary>
        /// Handles when the focus changes on a form.
        /// </summary>
        /// <param name="sender">The sender of the event.</param>
        /// <param name="e">An EventArgs object that contains the 
        /// event data.</param>
        private void FocusChanged(object sender, EventArgs e)
        {
            if (sender is Control) //&& (sender != m_virtualKeyboard))
                m_lastFocus = sender;
        }


        private void PlayerResultsEnter(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                SelectPlayerClick(sender, new EventArgs());

        }

        private void PlayerResultsDoubleClick(object sender, EventArgs e)
        {
            ListBox lst = (ListBox)sender;
            lock (this)
            {
                try
                {
                    if (lst.SelectedIndex > -1)
                    {
                        SelectPlayerClick(sender, new EventArgs());
                    }
                }
                catch (Exception ex)
                {
                    throw new Exception("PlayerResultsDoubleClick()...Exception: " + ex.Message);
                }
            }
        }

        /// <summary>
        /// Handles when a key on the virtual keyboard is clicked.
        /// </summary>
        /// <param name="sender">The sender of the event.</param>
        /// <param name="e">A KeyboardEventArgs object that contains the 
        /// event data.</param>
        private void KeyboardKeyPressed(object sender, KeyboardEventArgs e)
        {
            if (m_lastFocus is Control) // && (m_lastFocus != m_virtualKeyboard))
            {
                ((Control)m_lastFocus).Focus();
                SendKeys.Send(e.KeyPressed);
            }
        }

        private void NameKeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                SearchClick(sender, new EventArgs());
        }


        #endregion

        

        

        

    }
}