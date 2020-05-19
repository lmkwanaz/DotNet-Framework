using MusicLibrary.Data.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicLibrary.Domain
{
    public interface IMusicDomain
    {
        List<Library> GetArtists(int? artistID = null, string Artists = null);
        void DeleteArtist(int ArtistId);
        void UpdateArtist(Library Artist);
        void AddArtist(Library Artist);
    }
}
