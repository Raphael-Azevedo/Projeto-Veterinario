using Microsoft.EntityFrameworkCore.Migrations;

namespace DogAPI.Migrations
{
    public partial class Popularaca : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("INSERT INTO `apidogdb`.`raca` (`id`,`name`,`temperament`,`life_span`,`weightid`,`country_code`,`heightid`) VALUES(4, 'Airedale Terrier', 'Outgoing, Friendly, Alert, Confident, Intelligent, Courageous', '10 - 13 years', 4, NULL, 3);");
            migrationBuilder.Sql("INSERT INTO `apidogdb`.`raca` (`id`,`name`,`temperament`,`life_span`,`weightid`,`country_code`,`heightid`) VALUES(50, 'Border Collie', 'Tenacious, Keen, Energetic, Responsive, Alert, Intelligent', '12 - 16 years', 6, NULL, 5);");
            migrationBuilder.Sql(" INSERT INTO `apidogdb`.`raca` (`id`,`name`,`temperament`,`life_span`,`weightid`,`country_code`,`heightid`) VALUES(149, 'Labrador Retriever', 'Kind, Outgoing, Agile, Gentle, Intelligent, Trusting, Even Tempered', '10 - 13 years', 2, NULL, 1);");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("drop table `apidogdb`.`raca`");
        }
    }
}
