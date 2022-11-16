using Microsoft.EntityFrameworkCore.Migrations;

namespace DogAPI.Migrations
{
    public partial class Populaveterinarios : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("INSERT INTO `apidogdb`.`veterinarios` (`VeterinarioId`,`CRMV`,`Consultorio`,`Status`,`Nome`,`Endereco`,`Telefone`,`Email`,`Cep`,`Bairro`,`Cidade`) VALUES(1, '12345', '01', 1, 'Marcelo Aloado', 'Rua presidente joão goulart', 999999999, 'marcelovet@vetfirma.com', 12345123, 'Boa esperança', 'Vitória')");
            migrationBuilder.Sql("INSERT INTO `apidogdb`.`veterinarios` (`VeterinarioId`,`CRMV`,`Consultorio`,`Status`,`Nome`,`Endereco`,`Telefone`,`Email`,`Cep`,`Bairro`,`Cidade`) VALUES(2, '12345', '02', 1, 'Luana Almofadinhas', 'Rua presidente canarinho', 989999999, 'luanavet@vetfirma.com', 12345123, 'Itaquari', 'Vitória')");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
          migrationBuilder.Sql("drop table `apidogdb`.`veterinarios`");
        }
    }
}
