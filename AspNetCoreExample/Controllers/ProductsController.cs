using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AspNetCoreExample.Repository;
using AspNetCoreExample.SqlData.Northwind;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AspNetCoreExample.Controllers
{
    [Produces("application/json")]
    [Route("api/Products")]
    public class ProductsController : Controller
    {
        private NORTHWNDContext _context;
        private IMapper _mapper;
        private IRepository<Products> _productsRepository;

        public ProductsController(NORTHWNDContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
            //_productsRepository = productsRepository;
        }

        [HttpGet]
        public async Task<IActionResult> Get() {
            try
            {
                var products = _context.Products.Include(x => x.Category);
                // var categories = _context.Categories;
                // var repoProducts = new Repository<Products>(_context);
                // var products123 = repoProducts.GetAll();
                // var cat = _mapper.Map<SqlData.Northwind.Categories, Domain.Category>(categories.First());
                var domainProduct = _mapper.Map<IEnumerable<SqlData.Northwind.Products>, IEnumerable<Domain.Product>>(products);

                return Ok(domainProduct);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        } 

    }
}