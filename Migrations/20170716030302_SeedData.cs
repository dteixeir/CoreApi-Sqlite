using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;
using dotNetApi.Migrations.MigrationLoader;

namespace dotNetApi.Migrations
{
  public partial class SeedData : Migration
  {
    protected override void Up(MigrationBuilder migrationBuilder)
    {
      string scriptContent = MigrationExtensions.GetScriptContent("SeedData1.sql", MigrationExtensions.MigrationScriptType.DataUpdate);
      migrationBuilder.Sql(scriptContent);

      scriptContent = MigrationExtensions.GetScriptContent("SeedData2.sql", MigrationExtensions.MigrationScriptType.DataUpdate);
      migrationBuilder.Sql(scriptContent);

      scriptContent = MigrationExtensions.GetScriptContent("SeedData3.sql", MigrationExtensions.MigrationScriptType.DataUpdate);
      migrationBuilder.Sql(scriptContent);

      scriptContent = MigrationExtensions.GetScriptContent("SeedData4.sql", MigrationExtensions.MigrationScriptType.DataUpdate);
      migrationBuilder.Sql(scriptContent);

      scriptContent = MigrationExtensions.GetScriptContent("SeedData5.sql", MigrationExtensions.MigrationScriptType.DataUpdate);
      migrationBuilder.Sql(scriptContent);
    }
  }
}
