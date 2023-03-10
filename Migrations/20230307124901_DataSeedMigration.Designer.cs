// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Rss_Reader_BackEnd.Context;

#nullable disable

namespace Rss_Reader_BackEnd.Migrations
{
    [DbContext(typeof(RepositoryContext))]
    [Migration("20230307124901_DataSeedMigration")]
    partial class DataSeedMigration
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasDefaultSchema("RssReader")
                .HasAnnotation("ProductVersion", "7.0.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Rss_Reader_BackEnd.Models.Category", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("Name");

                    b.HasKey("Id")
                        .HasName("PrimaryKey_CategoryId");

                    b.ToTable("Category", "RssReader");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "CategoryNombre"
                        });
                });

            modelBuilder.Entity("Rss_Reader_BackEnd.Models.CategoryItemKey", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("CategoryForeignKey")
                        .HasColumnType("int");

                    b.Property<int>("ItemForeignKey")
                        .HasColumnType("int");

                    b.HasKey("Id")
                        .HasName("PrimaryKey_CategoryItemId");

                    b.HasIndex("CategoryForeignKey");

                    b.ToTable("CategoryItemKey", "RssReader");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CategoryForeignKey = 1,
                            ItemForeignKey = 1
                        });
                });

            modelBuilder.Entity("Rss_Reader_BackEnd.Models.Item", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("CreationDate")
                        .HasColumnType("datetime2")
                        .HasColumnName("CreationDate");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("Description");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("Title");

                    b.Property<string>("Url")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("Url");

                    b.HasKey("Id")
                        .HasName("PrimaryKey_ItemId");

                    b.ToTable("Item", "RssReader");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CreationDate = new DateTime(2023, 3, 7, 6, 49, 1, 503, DateTimeKind.Local).AddTicks(8280),
                            Description = "Description",
                            Title = "Titulo",
                            Url = "Url"
                        });
                });

            modelBuilder.Entity("Rss_Reader_BackEnd.Models.CategoryItemKey", b =>
                {
                    b.HasOne("Rss_Reader_BackEnd.Models.Category", "Category")
                        .WithMany("CategoryItemKeys")
                        .HasForeignKey("CategoryForeignKey")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Rss_Reader_BackEnd.Models.Item", "Item")
                        .WithMany("CategoryItemKeys")
                        .HasForeignKey("CategoryForeignKey")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Category");

                    b.Navigation("Item");
                });

            modelBuilder.Entity("Rss_Reader_BackEnd.Models.Category", b =>
                {
                    b.Navigation("CategoryItemKeys");
                });

            modelBuilder.Entity("Rss_Reader_BackEnd.Models.Item", b =>
                {
                    b.Navigation("CategoryItemKeys");
                });
#pragma warning restore 612, 618
        }
    }
}
