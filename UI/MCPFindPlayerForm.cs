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
using System.Collections.Generic;
using System.Linq;

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
        private PlayerListItem[] m_playerList = null;
        private bool[] m_sortInfo = new bool[8]{true, false, false, false, false, false, false, false};
        private int m_sortColumn = 0;
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
        public MCPFindPlayerForm(PlayerManager parent) 
        {
            m_parent = parent;
            InitializeComponent();           
            Application.DoEvents();
            Application.DoEvents();
            // m_lastFocus = m_txtbxSearchCategory;
            m_lastFocus = m_txtbxLastName;
            Application.DoEvents();
        }
        #endregion


        private void LoadPlayerListDataGrid(PlayerListItem[] players)
        {
            m_sortColumn = 0;
            m_sortInfo = new bool[8]{true, false, false, false, false, false, false, false};
            m_playerList = players.OrderBy(i => i.Id).ToArray();
            BindingSource bs = new BindingSource(m_playerList, "");
            m_dgvResultsList.DataSource = null;
            m_dgvResultsList.Rows.Clear();
            m_dgvResultsList.AutoGenerateColumns = false;
            m_dgvResultsList.AllowUserToAddRows = false;
            m_dgvResultsList.DataSource = bs; //players;
            //Sort("ReportDisplayName", SortOrder.Ascending);
            m_dgvResultsList.ClearSelection();
        }




        #region Button Events
        /// <summary>
        /// Handles the search button click.
        /// </summary>
        /// <param name="sender">The sender of the event.</param>
        /// <param name="e">An EventArgs object that contains the 
        /// event data.</param>
        private void SearchClick(object sender, EventArgs e)
        {                    
         
            m_parent.FindPlayers(string.Empty, m_txtbxLastName.Text.Trim(), m_txtbxFirstName.Text.Trim(), m_txtbxMagCard.Text.Trim());
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
                PlayerListItem[] players = m_parent.LastFindPlayersResults;

                if (players != null && players.Length > 0)
                {

                    LoadPlayerListDataGrid(players);
                    if (m_dgvResultsList.Rows.Count > 0)
                    {
                        m_dgvResultsList.Rows[0].Selected = true;
                    }

                    if (m_dgvResultsList.Rows.Count == 1)
                    {
                        m_selectPlayerButton.PerformClick();
                    }

                    m_dgvResultsList.Focus();
                }
                else
                {
                    MessageForm.Show(Properties.Resources.InfoPlayerNotFound, Properties.Resources.PlayerCenterName);
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
                //m_resultsList.Items.Clear();

                // Spawn a new thread to find players and wait until done.
                // FIX: DE2476
                m_parent.FindPlayers(magForm.MagCardNumber, string.Empty, string.Empty, string.Empty);//
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

                        LoadPlayerListDataGrid(players);
                      
                        if (m_dgvResultsList.Rows.Count > 0)
                        {
                            m_dgvResultsList.Rows[0].Selected = true;
                        }

                        if (m_dgvResultsList.Rows.Count == 1)
                        {
                            m_selectPlayerButton.PerformClick();
                        }
                    }
                    else
                    {
                        MessageForm.Show(Properties.Resources.InfoPlayerNotFound, Properties.Resources.PlayerCenterName);
                    }
                }
            }
        }

        private void m_dgvResultsList_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                e.Handled = true;
                SelectPlayerClick(sender, new EventArgs());
            }
        }


        private void m_dgvResultsList_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.Handled = true;
            }
        }

        private void m_dgvResultsList_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.Handled = true;
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

            //var testr = m_dgvResultsList.CurrentCell.RowIndex;

            if (m_dgvResultsList.SelectedRows == null || m_dgvResultsList.SelectedRows.Count == 0)
            {
                MessageForm.Show(Resources.FindPlayerFormNoPlayer);
                return;               
            }

            if (m_dgvResultsList.CurrentCell.RowIndex == -1)
            {
                MessageForm.Show(Resources.FindPlayerFormNoPlayer);
                return;
            }

            intPlayerID = (int)m_dgvResultsList.SelectedRows[0].Cells[0].Value;
            

            // Spawn a new thread to get the player's data and wait until done.
            // FIX: DE2476
            m_parent.GetPlayer(intPlayerID);
            m_parent.ShowWaitForm(this); // Block until we are done.        // END: DE2476
    
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


        private void m_dgvResultsList_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1)
                SelectPlayerClick(sender, new EventArgs());
        }

        //private void m_txtbxSearchCategory_KeyPress(object sender, KeyPressEventArgs e)
        //{
        //    if (e.KeyChar == (char)Keys.Enter)
        //    {
        //        SearchClick(sender, new EventArgs());
        //        e.Handled = true;
        //    }
        //}

        private void MCPFindPlayerForm_Shown(object sender, EventArgs e)
        {
            //m_txtbxSearchCategory.Focus();
            m_txtbxLastName.Focus();
        }

        private void m_dgvResultsList_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (m_playerList != null && e.ColumnIndex >= 1 && e.ColumnIndex < 8)//Exclude playerId on sorting in the list.  
            {
                m_sortColumn = e.ColumnIndex;
                m_sortInfo[m_sortColumn] = !m_sortInfo[m_sortColumn];

                switch (m_sortColumn)
                {
                    case 1: //first name
                    {
                        if(m_sortInfo[m_sortColumn])
                            m_playerList = m_playerList.OrderBy(i => i.FirstName).ToArray();
                        else
                            m_playerList = m_playerList.OrderByDescending(i => i.FirstName).ToArray();

                        break;
                    }

                    case 2: //middle name
                    {
                        if (m_sortInfo[m_sortColumn])
                            m_playerList = m_playerList.OrderBy(i => i.MiddleInitial).ToArray();
                        else
                            m_playerList = m_playerList.OrderByDescending(i => i.MiddleInitial).ToArray();
                        
                        break;
                    }

                    case 3: //last name
                    {
                        if (m_sortInfo[m_sortColumn])
                            m_playerList = m_playerList.OrderBy(i => i.LastName).ToArray();
                        else
                            m_playerList = m_playerList.OrderByDescending(i => i.LastName).ToArray();
                        
                        break;
                    }

                    case 4: //mag card
                    {
                        if (m_sortInfo[m_sortColumn])
                            m_playerList = m_playerList.OrderBy(i => i.MagCard).ToArray();
                        else
                            m_playerList = m_playerList.OrderByDescending(i => i.MagCard).ToArray();
                        
                        break;
                    }

                    case 5: //identity
                    {
                        if (m_sortInfo[m_sortColumn])
                            m_playerList = m_playerList.OrderBy(i => i.PlayerIdentity).ToArray();
                        else
                            m_playerList = m_playerList.OrderByDescending(i => i.PlayerIdentity).ToArray();
                        
                        break;
                    }

                    case 6: //birthdate
                    {
                        if (m_sortInfo[m_sortColumn])
                            m_playerList = m_playerList.OrderBy(i => i.BirthDate).ToArray();
                        else
                            m_playerList = m_playerList.OrderByDescending(i => i.BirthDate).ToArray();
                        
                        break;
                    }

                    case 7: //last visit date
                    {
                        if (m_sortInfo[m_sortColumn])
                            m_playerList = m_playerList.OrderBy(i => i.LastVisitDate).ToArray();
                        else
                            m_playerList = m_playerList.OrderByDescending(i => i.LastVisitDate).ToArray();
                        
                        break;
                    }

                    default:
                    {
                        if (m_sortInfo[m_sortColumn])
                            m_playerList = m_playerList.OrderBy(i => i.Id).ToArray();
                        else
                            m_playerList = m_playerList.OrderByDescending(i => i.Id).ToArray();
                        
                        break;
                    }
                }

                BindingSource bs = new BindingSource(m_playerList, "");
                m_dgvResultsList.DataSource = null;
                m_dgvResultsList.Rows.Clear();
                m_dgvResultsList.AutoGenerateColumns = false;
                m_dgvResultsList.AllowUserToAddRows = false;
                m_dgvResultsList.DataSource = bs; //players;
                m_dgvResultsList.ClearSelection();

                for (int i = 0; i < m_sortInfo.Length; i++)
                {
                    if (i != m_sortColumn)
                    {
                        m_sortInfo[i] = false;
                        m_dgvResultsList.Columns[i].HeaderCell.SortGlyphDirection = SortOrder.None;
                    }
                    else
                    {
                        m_dgvResultsList.Columns[i].HeaderCell.SortGlyphDirection = (m_sortInfo[i] ? SortOrder.Ascending : SortOrder.Descending);
                    }
                }
            }
        }

        #endregion

        private void m_dgvResultsList_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}