using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Metadata;

namespace DarkHeresy.Migrations
{
    public partial class CharacterSkillsMeleeRangedManyToMany : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Characters",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Agility = table.Column<int>(nullable: false),
                    BallisticSkill = table.Column<int>(nullable: false),
                    Career = table.Column<string>(maxLength: 50, nullable: false),
                    CareerId = table.Column<int>(nullable: true),
                    CharacterName = table.Column<string>(maxLength: 50, nullable: false),
                    ChestArmorId = table.Column<int>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    Divination = table.Column<string>(maxLength: 255, nullable: true),
                    FatePoints = table.Column<int>(nullable: false),
                    Fellowship = table.Column<int>(nullable: false),
                    HeadArmorId = table.Column<int>(nullable: true),
                    HomeWorld = table.Column<string>(maxLength: 20, nullable: true),
                    Intelligence = table.Column<int>(nullable: false),
                    LeftArmArmorId = table.Column<int>(nullable: true),
                    LeftLegArmorId = table.Column<int>(nullable: true),
                    OrdoFaction = table.Column<string>(maxLength: 50, nullable: true),
                    Perception = table.Column<int>(nullable: false),
                    PlayerName = table.Column<string>(maxLength: 50, nullable: false),
                    Quirk = table.Column<string>(maxLength: 50, nullable: true),
                    Rank = table.Column<string>(maxLength: 20, nullable: false),
                    RightArmArmorId = table.Column<int>(nullable: true),
                    RightLegArmorId = table.Column<int>(nullable: true),
                    SpentXp = table.Column<int>(nullable: true),
                    Strength = table.Column<int>(nullable: false),
                    TotalXp = table.Column<int>(nullable: true),
                    Toughness = table.Column<int>(nullable: false),
                    WeaponSkill = table.Column<int>(nullable: false),
                    Willpower = table.Column<int>(nullable: false),
                    Wounds = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Characters", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Characters_Armor_ChestArmorId",
                        column: x => x.ChestArmorId,
                        principalTable: "Armor",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Characters_Armor_HeadArmorId",
                        column: x => x.HeadArmorId,
                        principalTable: "Armor",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Characters_Armor_LeftArmArmorId",
                        column: x => x.LeftArmArmorId,
                        principalTable: "Armor",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Characters_Armor_LeftLegArmorId",
                        column: x => x.LeftLegArmorId,
                        principalTable: "Armor",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Characters_Armor_RightArmArmorId",
                        column: x => x.RightArmArmorId,
                        principalTable: "Armor",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Characters_Armor_RightLegArmorId",
                        column: x => x.RightLegArmorId,
                        principalTable: "Armor",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Skills",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Description = table.Column<string>(nullable: true),
                    Name = table.Column<string>(maxLength: 50, nullable: false),
                    Stat = table.Column<string>(maxLength: 4, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Skills", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CharacterMelees",
                columns: table => new
                {
                    CharacterId = table.Column<int>(nullable: false),
                    MeleeWeaponId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CharacterMelees", x => new { x.CharacterId, x.MeleeWeaponId });
                    table.ForeignKey(
                        name: "FK_CharacterMelees_Characters_CharacterId",
                        column: x => x.CharacterId,
                        principalTable: "Characters",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CharacterMelees_MeleeWeapons_MeleeWeaponId",
                        column: x => x.MeleeWeaponId,
                        principalTable: "MeleeWeapons",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "CharacterRangeds",
                columns: table => new
                {
                    CharacterId = table.Column<int>(nullable: false),
                    RangedWeaponId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CharacterRangeds", x => new { x.CharacterId, x.RangedWeaponId });
                    table.ForeignKey(
                        name: "FK_CharacterRangeds_Characters_CharacterId",
                        column: x => x.CharacterId,
                        principalTable: "Characters",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CharacterRangeds_RangedWeapons_RangedWeaponId",
                        column: x => x.RangedWeaponId,
                        principalTable: "RangedWeapons",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "CharacterSkills",
                columns: table => new
                {
                    CharacterId = table.Column<int>(nullable: false),
                    SkillId = table.Column<int>(nullable: false),
                    IsBasic = table.Column<bool>(nullable: false),
                    IsTen = table.Column<bool>(nullable: false),
                    IsTrained = table.Column<bool>(nullable: false),
                    IsTwenty = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CharacterSkills", x => new { x.CharacterId, x.SkillId });
                    table.ForeignKey(
                        name: "FK_CharacterSkills_Characters_CharacterId",
                        column: x => x.CharacterId,
                        principalTable: "Characters",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CharacterSkills_Skills_SkillId",
                        column: x => x.SkillId,
                        principalTable: "Skills",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Characters_ChestArmorId",
                table: "Characters",
                column: "ChestArmorId");

            migrationBuilder.CreateIndex(
                name: "IX_Characters_HeadArmorId",
                table: "Characters",
                column: "HeadArmorId");

            migrationBuilder.CreateIndex(
                name: "IX_Characters_LeftArmArmorId",
                table: "Characters",
                column: "LeftArmArmorId");

            migrationBuilder.CreateIndex(
                name: "IX_Characters_LeftLegArmorId",
                table: "Characters",
                column: "LeftLegArmorId");

            migrationBuilder.CreateIndex(
                name: "IX_Characters_RightArmArmorId",
                table: "Characters",
                column: "RightArmArmorId");

            migrationBuilder.CreateIndex(
                name: "IX_Characters_RightLegArmorId",
                table: "Characters",
                column: "RightLegArmorId");

            migrationBuilder.CreateIndex(
                name: "IX_CharacterMelees_MeleeWeaponId",
                table: "CharacterMelees",
                column: "MeleeWeaponId");

            migrationBuilder.CreateIndex(
                name: "IX_CharacterRangeds_RangedWeaponId",
                table: "CharacterRangeds",
                column: "RangedWeaponId");

            migrationBuilder.CreateIndex(
                name: "IX_CharacterSkills_SkillId",
                table: "CharacterSkills",
                column: "SkillId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CharacterMelees");

            migrationBuilder.DropTable(
                name: "CharacterRangeds");

            migrationBuilder.DropTable(
                name: "CharacterSkills");

            migrationBuilder.DropTable(
                name: "Characters");

            migrationBuilder.DropTable(
                name: "Skills");
        }
    }
}
