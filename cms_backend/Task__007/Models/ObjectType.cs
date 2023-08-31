using System;
using System.Collections.Generic;

namespace Task__007.Models;

public partial class ObjectType
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public int? ParentId { get; set; }

    public virtual ICollection<Address> Addresses { get; set; } = new List<Address>();

    public virtual ICollection<Hotel> Hotels { get; set; } = new List<Hotel>();

    public virtual ICollection<Object> Objects { get; set; } = new List<Object>();
}
