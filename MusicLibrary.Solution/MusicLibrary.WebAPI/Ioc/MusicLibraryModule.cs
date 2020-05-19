using ICM.JHB.Utility.NHibernate;
using log4net;
using MusicLibrary.Data;
using MusicLibrary.Domain;
using MusicLibrary.Repository;
using Ninject.Core;
using Ninject.Core.Behavior;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Diagnostics;
using System.Linq;
using System.Web;


namespace MusicLibrary.WebAPI.Ioc
{
    public class MusicLibraryModule : StandardModule
    {
        private readonly ILog _logger;

        public MusicLibraryModule()
        {
            try
            {
                log4net.Config.XmlConfigurator.Configure(new System.IO.FileInfo(ConfigurationManager.AppSettings["Log4NetXMLDir"]));
                _logger = LogManager.GetLogger("MusicLibraryAPI");
                _logger.Debug("MusicLibraryAPI starting...");
            }
            catch (Exception ex)
            {
                EventLog.WriteEntry("MusicLibraryAPI", string.Format("Failed to initialize module. {0}", ex.ToString()), EventLogEntryType.Error);
            }
        }

        public override void Load()
        {
            Bind<INSessionService>().To<MusicLibrarySession>().Using<SingletonBehavior>();
            Bind<IMusicRepository>().To<MusicRepository>();
            Bind<IMusicDomain>().To<MusicDomain>();
            Bind<ILog>().ToConstant(_logger);
        }
    }
}