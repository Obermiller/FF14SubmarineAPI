// <auto-generated />
using Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Data.Migrations
{
    [DbContext(typeof(DataContext))]
    partial class DataContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.6")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("Core.Models.Submarines.Schema.Part", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("Components")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("Desynthesizable")
                        .HasColumnType("bit");

                    b.Property<int>("Favor")
                        .HasColumnType("int");

                    b.Property<bool>("MarketboardProhibited")
                        .HasColumnType("bit");

                    b.Property<int>("Materials")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Range")
                        .HasColumnType("int");

                    b.Property<int>("Rank")
                        .HasColumnType("int");

                    b.Property<int>("Retrieval")
                        .HasColumnType("int");

                    b.Property<int>("SellingPrice")
                        .HasColumnType("int");

                    b.Property<int>("ShopSellingPrice")
                        .HasColumnType("int");

                    b.Property<int>("Speed")
                        .HasColumnType("int");

                    b.Property<int>("Surveillance")
                        .HasColumnType("int");

                    b.Property<int>("Type")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Parts");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Components = 5,
                            Description = "Comprising the center of a shark-class submersible, this ovoid hull is multi-walled to stabilize and maintain pressure within so that the vessel's crew does not succumb to the crushing weight of the waters it navigates. Several sturdy rudder fins serve to increase maneuverability.",
                            Desynthesizable = false,
                            Favor = 20,
                            MarketboardProhibited = true,
                            Materials = 1,
                            Name = "Shark-class Pressure Hull",
                            Range = 40,
                            Rank = 1,
                            Retrieval = 30,
                            SellingPrice = 16,
                            ShopSellingPrice = 0,
                            Speed = 20,
                            Surveillance = -10,
                            Type = 1
                        },
                        new
                        {
                            Id = 2,
                            Components = 5,
                            Description = "Comprising the rear end of a shark-class submersible, this stern contains the unique independent engine which propels the craft.",
                            Desynthesizable = false,
                            Favor = 15,
                            MarketboardProhibited = true,
                            Materials = 1,
                            Name = "Shark-class Stern",
                            Range = 30,
                            Rank = 1,
                            Retrieval = 20,
                            SellingPrice = 16,
                            ShopSellingPrice = 0,
                            Speed = 60,
                            Surveillance = -30,
                            Type = 2
                        },
                        new
                        {
                            Id = 3,
                            Components = 5,
                            Description = "Comprising the front end of a shark-class submersible, this bow has been reinforced to double as a battering ram for subduing unruly sea creatures.",
                            Desynthesizable = false,
                            Favor = 15,
                            MarketboardProhibited = true,
                            Materials = 1,
                            Name = "Shark-class Bow",
                            Range = -20,
                            Rank = 1,
                            Retrieval = 40,
                            SellingPrice = 16,
                            ShopSellingPrice = 0,
                            Speed = 10,
                            Surveillance = 50,
                            Type = 3
                        },
                        new
                        {
                            Id = 4,
                            Components = 5,
                            Description = "Comprising the top of a shark-class submersible, the bridge houses all of the equipment necessary for the vessel's crew to navigate the unplumbed depths of the Ruby Sea and beyond.",
                            Desynthesizable = false,
                            Favor = 20,
                            MarketboardProhibited = true,
                            Materials = 1,
                            Name = "Shark-class Bridge",
                            Range = 20,
                            Rank = 1,
                            Retrieval = 20,
                            SellingPrice = 16,
                            ShopSellingPrice = 0,
                            Speed = 20,
                            Surveillance = 20,
                            Type = 4
                        });
                });

            modelBuilder.Entity("Core.Models.Submarines.Schema.Submarine", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Rank")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Submarines");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Base Sub",
                            Rank = 1
                        });
                });

            modelBuilder.Entity("Core.Models.Submarines.Schema.SubmarinePart", b =>
                {
                    b.Property<int>("SubmarineId")
                        .HasColumnType("int");

                    b.Property<int>("PartId")
                        .HasColumnType("int");

                    b.Property<int>("Condition")
                        .HasColumnType("int");

                    b.Property<int>("Dye")
                        .HasColumnType("int");

                    b.HasKey("SubmarineId", "PartId");

                    b.HasIndex("PartId");

                    b.ToTable("Submarine_Part");

                    b.HasData(
                        new
                        {
                            SubmarineId = 1,
                            PartId = 1,
                            Condition = 100,
                            Dye = 2
                        },
                        new
                        {
                            SubmarineId = 1,
                            PartId = 2,
                            Condition = 100,
                            Dye = 2
                        },
                        new
                        {
                            SubmarineId = 1,
                            PartId = 3,
                            Condition = 100,
                            Dye = 2
                        },
                        new
                        {
                            SubmarineId = 1,
                            PartId = 4,
                            Condition = 100,
                            Dye = 2
                        });
                });

            modelBuilder.Entity("Core.Models.Submarines.Schema.SubmarinePart", b =>
                {
                    b.HasOne("Core.Models.Submarines.Schema.Part", "Part")
                        .WithMany("SubmarineParts")
                        .HasForeignKey("PartId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("Core.Models.Submarines.Schema.Submarine", "Submarine")
                        .WithMany("Parts")
                        .HasForeignKey("SubmarineId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Part");

                    b.Navigation("Submarine");
                });

            modelBuilder.Entity("Core.Models.Submarines.Schema.Part", b =>
                {
                    b.Navigation("SubmarineParts");
                });

            modelBuilder.Entity("Core.Models.Submarines.Schema.Submarine", b =>
                {
                    b.Navigation("Parts");
                });
#pragma warning restore 612, 618
        }
    }
}
