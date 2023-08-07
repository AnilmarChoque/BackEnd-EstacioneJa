using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using EstacioneJa.Data;
using EstacioneJa.Models;
using Microsoft.EntityFrameworkCore;

namespace EstacioneJa.Controllers
{
    [ApiController]
    [Route("[Controller]")]
    public class OcupacaoVagaController : ControllerBase
    {
        private readonly DataContext _context;

        public OcupacaoVagaController (DataContext context)
        {
            _context = context;
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetSingle(int id)
        {
            try 
            {
                OcupacaoVaga o = await _context.OcupacaoVagas
                    .FirstOrDefaultAsync(oBusca => oBusca.Id == id);
                return Ok(o);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("GetAll")]
        public async Task<IActionResult> Get()
        {
            try
            {
                List<OcupacaoVaga> lista = await _context.OcupacaoVagas.ToListAsync();
                return Ok (lista);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPost]
        public async Task<IActionResult> Add(OcupacaoVaga novoOcupacaoVaga)
        {
            try
            {
                await _context.OcupacaoVagas.AddAsync(novoOcupacaoVaga);
                await _context.SaveChangesAsync();

                return Ok (novoOcupacaoVaga.Id);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPut]
        public async Task<IActionResult> Update(OcupacaoVaga novoOcupacaoVaga)
        {
            try{
                _context.OcupacaoVagas.Update(novoOcupacaoVaga);
                int linhasAfetadas = await _context.SaveChangesAsync();

                return Ok (linhasAfetadas);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                OcupacaoVaga oRemover = await _context.OcupacaoVagas.FirstOrDefaultAsync(o => o.Id == id);

                _context.OcupacaoVagas.Remove(oRemover);
                int linhasAfetadas = await _context.SaveChangesAsync();
                return Ok (linhasAfetadas);
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}