using Xunit;
using Moq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using DogAPI.Services.Interfaces;
using DogAPI.Controllers;
using DogAPI.DTO.AtendimentoDTOs;

namespace DogApiTeste
{
    public class AtendimentoControllerTest
    {
        Mock<IAtendimentoServices> _atendimentoRepositoryMock;
        AtendimentosController _atendimentoController;

        public AtendimentoControllerTest()
        {
            _atendimentoRepositoryMock = new Mock<IAtendimentoServices>();
            _atendimentoController = new AtendimentosController(_atendimentoRepositoryMock.Object);
        }
        [Fact]
        public async Task Delete_ReturnsAOkObjectResult_WhenIdIsValid()
        {
            //arrange    
            var skip = 1;
            //Act
            var result = await _atendimentoController.Delete(skip);
            //Assert
            Assert.IsType<OkObjectResult>(result);
        }
        [Fact]
        public async Task Get_ReturnsAOkObjectResult_WhenIsValid()
        {
            //arrange         
            var skip = 1;
            //Act
            var result = await _atendimentoController.Get(skip);
            //Assert
            Assert.IsType<OkObjectResult>(result);
        }
        [Fact]
        public async Task GetById_ReturnsAOkObjectResult_WhenIsValid()
        {

            //arrange  
            var skip = 1;
            //Act
            var result = await _atendimentoController.GetById(skip);
            //Assert
            Assert.IsType<OkObjectResult>(result);
        }
        [Fact]
        public async Task GetByCPF_ReturnsAOkObjectResult_WhenIsValid()
        {

            //arrange 
            var cpf = "12345678911";
            //Act
            var result = await _atendimentoController.GetByCpf(cpf);
            //Assert
            Assert.IsType<OkObjectResult>(result);
        }
        [Fact]
        public async Task GetByPetName_ReturnsAOkObjectResult_WhenIsValid()
        {

            //arrange 
            var petName = "paçoca";
            //Act
            var result = await _atendimentoController.GetByPetName(petName);
            //Assert
            Assert.IsType<OkObjectResult>(result);
        }
        [Fact]
        public async Task Create_ReturnsAOkObjectResult_WhenIsValid()
        {
            //arrange         
            var Atendimento = new CreateAtendimentoDTO()
            {
                DataDeAtendimento = System.DateTime.Now,
                CachorroId = 1,
                veterinarioId = 1,
                Diagnostico = "teste",
                Comentario = "teste"
            };

            //Act

            var result = await _atendimentoController.Create(Atendimento);
            //Assert
            Assert.IsType<CreatedResult>(result);
        }
        [Fact]
        public async Task Update_ReturnsAOkObjectResult_WhenIsValid()
        {
            //arrange         
            var Atendimento = new UpdateAtendimentoDTO()
            {
                AtendimentoId = 1,
                DataDeAtendimento = System.DateTime.Now,
                CachorroId = 1,
                veterinarioId = 1,
                Diagnostico = "teste",
                Comentario = "teste"
            };
            var id = 1;

            //Act

            var result = await _atendimentoController.Update(id, Atendimento);
            //Assert
            Assert.IsType<OkObjectResult>(result);
        }
        [Fact]
        public async Task Update_ReturnsANotFoundResult_WhenAtendimentoIdIsDiferentIdRoute()
        {
            //arrange         
            var Atendimento = new UpdateAtendimentoDTO()
            {
                AtendimentoId = 1,
                 DataDeAtendimento = System.DateTime.Now,
                CachorroId = 1,
                veterinarioId = 1,
                Diagnostico = "teste",
                Comentario = "teste"
            };
            var id = 2;

            //Act

            var result = await _atendimentoController.Update(id, Atendimento);
            //Assert
            Assert.IsType<NotFoundResult>(result);
        }
    }
}
