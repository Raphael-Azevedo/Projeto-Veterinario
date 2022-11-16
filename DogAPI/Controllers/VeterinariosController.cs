using System;
using System.Threading.Tasks;
using DogAPI.DTO.VeterinarioDTOs;
using DogAPI.Services.Interfaces;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DogAPI.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class VeterinariosController : Controller
    {

        private readonly IVeterinarioServices _veterinarioServices;

        public VeterinariosController(IVeterinarioServices veterinarioServices)
        {
            _veterinarioServices = veterinarioServices;
        }
        /// <summary>
        /// Retonar lista de todos os veterinarios cadastrados
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
                var veterinarios = await _veterinarioServices.Get(skip, take);
                return Ok(veterinarios);
            }
            catch (Exception)
            {
                return BadRequest("Invalid Request");
            }
        }
        /// <summary>
        /// Retorna os dados do veterinario pelo seu id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            try
            {
                var veterinario = await _veterinarioServices.GetById(id);
                return Ok(veterinario);
            }
            catch (Exception)
            {
                return BadRequest("Invalid Request");
            }
        }
        /// <summary>
        /// Retorna os dados do veterinario pelo seu CRMV
        /// </summary>
        /// <param name="crmv"></param>
        /// <returns></returns>
        [HttpGet("crmv/{crmv}")]
        public async Task<IActionResult> GetByCRMV(string crmv)
        {
            try
            {
                var veterinario = await _veterinarioServices.GetByCRMV(crmv);
                return Ok(veterinario);
            }
            catch (Exception)
            {
                return BadRequest("Invalid Request");
            }
        }
        /// <summary>
        /// Cria um novo cadastro de veterinario
        /// </summary>
        /// <param name="veterinarioDTO"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateVeterinarioDTO veterinarioDTO)
        {
            try
            {
                await _veterinarioServices.Create(veterinarioDTO);
                return Created("Created", veterinarioDTO);
            }
            catch (Exception)
            {
                return BadRequest("Invalid Request");
            }
        }
        /// <summary>
        /// Atualiza cadastro de veterinário
        /// </summary>
        /// <param name="id"></param>
        /// <param name="veterinarioDTO"></param>
        /// <returns></returns>
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] UpdateVeterinarioDTO veterinarioDTO)
        {
            if (id != veterinarioDTO.VeterinarioId)
            {
                return NotFound();
            }
            if (ModelState.IsValid)
            {
                try
                {
                    await _veterinarioServices.Update(id, veterinarioDTO);
                    return Ok(veterinarioDTO);
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
        /// Deleta um cadastro de veterinario
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                await _veterinarioServices.Delete(id);
                return Ok("O veterinario foi deletado");
            }
            catch (Exception)
            {
                return BadRequest("Invalid Request");
            }

        }
    }
}