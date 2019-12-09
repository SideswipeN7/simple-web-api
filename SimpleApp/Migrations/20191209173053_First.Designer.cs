﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore.Storage.Internal;
using SimpleApp.Models;
using System;

namespace SimpleApp.Migrations
{
    [DbContext(typeof(ProductsContext))]
    [Migration("20191209173053_First")]
    partial class First
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.0.3-rtm-10026")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("SimpleApp.Models.Product", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnName("Name")
                        .HasMaxLength(100);

                    b.Property<decimal>("Price")
                        .HasColumnName("Price")
                        .HasColumnType("DECIMAL");

                    b.HasKey("Id")
                        .HasName("Guid");

                    b.ToTable("PRODUCTS");
                });
#pragma warning restore 612, 618
        }
    }
}