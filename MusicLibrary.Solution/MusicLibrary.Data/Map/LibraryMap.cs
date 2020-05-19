using FluentNHibernate.Mapping;
using MusicLibrary.Data.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicLibrary.Data.Map
{
    class LibraryMap : ClassMap<Library>
    {
        public LibraryMap()
        {
            Id(p => p.ArtistID);

            //References(x => x.Role)
            //    .Column("RoleID")
            //    .Not.LazyLoad();

            Map(p => p.Artist);
            Map(p => p.Title);
            Map(p => p.Active);
        }
    }
}
