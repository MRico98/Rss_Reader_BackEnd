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
    [Migration("20230307180824_UpdatingValesMigration")]
    partial class UpdatingValesMigration
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
                        .HasColumnType("nvarchar(450)")
                        .HasColumnName("Name");

                    b.HasKey("Id")
                        .HasName("PrimaryKey_CategoryId");

                    b.HasAlternateKey("Name");

                    b.ToTable("Category", "RssReader");
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
