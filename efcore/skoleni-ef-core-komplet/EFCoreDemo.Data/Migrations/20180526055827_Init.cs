using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace EFCoreDemo.Data.Migrations
{
    public partial class Init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "dbo");

            migrationBuilder.CreateSequence<int>(
                name: "OrderNumbers",
                schema: "dbo",
                startValue: 20180001L);

            migrationBuilder.CreateTable(
                name: "Brands",
                schema: "dbo",
                columns: table => new
                {
                    BrandId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    BrandIdentifier = table.Column<string>(nullable: false),
                    Title = table.Column<string>(nullable: false),
                    Numero = table.Column<int>(type: "nvarchar(200)", nullable: false),
                    Timestamp = table.Column<byte[]>(rowVersion: true, nullable: true),
                    LastUpdated = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Brands", x => x.BrandId);
                    table.UniqueConstraint("AlternateKey_BrandIdentifier", x => x.BrandIdentifier);
                });

            migrationBuilder.CreateTable(
                name: "Categories",
                schema: "dbo",
                columns: table => new
                {
                    CategoryId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Title = table.Column<string>(maxLength: 100, nullable: false),
                    SeoLink = table.Column<string>(maxLength: 100, nullable: false),
                    Extras = table.Column<string>(nullable: true),
                    Url = table.Column<string>(type: "varchar(200)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.CategoryId);
                });

            migrationBuilder.CreateTable(
                name: "Orders",
                schema: "dbo",
                columns: table => new
                {
                    OrderId = table.Column<Guid>(nullable: false),
                    Price_BasePrice = table.Column<decimal>(nullable: false),
                    Price_VatRate = table.Column<decimal>(nullable: false),
                    Created = table.Column<DateTime>(nullable: false),
                    OrderNo = table.Column<int>(nullable: false, defaultValueSql: "NEXT VALUE FOR dbo.OrderNumbers"),
                    OrderState = table.Column<int>(nullable: false, defaultValue: 2),
                    ShippingAddress_FirstName = table.Column<string>(nullable: true),
                    ShippingAddress_LastName = table.Column<string>(nullable: true),
                    BillingAddress_FirstName = table.Column<string>(nullable: true),
                    BillingAddress_LastName = table.Column<string>(nullable: true),
                    BillingAddress_Email = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.OrderId);
                });

            migrationBuilder.CreateTable(
                name: "Persons",
                schema: "dbo",
                columns: table => new
                {
                    DepartmentIdentifier = table.Column<int>(nullable: false),
                    DepartmentEmployeeIdentifier = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Persons", x => new { x.DepartmentEmployeeIdentifier, x.DepartmentIdentifier });
                });

            migrationBuilder.CreateTable(
                name: "Relations",
                schema: "dbo",
                columns: table => new
                {
                    RelationId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    SourceObjectId = table.Column<int>(nullable: false),
                    SourceObjectType = table.Column<int>(nullable: false),
                    ObjectId = table.Column<int>(nullable: false),
                    ObjectType = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Relations", x => x.RelationId);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                schema: "dbo",
                columns: table => new
                {
                    ProductId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    BrandIdentifier = table.Column<string>(nullable: false),
                    Title = table.Column<string>(maxLength: 100, nullable: false),
                    SeoLink = table.Column<string>(maxLength: 100, nullable: false),
                    Price_BasePrice = table.Column<decimal>(type: "decimal(10, 2)", nullable: false, defaultValue: 0m),
                    Price_VatRate = table.Column<decimal>(type: "decimal(4, 3)", nullable: false),
                    ProductWarehouseIdent = table.Column<string>(type: "nvarchar(200)", nullable: true, computedColumnSql: "'PRD-' + [SeoLink]"),
                    ProductType = table.Column<int>(nullable: false),
                    RssDescritpion = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.ProductId);
                    table.ForeignKey(
                        name: "FK_Products_Brands_BrandIdentifier",
                        column: x => x.BrandIdentifier,
                        principalSchema: "dbo",
                        principalTable: "Brands",
                        principalColumn: "BrandIdentifier",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Images",
                schema: "dbo",
                columns: table => new
                {
                    ImageId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ProductId = table.Column<int>(nullable: false),
                    Title = table.Column<string>(maxLength: 100, nullable: false),
                    Url = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Images", x => x.ImageId);
                    table.ForeignKey(
                        name: "FK_Images_Products_ProductId",
                        column: x => x.ProductId,
                        principalSchema: "dbo",
                        principalTable: "Products",
                        principalColumn: "ProductId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "OrderItem",
                schema: "dbo",
                columns: table => new
                {
                    OrderItemId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    OrderId = table.Column<Guid>(nullable: false),
                    OriginalProductId = table.Column<int>(nullable: true),
                    Title = table.Column<string>(maxLength: 100, nullable: false),
                    Price_BasePrice = table.Column<decimal>(nullable: false),
                    Price_VatRate = table.Column<decimal>(nullable: false),
                    Amount = table.Column<int>(nullable: false),
                    TotalPrice_BasePrice = table.Column<decimal>(nullable: false),
                    TotalPrice_VatRate = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderItem", x => x.OrderItemId);
                    table.ForeignKey(
                        name: "FK_OrderItem_Orders_OrderId",
                        column: x => x.OrderId,
                        principalSchema: "dbo",
                        principalTable: "Orders",
                        principalColumn: "OrderId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OrderItem_Products_OriginalProductId",
                        column: x => x.OriginalProductId,
                        principalSchema: "dbo",
                        principalTable: "Products",
                        principalColumn: "ProductId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ProductCategories",
                schema: "dbo",
                columns: table => new
                {
                    ProductId = table.Column<int>(nullable: false),
                    CategoryId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductCategories", x => new { x.ProductId, x.CategoryId });
                    table.ForeignKey(
                        name: "FK_ProductCategories_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalSchema: "dbo",
                        principalTable: "Categories",
                        principalColumn: "CategoryId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProductCategories_Products_ProductId",
                        column: x => x.ProductId,
                        principalSchema: "dbo",
                        principalTable: "Products",
                        principalColumn: "ProductId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Brands_BrandIdentifier",
                schema: "dbo",
                table: "Brands",
                column: "BrandIdentifier",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Category_SeoLink",
                schema: "dbo",
                table: "Categories",
                column: "SeoLink",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Images_ProductId",
                schema: "dbo",
                table: "Images",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderItem_OrderId",
                schema: "dbo",
                table: "OrderItem",
                column: "OrderId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderItem_OriginalProductId",
                schema: "dbo",
                table: "OrderItem",
                column: "OriginalProductId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductCategories_CategoryId",
                schema: "dbo",
                table: "ProductCategories",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_BrandIdentifier",
                schema: "dbo",
                table: "Products",
                column: "BrandIdentifier");

            migrationBuilder.CreateIndex(
                name: "IX_Products_SeoLink",
                schema: "dbo",
                table: "Products",
                column: "SeoLink",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Images",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "OrderItem",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "Persons",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "ProductCategories",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "Relations",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "Orders",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "Categories",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "Products",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "Brands",
                schema: "dbo");

            migrationBuilder.DropSequence(
                name: "OrderNumbers",
                schema: "dbo");
        }
    }
}
