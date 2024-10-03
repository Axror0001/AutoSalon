using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace AutoSalonAPI.Migrations
{
    /// <inheritdoc />
    public partial class b1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "BMWcompanys",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Code = table.Column<string>(type: "text", nullable: false),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    CreatedBy = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    CreatedIp = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    ModifiedBy = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    ModifiedIp = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    Guid = table.Column<Guid>(type: "uuid", nullable: false),
                    CompanyName = table.Column<string>(type: "text", nullable: false),
                    CompanyBreand = table.Column<string>(type: "text", nullable: false),
                    CompanyDirector = table.Column<string>(type: "text", nullable: false),
                    Country = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BMWcompanys", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "BYDcompanys",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Code = table.Column<string>(type: "text", nullable: false),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    CreatedBy = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    CreatedIp = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    ModifiedBy = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    ModifiedIp = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    Guid = table.Column<Guid>(type: "uuid", nullable: false),
                    CompanyName = table.Column<string>(type: "text", nullable: false),
                    CompanyBreand = table.Column<string>(type: "text", nullable: false),
                    CompanyDirector = table.Column<string>(type: "text", nullable: false),
                    Country = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BYDcompanys", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Chevroletcompanys",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Code = table.Column<string>(type: "text", nullable: false),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    CreatedBy = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    CreatedIp = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    ModifiedBy = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    ModifiedIp = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    Guid = table.Column<Guid>(type: "uuid", nullable: false),
                    CompanyName = table.Column<string>(type: "text", nullable: false),
                    CompanyBreand = table.Column<string>(type: "text", nullable: false),
                    CompanyDirector = table.Column<string>(type: "text", nullable: false),
                    Country = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Chevroletcompanys", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MersedensBenscompanys",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Code = table.Column<string>(type: "text", nullable: false),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    CreatedBy = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    CreatedIp = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    ModifiedBy = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    ModifiedIp = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    Guid = table.Column<Guid>(type: "uuid", nullable: false),
                    CompanyName = table.Column<string>(type: "text", nullable: false),
                    CompanyBreand = table.Column<string>(type: "text", nullable: false),
                    CompanyDirector = table.Column<string>(type: "text", nullable: false),
                    Country = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MersedensBenscompanys", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Toyotocompanys",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Code = table.Column<string>(type: "text", nullable: false),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    CreatedBy = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    CreatedIp = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    ModifiedBy = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    ModifiedIp = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    Guid = table.Column<Guid>(type: "uuid", nullable: false),
                    CompanyName = table.Column<string>(type: "text", nullable: false),
                    CompanyBreand = table.Column<string>(type: "text", nullable: false),
                    CompanyDirector = table.Column<string>(type: "text", nullable: false),
                    Country = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Toyotocompanys", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "BMWcars",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Code = table.Column<string>(type: "text", nullable: false),
                    CompanyId = table.Column<long>(type: "bigint", nullable: false),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    CreatedBy = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    CreatedIp = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    ModifiedBy = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    ModifiedIp = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    Guid = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Color = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BMWcars", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BMWcars_BMWcompanys_CompanyId",
                        column: x => x.CompanyId,
                        principalTable: "BMWcompanys",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "BmwTranslationCompany",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    bmwId = table.Column<long>(type: "bigint", nullable: false),
                    BMWcompanysId = table.Column<long>(type: "bigint", nullable: false),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    CreatedBy = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    CreatedIp = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    ModifiedBy = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    ModifiedIp = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    LanguageCode = table.Column<string>(type: "text", nullable: false),
                    ShortTitle = table.Column<string>(type: "text", nullable: false),
                    FullTitle = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BmwTranslationCompany", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BmwTranslationCompany_BMWcompanys_BMWcompanysId",
                        column: x => x.BMWcompanysId,
                        principalTable: "BMWcompanys",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "BYDcars",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Code = table.Column<string>(type: "text", nullable: false),
                    CompanyId = table.Column<long>(type: "bigint", nullable: false),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    CreatedBy = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    CreatedIp = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    ModifiedBy = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    ModifiedIp = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    Guid = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Color = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BYDcars", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BYDcars_BYDcompanys_CompanyId",
                        column: x => x.CompanyId,
                        principalTable: "BYDcompanys",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "BYDtranslationCompany",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    bydId = table.Column<long>(type: "bigint", nullable: false),
                    BYDcompanysId = table.Column<long>(type: "bigint", nullable: false),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    CreatedBy = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    CreatedIp = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    ModifiedBy = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    ModifiedIp = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    LanguageCode = table.Column<string>(type: "text", nullable: false),
                    ShortTitle = table.Column<string>(type: "text", nullable: false),
                    FullTitle = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BYDtranslationCompany", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BYDtranslationCompany_BYDcompanys_BYDcompanysId",
                        column: x => x.BYDcompanysId,
                        principalTable: "BYDcompanys",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Chevroletcars",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Code = table.Column<string>(type: "text", nullable: false),
                    CompanyId = table.Column<long>(type: "bigint", nullable: false),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    CreatedBy = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    CreatedIp = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    ModifiedBy = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    ModifiedIp = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    Guid = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Color = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Chevroletcars", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Chevroletcars_Chevroletcompanys_CompanyId",
                        column: x => x.CompanyId,
                        principalTable: "Chevroletcompanys",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ChevroletTranslations",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    ChevroletId = table.Column<long>(type: "bigint", nullable: false),
                    ChevroletcompanysId = table.Column<long>(type: "bigint", nullable: false),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    CreatedBy = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    CreatedIp = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    ModifiedBy = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    ModifiedIp = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    LanguageCode = table.Column<string>(type: "text", nullable: false),
                    ShortTitle = table.Column<string>(type: "text", nullable: false),
                    FullTitle = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ChevroletTranslations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ChevroletTranslations_Chevroletcompanys_ChevroletcompanysId",
                        column: x => x.ChevroletcompanysId,
                        principalTable: "Chevroletcompanys",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MersedensBenscars",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Code = table.Column<string>(type: "text", nullable: false),
                    CompanyId = table.Column<long>(type: "bigint", nullable: false),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    CreatedBy = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    CreatedIp = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    ModifiedBy = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    ModifiedIp = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    Guid = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Color = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MersedensBenscars", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MersedensBenscars_MersedensBenscompanys_CompanyId",
                        column: x => x.CompanyId,
                        principalTable: "MersedensBenscompanys",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MersTranslationCompany",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    MersId = table.Column<long>(type: "bigint", nullable: false),
                    MersedensBenscompanysId = table.Column<long>(type: "bigint", nullable: false),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    CreatedBy = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    CreatedIp = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    ModifiedBy = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    ModifiedIp = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    LanguageCode = table.Column<string>(type: "text", nullable: false),
                    ShortTitle = table.Column<string>(type: "text", nullable: false),
                    FullTitle = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MersTranslationCompany", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MersTranslationCompany_MersedensBenscompanys_MersedensBensc~",
                        column: x => x.MersedensBenscompanysId,
                        principalTable: "MersedensBenscompanys",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Toyotocars",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Code = table.Column<string>(type: "text", nullable: false),
                    CompanyId = table.Column<long>(type: "bigint", nullable: false),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    CreatedBy = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    CreatedIp = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    ModifiedBy = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    ModifiedIp = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    Guid = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Color = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Toyotocars", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Toyotocars_Toyotocompanys_CompanyId",
                        column: x => x.CompanyId,
                        principalTable: "Toyotocompanys",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ToyotoTranslationCompany",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    ToyotoId = table.Column<long>(type: "bigint", nullable: false),
                    ToyotoCompanysId = table.Column<long>(type: "bigint", nullable: false),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    CreatedBy = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    CreatedIp = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    ModifiedBy = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    ModifiedIp = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    LanguageCode = table.Column<string>(type: "text", nullable: false),
                    ShortTitle = table.Column<string>(type: "text", nullable: false),
                    FullTitle = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ToyotoTranslationCompany", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ToyotoTranslationCompany_Toyotocompanys_ToyotoCompanysId",
                        column: x => x.ToyotoCompanysId,
                        principalTable: "Toyotocompanys",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "BMWTranslation",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    bmwId = table.Column<long>(type: "bigint", nullable: false),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    CreatedBy = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    CreatedIp = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    ModifiedBy = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    ModifiedIp = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    LanguageCode = table.Column<string>(type: "text", nullable: false),
                    ShortTitle = table.Column<string>(type: "text", nullable: false),
                    FullTitle = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BMWTranslation", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BMWTranslation_BMWcars_bmwId",
                        column: x => x.bmwId,
                        principalTable: "BMWcars",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "BYDtranslationCars",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    bydId = table.Column<long>(type: "bigint", nullable: false),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    CreatedBy = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    CreatedIp = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    ModifiedBy = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    ModifiedIp = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    LanguageCode = table.Column<string>(type: "text", nullable: false),
                    ShortTitle = table.Column<string>(type: "text", nullable: false),
                    FullTitle = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BYDtranslationCars", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BYDtranslationCars_BYDcars_bydId",
                        column: x => x.bydId,
                        principalTable: "BYDcars",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ChevroletTranslationCars",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    ChevroletId = table.Column<long>(type: "bigint", nullable: false),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    CreatedBy = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    CreatedIp = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    ModifiedBy = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    ModifiedIp = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    LanguageCode = table.Column<string>(type: "text", nullable: false),
                    ShortTitle = table.Column<string>(type: "text", nullable: false),
                    FullTitle = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ChevroletTranslationCars", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ChevroletTranslationCars_Chevroletcars_ChevroletId",
                        column: x => x.ChevroletId,
                        principalTable: "Chevroletcars",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MersTranslationCars",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    MersId = table.Column<long>(type: "bigint", nullable: false),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    CreatedBy = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    CreatedIp = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    ModifiedBy = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    ModifiedIp = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    LanguageCode = table.Column<string>(type: "text", nullable: false),
                    ShortTitle = table.Column<string>(type: "text", nullable: false),
                    FullTitle = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MersTranslationCars", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MersTranslationCars_MersedensBenscars_MersId",
                        column: x => x.MersId,
                        principalTable: "MersedensBenscars",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ToyotoTranslationCars",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    ToyotoId = table.Column<long>(type: "bigint", nullable: false),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    CreatedBy = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    CreatedIp = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    ModifiedBy = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    ModifiedIp = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    LanguageCode = table.Column<string>(type: "text", nullable: false),
                    ShortTitle = table.Column<string>(type: "text", nullable: false),
                    FullTitle = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ToyotoTranslationCars", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ToyotoTranslationCars_Toyotocars_ToyotoId",
                        column: x => x.ToyotoId,
                        principalTable: "Toyotocars",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BMWcars_CompanyId",
                table: "BMWcars",
                column: "CompanyId");

            migrationBuilder.CreateIndex(
                name: "IX_BMWTranslation_bmwId",
                table: "BMWTranslation",
                column: "bmwId");

            migrationBuilder.CreateIndex(
                name: "IX_BmwTranslationCompany_BMWcompanysId",
                table: "BmwTranslationCompany",
                column: "BMWcompanysId");

            migrationBuilder.CreateIndex(
                name: "IX_BYDcars_CompanyId",
                table: "BYDcars",
                column: "CompanyId");

            migrationBuilder.CreateIndex(
                name: "IX_BYDtranslationCars_bydId",
                table: "BYDtranslationCars",
                column: "bydId");

            migrationBuilder.CreateIndex(
                name: "IX_BYDtranslationCompany_BYDcompanysId",
                table: "BYDtranslationCompany",
                column: "BYDcompanysId");

            migrationBuilder.CreateIndex(
                name: "IX_Chevroletcars_CompanyId",
                table: "Chevroletcars",
                column: "CompanyId");

            migrationBuilder.CreateIndex(
                name: "IX_ChevroletTranslationCars_ChevroletId",
                table: "ChevroletTranslationCars",
                column: "ChevroletId");

            migrationBuilder.CreateIndex(
                name: "IX_ChevroletTranslations_ChevroletcompanysId",
                table: "ChevroletTranslations",
                column: "ChevroletcompanysId");

            migrationBuilder.CreateIndex(
                name: "IX_MersedensBenscars_CompanyId",
                table: "MersedensBenscars",
                column: "CompanyId");

            migrationBuilder.CreateIndex(
                name: "IX_MersTranslationCars_MersId",
                table: "MersTranslationCars",
                column: "MersId");

            migrationBuilder.CreateIndex(
                name: "IX_MersTranslationCompany_MersedensBenscompanysId",
                table: "MersTranslationCompany",
                column: "MersedensBenscompanysId");

            migrationBuilder.CreateIndex(
                name: "IX_Toyotocars_CompanyId",
                table: "Toyotocars",
                column: "CompanyId");

            migrationBuilder.CreateIndex(
                name: "IX_ToyotoTranslationCars_ToyotoId",
                table: "ToyotoTranslationCars",
                column: "ToyotoId");

            migrationBuilder.CreateIndex(
                name: "IX_ToyotoTranslationCompany_ToyotoCompanysId",
                table: "ToyotoTranslationCompany",
                column: "ToyotoCompanysId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BMWTranslation");

            migrationBuilder.DropTable(
                name: "BmwTranslationCompany");

            migrationBuilder.DropTable(
                name: "BYDtranslationCars");

            migrationBuilder.DropTable(
                name: "BYDtranslationCompany");

            migrationBuilder.DropTable(
                name: "ChevroletTranslationCars");

            migrationBuilder.DropTable(
                name: "ChevroletTranslations");

            migrationBuilder.DropTable(
                name: "MersTranslationCars");

            migrationBuilder.DropTable(
                name: "MersTranslationCompany");

            migrationBuilder.DropTable(
                name: "ToyotoTranslationCars");

            migrationBuilder.DropTable(
                name: "ToyotoTranslationCompany");

            migrationBuilder.DropTable(
                name: "BMWcars");

            migrationBuilder.DropTable(
                name: "BYDcars");

            migrationBuilder.DropTable(
                name: "Chevroletcars");

            migrationBuilder.DropTable(
                name: "MersedensBenscars");

            migrationBuilder.DropTable(
                name: "Toyotocars");

            migrationBuilder.DropTable(
                name: "BMWcompanys");

            migrationBuilder.DropTable(
                name: "BYDcompanys");

            migrationBuilder.DropTable(
                name: "Chevroletcompanys");

            migrationBuilder.DropTable(
                name: "MersedensBenscompanys");

            migrationBuilder.DropTable(
                name: "Toyotocompanys");
        }
    }
}
