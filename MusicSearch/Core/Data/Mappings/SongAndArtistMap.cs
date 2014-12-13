using FluentNHibernate.Mapping;
using Microsoft.Owin.Mapping;
using MusicSearch.Core.Data.Schema;

namespace MusicSearch.Core.Data.Mappings
{
    public class SongAndArtistMap : ClassMap<SongAndArtist>
    {
        public SongAndArtistMap()
        {
            Id(s => s.MusicId);
            //Map(x => x.Album);
            Map(x => x.Artist);
            Map(x => x.Name);
            //Map(x => x.Type);
            //Map(x => x.Year);
            Table("Music");
        }
    }
}