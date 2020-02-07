using System;
using System.Collections.Generic;
using System.Security.Principal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

using CHAI.LISDashboard.Enums;
using CHAI.LISDashboard.CoreDomain;

namespace CHAI.LISDashboard.CoreDomain.Setting
{
    public partial class LLG:IEntity
    {
        public LLG()
        {
            this.Facilities = new List<Facility>();
        }
        public int Id { get; set; }
        public Nullable<int> ProvinceId { get; set; }
        public virtual District District { get; set; }
        public string LLGName { get; set; }
        public string LLGCode { get; set; }
        public string Description { get; set; }
        public virtual IList<Facility> Facilities { get; set; }

        #region Township
        public Facility GetFacility(int Id)
        {
            foreach (Facility facility in Facilities)
            {
                if (facility.Id == Id)
                {
                    return facility;
                }
            }
            return null;
        }
        public void RemoveFacility(int Id)
        {
            foreach (Facility facility in Facilities)
            {
                if (facility.Id == Id)
                {
                    Facilities.Remove(facility);
                }
            }

        }
        #endregion
    }
}
