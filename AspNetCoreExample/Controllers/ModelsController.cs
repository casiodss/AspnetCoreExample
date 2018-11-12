using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AspNetCoreExample.Repository;
using AspNetCoreExample.SqlData.Northwind;
using AspNetCoreExample.SqlData.Vega;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AspNetCoreExample.Controllers
{
    [Produces("application/json")]
    [Route("api/Models")]
    public class ModelsController : Controller
    {
        private IMapper _mapper;
        private IUnitOfWork<VEgaContext> _vegaUnitOfWork;

        public ModelsController(IMapper mapper, IUnitOfWork<VEgaContext> vegaUnitOfWork)
        {
            _mapper = mapper;
            _vegaUnitOfWork = vegaUnitOfWork;
        }

        [HttpGet]
        public async Task<IActionResult> Get() {
            try
            {
                var models = _vegaUnitOfWork.Repository<SqlData.Vega.Models>().GetAll().Include(x => x.Make);
                var mapped = _mapper.Map<IEnumerable<SqlData.Vega.Models>, IEnumerable<Domain.Vega.Models>>(models);
                return Ok(mapped);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

    }
}