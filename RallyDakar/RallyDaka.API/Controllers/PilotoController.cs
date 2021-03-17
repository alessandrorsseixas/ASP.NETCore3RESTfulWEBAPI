﻿using Microsoft.AspNetCore.JsonPatch;
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



        [HttpGet("{id}",Name ="Obter")]
        public IActionResult Obter(int id)
        {

            try
            {
                var piloto = _pilotoRepositorio.Obter(id);
                if (piloto== null)
                    return NoContent();

                return Ok(piloto);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Ocorreu um erro inesperado");

            }


        }


        [HttpGet]
        public IActionResult ObterTodos()
        {

            try
            {
                var pilotos = _pilotoRepositorio.ObterTodos();
                if (!pilotos.Any())
                    return NoContent();

                return Ok();
            }
            catch(Exception ex)
            {
                return  StatusCode(500,"Ocorreu um erro inesperado");

            }
            

        }
        [HttpPost]
        public IActionResult AdicionarPiloto([FromBody]Piloto piloto)
        {

            try
            {
                var pilotos = _pilotoRepositorio.ObterTodos();
                if (_pilotoRepositorio.Existe(piloto.Id))
                {
                    return StatusCode(409,"Já existe um piloto cadastrado com o mesmo ID");

                }
                else
                {
                    _pilotoRepositorio.Adicionar(piloto);
                    return CreatedAtRoute("Piloto Cadastrado com sucesso", new { id=piloto.Id},piloto);
                }

                
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Ocorreu um erro inesperado");

            }
        }

        [HttpPut]
        public IActionResult Atualizar([FromBody]Piloto piloto)
        {
            try
            {
                if (!_pilotoRepositorio.Existe(piloto.EquipeID))
                    return NoContent();
                _pilotoRepositorio.Atualizar(piloto);
                return Ok("Piloto Atualizado com sucesso");
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Ocorreu um erro inesperado");

            }
        }


        [HttpPatch("id")]
        public IActionResult Patch(int id,[FromBody]JsonPatchDocument<Piloto> patchpiloto)
        {
            try
            {
                if (!_pilotoRepositorio.Existe(id))
                    return NoContent();
               
                var piloto = _pilotoRepositorio.Obter(id);
                patchpiloto.ApplyTo(piloto);

                _pilotoRepositorio.Atualizar(piloto);


                return Ok("Piloto Atualizado com sucesso");
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Ocorreu um erro inesperado");

            }
        }


        [HttpDelete("{id}")]
        public IActionResult Deletar([FromBody]int id)
        {
            try
            {
                if (!_pilotoRepositorio.Existe(id))
                    return NoContent();
                var piloto = _pilotoRepositorio.Obter(id);
                _pilotoRepositorio.Deletar(piloto);

                return Ok("Piloto Atualizado com sucesso");
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Ocorreu um erro inesperado");

            }
        }
    }
}
