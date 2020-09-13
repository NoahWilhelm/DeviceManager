using DeviceManager.Core.Devices.Abstractions;
using DeviceManager.Core.Devices.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace DeviceManager.API.Controllers
{
    [Produces("application/json")]
    [ApiController]
    [Route("api/[controller]")]
    public class DevicesController : ControllerBase
    {

        private readonly IDevicesRepository devicesRepository;

        public DevicesController(IDevicesRepository devicesRepository)
        {
            this.devicesRepository = devicesRepository;
        }

        ///<summary>
        ///Returns a list of all devices or requested device
        ///</summary>
        [HttpGet("{id?}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Get(int? id = null)
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

        ///<summary>
        ///Deletes specific device
        /// </summary>
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Delete(int id)
        {

            var device = await devicesRepository.FindByIdAsync(id);
            devicesRepository.Remove(device);
            
            await devicesRepository.CommitAsync();

            return Ok();

        }

        ///<summary>
        ///Edits device
        ///</summary>
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Put(int id, [FromBody] Device model)
        {

            var findDevice = await this.devicesRepository.FindByIdAsync(id);

            if (findDevice == null) return NotFound("Device does not exist");

            var device = devicesRepository.Update(model);
            await devicesRepository.CommitAsync();

            return Ok(device);

        }

    }
}
