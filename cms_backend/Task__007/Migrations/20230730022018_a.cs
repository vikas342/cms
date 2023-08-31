using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Task__007.Migrations
{
    /// <inheritdoc />
    public partial class a : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Getalldata_Sp",
                columns: table => new
                {
                    cid = table.Column<int>(type: "int", nullable: false),
                    title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    image = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    food = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    id_id = table.Column<int>(type: "int", nullable: false),
                    buildingname = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    pincode = table.Column<int>(type: "int", nullable: false),
                    city = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    state = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "object_type",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    parentId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__object_t__3213E83FB2131020", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "roles",
                columns: table => new
                {
                    rid = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    role = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__roles__C2B7EDE8ADF0D7CE", x => x.rid);
                });

            migrationBuilder.CreateTable(
                name: "objects",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    typeid = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__objects__3213E83FBAE468D7", x => x.id);
                    table.ForeignKey(
                        name: "FK__objects__typeid__34C8D9D1",
                        column: x => x.typeid,
                        principalTable: "object_type",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "users",
                columns: table => new
                {
                    uid = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    uname = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    email = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    password = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    role = table.Column<int>(type: "int", nullable: true, defaultValueSql: "((2))")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__users__DD70126453300451", x => x.uid);
                    table.ForeignKey(
                        name: "FK__users__role__2C3393D0",
                        column: x => x.role,
                        principalTable: "roles",
                        principalColumn: "rid");
                });

            migrationBuilder.CreateTable(
                name: "address",
                columns: table => new
                {
                    add_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Buildingname = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: false),
                    city = table.Column<int>(type: "int", nullable: true),
                    state = table.Column<int>(type: "int", nullable: true),
                    pincode = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__address__273FC77EC1EBD05D", x => x.add_id);
                    table.ForeignKey(
                        name: "FK__address__city__37A5467C",
                        column: x => x.city,
                        principalTable: "objects",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK__address__state__38996AB5",
                        column: x => x.state,
                        principalTable: "object_type",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "conf_details",
                columns: table => new
                {
                    cid = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    title = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    cadd = table.Column<int>(type: "int", nullable: true),
                    food = table.Column<string>(type: "varchar(500)", unicode: false, maxLength: 500, nullable: false),
                    date = table.Column<DateTime>(type: "date", nullable: false),
                    image = table.Column<string>(type: "varchar(500)", unicode: false, maxLength: 500, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__conf_det__D837D05FCEC8DEB6", x => x.cid);
                    table.ForeignKey(
                        name: "FK__conf_detai__cadd__3B75D760",
                        column: x => x.cadd,
                        principalTable: "address",
                        principalColumn: "add_id");
                });

            migrationBuilder.CreateTable(
                name: "hotels",
                columns: table => new
                {
                    hid = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    cid = table.Column<int>(type: "int", nullable: true),
                    hname = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    city = table.Column<int>(type: "int", nullable: true),
                    state = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__hotels__DF101B018A652D5F", x => x.hid);
                    table.ForeignKey(
                        name: "FK__hotels__cid__3E52440B",
                        column: x => x.cid,
                        principalTable: "conf_details",
                        principalColumn: "cid");
                    table.ForeignKey(
                        name: "FK__hotels__city__3F466844",
                        column: x => x.city,
                        principalTable: "objects",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK__hotels__state__403A8C7D",
                        column: x => x.state,
                        principalTable: "object_type",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "speakers",
                columns: table => new
                {
                    sid = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    cid = table.Column<int>(type: "int", nullable: true),
                    name = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    image = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    intime = table.Column<DateTime>(type: "datetime", nullable: true),
                    outtime = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__speakers__DDDFDD3629E9884D", x => x.sid);
                    table.ForeignKey(
                        name: "FK__speakers__cid__4222D4EF",
                        column: x => x.cid,
                        principalTable: "conf_details",
                        principalColumn: "cid");
                });

            migrationBuilder.CreateTable(
                name: "orders",
                columns: table => new
                {
                    oid = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    uid = table.Column<int>(type: "int", nullable: true),
                    cid = table.Column<int>(type: "int", nullable: true),
                    hid = table.Column<int>(type: "int", nullable: true),
                    booked_date = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__orders__C2FFCF13649A464A", x => x.oid);
                    table.ForeignKey(
                        name: "FK__orders__cid__48CFD27E",
                        column: x => x.cid,
                        principalTable: "conf_details",
                        principalColumn: "cid");
                    table.ForeignKey(
                        name: "FK__orders__hid__49C3F6B7",
                        column: x => x.hid,
                        principalTable: "hotels",
                        principalColumn: "hid");
                    table.ForeignKey(
                        name: "FK__orders__uid__47DBAE45",
                        column: x => x.uid,
                        principalTable: "users",
                        principalColumn: "uid");
                });

            migrationBuilder.CreateIndex(
                name: "IX_address_city",
                table: "address",
                column: "city");

            migrationBuilder.CreateIndex(
                name: "IX_address_state",
                table: "address",
                column: "state");

            migrationBuilder.CreateIndex(
                name: "IX_conf_details_cadd",
                table: "conf_details",
                column: "cadd");

            migrationBuilder.CreateIndex(
                name: "IX_hotels_cid",
                table: "hotels",
                column: "cid");

            migrationBuilder.CreateIndex(
                name: "IX_hotels_city",
                table: "hotels",
                column: "city");

            migrationBuilder.CreateIndex(
                name: "IX_hotels_state",
                table: "hotels",
                column: "state");

            migrationBuilder.CreateIndex(
                name: "IX_objects_typeid",
                table: "objects",
                column: "typeid");

            migrationBuilder.CreateIndex(
                name: "IX_orders_cid",
                table: "orders",
                column: "cid");

            migrationBuilder.CreateIndex(
                name: "IX_orders_hid",
                table: "orders",
                column: "hid");

            migrationBuilder.CreateIndex(
                name: "IX_orders_uid",
                table: "orders",
                column: "uid");

            migrationBuilder.CreateIndex(
                name: "IX_speakers_cid",
                table: "speakers",
                column: "cid");

            migrationBuilder.CreateIndex(
                name: "IX_users_role",
                table: "users",
                column: "role");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Getalldata_Sp");

            migrationBuilder.DropTable(
                name: "orders");

            migrationBuilder.DropTable(
                name: "speakers");

            migrationBuilder.DropTable(
                name: "hotels");

            migrationBuilder.DropTable(
                name: "users");

            migrationBuilder.DropTable(
                name: "conf_details");

            migrationBuilder.DropTable(
                name: "roles");

            migrationBuilder.DropTable(
                name: "address");

            migrationBuilder.DropTable(
                name: "objects");

            migrationBuilder.DropTable(
                name: "object_type");
        }
    }
}
