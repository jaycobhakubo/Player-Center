#region Copyright
// This is an unpublished work protected under the copyright laws of the
// United States and other countries.  All rights reserved.  Should
// publication occur the following will apply:  © 2008 GameTech
// International, Inc.
#endregion

using System;
using GTI.Modules.Shared;

namespace GTI.Modules.PlayerCenter.Business
{
    /// <summary>
    /// The exception that is thrown when a non-fatal POS error occurs.
    /// </summary>
    public class PlayerCenterException : ModuleException
    {
        #region Constructors
        /// <summary>
        /// Initializes a new instance of the PlayerCenterException class.
        /// </summary>
        public PlayerCenterException()
            : base()
        {
        }

        /// <summary>
        /// Initializes a new instance of the PlayerCenterException class with 
        /// a specified error message.
        /// </summary>
        /// <param name="message">A message that describes the error.</param>
        public PlayerCenterException(string message)
            : base(message)
        {
        }

        /// <summary>
        /// Initializes a new instance of the PlayerCenterException class with 
        /// a specified error message and a reference to the inner exception 
        /// that is the cause of this exception.
        /// </summary>
        /// <param name="message">A message that describes the error.</param>
        /// <param name="innerException">The exception that is the cause of 
        /// the current exception. If the innerException parameter is not a 
        /// null reference, the current exception is raised in a catch block 
        /// that handles the inner exception.</param>
        public PlayerCenterException(string message, Exception innerException)
            : base(message, innerException)
        {
        }
        #endregion
    }

    internal class DuplicateException : ModuleException
    {

        internal DuplicateException(string message)
            : base(message + "Duplicate Record has been found")
        { }
    }
}