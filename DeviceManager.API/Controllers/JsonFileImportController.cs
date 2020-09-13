using DeviceManager.Core.DeviceImport.Abstractions;
using DeviceManager.Core.DeviceImport.Exceptions;
using DeviceManager.Core.Devices.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DeviceManager.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
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

            var resultDevices = new List<Device>();
            IFormFileCollection files;

            try
            {
                files = httpContextAccessor.HttpContext.Request.Form.Files;
            }
            catch (InvalidOperationException ex)
            {
                return BadRequest(ex.Message);
            }
            

            foreach (var file in files)
            {
                try
                {
                    var newDevices = await deviceFileImportService.ImportByFormFileAsync(file);
                    resultDevices.AddRange(newDevices);
                }
                catch (InvalidImportFileTextException ex)
                {
                    return BadRequest(ex.Message);
                }
            }

            return Ok(resultDevices);
        }

    }
}
