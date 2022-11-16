using Xunit;
using Moq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using DogAPI.Services.Interfaces;
using DogAPI.Controllers;
using DogAPI.DTO.VeterinarioDTOs;

namespace DogApiTeste
{
    public class VeterinarioControllerTest
    {
        Mock<IVeterinarioServices> _veteRepositoryMock;
        VeterinariosController _veterinarioController;

        public VeterinarioControllerTest()
        {
            _veteRepositoryMock = new Mock<IVeterinarioServices>();
            _veterinarioController = new VeterinariosController(_veteRepositoryMock.Object);
        }
        [Fact]
        public async Task Delete_ReturnsAOkObjectResult_WhenIdIsValid()
        {
            //arrange    
            var skip = 1;
            //Act
            var result = await _veterinarioController.Delete(skip);
            //Assert
            Assert.IsType<OkObjectResult>(result);
        }
        [Fact]
        public async Task Get_ReturnsAOkObjectResult_WhenIsValid()
        {
            //arrange         
            var skip = 1;
            //Act
            var result = await _veterinarioController.Get(skip);
            //Assert
            Assert.IsType<OkObjectResult>(result);
        }
        [Fact]
        public async Task GetById_ReturnsAOkObjectResult_WhenIsValid()
        {

            //arrange  
            var skip = 1;
            //Act
            var result = await _veterinarioController.GetById(skip);
            //Assert
            Assert.IsType<OkObjectResult>(result);
        }
        [Fact]
        public async Task GetByCRMV_ReturnsAOkObjectResult_WhenIsValid()
        {

            //arrange 
            var crmv = "12345";
            //Act
            var result = await _veterinarioController.GetByCRMV(crmv);
            //Assert
            Assert.IsType<OkObjectResult>(result);
        }
        [Fact]
        public async Task Create_ReturnsAOkObjectResult_WhenIsValid()
        {
            //arrange         
            var veterinario = new CreateVeterinarioDTO()
            {
                Nome = "teste",
                Cep = 12345678,
                Telefone = 123456789,
                Email = "teste@teste.com",
                Endereco = "Rua teste",
                Bairro = "teste",
                Cidade = "teste",
                Consultorio = "teste",
                CRMV = "12345"
            };

            //Act

            var result = await _veterinarioController.Create(veterinario);
            //Assert
            Assert.IsType<CreatedResult>(result);
        }
        [Fact]
        public async Task Update_ReturnsAOkObjectResult_WhenIsValid()
        {
            //arrange         
            var veterinario = new UpdateVeterinarioDTO()
            {
                VeterinarioId = 1,
                Nome = "teste",
                Cep = 12345678,
                Telefone = 123456789,
                Email = "teste@teste.com",
                Endereco = "Rua teste",
                Bairro = "teste",
                Cidade = "teste",
                Consultorio = "teste",
                CRMV = "12345"
            };
            var id = 1;

            //Act

            var result = await _veterinarioController.Update(id, veterinario);
            //Assert
            Assert.IsType<OkObjectResult>(result);
        }
        [Fact]
        public async Task Update_ReturnsANotFoundResult_WhenVeterinarioIdIsDiferentIdRoute()
        {
            //arrange         
            var veterinario = new UpdateVeterinarioDTO()
            {
                VeterinarioId = 1,
                Nome = "teste",
                Cep = 12345678,
                Telefone = 123456789,
                Email = "teste@teste.com",
                Endereco = "Rua teste",
                Bairro = "teste",
                Cidade = "teste",
                Consultorio = "teste",
                CRMV = "12345"
            };
            var id = 2;

            //Act

            var result = await _veterinarioController.Update(id, veterinario);
            //Assert
            Assert.IsType<NotFoundResult>(result);
        }
    }
}
