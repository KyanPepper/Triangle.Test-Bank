﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Triangle.TestBank.Data;

#nullable disable

namespace Triangle.TestBank.Data.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20240331051904_searchadded")]
    partial class searchadded
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Triangle.TestBank.Data.Models.Exam", b =>
                {
                    b.Property<int>("ExamId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ExamId"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PdfPath")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Subject")
                        .HasColumnType("int");

                    b.Property<int>("Term")
                        .HasColumnType("int");

                    b.HasKey("ExamId");

                    b.ToTable("Exams");
                });
#pragma warning restore 612, 618
        }
    }
}
