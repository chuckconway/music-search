using FluentNHibernate.Mapping;
using Microsoft.Owin.Mapping;
using MusicSearch.Core.Data.Schema;

namespace MusicSearch.Core.Data.Mappings
{
    public class MusicMap : ClassMap<Music>
    {
        public MusicMap()
        {
            Id(s => s.MusicId).GeneratedBy.Identity();
            Map(x => x.Album);
            Map(x => x.Artist);
            Map(x => x.Name);
            Map(x => x.Type);
            Map(x => x.Year);
        }
    }
}