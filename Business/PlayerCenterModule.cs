#region Copyright
// This is an unpublished work protected under the copyright laws of the
// United States and other countries.  All rights reserved.  Should
// publication occur the following will apply:  © 2008 GameTech
// International, Inc.
#endregion

using System;
using System.Threading;
using System.Globalization;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using GTI.Modules.Shared;
using GTI.Modules.PlayerCenter.Properties;

namespace GTI.Modules.PlayerCenter.Business
{
    /// <summary>
    /// The implementation of the IGTIModule COM interface for player 
    /// management.
    /// Command Line: -guid={BF874654-BCEC-4c87-996A-55F4789F1EAA} -server=GTISERVERLATIN -window
    /// </summary>
    [
        ComVisible(true),
        Guid("BF874654-BCEC-4c87-996A-55F4789F1EAA"),
        ClassInterface(ClassInterfaceType.None),
        ComSourceInterfaces(typeof(_IGTIModuleEvents)),
        ProgId("GTI.Modules.PlayerCenter.PlayerCenterModule")
    ]
    public sealed class PlayerCenterModule : IGTIModule
    {
        #region Constants
        private const string ModuleName = "GameTech Edge Bingo System Player Center Module"; // FIX: TA5079, TA8833
        #endregion

        #region Events
        /// <summary>
        /// The signature of the 'Stopped' COM connection point handler.
        /// </summary>
        /// <param name="moduleId">The id of the stopped module.</param>
        public delegate void IGTIModuleStoppedEventHandler(int moduleId);

        /// <summary>
        /// The event that will translate to the COM connection point.
        /// </summary>
        public event IGTIModuleStoppedEventHandler Stopped;

        /// <summary>
        /// Occurs when something wants the module to stop itself.
        /// </summary>
        internal event EventHandler StopPlayerCenter;

        /// <summary>
        /// Occurs when something wants player center to come to the front 
        /// of the screen.
        /// </summary>
        internal event EventHandler BringToFront;

        // PDTS 966
        /// <summary>
        /// Occurs when a server initiated message was received from the 
        /// server.
        /// </summary>
        internal event MessageReceivedEventHandler ServerMessageReceived; 
        #endregion

        #region Member Variables
        private object m_syncRoot = new object();
        private int m_moduleId = 0;
        private static bool m_isStopped = true;
        private Thread m_playerThread = null;
        #endregion

        #region Member Methods
        /// <summary>
        /// Starts the module.  If the module is already started nothing
        /// happens.  This method will block if another thread is currently
        /// executing it.
        /// </summary>
        /// <param name="moduleId">The id to be given to the module.</param>
        public void StartModule(int moduleId)
        {
            lock(m_syncRoot)
            {
                // Don't start again if we are already started.
                if(!m_isStopped)
                    return;

                // Assign the id.
                m_moduleId = moduleId;

                // Create a thread to run the module.
                m_playerThread = new Thread(Run);

                // Change the thread regional settings to the current OS 
                // globalization info.
                m_playerThread.CurrentUICulture = CultureInfo.CurrentCulture;

                // Rally US144
                // Make the thread a single threaded apartment for Crystal Reports.
                m_playerThread.SetApartmentState(ApartmentState.STA);

                // Start it.
                m_playerThread.Start();

                // Mark the module as started.
                m_isStopped = false;
            }
        }

        /// <summary>
        /// Creates the PlayerManager object and blocks until the module is 
        /// told to close or the user closes the it.
        /// </summary>
        private void Run()
        {
            PlayerManager playerManager = null;

            try
            {
                // Create and initialize new PlayerCenter object.
                playerManager = new PlayerManager(this);
                // FIX: DE2476
                playerManager.Initialize(true, false);
                // END: DE2476

                // Listen for the event where something wants the module to stop.
                StopPlayerCenter += new EventHandler(playerManager.ClosePlayerCenter);
                BringToFront += new EventHandler(playerManager.BringToFront);

                if(playerManager.IsInitialized)
                {
                    playerManager.Start(); // Show the module and block.
                    //bool test = false;
                    //GTI.Modules.Shared.Player p = new GTI.Modules.Shared.Player();
                    //playerManager.ShowPlayerManagment(out test, out p);
                }
            }
            catch(Exception e)
            {
                MessageBox.Show(string.Format(Resources.PlayerCenterError, e.Message + "\n" + e.StackTrace), Resources.PlayerCenterName);
            }
            finally
            {
                try
                {
                    // Shutdown the module.
                    if(playerManager != null)
                    {
                        playerManager.Shutdown();
                        playerManager = null;
                    }

                    OnStop();
                }
                catch
                {
                }

                lock(m_syncRoot)
                {
                    // Mark the module as stopped.
                    m_isStopped = true;
                }
            }
        }

        /// <summary>
        /// This method blocks until the module is stopped.  If the module is 
        /// already stopped nothing happens.
        /// </summary>
        public void StopModule()
        {
            if(m_playerThread != null)
            {
                // Send the stop event to module's controller.
                EventHandler stopHandler = StopPlayerCenter;

                if(stopHandler != null)
                    stopHandler(this, new EventArgs());

                m_playerThread.Join();
            }
        }

        /// <summary>
        /// Signals the COM connection point that we have stopped.
        /// </summary>
        internal void OnStop()
        {
            IGTIModuleStoppedEventHandler handler = Stopped;

            if(handler != null)
                handler(m_moduleId);
        }

        /// <summary>
        /// Returns the name of this GTI module.
        /// </summary>
        /// <returns>The module's name.</returns>
        public string QueryModuleName()
        {
            return ModuleName;
        }

        /// <summary>
        /// Tells the module to bring itself to the front of the screen.
        /// </summary>
        public void ComeToFront()
        {
            EventHandler handler = BringToFront;

            if (handler != null)
                handler(this, new EventArgs());
        }

        // PDTS 966
        /// <summary>
        /// Tells the module that a server initiated message was received.
        /// </summary>
        /// <param name="commandId">The id of the message received.</param>
        /// <param name="messageData">The payload data of the message or null 
        /// if the message has no data.</param>
        public void MessageReceived(int commandId, object msgData)
        {
            MessageReceivedEventArgs args = new MessageReceivedEventArgs(commandId, msgData);

            MessageReceivedEventHandler handler = ServerMessageReceived;

            if(handler != null)
                handler(this, args);
        }
        #endregion
    }
}
