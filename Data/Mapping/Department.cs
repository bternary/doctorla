using System;
using Data.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Data.Mapping
{
    class DepartmentMapping : IEntityTypeConfiguration<Department>
    {
        public void Configure(EntityTypeBuilder<Department> builder)
        {
            builder.ToTable("Department", "dbo");
            builder.HasKey(o => o.Id);
            builder.Property(o => o.Id).ValueGeneratedOnAdd();
            builder.Property(x => x.IDate).HasDefaultValue(DateTime.Now);
            builder.Property(x => x.IsDeleted).HasDefaultValue(false);
            builder.Property(x => x.IsActive).HasDefaultValue(true);
            builder.HasData(
               new Department() {Id=1, IsActive=true,IsDeleted=false, Name = "Alerji ve İmmünoloji",Image= "flaticon-protection" },
               new Department() {Id=2, IsActive=true,IsDeleted=false, Name = "Beyin ve Sinir Cerrahisi",Image= "flaticon-neurosurgery" },
               new Department() {Id=3, IsActive=true,IsDeleted=false, Name = "Cerrahi Onkoloji",Image= "flaticon-surgery-1" },
               new Department() {Id=4, IsActive=true,IsDeleted=false, Name = "Çocuk Cerrahisi", Image = "flaticon-baby" },
               new Department() {Id=5, IsActive=true,IsDeleted=false, Name = "Çocuk Gastroenterolojisi", Image = "flaticon-digestive-system" },
               new Department() {Id=6, IsActive=true,IsDeleted=false, Name = "Çocuk Hematolojisi", Image = "flaticon-blood-sample" },
               new Department() {Id=7, IsActive=true,IsDeleted=false, Name = "Çocuk Kardiyolojisi", Image = "flaticon-care" },
               new Department() {Id=8, IsActive=true,IsDeleted=false, Name = "Çocuk Psiyikatri", Image = "flaticon-babies" },
               new Department() {Id=9, IsActive=true,IsDeleted=false, Name = "Çocuk Romatolojisi", Image = "flaticon-x-ray" },
               new Department() {Id=10, IsActive=true,IsDeleted=false, Name = "Çocuk Sağlığı ve Hastalıkları", Image = "flaticon-baby-boy" },
               new Department() {Id=11, IsActive=true,IsDeleted=false, Name = "Çocuk Ürolojisi", Image = "flaticon-kidneys-1" },
               new Department() {Id=12, IsActive=true,IsDeleted=false, Name = "Dermatoloji", Image = "flaticon-dermatology" },
               new Department() {Id=13, IsActive=true,IsDeleted=false, Name = "Endokrinoloji", Image = "flaticon-adrenal-gland" },
               new Department() {Id=14, IsActive=true,IsDeleted=false, Name = "Enfeksiyon", Image = "flaticon-infected-lungs" },
               new Department() {Id=15, IsActive=true,IsDeleted=false, Name = "Fizik Tedavi ve Rehabilitasyon", Image = "flaticon-physical" },
               new Department() {Id=16, IsActive=true,IsDeleted=false, Name = "Genel Cerrahi", Image = "flaticon-medical-tools" },
               new Department() {Id=17, IsActive=true,IsDeleted=false, Name = "Göğüs Cerrahisi", Image = "flaticon-chest-pain" },
               new Department() {Id=18, IsActive=true,IsDeleted=false, Name = "Göğüs Hastalıkları", Image = "flaticon-lung" },
               new Department() {Id=19, IsActive=true,IsDeleted=false, Name = "Göz Hastalıkları", Image = "flaticon-eye" },
               new Department() {Id=21, IsActive=true,IsDeleted=false, Name = "Hematoloji", Image = "flaticon-test" },
               new Department() {Id=22, IsActive=true,IsDeleted=false, Name = "İç Hastalıkları", Image = "flaticon-stomach" },
               new Department() {Id=23, IsActive=true,IsDeleted=false, Name = "Jinekolojik Onkoloji", Image = "flaticon-gynecology" },
               new Department() {Id=24, IsActive=true,IsDeleted=false, Name = "Kadın Hastalıkları ve Doğum", Image = "flaticon-sexual-health" },
               new Department() {Id=25, IsActive=true,IsDeleted=false, Name = "Kalp ve Damar Cerrahisi", Image = "flaticon-heart-1" },
               new Department() {Id=26, IsActive=true,IsDeleted=false, Name = "Kardiyoloji", Image = "flaticon-cardiology" },
               new Department() {Id=27, IsActive=true,IsDeleted=false, Name = "Kulak Burun Boğaz", Image = "flaticon-kulakburunbugaz" },
               new Department() {Id=28, IsActive=true,IsDeleted=false, Name = "Nefroloji", Image = "flaticon-kidney" },
               new Department() {Id=29, IsActive=true,IsDeleted=false, Name = "Nöroloji", Image = "flaticon-neurology-1" },
               new Department() {Id=30, IsActive=true,IsDeleted=false, Name = "Ortopedi", Image = "flaticon-broken-arm" },
               new Department() {Id=31, IsActive=true,IsDeleted=false, Name = "Plastik Cerrahi", Image = "flaticon-surgery" },
               new Department() {Id=32, IsActive=true,IsDeleted=false, Name = "Psikiyatri", Image = "flaticon-mental-health-2" },
               new Department() {Id=33, IsActive=true,IsDeleted=false, Name = "Radyasyon Onkolojisi", Image = "flaticon-radiation" },
               new Department() {Id=34, IsActive=true,IsDeleted=false, Name = "Romatoloji", Image = "flaticon-joint-1" },
               new Department() {Id=35, IsActive=true,IsDeleted=false, Name = "Sigarayı Bıraktırma", Image = "flaticon-quit-smoking-1" },
               new Department() {Id=36, IsActive=true,IsDeleted=false, Name = "Tıbbi Onkoloji", Image = "flaticon-radiotherapy-1" },
               new Department() {Id=37, IsActive=true,IsDeleted=false, Name = "Üroloji", Image = "flaticon-uroloji" },
               new Department() {Id=38, IsActive =true,IsDeleted=false, Name = "Yanık Polikliniği", Image = "flaticon-burn" },
               new Department() { Id = 47, IsActive = true, IsDeleted = false, Name = "Beslenme ve Diyet", Image = "flaticon-nutrition" },
               new Department() { Id = 48, IsActive = true, IsDeleted = false, Name = "Doğum Koçu", Image = "flaticon-newborn-2" },
               new Department() { Id = 49, IsActive = true, IsDeleted = false, Name = "Emzirme Danışmanı", Image = "flaticon-breastfeeding" },
               new Department() { Id = 50, IsActive = true, IsDeleted = false, Name = "Odyoloji", Image = "flaticon-listening" },
               new Department() { Id = 51, IsActive = true, IsDeleted = false, Name = "Psikoterapi ", Image = "flaticon-inspiration" }
               );
        }
    }
}
