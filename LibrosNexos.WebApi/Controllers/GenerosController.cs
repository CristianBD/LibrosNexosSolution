using AutoMapper;
using LibrosNexos.Domain.Common;
using LibrosNexos.Infrastucture.ViewModel;
using LibrosNexos.Persistence.Context.IContext;
using LibrosNexos.Service.Contract;
using Microsoft.AspNetCore.Mvc;

namespace LibrosNexos.WebApi.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class GenerosController : BaseController
    {
        public GenerosController(ILibrosNexosContext context, IRepositoryManager repository, IMapper mapper) : base(context, repository, mapper)
        {
        }

        [HttpGet("GetGeneros")]
        public async Task<IActionResult> GetGeneros()
        {
            try
            {
                var generos = _mapper.Map<List<GeneroViewModel>>(await _repositoryManager.GenerosRepository.ObtenerGeneros());
                return Ok(new ResponseCommon<GeneroViewModel>
                {
                    Success = true,
                    Results = generos,
                    Message = "Exito."
                });
            }
            catch (Exception)
            {

                throw;
            }
        }

        [HttpPost("CreateGenero")]
        public async Task<IActionResult> CreateGenero(string genero)
        {
            try
            {
                var result = await _repositoryManager.GenerosRepository.CreateGenero(genero);
                return Ok(new ResponseCommon<bool>
                {
                    Success = true,
                    Result = result
                });
            }
            catch (Exception)
            {

                throw;
            }
        }

        [HttpPost("DeleteGenero")]

        public async Task<IActionResult> DeleteGenero(int? id, string? nombre)
        {
            var result = await _repositoryManager.GenerosRepository.DeleteGenero(id, nombre);
            return Ok(new ResponseCommon<bool>
            {
                Success = true,
                Result = result
            });
        }
    }
}
