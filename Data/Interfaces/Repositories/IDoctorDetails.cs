using Data.Domain;
using Domain.Interfaces.Base;
using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Data.Base
{
    public interface IDoctorDetails : IType
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public int DoctorDetailId { get; set; }
        public DoctorDetail DoctorDetail { get; set; }
    }
}
