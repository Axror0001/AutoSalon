using AutoSalon.DTO.CarsDTO.BmwDto;
using AutoSalonAPI.Reposiotry.CarRepository.BmwRepository;
using AutoSalonAPI.Service.CarService;
using Microsoft.AspNetCore.Mvc;

namespace AutoSalonAPI.Controllers.CarController
{

    [Route("api/[controller]")]
    [ApiController]
    public class BMWController : ControllerBase
    {
        private readonly BmwService _bmwService;
        private readonly IBmwRepository _bmwRepository;
        public BMWController(BmwService bmwService, IBmwRepository bmwRepository)
        {
            this._bmwService = bmwService;
            this._bmwRepository = bmwRepository;
        }
        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            var result = await _bmwService.GetAll();
            return Ok(result);
        }
        [HttpGet("GetBy/{Id}")]
        public async Task<IActionResult> GetById([FromBody] BmwDTOs bmwDtos)
        {
            var result = await _bmwRepository.GetById(bmwDtos.Id);
            return Ok(result);
        }
        [HttpPut("GetBy{Id}")]
        public async Task<IActionResult> Update(BmwDTOs bmwDtos, long Id, CancellationToken cancellationToken = default)
        {
            var result = await _bmwService.UpdateAsync(bmwDtos, Id, cancellationToken);
            return Ok(result);
        }
        [HttpPost("Create")]
        public async Task<IActionResult> Create( BmwDTOs bmwDtos, long Id, CancellationToken cancellationToken = default)
        {
            var result = await _bmwService.CreateAsync(bmwDtos, cancellationToken);
            return Ok(result);
        }
        [HttpDelete("Delete")]
        public async Task<IActionResult> Delete(BmwDTOs bmwDtos, CancellationToken cancellationToken = default)
        {
            var result = await _bmwService.Delete(bmwDtos, cancellationToken);
            return Ok(result);
        }
    }
}
