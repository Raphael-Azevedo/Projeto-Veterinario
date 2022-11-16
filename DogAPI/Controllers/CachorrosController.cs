using System;
using System.Threading.Tasks;
using DogAPI.DTO.CachorroDTOs;
using DogAPI.Services.Interfaces;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DogAPI.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class CachorrosController : Controller
    {
        private readonly ICachorroServices _cachorroServices;

        public CachorrosController(ICachorroServices cachorroServices)
        {
            _cachorroServices = cachorroServices;
        }
        /// <summary>
        /// Retonar lista de todos os pets
        /// </summary>
        /// <param name="skip"></param>
        /// <param name="take"></param>
        /// <returns></returns>
        [HttpGet("all/{skip:int?}/{take:int?}")]
        public async Task<IActionResult> Get([FromRoute] int skip = 0,
                     [FromRoute] int take = 10)
        {
            try
            {
                var Cachorros = await _cachorroServices.Get(skip, take);
                return Ok(Cachorros);
            }
            catch (Exception)
            {
                return BadRequest("Invalid Request");
            }
        }
        /// <summary>
        /// Retorna a lista de pets cadastrados no cpf do tutor
        /// </summary>
        /// <param name="cpf"></param>
        /// <param name="skip"></param>
        /// <param name="take"></param>
        /// <returns></returns>
        [HttpGet("tutor/{cpf}/{skip:int?}/{take:int?}")]
        public async Task<IActionResult> GetByCpf(string cpf, [FromRoute] int skip = 0,
                     [FromRoute] int take = 10)
        {
            try
            {
                var Cachorros = await _cachorroServices.GetByCpf(cpf, skip, take);
                return Ok(Cachorros);
            }
            catch (Exception)
            {
                return BadRequest("Invalid Request");
            }
        }
        /// <summary>
        /// Retorna o pet pelo id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            try
            {
                var Cachorro = await _cachorroServices.GetById(id);
                return Ok(Cachorro);
            }
            catch (Exception)
            {
                return BadRequest("Invalid Request");
            }
        }
        /// <summary>
        /// Cria cadastro de um novo pet
        /// </summary>
        /// <param name="CachorroDTO"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateCachorroDTO CachorroDTO)
        {
            try
            {
                await _cachorroServices.Create(CachorroDTO);
                return Created("Created", CachorroDTO);
            }
            catch (Exception)
            {
                return BadRequest("Invalid Request");
            }
        }
        /// <summary>
        /// Atualiza dados do cadastro de um pet
        /// </summary>
        /// <param name="id"></param>
        /// <param name="CachorroDTO"></param>
        /// <returns></returns>
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] UpdateCachorroDTO CachorroDTO)
        {
            if (id != CachorroDTO.CachorroId)
            {
                return NotFound();
            }
            if (ModelState.IsValid)
            {
                try
                {
                    await _cachorroServices.Update(id, CachorroDTO);
                    return Ok(CachorroDTO);
                }
                catch (Exception)
                {
                    return BadRequest("No Modified!");
                }
            }
            else
            {
                return BadRequest("No Modified!");
            }
        }
        /// <summary>
        /// Deleta um cadastro de pet
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                await _cachorroServices.Delete(id);
                return Ok("O Cachorro foi deletado");
            }
            catch (Exception)
            {
                return BadRequest("Invalid Request");
            }

        }
    }
}