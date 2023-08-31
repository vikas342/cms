using System;
using System.Collections.Generic;

namespace Task__007.Models;

public partial class Role
{
    public int Rid { get; set; }

    public string Role1 { get; set; } = null!;

    public virtual ICollection<User> Users { get; set; } = new List<User>();
}
