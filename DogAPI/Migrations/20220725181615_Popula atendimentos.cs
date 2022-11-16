using Microsoft.EntityFrameworkCore.Migrations;

namespace DogAPI.Migrations
{
    public partial class Populaatendimentos : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("INSERT INTO `apidogdb`.`atendimentos` (`AtendimentoId`,`DataDeAtendimento`,`PetCachorroId`,`VeterinarioId`,`Diagnostico`,`Comentario`,`Status`) VALUES(1, '2022-07-23 00:00:00.000000', 1, 1, 'Tudo Ok', 'Cachorro com a saude em dia', 1)");
            migrationBuilder.Sql("INSERT INTO `apidogdb`.`atendimentos` (`AtendimentoId`,`DataDeAtendimento`,`PetCachorroId`,`VeterinarioId`,`Diagnostico`,`Comentario`,`Status`) VALUES(2, '2022-02-23 00:00:00.000000', 1, 1, 'Tudo Ok', 'Cachorro com a saude em dia', 1)");
            migrationBuilder.Sql("INSERT INTO `apidogdb`.`atendimentos` (`AtendimentoId`,`DataDeAtendimento`,`PetCachorroId`,`VeterinarioId`,`Diagnostico`,`Comentario`,`Status`) VALUES(3, '2022-05-23 00:00:00.000000', 1, 1, 'Tudo Ok', 'Cachorro com a saude em dia', 1)");
            migrationBuilder.Sql("INSERT INTO `apidogdb`.`atendimentos` (`AtendimentoId`,`DataDeAtendimento`,`PetCachorroId`,`VeterinarioId`,`Diagnostico`,`Comentario`,`Status`) VALUES(4, '2022-05-23 00:00:00.000000', 2, 1, 'Tudo Ok', 'Cachorro com a saude em dia', 1)");
            migrationBuilder.Sql("INSERT INTO `apidogdb`.`atendimentos` (`AtendimentoId`,`DataDeAtendimento`,`PetCachorroId`,`VeterinarioId`,`Diagnostico`,`Comentario`,`Status`) VALUES(5, '2022-02-23 00:00:00.000000', 2, 1, 'Tudo Ok', 'Cachorro com a saude em dia', 1)");
            migrationBuilder.Sql("INSERT INTO `apidogdb`.`atendimentos` (`AtendimentoId`,`DataDeAtendimento`,`PetCachorroId`,`VeterinarioId`,`Diagnostico`,`Comentario`,`Status`) VALUES(6, '2022-05-23 00:00:00.000000', 3, 2, 'Tudo Ok', 'Cachorro com a saude em dia', 1)");
            migrationBuilder.Sql("INSERT INTO `apidogdb`.`atendimentos` (`AtendimentoId`,`DataDeAtendimento`,`PetCachorroId`,`VeterinarioId`,`Diagnostico`,`Comentario`,`Status`) VALUES(7, '2022-01-23 00:00:00.000000', 3, 2, 'Tudo Ok', 'Cachorro com a saude em dia', 1)");
            migrationBuilder.Sql("INSERT INTO `apidogdb`.`atendimentos` (`AtendimentoId`,`DataDeAtendimento`,`PetCachorroId`,`VeterinarioId`,`Diagnostico`,`Comentario`,`Status`) VALUES(8, '2022-02-23 00:00:00.000000', 4, 2, 'Tudo Ok', 'Cachorro com a saude em dia', 1)");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("drop table `apidogdb`.`atendimentos`");
        }
    }
}
