using System;
using Microsoft.Extensions.PlatformAbstractions;
using Microsoft.Extensions.Options;
using Microsoft.AspNetCore.Hosting;

namespace dotNetApi.Migrations.MigrationLoader
{
  public static class MigrationExtensions
  {
    internal enum MigrationScriptType
    {
      Function,
      StoredProcedure,
      Table,
      View,
      DataUpdate
    }
    internal static string GetScriptContent(string fileName, MigrationScriptType type)
    {

      var rootDir = new System.IO.DirectoryInfo(System.AppContext.BaseDirectory);
      rootDir = new System.IO.DirectoryInfo(rootDir.Parent.Parent.Parent.FullName);


      string spContent = string.Empty;
      string directory = @"/Migrations";
      switch (type)
      {
        case MigrationScriptType.DataUpdate:
          directory += @"/SeedData";
          break;

        case MigrationScriptType.Function:
          directory += @"\Functions";
          break;

        case MigrationScriptType.StoredProcedure:
          directory += @"\StoredProcedures";
          break;

        case MigrationScriptType.Table:
          directory += @"\Tables";
          break;

        case MigrationScriptType.View:
          directory += @"\Views";
          break;
      }

      if (System.IO.File.Exists(rootDir.ToString() + directory + @"\" + fileName) == false)
      {
        directory = directory.Replace(@"\dotNetApi.Migrations\Scripts", "\\");
      }

      spContent = System.IO.File.ReadAllText(rootDir.ToString() + directory + @"/" + fileName);

      return spContent;
    }
  }
}
