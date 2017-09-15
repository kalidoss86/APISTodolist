namespace ApisTodo.ModelsF.Migrations
{
    using System;
    using System.Data.Entity.Migrations;

    public partial class AddedComputedColumn : DbMigration
    {
        public override void Up()
        {
            DropPrimaryKey("dbo.TodoItems");
            AlterColumn("dbo.TodoItems", "TodoId", c => c.Int(nullable: false, identity: true));
            AlterColumn("dbo.TodoItems", "CreateTime", c => c.DateTime(defaultValueSql: "GETDATE()"));
            AlterColumn("dbo.TodoItems", "UpdateTime", c => c.DateTime(defaultValueSql: "GETDATE()"));
            AddPrimaryKey("dbo.TodoItems", "TodoId");
        }

        public override void Down()
        {
            DropPrimaryKey("dbo.TodoItems");
            AlterColumn("dbo.TodoItems", "UpdateTime", c => c.DateTime(nullable: false, defaultValueSql: "GETDATE()"));
            AlterColumn("dbo.TodoItems", "CreateTime", c => c.DateTime(nullable: false, defaultValueSql: "GETDATE()"));
            AlterColumn("dbo.TodoItems", "TodoId", c => c.Int(nullable: false));
            AddPrimaryKey("dbo.TodoItems", "TodoId");
        }
    }
}
