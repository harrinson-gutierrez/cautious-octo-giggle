using FluentMigrator;

namespace Infrastructure.Persistence.Migrations.Migrations
{
    [Migration(202312212338, "202312212338_SchemeDatabaseRoulette")]
    public class _202312212338_SchemeDatabaseRoulette : Migration
    {
        public override void Down()
        {
            Delete.Table("bet_roulette");
            Delete.Table("roulette");
        }

        public override void Up()
        {

            Create.Table("roulette")
                .WithColumn("id").AsGuid().NotNullable().PrimaryKey()
                .WithColumn("state").AsString().NotNullable();

            Create.Table("bet_roulette")
                .WithColumn("id").AsGuid().NotNullable().PrimaryKey()
                .WithColumn("roulette_id").AsGuid().NotNullable()
                .WithColumn("user_id").AsInt32().NotNullable()
                .WithColumn("bet").AsDecimal().NotNullable()
                .WithColumn("number").AsInt16().Nullable()
                .WithColumn("color").AsString().Nullable()
                .WithColumn("winner").AsBoolean().WithDefaultValue(false)
                .WithColumn("earned_bet").AsDecimal().Nullable();

            Create.ForeignKey("FK_bet_roulette_roulette_id_id")
                .FromTable("bet_roulette").ForeignColumn("roulette_id")
                .ToTable("roulette").PrimaryColumn("id");
        }
    }
}
