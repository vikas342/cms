using System;
using System.Collections.Generic;

namespace Task__007.Models;

public partial class Address
{
    public int AddId { get; set; }

    public string Buildingname { get; set; } = null!;

    public int? City { get; set; }

    public int? State { get; set; }

    public int Pincode { get; set; }

    public virtual Object? CityNavigation { get; set; }

    public virtual ICollection<ConfDetail> ConfDetails { get; set; } = new List<ConfDetail>();

    public virtual ObjectType? StateNavigation { get; set; }
}
