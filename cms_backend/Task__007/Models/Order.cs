using System;
using System.Collections.Generic;

namespace Task__007.Models;

public partial class Order
{
    public int Oid { get; set; }

    public int? Uid { get; set; }

    public int? Cid { get; set; }

    public int? Hid { get; set; }

    public DateTime? BookedDate { get; set; }

    public virtual ConfDetail? CidNavigation { get; set; }

    public virtual Hotel? HidNavigation { get; set; }

    public virtual User? UidNavigation { get; set; }
}
