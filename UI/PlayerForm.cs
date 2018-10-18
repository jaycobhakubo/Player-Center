#region Copyright
// This is an unpublished work protected under the copyright laws of the
// United States and other countries.  All rights reserved.  Should
// publication occur the following will apply:  © 2008 GameTech
// International, Inc.
#endregion

using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using GTI.Modules.Shared;
using GTI.Modules.PlayerCenter.Business;
using System.ComponentModel;

namespace GTI.Modules.PlayerCenter.UI
{
    /// <summary>
    /// The base class from which all player center forms should derive.
    /// </summary>
    internal partial class PlayerForm : EliteGradientForm
    {
        #region Member Variables
        protected PlayerManager m_parent;
        //US3407
        //Let us add a gradient properties to this form 
        protected bool m_drawGradient = true;
        protected LinearGradientMode m_gradientMode = LinearGradientMode.Vertical;
        protected Color m_beginColor = Color.FromArgb(156, 179, 213);
        protected Color m_endColor = Color.FromArgb(184, 186, 192);

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

           // SetStyle(ControlStyles.ResizeRedraw, true); //US3407
            InitializeComponent();

            m_parent = parent;
        }
        #endregion

        //US3407
        //#region Member Methods
        ///// <summary>
        ///// Handles the Form's paint background event.
        ///// </summary>
        ///// <param name="e">An PaintEventArgs object that contains the 
        ///// event data.</param>
        //protected override void OnPaintBackground(PaintEventArgs e)
        //{
        //    base.OnPaintBackground(e);

        //    if (m_drawGradient && ClientRectangle.Width > 0 && ClientRectangle.Height > 0)
        //    {
        //        LinearGradientBrush brush = new LinearGradientBrush(ClientRectangle, m_beginColor, m_endColor, m_gradientMode);
        //        e.Graphics.FillRectangle(brush, ClientRectangle);
        //    }
        //}


        //#endregion

        //#region Member Properties
        ///// <summary>
        ///// Gets or sets whether to draw the gradient background.
        ///// </summary>
        //[Description("Whether to draw the gradient background.")]
        //[Category("Appearance")]
        //[DefaultValue(true)]
        public bool DrawGradient
        {
            get
            {
                return m_drawGradient;
            }
            set
            {
                m_drawGradient = value;
                Invalidate();
            }
        }

        ///// <summary>
        ///// Gets or sets the background gradient's mode.
        ///// </summary>
        //[Description("The background gradient's mode.")]
        //[Category("Appearance")]
        //[DefaultValue(LinearGradientMode.Vertical)]
        public LinearGradientMode GradientMode
        {
            get
            {
                return m_gradientMode;
            }
            set
            {
                m_gradientMode = value;
                Invalidate();
            }
        }

        ///// <summary>
        ///// Gets or sets the gradient's start color.
        ///// </summary>
        //[Description("The background gradient's start color.")]
        //[Category("Appearance")]
        public Color GradientBeginColor
        {
            get
            {
                return m_beginColor;
            }
            set
            {
                m_beginColor = value;
                Invalidate();
            }
        }

        ///// <summary>
        ///// Gets or sets the gradient's end color.
        ///// </summary>
        //[Description("The background gradient's end color.")]
        //[Category("Appearance")]
        public Color GradientEndColor
        {
            get
            {
                return m_endColor;
            }
            set
            {
                m_endColor = value;
                Invalidate();
            }
        }
        //#endregion


    }
}