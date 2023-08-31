using System;
using System.Collections.Generic;

namespace Task__007.Models;

public partial class ConfDetail
{
    public int Cid { get; set; }

    public string Title { get; set; } = null!;

    public int? Cadd { get; set; }

    public string Food { get; set; } = null!;

    public DateTime Date { get; set; }

    public string? Image { get; set; }

    public int status { get; set; } = 6;


    public virtual Address? CaddNavigation { get; set; }

    public virtual ICollection<Hotel> Hotels { get; set; } = new List<Hotel>();

    public virtual ICollection<Order> Orders { get; set; } = new List<Order>();

    public virtual ICollection<Speaker> Speakers { get; set; } = new List<Speaker>();
}
