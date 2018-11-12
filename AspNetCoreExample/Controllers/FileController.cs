using System;
using System.Collections.Generic;
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
    [Route("api/Files")]
    public class FilesController : Controller
    {
        private IMapper _mapper;
        private IUnitOfWork<NORTHWNDContext> _northwindUnitOfWork;

        public FilesController(IMapper mapper)
        {
            _mapper = mapper;
        }

        //[HttpPost]
        //public async Task<IActionResult> UploadFile([FromBody] FileUploadModel)
        //{
        //}

    }
}