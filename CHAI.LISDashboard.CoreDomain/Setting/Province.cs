using System;
using System.Collections.Generic;
using System.Security.Principal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

using CHAI.LISDashboard.Enums;
using CHAI.LISDashboard.CoreDomain;

namespace CHAI.LISDashboard.CoreDomain.Setting
{
    public partial class Province:IEntity
    {
        public Province()
        {
            this.Districts = new List<District>();
        }
        public int Id { get; set; }
        public string ProvinceName { get; set; }
        public string ProvinceCode { get; set; }
        public string ProvinceShortName { get; set; }
        public string ProvinceMapId { get; set; }
        public string Description { get; set; }
        
        public virtual IList<District> Districts { get; set; }

        #region District
        public District GetDistrict(int Id)
        {
            foreach (District d in Districts)
            {
                if (d.Id == Id)
                {
                    return d;
                }
            }
            return null;
        }
        public District GetDistrictByprovince(int provinceId)
        {
            foreach (District d in Districts)
            {
                if (d.Province.Id == provinceId)
                {
                    return d;
                }
            }
            return null;
        }
        public void RemoveDistrict(int Id)
        {
            foreach (District d in Districts)
            {
                if (d.Id == Id)
                {
                    Districts.Remove(d);
                }
            }

        }
        #endregion
    }
}
