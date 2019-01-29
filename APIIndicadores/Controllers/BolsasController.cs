using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using APIIndicadores.Data;
using APIIndicadores.Models;

namespace APIIndicadores.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BolsasController : ControllerBase
    {
        [HttpGet]
        public List<BolsaValores> Get(
            [FromServices]ApplicationDbContext context)
        {
            return (from b in context.BolsasValores
                    select b).ToList();
        }
    }
}