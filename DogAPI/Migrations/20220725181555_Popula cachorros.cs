using Microsoft.EntityFrameworkCore.Migrations;

namespace DogAPI.Migrations
{
    public partial class Populacachorros : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("INSERT INTO `apidogdb`.`cachorros` (`CachorroId`,`TutorClienteId`,`Racaid`,`Tamanho`,`Peso`,`Vacinas`,`DataDeNascimento`,`Pedigree`,`Nome`,`Porte`,`Status`) VALUES(1, 1, 149, 25, 25, 'Todas as vacinas em dia', '2020-07-25 00:00:00.000000', '008041', 'Toby', 'Grande', 1)");
            migrationBuilder.Sql("INSERT INTO `apidogdb`.`cachorros` (`CachorroId`,`TutorClienteId`,`Racaid`,`Tamanho`,`Peso`,`Vacinas`,`DataDeNascimento`,`Pedigree`,`Nome`,`Porte`,`Status`) VALUES(2, 2, 4, 15, 15, 'Todas as vacinas em dia', '2020-07-25 00:00:00.000000', '008041', 'Tobias', 'Pequeno', 1)");
            migrationBuilder.Sql("INSERT INTO `apidogdb`.`cachorros` (`CachorroId`,`TutorClienteId`,`Racaid`,`Tamanho`,`Peso`,`Vacinas`,`DataDeNascimento`,`Pedigree`,`Nome`,`Porte`,`Status`) VALUES(3, 2, 50, 21, 14, 'Todas as vacinas em dia', '2020-07-25 00:00:00.000000', '008041', 'Lari', 'Grande', 1)");
            migrationBuilder.Sql("INSERT INTO `apidogdb`.`cachorros` (`CachorroId`,`TutorClienteId`,`Racaid`,`Tamanho`,`Peso`,`Vacinas`,`DataDeNascimento`,`Pedigree`,`Nome`,`Porte`,`Status`) VALUES(4, 3, 50, 11, 6, 'Todas as vacinas em dia', '2022-04-25 00:00:00.000000', '008041', 'Costela', 'Grande', 1)");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("drop table `apidogdb`.`cachorros`");
        }
    }
}
