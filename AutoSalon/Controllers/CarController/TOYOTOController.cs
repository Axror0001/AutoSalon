using AutoSalon.DTO.CarsDTO.BYDDto;
using AutoSalon.DTO.CarsDTO.ToyotoDto;
using AutoSalonAPI.Reposiotry.CarRepository.BYDRepository;
using AutoSalonAPI.Reposiotry.CarRepository.ToyotoRepository;
using AutoSalonAPI.Service.CarService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AutoSalonAPI.Controllers.CarController
{
    [Route("api/[controller]")]
    [ApiController]
    public class ToyotoController : ControllerBase
    {
        private readonly ToyotoService _toyotoService;
        private readonly IToyotoRepository _toyotoRepository;
        public ToyotoController(ToyotoService toyotoService, IToyotoRepository toyotoRepository)
        {
            this._toyotoRepository = toyotoRepository;
            this._toyotoService = toyotoService;
        }
        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll(CancellationToken cancellationToken = default)
        {
            object result = await _toyotoService.GetAll(cancellationToken);
            return Ok(result);
        }
        [HttpGet("GetBy/{Id}")]
        public async Task<IActionResult> GetById([FromBody] ToyotoDtos ToyotoDtos, CancellationToken cancellationToken = default)
        {
            object result = await _toyotoRepository.GetById(ToyotoDtos.Id, cancellationToken);
            return Ok(result);
        }
        [HttpPost("Create")]
        public async Task<IActionResult> Create(ToyotoDtos ToyotoDtos, CancellationToken cancellationToken = default)
        {
            var result = await _toyotoService.CreateAsync(ToyotoDtos, cancellationToken);
            return Ok(result);
        }
        [HttpPut("Update/{Id}")]
        public async Task<IActionResult> Update([FromBody] ToyotoDtos ToyotoDtos, long Id, CancellationToken cancellationToken = default)
        {
            var result = await _toyotoService.UpdateAsync(ToyotoDtos, Id, cancellationToken);
            return Ok(result);
        }
        [HttpDelete("Delete")]
        public async Task<IActionResult> Delete(ToyotoDtos ToyotoDtos, CancellationToken cancellationToken = default)
        {
            var result = await _toyotoService.Delete(ToyotoDtos, cancellationToken);
            return Ok(result);
        }
    }
}
