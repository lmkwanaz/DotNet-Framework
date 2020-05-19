using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicLibrary.Data.Entity
{
    public class Library
    {
        public virtual int ArtistID { get; set; }
        public virtual string Artist { get; set; }
        public virtual string Title { get; set; }
        public virtual bool Active { get; set; }
    }
}
