using System;
using Microsoft.Data.Entity;
using Microsoft.Data.Entity.Infrastructure;
using Microsoft.Data.Entity.Metadata;
using Microsoft.Data.Entity.Migrations;
using AfterSki.Models.RideModels;

namespace AfterSki.Migrations
{
    [DbContext(typeof(RideStatisticDBContext))]
    partial class RideStatisticDBContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.0-rc1-16348")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("AfterSki.Models.RideModels.Destination", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("name");

                    b.HasKey("id");
                });

            modelBuilder.Entity("AfterSki.Models.RideModels.RideStatistic", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd();

                    b.Property<int?>("destinationid");

                    b.Property<int>("height");

                    b.Property<string>("liftName");

                    b.Property<string>("name");

                    b.Property<string>("swipeDate");

                    b.Property<DateTime>("swipeTime");

                    b.HasKey("id");
                });

            modelBuilder.Entity("AfterSki.Models.RideModels.RideStatistic", b =>
                {
                    b.HasOne("AfterSki.Models.RideModels.Destination")
                        .WithMany()
                        .HasForeignKey("destinationid");
                });
        }
    }
}
