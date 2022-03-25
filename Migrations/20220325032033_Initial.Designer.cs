﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using WebShop.Models;

namespace WebShop.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20220325032033_Initial")]
    partial class Initial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("WebShop.Models.Category", b =>
                {
                    b.Property<int>("CategoryId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CategoryName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("CategoryId");

                    b.ToTable("Categories");

                    b.HasData(
                        new
                        {
                            CategoryId = 1,
                            CategoryName = "Accion Belico"
                        },
                        new
                        {
                            CategoryId = 2,
                            CategoryName = "Rol Accion"
                        },
                        new
                        {
                            CategoryId = 3,
                            CategoryName = "First Person Shotter"
                        });
                });

            modelBuilder.Entity("WebShop.Models.Game", b =>
                {
                    b.Property<int>("GameId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CategoryId")
                        .HasColumnType("int");

                    b.Property<string>("ImageThumbnailUrl")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ImageUrl")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ImportantInformation")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("InStock")
                        .HasColumnType("bit");

                    b.Property<bool>("IsGameOfTheWeek")
                        .HasColumnType("bit");

                    b.Property<string>("LongDescription")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("ShortDescription")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("GameId");

                    b.HasIndex("CategoryId");

                    b.ToTable("Games");

                    b.HasData(
                        new
                        {
                            GameId = 1,
                            CategoryId = 1,
                            ImageThumbnailUrl = "https://cdn.mos.cms.futurecdn.net/AC2X2VJaV48VcNv2FJiC23-320-80.jpg",
                            ImageUrl = "https://www.igyaan.in/wp-content/uploads/2015/10/CoD-2-1000x625.jpg",
                            ImportantInformation = "",
                            InStock = true,
                            IsGameOfTheWeek = true,
                            LongDescription = "La narrativa unificada de la campaña para un solo jugador de Vanguard abarca cuatro líneas de frente diferentes de la Segunda Guerra Mundial, centrándose en la Guerra del Pacífico, los frentes occidental y oriental y la campaña del norte de África.",
                            Name = "Call of Duty Vanguard",
                            Price = 75.95m,
                            ShortDescription = "Lorem Ipsum"
                        },
                        new
                        {
                            GameId = 2,
                            CategoryId = 2,
                            ImageThumbnailUrl = "https://us.cdn.eltribuno.com/092021/1631920503361/1366_2000%20(2).jpeg?&cw=320&ch=200",
                            ImageUrl = "https://img.8wallpapers.com/uploads/2021/04/ef60ccd081cb4de1b9acddf2-1000x625.jpg",
                            ImportantInformation = "",
                            InStock = true,
                            IsGameOfTheWeek = false,
                            LongDescription = "",
                            Name = "God of War",
                            Price = 60.95m,
                            ShortDescription = "Lorem Ipsum"
                        },
                        new
                        {
                            GameId = 3,
                            CategoryId = 3,
                            ImageThumbnailUrl = "https://us.cdn.eltribuno.com/072020/1596235960841.jpg?&cw=320&ch=200",
                            ImageUrl = "https://img.8wallpapers.com/uploads/2019/01/a1da12514cc1496a83be1783-1000x625.jpg",
                            ImportantInformation = "",
                            InStock = true,
                            IsGameOfTheWeek = false,
                            LongDescription = "El jefe Maestro el gran héroe de la humanidad y personaje principal de la saga se enfrentara a un grupo sanguinario y temible que alguna vez fueron parte del Covenant llamados los Desterrados, estos fueron integrados desde Halo Wars 2 y en las novelas del universo de Halo, ahora debutando como la amenaza principal en Halo Infinite.",
                            Name = "Halo Infinite",
                            Price = 55.95m,
                            ShortDescription = "Lorem Ipsum"
                        },
                        new
                        {
                            GameId = 4,
                            CategoryId = 2,
                            ImageThumbnailUrl = "https://cdn.mos.cms.futurecdn.net/E7RJm3PFysWPWq9sNYCij5-320-80.jpg",
                            ImageUrl = "https://sm.ign.com/ign_in/game/d/dark-souls/dark-souls-iii_19ft.jpg",
                            ImportantInformation = "",
                            InStock = true,
                            IsGameOfTheWeek = false,
                            LongDescription = "Es un videojuego de rol de acción desarrollado por FromSoftware y publicado por Bandai Namco Entertainment.",
                            Name = "Dark Souls",
                            Price = 70.95m,
                            ShortDescription = "Lorem Ipsum"
                        });
                });

            modelBuilder.Entity("WebShop.Models.Game", b =>
                {
                    b.HasOne("WebShop.Models.Category", "Category")
                        .WithMany("Games")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
