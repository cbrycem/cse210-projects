using System;

class Scripture
{
    public Scripture(string reference, string verse) {
        SplitString(reference);
        string[] versewords = verse.Split(' ');

        foreach (string j in versewords) {
            _words.Add(new Words(j));
        }
        
    }
    private List<Words> _words = new List<Words>();
    private Reference _reference;

    private void SplitString(string reference) {
        
        string[] parts = reference.Split(' ');
        string _book = parts[0];

        string[] chapterVerse = parts[1].Split(':');
        int _chapter = int.Parse(chapterVerse[0]);
        
        if (chapterVerse[1].Contains("-")) {
            string[] verses = chapterVerse[1].Split(':');
            int _verse = int.Parse(verses[0]);
            int _endverse = int.Parse(verses[1]);
            _reference = new Reference(_book, _chapter, _verse, _endverse);
        } else {
            int _verse = int.Parse(chapterVerse[1]);
            Reference _reference = new Reference(_book, _chapter, _verse);
        }


    }

    public void Display() {

        foreach (Words j in _words) {
            j.Display();
        }
    }
}