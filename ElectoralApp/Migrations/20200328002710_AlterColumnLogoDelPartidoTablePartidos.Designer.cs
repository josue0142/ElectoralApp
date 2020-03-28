﻿// <auto-generated />
using System;
using ElectoralApp.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace ElectoralApp.Migrations
{
    [DbContext(typeof(BDelectoralContext))]
    [Migration("20200328002710_AlterColumnLogoDelPartidoTablePartidos")]
    partial class AlterColumnLogoDelPartidoTablePartidos
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.6-servicing-10079")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("ElectoralApp.Models.Candidatos", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Apellido")
                        .IsRequired()
                        .HasMaxLength(25)
                        .IsUnicode(false);

                    b.Property<bool>("Estado");

                    b.Property<string>("FotoDePerfil")
                        .HasColumnName("Foto_de_perfil")
                        .HasMaxLength(25)
                        .IsUnicode(false);

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasMaxLength(25)
                        .IsUnicode(false);

                    b.Property<int?>("PartidoFk")
                        .IsRequired()
                        .HasColumnName("Partido_FK");

                    b.Property<int?>("PuestoFk")
                        .IsRequired()
                        .HasColumnName("Puesto_FK");

                    b.HasKey("Id");

                    b.HasIndex("PartidoFk");

                    b.HasIndex("PuestoFk");

                    b.ToTable("Candidatos");
                });

            modelBuilder.Entity("ElectoralApp.Models.Ciudadanos", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Apellido")
                        .IsRequired()
                        .HasMaxLength(25)
                        .IsUnicode(false);

                    b.Property<string>("DocumentoDeIdentidad")
                        .IsRequired()
                        .HasColumnName("Documento_de_identidad")
                        .HasMaxLength(25);

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(25)
                        .IsUnicode(false);

                    b.Property<bool>("Estado");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasMaxLength(25)
                        .IsUnicode(false);

                    b.HasKey("Id");

                    b.ToTable("Ciudadanos");
                });

            modelBuilder.Entity("ElectoralApp.Models.Elecciones", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("Estado");

                    b.Property<string>("FechaDeRealización")
                        .IsRequired()
                        .HasColumnName("Fecha_de_realización")
                        .HasMaxLength(25)
                        .IsUnicode(false);

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasMaxLength(25)
                        .IsUnicode(false);

                    b.HasKey("Id");

                    b.ToTable("Elecciones");
                });

            modelBuilder.Entity("ElectoralApp.Models.Partidos", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Descripción")
                        .IsRequired()
                        .HasMaxLength(25)
                        .IsUnicode(false);

                    b.Property<bool>("Estado");

                    b.Property<string>("LogoDelPartido")
                        .HasColumnName("Logo_del_partido")
                        .HasMaxLength(25)
                        .IsUnicode(false);

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasMaxLength(25)
                        .IsUnicode(false);

                    b.HasKey("Id");

                    b.ToTable("Partidos");
                });

            modelBuilder.Entity("ElectoralApp.Models.PuestoElectivo", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Descripción")
                        .IsRequired()
                        .HasMaxLength(25)
                        .IsUnicode(false);

                    b.Property<bool>("Estado");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasMaxLength(25)
                        .IsUnicode(false);

                    b.HasKey("Id");

                    b.ToTable("PuestoElectivo");
                });

            modelBuilder.Entity("ElectoralApp.Models.Resultados", b =>
                {
                    b.Property<int>("Id");

                    b.Property<int>("CandidatosFk")
                        .HasColumnName("Candidatos_FK");

                    b.Property<int>("CiudadanosFk")
                        .HasColumnName("Ciudadanos_FK");

                    b.Property<int>("EleccionesFk")
                        .HasColumnName("Elecciones_FK");

                    b.HasKey("Id");

                    b.HasIndex("CandidatosFk");

                    b.HasIndex("CiudadanosFk");

                    b.HasIndex("EleccionesFk");

                    b.ToTable("Resultados");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("Name")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<string>("RoleId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUser", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("AccessFailedCount");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("Email")
                        .HasMaxLength(256);

                    b.Property<bool>("EmailConfirmed");

                    b.Property<bool>("LockoutEnabled");

                    b.Property<DateTimeOffset?>("LockoutEnd");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256);

                    b.Property<string>("PasswordHash");

                    b.Property<string>("PhoneNumber");

                    b.Property<bool>("PhoneNumberConfirmed");

                    b.Property<string>("SecurityStamp");

                    b.Property<bool>("TwoFactorEnabled");

                    b.Property<string>("UserName")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider");

                    b.Property<string>("ProviderKey");

                    b.Property<string>("ProviderDisplayName");

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId");

                    b.Property<string>("RoleId");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId");

                    b.Property<string>("LoginProvider");

                    b.Property<string>("Name");

                    b.Property<string>("Value");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens");
                });

            modelBuilder.Entity("ElectoralApp.Models.Candidatos", b =>
                {
                    b.HasOne("ElectoralApp.Models.Partidos", "PartidoFkNavigation")
                        .WithMany("Candidatos")
                        .HasForeignKey("PartidoFk")
                        .HasConstraintName("FK_Candidatos_Partidos")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("ElectoralApp.Models.PuestoElectivo", "PuestoFkNavigation")
                        .WithMany("Candidatos")
                        .HasForeignKey("PuestoFk")
                        .HasConstraintName("FK_Candidatos_PuestoElectivo")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("ElectoralApp.Models.Resultados", b =>
                {
                    b.HasOne("ElectoralApp.Models.Candidatos", "CandidatosFkNavigation")
                        .WithMany("Resultados")
                        .HasForeignKey("CandidatosFk")
                        .HasConstraintName("FK_Resultados_Candidatos");

                    b.HasOne("ElectoralApp.Models.Ciudadanos", "CiudadanosFkNavigation")
                        .WithMany("Resultados")
                        .HasForeignKey("CiudadanosFk")
                        .HasConstraintName("FK_Resultados_Ciudadanos");

                    b.HasOne("ElectoralApp.Models.Elecciones", "EleccionesFkNavigation")
                        .WithMany("Resultados")
                        .HasForeignKey("EleccionesFk")
                        .HasConstraintName("FK_Resultados_Elecciones");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
