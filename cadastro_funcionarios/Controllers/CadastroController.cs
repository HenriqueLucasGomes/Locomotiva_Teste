using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using api.Models;
using api.Data;

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
        public async Task<ActionResult> cadastrarFuncionario([FromBody] Funcionarios f)
        {
            if(f.Email==""){
                return Problem("Campo 'Email' se encontra vazio","",500,"Email Vazio","Inconsistência no Registro");
            }else if(new EmailAddressAttribute().IsValid(f.Email)){
                dc.funcionarios.Add(f);
                await dc.SaveChangesAsync();
                return Created("",f);                
            }
            else{
                return Problem("Formato de Email fora do padrão","",500,"Email Inválido","Inconsistência no Registro");
            }
           
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
            var dados=await dc.funcionarios.ToListAsync();
            return Ok(dados);
        }
    }

}