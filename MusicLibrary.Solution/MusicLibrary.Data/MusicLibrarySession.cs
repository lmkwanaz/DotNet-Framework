using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using ICM.JHB.Utility.NHibernate;
using MusicLibrary.Data.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicLibrary.Data
{
    public class MusicLibrarySession : NSessionService
    {
        protected override void SetSession()
        {
            if (_factory == null)
            {
                _factory = Fluently.Configure()
                    .Database(MsSqlConfiguration.MsSql2008.ConnectionString(c => c.FromConnectionStringWithKey("MusicLibrary")))
                    .Mappings(m =>
                    {
                        m.FluentMappings.AddFromAssemblyOf<Library>();
                    })
                    .BuildSessionFactory();
            }
        }
    }
}
