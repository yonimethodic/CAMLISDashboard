
using System;
using System.Collections.Generic;

namespace CHAI.LISDashboard.CoreDomain.Admins
{
    public class PocModule : IEntity
    {
        public PocModule()
        {
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string FolderPath { get; set; }

    }

}
