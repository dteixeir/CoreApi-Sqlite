using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace dotNetApi.Migrations
{
    public partial class MyFirstMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Breweries",
                columns: table => new
                {
                    Id = table.Column<string>(maxLength: 32, nullable: false),
                    Address1 = table.Column<string>(nullable: true),
                    Address2 = table.Column<string>(nullable: true),
                    City = table.Column<string>(nullable: true),
                    Code = table.Column<string>(nullable: true),
                    Country = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    FilePath = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    Phone = table.Column<string>(nullable: true),
                    State = table.Column<string>(nullable: true),
                    Website = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Breweries", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Id = table.Column<string>(maxLength: 32, nullable: false),
                    Description = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Styles",
                columns: table => new
                {
                    Id = table.Column<string>(maxLength: 32, nullable: false),
                    Category_Id = table.Column<string>(maxLength: 32, nullable: true),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Styles", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Styles_Categories_Category_Id",
                        column: x => x.Category_Id,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Beers",
                columns: table => new
                {
                    Id = table.Column<string>(maxLength: 32, nullable: false),
                    AlcoholByVolume = table.Column<int>(nullable: false),
                    Brewery_Id = table.Column<string>(maxLength: 32, nullable: true),
                    Category_Id = table.Column<string>(maxLength: 32, nullable: true),
                    Description = table.Column<string>(nullable: true),
                    Filepath = table.Column<string>(nullable: true),
                    InternationalBitternessUnits = table.Column<int>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    StandardReferenceMethod = table.Column<int>(nullable: false),
                    Style_Id = table.Column<string>(maxLength: 32, nullable: true),
                    UniversalProductCode = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Beers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Beers_Breweries_Brewery_Id",
                        column: x => x.Brewery_Id,
                        principalTable: "Breweries",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Beers_Categories_Category_Id",
                        column: x => x.Category_Id,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Beers_Styles_Style_Id",
                        column: x => x.Style_Id,
                        principalTable: "Styles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Beers_Brewery_Id",
                table: "Beers",
                column: "Brewery_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Beers_Category_Id",
                table: "Beers",
                column: "Category_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Beers_Style_Id",
                table: "Beers",
                column: "Style_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Styles_Category_Id",
                table: "Styles",
                column: "Category_Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Beers");

            migrationBuilder.DropTable(
                name: "Breweries");

            migrationBuilder.DropTable(
                name: "Styles");

            migrationBuilder.DropTable(
                name: "Categories");
        }
    }
}
