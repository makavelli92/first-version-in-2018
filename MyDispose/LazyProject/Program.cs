using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LazyProject
{
    class Song
    {
        public string Artist { get; set; }
        public string TrackName { get; set; }

        public Song(string artist, string track)
        {
            Artist = artist;
            TrackName = track;
        }
    }
    class Albom
    {
        private Song[] albom = new Song[20000];
    }
    class MediaPleer
    {
        private Lazy<Albom> allSong = new Lazy<Albom>();

        public Albom GetAllTracks()
        {
            return allSong.Value;
        }
        public void Play()
        {
            Console.WriteLine("Play");
        }
        public void Stop()
        {
            Console.WriteLine("Stop");
        }
    }
    
    class Program
    {
        static void Main(string[] args)
        {
            MediaPleer pleer = new MediaPleer();
            pleer.Play();

            Console.ReadLine();

        }
    }
}
