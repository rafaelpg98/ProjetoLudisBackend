using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace ProjetoLudis.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Comerciantes",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    RazaoSocial = table.Column<string>(nullable: true),
                    CPFCNPJ = table.Column<string>(nullable: true),
                    InscricaoEstadual = table.Column<string>(nullable: true),
                    InscricaoMunicipal = table.Column<string>(nullable: true),
                    IndicadorIE = table.Column<int>(nullable: false),
                    Regime = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Comerciantes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Esportistas",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    CPF = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Esportistas", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Usuarios",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Email = table.Column<string>(nullable: true),
                    Senha = table.Column<string>(nullable: true),
                    Telefone = table.Column<string>(nullable: true),
                    Endereco = table.Column<string>(nullable: true),
                    CEP = table.Column<string>(nullable: true),
                    Cidade = table.Column<string>(nullable: true),
                    Bairro = table.Column<string>(nullable: true),
                    Nome = table.Column<string>(nullable: true),
                    Complemento = table.Column<string>(nullable: true),
                    UF = table.Column<string>(nullable: true),
                    IdEsportista = table.Column<int>(nullable: true),
                    EsportistaId = table.Column<int>(nullable: true),
                    IdComerciante = table.Column<int>(nullable: true),
                    ComercianteId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuarios", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Usuarios_Comerciantes_ComercianteId",
                        column: x => x.ComercianteId,
                        principalTable: "Comerciantes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Usuarios_Esportistas_EsportistaId",
                        column: x => x.EsportistaId,
                        principalTable: "Esportistas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "Comerciantes",
                columns: new[] { "Id", "CPFCNPJ", "IndicadorIE", "InscricaoEstadual", "InscricaoMunicipal", "RazaoSocial", "Regime" },
                values: new object[] { 1, "1222521/0001-01", 0, " ", " ", "Clube do 100", 1 });

            migrationBuilder.InsertData(
                table: "Esportistas",
                columns: new[] { "Id", "CPF" },
                values: new object[] { 1, "13131308670" });

            migrationBuilder.InsertData(
                table: "Usuarios",
                columns: new[] { "Id", "Bairro", "CEP", "Cidade", "ComercianteId", "Complemento", "Email", "Endereco", "EsportistaId", "IdComerciante", "IdEsportista", "Nome", "Senha", "Telefone", "UF" },
                values: new object[,]
                {
                    { 1, "Centro", "37190000", "Três Pontas", null, " ", "Iury@teste.com.br", "R. José Caixambu Nº 213", null, null, 1, "Iury", "iury123", "997288193", "UF" },
                    { 2, "Centro", "37190000", "Três Pontas", null, " ", "           ", "R. José Caixambu Nº 213", null, null, 0, "Iury", "iury123", "997288193", "UF" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Usuarios_ComercianteId",
                table: "Usuarios",
                column: "ComercianteId");

            migrationBuilder.CreateIndex(
                name: "IX_Usuarios_EsportistaId",
                table: "Usuarios",
                column: "EsportistaId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Usuarios");

            migrationBuilder.DropTable(
                name: "Comerciantes");

            migrationBuilder.DropTable(
                name: "Esportistas");
        }
    }
}
