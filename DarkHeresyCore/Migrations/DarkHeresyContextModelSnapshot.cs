using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using DarkHeresy;

namespace DarkHeresy.Migrations
{
    [DbContext(typeof(DarkHeresyContext))]
    partial class DarkHeresyContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.1.2")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("DarkHeresy.Models.Ammo", b =>
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

            modelBuilder.Entity("DarkHeresy.Models.Armor", b =>
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

            modelBuilder.Entity("DarkHeresy.Models.Availability", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.HasKey("Id");

                    b.ToTable("Availability");
                });

            modelBuilder.Entity("DarkHeresy.Models.Category", b =>
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

            modelBuilder.Entity("DarkHeresy.Models.Character", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("Agility");

                    b.Property<int>("BallisticSkill");

                    b.Property<string>("Career")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<int?>("CareerId");

                    b.Property<string>("CharacterName")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<int?>("ChestArmorId");

                    b.Property<string>("Description");

                    b.Property<string>("Divination")
                        .HasMaxLength(255);

                    b.Property<int>("FatePoints");

                    b.Property<int>("Fellowship");

                    b.Property<int?>("HeadArmorId");

                    b.Property<string>("HomeWorld")
                        .HasMaxLength(20);

                    b.Property<int>("Intelligence");

                    b.Property<int?>("LeftArmArmorId");

                    b.Property<int?>("LeftLegArmorId");

                    b.Property<string>("OrdoFaction")
                        .HasMaxLength(50);

                    b.Property<int>("Perception");

                    b.Property<string>("PlayerName")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<string>("Quirk")
                        .HasMaxLength(50);

                    b.Property<string>("Rank")
                        .IsRequired()
                        .HasMaxLength(20);

                    b.Property<int?>("RightArmArmorId");

                    b.Property<int?>("RightLegArmorId");

                    b.Property<int?>("SpentXp");

                    b.Property<int>("Strength");

                    b.Property<int?>("TotalXp");

                    b.Property<int>("Toughness");

                    b.Property<int>("WeaponSkill");

                    b.Property<int>("Willpower");

                    b.Property<int>("Wounds");

                    b.HasKey("Id");

                    b.HasIndex("ChestArmorId");

                    b.HasIndex("HeadArmorId");

                    b.HasIndex("LeftArmArmorId");

                    b.HasIndex("LeftLegArmorId");

                    b.HasIndex("RightArmArmorId");

                    b.HasIndex("RightLegArmorId");

                    b.ToTable("Characters");
                });

            modelBuilder.Entity("DarkHeresy.Models.CharacterMelee", b =>
                {
                    b.Property<int>("CharacterId");

                    b.Property<int>("MeleeWeaponId");

                    b.HasKey("CharacterId", "MeleeWeaponId");

                    b.HasIndex("MeleeWeaponId");

                    b.ToTable("CharacterMelees");
                });

            modelBuilder.Entity("DarkHeresy.Models.CharacterRanged", b =>
                {
                    b.Property<int>("CharacterId");

                    b.Property<int>("RangedWeaponId");

                    b.HasKey("CharacterId", "RangedWeaponId");

                    b.HasIndex("RangedWeaponId");

                    b.ToTable("CharacterRangeds");
                });

            modelBuilder.Entity("DarkHeresy.Models.CharacterSkill", b =>
                {
                    b.Property<int>("CharacterId");

                    b.Property<int>("SkillId");

                    b.Property<bool>("IsBasic");

                    b.Property<bool>("IsTen");

                    b.Property<bool>("IsTrained");

                    b.Property<bool>("IsTwenty");

                    b.HasKey("CharacterId", "SkillId");

                    b.HasIndex("SkillId");

                    b.ToTable("CharacterSkills");
                });

