using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace ShepherdsPies.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "text", nullable: false),
                    Name = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "text", nullable: false),
                    UserName = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "boolean", nullable: false),
                    PasswordHash = table.Column<string>(type: "text", nullable: true),
                    SecurityStamp = table.Column<string>(type: "text", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "text", nullable: true),
                    PhoneNumber = table.Column<string>(type: "text", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "boolean", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "boolean", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "boolean", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Cheeses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Type = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cheeses", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Sauces",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Type = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sauces", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Sizes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Length = table.Column<string>(type: "text", nullable: false),
                    Cost = table.Column<decimal>(type: "numeric", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sizes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Toppings",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Toppings", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    RoleId = table.Column<string>(type: "text", nullable: false),
                    ClaimType = table.Column<string>(type: "text", nullable: true),
                    ClaimValue = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    UserId = table.Column<string>(type: "text", nullable: false),
                    ClaimType = table.Column<string>(type: "text", nullable: true),
                    ClaimValue = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "text", nullable: false),
                    ProviderKey = table.Column<string>(type: "text", nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "text", nullable: true),
                    UserId = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "text", nullable: false),
                    RoleId = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "text", nullable: false),
                    LoginProvider = table.Column<string>(type: "text", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Value = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserProfiles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    FirstName = table.Column<string>(type: "text", nullable: false),
                    LastName = table.Column<string>(type: "text", nullable: false),
                    Address = table.Column<string>(type: "text", nullable: false),
                    IdentityUserId = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserProfiles", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserProfiles_AspNetUsers_IdentityUserId",
                        column: x => x.IdentityUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    EmployeeId = table.Column<int>(type: "integer", nullable: false),
                    TableNumber = table.Column<int>(type: "integer", nullable: true),
                    DriverId = table.Column<int>(type: "integer", nullable: true),
                    Tipped = table.Column<decimal>(type: "numeric", nullable: true),
                    OrderDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Orders_UserProfiles_DriverId",
                        column: x => x.DriverId,
                        principalTable: "UserProfiles",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Orders_UserProfiles_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "UserProfiles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Pizzas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    SizeId = table.Column<int>(type: "integer", nullable: false),
                    CheeseId = table.Column<int>(type: "integer", nullable: false),
                    SauceId = table.Column<int>(type: "integer", nullable: false),
                    OrderId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pizzas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Pizzas_Cheeses_CheeseId",
                        column: x => x.CheeseId,
                        principalTable: "Cheeses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Pizzas_Orders_OrderId",
                        column: x => x.OrderId,
                        principalTable: "Orders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Pizzas_Sauces_SauceId",
                        column: x => x.SauceId,
                        principalTable: "Sauces",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Pizzas_Sizes_SizeId",
                        column: x => x.SizeId,
                        principalTable: "Sizes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PizzaToppings",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    PizzaId = table.Column<int>(type: "integer", nullable: false),
                    ToppingId = table.Column<int>(type: "integer", nullable: false),
                    Quantity = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PizzaToppings", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PizzaToppings_Pizzas_PizzaId",
                        column: x => x.PizzaId,
                        principalTable: "Pizzas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PizzaToppings_Toppings_ToppingId",
                        column: x => x.ToppingId,
                        principalTable: "Toppings",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "c3aaeb97-d2ba-4a53-a521-4eea61e59b35", "fe0cb316-b130-40db-bc15-90eb895d3e0f", "Admin", "admin" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "075aa239-f0fa-46d7-8cb5-223d4064e582", 0, "4c164f3a-2ee2-4dfe-8935-69133f848077", "joshb@gmail.com", false, false, null, null, null, "AQAAAAEAACcQAAAAEE8Z4d5fHu4UL5c1pI+AfaVewYYSfFPwIysEpFUCvQ+18Aoq9G7J9BcLi3YkTTnQpg==", null, false, "43f0bc9a-2505-45da-8f1e-7e7e87a669c3", false, "joshb" },
                    { "5b795ef4-89bd-4de6-b6e1-6bb3dc469242", 0, "295b148b-8d4e-4c31-84c4-e5e6b0001eeb", "jdfitz@gmail.com", false, false, null, null, null, "AQAAAAEAACcQAAAAEHHH2iZuk0P0iK9Ct87mbCzMSz+At7FFgfQ6GfmMQB3JmQ0crR3S9jT23xkLxzhY/Q==", null, false, "f4faeae6-4ce5-46fe-bba4-8175154946ec", false, "jdfitz" },
                    { "6245ffde-88da-4745-bd81-32943de1fa00", 0, "0c4a3bf5-8a76-49fa-bbd8-6a775991ee33", "jbarton@gmail.com", false, false, null, null, null, "AQAAAAEAACcQAAAAEAkwG4a/+exKKH90L2fVLer3EcNOO3/xkLjwLrcqo/hl7P9r7XlzwRdhB8iuE5trxQ==", null, false, "b3dd925a-a1b7-4a2e-9ec4-3b1eedb922f5", false, "jbarton" },
                    { "8fe414ed-22f8-4dd5-8cde-f5bcf922cec0", 0, "427d9e04-bbbd-439b-9c0f-0be40929633d", "calebs@gmail.com", false, false, null, null, null, "AQAAAAEAACcQAAAAEEbUUowrD8C2RD6bysd45BiysTEzkeADzRJZXELV15Qm7EABiY7qjrvjnyFZGH7A/Q==", null, false, "7d6a2e83-a563-4eb1-bd45-b7ef65a2161f", false, "csullivan" },
                    { "dbc40bc6-0829-4ac5-a3ed-180f5e916a5f", 0, "09ed1f9e-bd8e-4c2e-bcef-595b03ed6340", "admina@strator.comx", false, false, null, null, null, "AQAAAAEAACcQAAAAEEaX5StMd60lxTyriiWZpTXaVTXKL+BFfH+YnauNnjbaFgxOJ0WYqeh2oflnvHNgOg==", null, false, "9f339232-3d32-4404-9a3f-f638befe828c", false, "Administrator" },
                    { "e53af84d-c3d0-4db8-9a6a-680985b82553", 0, "32f86324-3c41-4185-8081-adb033a7c249", "greg@gmail.com", false, false, null, null, null, "AQAAAAEAACcQAAAAEBZ+KbjnHxeJX56C6HbzOa1kaAzRa2jJsHPuKSf1EQW306fzUhIRzeuXpq+FWlkbGg==", null, false, "9f751b41-b233-41fb-94cc-2104e6649a0c", false, "greg" }
                });

            migrationBuilder.InsertData(
                table: "Cheeses",
                columns: new[] { "Id", "Type" },
                values: new object[,]
                {
                    { 1, "Mozzarella" },
                    { 2, "Buffalo Mozzarella" },
                    { 3, "Four Cheese" },
                    { 4, "Vegan" },
                    { 5, "Parmesan" },
                    { 6, "None (Cheeseless)" }
                });

            migrationBuilder.InsertData(
                table: "Sauces",
                columns: new[] { "Id", "Type" },
                values: new object[,]
                {
                    { 1, "Marinara" },
                    { 2, "Arrabbiata" },
                    { 3, "Garlic White" },
                    { 4, "Pesto" },
                    { 5, "None (Sauceless)" }
                });

            migrationBuilder.InsertData(
                table: "Sizes",
                columns: new[] { "Id", "Cost", "Length", "Name" },
                values: new object[,]
                {
                    { 1, 10.00m, "10\"", "Small" },
                    { 2, 12.00m, "14\"", "Medium" },
                    { 3, 15.00m, "18\"", "Large" }
                });

            migrationBuilder.InsertData(
                table: "Toppings",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Pepperoni" },
                    { 2, "Sausage" },
                    { 3, "Mushroom" },
                    { 4, "Onion" },
                    { 5, "Green Pepper" },
                    { 6, "Black Olive" },
                    { 7, "Basil" },
                    { 8, "Bacon" },
                    { 9, "Spinach" },
                    { 10, "Pineapple" },
                    { 11, "Extra Cheese" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "c3aaeb97-d2ba-4a53-a521-4eea61e59b35", "dbc40bc6-0829-4ac5-a3ed-180f5e916a5f" });

            migrationBuilder.InsertData(
                table: "UserProfiles",
                columns: new[] { "Id", "Address", "FirstName", "IdentityUserId", "LastName" },
                values: new object[,]
                {
                    { 1, "101 Main Street", "Admina", "dbc40bc6-0829-4ac5-a3ed-180f5e916a5f", "Strator" },
                    { 2, "132 Main Street", "JD", "5b795ef4-89bd-4de6-b6e1-6bb3dc469242", "Fitzmartin" },
                    { 3, "523 Ocean Ave", "Greg", "e53af84d-c3d0-4db8-9a6a-680985b82553", "Korte" },
                    { 4, "636 Palm Street", "Josh", "6245ffde-88da-4745-bd81-32943de1fa00", "Barton" },
                    { 5, "5345 Equador Way", "Caleb", "8fe414ed-22f8-4dd5-8cde-f5bcf922cec0", "Sullivan" },
                    { 6, "643 Palm Street", "Josh", "075aa239-f0fa-46d7-8cb5-223d4064e582", "Baugh" }
                });

            migrationBuilder.InsertData(
                table: "Orders",
                columns: new[] { "Id", "DriverId", "EmployeeId", "OrderDate", "TableNumber", "Tipped" },
                values: new object[,]
                {
                    { 1, null, 2, new DateTime(2023, 9, 16, 17, 30, 50, 0, DateTimeKind.Unspecified), 3, 6.80m },
                    { 2, 4, 2, new DateTime(2023, 9, 16, 18, 25, 22, 0, DateTimeKind.Unspecified), null, 11m },
                    { 3, null, 3, new DateTime(2023, 9, 17, 12, 4, 35, 0, DateTimeKind.Unspecified), 6, null },
                    { 4, 5, 6, new DateTime(2023, 9, 18, 12, 4, 11, 0, DateTimeKind.Unspecified), null, 8.75m },
                    { 5, 4, 5, new DateTime(2023, 9, 18, 13, 48, 37, 0, DateTimeKind.Unspecified), null, 4.95m },
                    { 6, null, 4, new DateTime(2023, 9, 18, 15, 22, 58, 0, DateTimeKind.Unspecified), 1, 12m },
                    { 7, null, 5, new DateTime(2023, 9, 20, 11, 7, 47, 0, DateTimeKind.Unspecified), 2, null },
                    { 8, 6, 3, new DateTime(2023, 9, 22, 12, 34, 51, 0, DateTimeKind.Unspecified), null, 8.55m },
                    { 9, 5, 2, new DateTime(2023, 9, 22, 14, 41, 8, 0, DateTimeKind.Unspecified), null, 6.39m }
                });

            migrationBuilder.InsertData(
                table: "Pizzas",
                columns: new[] { "Id", "CheeseId", "OrderId", "SauceId", "SizeId" },
                values: new object[,]
                {
                    { 1, 1, 1, 1, 2 },
                    { 2, 2, 2, 5, 1 },
                    { 3, 5, 2, 3, 2 },
                    { 4, 4, 3, 4, 3 },
                    { 5, 6, 4, 2, 3 },
                    { 6, 2, 4, 4, 1 },
                    { 7, 1, 5, 3, 1 },
                    { 8, 3, 6, 1, 1 },
                    { 9, 4, 6, 5, 2 },
                    { 10, 3, 6, 1, 3 },
                    { 11, 5, 7, 1, 1 },
                    { 12, 1, 8, 2, 2 },
                    { 13, 6, 8, 3, 1 },
                    { 14, 1, 9, 3, 2 },
                    { 15, 2, 9, 1, 3 }
                });

            migrationBuilder.InsertData(
                table: "PizzaToppings",
                columns: new[] { "Id", "PizzaId", "Quantity", "ToppingId" },
                values: new object[,]
                {
                    { 1, 1, 8, 1 },
                    { 2, 1, 8, 8 },
                    { 3, 1, 8, 9 },
                    { 4, 2, 10, 1 },
                    { 5, 3, 11, 1 },
                    { 6, 3, 7, 1 },
                    { 7, 4, 9, 1 },
                    { 8, 5, 12, 1 },
                    { 9, 5, 15, 1 },
                    { 10, 5, 7, 1 },
                    { 11, 6, 7, 1 },
                    { 12, 6, 4, 1 },
                    { 13, 7, 10, 1 },
                    { 14, 8, 11, 1 },
                    { 15, 9, 12, 1 },
                    { 16, 9, 10, 1 },
                    { 17, 10, 5, 1 },
                    { 18, 11, 6, 1 },
                    { 19, 11, 8, 1 },
                    { 20, 11, 7, 1 },
                    { 21, 12, 8, 1 },
                    { 22, 12, 9, 1 },
                    { 23, 13, 10, 1 },
                    { 24, 14, 10, 1 },
                    { 25, 15, 7, 1 },
                    { 26, 15, 8, 1 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Orders_DriverId",
                table: "Orders",
                column: "DriverId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_EmployeeId",
                table: "Orders",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_Pizzas_CheeseId",
                table: "Pizzas",
                column: "CheeseId");

            migrationBuilder.CreateIndex(
                name: "IX_Pizzas_OrderId",
                table: "Pizzas",
                column: "OrderId");

            migrationBuilder.CreateIndex(
                name: "IX_Pizzas_SauceId",
                table: "Pizzas",
                column: "SauceId");

            migrationBuilder.CreateIndex(
                name: "IX_Pizzas_SizeId",
                table: "Pizzas",
                column: "SizeId");

            migrationBuilder.CreateIndex(
                name: "IX_PizzaToppings_PizzaId",
                table: "PizzaToppings",
                column: "PizzaId");

            migrationBuilder.CreateIndex(
                name: "IX_PizzaToppings_ToppingId",
                table: "PizzaToppings",
                column: "ToppingId");

            migrationBuilder.CreateIndex(
                name: "IX_UserProfiles_IdentityUserId",
                table: "UserProfiles",
                column: "IdentityUserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "PizzaToppings");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "Pizzas");

            migrationBuilder.DropTable(
                name: "Toppings");

            migrationBuilder.DropTable(
                name: "Cheeses");

            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.DropTable(
                name: "Sauces");

            migrationBuilder.DropTable(
                name: "Sizes");

            migrationBuilder.DropTable(
                name: "UserProfiles");

            migrationBuilder.DropTable(
                name: "AspNetUsers");
        }
    }
}
