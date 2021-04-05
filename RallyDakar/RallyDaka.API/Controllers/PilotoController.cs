using AutoMapper;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using RallyDakar.Dominio.Entidades;
using RallyDakar.Dominio.Interfaces;
using RallyDakar.Dominio.Modelo;
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
        private readonly IMapper _mapper;
        public PilotoController(IPilotoRepositorio pilotoRepositorio,IMapper mapper)
        {
            _pilotoRepositorio = pilotoRepositorio;
            _mapper = mapper;
        }



        [HttpGet("{id}",Name ="Obter")]
        public IActionResult Obter(int id)
        {

            try
            {
                var piloto = _pilotoRepositorio.Obter(id);
                if (piloto== null)
                    return NoContent();

                var pilotoModelo = _mapper.Map<PilotoModelo>(piloto);
                return Ok(pilotoModelo);
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
                var pilotosModelo = _mapper.Map<IEnumerable<Piloto>>(pilotos);
                return Ok(pilotosModelo);
            }
            catch(Exception ex)
            {
                return  StatusCode(500,"Ocorreu um erro inesperado");

            }
            

        }



        [HttpPost]
        public IActionResult AdicionarPiloto([FromBody]PilotoModelo pilotoModelo)
        {

            try
            {

                var piloto = _mapper.Map<Piloto>(pilotoModelo);
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
        public IActionResult Atualizar([FromBody]PilotoModelo pilotoModelo)
        {
            try
            {
                if (!_pilotoRepositorio.Existe(pilotoModelo.EquipeID))
                    return NoContent();

                var piloto = _mapper.Map<Piloto>(pilotoModelo);
                _pilotoRepositorio.Atualizar(piloto);
                return Ok("Piloto Atualizado com sucesso");
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Ocorreu um erro inesperado");

            }
        }


        [HttpPatch("id")]
        public IActionResult Patch(int id,[FromBody]JsonPatchDocument<PilotoModelo> patchpilotoModelo)
        {
            try
            {
                if (!_pilotoRepositorio.Existe(id))
                    return NoContent();
               
                var piloto = _pilotoRepositorio.Obter(id);

                var pilotoModelo = _mapper.Map<PilotoModelo>(piloto);

                patchpilotoModelo.ApplyTo(pilotoModelo);

                piloto = _mapper.Map(pilotoModelo, piloto); 

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


       [HttpOptions]
       public IActionResult DevolverOperacoesPermitidas()
        {

            Response.Headers.Add("ALLOW", "GET,POST,PUT,PATCH,OPTIONS");
            return Ok();
        }
    }
}
