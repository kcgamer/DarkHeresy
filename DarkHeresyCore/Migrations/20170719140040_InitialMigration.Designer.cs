using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using DarkHeresyCore.Models;

namespace DarkHeresyCore.Migrations
{
    [DbContext(typeof(DarkHeresyContext))]
    [Migration("20170719140040_InitialMigration")]
    partial class InitialMigration
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.1.2")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("DarkHeresyCore.Models.Ammo", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Amount")
                        .HasMaxLength(10);

                    b.Property<int>("AvailabilityId");

                    b.Property<int?>("Cost");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<string>("Notes");

                    b.Property<string>("Source")
                        .HasMaxLength(10);

                    b.HasKey("Id");

                    b.HasIndex("AvailabilityId");

                    b.ToTable("Ammo");
                });

            modelBuilder.Entity("DarkHeresyCore.Models.Armor", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Ap")
                        .HasColumnName("AP")
                        .HasMaxLength(50);

                    b.Property<int>("AvailabilityId");

                    b.Property<int>("CategoryId");

                    b.Property<int?>("Cost");

                    b.Property<string>("LocCovered")
                        .HasMaxLength(50);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<string>("Notes");

                    b.Property<string>("Source")
                        .HasMaxLength(10);

                    b.Property<string>("Weight")
                        .HasMaxLength(10);

                    b.HasKey("Id");

                    b.HasIndex("AvailabilityId");

                    b.HasIndex("CategoryId");

                    b.ToTable("Armor");
                });

            modelBuilder.Entity("DarkHeresyCore.Models.Availability", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.HasKey("Id");

                    b.ToTable("Availability");
                });

            modelBuilder.Entity("DarkHeresyCore.Models.Category", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.HasKey("Id");

                    b.ToTable("Category");
                });

            modelBuilder.Entity("DarkHeresyCore.Models.Class", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.HasKey("Id");

                    b.ToTable("Class");
                });

            modelBuilder.Entity("DarkHeresyCore.Models.Cybernetic", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("AvailabilityId");

                    b.Property<int>("CategoryId");

                    b.Property<string>("Cost")
                        .HasMaxLength(50);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<string>("Notes");

                    b.Property<string>("Source")
                        .HasMaxLength(10);

                    b.HasKey("Id");

                    b.HasIndex("AvailabilityId");

                    b.HasIndex("CategoryId");

                    b.ToTable("Cybernetic");
                });

            modelBuilder.Entity("DarkHeresyCore.Models.Gear", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("AvailabilityId");

                    b.Property<int>("CategoryId");

                    b.Property<string>("Cost")
                        .HasMaxLength(10);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<string>("Notes")
                        .HasColumnType("varchar(max)");

                    b.Property<string>("Source")
                        .HasMaxLength(10);

                    b.Property<string>("Weight")
                        .HasMaxLength(10);

                    b.HasKey("Id");

                    b.HasIndex("AvailabilityId");

                    b.HasIndex("CategoryId");

                    b.ToTable("Gear");
                });

            modelBuilder.Entity("DarkHeresyCore.Models.MeleeWeapon", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("AvailabilityId");

                    b.Property<int>("CategoryId");

                    b.Property<int>("ClassId");

                    b.Property<int?>("Cost");

                    b.Property<string>("Damage")
                        .HasMaxLength(20);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<string>("Notes");

                    b.Property<int?>("Pen");

                    b.Property<string>("Range")
                        .HasMaxLength(10);

                    b.Property<string>("Source")
                        .HasMaxLength(10);

                    b.Property<string>("Special")
                        .HasMaxLength(50);

                    b.Property<bool>("TwoHanded");

                    b.Property<string>("Weight")
                        .HasMaxLength(10);

                    b.HasKey("Id");

                    b.HasIndex("AvailabilityId");

                    b.HasIndex("CategoryId");

                    b.HasIndex("ClassId");

                    b.ToTable("MeleeWeapon");
                });

            modelBuilder.Entity("DarkHeresyCore.Models.RangedWeapon", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("AvailabilityId");

                    b.Property<int>("CategoryId");

                    b.Property<int>("ClassId");

                    b.Property<int?>("Clip");

                    b.Property<int?>("Cost");

                    b.Property<string>("Damage")
                        .HasMaxLength(20);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<string>("Notes");

                    b.Property<int?>("Pen");

                    b.Property<string>("Range")
                        .HasMaxLength(10);

                    b.Property<string>("Reload")
                        .HasMaxLength(20);

                    b.Property<string>("RoF")
                        .HasMaxLength(10);

                    b.Property<string>("Source")
                        .HasMaxLength(10);

                    b.Property<string>("Special")
                        .HasMaxLength(50);

                    b.Property<string>("Weight")
                        .HasMaxLength(10);

                    b.HasKey("Id");

                    b.HasIndex("AvailabilityId");

                    b.HasIndex("CategoryId");

                    b.HasIndex("ClassId");

                    b.ToTable("RangedWeapon");
                });

            modelBuilder.Entity("DarkHeresyCore.Models.Service", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("AvailabilityId");

                    b.Property<int>("CategoryId");

                    b.Property<int?>("Cost");

                    b.Property<string>("Difficulty")
                        .HasMaxLength(50);

                    b.Property<string>("Effect")
                        .HasMaxLength(50);

                    b.Property<int?>("MaterialCost");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100);

                    b.Property<string>("Notes");

                    b.Property<string>("Source")
                        .HasMaxLength(10);

                    b.HasKey("Id");

                    b.HasIndex("AvailabilityId");

                    b.HasIndex("CategoryId");

                    b.ToTable("Service");
                });

            modelBuilder.Entity("DarkHeresyCore.Models.Source", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Abbr")
                        .IsRequired()
                        .HasMaxLength(10);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.HasKey("Id");

                    b.ToTable("Source");
                });

            modelBuilder.Entity("DarkHeresyCore.Models.WeaponUpgrade", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("AvailabilityId");

                    b.Property<int>("CategoryId");

                    b.Property<int?>("Cost");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<string>("Notes");

                    b.Property<string>("Source")
                        .HasMaxLength(10);

                    b.Property<string>("Weight")
                        .HasMaxLength(10);

                    b.HasKey("Id");

                    b.HasIndex("AvailabilityId");

                    b.HasIndex("CategoryId");

                    b.ToTable("WeaponUpgrade");
                });

            modelBuilder.Entity("DarkHeresyCore.Models.Ammo", b =>
                {
                    b.HasOne("DarkHeresyCore.Models.Availability", "Availability")
                        .WithMany("Ammo")
                        .HasForeignKey("AvailabilityId")
                        .HasConstraintName("FK_Ammo_Availability");
                });

            modelBuilder.Entity("DarkHeresyCore.Models.Armor", b =>
                {
                    b.HasOne("DarkHeresyCore.Models.Availability", "Availability")
                        .WithMany("Armor")
                        .HasForeignKey("AvailabilityId")
                        .HasConstraintName("FK_Armor_Availability");

                    b.HasOne("DarkHeresyCore.Models.Category", "Category")
                        .WithMany("Armor")
                        .HasForeignKey("CategoryId")
                        .HasConstraintName("FK_Armor_Category");
                });

            modelBuilder.Entity("DarkHeresyCore.Models.Cybernetic", b =>
                {
                    b.HasOne("DarkHeresyCore.Models.Availability", "Availability")
                        .WithMany("Cybernetic")
                        .HasForeignKey("AvailabilityId")
                        .HasConstraintName("FK_Cybernetics_Availability");

                    b.HasOne("DarkHeresyCore.Models.Category", "Category")
                        .WithMany("Cybernetic")
                        .HasForeignKey("CategoryId")
                        .HasConstraintName("FK_Cybernetics_Category");
                });

            modelBuilder.Entity("DarkHeresyCore.Models.Gear", b =>
                {
                    b.HasOne("DarkHeresyCore.Models.Availability", "Availability")
                        .WithMany("Gear")
                        .HasForeignKey("AvailabilityId")
                        .HasConstraintName("FK_Gear_Availability");

                    b.HasOne("DarkHeresyCore.Models.Category", "Category")
                        .WithMany("Gear")
                        .HasForeignKey("CategoryId")
                        .HasConstraintName("FK_Gear_Category");
                });

            modelBuilder.Entity("DarkHeresyCore.Models.MeleeWeapon", b =>
                {
                    b.HasOne("DarkHeresyCore.Models.Availability", "Availability")
                        .WithMany("MeleeWeapon")
                        .HasForeignKey("AvailabilityId")
                        .HasConstraintName("FK_MeleeWeapons_Availability");

                    b.HasOne("DarkHeresyCore.Models.Category", "Category")
                        .WithMany("MeleeWeapon")
                        .HasForeignKey("CategoryId")
                        .HasConstraintName("FK_MeleeWeapons_Category");

                    b.HasOne("DarkHeresyCore.Models.Class", "Class")
                        .WithMany("MeleeWeapon")
                        .HasForeignKey("ClassId")
                        .HasConstraintName("FK_MeleeWeapons_Class");
                });

            modelBuilder.Entity("DarkHeresyCore.Models.RangedWeapon", b =>
                {
                    b.HasOne("DarkHeresyCore.Models.Availability", "Availability")
                        .WithMany("RangedWeapon")
                        .HasForeignKey("AvailabilityId")
                        .HasConstraintName("FK_RangedWeapons_Availability");

                    b.HasOne("DarkHeresyCore.Models.Category", "Category")
                        .WithMany("RangedWeapon")
                        .HasForeignKey("CategoryId")
                        .HasConstraintName("FK_RangedWeapons_Category");

                    b.HasOne("DarkHeresyCore.Models.Class", "Class")
                        .WithMany("RangedWeapon")
                        .HasForeignKey("ClassId")
                        .HasConstraintName("FK_RangedWeapons_Class");
                });

            modelBuilder.Entity("DarkHeresyCore.Models.Service", b =>
                {
                    b.HasOne("DarkHeresyCore.Models.Availability", "Availability")
                        .WithMany("Service")
                        .HasForeignKey("AvailabilityId")
                        .HasConstraintName("FK_Services_Availability");

                    b.HasOne("DarkHeresyCore.Models.Category", "Category")
                        .WithMany("Service")
                        .HasForeignKey("CategoryId")
                        .HasConstraintName("FK_Services_Category");
                });

            modelBuilder.Entity("DarkHeresyCore.Models.WeaponUpgrade", b =>
                {
                    b.HasOne("DarkHeresyCore.Models.Availability", "Availability")
                        .WithMany("WeaponUpgrade")
                        .HasForeignKey("AvailabilityId")
                        .HasConstraintName("FK_WeaponUpgrades_Availability");

                    b.HasOne("DarkHeresyCore.Models.Category", "Category")
                        .WithMany("WeaponUpgrade")
                        .HasForeignKey("CategoryId")
                        .HasConstraintName("FK_WeaponUpgrades_Category");
                });
        }
    }
}
