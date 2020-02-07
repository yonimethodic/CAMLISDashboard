using System;
using System.Collections.Generic;
using System.Security.Principal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

using CHAI.LISDashboard.Enums;
using CHAI.LISDashboard.CoreDomain;

namespace CHAI.LISDashboard.CoreDomain.Setting
{
    public partial class Facility:IEntity
    {
        public int Id { get; set; }
        public string FacilityName { get; set; }
        public string FacilityCode { get; set; }
        public Nullable<int> ProvinceId { get; set; }
        public Nullable<int> FacilityTypeId { get; set; }
        public Nullable<int> ReferalFacilityId { get; set; }
        public virtual LLG LLG { get; set; }
        public Nullable<int> LaboratoryId { get; set; }
        public string SMSPhoneNumber { get; set; }
        public string Email { get; set; }
        public string VLEmail { get; set; }
        public Nullable<bool> FacilityStatus { get; set; }
        public Nullable<int> ReferalProvinceId { get; set; }
        public Nullable<int> DonorID { get; set; }
        public string FacilityARTCode { get; set; }
        public string VLSMSNumber { get; set; }
        public string FacilityType2 { get; set; }
        public string FacilityType3 { get; set; }
    }
}
