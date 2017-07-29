using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Metadata;

namespace DarkHeresyCore.Migrations
{
    public partial class AddCharacterAndSkillsModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Character",
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
                    table.PrimaryKey("PK_Character", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Character_Armor_ChestArmorId",
                        column: x => x.ChestArmorId,
                        principalTable: "Armor",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Character_Armor_HeadArmorId",
                        column: x => x.HeadArmorId,
                        principalTable: "Armor",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Character_Armor_LeftArmArmorId",
                        column: x => x.LeftArmArmorId,
                        principalTable: "Armor",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Character_Armor_LeftLegArmorId",
                        column: x => x.LeftLegArmorId,
                        principalTable: "Armor",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Character_Armor_RightArmArmorId",
                        column: x => x.RightArmArmorId,
                        principalTable: "Armor",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Character_Armor_RightLegArmorId",
                        column: x => x.RightLegArmorId,
                        principalTable: "Armor",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Skill",
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
                    table.PrimaryKey("PK_Skill", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CharacterSkill",
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
                    table.PrimaryKey("PK_CharacterSkill", x => new { x.CharacterId, x.SkillId });
                    table.ForeignKey(
                        name: "FK_CharacterSkill_Character_CharacterId",
                        column: x => x.CharacterId,
                        principalTable: "Character",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CharacterSkill_Skill_SkillId",
                        column: x => x.SkillId,
                        principalTable: "Skill",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Character_ChestArmorId",
                table: "Character",
                column: "ChestArmorId");

            migrationBuilder.CreateIndex(
                name: "IX_Character_HeadArmorId",
                table: "Character",
                column: "HeadArmorId");

            migrationBuilder.CreateIndex(
                name: "IX_Character_LeftArmArmorId",
                table: "Character",
                column: "LeftArmArmorId");

            migrationBuilder.CreateIndex(
                name: "IX_Character_LeftLegArmorId",
                table: "Character",
                column: "LeftLegArmorId");

            migrationBuilder.CreateIndex(
                name: "IX_Character_RightArmArmorId",
                table: "Character",
                column: "RightArmArmorId");

            migrationBuilder.CreateIndex(
                name: "IX_Character_RightLegArmorId",
                table: "Character",
                column: "RightLegArmorId");

            migrationBuilder.CreateIndex(
                name: "IX_CharacterSkill_SkillId",
                table: "CharacterSkill",
                column: "SkillId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CharacterSkill");

            migrationBuilder.DropTable(
                name: "Character");

            migrationBuilder.DropTable(
                name: "Skill");
        }
    }
}
