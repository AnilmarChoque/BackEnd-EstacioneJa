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
    public class PagamentoController : ControllerBase
    {
        private readonly DataContext _context;

        public PagamentoController (DataContext context)
        {
            _context = context;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetSingle(int id)
        {
            try 
            {
                Pagamento u = await _context.Pagamentos
                    .FirstOrDefaultAsync(pBusca => pBusca.Id == id);
                return Ok(u);
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
                List<Pagamento> lista = await _context.Pagamentos.ToListAsync();
                return Ok (lista);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPost]
        public async Task<IActionResult> Add(Pagamento novoPagamento)
        {
            try
            {
                await _context.Pagamentos.AddAsync(novoPagamento);
                await _context.SaveChangesAsync();

                return Ok (novoPagamento.Id);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPut]
        public async Task<IActionResult> Update(Pagamento novoPagamento)
        {
            try{
                _context.Pagamentos.Update(novoPagamento);
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
                Pagamento pRemover = await _context.Pagamentos.FirstOrDefaultAsync(p => p.Id == id);

                _context.Pagamentos.Remove(pRemover);
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