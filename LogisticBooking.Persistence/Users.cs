using System;
using System.Collections.Generic;

namespace LogisticBooking.API
{
    public partial class Users
    {
        public Users()
        {
            Claims = new HashSet<Claims>();
            UserLogins = new HashSet<UserLogins>();
        }

        public string SubjectId { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public bool IsActive { get; set; }

        public virtual ICollection<Claims> Claims { get; set; }
        public virtual ICollection<UserLogins> UserLogins { get; set; }
    }
}
