#region Copyright
// This is an unpublished work protected under the copyright laws of the
// United States and other countries.  All rights reserved.  Should
// publication occur the following will apply:  © 2008 GameTech
// International, Inc.
#endregion

// Rally US144

using System;
using System.Windows.Forms;
using System.Globalization;
using System.ComponentModel;
using CrystalDecisions.CrystalReports.Engine;
using GTI.Modules.Shared;
using GTI.Modules.PlayerCenter.Business;
using GTI.Modules.PlayerCenter.Properties;

namespace GTI.Modules.PlayerCenter.UI
{
    public partial class ReportForm : GradientForm
    {
        #region Member Variables
        protected PlayerManager m_parent;
        #endregion

        #region Constructors
        /// <summary>
        /// Initializes a new instance of the ReportForm class.
        /// </summary>
        /// <param name="parent">The PlayerManager to which this form 
        /// belongs.</param>
        public ReportForm(PlayerManager parent)
        {
            if(parent == null)
                throw new ArgumentNullException("parent");

            m_parent = parent;

            InitializeComponent();
        }
        #endregion

        #region Member Methods
        /// <summary>
        /// Handles the close menu item's click event.
        /// </summary>
        /// <param name="sender">The sender of the event.</param>
        /// <param name="e">An EventArgs object that contains the
        /// event data.</param>
        private void CloseClick(object sender, EventArgs e)
        {
            // Just make the form invisible.
            Hide();
        }
        #endregion

        #region Member Properties
        /// <summary>
        /// Gets or sets the report to be viewed on this form.
        /// </summary>
        public ReportDocument Report
        {
            get
            {
                return (ReportDocument)m_reportViewer.ReportSource;
            }
            set
            {
                m_reportViewer.ReportSource = value;
                m_reportViewer.Zoom(1);
            }
        }
        #endregion
    }
}
