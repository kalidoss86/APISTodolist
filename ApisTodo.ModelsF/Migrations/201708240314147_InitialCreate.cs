namespace ApisTodo.ModelsF.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.TodoItems",
                c => new
                    {
                        TodoId = c.Int(nullable: false, identity: true),
                        TodoTitle = c.String(),
                        TodoDescrption = c.String(),
                        IsCompleted = c.Boolean(nullable: false),
                        IsDeleted = c.Boolean(nullable: false),
                        CreateTime = c.DateTime(nullable: false),
                        DueDate = c.DateTime(),
                        UpdateTime = c.DateTime(nullable: false),
                        CompletedTime = c.DateTime(),
                    })
                .PrimaryKey(t => t.TodoId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.TodoItems");
        }
    }
}
