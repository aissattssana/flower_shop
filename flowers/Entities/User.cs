using System;
using System.Collections.Generic;

namespace flowers
{

    public partial class User
    {
        public long IdUser { get; set; }

        public string Login { get; set; } = null!;

        public string Password { get; set; } = null!;

        public string Role { get; set; } = null!;

        public string Name { get; set; } = null!;

        public string SecondName { get; set; } = null!;

        public string Phone { get; set; } = null!;

        public string Mail { get; set; } = null!;

        public string Address { get; set; } = null!;

        public byte[]? Photo { get; set; }

        public virtual ICollection<Client> Clients { get; } = new List<Client>();

        public virtual ICollection<Manager> Managers { get; } = new List<Manager>();
    }
}
