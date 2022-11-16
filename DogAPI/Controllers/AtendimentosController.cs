using System;
using System.Threading.Tasks;
using DogAPI.DTO.AtendimentoDTOs;
using DogAPI.Services.Interfaces;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DogAPI.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class AtendimentosController : Controller
    {
        private readonly IAtendimentoServices _atendimentoServices;

        public AtendimentosController(IAtendimentoServices AtendimentoServices)
        {
            _atendimentoServices = AtendimentoServices;
        }
        /// <summary>
        /// Retorna lista com todos os atendimentos
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
                var Atendimentos = await _atendimentoServices.Get(skip, take);
                return Ok(Atendimentos);
            }
            catch (Exception)
            {
                return BadRequest("Invalid Request");
            }
        }
        /// <summary>
        /// Busca os atendimentos pelo cpf do tutor
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
                var Atendimentos = await _atendimentoServices.GetByCpf(cpf, skip, take);
                return Ok(Atendimentos);
            }
            catch (Exception)
            {
                return BadRequest("Invalid Request");
            }
        }
        /// <summary>
        /// Busca os atendimentos pelo nome do pet
        /// </summary>
        /// <param name="petName"></param>
        /// <param name="skip"></param>
        /// <param name="take"></param>
        /// <returns></returns>
        [HttpGet("pet/{petName}/{skip:int?}/{take:int?}")]
        public async Task<IActionResult> GetByPetName(string petName, [FromRoute] int skip = 0,
              [FromRoute] int take = 10)
        {
            try
            {
                var Atendimentos = await _atendimentoServices.GetByPetName(petName, skip, take);
                return Ok(Atendimentos);
            }
            catch (Exception)
            {
                return BadRequest("Invalid Request");
            }
        }
        /// <summary>
        /// Busca o atendimento pelo id 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            try
            {
                var Atendimento = await _atendimentoServices.GetById(id);
                return Ok(Atendimento);
            }
            catch (Exception)
            {
                return BadRequest("Invalid Request");
            }
        }
        /// <summary>
        /// Cria um novo atendimento
        /// </summary>
        /// <param name="AtendimentoDTO"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateAtendimentoDTO AtendimentoDTO)
        {
            try
            {
                await _atendimentoServices.Create(AtendimentoDTO);
                return Created("Created", AtendimentoDTO);
            }
            catch (Exception)
            {
                return BadRequest("Invalid Request");
            }
        }
        /// <summary>
        /// Atualiza os dados do atendimento
        /// </summary>
        /// <param name="id"></param>
        /// <param name="AtendimentoDTO"></param>
        /// <returns></returns>
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] UpdateAtendimentoDTO AtendimentoDTO)
        {
            if (id != AtendimentoDTO.AtendimentoId)
            {
                return NotFound();
            }
            if (ModelState.IsValid)
            {
                try
                {
                    await _atendimentoServices.Update(id, AtendimentoDTO);
                    return Ok(AtendimentoDTO);
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
        /// Deleta um atendimento
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                await _atendimentoServices.Delete(id);
                return Ok("O Atendimento foi deletado");
            }
            catch (Exception)
            {
                return BadRequest("Invalid Request");
            }

        }
    }
}