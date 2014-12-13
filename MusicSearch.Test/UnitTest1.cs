using System;
using System.Linq;
using System.Xml.Linq;
using System.Xml.XPath;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MusicSearch.Core.Data;
using MusicSearch.Core.Data.Schema;

namespace MusicSearch.Test
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
           var doc = XDocument.Load(@"Songs\ondagokaraoke.xml");
           var songs = (from i in doc.Descendants("plist").Descendants("dict").Descendants("array").Descendants("dict").Descendants("array").Descendants("dict")  //doc.XPathEvaluate("plist/dict/array/dict/array/dict")
                        select i ).ToList();

            var sessionFactory = SessionFactory.CreateSessionFactory();

            var session = sessionFactory.OpenSession();

            foreach (var song in songs)
           {
                Music music = new Music();
               music.Type = "Karaoke";

               foreach (var x in song.Nodes())
               {
                   if (((XElement)x).Value == "name")
                   {
                     var name = (x.NextNode as XElement).Value;
                     music.Name = name;
                   }

                   if (((XElement)x).Value == "albm")
                   {
                       var album = (x.NextNode as XElement).Value;
                       music.Album = album;
                   }

                   if (((XElement)x).Value == "arts")
                   {
                       var artist = (x.NextNode as XElement).Value;
                       music.Artist = artist;
                   }
               }

               session.Save(music);
              
           }

            int d = songs.Count;

        }
    }
}
