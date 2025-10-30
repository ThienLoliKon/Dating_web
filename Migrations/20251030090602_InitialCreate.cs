using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Dating_web.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "nguoi_dung",
                columns: table => new
                {
                    nguoi_dung_id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ten_dang_nhap = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    mat_khau = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    so_dien_thoai = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    gioi_tinh = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ngay_sinh = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ngay_tao = table.Column<DateTime>(type: "datetime2", nullable: false),
                    trang_thai = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_nguoi_dung", x => x.nguoi_dung_id);
                });

            migrationBuilder.CreateTable(
                name: "bao_cao",
                columns: table => new
                {
                    bao_cao_id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    nguoi_bao_cao_id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    nguoi_bi_bao_cao_id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ly_do = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    thoi_gian = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_bao_cao", x => x.bao_cao_id);
                    table.ForeignKey(
                        name: "FK_bao_cao_nguoi_dung_nguoi_bao_cao_id",
                        column: x => x.nguoi_bao_cao_id,
                        principalTable: "nguoi_dung",
                        principalColumn: "nguoi_dung_id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_bao_cao_nguoi_dung_nguoi_bi_bao_cao_id",
                        column: x => x.nguoi_bi_bao_cao_id,
                        principalTable: "nguoi_dung",
                        principalColumn: "nguoi_dung_id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ho_so",
                columns: table => new
                {
                    ho_so_id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    nguoi_dung_id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ho_va_ten = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    anh_dai_dien = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    album_anh = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    so_thich = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    mo_ta_ban_than = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    dia_chi = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ho_so", x => x.ho_so_id);
                    table.ForeignKey(
                        name: "FK_ho_so_nguoi_dung_nguoi_dung_id",
                        column: x => x.nguoi_dung_id,
                        principalTable: "nguoi_dung",
                        principalColumn: "nguoi_dung_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "match_user",
                columns: table => new
                {
                    match_id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    nguoi_a_id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    nguoi_b_id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    thoi_gian = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_match_user", x => x.match_id);
                    table.ForeignKey(
                        name: "FK_match_user_nguoi_dung_nguoi_a_id",
                        column: x => x.nguoi_a_id,
                        principalTable: "nguoi_dung",
                        principalColumn: "nguoi_dung_id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_match_user_nguoi_dung_nguoi_b_id",
                        column: x => x.nguoi_b_id,
                        principalTable: "nguoi_dung",
                        principalColumn: "nguoi_dung_id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "tai_khoan_vip",
                columns: table => new
                {
                    vip_id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    nguoi_dung_id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    goi_vip = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ngay_bat_dau = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ngay_ket_thuc = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tai_khoan_vip", x => x.vip_id);
                    table.ForeignKey(
                        name: "FK_tai_khoan_vip_nguoi_dung_nguoi_dung_id",
                        column: x => x.nguoi_dung_id,
                        principalTable: "nguoi_dung",
                        principalColumn: "nguoi_dung_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "thich",
                columns: table => new
                {
                    nguoi_gui_id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    nguoi_nhan_id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    thoi_gian = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_thich", x => new { x.nguoi_gui_id, x.nguoi_nhan_id });
                    table.ForeignKey(
                        name: "FK_thich_nguoi_dung_nguoi_gui_id",
                        column: x => x.nguoi_gui_id,
                        principalTable: "nguoi_dung",
                        principalColumn: "nguoi_dung_id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_thich_nguoi_dung_nguoi_nhan_id",
                        column: x => x.nguoi_nhan_id,
                        principalTable: "nguoi_dung",
                        principalColumn: "nguoi_dung_id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "tin_nhan",
                columns: table => new
                {
                    tin_nhan_id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    match_id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    nguoi_gui_id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    noi_dung = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    thoi_gian = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tin_nhan", x => x.tin_nhan_id);
                    table.ForeignKey(
                        name: "FK_tin_nhan_match_user_match_id",
                        column: x => x.match_id,
                        principalTable: "match_user",
                        principalColumn: "match_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_tin_nhan_nguoi_dung_nguoi_gui_id",
                        column: x => x.nguoi_gui_id,
                        principalTable: "nguoi_dung",
                        principalColumn: "nguoi_dung_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_bao_cao_nguoi_bao_cao_id",
                table: "bao_cao",
                column: "nguoi_bao_cao_id");

            migrationBuilder.CreateIndex(
                name: "IX_bao_cao_nguoi_bi_bao_cao_id",
                table: "bao_cao",
                column: "nguoi_bi_bao_cao_id");

            migrationBuilder.CreateIndex(
                name: "IX_ho_so_nguoi_dung_id",
                table: "ho_so",
                column: "nguoi_dung_id");

            migrationBuilder.CreateIndex(
                name: "IX_match_user_nguoi_a_id",
                table: "match_user",
                column: "nguoi_a_id");

            migrationBuilder.CreateIndex(
                name: "IX_match_user_nguoi_b_id",
                table: "match_user",
                column: "nguoi_b_id");

            migrationBuilder.CreateIndex(
                name: "IX_tai_khoan_vip_nguoi_dung_id",
                table: "tai_khoan_vip",
                column: "nguoi_dung_id");

            migrationBuilder.CreateIndex(
                name: "IX_thich_nguoi_nhan_id",
                table: "thich",
                column: "nguoi_nhan_id");

            migrationBuilder.CreateIndex(
                name: "IX_tin_nhan_match_id",
                table: "tin_nhan",
                column: "match_id");

            migrationBuilder.CreateIndex(
                name: "IX_tin_nhan_nguoi_gui_id",
                table: "tin_nhan",
                column: "nguoi_gui_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "bao_cao");

            migrationBuilder.DropTable(
                name: "ho_so");

            migrationBuilder.DropTable(
                name: "tai_khoan_vip");

            migrationBuilder.DropTable(
                name: "thich");

            migrationBuilder.DropTable(
                name: "tin_nhan");

            migrationBuilder.DropTable(
                name: "match_user");

            migrationBuilder.DropTable(
                name: "nguoi_dung");
        }
    }
}
