﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using StoriesReadingAPI.Models;

#nullable disable

namespace StoriesReadingAPI.Migrations
{
    [DbContext(typeof(SampleDBContext))]
    [Migration("20240727204652_LanguagesIsShownMigration")]
    partial class LanguagesIsShownMigration
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.7")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("StoriesReadingAPI.Models.LanguageLevels", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("LanguageId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Power")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("LanguageId");

                    b.ToTable("LanguageLevels");
                });

            modelBuilder.Entity("StoriesReadingAPI.Models.Languages", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<bool>("IsShown")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Languages");
                });

            modelBuilder.Entity("StoriesReadingAPI.Models.Sentences", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("LanguageOriginal")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LanguageTranslation")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Order")
                        .HasColumnType("int");

                    b.Property<int>("TextId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("TextId");

                    b.ToTable("Sentences");
                });

            modelBuilder.Entity("StoriesReadingAPI.Models.Texts", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("LanguageLevelsId")
                        .HasColumnType("int");

                    b.Property<int>("LanguageOriginalId")
                        .HasColumnType("int");

                    b.Property<int>("LanguageTranslationId")
                        .HasColumnType("int");

                    b.Property<string>("TextTitle")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("LanguageLevelsId");

                    b.HasIndex("LanguageOriginalId");

                    b.HasIndex("LanguageTranslationId");

                    b.ToTable("Texts");
                });

            modelBuilder.Entity("StoriesReadingAPI.Models.LanguageLevels", b =>
                {
                    b.HasOne("StoriesReadingAPI.Models.Languages", "Language")
                        .WithMany("Levels")
                        .HasForeignKey("LanguageId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Language");
                });

            modelBuilder.Entity("StoriesReadingAPI.Models.Sentences", b =>
                {
                    b.HasOne("StoriesReadingAPI.Models.Texts", "Text")
                        .WithMany()
                        .HasForeignKey("TextId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Text");
                });

            modelBuilder.Entity("StoriesReadingAPI.Models.Texts", b =>
                {
                    b.HasOne("StoriesReadingAPI.Models.LanguageLevels", "LanguageLevels")
                        .WithMany()
                        .HasForeignKey("LanguageLevelsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("StoriesReadingAPI.Models.Languages", "LanguageOriginal")
                        .WithMany()
                        .HasForeignKey("LanguageOriginalId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("StoriesReadingAPI.Models.Languages", "LanguageTranslation")
                        .WithMany()
                        .HasForeignKey("LanguageTranslationId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("LanguageLevels");

                    b.Navigation("LanguageOriginal");

                    b.Navigation("LanguageTranslation");
                });

            modelBuilder.Entity("StoriesReadingAPI.Models.Languages", b =>
                {
                    b.Navigation("Levels");
                });
#pragma warning restore 612, 618
        }
    }
}
