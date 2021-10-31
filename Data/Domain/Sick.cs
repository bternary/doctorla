using Domain.Interfaces.Base;
using System;
using System.Collections.Generic;

namespace Data.Domain
{
  public class Sick : IBaseEntity, IType
  {
    public int Id { get; set; }
    public bool IsActive { get; set; }
    public bool IsDeleted { get; set; }
    public DateTime IDate { get; set; }
    public int IUser { get; set; }
    public DateTime? UUDate { get; set; }
    public int? UUser { get; set; }
    public string Name { get; set; }
    public string DefaultName { get; set; }
    public ICollection<Appointment> Appointment { get; set; }

  }
}
