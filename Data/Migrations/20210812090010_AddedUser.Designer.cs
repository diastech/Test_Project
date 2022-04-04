﻿// <auto-generated />
using System;
using Data.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Data.Migrations
{
    [DbContext(typeof(DiasContext))]
    [Migration("20210812090010_AddedUser")]
    partial class AddedUser
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Data.Entities.Bina", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Ad")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreateDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("ModifiedDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("Numara")
                        .HasColumnType("int");

                    b.Property<bool>("SilindiMi")
                        .HasColumnType("bit");

                    b.HasKey("ID");

                    b.ToTable("Binas");
                });

            modelBuilder.Entity("Data.Entities.Depo", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Ad")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreateDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("EnvanterID")
                        .HasColumnType("int");

                    b.Property<DateTime>("ModifiedDate")
                        .HasColumnType("datetime2");

                    b.Property<bool>("SilindiMi")
                        .HasColumnType("bit");

                    b.HasKey("ID");

                    b.HasIndex("EnvanterID");

                    b.ToTable("Depos");
                });

            modelBuilder.Entity("Data.Entities.Envanter", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Ad")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreateDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("Durum")
                        .HasColumnType("int");

                    b.Property<DateTime>("ModifiedDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("Numara")
                        .HasColumnType("int");

                    b.Property<bool>("SilindiMi")
                        .HasColumnType("bit");

                    b.HasKey("ID");

                    b.ToTable("Envanters");
                });

            modelBuilder.Entity("Data.Entities.IsEmri", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Ad")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreateDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("EnvanterId")
                        .HasColumnType("int");

                    b.Property<DateTime>("ModifiedDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("OdaId")
                        .HasColumnType("int");

                    b.Property<bool>("SilindiMi")
                        .HasColumnType("bit");

                    b.HasKey("ID");

                    b.HasIndex("EnvanterId");

                    b.HasIndex("OdaId");

                    b.ToTable("IsEmris");
                });

            modelBuilder.Entity("Data.Entities.Oda", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("BinaID")
                        .HasColumnType("int");

                    b.Property<DateTime>("CreateDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("ModifiedDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("Numara")
                        .HasColumnType("int");

                    b.Property<bool>("SilindiMi")
                        .HasColumnType("bit");

                    b.HasKey("ID");

                    b.HasIndex("BinaID");

                    b.ToTable("Odas");
                });

            modelBuilder.Entity("Data.Entities.UrunYolu", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("BinaID")
                        .HasColumnType("int");

                    b.Property<DateTime>("CreateDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("EnvanterId")
                        .HasColumnType("int");

                    b.Property<string>("Envanteradi")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("ModifiedDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("OdaId")
                        .HasColumnType("int");

                    b.Property<bool>("SilindiMi")
                        .HasColumnType("bit");

                    b.HasKey("ID");

                    b.HasIndex("BinaID");

                    b.HasIndex("EnvanterId");

                    b.HasIndex("OdaId");

                    b.ToTable("UrunYolus");
                });

            modelBuilder.Entity("Data.Entities.User", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("CreateDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("KullaniciAdi")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("ModifiedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Password")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("SilindiMi")
                        .HasColumnType("bit");

                    b.HasKey("ID");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("Data.Entities.Depo", b =>
                {
                    b.HasOne("Data.Entities.Envanter", "Envanter")
                        .WithMany("Depos")
                        .HasForeignKey("EnvanterID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Data.Entities.IsEmri", b =>
                {
                    b.HasOne("Data.Entities.Envanter", "Envanter")
                        .WithMany()
                        .HasForeignKey("EnvanterId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Data.Entities.Oda", "Oda")
                        .WithMany()
                        .HasForeignKey("OdaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Data.Entities.Oda", b =>
                {
                    b.HasOne("Data.Entities.Bina", "Bina")
                        .WithMany()
                        .HasForeignKey("BinaID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Data.Entities.UrunYolu", b =>
                {
                    b.HasOne("Data.Entities.Bina", null)
                        .WithMany("UrunYolus")
                        .HasForeignKey("BinaID");

                    b.HasOne("Data.Entities.Envanter", "Envanter")
                        .WithMany("UrunYolus")
                        .HasForeignKey("EnvanterId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Data.Entities.Oda", "Oda")
                        .WithMany("UrunYolus")
                        .HasForeignKey("OdaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
