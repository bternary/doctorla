using Data.Domain;
using Data.Mapping;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace Data
{
    public class DataContext : DbContext
    {
        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    //optionsBuilder.UseSqlServer("Server=85.95.242.240,1435;Database=DoctorlaStage;User Id=sa;Password=Ec2jKDGJKa45;MultipleActiveResultSets=true");
        //    //Canlı Db --------
        //    //optionsBuilder.UseSqlServer("Server=94.73.145.8;Database=u9374834_db519;User Id=u9374834_user519;Password=BZlw52E7PXmk56H;MultipleActiveResultSets=true");

        //    // Test Db --------
        //    //optionsBuilder.UseSqlServer("Server=94.73.148.5;Database=u9374834_testdb;User Id=u9374834_testusr;Password=PIel33V9OFoo04Q;MultipleActiveResultSets=true");
        //}

        public DataContext()
        {
        }
        public DataContext(DbContextOptions options) : base(options)
        {
        }
        public DbSet<UserType> UserType { get; set; }
        public DbSet<User> User { get; set; }
        public DbSet<RelUserDepartment> RelUserDepartment { get; set; }
        public DbSet<Department> Department { get; set; }
        public DbSet<RoleGroup> RoleGroup { get; set; }
        public DbSet<Referance> Referance { get; set; }
        public DbSet<Menu> Menu { get; set; }
        public DbSet<MenuType> MenuType { get; set; }
        public DbSet<Country> Country { get; set; }
        public DbSet<City> City { get; set; }
        public DbSet<County> County { get; set; }
        public DbSet<Address> Address { get; set; }
        public DbSet<AddressType> AddressType { get; set; }
        public DbSet<Contact> Contact { get; set; }
        public DbSet<Sick> Sick { get; set; }
        public DbSet<Appointment> Appointment { get; set; }
        public DbSet<AppointmentFiles> AppointmentFiles { get; set; }
        public DbSet<AppointmentProcess> AppointmentProcess { get; set; }
        public DbSet<UserDetail> UserDetail { get; set; }
        public DbSet<DoctorDetail> DoctorDetail { get; set; }
        public DbSet<DoctorExperiences> DoctorExperiences { get; set; }
        public DbSet<DoctorMedicalInterests> DoctorMedicalInterests { get; set; }
        public DbSet<DoctorScientificMembership> DoctorScientificMembership { get; set; }
        public DbSet<DoctorEducations> DoctorEducations { get; set; }
        public DbSet<Donations> Donations { get; set; }
        public DbSet<NotifyTokens> NotifyTokens { get; set; }
        public DbSet<NotifyWarning> NotifyWarning { get; set; }
        public DbSet<Logs> Logs { get; set; }
        public DbSet<DailyCheck> DailyCheck { get; set; }
        public DbSet<DailyCheckDetail> DailyCheckDetail { get; set; }
        public DbSet<DailyCheckDetailValues> DailyCheckDetailValues { get; set; }
        public DbSet<DailyCheckPackages> DailyCheckPackages { get; set; }
        public DbSet<DailyCheckPackagesValues> DailyCheckPackagesValues { get; set; }
        public DbSet<PaymentProcess> PaymentProcess { get; set; }
        public DbSet<PackageChat> PackageChat { get; set; }
        public DbSet<DailyCheckAlerts> DailyCheckAlerts { get; set; }
        public DbSet<Slider> Slider { get; set; }
        public DbSet<Posts> Posts { get; set; }
        public DbSet<Blog> Blog { get; set; }
        public DbSet<Package> Package { get; set; }
        public DbSet<PackageDetail> PackageDetail { get; set; }
        public DbSet<PackageOffers> PackageOffers { get; set; }
        public DbSet<RelPackageDetail> RelPackageDetail { get; set; }
        public DbSet<Campaign> Campaign { get; set; }
        public DbSet<UsedCampaign> UsedCampaign { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema("dbo");
            modelBuilder.ApplyConfiguration(new DailyCheckDetailValuesMapping());
            modelBuilder.ApplyConfiguration(new UserTypeMapping());
            modelBuilder.ApplyConfiguration(new UserMapping());
            modelBuilder.ApplyConfiguration(new RelUserDepartmentMapping());
            modelBuilder.ApplyConfiguration(new ReferanceMapping());
            modelBuilder.ApplyConfiguration(new MenuTypeMapping());
            modelBuilder.ApplyConfiguration(new MenuMapping());
            modelBuilder.ApplyConfiguration(new CountryMapping());
            modelBuilder.ApplyConfiguration(new CityMapping());
            modelBuilder.ApplyConfiguration(new CountyMapping());
            modelBuilder.ApplyConfiguration(new AddressTypeMapping());
            modelBuilder.ApplyConfiguration(new AddressMapping());
            modelBuilder.ApplyConfiguration(new AppointmentMapping());
            modelBuilder.ApplyConfiguration(new AppointmentProcessMapping());
            modelBuilder.ApplyConfiguration(new AppointmentFilesMapping());
            modelBuilder.ApplyConfiguration(new SickMapping());
            modelBuilder.ApplyConfiguration(new UserDetailMapping());
            modelBuilder.ApplyConfiguration(new DoctorDetailMapping());
            modelBuilder.ApplyConfiguration(new DoctorEducationsMapping());
            modelBuilder.ApplyConfiguration(new DoctorExperiencesMapping());
            modelBuilder.ApplyConfiguration(new DoctorScientificMembershipMapping());
            modelBuilder.ApplyConfiguration(new DepartmentMapping());
            modelBuilder.ApplyConfiguration(new RoleGroupMapping());
            modelBuilder.ApplyConfiguration(new NotifyTokensMapping());
            modelBuilder.ApplyConfiguration(new NotifyWarningMapping());
            modelBuilder.ApplyConfiguration(new DailyCheckMapping());
            modelBuilder.ApplyConfiguration(new DailyCheckDetailMapping());
            modelBuilder.ApplyConfiguration(new DailyCheckDetailValuesMapping());
            modelBuilder.ApplyConfiguration(new DailyCheckPackagesMapping());
            modelBuilder.ApplyConfiguration(new DailyCheckPackagesValuesMapping());
            modelBuilder.ApplyConfiguration(new PaymentProcessMapping());
            modelBuilder.ApplyConfiguration(new DailyCheckAlertsMapping());
            modelBuilder.ApplyConfiguration(new SliderMapping());
            modelBuilder.ApplyConfiguration(new PostsMapping());
            modelBuilder.ApplyConfiguration(new BlogMapping());
            modelBuilder.ApplyConfiguration(new PackageMapping());
            modelBuilder.ApplyConfiguration(new PackageDetailMapping());
            modelBuilder.ApplyConfiguration(new PackageOffersMapping());
            modelBuilder.ApplyConfiguration(new RelPackageDetailMapping());
            modelBuilder.ApplyConfiguration(new CampaignMapping());
            modelBuilder.ApplyConfiguration(new UsedCampaignMapping());
        }
    }
}
