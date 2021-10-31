using Data.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace Data.Mapping
{
    public class DailyCheckPackagesValuesMapping : IEntityTypeConfiguration<DailyCheckPackagesValues>
    {
        public void Configure(EntityTypeBuilder<DailyCheckPackagesValues> builder)
        {
            builder.ToTable(nameof(DailyCheckPackagesValues), "dbo");
            builder.HasKey(o => o.Id);
            builder.Property(o => o.Id).ValueGeneratedOnAdd();
            builder.Property(o => o.MinValue).HasDefaultValue(0);
            builder.Property(o => o.MaxValue).HasDefaultValue(0);
            builder.HasData(
            new DailyCheckPackagesValues() { Id = 1, Name = "Kronik Tansiyon", MinValue=89, MaxValue=139, Icon= "flaticon-blood-pressure-meter" },
            new DailyCheckPackagesValues() { Id = 2, Name = "Tansiyon", MinValue=80, MaxValue=120, Icon= "flaticon-blood-pressure-gauge" },
            new DailyCheckPackagesValues() { Id = 3, Name = "Ateş", MinValue=35.5, MaxValue=37.5, Icon= "flaticon-fever" },
            new DailyCheckPackagesValues() { Id = 4, Name = "Açlık Şekeri", MinValue=70, MaxValue=100, Icon= "flaticon-diabetes-1" },
            new DailyCheckPackagesValues() { Id = 5, Name = "Tokluk Şekeri", MinValue=100, MaxValue=140, Icon= "flaticon-diabetes-1" },
            new DailyCheckPackagesValues() { Id = 6, Name = "Nabız", MinValue=60, MaxValue=100, Icon= "flaticon-heart-2" },
            new DailyCheckPackagesValues() { Id = 7, Name = "CRP", MinValue=0, MaxValue=0.8, Icon= "flaticon-heartbeat" },
            new DailyCheckPackagesValues() { Id = 8, Name = "Sedimantasyon", MinValue=0, MaxValue=20, Icon= "flaticon-heartbeat" },
            new DailyCheckPackagesValues() { Id = 9, Name = "Troponin", MinValue=0, MaxValue=0.04, Icon= "flaticon-heartbeat" },
            new DailyCheckPackagesValues() { Id = 10, Name = "BNP", MinValue=74, MaxValue=125, Icon= "flaticon-heartbeat" },
            new DailyCheckPackagesValues() { Id = 11, Name = "CK-MB", MinValue=0, MaxValue=25, Icon= "flaticon-heartbeat" },
            new DailyCheckPackagesValues() { Id = 12, Name = "D-Dimer", MinValue=0, MaxValue=500, Icon= "flaticon-heartbeat" },
            new DailyCheckPackagesValues() { Id = 13, Name = "Su Kullanımı", MinValue = 2, MaxValue=5, Icon= "flaticon-drinking-water" },
            new DailyCheckPackagesValues() { Id = 14, Name = "Vücut Kitle İndeksi", MinValue = 19, MaxValue=24.9, Icon= "flaticon-weighing-machine" },
            new DailyCheckPackagesValues() { Id = 15, Name = "Mental Durum", MinValue = 0, MaxValue=0, Icon= "flaticon-mental-health-2" },
            new DailyCheckPackagesValues() { Id = 16, Name = "Beta-HCG", MinValue = 0, MaxValue=10, Icon= "flaticon-heartbeat" },
            new DailyCheckPackagesValues() { Id = 17, Name = "İlaç Kullanımı", MinValue = 0, MaxValue= 0, Icon= "flaticon-drugs" },
            new DailyCheckPackagesValues() { Id = 18, Name = "WBC", MinValue = 4, MaxValue= 1000, Icon= "flaticon-heartbeat" },
            new DailyCheckPackagesValues() { Id = 19, Name = "MCV", MinValue = 77, MaxValue= 115, Icon= "flaticon-heartbeat" },
            new DailyCheckPackagesValues() { Id = 20, Name = "RBC", MinValue = 4, MaxValue= 52000, Icon= "flaticon-heartbeat" },
            new DailyCheckPackagesValues() { Id = 21, Name = "PLT (Trombosit)", MinValue = 100, MaxValue= 400000, Icon= "flaticon-heartbeat" },
            new DailyCheckPackagesValues() { Id = 22, Name = "LYMPH % (Lenfosit)", MinValue = 20, MaxValue= 40, Icon= "flaticon-heartbeat" },
            new DailyCheckPackagesValues() { Id = 23, Name = "Total Kolestrol", MinValue = 140, MaxValue= 200, Icon= "flaticon-blood-test-1" },
            new DailyCheckPackagesValues() { Id = 24, Name = "LDL", MinValue = 90, MaxValue= 125, Icon= "flaticon-heartbeat" },
            new DailyCheckPackagesValues() { Id = 25, Name = "HDL", MinValue = 35, MaxValue= 70, Icon= "flaticon-heartbeat" },
            new DailyCheckPackagesValues() { Id = 26, Name = "Trigliserit", MinValue = 40, MaxValue= 200, Icon= "flaticon-heartbeat" },
            new DailyCheckPackagesValues() { Id = 27, Name = "Ferritin", MinValue = 100, MaxValue= 291, Icon= "flaticon-heartbeat" },
            new DailyCheckPackagesValues() { Id = 28, Name = "Demir Bağlama Kapasitesi", MinValue = 120, MaxValue= 270, Icon= "flaticon-heartbeat" },
            new DailyCheckPackagesValues() { Id = 29, Name = "B12", MinValue = 211, MaxValue= 911, Icon= "flaticon-vitamins" },
            new DailyCheckPackagesValues() { Id = 30, Name = "Folat", MinValue = 3, MaxValue= 17, Icon= "flaticon-heartbeat" },
            new DailyCheckPackagesValues() { Id = 31, Name = "D Vit", MinValue = 21, MaxValue= 80, Icon= "flaticon-vitamins" },
            new DailyCheckPackagesValues() { Id = 32, Name = "Serbest t3", MinValue = 2.5, MaxValue= 3.9, Icon= "flaticon-heartbeat" },
            new DailyCheckPackagesValues() { Id = 33, Name = "Serbest t4", MinValue = 0.89, MaxValue= 1.76, Icon= "flaticon-heartbeat" },
            new DailyCheckPackagesValues() { Id = 34, Name = "TSH", MinValue = 0.35, MaxValue= 5.5, Icon= "flaticon-heartbeat" },
            new DailyCheckPackagesValues() { Id = 35, Name = "ALT", MinValue = 10, MaxValue= 49, Icon= "flaticon-heartbeat" },
            new DailyCheckPackagesValues() { Id = 36, Name = "AST", MinValue = 0, MaxValue= 36, Icon= "flaticon-heartbeat" },
            new DailyCheckPackagesValues() { Id = 37, Name = "BUN", MinValue = 9, MaxValue= 23, Icon= "flaticon-heartbeat" },
            new DailyCheckPackagesValues() { Id = 38, Name = "ÜRE", MinValue = 20, MaxValue= 50, Icon= "flaticon-heartbeat" },
            new DailyCheckPackagesValues() { Id = 39, Name = "Kreatin", MinValue = 0.5, MaxValue= 1.1, Icon= "flaticon-heartbeat" },
            new DailyCheckPackagesValues() { Id = 40, Name = "Total Bilirubin", MinValue = 0.3, MaxValue= 1.2, Icon= "flaticon-heartbeat" },
            new DailyCheckPackagesValues() { Id = 41, Name = "Direk Bilirubin", MinValue = 0, MaxValue= 0.3, Icon= "flaticon - heartbeat" },
            new DailyCheckPackagesValues() { Id = 42, Name = "Total Testosteron", MinValue = 14, MaxValue= 76, Icon= "flaticon-heartbeat" },
            new DailyCheckPackagesValues() { Id = 43, Name = "Prolaktin", MinValue = 28, MaxValue= 29.2, Icon= "flaticon-heartbeat" },
            new DailyCheckPackagesValues() { Id = 44, Name = "İnsülin", MinValue = 3, MaxValue= 25, Icon= "flaticon-insulin" },
            new DailyCheckPackagesValues() { Id = 45, Name = "WBC", MinValue = 4, MaxValue = 1000, Icon = "flaticon-heartbeat" },


            //Default Values


            new DailyCheckPackagesValues() { Id = 1000, Name = "Tansiyon", MinValue = 3, MaxValue= 25, Icon= "far fa-clipboard", IsDefault=true },
            new DailyCheckPackagesValues() { Id = 1001, Name = "Açlık Kan Şekeri", MinValue = 3, MaxValue= 25, Icon= "far fa-clipboard", IsDefault=true },
            new DailyCheckPackagesValues() { Id = 1002, Name = "Tokluk Kan Şekeri", MinValue = 3, MaxValue= 25, Icon= "far fa-clipboard", IsDefault=true },
            new DailyCheckPackagesValues() { Id = 1003, Name = "Vütuc Sıcaklığı", MinValue = 3, MaxValue= 25, Icon= "far fa-clipboard", IsDefault=true },
            new DailyCheckPackagesValues() { Id = 1004, Name = "Ağrı", MinValue = 3, MaxValue= 25, Icon= "far fa-clipboard", IsDefault=true },
            new DailyCheckPackagesValues() { Id = 1005, Name = "Mod", MinValue = 3, MaxValue= 25, Icon= "far fa-clipboard", IsDefault=true },
            new DailyCheckPackagesValues() { Id = 1006, Name = "Sıvı Dengesi", MinValue = 3, MaxValue= 25, Icon= "fas fa-file-upload", IsDefault = true },


            new DailyCheckPackagesValues() { Id = 1100, Name = "Hasta Notu", MinValue = 3, MaxValue= 25, Icon= "flaticon-medical-report-1", IsDefault=true },
            new DailyCheckPackagesValues() { Id = 1101, Name = "Hemşire Notu", MinValue = 3, MaxValue= 25, Icon= "flaticon-medical-report-1", IsDefault = true },
            new DailyCheckPackagesValues() { Id = 1102, Name = "Dosyalar", MinValue = 3, MaxValue= 25, Icon= "flaticon-file", IsDefault = true }


            );
        }
    }
}
