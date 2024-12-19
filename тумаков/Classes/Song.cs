using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace тумаков.Classes
{
    internal class Song
    {
        public string name { get; set; }
        public string author { get; set; }
        public Song previous { get; set; }
        // конструктор по умолчанию
        public Song()
        {
        }
        public Song(string name, string author)
        {
            this.name = name;
            this.author = author;
            this.previous = null; 
        }
        public Song(string name, string author, Song previousSong)
        {
            this.name = name;
            this.author = author;
            this.previous = previousSong; 
        }
        public void FillName(string name)
        {
            this.name = name;
        }
        public void FillAuthor(string author)
        {
            this.author = author;
        }
        public void FillPrevSong(Song prev)
        {
            this.previous = prev;
        }
        public string Title()
        {
            return $"{name} - {author}";
        }
        public override bool Equals(object d)
        {
            if (d is Song other)
            {
                return this.name == other.name && this.author == other.author;
            }
            return false;
        }
        public override int GetHashCode()
        {
            return (name, author).GetHashCode();
        }
    }
}
