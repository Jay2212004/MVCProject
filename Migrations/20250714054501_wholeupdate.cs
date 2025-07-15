using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MVC_Task.Migrations
{
    /// <inheritdoc />
    public partial class wholeupdate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Department",
                columns: table => new
                {
                    DeptId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DeptName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Department", x => x.DeptId);
                });

            migrationBuilder.CreateTable(
                name: "Role",
                columns: table => new
                {
                    RoleId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Role", x => x.RoleId);
                });

            migrationBuilder.CreateTable(
                name: "Manager",
                columns: table => new
                {
                    Mid = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Mname = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DeptId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Manager", x => x.Mid);
                    table.ForeignKey(
                        name: "FK_Manager_Department_DeptId",
                        column: x => x.DeptId,
                        principalTable: "Department",
                        principalColumn: "DeptId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "employee",
                columns: table => new
                {
                    eid = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ename = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    esalary = table.Column<double>(type: "float", nullable: false),
                    password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Mid = table.Column<int>(type: "int", nullable: false),
                    RoleId = table.Column<int>(type: "int", nullable: false),
                    DeptId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_employee", x => x.eid);
                    table.ForeignKey(
                        name: "FK_employee_Department_DeptId",
                        column: x => x.DeptId,
                        principalTable: "Department",
                        principalColumn: "DeptId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_employee_Manager_Mid",
                        column: x => x.Mid,
                        principalTable: "Manager",
                        principalColumn: "Mid",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_employee_Role_RoleId",
                        column: x => x.RoleId,
                        principalTable: "Role",
                        principalColumn: "RoleId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Document",
                columns: table => new
                {
                    DocId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FileName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FilePath = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EmpId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Document", x => x.DocId);
                    table.ForeignKey(
                        name: "FK_Document_employee_EmpId",
                        column: x => x.EmpId,
                        principalTable: "employee",
                        principalColumn: "eid",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Document_EmpId",
                table: "Document",
                column: "EmpId");

            migrationBuilder.CreateIndex(
                name: "IX_employee_DeptId",
                table: "employee",
                column: "DeptId");

            migrationBuilder.CreateIndex(
                name: "IX_employee_Mid",
                table: "employee",
                column: "Mid");

            migrationBuilder.CreateIndex(
                name: "IX_employee_RoleId",
                table: "employee",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_Manager_DeptId",
                table: "Manager",
                column: "DeptId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Document");

            migrationBuilder.DropTable(
                name: "employee");

            migrationBuilder.DropTable(
                name: "Manager");

            migrationBuilder.DropTable(
                name: "Role");

            migrationBuilder.DropTable(
                name: "Department");
        }
    }
}
