using System;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using DogAPI.DTO;
using DogAPI.Models;
using DogAPI.Services.Interfaces;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DogAPI.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class UsuarioController : Controller
    {
        private readonly IAtendimentoServices _atendimentoServices;

        public UsuarioController(IAtendimentoServices atendimentoServices)
        {
            _atendimentoServices = atendimentoServices;
        }
        /// <summary>
        /// Gera uma lista de todas as raças de cachorros
        /// </summary>
        /// <param name="skip"></param>
        /// <param name="take"></param>
        /// <returns></returns>
        [HttpGet("breeds/{skip:int?}/{take:int?}")]
        public async Task<IActionResult> GetListTheBreeds([FromRoute] int skip = 0,
                             [FromRoute] int take = 10)
        {
            string apiUrl = "https://api.thedogapi.com/v1/breeds?limit=" + take + "&page=" + skip;
            try
            {
                using (var cliente = new HttpClient())
                {
                    var breeds = await cliente.GetStringAsync(apiUrl);

                    var result = JsonSerializer.Deserialize<Raca[]>(breeds);
                    return Ok(result);
                }
            }
            catch (Exception)
            {
                return BadRequest("Invalid Request");
            }
        }
        /// <summary>
        /// Busca os dados da raça do cachorro pelo nome da raça
        /// </summary>
        /// <param name="breedName"></param>
        /// <returns></returns>
        [HttpPost("search/")]
        public async Task<IActionResult> SearchBreedsByName([FromBody] RacaDTO breedName)
        {
            string apiUrl = "https://api.thedogapi.com/v1/breeds/search?q=" + breedName.breedName;
            try
            {
                using (var cliente = new HttpClient())
                {
                    var breeds = await cliente.GetStringAsync(apiUrl);

                    var result = JsonSerializer.Deserialize<Raca[]>(breeds);
                    return Ok(result);
                }
            }
            catch (Exception)
            {
                return BadRequest("Invalid Request");
            }
        }
        /// <summary>
        /// Busca imagens das raças de cachorro
        /// </summary>
        /// <param name="skip"></param>
        /// <param name="take"></param>
        /// <returns></returns>
        [HttpGet("images/{skip:int?}/{take:int?}")]
        public async Task<IActionResult> GetListOfImages([FromRoute] int skip = 0,
                     [FromRoute] int take = 10)
        {
            string apiUrl = "https://api.thedogapi.com/v1/images/search?page=" + skip + "&limit=" + take;
            try
            {
                using (var cliente = new HttpClient())
                {
                    var images = await cliente.GetStringAsync(apiUrl);

                    var result = JsonSerializer.Deserialize<ImagemDTO[]>(images); //criar dto de imagem
                    return Ok(result);
                }
            }
            catch (Exception)
            {
                return BadRequest("Invalid Request");
            }
        }
        /// <summary>
        /// Cliente busca os dados do atendimento pelo seu email de usuario
        /// </summary>
        /// <param name="user"></param>
        /// <param name="skip"></param>
        /// <param name="take"></param>
        /// <returns></returns>
        [HttpGet("tutor/{user}/{skip:int?}/{take:int?}")]
        public async Task<IActionResult> GetByuser(string user, [FromRoute] int skip = 0,
              [FromRoute] int take = 10)
        {
            try
            {
                var Atendimentos = await _atendimentoServices.GetByUser(user, skip, take);
                return Ok(Atendimentos);
            }
            catch (Exception)
            {
                return BadRequest("Invalid Request");
            }
        }
    }
}