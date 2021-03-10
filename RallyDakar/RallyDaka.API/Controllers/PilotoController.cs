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
    [Route("api/pilotos")]
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
            //Piloto piloto = new Piloto()
            //{
            //    Id = 1,
            //    Nome = "alessandro"

            //};
            //List<Piloto> lista = new List<Piloto>();
            //lista.Add(piloto);
            //return Ok(lista);
            return Ok(_pilotoRepositorio.ObterTodos());

        }
        [HttpPost]
        public IActionResult AdicionarPiloto([FromBody]Piloto piloto)
        {
            _pilotoRepositorio.Adicionar(piloto);
            return Ok();
        }

        [HttpPut]
        public IActionResult AtualizarPiloto([FromBody]Piloto piloto)
        {
            return Ok();
        }


        [HttpPatch]
        public IActionResult AtualizarParcialPiloto([FromBody]Piloto piloto)
        {
            return Ok();
        }


        [HttpDelete("{id}")]
        public IActionResult DeletarPiloto([FromBody]int id)
        {
            return Ok();
        }
    }
}
