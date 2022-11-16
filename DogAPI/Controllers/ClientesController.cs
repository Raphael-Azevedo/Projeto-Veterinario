using System;
using System.Threading.Tasks;
using DogAPI.DTO.ClienteDTOs;
using DogAPI.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using DogAPI.Validations;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authentication.JwtBearer;

namespace DogAPI.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class ClientesController : Controller
    {
        private readonly IClienteServices _clienteServices;

        public ClientesController(IClienteServices clienteServices)
        {
            _clienteServices = clienteServices;
        }
        /// <summary>
        /// Retorna a lista de todos os clientes
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
                var Clientes = await _clienteServices.Get(skip, take);
                return Ok(Clientes);
            }
            catch (Exception)
            {
                return BadRequest("Invalid Request");
            }
        }
        /// <summary>
        /// Retorna o cliente pelo id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            try
            {
                var Cliente = await _clienteServices.GetById(id);
                return Ok(Cliente);
            }
            catch (Exception)
            {
                return BadRequest("Invalid Request");
            }
        }
        /// <summary>
        /// retorna o cliente pelo seu cpf
        /// </summary>
        /// <param name="cpf"></param>
        /// <returns></returns>
        [HttpGet("cpf/{cpf}")]
        public async Task<IActionResult> GetByCPF(string cpf)
        {
            try
            {
                var Cliente = await _clienteServices.GetByCPF(cpf);
                return Ok(Cliente);
            }
            catch (Exception)
            {
                return BadRequest("Invalid Request");
            }
        }
        /// <summary>
        /// Cria o cadastro de um cliente
        /// </summary>
        /// <param name="ClienteDTO"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateClienteDTO ClienteDTO)
        {
            if (!ValidaCPF.IsCpf(ClienteDTO.CPF))
            {
                return BadRequest("Invalid CPF");
            }
            try
            {
                await _clienteServices.Create(ClienteDTO);
                return Created("Created", ClienteDTO);
            }
            catch (Exception)
            {
                return BadRequest("Invalid Request");
            }
        }
        /// <summary>
        /// Atualiza o cadastro de um cliente
        /// </summary>
        /// <param name="id"></param>
        /// <param name="ClienteDTO"></param>
        /// <returns></returns>
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] UpdateClienteDTO ClienteDTO)
        {
            if (!ValidaCPF.IsCpf(ClienteDTO.CPF))
            {
                return BadRequest("Invalid CPF");
            }
            if (id != ClienteDTO.ClienteId)
            {
                return NotFound();
            }
            if (ModelState.IsValid)
            {
                try
                {
                    await _clienteServices.Update(id, ClienteDTO);
                    return Ok(ClienteDTO);
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
        /// Deleta um cliente pelo id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                await _clienteServices.Delete(id);
                return Ok("O Cliente foi deletado");
            }
            catch (Exception)
            {
                return BadRequest("Invalid Request");
            }

        }
    }
}