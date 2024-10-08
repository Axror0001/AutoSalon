using AutoSalon.DTO.CarsDTO.BYDDto;
using AutoSalonAPI.Reposiotry.CarRepository.BYDRepository;
using AutoSalonAPI.Service.CarService;
using Microsoft.AspNetCore.Mvc;

namespace AutoSalonAPI.Controllers.CarController
{
    [Route("api/[controller]")]
    [ApiController]
    public class BYDController : ControllerBase
    {
        private readonly BydService _bydService;
        private readonly IBydRepository _bydRepository;
        public BYDController(BydService bydService, IBydRepository bydRepository)
        {
            this._bydService = bydService;
            this._bydRepository = bydRepository;
        }
        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll(CancellationToken cancellationToken = default)
        {
            object result = await _bydService.GetAll(cancellationToken);
            return Ok(result);
        }
        [HttpGet("GetBy/{Id}")]
        public async Task<IActionResult> GetById([FromBody] BydDtos bydDtos, CancellationToken cancellationToken = default)
        {
            object result = await _bydRepository.GetById(bydDtos.Id, cancellationToken);
            return Ok(result);
        }
        [HttpPost("Create")]
        public async Task<IActionResult> Create(BydDtos bydDtos, CancellationToken cancellationToken = default)
        {
            var result = await _bydService.CreateAsync(bydDtos, cancellationToken);
            return Ok(result);
        }
        [HttpPut("Update/{Id}")]
        public async Task<IActionResult> Update([FromBody]BydDtos bydDtos, long Id, CancellationToken cancellationToken = default)
        {
            var result = await _bydService.UpdateAsync(bydDtos, Id, cancellationToken);
            return Ok(result);
        }
        [HttpDelete("Delete")]
        public async Task<IActionResult> Delete(BydDtos bydDtos, CancellationToken cancellationToken = default)
        {
            var result = await _bydService.Delete(bydDtos, cancellationToken);
            return Ok(result);
        }
    }
}
