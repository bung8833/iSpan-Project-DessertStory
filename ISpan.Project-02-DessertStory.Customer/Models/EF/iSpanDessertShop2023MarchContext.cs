using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace ISpan.Project_02_DessertStory.Customer.Models.EF
{
    public partial class iSpanDessertShop2023MarchContext : DbContext
    {
        public iSpanDessertShop2023MarchContext()
        {
        }

        public iSpanDessertShop2023MarchContext(DbContextOptions<iSpanDessertShop2023MarchContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Administrator> Administrators { get; set; } = null!;
        public virtual DbSet<Advertise> Advertises { get; set; } = null!;
        public virtual DbSet<BlacklistedMember> BlacklistedMembers { get; set; } = null!;
        public virtual DbSet<CartItem> CartItems { get; set; } = null!;
        public virtual DbSet<Category> Categories { get; set; } = null!;
        public virtual DbSet<Comment> Comments { get; set; } = null!;
        public virtual DbSet<Coupon> Coupons { get; set; } = null!;
        public virtual DbSet<CustomerReservation> CustomerReservations { get; set; } = null!;
        public virtual DbSet<LoginHistory> LoginHistories { get; set; } = null!;
        public virtual DbSet<Member> Members { get; set; } = null!;
        public virtual DbSet<MemberAddress> MemberAddresses { get; set; } = null!;
        public virtual DbSet<Order> Orders { get; set; } = null!;
        public virtual DbSet<OrderDetail> OrderDetails { get; set; } = null!;
        public virtual DbSet<Post> Posts { get; set; } = null!;
        public virtual DbSet<PostText> PostTexts { get; set; } = null!;
        public virtual DbSet<Product> Products { get; set; } = null!;
        public virtual DbSet<ProductFlavor> ProductFlavors { get; set; } = null!;
        public virtual DbSet<ProductSize> ProductSizes { get; set; } = null!;
        public virtual DbSet<Recipe> Recipes { get; set; } = null!;
        public virtual DbSet<Reply> Replies { get; set; } = null!;
        public virtual DbSet<Report> Reports { get; set; } = null!;
        public virtual DbSet<Seller> Sellers { get; set; } = null!;
        public virtual DbSet<Suspension> Suspensions { get; set; } = null!;
        public virtual DbSet<TablesForReservation> TablesForReservations { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Administrator>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Account).HasMaxLength(50);

                entity.Property(e => e.ContactNumber).HasMaxLength(50);

                entity.Property(e => e.Email).HasMaxLength(50);

                entity.Property(e => e.Notes).HasMaxLength(500);

                entity.Property(e => e.Password).HasMaxLength(50);
            });

            modelBuilder.Entity<Advertise>(entity =>
            {
                entity.ToTable("Advertise");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Tendtime).HasColumnType("datetime");

                entity.Property(e => e.Tstarttime).HasColumnType("datetime");
            });

            modelBuilder.Entity<BlacklistedMember>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.MemberAccount).HasMaxLength(50);

                entity.Property(e => e.MemberId).HasColumnName("MemberID");

                entity.Property(e => e.SellerId).HasColumnName("SellerID");

                entity.Property(e => e.Status).HasMaxLength(50);
            });

            modelBuilder.Entity<CartItem>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.AddTime)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.MemberId).HasColumnName("MemberID");

                entity.Property(e => e.Notes).HasMaxLength(500);

                entity.Property(e => e.ProductId).HasColumnName("ProductID");

                entity.HasOne(d => d.Member)
                    .WithMany(p => p.CartItems)
                    .HasForeignKey(d => d.MemberId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_CartItems_Members");

                entity.HasOne(d => d.Product)
                    .WithMany(p => p.CartItems)
                    .HasForeignKey(d => d.ProductId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_CartItems_Products");
            });

            modelBuilder.Entity<Category>(entity =>
            {
                entity.HasIndex(e => e.Name, "IX_Categories")
                    .IsUnique();

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Name).HasMaxLength(50);
            });

            modelBuilder.Entity<Comment>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Content).HasMaxLength(500);

                entity.Property(e => e.PosterId).HasColumnName("PosterID");

                entity.Property(e => e.PublicationDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.RecipeId).HasColumnName("RecipeID");

                entity.Property(e => e.UpdateDate).HasColumnType("datetime");
            });

            modelBuilder.Entity<Coupon>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Description).HasMaxLength(500);

                entity.Property(e => e.DiscountRate).HasColumnType("decimal(18, 0)");

                entity.Property(e => e.DscountAmount).HasColumnType("decimal(18, 0)");

                entity.Property(e => e.Name).HasMaxLength(50);

                entity.Property(e => e.SellerId).HasColumnName("SellerID");

                entity.Property(e => e.Status).HasMaxLength(50);

                entity.Property(e => e.Threshold).HasColumnType("decimal(18, 0)");

                entity.Property(e => e.ValidSince).HasColumnType("datetime");

                entity.Property(e => e.ValidUntil).HasColumnType("datetime");
            });

            modelBuilder.Entity<CustomerReservation>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.MemberId).HasColumnName("MemberID");

                entity.Property(e => e.Notes).HasMaxLength(50);

                entity.Property(e => e.OrderDate).HasColumnType("datetime");

                entity.Property(e => e.OrderTime).HasColumnType("datetime");

                entity.Property(e => e.ReservationName).HasMaxLength(50);

                entity.Property(e => e.ReservationNumber).HasMaxLength(50);

                entity.Property(e => e.SellerId).HasColumnName("SellerID");
            });

            modelBuilder.Entity<LoginHistory>(entity =>
            {
                entity.ToTable("LoginHistory");

                entity.Property(e => e.Account).HasMaxLength(50);

                entity.Property(e => e.LoginDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");
            });

            modelBuilder.Entity<Member>(entity =>
            {
                entity.HasIndex(e => e.Account, "IX_Members")
                    .IsUnique();

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Account).HasMaxLength(50);

                entity.Property(e => e.Address).HasMaxLength(500);

                entity.Property(e => e.BirthDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.City).HasMaxLength(50);

                entity.Property(e => e.Country).HasMaxLength(50);

                entity.Property(e => e.District).HasMaxLength(50);

                entity.Property(e => e.Email).HasMaxLength(50);

                entity.Property(e => e.FirstName).HasMaxLength(50);

                entity.Property(e => e.Gender).HasMaxLength(50);

                entity.Property(e => e.IdentityNumber)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.InvoiceCarrier).HasMaxLength(50);

                entity.Property(e => e.LastName).HasMaxLength(50);

                entity.Property(e => e.Mobile).HasMaxLength(50);

                entity.Property(e => e.Notes).HasMaxLength(500);

                entity.Property(e => e.Password).HasMaxLength(50);

                entity.Property(e => e.Picture).HasMaxLength(500);

                entity.Property(e => e.SuspensionReason).HasMaxLength(50);

                entity.Property(e => e.Tel).HasMaxLength(50);

                entity.Property(e => e.Zip)
                    .HasMaxLength(50)
                    .HasColumnName("ZIP");
            });

            modelBuilder.Entity<MemberAddress>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.ContactName).HasMaxLength(50);

                entity.Property(e => e.ContactNumber).HasMaxLength(50);

                entity.Property(e => e.Country).HasMaxLength(50);

                entity.Property(e => e.InvoiceAddress).HasMaxLength(500);

                entity.Property(e => e.InvoiceZip)
                    .HasMaxLength(50)
                    .HasColumnName("InvoiceZIP");

                entity.Property(e => e.MemberId).HasColumnName("MemberID");

                entity.Property(e => e.Notes).HasMaxLength(500);

                entity.Property(e => e.ShipAddress).HasMaxLength(500);

                entity.Property(e => e.ShipZip)
                    .HasMaxLength(50)
                    .HasColumnName("ShipZIP");

                entity.HasOne(d => d.Member)
                    .WithMany(p => p.MemberAddresses)
                    .HasForeignKey(d => d.MemberId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_MemberAddresses_Members");
            });

            modelBuilder.Entity<Order>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.CompletionDate).HasColumnType("datetime");

                entity.Property(e => e.ContactNumber).HasMaxLength(50);

                entity.Property(e => e.FirstName).HasMaxLength(50);

                entity.Property(e => e.InvoiceAddress).HasMaxLength(500);

                entity.Property(e => e.InvoiceZip)
                    .HasMaxLength(50)
                    .HasColumnName("InvoiceZIP");

                entity.Property(e => e.LastName).HasMaxLength(50);

                entity.Property(e => e.MemberId).HasColumnName("MemberID");

                entity.Property(e => e.Notes).HasMaxLength(500);

                entity.Property(e => e.OrderDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.OrderStatus)
                    .HasMaxLength(50)
                    .HasDefaultValueSql("(N'''未出貨')");

                entity.Property(e => e.PaymentMethod).HasMaxLength(50);

                entity.Property(e => e.SellerId).HasColumnName("SellerID");

                entity.Property(e => e.ShipAddress).HasMaxLength(500);

                entity.Property(e => e.ShipVia).HasMaxLength(50);

                entity.Property(e => e.ShipZip)
                    .HasMaxLength(50)
                    .HasColumnName("ShipZIP");

                entity.Property(e => e.ShippingFee).HasColumnType("decimal(18, 0)");

                entity.Property(e => e.TotalPrice).HasColumnType("decimal(18, 0)");

                entity.HasOne(d => d.Member)
                    .WithMany(p => p.Orders)
                    .HasForeignKey(d => d.MemberId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Orders_Members");

                entity.HasOne(d => d.Seller)
                    .WithMany(p => p.Orders)
                    .HasForeignKey(d => d.SellerId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Orders_Sellers");
            });

            modelBuilder.Entity<OrderDetail>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Discount).HasColumnType("decimal(18, 0)");

                entity.Property(e => e.OrderId).HasColumnName("OrderID");

                entity.Property(e => e.ProductId).HasColumnName("ProductID");

                entity.Property(e => e.Subtotal).HasColumnType("decimal(18, 0)");

                entity.Property(e => e.UnitPrice).HasColumnType("decimal(18, 0)");

                entity.HasOne(d => d.Order)
                    .WithMany(p => p.OrderDetails)
                    .HasForeignKey(d => d.OrderId)
                    .HasConstraintName("FK_OrderDetails_Orders");

                entity.HasOne(d => d.Product)
                    .WithMany(p => p.OrderDetails)
                    .HasForeignKey(d => d.ProductId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_OrderDetails_Products");
            });

            modelBuilder.Entity<Post>(entity =>
            {
                entity.Property(e => e.PostId).HasColumnName("PostID");

                entity.Property(e => e.CreatedAt).HasColumnType("datetime");

                entity.Property(e => e.TContent).HasColumnName("tContent");

                entity.Property(e => e.Title).HasMaxLength(50);

                entity.Property(e => e.UpdateAt).HasColumnType("datetime");

                entity.Property(e => e.UserId)
                    .HasMaxLength(50)
                    .HasColumnName("UserID");
            });

            modelBuilder.Entity<PostText>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("PostText");

                entity.Property(e => e.CreatedAt).HasColumnType("datetime");

                entity.Property(e => e.PostId).HasColumnName("PostID");

                entity.Property(e => e.PostText1).HasColumnName("PostText");

                entity.Property(e => e.TContent).HasColumnName("tContent");

                entity.Property(e => e.UpdatedAt).HasColumnType("datetime");

                entity.Property(e => e.UserId)
                    .HasMaxLength(50)
                    .HasColumnName("UserID");

                entity.HasOne(d => d.Post)
                    .WithMany()
                    .HasForeignKey(d => d.PostId)
                    .HasConstraintName("FK_PostText_Posts");
            });

            modelBuilder.Entity<Product>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.CategoryId).HasColumnName("CategoryID");

                entity.Property(e => e.Description).HasMaxLength(4000);

                entity.Property(e => e.LastModified)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.ProductFlavor).HasMaxLength(50);

                entity.Property(e => e.ProductName).HasMaxLength(500);

                entity.Property(e => e.ProductSize).HasMaxLength(50);

                entity.Property(e => e.ProductUnit).HasMaxLength(50);

                entity.Property(e => e.SellerId).HasColumnName("SellerID");

                entity.Property(e => e.UnitPrice).HasColumnType("decimal(18, 0)");

                entity.Property(e => e.UploadDate).HasColumnType("datetime");

                entity.HasOne(d => d.Category)
                    .WithMany(p => p.Products)
                    .HasForeignKey(d => d.CategoryId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Products_Categories");

                entity.HasOne(d => d.Seller)
                    .WithMany(p => p.Products)
                    .HasForeignKey(d => d.SellerId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Products_Sellers");
            });

            modelBuilder.Entity<ProductFlavor>(entity =>
            {
                entity.HasIndex(e => e.FlavorName, "IX_Specs")
                    .IsUnique();

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.FlavorName)
                    .HasMaxLength(50)
                    .HasDefaultValueSql("(N'無')");

                entity.Property(e => e.ProductId).HasColumnName("ProductID");
            });

            modelBuilder.Entity<ProductSize>(entity =>
            {
                entity.HasIndex(e => e.SizeName, "IX_Sizes")
                    .IsUnique();

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.ProductId).HasColumnName("ProductID");

                entity.Property(e => e.SizeName)
                    .HasMaxLength(50)
                    .HasDefaultValueSql("(N'無')");
            });

            modelBuilder.Entity<Recipe>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Content).HasMaxLength(500);

                entity.Property(e => e.PosterId).HasColumnName("PosterID");

                entity.Property(e => e.PublicationDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.UpdateDate).HasColumnType("datetime");
            });

            modelBuilder.Entity<Reply>(entity =>
            {
                entity.ToTable("Reply");

                entity.Property(e => e.CreatedAt).HasColumnType("datetime");

                entity.Property(e => e.TContent)
                    .HasMaxLength(50)
                    .HasColumnName("tContent");

                entity.Property(e => e.UpdatedAt).HasColumnType("datetime");

                entity.Property(e => e.UserId).HasMaxLength(50);

                entity.HasOne(d => d.Post)
                    .WithMany(p => p.Replies)
                    .HasForeignKey(d => d.PostId)
                    .HasConstraintName("FK_Reply_Posts");
            });

            modelBuilder.Entity<Report>(entity =>
            {
                entity.ToTable("Report");

                entity.Property(e => e.Reportcategory).HasMaxLength(50);

                entity.Property(e => e.Reporter).HasMaxLength(50);
            });

            modelBuilder.Entity<Seller>(entity =>
            {
                entity.HasIndex(e => e.Id, "IX_Sellers")
                    .IsUnique();

                entity.HasIndex(e => e.Account, "IX_Sellers_1");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Account).HasMaxLength(50);

                entity.Property(e => e.Address).HasMaxLength(500);

                entity.Property(e => e.Bank).HasMaxLength(50);

                entity.Property(e => e.BankAccount).HasMaxLength(50);

                entity.Property(e => e.BankBranch).HasMaxLength(50);

                entity.Property(e => e.BankName).HasMaxLength(50);

                entity.Property(e => e.BirthDate).HasColumnType("datetime");

                entity.Property(e => e.ContactNumber).HasMaxLength(50);

                entity.Property(e => e.Description).HasMaxLength(4000);

                entity.Property(e => e.Email).HasMaxLength(500);

                entity.Property(e => e.EmailStatus).HasDefaultValueSql("((0))");

                entity.Property(e => e.EmailToken).HasMaxLength(500);

                entity.Property(e => e.FirstName).HasMaxLength(50);

                entity.Property(e => e.IdentityNumber).HasMaxLength(50);

                entity.Property(e => e.LastLogin)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.LastName).HasMaxLength(50);

                entity.Property(e => e.Password).HasMaxLength(50);

                entity.Property(e => e.Picture).HasMaxLength(500);

                entity.Property(e => e.RegisterDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.StoreName).HasMaxLength(50);

                entity.Property(e => e.SuspensionReason).HasMaxLength(50);
            });

            modelBuilder.Entity<Suspension>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Date)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.MemberId).HasColumnName("MemberID");

                entity.Property(e => e.Notes).HasMaxLength(500);

                entity.Property(e => e.SuspensionType).HasMaxLength(50);

                entity.HasOne(d => d.Member)
                    .WithMany(p => p.Suspensions)
                    .HasForeignKey(d => d.MemberId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Suspensions_Members");
            });

            modelBuilder.Entity<TablesForReservation>(entity =>
            {
                entity.ToTable("TablesForReservation");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Notes).HasMaxLength(50);

                entity.Property(e => e.OrderDate).HasColumnType("datetime");

                entity.Property(e => e.OrderTime).HasColumnType("datetime");

                entity.Property(e => e.SellerId).HasColumnName("SellerID");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
