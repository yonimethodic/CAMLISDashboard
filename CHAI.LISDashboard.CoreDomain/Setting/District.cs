using System;
using System.Collections.Generic;
using System.Security.Principal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

using CHAI.LISDashboard.Enums;
using CHAI.LISDashboard.CoreDomain;

namespace CHAI.LISDashboard.CoreDomain.Setting
{
    public partial class District : IEntity
    {
        public District()
        {
            this.LLGs = new List<LLG>();
        }
        public int Id { get; set; }
        public virtual Province Province { get; set; }
        public string DistrictName { get; set; }
        public string DistrictCode { get; set; }
        public string DistrictShortName { get; set; }
        public string Description { get; set; }
        public virtual IList<LLG> LLGs { get; set; }

        #region Township
        public LLG GetLLG(int Id)
        {
            foreach (LLG llg in LLGs)
            {
                if (llg.Id == Id)
                {
                    return llg;
                }
            }
            return null;
        }
        public void RemoveLLG(int Id)
        {
            foreach (LLG llg in LLGs)
            {
                if (llg.Id == Id)
                {
                    LLGs.Remove(llg);
                }
            }

        }
        #endregion
    }
}
