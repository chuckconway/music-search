using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MusicSearch.Core.Data.Schema
{
    public class Music
    {
        public virtual int MusicId { get; set; }

        public virtual string Artist { get; set; }

        public virtual string Name { get; set; }
        
        public virtual string Album { get; set; }

        public virtual string Year { get; set; }

        public virtual string Type { get; set; }

    }
}