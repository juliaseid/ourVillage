﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using YourVillage.Models;

namespace YourVillage.Migrations
{
    [DbContext(typeof(YourVillageContext))]
    partial class YourVillageContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("varchar(255)");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("longtext");

                    b.Property<string>("Name")
                        .HasColumnType("varchar(256)")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedName")
                        .HasColumnType("varchar(256)")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasName("RoleNameIndex");

                    b.ToTable("AspNetRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("ClaimType")
                        .HasColumnType("longtext");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("longtext");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("varchar(255)");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("ClaimType")
                        .HasColumnType("longtext");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("longtext");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("varchar(255)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasColumnType("varchar(255)");

                    b.Property<string>("ProviderKey")
                        .HasColumnType("varchar(255)");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("longtext");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("varchar(255)");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("varchar(255)");

                    b.Property<string>("RoleId")
                        .HasColumnType("varchar(255)");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("varchar(255)");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("varchar(255)");

                    b.Property<string>("Name")
                        .HasColumnType("varchar(255)");

                    b.Property<string>("Value")
                        .HasColumnType("longtext");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens");
                });

            modelBuilder.Entity("YourVillage.Models.Address", b =>
                {
                    b.Property<int>("AddressId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("AddressName")
                        .HasColumnType("longtext");

                    b.Property<string>("City")
                        .HasColumnType("longtext");

                    b.Property<int?>("FamilyId")
                        .HasColumnType("int");

                    b.Property<string>("State")
                        .HasColumnType("longtext");

                    b.Property<string>("StreetAddress")
                        .HasColumnType("longtext");

                    b.Property<string>("StreetAddressLine2")
                        .HasColumnType("longtext");

                    b.Property<int>("Zip")
                        .HasColumnType("int");

                    b.HasKey("AddressId");

                    b.HasIndex("FamilyId");

                    b.ToTable("Addresses");
                });

            modelBuilder.Entity("YourVillage.Models.ApplicationUser", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("varchar(255)");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("longtext");

                    b.Property<string>("Email")
                        .HasColumnType("varchar(256)")
                        .HasMaxLength(256);

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("Name")
                        .HasColumnType("longtext");

                    b.Property<string>("NormalizedEmail")
                        .HasColumnType("varchar(256)")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedUserName")
                        .HasColumnType("varchar(256)")
                        .HasMaxLength(256);

                    b.Property<string>("PasswordHash")
                        .HasColumnType("longtext");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("longtext");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("longtext");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("UserName")
                        .HasColumnType("varchar(256)")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasName("UserNameIndex");

                    b.ToTable("AspNetUsers");
                });

            modelBuilder.Entity("YourVillage.Models.Caregiver", b =>
                {
                    b.Property<string>("CaregiverId")
                        .HasColumnType("varchar(255)");

                    b.Property<bool>("Emergency")
                        .HasColumnType("bit");

                    b.Property<bool>("Evenings")
                        .HasColumnType("bit");

                    b.Property<string>("FirstName")
                        .HasColumnType("longtext");

                    b.Property<string>("LastName")
                        .HasColumnType("longtext");

                    b.Property<string>("Phone")
                        .HasColumnType("longtext");

                    b.Property<bool>("Weekdays")
                        .HasColumnType("bit");

                    b.Property<bool>("Weekends")
                        .HasColumnType("bit");

                    b.HasKey("CaregiverId");

                    b.ToTable("Caregivers");
                });

