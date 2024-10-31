using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Movie_API.Migrations
{
    /// <inheritdoc />
    public partial class AddMovieTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.CreateTable(
            //    name: "MovieDetails",
            //    columns: table => new
            //    {
            //        Id = table.Column<int>(type: "int", nullable: false)
            //            .Annotation("SqlServer:Identity", "1, 1"),
            //        Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
            //        Year = table.Column<string>(type: "nvarchar(max)", nullable: false),
            //        Rated = table.Column<string>(type: "nvarchar(max)", nullable: false),
            //        Released = table.Column<string>(type: "nvarchar(max)", nullable: false),
            //        Language = table.Column<string>(type: "nvarchar(max)", nullable: false),
            //        Country = table.Column<string>(type: "nvarchar(max)", nullable: false)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_MovieDetails", x => x.Id);
            //    });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MovieDetails");
        }
    }
}
