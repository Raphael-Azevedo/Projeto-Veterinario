using Microsoft.EntityFrameworkCore.Migrations;

namespace DogAPI.Migrations
{
    public partial class Populadados : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("INSERT INTO `apidogdb`.`dados` (`id`,`imperial`,`metric`) VALUES(1, '21.5 - 24.5', '55 - 62');");
            migrationBuilder.Sql("INSERT INTO `apidogdb`.`dados` (`id`,`imperial`,`metric`) VALUES(2, '55 - 80', '25 - 36');");
            migrationBuilder.Sql("INSERT INTO `apidogdb`.`dados` (`id`,`imperial`,`metric`) VALUES(3, '21 - 23', '53 - 58');");
            migrationBuilder.Sql("INSERT INTO `apidogdb`.`dados` (`id`,`imperial`,`metric`) VALUES(4, '40 - 65', '18 - 29');");
            migrationBuilder.Sql("INSERT INTO `apidogdb`.`dados` (`id`,`imperial`,`metric`) VALUES(5, '18 - 22', '46 - 56');");
            migrationBuilder.Sql("INSERT INTO `apidogdb`.`dados` (`id`,`imperial`,`metric`) VALUES(6, '30 - 45', '14 - 20');");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("drop table `apidogdb`.`dados`");
        }
    }
}
