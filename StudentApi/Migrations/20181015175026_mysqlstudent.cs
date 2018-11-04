using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace StudentApi.Migrations
{
    public partial class mysqlstudent : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "StudentAddress",
                columns: table => new
                {
                    AddressId = table.Column<long>(nullable: false)
                        .Annotation("MySQL:AutoIncrement", true),
                    AddressLine1 = table.Column<string>(nullable: true),
                    AddressLine2 = table.Column<string>(nullable: true),
                    AddressTypeId = table.Column<long>(nullable: true),
                    CanShare = table.Column<long>(nullable: true),
                    City = table.Column<long>(nullable: true),
                    Country = table.Column<long>(nullable: true),
                    CreatedBy = table.Column<string>(maxLength: 256, nullable: true),
                    CreatedDate = table.Column<DateTime>(nullable: true),
                    IsActive = table.Column<long>(nullable: true),
                    POBox = table.Column<string>(nullable: true),
                    State = table.Column<long>(nullable: true),
                    StudentId = table.Column<long>(nullable: true),
                    UpdatedBy = table.Column<string>(maxLength: 256, nullable: true),
                    UpdatedDate = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StudentAddress", x => x.AddressId);
                });

            migrationBuilder.CreateTable(
                name: "StudentContact",
                columns: table => new
                {
                    ContactId = table.Column<long>(nullable: false)
                        .Annotation("MySQL:AutoIncrement", true),
                    CanShare = table.Column<long>(nullable: true),
                    ContactNo = table.Column<string>(nullable: true),
                    ContactTypeId = table.Column<long>(nullable: true),
                    CreatedBy = table.Column<string>(maxLength: 256, nullable: true),
                    CreatedDate = table.Column<DateTime>(nullable: true),
                    Priority = table.Column<long>(nullable: true),
                    StudentId = table.Column<long>(nullable: true),
                    UpdatedBy = table.Column<string>(maxLength: 256, nullable: true),
                    UpdatedDate = table.Column<DateTime>(nullable: true),
                    isActive = table.Column<long>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StudentContact", x => x.ContactId);
                });

            migrationBuilder.CreateTable(
                name: "StudentGeneral",
                columns: table => new
                {
                    StudentId = table.Column<long>(nullable: false)
                        .Annotation("MySQL:AutoIncrement", true),
                    ApplicationNo = table.Column<long>(nullable: true),
                    CanShare = table.Column<long>(nullable: true),
                    CountryOfBirthId = table.Column<long>(nullable: true),
                    CreatedBy = table.Column<string>(maxLength: 256, nullable: true),
                    CreatedDate = table.Column<DateTime>(nullable: true),
                    DateOfBirth = table.Column<DateTime>(nullable: true),
                    GenderId = table.Column<long>(nullable: true),
                    MaritalStatusId = table.Column<long>(nullable: true),
                    NationalityId = table.Column<long>(nullable: true),
                    PlaceOfBirth = table.Column<string>(nullable: true),
                    StudentName = table.Column<string>(nullable: true),
                    UpdatedBy = table.Column<string>(maxLength: 256, nullable: true),
                    UpdatedDate = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StudentGeneral", x => x.StudentId);
                });

            migrationBuilder.CreateTable(
                name: "StudentIdentity",
                columns: table => new
                {
                    IdentityId = table.Column<long>(nullable: false)
                        .Annotation("MySQL:AutoIncrement", true),
                    CanShare = table.Column<long>(nullable: true),
                    CreatedBy = table.Column<string>(maxLength: 256, nullable: true),
                    CreatedDate = table.Column<DateTime>(nullable: true),
                    IdentityExpiryDate = table.Column<DateTime>(nullable: true),
                    IdentityIssueDate = table.Column<DateTime>(nullable: true),
                    IdentityNumber = table.Column<string>(nullable: true),
                    IdentityTypeId = table.Column<long>(nullable: true),
                    IsActive = table.Column<long>(nullable: true),
                    IssuingAuthority = table.Column<string>(nullable: true),
                    StudentId = table.Column<long>(nullable: true),
                    UpdatedBy = table.Column<string>(maxLength: 256, nullable: true),
                    UpdatedDate = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StudentIdentity", x => x.IdentityId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "StudentAddress");

            migrationBuilder.DropTable(
                name: "StudentContact");

            migrationBuilder.DropTable(
                name: "StudentGeneral");

            migrationBuilder.DropTable(
                name: "StudentIdentity");
        }
    }
}
