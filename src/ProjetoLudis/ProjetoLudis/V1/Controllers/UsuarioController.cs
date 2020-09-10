
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;
using ProjetoLudis.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProjetoLudis.Models;

namespace ProjetoLudis.Controllers
{
    /// <summary>
    /// Metodos de  manipulação do Usuario 
    /// </summary>
    [ApiController]
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    public class UsuarioController : ControllerBase
    {
        public readonly IRepository _repo;
            
        private readonly IMapper _mapper;
        /// <summary>
        /// Metodo construtor
        /// </summary>
        /// <param name="repo"></param>
        /// <param name="mapper"></param>
        public UsuarioController(IRepository repo, IMapper mapper)
        {
            _mapper = mapper;
            _repo = repo;
        }
        /// <summary>
        /// Metodo para retorna todos os usuarios.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Authorize]
        public IActionResult Get()
        {
            var usuarios = _repo.GetAllUsuario();
            return Ok(_mapper.Map<IEnumerable<Usuario>>(usuarios));

        }
        /// <summary>
        /// Metodo para retorna somente um usuario(Query =>  Id).
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        [Authorize]
        public IActionResult GetById(int id)
        {
            var usuario = _repo.GetUsuarioById(id);
            if (usuario == null) return BadRequest("Usuario não encontrado");

            var Usuario = _mapper.Map<Usuario>(usuario);

            return Ok(Usuario);

        }
        /// <summary>
        /// Metodo de inclusão de usuario(Body => Novo Usuario)
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        [Authorize]
        public IActionResult Post(Usuario model)
        {
            var usuario = _mapper.Map<Usuario>(model);

            _repo.Add(usuario);
            if (_repo.SaveChanges())
            {
                return Created($"/api/usuario/{model.Id}", _mapper.Map<Usuario>(usuario));
            }

            return BadRequest("Usuario não cadastrado");
        }
        /// <summary>
        /// Metodo de alteração de todo usuario(Query => Id; Body => Usuario)
        /// </summary>
        /// <param name="id"></param>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPut("{id}")]
        [Authorize]
        public IActionResult Put(int id, Usuario model)
        {
            var usuario = _repo.GetUsuarioById(id);
            if (usuario == null) return BadRequest("Usuario não encontrado");

            _mapper.Map(model, usuario);

            _repo.Update(usuario);
            if (_repo.SaveChanges())
            {
                return Created($"/api/usuario/{model.Id}", _mapper.Map<Usuario>(usuario));
            }

            return BadRequest("Usuario não atualizado");
        }
        /// <summary>
        /// Metodo de alteração parcial do usuario(Query => Id; Body => Usuario) 
        /// </summary>
        /// <param name="id"></param>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPatch("{id}")]
        [Authorize]
        public IActionResult Patch(int id, Usuario model)
        {
            var usuario = _repo.GetUsuarioById(id);
            if (usuario == null) return BadRequest("Ususario não encontrado");

            _mapper.Map(model, usuario);

            _repo.Update(usuario);
            if (_repo.SaveChanges())
            {
                return Created($"/api/usuario/{model.Id}", _mapper.Map<Usuario>(usuario));
            }

            return BadRequest("Usuario não atualizado");
        }
        /// <summary>
        /// Metodo de Exclusao de Usuario(Quey => Id)
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        [Authorize]
        public IActionResult Delete(int id)
        {
            var usuario = _repo.GetUsuarioById(id);
            if (usuario == null) return BadRequest("Usuario não encontrado");


            _repo.Delete(usuario);
            if (_repo.SaveChanges())
            {
                return Ok("Usuario deletado");
            }

            return BadRequest("Usuario não deletado");
        }
    }
}
