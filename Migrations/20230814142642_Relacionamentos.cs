using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EstacioneJa.Migrations
{
    /// <inheritdoc />
    public partial class Relacionamentos : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Vagas_Sensores_IdSensorId",
                table: "Vagas");

            migrationBuilder.DropIndex(
                name: "IX_Vagas_IdSensorId",
                table: "Vagas");

            migrationBuilder.DropColumn(
                name: "IdSensorId",
                table: "Vagas");

            migrationBuilder.RenameColumn(
                name: "Vaga",
                table: "Sensores",
                newName: "VagaSensor");

            migrationBuilder.AddColumn<int>(
                name: "SensorId",
                table: "Vagas",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "UsuarioId",
                table: "Usuarios",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "Latitude",
                table: "Sensores",
                type: "float",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "Longitude",
                table: "Sensores",
                type: "float",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "UsuarioPagamentos",
                columns: table => new
                {
                    UsuarioId = table.Column<int>(type: "int", nullable: false),
                    PagamentoId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UsuarioPagamentos", x => new { x.UsuarioId, x.PagamentoId });
                    table.ForeignKey(
                        name: "FK_UsuarioPagamentos_Pagamentos_PagamentoId",
                        column: x => x.PagamentoId,
                        principalTable: "Pagamentos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UsuarioPagamentos_Usuarios_UsuarioId",
                        column: x => x.UsuarioId,
                        principalTable: "Usuarios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "VagaUsuarios",
                columns: table => new
                {
                    VagaId = table.Column<int>(type: "int", nullable: false),
                    UsuarioId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VagaUsuarios", x => new { x.VagaId, x.UsuarioId });
                    table.ForeignKey(
                        name: "FK_VagaUsuarios_Usuarios_UsuarioId",
                        column: x => x.UsuarioId,
                        principalTable: "Usuarios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_VagaUsuarios_Vagas_VagaId",
                        column: x => x.VagaId,
                        principalTable: "Vagas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                table: "Usuarios",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "SenhaHash", "SenhaSalt", "UsuarioId" },
                values: new object[] { new byte[] { 127, 117, 23, 9, 51, 27, 110, 110, 135, 22, 163, 208, 154, 64, 160, 14, 247, 239, 168, 49, 112, 89, 230, 94, 198, 137, 128, 1, 152, 236, 106, 172, 11, 109, 0, 173, 144, 66, 30, 194, 116, 246, 237, 99, 134, 165, 156, 130, 145, 142, 101, 242, 127, 45, 233, 156, 168, 7, 121, 47, 102, 104, 110, 11 }, new byte[] { 121, 13, 255, 85, 146, 244, 53, 171, 32, 119, 64, 73, 165, 13, 41, 98, 35, 36, 67, 243, 156, 184, 211, 229, 208, 243, 5, 153, 229, 220, 189, 82, 45, 61, 93, 174, 97, 189, 129, 102, 6, 12, 201, 105, 163, 77, 197, 72, 199, 198, 208, 126, 218, 48, 130, 62, 121, 141, 186, 138, 65, 80, 227, 137, 198, 50, 237, 223, 129, 104, 119, 70, 252, 118, 146, 17, 176, 193, 2, 143, 157, 71, 134, 119, 122, 192, 60, 85, 149, 35, 164, 111, 28, 118, 241, 224, 75, 196, 62, 32, 235, 123, 22, 178, 113, 83, 18, 238, 167, 100, 14, 199, 32, 166, 104, 188, 66, 19, 49, 151, 221, 176, 121, 225, 87, 244, 101, 68 }, null });

            migrationBuilder.CreateIndex(
                name: "IX_Vagas_SensorId",
                table: "Vagas",
                column: "SensorId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Usuarios_UsuarioId",
                table: "Usuarios",
                column: "UsuarioId");

            migrationBuilder.CreateIndex(
                name: "IX_UsuarioPagamentos_PagamentoId",
                table: "UsuarioPagamentos",
                column: "PagamentoId");

            migrationBuilder.CreateIndex(
                name: "IX_VagaUsuarios_UsuarioId",
                table: "VagaUsuarios",
                column: "UsuarioId");

            migrationBuilder.AddForeignKey(
                name: "FK_Usuarios_Usuarios_UsuarioId",
                table: "Usuarios",
                column: "UsuarioId",
                principalTable: "Usuarios",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Vagas_Sensores_SensorId",
                table: "Vagas",
                column: "SensorId",
                principalTable: "Sensores",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Usuarios_Usuarios_UsuarioId",
                table: "Usuarios");

            migrationBuilder.DropForeignKey(
                name: "FK_Vagas_Sensores_SensorId",
                table: "Vagas");

            migrationBuilder.DropTable(
                name: "UsuarioPagamentos");

            migrationBuilder.DropTable(
                name: "VagaUsuarios");

            migrationBuilder.DropIndex(
                name: "IX_Vagas_SensorId",
                table: "Vagas");

            migrationBuilder.DropIndex(
                name: "IX_Usuarios_UsuarioId",
                table: "Usuarios");

            migrationBuilder.DropColumn(
                name: "SensorId",
                table: "Vagas");

            migrationBuilder.DropColumn(
                name: "UsuarioId",
                table: "Usuarios");

            migrationBuilder.DropColumn(
                name: "Latitude",
                table: "Sensores");

            migrationBuilder.DropColumn(
                name: "Longitude",
                table: "Sensores");

            migrationBuilder.RenameColumn(
                name: "VagaSensor",
                table: "Sensores",
                newName: "Vaga");

            migrationBuilder.AddColumn<int>(
                name: "IdSensorId",
                table: "Vagas",
                type: "int",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Usuarios",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "SenhaHash", "SenhaSalt" },
                values: new object[] { new byte[] { 39, 98, 183, 74, 87, 6, 128, 178, 22, 112, 17, 41, 78, 156, 159, 64, 225, 28, 141, 215, 227, 164, 121, 221, 197, 123, 33, 12, 143, 114, 108, 197, 134, 215, 63, 95, 175, 151, 90, 81, 161, 142, 205, 48, 52, 113, 230, 222, 40, 119, 55, 227, 72, 69, 86, 117, 15, 168, 189, 154, 66, 61, 222, 102 }, new byte[] { 156, 25, 12, 198, 129, 252, 68, 70, 49, 120, 197, 181, 212, 155, 246, 89, 44, 51, 85, 91, 43, 160, 178, 47, 80, 167, 190, 244, 27, 112, 94, 113, 6, 27, 46, 195, 192, 128, 118, 107, 19, 24, 238, 135, 22, 108, 64, 176, 202, 133, 29, 138, 16, 30, 213, 180, 104, 106, 159, 94, 201, 132, 162, 122, 152, 234, 146, 77, 89, 175, 168, 59, 172, 156, 17, 87, 198, 193, 75, 165, 22, 97, 188, 191, 183, 6, 197, 203, 39, 159, 222, 81, 185, 240, 14, 13, 79, 3, 231, 146, 114, 155, 194, 114, 239, 15, 172, 194, 187, 231, 154, 195, 253, 199, 55, 79, 160, 36, 12, 196, 129, 12, 137, 48, 236, 226, 21, 15 } });

            migrationBuilder.CreateIndex(
                name: "IX_Vagas_IdSensorId",
                table: "Vagas",
                column: "IdSensorId");

            migrationBuilder.AddForeignKey(
                name: "FK_Vagas_Sensores_IdSensorId",
                table: "Vagas",
                column: "IdSensorId",
                principalTable: "Sensores",
                principalColumn: "Id");
        }
    }
}
