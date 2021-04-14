using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace EgyptExcavation.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AgeGroups",
                columns: table => new
                {
                    AgeGroupID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Age_group = table.Column<string>(nullable: true),
                    BurialID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AgeGroups", x => x.AgeGroupID);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserName = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(maxLength: 256, nullable: true),
                    Email = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(nullable: false),
                    PasswordHash = table.Column<string>(nullable: true),
                    SecurityStamp = table.Column<string>(nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true),
                    PhoneNumber = table.Column<string>(nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(nullable: false),
                    TwoFactorEnabled = table.Column<bool>(nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(nullable: true),
                    LockoutEnabled = table.Column<bool>(nullable: false),
                    AccessFailedCount = table.Column<int>(nullable: false),
                    FirstName = table.Column<string>(nullable: false),
                    LastName = table.Column<string>(nullable: false),
                    FullName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    CategoryID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.CategoryID);
                });

            migrationBuilder.CreateTable(
                name: "HairColors",
                columns: table => new
                {
                    HairColorID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Hair_color = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HairColors", x => x.HairColorID);
                });

            migrationBuilder.CreateTable(
                name: "Labs",
                columns: table => new
                {
                    LabID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Lab_name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Labs", x => x.LabID);
                });

            migrationBuilder.CreateTable(
                name: "Locations",
                columns: table => new
                {
                    LocationID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LocationFull = table.Column<string>(nullable: true),
                    Location_NS = table.Column<string>(nullable: true),
                    Location_EW = table.Column<string>(nullable: true),
                    NS_low = table.Column<int>(nullable: false),
                    NS_high = table.Column<int>(nullable: false),
                    EW_low = table.Column<int>(nullable: false),
                    EW_high = table.Column<int>(nullable: false),
                    Subplot = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Locations", x => x.LocationID);
                });

            migrationBuilder.CreateTable(
                name: "Preservations",
                columns: table => new
                {
                    PreservationID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Quality = table.Column<string>(nullable: true),
                    PreservationIndex = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Preservations", x => x.PreservationID);
                });

            migrationBuilder.CreateTable(
                name: "Skulls",
                columns: table => new
                {
                    SkullID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Max_cranial_length = table.Column<double>(nullable: false),
                    Max_cranial_breadth = table.Column<double>(nullable: false),
                    Basion_bregma_height = table.Column<double>(nullable: false),
                    basion_nasion = table.Column<double>(nullable: false),
                    Basion_prosthion_length = table.Column<double>(nullable: false),
                    Bizygomatic_diameter = table.Column<double>(nullable: false),
                    Nasion_prosthion = table.Column<double>(nullable: false),
                    Max_nasal_breadth = table.Column<double>(nullable: false),
                    Interorbital_breadth = table.Column<double>(nullable: false),
                    Buried_with_artifacts = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Skulls", x => x.SkullID);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<int>(nullable: false),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(nullable: false),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(nullable: false),
                    ProviderKey = table.Column<string>(nullable: false),
                    ProviderDisplayName = table.Column<string>(nullable: true),
                    UserId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<int>(nullable: false),
                    RoleId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<int>(nullable: false),
                    LoginProvider = table.Column<string>(nullable: false),
                    Name = table.Column<string>(nullable: false),
                    Value = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CarbonDatings",
                columns: table => new
                {
                    CarbonID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Rack = table.Column<int>(nullable: false),
                    Tube = table.Column<int>(nullable: false),
                    Description = table.Column<string>(nullable: true),
                    Size_ml = table.Column<int>(nullable: false),
                    Foci = table.Column<int>(nullable: false),
                    C14_sample_2017 = table.Column<int>(nullable: false),
                    Locations_description = table.Column<string>(nullable: true),
                    Questions = table.Column<string>(nullable: true),
                    Conventional_C14_age_bp = table.Column<int>(nullable: false),
                    C14_calendar_date = table.Column<int>(nullable: false),
                    Calibrated_95_calendar_date_max = table.Column<int>(nullable: false),
                    Calibrated_95_calendar_date_min = table.Column<int>(nullable: false),
                    Calibrated_95_calendar_date_span = table.Column<int>(nullable: false),
                    Year_era = table.Column<string>(nullable: true),
                    Category_ID = table.Column<int>(nullable: false),
                    CategoryID = table.Column<int>(nullable: true),
                    Lab_ID = table.Column<int>(nullable: false),
                    LabID = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CarbonDatings", x => x.CarbonID);
                    table.ForeignKey(
                        name: "FK_CarbonDatings_Categories_CategoryID",
                        column: x => x.CategoryID,
                        principalTable: "Categories",
                        principalColumn: "CategoryID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CarbonDatings_Labs_LabID",
                        column: x => x.LabID,
                        principalTable: "Labs",
                        principalColumn: "LabID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Burials",
                columns: table => new
                {
                    BurialID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserID = table.Column<int>(nullable: true),
                    AgeGroupID = table.Column<int>(nullable: true),
                    CarbonID = table.Column<int>(nullable: true),
                    LocationID = table.Column<int>(nullable: false),
                    HairColorID = table.Column<int>(nullable: true),
                    PreservationID = table.Column<int>(nullable: true),
                    SkullID = table.Column<int>(nullable: true),
                    Burial_number = table.Column<int>(nullable: false),
                    Depth = table.Column<int>(nullable: false),
                    Length = table.Column<int>(nullable: false),
                    Head_direction = table.Column<string>(nullable: true),
                    Discovery_date = table.Column<DateTime>(nullable: true),
                    Preservation_notes = table.Column<string>(nullable: true),
                    South_to_head = table.Column<int>(nullable: false),
                    South_to_feet = table.Column<int>(nullable: false),
                    West_to_head = table.Column<int>(nullable: false),
                    West_to_feet = table.Column<int>(nullable: false),
                    Sample_number = table.Column<int>(nullable: true),
                    GE_function_total = table.Column<double>(nullable: true),
                    Gender_body_col = table.Column<string>(nullable: true),
                    Gender_GE = table.Column<string>(nullable: true),
                    Basilar_structure = table.Column<string>(nullable: true),
                    Ventral_arc = table.Column<int>(nullable: true),
                    Subpubic_angle = table.Column<int>(nullable: true),
                    Sciatic_notch = table.Column<int>(nullable: true),
                    Pubic_bone = table.Column<int>(nullable: true),
                    Preaur_sulcus = table.Column<int>(nullable: true),
                    Medial_IP_ramus = table.Column<int>(nullable: true),
                    Dorsal_pitting = table.Column<int>(nullable: true),
                    Osteophytosis = table.Column<string>(nullable: true),
                    Pubic_sympysis = table.Column<string>(nullable: true),
                    Femur_head = table.Column<double>(nullable: true),
                    Femur_length = table.Column<int>(nullable: true),
                    Humerus_length = table.Column<double>(nullable: true),
                    Tibia_length = table.Column<double>(nullable: true),
                    Robust = table.Column<int>(nullable: true),
                    Supraorbital = table.Column<int>(nullable: true),
                    Orbital_edge = table.Column<int>(nullable: true),
                    Parietal_bossing = table.Column<int>(nullable: true),
                    Gonian = table.Column<int>(nullable: true),
                    Nuchal_crest = table.Column<int>(nullable: true),
                    Zygomatic_crest = table.Column<int>(nullable: true),
                    Artifacts_description = table.Column<string>(nullable: true),
                    Hair_taken = table.Column<bool>(nullable: true),
                    Soft_tissue_taken = table.Column<bool>(nullable: true),
                    Bone_taken = table.Column<bool>(nullable: true),
                    Tooth_taken = table.Column<bool>(nullable: true),
                    Textile_taken = table.Column<bool>(nullable: true),
                    Textile_notes = table.Column<string>(nullable: true),
                    Artifact_found = table.Column<bool>(nullable: true),
                    Estimate_age = table.Column<double>(nullable: true),
                    Estimate_living_stature = table.Column<double>(nullable: true),
                    Tooth_attrition = table.Column<string>(nullable: true),
                    Tooth_eruption = table.Column<string>(nullable: true),
                    Pathology_anomalies = table.Column<string>(nullable: true),
                    Epiphyseal_union = table.Column<string>(nullable: true),
                    PhotoPath = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Burials", x => x.BurialID);
                    table.ForeignKey(
                        name: "FK_Burials_AgeGroups_AgeGroupID",
                        column: x => x.AgeGroupID,
                        principalTable: "AgeGroups",
                        principalColumn: "AgeGroupID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Burials_CarbonDatings_CarbonID",
                        column: x => x.CarbonID,
                        principalTable: "CarbonDatings",
                        principalColumn: "CarbonID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Burials_HairColors_HairColorID",
                        column: x => x.HairColorID,
                        principalTable: "HairColors",
                        principalColumn: "HairColorID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Burials_Locations_LocationID",
                        column: x => x.LocationID,
                        principalTable: "Locations",
                        principalColumn: "LocationID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Burials_Preservations_PreservationID",
                        column: x => x.PreservationID,
                        principalTable: "Preservations",
                        principalColumn: "PreservationID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Burials_Skulls_SkullID",
                        column: x => x.SkullID,
                        principalTable: "Skulls",
                        principalColumn: "SkullID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Burials_AspNetUsers_UserID",
                        column: x => x.UserID,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Burials_AgeGroupID",
                table: "Burials",
                column: "AgeGroupID");

            migrationBuilder.CreateIndex(
                name: "IX_Burials_CarbonID",
                table: "Burials",
                column: "CarbonID");

            migrationBuilder.CreateIndex(
                name: "IX_Burials_HairColorID",
                table: "Burials",
                column: "HairColorID");

            migrationBuilder.CreateIndex(
                name: "IX_Burials_LocationID",
                table: "Burials",
                column: "LocationID");

            migrationBuilder.CreateIndex(
                name: "IX_Burials_PreservationID",
                table: "Burials",
                column: "PreservationID");

            migrationBuilder.CreateIndex(
                name: "IX_Burials_SkullID",
                table: "Burials",
                column: "SkullID");

            migrationBuilder.CreateIndex(
                name: "IX_Burials_UserID",
                table: "Burials",
                column: "UserID");

            migrationBuilder.CreateIndex(
                name: "IX_CarbonDatings_CategoryID",
                table: "CarbonDatings",
                column: "CategoryID");

            migrationBuilder.CreateIndex(
                name: "IX_CarbonDatings_LabID",
                table: "CarbonDatings",
                column: "LabID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "Burials");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "AgeGroups");

            migrationBuilder.DropTable(
                name: "CarbonDatings");

            migrationBuilder.DropTable(
                name: "HairColors");

            migrationBuilder.DropTable(
                name: "Locations");

            migrationBuilder.DropTable(
                name: "Preservations");

            migrationBuilder.DropTable(
                name: "Skulls");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DropTable(
                name: "Labs");
        }
    }
}
