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
    public class SensorController : ControllerBase
    {
        private readonly DataContext _context;

        public SensorController (DataContext context)
        {
            _context = context;
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetSingle(int id)
        {
            try 
            {
                Sensor s = await _context.Sensores
                    .FirstOrDefaultAsync(sBusca => sBusca.Id == id);
                return Ok(s);
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
                List<Sensor> lista = await _context.Sensores.ToListAsync();
                return Ok (lista);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPost]
        public async Task<IActionResult> Add(Sensor novoSensor)
        {
            try
            {
                await _context.Sensores.AddAsync(novoSensor);
                await _context.SaveChangesAsync();

                return Ok (novoSensor.Id);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPut]
        public async Task<IActionResult> Update(Sensor novoSensor)
        {
            try{
                _context.Sensores.Update(novoSensor);
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
                Sensor sRemover = await _context.Sensores.FirstOrDefaultAsync(s => s.Id == id);

                _context.Sensores.Remove(sRemover);
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