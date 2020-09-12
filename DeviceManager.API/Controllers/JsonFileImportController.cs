using DeviceManager.Core.DeviceImport.Abstractions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DeviceManager.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class JsonFileImportController : ControllerBase
    {
        private readonly IHttpContextAccessor httpContextAccessor;
        private readonly IDevicesFileImportService deviceFileImportService;

        public JsonFileImportController(IHttpContextAccessor httpContextAccessor, IDevicesFileImportService deviceFileImportService)
        {
            this.httpContextAccessor = httpContextAccessor;
            this.deviceFileImportService = deviceFileImportService;
        }

        [HttpPost]
        public async Task<IActionResult> Post()
        {
            var files = httpContextAccessor.HttpContext.Request.Form.Files;

            foreach (var file in files)
            {
                await deviceFileImportService.ImportByFormFileAsync(file);
            }

            return Ok();
        }

    }
}
