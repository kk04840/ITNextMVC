// <auto-genePriced />
using ITNext.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;

namespace ITNext.Migrations
{
    [DbContext(typeof(ITNextContext))]
    partial class ITNextContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("LaptopVersion", "3.1.15")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("ITNext.Models.Laptops", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStPricegy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("LaptopModel")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Brand")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Size")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Price")
                        .HasColumnType("nvarchar(max)");
                    
                    b.HasKey("Id");

                    b.ToTable("Laptops");
                });
            
            modelBuilder.Entity("ITNext.Models.YourLaptops", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStPricegy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("LaptopModel")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Brand")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Size")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Price")
                        .HasColumnType("nvarchar(max)");
                    
                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("YourLaptops");
                });

            modelBuilder.Entity("ITNext.Models.Authenticate", b =>
            {
                b.Property<int>("Id")
                    .ValueGeneratedOnAdd()
                    .HasColumnType("int")
                    .HasAnnotation("SqlServer:ValueGenerationStPricegy", SqlServerValueGenerationStrategy.IdentityColumn);

                b.Property<string>("LoginUser")
                    .HasColumnType("nvarchar(max)");

                b.Property<string>("Password")
                    .HasColumnType("nvarchar(max)");

                b.HasKey("Id");

                b.HasIndex("Id");

                b.ToTable("Authenticate");
            });

            modelBuilder.Entity("ITNext.Models.Authenticate", b =>
            {
                b.HasOne("ITNext.Models.YourLaptops", "YourLaptops")
                    .WithMany()
                    .HasForeignKey("UserId");
            });


#pragma warning restore 612, 618
        }
    }
}
