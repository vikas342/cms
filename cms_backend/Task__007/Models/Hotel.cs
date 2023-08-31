using System;
using System.Collections.Generic;

namespace Task__007.Models;

public partial class Hotel
{
    public int Hid { get; set; }

    public int Cid { get; set; }

    public string Hname { get; set; } = null!;

    public int? City { get; set; }

    public int? State { get; set; }

    public virtual ConfDetail? CidNavigation { get; set; }

    public virtual Object? CityNavigation { get; set; }

    public virtual ICollection<Order> Orders { get; set; } = new List<Order>();

    public virtual ObjectType? StateNavigation { get; set; }
}