            modelBuilder.Entity("YourVillage.Models.CaregiverFamily", b =>
                {
                    b.Property<int>("CaregiverFamilyId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("CaregiverId")
                        .HasColumnType("varchar(255)");

                    b.Property<int>("FamilyId")
                        .HasColumnType("int");

                    b.HasKey("CaregiverFamilyId");

                    b.HasIndex("CaregiverId");

                    b.HasIndex("FamilyId");

                    b.ToTable("CaregiverFamilies");
                });

            modelBuilder.Entity("YourVillage.Models.Child", b =>
                {
                    b.Property<int>("ChildId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("Age")
                        .HasColumnType("int");

                    b.Property<string>("AgeUnit")
                        .HasColumnType("longtext");

                    b.Property<DateTime>("Birthday")
                        .HasColumnType("datetime(6)");

                    b.Property<int>("FamilyId")
                        .HasColumnType("int");

                    b.Property<string>("FirstName")
                        .HasColumnType("longtext");

                    b.Property<string>("LastName")
                        .HasColumnType("longtext");

                    b.Property<string>("Nickname")
                        .HasColumnType("longtext");

                    b.HasKey("ChildId");

                    b.HasIndex("FamilyId");

                    b.ToTable("Children");
                });

            modelBuilder.Entity("YourVillage.Models.ChildNote", b =>
                {
                    b.Property<int>("ChildNoteId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("ChildId")
                        .HasColumnType("int");

                    b.Property<int>("NoteId")
                        .HasColumnType("int");

                    b.HasKey("ChildNoteId");

                    b.HasIndex("ChildId");

                    b.HasIndex("NoteId");

                    b.ToTable("ChildNotes");
                });

            modelBuilder.Entity("YourVillage.Models.ChildProfile", b =>
                {
                    b.Property<int>("ChildProfileId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Allergies")
                        .HasColumnType("longtext");

                    b.Property<string>("Bedtime")
                        .HasColumnType("longtext");

                    b.Property<string>("Behavior")
                        .HasColumnType("longtext");

                    b.Property<int>("ChildId")
                        .HasColumnType("int");

                    b.Property<string>("Consequences")
                        .HasColumnType("longtext");

                    b.Property<string>("Dietary")
                        .HasColumnType("longtext");

                    b.Property<string>("Homework")
                        .HasColumnType("longtext");

                    b.Property<string>("Meals")
                        .HasColumnType("longtext");

                    b.Property<string>("MedicalConditions")
                        .HasColumnType("longtext");

                    b.Property<string>("Medications")
                        .HasColumnType("longtext");

                    b.Property<string>("Naptime")
                        .HasColumnType("longtext");

                    b.Property<string>("PackForSchool")
                        .HasColumnType("longtext");

                    b.Property<string>("Rewards")
                        .HasColumnType("longtext");

                    b.Property<string>("SchoolDetails")
                        .HasColumnType("longtext");

                    b.Property<string>("SchoolMeals")
                        .HasColumnType("longtext");

                    b.Property<string>("Snacks")
                        .HasColumnType("longtext");

                    b.HasKey("ChildProfileId");

                    b.HasIndex("ChildId");

                    b.ToTable("ChildProfiles");
                });

            modelBuilder.Entity("YourVillage.Models.Contact", b =>
                {
                    b.Property<int>("ContactId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("BusinessOrg")
                        .HasColumnType("longtext");

                    b.Property<string>("ContactType")
                        .HasColumnType("longtext");

                    b.Property<int?>("FamilyId")
                        .HasColumnType("int");

                    b.Property<string>("FirstName")
                        .HasColumnType("longtext");

                    b.Property<string>("LastName")
                        .HasColumnType("longtext");

                    b.Property<string>("Phone")
                        .HasColumnType("longtext");

                    b.Property<string>("Relationship")
                        .HasColumnType("longtext");

                    b.HasKey("ContactId");

                    b.HasIndex("FamilyId");

                    b.ToTable("Contacts");
                });

            modelBuilder.Entity("YourVillage.Models.Family", b =>
                {
                    b.Property<int>("FamilyId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("CaregiverIds")
                        .HasColumnType("longtext");

                    b.Property<string>("Parent1FirstName")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Parent1LastName")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Parent1Phone")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Parent1Relationship")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Parent2FirstName")
                        .HasColumnType("longtext");

                    b.Property<string>("Parent2LastName")
                        .HasColumnType("longtext");

                    b.Property<string>("Parent2Phone")
                        .HasColumnType("longtext");

                    b.Property<string>("Parent2Relationship")
                        .HasColumnType("longtext");

                    b.Property<string>("ParentId")
                        .HasColumnType("longtext");

                    b.Property<string>("ProfileName")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<int>("SecretCode")
                        .HasColumnType("int");

                    b.HasKey("FamilyId");

                    b.ToTable("Families");
                });

            modelBuilder.Entity("YourVillage.Models.Note", b =>
                {
                    b.Property<int>("NoteId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Text")
                        .HasColumnType("longtext");

                    b.Property<string>("UserId")
                        .HasColumnType("varchar(255)");

                    b.HasKey("NoteId");

                    b.HasIndex("UserId");

                    b.ToTable("Notes");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("YourVillage.Models.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("YourVillage.Models.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("YourVillage.Models.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("YourVillage.Models.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("YourVillage.Models.Address", b =>
                {
                    b.HasOne("YourVillage.Models.Family", null)
                        .WithMany("Addresses")
                        .HasForeignKey("FamilyId");
                });

            modelBuilder.Entity("YourVillage.Models.CaregiverFamily", b =>
                {
                    b.HasOne("YourVillage.Models.Caregiver", "Caregiver")
                        .WithMany("Families")
                        .HasForeignKey("CaregiverId");

                    b.HasOne("YourVillage.Models.Family", "Family")
                        .WithMany("Caregivers")
                        .HasForeignKey("FamilyId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("YourVillage.Models.Child", b =>
                {
                    b.HasOne("YourVillage.Models.Family", null)
                        .WithMany("Children")
                        .HasForeignKey("FamilyId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("YourVillage.Models.ChildNote", b =>
                {
                    b.HasOne("YourVillage.Models.Child", "Child")
                        .WithMany("Notes")
                        .HasForeignKey("ChildId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("YourVillage.Models.Note", "Note")
                        .WithMany("Children")
                        .HasForeignKey("NoteId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("YourVillage.Models.ChildProfile", b =>
                {
                    b.HasOne("YourVillage.Models.Child", "Child")
                        .WithMany("Profile")
                        .HasForeignKey("ChildId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("YourVillage.Models.Contact", b =>
                {
                    b.HasOne("YourVillage.Models.Family", null)
                        .WithMany("Contacts")
                        .HasForeignKey("FamilyId");
                });

            modelBuilder.Entity("YourVillage.Models.Note", b =>
                {
                    b.HasOne("YourVillage.Models.ApplicationUser", "User")
                        .WithMany()
                        .HasForeignKey("UserId");
                });
#pragma warning restore 612, 618
        }
    }
}
