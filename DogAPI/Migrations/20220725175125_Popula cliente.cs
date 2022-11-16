using Microsoft.EntityFrameworkCore.Migrations;

namespace DogAPI.Migrations
{
    public partial class Populacliente : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("INSERT INTO `apidogdb`.`clientes` (`ClienteId`,`CPF`,`Status`,`Nome`,`Endereco`,`Telefone`,`Email`,`Cep`,`Bairro`,`Cidade`) VALUES(1, '038.511.890-27', 1, 'Harry potter', 'rua continental', 989997777, 'usuario@gft.com', 12345123, 'Santo Antônio', 'Vitória')");
            migrationBuilder.Sql("INSERT INTO `apidogdb`.`clientes` (`ClienteId`,`CPF`,`Status`,`Nome`,`Endereco`,`Telefone`,`Email`,`Cep`,`Bairro`,`Cidade`) VALUES(2, '307.061.680-11', 1, 'João Leão', 'rua Azul', 989997777, 'Joaazim@gmail.com', 12345123, 'Santo André', 'Vitória')");
            migrationBuilder.Sql("INSERT INTO `apidogdb`.`clientes` (`ClienteId`,`CPF`,`Status`,`Nome`,`Endereco`,`Telefone`,`Email`,`Cep`,`Bairro`,`Cidade`) VALUES(3, '019.009.380-30', 1, 'Julia Leal', 'rua canada', 989997777, 'jLeal@gmail.com', 12345123, 'Santa Tereza', 'Vitória')");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("drop table `apidogdb`.`clientes`");
        }
    }
}
