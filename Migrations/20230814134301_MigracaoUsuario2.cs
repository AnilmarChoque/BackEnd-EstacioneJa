using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EstacioneJa.Migrations
{
    /// <inheritdoc />
    public partial class MigracaoUsuario2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Vagas_Sensores_IdSensorId",
                table: "Vagas");

            migrationBuilder.DropColumn(
                name: "Senha",
                table: "Usuarios");

            migrationBuilder.AlterColumn<string>(
                name: "Secao",
                table: "Vagas",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Preferencia",
                table: "Vagas",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<int>(
                name: "IdSensorId",
                table: "Vagas",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<bool>(
                name: "Preferencia",
                table: "Usuarios",
                type: "bit",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Nome",
                table: "Usuarios",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "Usuarios",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<long>(
                name: "Cpf",
                table: "Usuarios",
                type: "bigint",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<byte[]>(
                name: "SenhaHash",
                table: "Usuarios",
                type: "varbinary(max)",
                nullable: true);

            migrationBuilder.AddColumn<byte[]>(
                name: "SenhaSalt",
                table: "Usuarios",
                type: "varbinary(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "TipoUsuario",
                table: "Usuarios",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<string>(
                name: "Receptor",
                table: "Pagamentos",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "FormaPagamento",
                table: "Pagamentos",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Emissor",
                table: "Pagamentos",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.InsertData(
                table: "Usuarios",
                columns: new[] { "Id", "Cpf", "Email", "Nome", "Preferencia", "SenhaHash", "SenhaSalt", "TipoUsuario" },
                values: new object[] { 1, 12345678912L, "seuEmail@gmail.com", "UsuarioAdmin", false, new byte[] { 39, 98, 183, 74, 87, 6, 128, 178, 22, 112, 17, 41, 78, 156, 159, 64, 225, 28, 141, 215, 227, 164, 121, 221, 197, 123, 33, 12, 143, 114, 108, 197, 134, 215, 63, 95, 175, 151, 90, 81, 161, 142, 205, 48, 52, 113, 230, 222, 40, 119, 55, 227, 72, 69, 86, 117, 15, 168, 189, 154, 66, 61, 222, 102 }, new byte[] { 156, 25, 12, 198, 129, 252, 68, 70, 49, 120, 197, 181, 212, 155, 246, 89, 44, 51, 85, 91, 43, 160, 178, 47, 80, 167, 190, 244, 27, 112, 94, 113, 6, 27, 46, 195, 192, 128, 118, 107, 19, 24, 238, 135, 22, 108, 64, 176, 202, 133, 29, 138, 16, 30, 213, 180, 104, 106, 159, 94, 201, 132, 162, 122, 152, 234, 146, 77, 89, 175, 168, 59, 172, 156, 17, 87, 198, 193, 75, 165, 22, 97, 188, 191, 183, 6, 197, 203, 39, 159, 222, 81, 185, 240, 14, 13, 79, 3, 231, 146, 114, 155, 194, 114, 239, 15, 172, 194, 187, 231, 154, 195, 253, 199, 55, 79, 160, 36, 12, 196, 129, 12, 137, 48, 236, 226, 21, 15 }, 1 });

            migrationBuilder.AddForeignKey(
                name: "FK_Vagas_Sensores_IdSensorId",
                table: "Vagas",
                column: "IdSensorId",
                principalTable: "Sensores",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Vagas_Sensores_IdSensorId",
                table: "Vagas");

            migrationBuilder.DeleteData(
                table: "Usuarios",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DropColumn(
                name: "SenhaHash",
                table: "Usuarios");

            migrationBuilder.DropColumn(
                name: "SenhaSalt",
                table: "Usuarios");

            migrationBuilder.DropColumn(
                name: "TipoUsuario",
                table: "Usuarios");

            migrationBuilder.AlterColumn<string>(
                name: "Secao",
                table: "Vagas",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Preferencia",
                table: "Vagas",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "IdSensorId",
                table: "Vagas",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Preferencia",
                table: "Usuarios",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(bool),
                oldType: "bit");

            migrationBuilder.AlterColumn<string>(
                name: "Nome",
                table: "Usuarios",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "Usuarios",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "Cpf",
                table: "Usuarios",
                type: "int",
                nullable: false,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AddColumn<string>(
                name: "Senha",
                table: "Usuarios",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<string>(
                name: "Receptor",
                table: "Pagamentos",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "FormaPagamento",
                table: "Pagamentos",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Emissor",
                table: "Pagamentos",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Vagas_Sensores_IdSensorId",
                table: "Vagas",
                column: "IdSensorId",
                principalTable: "Sensores",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
