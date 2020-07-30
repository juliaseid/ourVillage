﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using YourVillage.Models;

namespace YourVillage.Migrations
{
    [DbContext(typeof(YourVillageContext))]
    [Migration("20200730044456_CaregiverBools")]
    partial class CaregiverBools
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.4-servicing-10062")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

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
                        .HasName("RoleNameIndex");

                    b.ToTable("AspNetRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<string>("RoleId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

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

            modelBuilder.Entity("YourVillage.Models.Address", b =>
                {
                    b.Property<int>("AddressId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("AddressName");

                    b.Property<string>("City");

                    b.Property<int?>("FamilyId");

                    b.Property<string>("State");

                    b.Property<string>("StreetAddress");

                    b.Property<string>("StreetAddressLine2");

                    b.Property<int>("Zip");

                    b.HasKey("AddressId");

                    b.HasIndex("FamilyId");

                    b.ToTable("Addresses");
                });

            modelBuilder.Entity("YourVillage.Models.ApplicationUser", b =>
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

                    b.Property<string>("Name");

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
                        .HasName("UserNameIndex");

                    b.ToTable("AspNetUsers");
                });

            modelBuilder.Entity("YourVillage.Models.Caregiver", b =>
                {
                    b.Property<string>("CaregiverId")
                        .ValueGeneratedOnAdd();

                    b.Property<bool>("Emergency");

                    b.Property<bool>("Evenings");

                    b.Property<string>("FirstName");

                    b.Property<string>("LastName");

                    b.Property<string>("Phone");

                    b.Property<bool>("Weekdays");

                    b.Property<bool>("Weekends");

                    b.HasKey("CaregiverId");

                    b.ToTable("Caregivers");
                });

            modelBuilder.Entity("YourVillage.Models.CaregiverFamily", b =>
                {
                    b.Property<int>("CaregiverFamilyId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("CaregiverId");

                    b.Property<int>("FamilyId");

                    b.HasKey("CaregiverFamilyId");

                    b.HasIndex("CaregiverId");

                    b.HasIndex("FamilyId");

                    b.ToTable("CaregiverFamilies");
                });

            modelBuilder.Entity("YourVillage.Models.Child", b =>
                {
                    b.Property<int>("ChildId")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("Age");

                    b.Property<string>("AgeUnit");

                    b.Property<DateTime>("Birthday");

                    b.Property<int>("FamilyId");

                    b.Property<string>("FirstName");

                    b.Property<string>("LastName");

                    b.Property<string>("Nickname");

                    b.HasKey("ChildId");

                    b.HasIndex("FamilyId");

                    b.ToTable("Children");
                });

            modelBuilder.Entity("YourVillage.Models.ChildNote", b =>
                {
                    b.Property<int>("ChildNoteId")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("ChildId");

                    b.Property<int>("NoteId");

                    b.HasKey("ChildNoteId");

                    b.HasIndex("ChildId");

                    b.HasIndex("NoteId");

                    b.ToTable("ChildNotes");
                });

            modelBuilder.Entity("YourVillage.Models.ChildProfile", b =>
                {
                    b.Property<int>("ChildProfileId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Allergies");

                    b.Property<string>("Bedtime");

                    b.Property<string>("Behavior");

                    b.Property<int>("ChildId");

                    b.Property<string>("Consequences");

                    b.Property<string>("Dietary");

                    b.Property<string>("Homework");

                    b.Property<string>("Meals");

                    b.Property<string>("MedicalConditions");

                    b.Property<string>("Medications");

                    b.Property<string>("Naptime");

                    b.Property<string>("PackForSchool");

                    b.Property<string>("Rewards");

                    b.Property<string>("SchoolDetails");

                    b.Property<string>("SchoolMeals");

                    b.Property<string>("Snacks");

                    b.HasKey("ChildProfileId");

                    b.HasIndex("ChildId");

                    b.ToTable("ChildProfiles");
                });

            modelBuilder.Entity("YourVillage.Models.Contact", b =>
                {
                    b.Property<int>("ContactId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("BusinessOrg");

                    b.Property<string>("ContactType");

                    b.Property<int?>("FamilyId");

                    b.Property<string>("FirstName");

                    b.Property<string>("LastName");

                    b.Property<string>("Phone");

                    b.Property<string>("Relationship");

                    b.HasKey("ContactId");

                    b.HasIndex("FamilyId");

                    b.ToTable("Contacts");
                });

            modelBuilder.Entity("YourVillage.Models.Family", b =>
                {
                    b.Property<int>("FamilyId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("CaregiverIds");

                    b.Property<string>("Parent1FirstName")
                        .IsRequired();

                    b.Property<string>("Parent1LastName")
                        .IsRequired();

                    b.Property<string>("Parent1Phone")
                        .IsRequired();

                    b.Property<string>("Parent1Relationship")
                        .IsRequired();

                    b.Property<string>("Parent2FirstName");

                    b.Property<string>("Parent2LastName");

                    b.Property<string>("Parent2Phone");

                    b.Property<string>("Parent2Relationship");

                    b.Property<string>("ParentId");

                    b.Property<string>("ProfileName")
                        .IsRequired();

                    b.Property<int>("SecretCode");

                    b.HasKey("FamilyId");

                    b.ToTable("Families");
                });

            modelBuilder.Entity("YourVillage.Models.Note", b =>
                {
                    b.Property<int>("NoteId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Text");

                    b.Property<string>("UserId");

                    b.HasKey("NoteId");

                    b.HasIndex("UserId");

                    b.ToTable("Notes");
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
                    b.HasOne("YourVillage.Models.ApplicationUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("YourVillage.Models.ApplicationUser")
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

                    b.HasOne("YourVillage.Models.ApplicationUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("YourVillage.Models.ApplicationUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("YourVillage.Models.Address", b =>
                {
                    b.HasOne("YourVillage.Models.Family")
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
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("YourVillage.Models.Child", b =>
                {
                    b.HasOne("YourVillage.Models.Family", "Family")
                        .WithMany("Children")
                        .HasForeignKey("FamilyId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("YourVillage.Models.ChildNote", b =>
                {
                    b.HasOne("YourVillage.Models.Child", "Child")
                        .WithMany("Notes")
                        .HasForeignKey("ChildId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("YourVillage.Models.Note", "Note")
                        .WithMany("Children")
                        .HasForeignKey("NoteId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("YourVillage.Models.ChildProfile", b =>
                {
                    b.HasOne("YourVillage.Models.Child", "Child")
                        .WithMany("Profile")
                        .HasForeignKey("ChildId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("YourVillage.Models.Contact", b =>
                {
                    b.HasOne("YourVillage.Models.Family")
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
