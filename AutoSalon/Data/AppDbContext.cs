using AutoSalon.Models.Cars.BMW;
using AutoSalon.Models.Cars.BYD;
using AutoSalon.Models.Cars.Chevrolet;
using AutoSalon.Models.Cars.MersedensBens;
using AutoSalon.Models.Cars.Toyoto;
using AutoSalon.Models.Companys.BMW;
using AutoSalon.Models.Companys.BYD;
using AutoSalon.Models.Companys.Chevrolet;
using AutoSalon.Models.Companys.MersedensBens;
using AutoSalon.Models.Companys.Toyoto;
using Microsoft.EntityFrameworkCore;

namespace AutoSalon.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options){}
        #region BMW
        public DbSet<BMWcars> BMWcars { get; set; }
        public DbSet<BMWTranslation> BMWTranslationCars { get; set; }
        public DbSet<BMWcompanys> BMWcompanys { get; set; }
        public DbSet<BMWTranslation> bMWTranslationCompany { get; set; }
        #endregion
        
        #region BYD
        public DbSet<BYDcars> BYDcars { get; set; }
        public DbSet<BYDTranslation> BYDtranslationCars { get; set; }
        public DbSet<BYDcompanys> BYDcompanys { get; set; }
        public DbSet<BYDTranslationCompany> BYDtranslationCompany { get; set; }
        #endregion

        #region CHEVROLET
        public DbSet<Chevroletcars> Chevroletcars { get; set; }
        public DbSet<ChevroletTranslation> ChevroletTranslationCars { get; set; }
        public DbSet<Chevroletcompanys> Chevroletcompanys { get; set; }
        public DbSet<ChevroletTranslationCompany> ChevroletTranslations { get; set; }
        #endregion

        #region MERS
        public DbSet<MersedensBenscars> MersedensBenscars { get; set; }
        public DbSet<MersTranslation> MersTranslationCars { get; set; }
        public DbSet<MersedensBenscompanys> MersedensBenscompanys { get; set; }
        public DbSet<MersTranslationCompany> MersTranslationCompany { get; set; }
        #endregion

        #region TOYOTO
        public DbSet<Toyotocars> Toyotocars { get;set; }
        public DbSet<ToyotoTranslation> ToyotoTranslationCars { get; set; }
        public DbSet<Toyotocompanys> Toyotocompanys { get; set; }
        public DbSet<ToyotoTranslationCompany> ToyotoTranslationCompany { get; set; }
        #endregion

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            #region BMW
            modelBuilder.Entity<BMWcompanys>()
                .HasMany(x => x.BMWcars)
                .WithOne(x => x.BMWcompanys)
                .HasForeignKey(x => x.CompanyId)
                .IsRequired();


            modelBuilder.Entity<BMWcars>()
                .HasMany(x => x.Translations)
                .WithOne(x => x.BMWcars)
                .HasForeignKey(X => X.bmwId)
                .IsRequired();
            #endregion

            #region BYD
            modelBuilder.Entity<BYDcompanys>()
                .HasMany(x => x.BYDcars)
                .WithOne(x => x.BYDcompanys)
                .HasForeignKey(x => x.CompanyId)
                .IsRequired();

            modelBuilder.Entity<BYDcars>()
                .HasMany(x => x.Translations)
                .WithOne(x => x.BYDcars)
                .HasForeignKey(x => x.bydId)
                .IsRequired();
            #endregion

            #region CHEVROLET
            modelBuilder.Entity<Chevroletcompanys>()
                .HasMany(x => x.Chevroletcars)
                .WithOne(x => x.Chevroletcompanys)
                .HasForeignKey(x => x.CompanyId)
                .IsRequired();


            modelBuilder.Entity<Chevroletcars>()
                .HasMany(x => x.Translations)
                .WithOne(x => x.Chevroletcars)
                .HasForeignKey(x => x.ChevroletId)
                .IsRequired();

            #endregion

            #region MERS
            modelBuilder.Entity<MersedensBenscompanys>()
                .HasMany(x => x.MersedensBenscars)
                .WithOne(x => x.MersedensBenscompanys)
                .HasForeignKey(x => x.CompanyId)
                .IsRequired();


            modelBuilder.Entity<MersedensBenscars>()
                .HasMany(x => x.Translations)
                .WithOne(x => x.MersedensBenscars)
                .HasForeignKey(x => x.MersId)
                .IsRequired();

            #endregion

            #region TOYOTO
            modelBuilder.Entity<Toyotocompanys>()
                .HasMany(x => x.Toyotocars)
                .WithOne(x => x.Toyotocompanys)
                .HasForeignKey(x => x.CompanyId)
                .IsRequired();

            modelBuilder.Entity<Toyotocars>()
                .HasMany(x => x.Translations)
                .WithOne(x => x.ToyotoCars)
                .HasForeignKey(x => x.ToyotoId)
                .IsRequired();
            #endregion
        }
    }
}
