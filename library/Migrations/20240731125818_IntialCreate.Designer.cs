﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using library.Data;

#nullable disable

namespace library.Migrations
{
    [DbContext(typeof(ApplicationDBContext))]
    [Migration("20240731125818_IntialCreate")]
    partial class IntialCreate
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.7")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("library.Models.BookModel", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"));

                    b.Property<string>("BookName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("GenreName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<float>("Height")
                        .HasColumnType("real");

                    b.Property<long>("SetId")
                        .HasColumnType("bigint");

                    b.Property<float>("Width")
                        .HasColumnType("real");

                    b.HasKey("Id");

                    b.HasIndex("SetId");

                    b.ToTable("book");
                });

            modelBuilder.Entity("library.Models.LibraryModel", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"));

                    b.Property<string>("GenreName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("Id");

                    b.HasIndex("GenreName")
                        .IsUnique();

                    b.ToTable("library");
                });

            modelBuilder.Entity("library.Models.SetModel", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"));

                    b.Property<string>("SetName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<long>("ShelfId")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.HasIndex("ShelfId");

                    b.ToTable("set");
                });

            modelBuilder.Entity("library.Models.ShelfModel", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"));

                    b.Property<float>("Height")
                        .HasColumnType("real");

                    b.Property<long>("LibraryId")
                        .HasColumnType("bigint");

                    b.Property<float>("Width")
                        .HasColumnType("real");

                    b.HasKey("Id");

                    b.HasIndex("LibraryId");

                    b.ToTable("shelf");
                });

            modelBuilder.Entity("library.Models.BookModel", b =>
                {
                    b.HasOne("library.Models.SetModel", "Set")
                        .WithMany("Books")
                        .HasForeignKey("SetId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Set");
                });

            modelBuilder.Entity("library.Models.SetModel", b =>
                {
                    b.HasOne("library.Models.ShelfModel", "Shelf")
                        .WithMany("Sets")
                        .HasForeignKey("ShelfId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Shelf");
                });

            modelBuilder.Entity("library.Models.ShelfModel", b =>
                {
                    b.HasOne("library.Models.LibraryModel", "LibraryGenre")
                        .WithMany("Shelves")
                        .HasForeignKey("LibraryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("LibraryGenre");
                });

            modelBuilder.Entity("library.Models.LibraryModel", b =>
                {
                    b.Navigation("Shelves");
                });

            modelBuilder.Entity("library.Models.SetModel", b =>
                {
                    b.Navigation("Books");
                });

            modelBuilder.Entity("library.Models.ShelfModel", b =>
                {
                    b.Navigation("Sets");
                });
#pragma warning restore 612, 618
        }
    }
}
