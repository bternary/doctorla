using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Interfaces.Base
{
    public interface IBaseEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        [DefaultValue(true)]
        public bool IsActive { get; set; }
        [Required]
        [DefaultValue(false)]
        public bool IsDeleted { get; set; }
        [Required]
        public DateTime IDate { get; set; }
        [Required]
        public int IUser { get; set; }
        public DateTime? UUDate { get; set; }
        public int? UUser { get; set; }
    }
}
