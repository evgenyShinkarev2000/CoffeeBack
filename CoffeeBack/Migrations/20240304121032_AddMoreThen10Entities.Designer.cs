﻿// <auto-generated />
using System;
using CoffeeBack.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace CoffeeBack.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20240304121032_AddMoreThen10Entities")]
    partial class AddMoreThen10Entities
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "8.0.2");

            modelBuilder.Entity("CoffeeBack.Data.Models.Document", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int?>("DocumentKindId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("ExternalId")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("DocumentKindId");

                    b.ToTable("Documents");
                });

            modelBuilder.Entity("CoffeeBack.Data.Models.DocumentKind", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("DocumentKinds");
                });

            modelBuilder.Entity("CoffeeBack.Data.Models.Person", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .HasColumnType("TEXT");

                    b.Property<string>("Patronymic")
                        .HasColumnType("TEXT");

                    b.Property<string>("Surname")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("People");
                });

            modelBuilder.Entity("CoffeeBack.Data.Models.PersonRole", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("AccessLevel")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .HasColumnType("TEXT");

                    b.Property<int?>("PersonId")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("PersonId");

                    b.ToTable("PersonRoleMany");
                });

            modelBuilder.Entity("CoffeeBack.Data.Models.SelectAnswerExercise", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Question")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("SelectAnswerExercises");
                });

            modelBuilder.Entity("CoffeeBack.Data.Models.SelectAnswerExersiseAnswer", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Answer")
                        .HasColumnType("TEXT");

                    b.Property<bool>("IsRightAnswer")
                        .HasColumnType("INTEGER");

                    b.Property<int?>("SelectAnswerExerciseId")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("SelectAnswerExerciseId");

                    b.ToTable("SelectAnswerExersiseAnswers");
                });

            modelBuilder.Entity("CoffeeBack.Data.Models.TextLecture", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Content")
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("TextLectures");
                });

            modelBuilder.Entity("CoffeeBack.Data.Models.VideoLecture", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .HasColumnType("TEXT");

                    b.Property<string>("Source")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("VideoLectures");
                });

            modelBuilder.Entity("DocumentPerson", b =>
                {
                    b.Property<int>("DocumentsId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("PeopleId")
                        .HasColumnType("INTEGER");

                    b.HasKey("DocumentsId", "PeopleId");

                    b.HasIndex("PeopleId");

                    b.ToTable("DocumentPerson");
                });

            modelBuilder.Entity("PersonTextLecture", b =>
                {
                    b.Property<int>("CompleatedTextLecturesId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("LearnedPeopleId")
                        .HasColumnType("INTEGER");

                    b.HasKey("CompleatedTextLecturesId", "LearnedPeopleId");

                    b.HasIndex("LearnedPeopleId");

                    b.ToTable("PersonTextLecture");
                });

            modelBuilder.Entity("PersonVideoLecture", b =>
                {
                    b.Property<int>("CompleatedVideoLecturesId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("LearnedPeopleId")
                        .HasColumnType("INTEGER");

                    b.HasKey("CompleatedVideoLecturesId", "LearnedPeopleId");

                    b.HasIndex("LearnedPeopleId");

                    b.ToTable("PersonVideoLecture");
                });

            modelBuilder.Entity("CoffeeBack.Data.Models.Document", b =>
                {
                    b.HasOne("CoffeeBack.Data.Models.DocumentKind", "DocumentKind")
                        .WithMany()
                        .HasForeignKey("DocumentKindId");

                    b.Navigation("DocumentKind");
                });

            modelBuilder.Entity("CoffeeBack.Data.Models.PersonRole", b =>
                {
                    b.HasOne("CoffeeBack.Data.Models.Person", "Person")
                        .WithMany()
                        .HasForeignKey("PersonId");

                    b.Navigation("Person");
                });

            modelBuilder.Entity("CoffeeBack.Data.Models.SelectAnswerExersiseAnswer", b =>
                {
                    b.HasOne("CoffeeBack.Data.Models.SelectAnswerExercise", "SelectAnswerExercise")
                        .WithMany("Answers")
                        .HasForeignKey("SelectAnswerExerciseId");

                    b.Navigation("SelectAnswerExercise");
                });

            modelBuilder.Entity("DocumentPerson", b =>
                {
                    b.HasOne("CoffeeBack.Data.Models.Document", null)
                        .WithMany()
                        .HasForeignKey("DocumentsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("CoffeeBack.Data.Models.Person", null)
                        .WithMany()
                        .HasForeignKey("PeopleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("PersonTextLecture", b =>
                {
                    b.HasOne("CoffeeBack.Data.Models.TextLecture", null)
                        .WithMany()
                        .HasForeignKey("CompleatedTextLecturesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("CoffeeBack.Data.Models.Person", null)
                        .WithMany()
                        .HasForeignKey("LearnedPeopleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("PersonVideoLecture", b =>
                {
                    b.HasOne("CoffeeBack.Data.Models.VideoLecture", null)
                        .WithMany()
                        .HasForeignKey("CompleatedVideoLecturesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("CoffeeBack.Data.Models.Person", null)
                        .WithMany()
                        .HasForeignKey("LearnedPeopleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("CoffeeBack.Data.Models.SelectAnswerExercise", b =>
                {
                    b.Navigation("Answers");
                });
#pragma warning restore 612, 618
        }
    }
}
