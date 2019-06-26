using System;
using System.Collections.Generic;

namespace LogisticBooking.API
{
    public partial class UserLogins
    {
        public string Id { get; set; }
        public string SubjectId { get; set; }
        public string LoginProvider { get; set; }
        public string ProviderKey { get; set; }

        public virtual Users Subject { get; set; }
    }
}
