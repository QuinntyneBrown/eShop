﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using eShop.Api.Data;

namespace eShop.Api.Migrations
{
    [DbContext(typeof(EShopDbContext))]
    partial class EShopDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.4")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("eShop.Api.Models.Basket", b =>
                {
                    b.Property<Guid>("BasketId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("CustomerId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("BasketId");

                    b.ToTable("Baskets");
                });

            modelBuilder.Entity("eShop.Api.Models.BasketItem", b =>
                {
                    b.Property<Guid>("BasketItemId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("BasketId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("CatalogItemId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.HasKey("BasketItemId");

                    b.HasIndex("BasketId");

                    b.ToTable("BasketItem");
                });

            modelBuilder.Entity("eShop.Api.Models.CatalogItem", b =>
                {
                    b.Property<Guid>("CatalogItemId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("InventoryCount")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("OnReOrder")
                        .HasColumnType("bit");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("QuantityInStock")
                        .HasColumnType("int");

                    b.HasKey("CatalogItemId");

                    b.ToTable("CatalogItems");
                });

            modelBuilder.Entity("eShop.Api.Models.CatalogItemImage", b =>
                {
                    b.Property<Guid>("CatalogItemImageId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("CatalogItemId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("DigitalAssetId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("CatalogItemImageId");

                    b.HasIndex("CatalogItemId");

                    b.ToTable("CatalogItemImage");
                });

            modelBuilder.Entity("eShop.Api.Models.CatalogItemNote", b =>
                {
                    b.Property<Guid>("CatalogItemId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("NoteId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("CatalogItemId", "NoteId");

                    b.HasIndex("NoteId");

                    b.ToTable("CatalogItemNote");
                });

            modelBuilder.Entity("eShop.Api.Models.Contact", b =>
                {
                    b.Property<Guid>("ContactId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ContactId");

                    b.ToTable("Contacts");
                });

            modelBuilder.Entity("eShop.Api.Models.Content", b =>
                {
                    b.Property<Guid>("ContentId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("About")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ContactInfo")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FacebookUrl")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("HeroImageUrl")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("InstagramUrl")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LogoUrl")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ReturnPolicy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Subscribe")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TermsOfService")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Title")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TwitterUrl")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ContentId");

                    b.ToTable("Contents");
                });

            modelBuilder.Entity("eShop.Api.Models.Customer", b =>
                {
                    b.Property<Guid>("CustomerId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Firstname")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Lastname")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("CustomerId");

                    b.ToTable("Customers");
                });

            modelBuilder.Entity("eShop.Api.Models.Customization", b =>
                {
                    b.Property<Guid>("CustomizationId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("BackgroundColor")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("CustomizationId");

                    b.ToTable("Customizations");
                });

            modelBuilder.Entity("eShop.Api.Models.DigitalAsset", b =>
                {
                    b.Property<Guid>("DigitalAssetId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<byte[]>("Bytes")
                        .HasColumnType("varbinary(max)");

                    b.Property<string>("ContentType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("DigitalAssetId");

                    b.ToTable("DigitalAssets");
                });

            modelBuilder.Entity("eShop.Api.Models.HtmlContent", b =>
                {
                    b.Property<Guid>("HtmlContentId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Body")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid?>("ContentId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("HtmlContentId");

                    b.HasIndex("ContentId");

                    b.ToTable("HtmlContents");
                });

            modelBuilder.Entity("eShop.Api.Models.ImageContent", b =>
                {
                    b.Property<Guid>("ImageContentId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("ContentId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("DigitalAssetId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("ImageContentId");

                    b.HasIndex("ContentId");

                    b.ToTable("ImageContents");
                });

            modelBuilder.Entity("eShop.Api.Models.Note", b =>
                {
                    b.Property<Guid>("NoteId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Body")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid?>("CatalogItemId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("Created")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("Deleted")
                        .HasColumnType("datetime2");

                    b.HasKey("NoteId");

                    b.HasIndex("CatalogItemId");

                    b.ToTable("Notes");
                });

            modelBuilder.Entity("eShop.Api.Models.Order", b =>
                {
                    b.Property<Guid>("OrderId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<decimal>("Cost")
                        .HasColumnType("decimal(18,2)");

                    b.Property<Guid>("CustomerId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("OrderDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.HasKey("OrderId");

                    b.ToTable("Orders");
                });

            modelBuilder.Entity("eShop.Api.Models.OrderItem", b =>
                {
                    b.Property<Guid>("OrderItemId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("CatalogItemId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("OrderId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.HasKey("OrderItemId");

                    b.HasIndex("OrderId");

                    b.ToTable("OrderItems");
                });

            modelBuilder.Entity("eShop.Api.Models.Role", b =>
                {
                    b.Property<Guid>("RoleId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid?>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("RoleId");

                    b.HasIndex("UserId");

                    b.ToTable("Roles");
                });

            modelBuilder.Entity("eShop.Api.Models.TextContent", b =>
                {
                    b.Property<Guid>("TextContentId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("ContentId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("TextContentId");

                    b.HasIndex("ContentId");

                    b.ToTable("TextContents");
                });

            modelBuilder.Entity("eShop.Api.Models.User", b =>
                {
                    b.Property<Guid>("UserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("AvatarDigitalAssetId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Password")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RefreshToken")
                        .HasColumnType("nvarchar(max)");

                    b.Property<byte[]>("Salt")
                        .HasColumnType("varbinary(max)");

                    b.Property<string>("Username")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("eShop.Api.Models.UserRole", b =>
                {
                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("RoleId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("UserId", "RoleId");

                    b.ToTable("UserRole");
                });

            modelBuilder.Entity("eShop.Api.Models.BasketItem", b =>
                {
                    b.HasOne("eShop.Api.Models.Basket", null)
                        .WithMany("BasketItems")
                        .HasForeignKey("BasketId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("eShop.Api.Models.CatalogItemImage", b =>
                {
                    b.HasOne("eShop.Api.Models.CatalogItem", null)
                        .WithMany("CatalogItemImages")
                        .HasForeignKey("CatalogItemId");
                });

            modelBuilder.Entity("eShop.Api.Models.CatalogItemNote", b =>
                {
                    b.HasOne("eShop.Api.Models.CatalogItem", "CatalogItem")
                        .WithMany()
                        .HasForeignKey("CatalogItemId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("eShop.Api.Models.Note", "Note")
                        .WithMany()
                        .HasForeignKey("NoteId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("CatalogItem");

                    b.Navigation("Note");
                });

            modelBuilder.Entity("eShop.Api.Models.HtmlContent", b =>
                {
                    b.HasOne("eShop.Api.Models.Content", null)
                        .WithMany("HtmlContents")
                        .HasForeignKey("ContentId");
                });

            modelBuilder.Entity("eShop.Api.Models.ImageContent", b =>
                {
                    b.HasOne("eShop.Api.Models.Content", null)
                        .WithMany("ImageContents")
                        .HasForeignKey("ContentId");
                });

            modelBuilder.Entity("eShop.Api.Models.Note", b =>
                {
                    b.HasOne("eShop.Api.Models.CatalogItem", null)
                        .WithMany("Notes")
                        .HasForeignKey("CatalogItemId");
                });

            modelBuilder.Entity("eShop.Api.Models.Order", b =>
                {
                    b.OwnsOne("eShop.Api.Models.Address", "BillingAddress", b1 =>
                        {
                            b1.Property<Guid>("OrderId")
                                .HasColumnType("uniqueidentifier");

                            b1.Property<string>("City")
                                .HasColumnType("nvarchar(max)");

                            b1.Property<string>("PostalCode")
                                .HasColumnType("nvarchar(max)");

                            b1.Property<string>("Province")
                                .HasColumnType("nvarchar(max)");

                            b1.Property<string>("Street")
                                .HasColumnType("nvarchar(max)");

                            b1.HasKey("OrderId");

                            b1.ToTable("Orders");

                            b1.WithOwner()
                                .HasForeignKey("OrderId");
                        });

                    b.OwnsOne("eShop.Api.Models.Address", "ShippingAddress", b1 =>
                        {
                            b1.Property<Guid>("OrderId")
                                .HasColumnType("uniqueidentifier");

                            b1.Property<string>("City")
                                .HasColumnType("nvarchar(max)");

                            b1.Property<string>("PostalCode")
                                .HasColumnType("nvarchar(max)");

                            b1.Property<string>("Province")
                                .HasColumnType("nvarchar(max)");

                            b1.Property<string>("Street")
                                .HasColumnType("nvarchar(max)");

                            b1.HasKey("OrderId");

                            b1.ToTable("Orders");

                            b1.WithOwner()
                                .HasForeignKey("OrderId");
                        });

                    b.Navigation("BillingAddress");

                    b.Navigation("ShippingAddress");
                });

            modelBuilder.Entity("eShop.Api.Models.OrderItem", b =>
                {
                    b.HasOne("eShop.Api.Models.Order", null)
                        .WithMany("OrderItems")
                        .HasForeignKey("OrderId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("eShop.Api.Models.Role", b =>
                {
                    b.HasOne("eShop.Api.Models.User", null)
                        .WithMany("Roles")
                        .HasForeignKey("UserId");

                    b.OwnsMany("eShop.Api.Models.Privilege", "Privileges", b1 =>
                        {
                            b1.Property<Guid>("RoleId")
                                .HasColumnType("uniqueidentifier");

                            b1.Property<int>("Id")
                                .ValueGeneratedOnAdd()
                                .HasColumnType("int")
                                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                            b1.Property<int>("AccessRight")
                                .HasColumnType("int");

                            b1.Property<string>("Aggregate")
                                .HasColumnType("nvarchar(max)");

                            b1.HasKey("RoleId", "Id");

                            b1.ToTable("Privilege");

                            b1.WithOwner()
                                .HasForeignKey("RoleId");
                        });

                    b.Navigation("Privileges");
                });

            modelBuilder.Entity("eShop.Api.Models.TextContent", b =>
                {
                    b.HasOne("eShop.Api.Models.Content", null)
                        .WithMany("TextContents")
                        .HasForeignKey("ContentId");
                });

            modelBuilder.Entity("eShop.Api.Models.Basket", b =>
                {
                    b.Navigation("BasketItems");
                });

            modelBuilder.Entity("eShop.Api.Models.CatalogItem", b =>
                {
                    b.Navigation("CatalogItemImages");

                    b.Navigation("Notes");
                });

            modelBuilder.Entity("eShop.Api.Models.Content", b =>
                {
                    b.Navigation("HtmlContents");

                    b.Navigation("ImageContents");

                    b.Navigation("TextContents");
                });

            modelBuilder.Entity("eShop.Api.Models.Order", b =>
                {
                    b.Navigation("OrderItems");
                });

            modelBuilder.Entity("eShop.Api.Models.User", b =>
                {
                    b.Navigation("Roles");
                });
#pragma warning restore 612, 618
        }
    }
}
