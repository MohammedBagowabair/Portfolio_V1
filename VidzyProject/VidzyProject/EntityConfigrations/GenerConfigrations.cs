using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity.ModelConfiguration;

namespace VidzyProject.EntityConfigrations
{
    public class GenerConfigrations:EntityTypeConfiguration<Genre>
    {
        public GenerConfigrations()
        {
            Property()
        }
    }
}
