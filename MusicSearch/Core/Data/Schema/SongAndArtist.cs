using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MusicSearch.Core.Data.Schema
{
    public class SongAndArtist
    {
        public virtual string Artist { get; set; }

        public virtual string Name { get; set; }
        public virtual int MusicId { get; set; }
    }
}