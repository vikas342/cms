using System;
using System.Collections.Generic;

namespace Task__007.Models;

public partial class Object
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public int? Typeid { get; set; }

    public virtual ICollection<Address> Addresses { get; set; } = new List<Address>();

    public virtual ICollection<Hotel> Hotels { get; set; } = new List<Hotel>();

    public virtual ObjectType? Type { get; set; }
}
