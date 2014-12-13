using System.Collections.Generic;
using System.Linq;
using MusicSearch.Core.Data.Schema;
using NHibernate;

namespace MusicSearch.Core.Data.Repositories
{
    public class SearchRepository
    {
        public List<SongAndArtist> Search(string term)
        {
            using (ISessionFactory factory = SessionFactory.CreateSessionFactory())
            {
                using (var session = factory.OpenSession())
                {

                   var matches = session.ProcedureList<object, SongAndArtist>("Music_SearchNameAndArtist", new { term });
                    return matches.ToList();

                }
            }
        }
    }
}