using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VidzyProject
{
    public class Genre
    {
        public byte Id { get; set; }
        public string Name { get; set; }
        public ICollection<Video> Videos { get; set; }

        public Genre()
        {
            Videos = new Collection<Video>();
        }
    }
}
