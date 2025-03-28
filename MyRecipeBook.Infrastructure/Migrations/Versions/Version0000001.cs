﻿using FluentMigrator;

namespace MyRecipeBook.Infrastructure.Migrations.Versions
{
    [Migration(1, "Create table users")]
    public class Version0000001 : VersionBase
    {
        public override void Up()
        {
            CreateTable("Users")
                 .WithColumn("Name").AsString(255).NotNullable()
                 .WithColumn("Email").AsString(255).NotNullable()
                 .WithColumn("Password").AsString(2000).NotNullable();
        }
    }
}
