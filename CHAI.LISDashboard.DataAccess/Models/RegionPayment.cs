using System;
using System.Collections.Generic;

namespace SKDH.AssociationManagment.DataAccess.Models
{
    public partial class RegionPayment
    {
        public int Id { get; set; }
        public Nullable<int> Region_Id { get; set; }
        public Nullable<int> paymentSetting_Id { get; set; }
    }
}
