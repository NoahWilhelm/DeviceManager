using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DeviceManager.Testing.Core.Mocks
{
    public class FormFileMock : IFormFile
    {
        public string ContentDisposition { get; }
        public string ContentType { get; }
        public string FileName { get; }
        public IHeaderDictionary Headers { get; }
        public long Length { get; }
        public string Name { get; }

        private readonly FileInfo sourceFile;

        public void CopyTo(Stream target)
        {
            throw new NotImplementedException();
        }

        public Task CopyToAsync(Stream target, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Stream OpenReadStream()
        {
            return sourceFile.OpenRead();
        }

        public FormFileMock(string contentType, FileInfo sourceFile) => (this.ContentType, this.sourceFile) = (contentType, sourceFile);

    }
}