            modelBuilder.Entity("DarkHeresy.Models.Class", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.HasKey("Id");

                    b.ToTable("Class");
                });

            modelBuilder.Entity("DarkHeresy.Models.Cybernetic", b =>
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

                    b.ToTable("Cybernetics");
                });

            modelBuilder.Entity("DarkHeresy.Models.Gear", b =>
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

            modelBuilder.Entity("DarkHeresy.Models.MeleeWeapon", b =>
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

                    b.ToTable("MeleeWeapons");
                });

            modelBuilder.Entity("DarkHeresy.Models.RangedWeapon", b =>
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

                    b.ToTable("RangedWeapons");
                });

            modelBuilder.Entity("DarkHeresy.Models.Service", b =>
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

                    b.ToTable("Services");
                });

            modelBuilder.Entity("DarkHeresy.Models.Skill", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Description");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<string>("Stat")
                        .HasMaxLength(4);

                    b.HasKey("Id");

                    b.ToTable("Skills");
                });

            modelBuilder.Entity("DarkHeresy.Models.Source", b =>
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

                    b.ToTable("Sources");
                });

            modelBuilder.Entity("DarkHeresy.Models.WeaponUpgrade", b =>
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

                    b.ToTable("WeaponUpgrades");
                });

            modelBuilder.Entity("DarkHeresy.Models.Ammo", b =>
                {
                    b.HasOne("DarkHeresy.Models.Availability", "Availability")
                        .WithMany("Ammo")
                        .HasForeignKey("AvailabilityId")
                        .HasConstraintName("FK_Ammo_Availability");
                });

            modelBuilder.Entity("DarkHeresy.Models.Armor", b =>
                {
                    b.HasOne("DarkHeresy.Models.Availability", "Availability")
                        .WithMany("Armor")
                        .HasForeignKey("AvailabilityId")
                        .HasConstraintName("FK_Armor_Availability");

                    b.HasOne("DarkHeresy.Models.Category", "Category")
                        .WithMany("Armor")
                        .HasForeignKey("CategoryId")
                        .HasConstraintName("FK_Armor_Category");
                });

            modelBuilder.Entity("DarkHeresy.Models.Character", b =>
                {
                    b.HasOne("DarkHeresy.Models.Armor", "ChestArmor")
                        .WithMany("ChestCharacters")
                        .HasForeignKey("ChestArmorId");

                    b.HasOne("DarkHeresy.Models.Armor", "HeadArmor")
                        .WithMany("HeadCharacters")
                        .HasForeignKey("HeadArmorId");

                    b.HasOne("DarkHeresy.Models.Armor", "LeftArmArmor")
                        .WithMany("LeftArmCharacters")
                        .HasForeignKey("LeftArmArmorId");

                    b.HasOne("DarkHeresy.Models.Armor", "LeftLegArmor")
                        .WithMany("LeftLegCharacters")
                        .HasForeignKey("LeftLegArmorId");

                    b.HasOne("DarkHeresy.Models.Armor", "RightArmArmor")
                        .WithMany("RightArmCharacters")
                        .HasForeignKey("RightArmArmorId");

                    b.HasOne("DarkHeresy.Models.Armor", "RightLegArmor")
                        .WithMany("RightLegCharacters")
                        .HasForeignKey("RightLegArmorId");
                });

            modelBuilder.Entity("DarkHeresy.Models.CharacterMelee", b =>
                {
                    b.HasOne("DarkHeresy.Models.Character", "Character")
                        .WithMany("CharacterMelees")
                        .HasForeignKey("CharacterId");

                    b.HasOne("DarkHeresy.Models.MeleeWeapon", "MeleeWeapon")
                        .WithMany("CharacterMelees")
                        .HasForeignKey("MeleeWeaponId");
                });

            modelBuilder.Entity("DarkHeresy.Models.CharacterRanged", b =>
                {
                    b.HasOne("DarkHeresy.Models.Character", "Character")
                        .WithMany("CharacterRangeds")
                        .HasForeignKey("CharacterId");

                    b.HasOne("DarkHeresy.Models.RangedWeapon", "RangedWeapon")
                        .WithMany("CharacterRangeds")
                        .HasForeignKey("RangedWeaponId");
                });

            modelBuilder.Entity("DarkHeresy.Models.CharacterSkill", b =>
                {
                    b.HasOne("DarkHeresy.Models.Character", "Character")
                        .WithMany("CharacterSkills")
                        .HasForeignKey("CharacterId");

                    b.HasOne("DarkHeresy.Models.Skill", "Skill")
                        .WithMany("CharacterSkills")
                        .HasForeignKey("SkillId");
                });

            modelBuilder.Entity("DarkHeresy.Models.Cybernetic", b =>
                {
                    b.HasOne("DarkHeresy.Models.Availability", "Availability")
                        .WithMany("Cybernetics")
                        .HasForeignKey("AvailabilityId")
                        .HasConstraintName("FK_Cybernetics_Availability");

                    b.HasOne("DarkHeresy.Models.Category", "Category")
                        .WithMany("Cybernetics")
                        .HasForeignKey("CategoryId")
                        .HasConstraintName("FK_Cybernetics_Category");
                });

            modelBuilder.Entity("DarkHeresy.Models.Gear", b =>
                {
                    b.HasOne("DarkHeresy.Models.Availability", "Availability")
                        .WithMany("Gear")
                        .HasForeignKey("AvailabilityId")
                        .HasConstraintName("FK_Gear_Availability");

                    b.HasOne("DarkHeresy.Models.Category", "Category")
                        .WithMany("Gear")
                        .HasForeignKey("CategoryId")
                        .HasConstraintName("FK_Gear_Category");
                });

            modelBuilder.Entity("DarkHeresy.Models.MeleeWeapon", b =>
                {
                    b.HasOne("DarkHeresy.Models.Availability", "Availability")
                        .WithMany("MeleeWeapons")
                        .HasForeignKey("AvailabilityId")
                        .HasConstraintName("FK_MeleeWeapons_Availability");

                    b.HasOne("DarkHeresy.Models.Category", "Category")
                        .WithMany("MeleeWeapons")
                        .HasForeignKey("CategoryId")
                        .HasConstraintName("FK_MeleeWeapons_Category");

                    b.HasOne("DarkHeresy.Models.Class", "Class")
                        .WithMany("MeleeWeapons")
                        .HasForeignKey("ClassId")
                        .HasConstraintName("FK_MeleeWeapons_Class");
                });

            modelBuilder.Entity("DarkHeresy.Models.RangedWeapon", b =>
                {
                    b.HasOne("DarkHeresy.Models.Availability", "Availability")
                        .WithMany("RangedWeapons")
                        .HasForeignKey("AvailabilityId")
                        .HasConstraintName("FK_RangedWeapons_Availability");

                    b.HasOne("DarkHeresy.Models.Category", "Category")
                        .WithMany("RangedWeapons")
                        .HasForeignKey("CategoryId")
                        .HasConstraintName("FK_RangedWeapons_Category");

                    b.HasOne("DarkHeresy.Models.Class", "Class")
                        .WithMany("RangedWeapons")
                        .HasForeignKey("ClassId")
                        .HasConstraintName("FK_RangedWeapons_Class");
                });

            modelBuilder.Entity("DarkHeresy.Models.Service", b =>
                {
                    b.HasOne("DarkHeresy.Models.Availability", "Availability")
                        .WithMany("Services")
                        .HasForeignKey("AvailabilityId")
                        .HasConstraintName("FK_Services_Availability");

                    b.HasOne("DarkHeresy.Models.Category", "Category")
                        .WithMany("Services")
                        .HasForeignKey("CategoryId")
                        .HasConstraintName("FK_Services_Category");
                });

            modelBuilder.Entity("DarkHeresy.Models.WeaponUpgrade", b =>
                {
                    b.HasOne("DarkHeresy.Models.Availability", "Availability")
                        .WithMany("WeaponUpgrades")
                        .HasForeignKey("AvailabilityId")
                        .HasConstraintName("FK_WeaponUpgrades_Availability");

                    b.HasOne("DarkHeresy.Models.Category", "Category")
                        .WithMany("WeaponUpgrades")
                        .HasForeignKey("CategoryId")
                        .HasConstraintName("FK_WeaponUpgrades_Category");
                });
        }
    }
}
