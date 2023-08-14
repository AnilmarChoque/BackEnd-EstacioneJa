using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using EstacioneJa.Data;
using EstacioneJa.Models;
using Microsoft.EntityFrameworkCore;
using EstacioneJa.Utils;

namespace EstacioneJa.Controllers
{
    [ApiController]
    [Route("[Controller]")]
    public class UsuarioController : ControllerBase
    {
        private readonly DataContext _context;

        public UsuarioController (DataContext context)
        {
            _context = context;
        }

        private async Task<bool> UsuarioExistente(string nome)
        {
            if (await _context.Usuarios.AnyAsync(x => x.Nome.ToLower() == nome.ToLower()))
            {
                return true;
            }
            return false;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetSingle(int id)
        {
            try 
            {
                Usuario u = await _context.Usuarios
                    .FirstOrDefaultAsync(uBusca => uBusca.Id == id);
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
                List<Usuario> lista = await _context.Usuarios.ToListAsync();
                return Ok (lista);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPost]
        public async Task<IActionResult> Add(Usuario novoUsuario)
        {
            try
            {
                await _context.Usuarios.AddAsync(novoUsuario);
                await _context.SaveChangesAsync();

                return Ok (novoUsuario.Id);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPut]
        public async Task<IActionResult> Update(Usuario novoUsuario)
        {
            try{_context.Usuarios.Update(novoUsuario);
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
                Usuario uRemover = await _context.Usuarios.FirstOrDefaultAsync(u => u.Id == id);

                _context.Usuarios.Remove(uRemover);
                int linhasAfetadas = await _context.SaveChangesAsync();
                return Ok (linhasAfetadas);
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPost("Registrar")]
        public async Task<IActionResult> RegistrarUsuario(Usuario user)
        {
            try
            {
                if(await UsuarioExistente(user.Nome))
                {
                    throw new System.Exception("Nome já existe");
                }
                Criptografia.CriarSenhaHash(user.Senha, out byte[] hash, out byte[] salt);
                user.Senha = string.Empty;
                user.SenhaHash = hash;
                user.SenhaSalt = salt;
                await _context.Usuarios.AddAsync(user);
                await _context.SaveChangesAsync();

                return Ok(user.Id);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("Autenticar")]
        public async Task<IActionResult> AutenticarUsuario(Usuario credenciais)
        {
            try
            {
                Usuario usuario = await _context.Usuarios
                .FirstOrDefaultAsync(x => x.Nome.ToLower().Equals(credenciais.Nome.ToLower()));

                if(usuario == null)
                {
                    throw new System.Exception("Usuário não encontrado");
                }
                else if (!Criptografia.VerificarSenhaHash(credenciais.Senha, usuario.SenhaHash, usuario.SenhaSalt))
                {
                    throw new System.Exception("Senha incorreta");
                }
                else
                {
                    return Ok(usuario);
                }
            }
            catch (System.Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

    }
}