using ICM.JHB.Utility.Ninject;
using log4net;
using MusicLibrary.Data.Entity;
using MusicLibrary.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace MusicLibrary.WebAPI.Controllers
{
    public class MusicLibraryController : ApiController
    {
        protected readonly ILog _logger = Ninject_IOC.Container.Get<ILog>();
        protected IMusicDomain _domain = Ninject_IOC.Container.Get<IMusicDomain>();


        [Route("api/v1/Artist")]
        [HttpGet]
        public List<Library> GetArtists(int? artistID = null, string Artists = null)
        {
            try
            {
                _logger.Debug("Executing GetArtists");

                var artists = _domain.GetArtists(artistID, Artists);

                var count = (artists == null) ? 0 : artists.Count();

                _logger.Debug(string.Format("#End GetArtist. {0} results: ", count));

                return artists;
            }
            catch (Exception ex)
            {
                _logger.Error("Error on GetArtists.", ex);
                throw ex;
            }
        }

        [Route("api/v1/Artist")]
        [HttpPost]
        public void AddArtist([FromBody]Library artist)
        {
            try
            {
                _logger.Debug("Executing AddArtist");

                _domain.AddArtist(artist);

                _logger.Debug(string.Format("#End AddArtist."));
            }
            catch (Exception ex)
            {
                _logger.Error("Error on AddArtist.", ex);
                throw ex;
            }

        }


        [Route("api/v1/Artist/{id}")]
        [HttpPut]
        public void UpdateArtist([FromBody]Library artist)
        {
            try
            {
                _logger.Debug("Executing UpdateArtist");

                _domain.UpdateArtist(artist);

                _logger.Debug(string.Format("#End UpdateArtist."));

            }
            catch (Exception ex)
            {
                _logger.Error("Error on UpdateArtist.", ex);
                throw ex;
            }

        }


        [Route("api/v1/Artist/{id}")]
        [HttpDelete]
        public void DeleteArtist(int id)
        {
            try
            {
                _logger.Debug("Executing DeleteArtist");

                _domain.DeleteArtist(id);

                _logger.Debug(string.Format("#End DeleteArtist."));

            }
            catch (Exception ex)
            {
                _logger.Error("Error on DeleteArtist.", ex);
                throw ex;
            }

        }
    }
}
