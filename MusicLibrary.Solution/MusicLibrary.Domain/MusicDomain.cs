using MusicLibrary.Data.Entity;
using MusicLibrary.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicLibrary.Domain
{
    public class MusicDomain : IMusicDomain
    {
        IMusicRepository _repository;

        public MusicDomain(IMusicRepository repository)
        {
            _repository = repository;
        }

        public List<Library> GetArtists(int? artistID = null, string Artists = null)
        {
            return _repository.GetArtists(artistID, Artists);
        }

        public void AddArtist(Library Artist)
        {
            _repository.AddArtist(Artist);
        }

        public void DeleteArtist(int ArtistId)
        {
            _repository.DeleteArtist(ArtistId);
        }

        public void UpdateArtist(Library Artist)
        {
            _repository.UpdateArtist(Artist);
        }
    }
}
