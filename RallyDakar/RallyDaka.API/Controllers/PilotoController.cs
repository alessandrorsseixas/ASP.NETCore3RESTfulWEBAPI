using Microsoft.AspNetCore.Mvc;
using RallyDakar.Dominio.Entidades;
using RallyDakar.Dominio.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RallyDaka.API.Controllers
{

    [ApiController]
    [Route("api/produtos")]
    public class PilotoController : ControllerBase 
    {
        private readonly IPilotoRepositorio _pilotoRepositorio;

        public PilotoController(IPilotoRepositorio pilotoRepositorio)
        {
            _pilotoRepositorio = pilotoRepositorio;
        }

        [HttpGet]
        public IActionResult ObterTodos()
        {
            return Ok(_pilotoRepositorio.ObterTodos());

        }
        /// <summary>
        /// A api vai ler as requisições no corpo da chamada
        /// </summary>
        /// <param name="piloto"></param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult Adicionar([FromBody]Piloto piloto)
        {
            _pilotoRepositorio.Adicionar(piloto);
            return Ok();
        }
    }
}
