﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using OpenScienceProjects.API.Data;

#nullable disable

namespace OpenScienceProjects.API.Migrations
{
    [DbContext(typeof(DatabaseContext))]
    [Migration("20231008160616_AddedColumnOfficialSite")]
    partial class AddedColumnOfficialSite
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.22")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("OpenScienceProjects.API.Entities.Organization", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("varchar(250)")
                        .HasColumnName("description");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("varchar(100)")
                        .HasColumnName("email");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("varchar(250)")
                        .HasColumnName("name");

                    b.Property<string>("OfficialSite")
                        .IsRequired()
                        .HasColumnType("varchar(250)")
                        .HasColumnName("official_site");

                    b.Property<int>("Phone")
                        .HasMaxLength(20)
                        .HasColumnType("int")
                        .HasColumnName("phone");

                    b.HasKey("Id");

                    b.ToTable("organization", (string)null);
                });

            modelBuilder.Entity("OpenScienceProjects.API.Entities.Project", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("varchar(250)")
                        .HasColumnName("description");

                    b.Property<int>("OrganizationId")
                        .HasColumnType("int")
                        .HasColumnName("organization_id");

                    b.HasKey("Id");

                    b.HasIndex("OrganizationId");

                    b.ToTable("project", (string)null);
                });

            modelBuilder.Entity("OpenScienceProjects.API.Entities.ProjectTag", b =>
                {
                    b.Property<int>("ProjectId")
                        .HasColumnType("int")
                        .HasColumnName("project_id");

                    b.Property<int>("TagId")
                        .HasColumnType("int")
                        .HasColumnName("tag_id");

                    b.HasKey("ProjectId", "TagId");

                    b.HasIndex("TagId");

                    b.ToTable("project_tag", (string)null);
                });

            modelBuilder.Entity("OpenScienceProjects.API.Entities.ProjectUser", b =>
                {
                    b.Property<int>("ProjectId")
                        .HasColumnType("int")
                        .HasColumnName("project_id");

                    b.Property<int>("UserId")
                        .HasColumnType("int")
                        .HasColumnName("user_id");

                    b.HasKey("ProjectId", "UserId");

                    b.HasIndex("UserId");

                    b.ToTable("project_user", (string)null);
                });

            modelBuilder.Entity("OpenScienceProjects.API.Entities.Tag", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("varchar(100)")
                        .HasColumnName("description");

                    b.HasKey("Id");

                    b.ToTable("tag", (string)null);
                });

            modelBuilder.Entity("OpenScienceProjects.API.Entities.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<DateTime>("BirthDate")
                        .HasColumnType("date")
                        .HasColumnName("birth_date");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("varchar(250)")
                        .HasColumnName("description");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("varchar(100)")
                        .HasColumnName("email");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("varchar(100)")
                        .HasColumnName("name");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("varchar(50)")
                        .HasColumnName("password");

                    b.HasKey("Id");

                    b.ToTable("user", (string)null);
                });

            modelBuilder.Entity("OpenScienceProjects.API.Entities.UserTag", b =>
                {
                    b.Property<int>("UserId")
                        .HasColumnType("int")
                        .HasColumnName("user_id");

                    b.Property<int>("TagId")
                        .HasColumnType("int")
                        .HasColumnName("tag_id");

                    b.HasKey("UserId", "TagId");

                    b.ToTable("user_tag", (string)null);
                });

            modelBuilder.Entity("OpenScienceProjects.API.Entities.Project", b =>
                {
                    b.HasOne("OpenScienceProjects.API.Entities.Organization", "Organization")
                        .WithMany("Projects")
                        .HasForeignKey("OrganizationId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Organization");
                });

            modelBuilder.Entity("OpenScienceProjects.API.Entities.ProjectTag", b =>
                {
                    b.HasOne("OpenScienceProjects.API.Entities.Project", "Project")
                        .WithMany("ProjectTags")
                        .HasForeignKey("ProjectId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("OpenScienceProjects.API.Entities.Tag", "Tag")
                        .WithMany()
                        .HasForeignKey("TagId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Project");

                    b.Navigation("Tag");
                });

            modelBuilder.Entity("OpenScienceProjects.API.Entities.ProjectUser", b =>
                {
                    b.HasOne("OpenScienceProjects.API.Entities.Project", "Project")
                        .WithMany("ProjectUsers")
                        .HasForeignKey("ProjectId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("OpenScienceProjects.API.Entities.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Project");

                    b.Navigation("User");
                });

            modelBuilder.Entity("OpenScienceProjects.API.Entities.UserTag", b =>
                {
                    b.HasOne("OpenScienceProjects.API.Entities.Tag", "Tag")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("OpenScienceProjects.API.Entities.User", "User")
                        .WithMany("UserTags")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Tag");

                    b.Navigation("User");
                });

            modelBuilder.Entity("OpenScienceProjects.API.Entities.Organization", b =>
                {
                    b.Navigation("Projects");
                });

            modelBuilder.Entity("OpenScienceProjects.API.Entities.Project", b =>
                {
                    b.Navigation("ProjectTags");

                    b.Navigation("ProjectUsers");
                });

            modelBuilder.Entity("OpenScienceProjects.API.Entities.User", b =>
                {
                    b.Navigation("UserTags");
                });
#pragma warning restore 612, 618
        }
    }
}
