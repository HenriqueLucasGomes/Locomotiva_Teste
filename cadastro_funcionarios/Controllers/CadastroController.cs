using System.Threading.Tasks;
using api.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using api.Models;

namespace api.Controllers
{
    [Controller]
    [Route("[controller]")]
    public class ModelosController : ControllerBase
    {
        
        private DataContext dc;

        public ModelosController(DataContext context)
        {
            this.dc=context;
        }

        [HttpPost("CadEqup")]
        public async Task<ActionResult> cadastrarEquipe([FromBody] Equipes e)
        {
            dc.equipes.Add(e);
            await dc.SaveChangesAsync();

            return Created("",e);
        }

        [HttpPost("CadFunc")]
        public async Task<ActionResult> cadastrarFuncionario([FromBody] Equipes e)
        {
            dc.equipes.Add(e);
            await dc.SaveChangesAsync();

            return Created("",e);
        }
        
        [HttpGet("ListEqup")]
        public async Task<ActionResult> listarEquipes()
        {
            
            var dados=await dc.equipes.ToListAsync();
            return Ok(dados);
        }

        [HttpGet("ListFunc")]
        public async Task<ActionResult> listarFuncionarios()
        {
            var dados=await dc.equipes.ToListAsync();
            return Ok(dados);
        }
    }

}