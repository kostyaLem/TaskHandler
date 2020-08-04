namespace TaskHandler.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;

    public partial class Init : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.TaskDatas",
                c => new
                {
                    TaskID = c.Int(nullable: false, identity: true),
                    Description = c.String(nullable: false),
                    CreateTime = c.Time(nullable: true, precision: 7, defaultValueSql: "getdate()"),
                })
                .PrimaryKey(t => t.TaskID);

        }

        public override void Down()
        {
            DropTable("dbo.TaskDatas");
        }
    }
}
