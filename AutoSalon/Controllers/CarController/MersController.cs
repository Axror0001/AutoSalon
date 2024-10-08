using AutoSalon.DTO.CarsDTO.BYDDto;
using AutoSalon.DTO.CarsDTO.MersDto;
using AutoSalonAPI.Reposiotry.CarRepository.BYDRepository;
using AutoSalonAPI.Reposiotry.CarRepository.MersRepository;
using AutoSalonAPI.Service.CarService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AutoSalonAPI.Controllers.CarController
{
    [Route("api/[controller]")]
    [ApiController]
    public class MersController : ControllerBase
    {
        private readonly MersService _mersService;
        private readonly IMersRepository _mersRepository;
        public MersController(MersService mersService, IMersRepository mersRepository)
        {
            this._mersService = mersService;
            this._mersRepository = mersRepository;
        }
        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll(CancellationToken cancellationToken = default)
        {
            object result = await _mersService.GetAll(cancellationToken);
            return Ok(result);
        }
        [HttpGet("GetBy/{Id}")]
        public async Task<IActionResult> GetById([FromBody] MersDtos mersDtos, CancellationToken cancellationToken = default)
        {
            object result = await _mersRepository.GetById(mersDtos.Id, cancellationToken);
            return Ok(result);
        }
        [HttpPost("Create")]
        public async Task<IActionResult> Create(MersDtos mersDtos, CancellationToken cancellationToken = default)
        {
            var result = await _mersService.CreateAsync(mersDtos, cancellationToken);
            return Ok(result);
        }
        [HttpPut("Update/{Id}")]
        public async Task<IActionResult> Update([FromBody] MersDtos mersDtos, long Id, CancellationToken cancellationToken = default)
        {
            var result = await _mersService.UpdateAsync(mersDtos, Id, cancellationToken);
            return Ok(result);
        }
        [HttpDelete("Delete")]
        public async Task<IActionResult> Delete(MersDtos mersDtos, CancellationToken cancellationToken = default)
        {
            var result = await _mersService.Delete(mersDtos, cancellationToken);
            return Ok(result);
        }
    }
}
