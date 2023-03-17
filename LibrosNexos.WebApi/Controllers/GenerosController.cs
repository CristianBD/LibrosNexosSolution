using AutoMapper;
using LibrosNexos.Domain.Common;
using LibrosNexos.Infrastucture.ViewModel;
using LibrosNexos.Persistence.Context.IContext;
using LibrosNexos.Service.Contract;
using Microsoft.AspNetCore.Http;
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
                    Results = generos
                });
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
