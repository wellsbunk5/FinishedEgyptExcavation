// <auto-generated />
using System;
using EgyptExcavation.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace EgyptExcavation.Migrations
{
    [DbContext(typeof(ExcavationDbContext))]
    [Migration("20210412235258_Initial")]
    partial class Initial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.13")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("EgyptExcavation.Models.Age_Groups", b =>
                {
                    b.Property<int>("AgeGroupID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Age_group")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("BurialID")
                        .HasColumnType("int");

                    b.HasKey("AgeGroupID");

                    b.ToTable("AgeGroups");
                });

            modelBuilder.Entity("EgyptExcavation.Models.Burial", b =>
                {
                    b.Property<int>("BurialID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("AgeGroupID")
                        .HasColumnType("int");

                    b.Property<bool?>("Artifact_found")
                        .HasColumnType("bit");

                    b.Property<string>("Artifacts_description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Basilar_structure")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool?>("Bone_taken")
                        .HasColumnType("bit");

                    b.Property<int>("Burial_number")
                        .HasColumnType("int");

                    b.Property<int?>("CarbonID")
                        .HasColumnType("int");

                    b.Property<int>("Depth")
                        .HasColumnType("int");

                    b.Property<DateTime?>("Discovery_date")
                        .HasColumnType("datetime2");

                    b.Property<int?>("Dorsal_pitting")
                        .HasColumnType("int");

                    b.Property<string>("Epiphyseal_union")
                        .HasColumnType("nvarchar(max)");

                    b.Property<double?>("Estimate_age")
                        .HasColumnType("float");

                    b.Property<double?>("Estimate_living_stature")
                        .HasColumnType("float");

                    b.Property<double?>("Femur_head")
                        .HasColumnType("float");

                    b.Property<int?>("Femur_length")
                        .HasColumnType("int");

                    b.Property<double?>("GE_function_total")
                        .HasColumnType("float");

                    b.Property<string>("Gender_GE")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Gender_body_col")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("Gonian")
                        .HasColumnType("int");

                    b.Property<int?>("HairColorID")
                        .HasColumnType("int");

                    b.Property<bool?>("Hair_taken")
                        .HasColumnType("bit");

                    b.Property<string>("Head_direction")
                        .HasColumnType("nvarchar(max)");

                    b.Property<double?>("Humerus_length")
                        .HasColumnType("float");

                    b.Property<int>("Length")
                        .HasColumnType("int");

                    b.Property<int>("LocationID")
                        .HasColumnType("int");

                    b.Property<int?>("Medial_IP_ramus")
                        .HasColumnType("int");

                    b.Property<int?>("Nuchal_crest")
                        .HasColumnType("int");

                    b.Property<int?>("Orbital_edge")
                        .HasColumnType("int");

                    b.Property<string>("Osteophytosis")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("Parietal_bossing")
                        .HasColumnType("int");

                    b.Property<string>("Pathology_anomalies")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhotoPath")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("Preaur_sulcus")
                        .HasColumnType("int");

                    b.Property<int?>("PreservationID")
                        .HasColumnType("int");

                    b.Property<string>("Preservation_notes")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("Pubic_bone")
                        .HasColumnType("int");

                    b.Property<string>("Pubic_sympysis")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("Robust")
                        .HasColumnType("int");

                    b.Property<int?>("Sample_number")
                        .HasColumnType("int");

                    b.Property<int?>("Sciatic_notch")
                        .HasColumnType("int");

                    b.Property<int?>("SkullID")
                        .HasColumnType("int");

                    b.Property<bool?>("Soft_tissue_taken")
                        .HasColumnType("bit");

                    b.Property<int>("South_to_feet")
                        .HasColumnType("int");

                    b.Property<int>("South_to_head")
                        .HasColumnType("int");

                    b.Property<int?>("Subpubic_angle")
                        .HasColumnType("int");

                    b.Property<int?>("Supraorbital")
                        .HasColumnType("int");

                    b.Property<string>("Textile_notes")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool?>("Textile_taken")
                        .HasColumnType("bit");

                    b.Property<double?>("Tibia_length")
                        .HasColumnType("float");

                    b.Property<string>("Tooth_attrition")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Tooth_eruption")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool?>("Tooth_taken")
                        .HasColumnType("bit");

                    b.Property<int?>("UserID")
                        .HasColumnType("int");

                    b.Property<int?>("Ventral_arc")
                        .HasColumnType("int");

                    b.Property<int>("West_to_feet")
                        .HasColumnType("int");

                    b.Property<int>("West_to_head")
                        .HasColumnType("int");

                    b.Property<int?>("Zygomatic_crest")
                        .HasColumnType("int");

                    b.HasKey("BurialID");

                    b.HasIndex("AgeGroupID");

                    b.HasIndex("CarbonID");

                    b.HasIndex("HairColorID");

                    b.HasIndex("LocationID");

                    b.HasIndex("PreservationID");

                    b.HasIndex("SkullID");

                    b.HasIndex("UserID");

                    b.ToTable("Burials");
                });

            modelBuilder.Entity("EgyptExcavation.Models.CarbonDating", b =>
                {
                    b.Property<int>("CarbonID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("C14_calendar_date")
                        .HasColumnType("int");

                    b.Property<int>("C14_sample_2017")
                        .HasColumnType("int");

                    b.Property<int>("Calibrated_95_calendar_date_max")
                        .HasColumnType("int");

                    b.Property<int>("Calibrated_95_calendar_date_min")
                        .HasColumnType("int");

                    b.Property<int>("Calibrated_95_calendar_date_span")
                        .HasColumnType("int");

                    b.Property<int?>("CategoryID")
                        .HasColumnType("int");

                    b.Property<int>("Category_ID")
                        .HasColumnType("int");

                    b.Property<int>("Conventional_C14_age_bp")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Foci")
                        .HasColumnType("int");

                    b.Property<int?>("LabID")
                        .HasColumnType("int");

                    b.Property<int>("Lab_ID")
                        .HasColumnType("int");

                    b.Property<string>("Locations_description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Questions")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Rack")
                        .HasColumnType("int");

                    b.Property<int>("Size_ml")
                        .HasColumnType("int");

                    b.Property<int>("Tube")
                        .HasColumnType("int");

                    b.Property<string>("Year_era")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("CarbonID");

                    b.HasIndex("CategoryID");

                    b.HasIndex("LabID");

                    b.ToTable("CarbonDatings");
                });

            modelBuilder.Entity("EgyptExcavation.Models.Categories", b =>
                {
                    b.Property<int>("CategoryID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("CategoryID");

                    b.ToTable("Categories");
                });

            modelBuilder.Entity("EgyptExcavation.Models.HairColors", b =>
                {
                    b.Property<int>("HairColorID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Hair_color")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("HairColorID");

                    b.ToTable("HairColors");
                });

            modelBuilder.Entity("EgyptExcavation.Models.Labs", b =>
                {
                    b.Property<int>("LabID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Lab_name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("LabID");

                    b.ToTable("Labs");
                });

            modelBuilder.Entity("EgyptExcavation.Models.Locations", b =>
                {
                    b.Property<int>("LocationID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("EW_high")
                        .HasColumnType("int");

                    b.Property<int>("EW_low")
                        .HasColumnType("int");

                    b.Property<string>("LocationFull")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Location_EW")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Location_NS")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("NS_high")
                        .HasColumnType("int");

                    b.Property<int>("NS_low")
                        .HasColumnType("int");

                    b.Property<string>("Subplot")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("LocationID");

                    b.ToTable("Locations");
                });

            modelBuilder.Entity("EgyptExcavation.Models.Preservations", b =>
                {
                    b.Property<int>("PreservationID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("PreservationIndex")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Quality")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("PreservationID");

                    b.ToTable("Preservations");
                });

            modelBuilder.Entity("EgyptExcavation.Models.Role", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(256)")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedName")
                        .HasColumnType("nvarchar(256)")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles");
                });

            modelBuilder.Entity("EgyptExcavation.Models.Skulls", b =>
                {
                    b.Property<int>("SkullID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<double>("Basion_bregma_height")
                        .HasColumnType("float");

                    b.Property<double>("Basion_prosthion_length")
                        .HasColumnType("float");

                    b.Property<double>("Bizygomatic_diameter")
                        .HasColumnType("float");

                    b.Property<bool>("Buried_with_artifacts")
                        .HasColumnType("bit");

                    b.Property<double>("Interorbital_breadth")
                        .HasColumnType("float");

                    b.Property<double>("Max_cranial_breadth")
                        .HasColumnType("float");

                    b.Property<double>("Max_cranial_length")
                        .HasColumnType("float");

                    b.Property<double>("Max_nasal_breadth")
                        .HasColumnType("float");

                    b.Property<double>("Nasion_prosthion")
                        .HasColumnType("float");

                    b.Property<double>("basion_nasion")
                        .HasColumnType("float");

                    b.HasKey("SkullID");

                    b.ToTable("Skulls");
                });

            modelBuilder.Entity("EgyptExcavation.Models.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(256)")
                        .HasMaxLength(256);

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FullName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("NormalizedEmail")
                        .HasColumnType("nvarchar(256)")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedUserName")
                        .HasColumnType("nvarchar(256)")
                        .HasMaxLength(256);

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("UserName")
                        .HasColumnType("nvarchar(256)")
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

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<int>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("RoleId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<int>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<int>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderKey")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<int>", b =>
                {
                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.Property<int>("RoleId")
                        .HasColumnType("int");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<int>", b =>
                {
                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens");
                });

            modelBuilder.Entity("EgyptExcavation.Models.Burial", b =>
                {
                    b.HasOne("EgyptExcavation.Models.Age_Groups", "AgeGroup")
                        .WithMany("Burial")
                        .HasForeignKey("AgeGroupID");

                    b.HasOne("EgyptExcavation.Models.CarbonDating", "Carbon")
                        .WithMany("Burial")
                        .HasForeignKey("CarbonID");

                    b.HasOne("EgyptExcavation.Models.HairColors", "HairColor")
                        .WithMany("Burial")
                        .HasForeignKey("HairColorID");

                    b.HasOne("EgyptExcavation.Models.Locations", "Location")
                        .WithMany("Burial")
                        .HasForeignKey("LocationID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("EgyptExcavation.Models.Preservations", "Preservation")
                        .WithMany("Burial")
                        .HasForeignKey("PreservationID");

                    b.HasOne("EgyptExcavation.Models.Skulls", "Skull")
                        .WithMany("Burial")
                        .HasForeignKey("SkullID");

                    b.HasOne("EgyptExcavation.Models.User", "User")
                        .WithMany()
                        .HasForeignKey("UserID");
                });

            modelBuilder.Entity("EgyptExcavation.Models.CarbonDating", b =>
                {
                    b.HasOne("EgyptExcavation.Models.Categories", "Category")
                        .WithMany("Carbon")
                        .HasForeignKey("CategoryID");

                    b.HasOne("EgyptExcavation.Models.Labs", "Lab")
                        .WithMany("Carbon")
                        .HasForeignKey("LabID");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<int>", b =>
                {
                    b.HasOne("EgyptExcavation.Models.Role", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<int>", b =>
                {
                    b.HasOne("EgyptExcavation.Models.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<int>", b =>
                {
                    b.HasOne("EgyptExcavation.Models.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<int>", b =>
                {
                    b.HasOne("EgyptExcavation.Models.Role", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("EgyptExcavation.Models.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<int>", b =>
                {
                    b.HasOne("EgyptExcavation.Models.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
