using System;
using System.Security.Cryptography.X509Certificates;
using DarkHeresyCore.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace DarkHeresy

{
    public class DarkHeresyContext : DbContext
    {
        public DbSet<Ammo> Ammo { get; set; }
        public DbSet<Armor> Armor { get; set; }
        public DbSet<Availability> Availability { get; set; }
        public DbSet<Category> Category { get; set; }
        public DbSet<Class> Class { get; set; }
        public DbSet<Cybernetic> Cybernetics { get; set; }
        public DbSet<Gear> Gear { get; set; }
        public DbSet<MeleeWeapon> MeleeWeapons { get; set; }
        public DbSet<RangedWeapon> RangedWeapons { get; set; }
        public DbSet<Service> Services { get; set; }
        public DbSet<Source> Sources { get; set; }
        public DbSet<WeaponUpgrade> WeaponUpgrades { get; set; }
        public DbSet<Character> Characters { get; set; }
        public DbSet<Skill> Skills { get; set; }
        public DbSet<CharacterSkill> CharacterSkills { get; set; }


        public DarkHeresyContext(DbContextOptions<DarkHeresyContext> options) : base(options)
        {
            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Ammo>(entity =>
            {
                entity.Property(e => e.Amount).HasMaxLength(10);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Source).HasMaxLength(10);

                entity.HasOne(d => d.Availability)
                    .WithMany(p => p.Ammo)
                    .HasForeignKey(d => d.AvailabilityId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK_Ammo_Availability");
            });

            modelBuilder.Entity<Armor>(entity =>
            {
                entity.Property(e => e.Ap)
                    .HasColumnName("AP")
                    .HasMaxLength(50);

                entity.Property(e => e.LocCovered).HasMaxLength(50);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Source).HasMaxLength(10);

                entity.Property(e => e.Weight).HasMaxLength(10);

                entity.HasOne(d => d.Availability)
                    .WithMany(p => p.Armor)
                    .HasForeignKey(d => d.AvailabilityId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK_Armor_Availability");

                entity.HasOne(d => d.Category)
                    .WithMany(p => p.Armor)
                    .HasForeignKey(d => d.CategoryId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK_Armor_Category");
            });

            modelBuilder.Entity<Availability>(entity =>
            {
                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<Category>(entity =>
            {
                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Type)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<Class>(entity =>
            {
                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<Cybernetic>(entity =>
            {
                entity.ToTable("Cybernetics");

                entity.Property(e => e.Cost).HasMaxLength(50);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Source).HasMaxLength(10);

                entity.HasOne(d => d.Availability)
                    .WithMany(p => p.Cybernetics)
                    .HasForeignKey(d => d.AvailabilityId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK_Cybernetics_Availability");

                entity.HasOne(d => d.Category)
                    .WithMany(p => p.Cybernetics)
                    .HasForeignKey(d => d.CategoryId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK_Cybernetics_Category");
            });

            modelBuilder.Entity<Gear>(entity =>
            {
                entity.Property(e => e.Cost).HasMaxLength(10);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Notes).HasColumnType("varchar(max)");

                entity.Property(e => e.Source).HasMaxLength(10);

                entity.Property(e => e.Weight).HasMaxLength(10);

                entity.HasOne(d => d.Availability)
                    .WithMany(p => p.Gear)
                    .HasForeignKey(d => d.AvailabilityId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK_Gear_Availability");

                entity.HasOne(d => d.Category)
                    .WithMany(p => p.Gear)
                    .HasForeignKey(d => d.CategoryId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK_Gear_Category");
            });

            modelBuilder.Entity<MeleeWeapon>(entity =>
            {
                entity.ToTable("MeleeWeapons");
                entity.Property(e => e.Damage).HasMaxLength(20);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Range).HasMaxLength(10);

                entity.Property(e => e.Source).HasMaxLength(10);

                entity.Property(e => e.Special).HasMaxLength(50);

                entity.Property(e => e.Weight).HasMaxLength(10);

                entity.HasOne(d => d.Availability)
                    .WithMany(p => p.MeleeWeapons)
                    .HasForeignKey(d => d.AvailabilityId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK_MeleeWeapons_Availability");

                entity.HasOne(d => d.Category)
                    .WithMany(p => p.MeleeWeapons)
                    .HasForeignKey(d => d.CategoryId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK_MeleeWeapons_Category");

                entity.HasOne(d => d.Class)
                    .WithMany(p => p.MeleeWeapons)
                    .HasForeignKey(d => d.ClassId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK_MeleeWeapons_Class");
            });

            modelBuilder.Entity<RangedWeapon>(entity =>
            {
                entity.ToTable("RangedWeapons");

                entity.Property(e => e.Damage).HasMaxLength(20);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Range).HasMaxLength(10);

                entity.Property(e => e.Reload).HasMaxLength(20);

                entity.Property(e => e.RoF).HasMaxLength(10);

                entity.Property(e => e.Source).HasMaxLength(10);

                entity.Property(e => e.Special).HasMaxLength(50);

                entity.Property(e => e.Weight).HasMaxLength(10);

                entity.HasOne(d => d.Availability)
                    .WithMany(p => p.RangedWeapons)
                    .HasForeignKey(d => d.AvailabilityId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK_RangedWeapons_Availability");

                entity.HasOne(d => d.Category)
                    .WithMany(p => p.RangedWeapons)
                    .HasForeignKey(d => d.CategoryId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK_RangedWeapons_Category");

                entity.HasOne(d => d.Class)
                    .WithMany(p => p.RangedWeapons)
                    .HasForeignKey(d => d.ClassId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK_RangedWeapons_Class");
            });

            modelBuilder.Entity<Service>(entity =>
            {
                entity.ToTable("Services");
                entity.Property(e => e.Difficulty).HasMaxLength(50);

                entity.Property(e => e.Effect).HasMaxLength(50);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.Source).HasMaxLength(10);

                entity.HasOne(d => d.Availability)
                    .WithMany(p => p.Services)
                    .HasForeignKey(d => d.AvailabilityId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK_Services_Availability");

                entity.HasOne(d => d.Category)
                    .WithMany(p => p.Services)
                    .HasForeignKey(d => d.CategoryId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK_Services_Category");
            });

            modelBuilder.Entity<Source>(entity =>
            {
                entity.ToTable("Sources");
                entity.Property(e => e.Abbr)
                    .IsRequired()
                    .HasMaxLength(10);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<WeaponUpgrade>(entity =>
            {
                entity.ToTable("WeaponUpgrades");
                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Source).HasMaxLength(10);

                entity.Property(e => e.Weight).HasMaxLength(10);

                entity.HasOne(d => d.Availability)
                    .WithMany(p => p.WeaponUpgrades)
                    .HasForeignKey(d => d.AvailabilityId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK_WeaponUpgrades_Availability");

                entity.HasOne(d => d.Category)
                    .WithMany(p => p.WeaponUpgrades)
                    .HasForeignKey(d => d.CategoryId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK_WeaponUpgrades_Category");
            });

            modelBuilder.Entity<Character>(entity =>
            {
                entity.Property(e => e.CharacterName)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.PlayerName)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Career)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Rank)
                    .IsRequired()
                    .HasMaxLength(20);

                entity.Property(e => e.HomeWorld)
                    .HasMaxLength(20);

                entity.Property(e => e.Quirk)
                    .HasMaxLength(50);

                entity.Property(e => e.Divination)
                    .HasMaxLength(255);

                entity.Property(e => e.OrdoFaction)
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<Skill>(entity =>
            {
                entity.Property(e => e.Name)
                    .HasMaxLength(50)
                    .IsRequired();

                entity.Property(e => e.Stat)
                    .HasMaxLength(4);

            });

            modelBuilder.Entity<CharacterSkill>(entity =>
            {
                entity.HasKey(cs => new {cs.CharacterId, cs.SkillId});

                entity.HasOne(cs => cs.Character)
                    .WithMany(c => c.CharacterSkills)
                    .HasForeignKey(cs => cs.CharacterId);

                entity.HasOne(cs => cs.Skill)
                    .WithMany(s => s.CharacterSkills)
                    .HasForeignKey(cs => cs.SkillId);
            });
        }
    }
}