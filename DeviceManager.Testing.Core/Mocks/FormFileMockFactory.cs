using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace DeviceManager.Testing.Core.Mocks
{
    public static class FormFileMockFactory
    {

        public static IFormFile CreateFormFileByFileInfo(string contentType, FileInfo fileInfo)
        {
            return new FormFileMock(contentType, fileInfo);
        }

    }
}
