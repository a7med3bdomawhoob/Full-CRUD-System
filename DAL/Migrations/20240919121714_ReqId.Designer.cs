﻿// <auto-generated />
using DAL.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace DAL.Migrations
{
    [DbContext(typeof(NamaaContext))]
    [Migration("20240919121714_ReqId")]
    partial class ReqId
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("DAL.Entity.Area", b =>
                {
                    b.Property<int>("AreaId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("AreaId"));

                    b.Property<string>("Area_Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Area_Image")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ServiceId")
                        .HasColumnType("int");

                    b.HasKey("AreaId");

                    b.HasIndex("ServiceId");

                    b.ToTable("areas");
                });

            modelBuilder.Entity("DAL.Entity.Equipement", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Equipement_Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Equipement_Functions")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Equipement_Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Equipement_Parts")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Image_Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("equipments");
                });

            modelBuilder.Entity("DAL.Entity.Job", b =>
                {
                    b.Property<int>("Job_Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Job_Id"));

                    b.Property<string>("Date")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Job_Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Job_Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Location")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Time_Type")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Job_Id");

                    b.ToTable("jobs");
                });

            modelBuilder.Entity("DAL.Entity.JobRequirements", b =>
                {
                    b.Property<int>("JobRequirements_Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("JobRequirements_Id"));

                    b.Property<int>("Job_Id")
                        .HasColumnType("int");

                    b.Property<string>("Req1")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Req10")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Req2")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Req3")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Req4")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Req5")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Req6")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Req7")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Req8")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Req9")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("JobRequirements_Id");

                    b.HasIndex("Job_Id");

                    b.ToTable("job_requirement");
                });

            modelBuilder.Entity("DAL.Entity.JobResponsibilities", b =>
                {
                    b.Property<int>("JobResponsibilities_Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("JobResponsibilities_Id"));

                    b.Property<int>("Job_Id")
                        .HasColumnType("int");

                    b.Property<int>("Job_Id1")
                        .HasColumnType("int");

                    b.Property<string>("Res1")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Res10")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Res2")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Res3")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Res4")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Res5")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Res6")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Res7")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Res8")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Res9")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("JobResponsibilities_Id");

                    b.HasIndex("Job_Id1");

                    b.ToTable("JobResponsibilities");
                });

            modelBuilder.Entity("DAL.Entity.News", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Date")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Image_Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("News_Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("News_Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("news");
                });

            modelBuilder.Entity("DAL.Entity.Project", b =>
                {
                    b.Property<int>("ProjectId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ProjectId"));

                    b.Property<int>("AreaId")
                        .HasColumnType("int");

                    b.Property<string>("Client_Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Image_Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Location")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Project_Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Project_Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ProjectId");

                    b.HasIndex("AreaId");

                    b.ToTable("projects");
                });

            modelBuilder.Entity("DAL.Entity.Service", b =>
                {
                    b.Property<int>("ServiceId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ServiceId"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Service_Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Service_Image")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ServiceId");

                    b.ToTable("services");
                });

            modelBuilder.Entity("DAL.Entity.Area", b =>
                {
                    b.HasOne("DAL.Entity.Service", "Service")
                        .WithMany("Areas")
                        .HasForeignKey("ServiceId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Service");
                });

            modelBuilder.Entity("DAL.Entity.JobRequirements", b =>
                {
                    b.HasOne("DAL.Entity.Job", "job")
                        .WithMany("JobRequirements")
                        .HasForeignKey("Job_Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("job");
                });

            modelBuilder.Entity("DAL.Entity.JobResponsibilities", b =>
                {
                    b.HasOne("DAL.Entity.Job", "job")
                        .WithMany("JobResponsibilities")
                        .HasForeignKey("Job_Id1")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("job");
                });

            modelBuilder.Entity("DAL.Entity.Project", b =>
                {
                    b.HasOne("DAL.Entity.Area", "Area")
                        .WithMany("Projects")
                        .HasForeignKey("AreaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Area");
                });

            modelBuilder.Entity("DAL.Entity.Area", b =>
                {
                    b.Navigation("Projects");
                });

            modelBuilder.Entity("DAL.Entity.Job", b =>
                {
                    b.Navigation("JobRequirements");

                    b.Navigation("JobResponsibilities");
                });

            modelBuilder.Entity("DAL.Entity.Service", b =>
                {
                    b.Navigation("Areas");
                });
#pragma warning restore 612, 618
        }
    }
}
