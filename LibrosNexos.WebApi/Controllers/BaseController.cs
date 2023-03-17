using AutoMapper;
using LibrosNexos.Persistence.Context.IContext;
using LibrosNexos.Service.Contract;
using Microsoft.AspNetCore.Mvc;

namespace LibrosNexos.WebApi.Controllers
{
    public class BaseController : ControllerBase
    {
        protected readonly ILibrosNexosContext _context;
        protected readonly IRepositoryManager _repositoryManager;
        protected readonly IMapper _mapper;

        public BaseController(ILibrosNexosContext context, IRepositoryManager repository, IMapper mapper)
        {
            _context = context;
            _repositoryManager = repository;
            _mapper = mapper;
        }
    }
}
