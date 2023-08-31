using System;
using System.Collections.Generic;

namespace Task__007.Models;

public partial class User
{
    public int Uid { get; set; }

    public string Uname { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string Password { get; set; } = null!;

    public int? Role { get; set; }

    public virtual ICollection<Order> Orders { get; set; } = new List<Order>();

    public virtual Role? RoleNavigation { get; set; }
}
