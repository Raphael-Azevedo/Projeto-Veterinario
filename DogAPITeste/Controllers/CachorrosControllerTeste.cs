using Xunit;
using Moq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using DogAPI.Services.Interfaces;
using DogAPI.Controllers;
using DogAPI.DTO.CachorroDTOs;

namespace DogApiTeste
{
    public class CachorroControllerTest
    {
        Mock<ICachorroServices> _cachorroRepositoryMock;
        CachorrosController _cachorroController;

        public CachorroControllerTest()
        {
            _cachorroRepositoryMock = new Mock<ICachorroServices>();
            _cachorroController = new CachorrosController(_cachorroRepositoryMock.Object);
        }
        [Fact]
        public async Task Delete_ReturnsAOkObjectResult_WhenIdIsValid()
        {
            //arrange    
            var skip = 1;
            //Act
            var result = await _cachorroController.Delete(skip);
            //Assert
            Assert.IsType<OkObjectResult>(result);
        }
        [Fact]
        public async Task Get_ReturnsAOkObjectResult_WhenIsValid()
        {
            //arrange         
            var skip = 1;
            //Act
            var result = await _cachorroController.Get(skip);
            //Assert
            Assert.IsType<OkObjectResult>(result);
        }
        [Fact]
        public async Task GetById_ReturnsAOkObjectResult_WhenIsValid()
        {

            //arrange  
            var skip = 1;
            //Act
            var result = await _cachorroController.GetById(skip);
            //Assert
            Assert.IsType<OkObjectResult>(result);
        }
        [Fact]
        public async Task GetByCPF_ReturnsAOkObjectResult_WhenIsValid()
        {

            //arrange 
            var cpf = "123456789";
            //Act
            var result = await _cachorroController.GetByCpf(cpf);
            //Assert
            Assert.IsType<OkObjectResult>(result);
        }
        [Fact]
        public async Task Create_ReturnsAOkObjectResult_WhenIsValid()
        {
            //arrange         
            var Cachorro = new CreateCachorroDTO()
            {
                Nome = "teste",
                NomeRaca = "labrador",
                Tamanho = 30,
                TutorCpf = "038.511.890-27",
                Pedigree = "00801",
                Peso = 14,
                Porte = "Grande porte",
                DataDeNascimento = System.DateTime.Now,
                Vacinas = "Vacina anti rabica"
            };

            //Act

            var result = await _cachorroController.Create(Cachorro);
            //Assert
            Assert.IsType<CreatedResult>(result);
        }
        [Fact]
        public async Task Update_ReturnsAOkObjectResult_WhenIsValid()
        {
            //arrange         
            var Cachorro = new UpdateCachorroDTO()
            {
                CachorroId = 1,
                Nome = "teste",
                NomeRaca = "labrador",
                Tamanho = 30,
                TutorCpf = "038.511.890-27",
                Pedigree = "00801",
                Peso = 14,
                Porte = "Grande porte",
                DataDeNascimento = System.DateTime.Now,
                Vacinas = "Vacina anti rabica"
            };
            var id = 1;

            //Act

            var result = await _cachorroController.Update(id, Cachorro);
            //Assert
            Assert.IsType<OkObjectResult>(result);
        }
        [Fact]
        public async Task Update_ReturnsANotFoundResult_WhenCachorroIdIsDiferentIdRoute()
        {
            //arrange         
            var Cachorro = new UpdateCachorroDTO()
            {
                CachorroId = 1,
                Nome = "teste",
                NomeRaca = "labrador",
                Tamanho = 30,
                TutorCpf = "038.511.890-27",
                Pedigree = "00801",
                Peso = 14,
                Porte = "Grande porte",
                DataDeNascimento = System.DateTime.Now,
                Vacinas = "Vacina anti rabica"
            };
            var id = 2;

            //Act

            var result = await _cachorroController.Update(id, Cachorro);
            //Assert
            Assert.IsType<NotFoundResult>(result);
        }
    }
}
