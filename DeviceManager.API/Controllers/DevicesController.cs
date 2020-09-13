using DeviceManager.Core.Devices.Abstractions;
using DeviceManager.Core.Devices.Models;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace DeviceManager.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class DevicesController : ControllerBase
    {

        private readonly IDevicesRepository devicesRepository;

        public DevicesController(IDevicesRepository devicesRepository)
        {
            this.devicesRepository = devicesRepository;
        }

        [HttpGet("{id?}")]
        public async Task<IActionResult> Get(int? id)
        {
            if (!id.HasValue)
            {
                var allDevices = await devicesRepository.GetAllAsync();
                return Ok(allDevices);
            } else
            {
                var findDevice = await devicesRepository.FindByIdAsync(id.Value);

                if (findDevice == null)
                    return NotFound("This device does not exist!");

                return Ok(findDevice);
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int? id)
        {

            var device = await devicesRepository.FindByIdAsync(id.Value);
            devicesRepository.Remove(device);
            
            await devicesRepository.CommitAsync();

            return Ok();

        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] Device model)
        {

            var device = devicesRepository.Update(model);
            await devicesRepository.CommitAsync();

            return Ok(device);

        }

    }
}
