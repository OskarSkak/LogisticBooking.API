using System;
using System.Collections.Generic;

namespace LogisticBooking.API
{
    public partial class Claims
    {
        public string Id { get; set; }
        public string SubjectId { get; set; }
        public string ClaimType { get; set; }
        public string ClaimValue { get; set; }

        public virtual Users Subject { get; set; }
        
        public Claims(string claimType, string claimValue)
        {
            ClaimType = claimType;
            ClaimValue = claimValue;
        }
    }
}
