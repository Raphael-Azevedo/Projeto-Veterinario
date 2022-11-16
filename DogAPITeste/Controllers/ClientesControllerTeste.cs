using Xunit;
using Moq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using DogAPI.Services.Interfaces;
using DogAPI.Controllers;
using DogAPI.DTO.ClienteDTOs;

namespace DogApiTeste
{
    public class ClienteControllerTest
    {
        Mock<IClienteServices> _clientesRepositoryMock;
        ClientesController _clientesController;

        public ClienteControllerTest()
        {
            _clientesRepositoryMock = new Mock<IClienteServices>();
            _clientesController = new ClientesController(_clientesRepositoryMock.Object);
        }
        [Fact]
        public async Task Delete_ReturnsAOkObjectResult_WhenIdIsValid()
        {
            //arrange    
            var skip = 1;
            //Act
            var result = await _clientesController.Delete(skip);
            //Assert
            Assert.IsType<OkObjectResult>(result);
        }
        [Fact]
        public async Task Get_ReturnsAOkObjectResult_WhenIsValid()
        {
            //arrange         
            var skip = 1;
            //Act
            var result = await _clientesController.Get(skip);
            //Assert
            Assert.IsType<OkObjectResult>(result);
        }
        [Fact]
        public async Task GetById_ReturnsAOkObjectResult_WhenIsValid()
        {

            //arrange  
            var skip = 1;
            //Act
            var result = await _clientesController.GetById(skip);
            //Assert
            Assert.IsType<OkObjectResult>(result);
        }
        [Fact]
        public async Task GetByCPF_ReturnsAOkObjectResult_WhenIsValid()
        {

            //arrange 
            var cpf = "12345678911";
            //Act
            var result = await _clientesController.GetByCPF(cpf);
            //Assert
            Assert.IsType<OkObjectResult>(result);
        }
        [Fact]
        public async Task Create_ReturnsAOkObjectResult_WhenIsValid()
        {
            //arrange         
            var Cliente = new CreateClienteDTO()
            {
                Nome = "teste",
                Cep = 12345678,
                Telefone = 123456789,
                Email = "teste@teste.com",
                Endereco = "Rua teste",
                Bairro = "teste",
                Cidade = "teste",
                CPF = "038.511.890-27"
            };

            //Act

            var result = await _clientesController.Create(Cliente);
            //Assert
            Assert.IsType<CreatedResult>(result);
        }
        [Fact]
        public async Task Update_ReturnsAOkObjectResult_WhenIsValid()
        {
            //arrange         
            var Cliente = new UpdateClienteDTO()
            {
                ClienteId = 1,
                Nome = "teste",
                Cep = 12345678,
                Telefone = 123456789,
                Email = "teste@teste.com",
                Endereco = "Rua teste",
                Bairro = "teste",
                Cidade = "teste",
                CPF = "038.511.890-27"
            };
            var id = 1;

            //Act

            var result = await _clientesController.Update(id, Cliente);
            //Assert
            Assert.IsType<OkObjectResult>(result);
        }
        [Fact]
        public async Task Update_ReturnsANotFoundResult_WhenClienteIdIsDiferentIdRoute()
        {
            //arrange         
            var Cliente = new UpdateClienteDTO()
            {
                ClienteId = 1,
                Nome = "teste",
                Cep = 12345678,
                Telefone = 123456789,
                Email = "teste@teste.com",
                Endereco = "Rua teste",
                Bairro = "teste",
                Cidade = "teste",
                CPF = "03851189027"
            };
            var id = 2;

            //Act

            var result = await _clientesController.Update(id, Cliente);
            //Assert
            Assert.IsType<NotFoundResult>(result);
        }
        [Fact]
        public async Task Update_ReturnsABadRequestResult_WhenCPFIsInvalid()
        {
            //arrange         
            var Cliente = new UpdateClienteDTO()
            {
                ClienteId = 1,
                Nome = "teste",
                Cep = 12345678,
                Telefone = 123456789,
                Email = "teste@teste.com",
                Endereco = "Rua teste",
                Bairro = "teste",
                Cidade = "teste",
                CPF = "0385118907"
            };
            var id = 2;

            //Act

            var result = await _clientesController.Update(id, Cliente);
            //Assert
            Assert.IsType<BadRequestObjectResult>(result);
        }
        [Fact]
        public async Task Create_ReturnsABadRequestResult_WhenCPFIsInvalid()
        {
            //arrange         
            var Cliente = new UpdateClienteDTO()
            {
                ClienteId = 1,
                Nome = "teste",
                Cep = 12345678,
                Telefone = 123456789,
                Email = "teste@teste.com",
                Endereco = "Rua teste",
                Bairro = "teste",
                Cidade = "teste",
                CPF = "0385118907"
            };
            var id = 2;

            //Act

            var result = await _clientesController.Update(id, Cliente);
            //Assert
            Assert.IsType<BadRequestObjectResult>(result);
        }
    }
}
