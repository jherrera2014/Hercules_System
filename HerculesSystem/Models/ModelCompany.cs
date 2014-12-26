namespace Hercules.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class ModelCompany : DbContext
    {
        public ModelCompany()
            : base("name=DefaultConnection")
        {
        }

    }
}
