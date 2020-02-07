using System;
using System.Collections.Generic;

namespace SKDH.AssociationManagment.DataAccess.Models
{
    public partial class ExpenseType
    {
        public ExpenseType()
        {
            this.Expenses = new List<Expens>();
        }

        public int Id { get; set; }
        public string ExpenseTypeName { get; set; }
        public virtual ICollection<Expens> Expenses { get; set; }
    }
}
