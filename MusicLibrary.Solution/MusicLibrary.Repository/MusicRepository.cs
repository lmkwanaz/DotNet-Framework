using log4net;
using MusicLibrary.Data;
using MusicLibrary.Data.Entity;
using NHibernate.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicLibrary.Repository
{
    public class MusicRepository : IMusicRepository
    {

        private readonly MusicLibrarySession _nhibernateSession;
        private static ILog _logger;

        public MusicRepository(ILog logger, MusicLibrarySession nhibernateSession)
        {
            _logger = logger;
            _nhibernateSession = nhibernateSession;
        }

        public List<Library> GetArtists(int? ArtistID, string Artist)
        {
            using (var session = _nhibernateSession.CreateSession())
            {
                try
                {
                    var query = session.QueryOver<Library>();

                    if (ArtistID != null)
                        query.Where(p => p.ArtistID == ArtistID);
                    if (Artist != null)
                        query.And(p => p.Artist == Artist);


                    return query.List<Library>()
                        .ToList();


                }
                catch (Exception ex)
                {
                    _logger.Error("Error on GetUsers", ex);
                    throw ex;
                }
            }
        }

        public void AddArtist(Library artist)
        {
            try
            {
                using (var session = _nhibernateSession.CreateSession())
                {
                    if (artist.Artist != null && !artist.Artist.Equals(""))
                    {
                        artist.Artist = artist.Artist;
                    }
                    else
                    {
                        throw new Exception(string.Format("Cannot save user without a valid username"));
                    }

                    session.Save(artist);
                    session.Flush();
                }
            }
            catch (Exception ex)
            {

                _logger.Error("Error on AddArtist", ex);
                throw ex;
            }
        }

        public void UpdateArtist(Library artist)
        {
            try
            {
                using (var session = _nhibernateSession.CreateSession())
                {
                    if (artist.ArtistID == 0)
                        throw new Exception("ID must have a value");

                    session.SaveOrUpdate(artist);
                    session.Flush();
                }
            }
            catch (Exception ex)
            {

                _logger.Error("Error on UpdateArtist", ex);
                throw ex;
            }
        }

        public void DeleteArtist(int artistID)
        {
            try
            {
                using (var session = _nhibernateSession.CreateSession())
                {
                    var user = session.Query<Library>().SingleOrDefault(p => p.ArtistID == artistID);

                    if (user == null)
                        throw new Exception(string.Format("Artist with ID {0} is not found", artistID));

                    session.Delete(user);
                    session.Flush();
                }
            }
            catch (Exception ex)
            {
                _logger.Error("Error on Delete", ex);
                throw ex;
            }
        }
    }
}
