using AutoSalon.DTO.CarsDTO.BYDDto;
using AutoSalon.DTO.CarsDTO.ChevroletDto;
using AutoSalonAPI.Reposiotry.CarRepository.BYDRepository;
using AutoSalonAPI.Reposiotry.CarRepository.ChevroletRepository;
using AutoSalonAPI.Service.CarService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AutoSalonAPI.Controllers.CarController
{
    [Route("api/[controller]")]
    [ApiController]
    public class ChevroletController : ControllerBase
    {
        private readonly ChevroletService _chevroletService;
        private readonly IChevroletRepository _chevroletRepository;
        public ChevroletController(ChevroletService chevroletService, IChevroletRepository chevroletRepository)
        {
            this._chevroletService = chevroletService;
            this._chevroletRepository = chevroletRepository;
        }
        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll(CancellationToken cancellationToken = default)
        {
            object result = await _chevroletService.GetAll(cancellationToken);
            return Ok(result);
        }
        [HttpGet("GetBy/{Id}")]
        public async Task<IActionResult> GetById([FromBody] ChevroletDtos chevroletDtos, CancellationToken cancellationToken = default)
        {
            object result = await _chevroletRepository.GetById(chevroletDtos.Id, cancellationToken);
            return Ok(result);
        }
        [HttpPost("Create")]
        public async Task<IActionResult> Create(ChevroletDtos chevroletDtos, CancellationToken cancellationToken = default)
        {
            var result = await _chevroletService.CreateAsync(chevroletDtos, cancellationToken);
            return Ok(result);
        }
        [HttpPut("Update/{Id}")]
        public async Task<IActionResult> Update([FromBody] ChevroletDtos chevroletDtos, long Id, CancellationToken cancellationToken = default)
        {
            var result = await _chevroletService.UpdateAsync(chevroletDtos, Id, cancellationToken);
            return Ok(result);
        }
        [HttpDelete("Delete")]
        public async Task<IActionResult> Delete(ChevroletDtos chevroletDtos, CancellationToken cancellationToken = default)
        {
            var result = await _chevroletService.Delete(chevroletDtos, cancellationToken);
            return Ok(result);
        }
    }
}
