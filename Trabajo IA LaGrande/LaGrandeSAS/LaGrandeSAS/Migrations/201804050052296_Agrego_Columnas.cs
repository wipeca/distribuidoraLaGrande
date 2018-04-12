namespace LaGrandeSAS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Agrego_Columnas : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AspNetUsers", "Nombres", c => c.String(maxLength: 250));
            AddColumn("dbo.AspNetUsers", "Apellidos", c => c.String(maxLength: 250));
            AddColumn("dbo.AspNetUsers", "Barrio", c => c.String(maxLength: 250));
            AddColumn("dbo.AspNetUsers", "FechaCreacion", c => c.String(maxLength: 10));
        }
        
        public override void Down()
        {
            DropColumn("dbo.AspNetUsers", "FechaCreacion");
            DropColumn("dbo.AspNetUsers", "Barrio");
            DropColumn("dbo.AspNetUsers", "Apellidos");
            DropColumn("dbo.AspNetUsers", "Nombres");
        }
    }
}
