using System;
using System.Collections.Generic;

namespace Task__007.Models;

public partial class Speaker
{
    public int? Cid { get; set; }

    public string Name { get; set; } = null!;

    public string Image { get; set; } = null!;

    public DateTime? Intime { get; set; }

    public DateTime? Outtime { get; set; }

    public int Sid { get; set; }

    public virtual ConfDetail? CidNavigation { get; set; }
}
