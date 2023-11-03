using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VShop.Migrations
{
    /// <inheritdoc />
    public partial class SeedProducts : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder mb)
        {
            mb.Sql("Insert into Products(Name, Price, Description, Stock, ImageURL, CategoryId)" +
                "Values('Caderno',7.55, 'Caderno',10, 'caderno1.jpg',1)");
            mb.Sql("Insert into Products(Name, Price, Description, Stock, ImageURL, CategoryId)" +
                "Values('Lápis',3.55, 'Lápis Preto',20, 'lapis1.jpg',1)");
            mb.Sql("Insert into Products(Name, Price, Description, Stock, ImageURL, CategoryId)" +
                "Values('Clipes para Papel',5.33, 'Clipes para Papel',50, 'clips1.jpg',2)");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder mb)
        {
            mb.Sql("delete from Products");
        }
    }
}
