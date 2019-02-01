#region Copyright
// This is an unpublished work protected under the copyright laws of the
// United States and other countries.  All rights reserved.  Should
// publication occur the following will apply:  © 2008 GameTech
// International, Inc.
#endregion

using System;
using System.Drawing;
using System.Windows.Forms;
using GTI.Modules.Shared;
using GTI.Modules.PlayerCenter.Business;

namespace GTI.Modules.PlayerCenter.UI
{
    /// <summary>
    /// The base class from which all player center forms should derive.
    /// </summary>
    internal partial class PlayerForm : EliteGradientForm
    {
        #region Member Variables
        protected PlayerManager m_parent;
        #endregion

        #region Constructors
        /// <summary>
        /// Initalizes a new instance of the POSForm class.
        /// Required method for Designer support.
        /// </summary>
        private PlayerForm()
        {
        }

        /// <summary>
        /// Initalizes a new instance of the POSForm class.
        /// </summary>
        /// <param name="parent">The PlayerManager to which this form 
        /// belongs.</param>
        /// <param name="displayMode">The display mode used to show this 
        /// form.</param>
        public PlayerForm(PlayerManager parent, DisplayMode displayMode)
            : base(displayMode)
        {
            if(parent == null)
                throw new ArgumentNullException("parent");

            InitializeComponent();

            m_parent = parent;
        }
        #endregion
    }
}