using Xunit;
using Moq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using DogAPI.Services.Interfaces;
using DogAPI.Controllers;
using DogAPI.DTO;

namespace DogApiTeste
{
    public class UsuarioControllerTest
    {
        Mock<IAtendimentoServices> _atendimentoRepositoryMock;
        UsuarioController _usuarioController;

        public UsuarioControllerTest()
        {
            _atendimentoRepositoryMock = new Mock<IAtendimentoServices>();
            _usuarioController = new UsuarioController(_atendimentoRepositoryMock.Object);
        }
        [Fact]
        public async Task GetListTheBreeds_ReturnsAOkObjectResult_WhenIsValid()
        {
            //arrange         
            var skip = 1;
            //Act
            var result = await _usuarioController.GetListTheBreeds(skip);
            //Assert
            Assert.IsType<OkObjectResult>(result);
        }
        [Fact]
        public async Task SearchBreedsByName_ReturnsAOkObjectResult_WhenIsValid()
        {

            //arrange  
            var breedName = new RacaDTO();
            //Act
            var result = await _usuarioController.SearchBreedsByName(breedName);
            //Assert
            Assert.IsType<OkObjectResult>(result);
        }
        [Fact]
        public async Task GetListOfImages_ReturnsAOkObjectResult_WhenIsValid()
        {

            //arrange 
            var skip = 1;
            //Act
            var result = await _usuarioController.GetListOfImages(skip);
            //Assert
            Assert.IsType<OkObjectResult>(result);
        }
        [Fact]
        public async Task GetByCpf_ReturnsAOkObjectResult_WhenIsValid()
        {
            //arrange 
            var skip = 1;
            var user = "teste@gmail.com";
            //Act
            var result = await _usuarioController.GetByuser(user,skip);
            //Assert
            Assert.IsType<OkObjectResult>(result);
        }

    }
}
