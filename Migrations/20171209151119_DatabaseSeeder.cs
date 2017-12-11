using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace exampleapp.Migrations
{
    public partial class DatabaseSeeder : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("INSERT INTO Roles (Name) VALUES ('Admin')");
            migrationBuilder.Sql("INSERT INTO Roles (Name) VALUES ('Standard')");

            migrationBuilder.Sql("INSERT INTO Users (Name, Email, Password, RoleId) VALUES ('Simon Mkoveni', 'simon@email.com','password', (SELECT ID FROM Roles WHERE Name='Admin'))");
            migrationBuilder.Sql("INSERT INTO Users (Name, Email, Password, RoleId) VALUES ('Rivalani Hlengani', 'rivalani@email.com','password', (SELECT ID FROM Roles WHERE Name='Standard'))");
            migrationBuilder.Sql("INSERT INTO Users (Name, Email, Password, RoleId) VALUES ('Almina Mkoveni', 'ali@email.com','password', (SELECT ID FROM Roles WHERE Name='Standard'))");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
