﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SchoolProject.Infrastructure;

#nullable disable

namespace SchoolProject.Infrastructure.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20250621155617_InitialCreate")]
    partial class InitialCreate
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "8.0.17");

            modelBuilder.Entity("SchoolProject.Data.Department", b =>
                {
                    b.Property<int>("DID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("DName")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("TEXT");

                    b.HasKey("DID");

                    b.ToTable("Departments");
                });

            modelBuilder.Entity("SchoolProject.Data.DepartmetSubject", b =>
                {
                    b.Property<int>("DeptSubID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("DID")
                        .HasColumnType("INTEGER");

                    b.Property<int>("SubID")
                        .HasColumnType("INTEGER");

                    b.HasKey("DeptSubID");

                    b.HasIndex("DID");

                    b.HasIndex("SubID");

                    b.ToTable("DepartmetSubject");
                });

            modelBuilder.Entity("SchoolProject.Data.Student", b =>
                {
                    b.Property<int>("StudID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("TEXT");

                    b.Property<int?>("DID")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("TEXT");

                    b.Property<string>("Phone")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("TEXT");

                    b.HasKey("StudID");

                    b.HasIndex("DID");

                    b.ToTable("Students");
                });

            modelBuilder.Entity("SchoolProject.Data.StudentSubject", b =>
                {
                    b.Property<int>("StudSubID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("StudID")
                        .HasColumnType("INTEGER");

                    b.Property<int>("SubID")
                        .HasColumnType("INTEGER");

                    b.HasKey("StudSubID");

                    b.HasIndex("StudID");

                    b.HasIndex("SubID");

                    b.ToTable("StudentSubject");
                });

            modelBuilder.Entity("SchoolProject.Data.Subject", b =>
                {
                    b.Property<int>("SubID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("Period")
                        .HasColumnType("TEXT");

                    b.Property<string>("SubjectName")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("TEXT");

                    b.HasKey("SubID");

                    b.ToTable("Subjects");
                });

            modelBuilder.Entity("SchoolProject.Data.DepartmetSubject", b =>
                {
                    b.HasOne("SchoolProject.Data.Department", "Department")
                        .WithMany("DepartmentSubjects")
                        .HasForeignKey("DID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SchoolProject.Data.Subject", "Subjects")
                        .WithMany("DepartmetsSubjects")
                        .HasForeignKey("SubID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Department");

                    b.Navigation("Subjects");
                });

            modelBuilder.Entity("SchoolProject.Data.Student", b =>
                {
                    b.HasOne("SchoolProject.Data.Department", "Department")
                        .WithMany("Students")
                        .HasForeignKey("DID");

                    b.Navigation("Department");
                });

            modelBuilder.Entity("SchoolProject.Data.StudentSubject", b =>
                {
                    b.HasOne("SchoolProject.Data.Student", "Student")
                        .WithMany()
                        .HasForeignKey("StudID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SchoolProject.Data.Subject", "Subject")
                        .WithMany("StudentsSubjects")
                        .HasForeignKey("SubID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Student");

                    b.Navigation("Subject");
                });

            modelBuilder.Entity("SchoolProject.Data.Department", b =>
                {
                    b.Navigation("DepartmentSubjects");

                    b.Navigation("Students");
                });

            modelBuilder.Entity("SchoolProject.Data.Subject", b =>
                {
                    b.Navigation("DepartmetsSubjects");

                    b.Navigation("StudentsSubjects");
                });
#pragma warning restore 612, 618
        }
    }
}
