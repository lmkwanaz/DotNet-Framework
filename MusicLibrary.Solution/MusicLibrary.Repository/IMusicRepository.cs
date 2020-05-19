using MusicLibrary.Data.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicLibrary.Repository
{
    public interface IMusicRepository
    {
        List<Library> GetArtists(int? ArtistID, string Artist = null);
        void AddArtist(Library Artist);
        void UpdateArtist(Library Artist);
        void DeleteArtist(int ArtistID);
    }
}
