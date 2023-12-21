using FluentMigrator;

namespace Infrastructure.Persistence.Migrations.Migrations
{
    [Migration(202105161212, "SchemeDatabaseIdentity")]
    public class _202105161212_SchemeDatabaseIdentity : Migration
    {
        public override void Down()
        {
            Delete.Table("refresh_token");
            Delete.Table("user_login");
            Delete.Table("role_permission");
            Delete.Table("user_role");
            Delete.Table("role");
            Delete.Table("app_user");
            Delete.Table("organization");
            Delete.Table("permission");
        }

        public override void Up()
        {

            Create.Table("organization")
                .WithColumn("id").AsInt32().NotNullable().PrimaryKey()
                .WithColumn("name").AsString().NotNullable()
                .WithColumn("description").AsString().Nullable();

            Create.Table("app_user")
                .WithColumn("id").AsInt32().NotNullable().PrimaryKey().Identity()
                .WithColumn("name").AsString().NotNullable()
                .WithColumn("last_name").AsString().Nullable()
                .WithColumn("username").AsString().NotNullable()
                .WithColumn("email").AsString().NotNullable()
                .WithColumn("email_confirmed").AsBoolean()
                .WithColumn("enabled").AsBoolean().WithDefaultValue(true)
                .WithColumn("password_hash").AsString().Nullable()
                .WithColumn("security_stamp").AsString()
                .WithColumn("instagram").AsString().Nullable()
                .WithColumn("facebook").AsString().Nullable()
                .WithColumn("twitter").AsString().Nullable()
                .WithColumn("profile_image").AsString().Nullable();

            Create.Table("role")
                .WithColumn("id").AsInt32().NotNullable().PrimaryKey().Identity()
                .WithColumn("name").AsString().NotNullable()
                .WithColumn("description").AsString().Nullable();

            Create.Table("user_role")
                 .WithColumn("id").AsInt32().NotNullable().PrimaryKey().Identity()
                .WithColumn("user_id").AsInt32().NotNullable()
                .WithColumn("role_id").AsInt32().NotNullable()
                .WithColumn("organization_id").AsInt32().Nullable();

            Create.ForeignKey("FK_user_role_role_id_role_id")
                .FromTable("user_role").ForeignColumn("role_id")
                .ToTable("role").PrimaryColumn("id");

            Create.ForeignKey("FK_user_role_id_user_id_user_id")
                .FromTable("user_role").ForeignColumn("user_id")
                .ToTable("app_user").PrimaryColumn("id");

            Create.ForeignKey("FK_user_role_organization_id_organization_id")
              .FromTable("user_role").ForeignColumn("organization_id")
              .ToTable("organization").PrimaryColumn("id");

            Create.Table("refresh_token")
                .WithColumn("token").AsGuid().PrimaryKey()
                .WithColumn("jwt_id").AsString().NotNullable()
                .WithColumn("creation_date").AsDateTime().NotNullable()
                .WithColumn("expired_date").AsDateTime().NotNullable()
                .WithColumn("used").AsBoolean()
                .WithColumn("invalidated").AsBoolean()
                .WithColumn("user_id").AsInt32();

            Create.ForeignKey("FK_refresh_tokens_user_id_user_id")
               .FromTable("refresh_token").ForeignColumn("user_id")
               .ToTable("app_user").PrimaryColumn("id");

            Create.Table("user_login")
               .WithColumn("login_provider").AsString().PrimaryKey()
               .WithColumn("provider_key").AsString().PrimaryKey()
               .WithColumn("provider_displayname").AsString().NotNullable()
               .WithColumn("user_id").AsInt32();

            Create.ForeignKey("FK_user_login_user_id_user_id")
               .FromTable("user_login").ForeignColumn("user_id")
               .ToTable("app_user").PrimaryColumn("id");

            Create.Table("permission")
                .WithColumn("id").AsInt32().NotNullable().PrimaryKey().Identity()
                .WithColumn("name").AsString().NotNullable()
                .WithColumn("description").AsString().Nullable();

            Create.Table("role_permission")
              .WithColumn("id").AsInt32().NotNullable().PrimaryKey().Identity()
              .WithColumn("role_id").AsInt32().NotNullable()
              .WithColumn("permission_id").AsInt32().NotNullable();

            Create.ForeignKey("FK_role_permission_role_id_role_id")
            .FromTable("role_permission").ForeignColumn("role_id")
            .ToTable("role").PrimaryColumn("id");

            Create.ForeignKey("FK_role_permission_permission_id_permission_id")
           .FromTable("role_permission").ForeignColumn("permission_id")
           .ToTable("permission").PrimaryColumn("id");

            Execute.EmbeddedScript("202105161212_SchemeDatabaseIdentity.sql");
        }
    }
}
