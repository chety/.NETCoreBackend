using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Results
{
    public interface IResult
    {
        

        /// <summary>
        /// The process result is successfull or not
        /// </summary>
        bool Success { get; }

        /// <summary>
        /// Service result message
        /// </summary>
        string Message { get; }
    }
}
