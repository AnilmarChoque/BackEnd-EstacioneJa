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
    public class VagaController : ControllerBase
    {
        private readonly DataContext _context;

        public VagaController (DataContext context)
        {
            _context = context;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetSingle(int id)
        {
            try 
            {
                Vaga v = await _context.Vagas
                    .FirstOrDefaultAsync(vBusca => vBusca.Id == id);
                return Ok(v);
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
                List<Vaga> lista = await _context.Vagas.ToListAsync();
                return Ok (lista);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPost]
        public async Task<IActionResult> Add(Vaga novoVaga)
        {
            try
            {
                await _context.Vagas.AddAsync(novoVaga);
                await _context.SaveChangesAsync();

                return Ok (novoVaga.Id);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPut]
        public async Task<IActionResult> Update(Vaga novoVaga)
        {
            try{
                _context.Vagas.Update(novoVaga);
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
                Vaga vRemover = await _context.Vagas.FirstOrDefaultAsync(v => v.Id == id);

                _context.Vagas.Remove(vRemover);
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