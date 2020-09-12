using System;
using System.Collections.Generic;
using System.Text;

namespace DeviceManager.Core.DeviceImport.Exceptions
{
    public class InvalidImportFileTextException : Exception
    {

        public InvalidImportFileTextException(string message) : base(message) {}

        public InvalidImportFileTextException(string message, Exception innerException) : base(message, innerException) { }

    }
}
