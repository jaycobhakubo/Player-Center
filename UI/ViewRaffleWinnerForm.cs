#region Copyright
// This is an unpublished work protected under the copyright laws of the
// United States and other countries.  All rights reserved.  Should
// publication occur the following will apply:  © 2008 GameTech
// International, Inc.
#endregion

using System;
using System.Text;
using System.Data;
using System.Drawing;
using System.ComponentModel;
using System.Collections.Generic;
using System.Windows.Forms;
using GTI.Modules.Shared;
using GTI.Modules.PlayerCenter.Business;
using GTI.Modules.PlayerCenter.Properties;
using GTI.Modules.PlayerCenter.Data;

namespace GTI.Modules.PlayerCenter.UI
{
    /// <summary>
    /// The form that allows the viewing of Raffle Winners.
    /// </summary>
    internal partial class ViewRaffleWinnerForm : PlayerForm 
    {
        #region Constructors

        /// <summary>
        /// Initializes a new instance of the ViewRaffleWinnerForm class.
        /// </summary>
        /// <param name="parent">The PlayerManger to which this form 
        /// belongs.</param>
        /// <param name="displayMode">The display mode used to show this 
        /// form.</param>
        public ViewRaffleWinnerForm(PlayerManager parent, DisplayMode displayMode)
            : base(parent, displayMode)
        {
            InitializeComponent();
        }

        #endregion

        #region Member Methods
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void RunRaffleClick(object sender, EventArgs e)
        {
            // TODO Move these server messages to their own thread.
            try
            {
                m_parent.RunPlayerRaffle();

                if(m_parent.LastRaffleReturnCode == (int)RunPlayerRaffleReturnCode.NotEnoughPlayers)
                    throw new PlayerCenterException(Resources.NoRafflePlayers);

                else if (m_parent.LastRaffleReturnCode == (int)RunPlayerRaffleReturnCode.RaffleInProgress)
                    throw new PlayerCenterException(Resources.RaffleInProgress);

                else
                {
                    // Get the player's picture
                    GetPlayerImageMessage getPicMsg = new GetPlayerImageMessage();
                    getPicMsg.PlayerId = m_parent.LastRafflePlayerId;

                    try
                    {
                        getPicMsg.Send();
                    }
                    catch (ServerCommException)
                    {
                        m_parent.ServerCommFailed();
                    }
                    catch (Exception ex)
                    {
                        throw new PlayerCenterException(string.Format(Resources.LoadPictureFailed, m_parent.FormatExceptionMessage(ex)), ex);
                    }

                    if (getPicMsg.Image != null)
                        PlayerImage = getPicMsg.Image;
                    else
                        PlayerImage = Resources.NoPic;

                    FirstName = m_parent.LastRafflePlayerFirstName;
                    LastName = m_parent.LastRafflePlayerLastName;
                    Comments = Resources.CurrentRaffleWinner;
                }
            }
            catch(ServerCommException)
            {
                m_parent.ServerCommFailed();
            }
            catch(Exception ex)
            {
                MessageForm.Show(m_displayMode, ex.Message);
            }
        }

        private void ClearRaffleClick(object sender, EventArgs e)
        {
            // Move the server message to their own thread.
            try
            {
                m_parent.ClearPlayerRaffle();
            }
            catch(ServerCommException)
            {
                m_parent.ServerCommFailed();
            }
            catch(Exception ex)
            {
                MessageForm.Show(m_displayMode, ex.Message);
            }
        }

        private void CloseClick(object sender, EventArgs e)
        {
            // Clear last results.
            m_parent.LastRaffleReturnCode = 0;
            m_parent.LastRafflePlayerId = 0;
            m_parent.LastRafflePlayerFirstName = string.Empty;
            m_parent.LastRafflePlayerLastName = string.Empty;

            // Close this form
            Close();
        }

        #endregion

        #region Member Properties

        /// <summary>
        /// Get or Set the Player's First Name.
        /// </summary>
        public string FirstName
        {
            get
            {
                return m_firstName.Text;
            }
            set
            {
                m_firstName.ReadOnly = false;
                m_firstName.Text = value;
                m_firstName.ReadOnly = true;
            }
        }

        /// <summary>
        /// Get or Set the Player's Last Name.
        /// </summary>
        public string LastName
        {
            get
            {
                return m_lastName.Text;
            }
            set
            {
                m_lastName.ReadOnly = false;
                m_lastName.Text = value;
                m_lastName.ReadOnly = true;
            }
        }

        /// <summary>
        /// Get or Set the Player's picture.
        /// </summary>
        public Bitmap PlayerImage
        {
            get
            {
                if (m_noPic.Image != null)
                    return (Bitmap)m_noPic.Image;
                else
                    return Resources.NoPic;
            }
            set
            {
                if (value != null)
                    m_noPic.Image = value;
                else
                    m_noPic.Image = Resources.NoPic;
            }
        }

        /// <summary>
        /// Get or Set the Player's comments
        /// </summary>
        public string Comments
        {
            get
            {
                return m_comments.Text;
            }
            set
            {
                m_comments.ReadOnly = false;
                m_comments.Text = value;
                m_comments.ReadOnly = true;
            }
        }

        #endregion

    }
}