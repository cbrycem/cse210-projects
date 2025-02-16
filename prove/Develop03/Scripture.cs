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
    private Random rnd = new Random();

    private void HideWords() {
        List<int> _length = new List<int>();
        int i = 0;
        foreach (Words j in _words) {
            bool hidden = j.Hidden();
            if (hidden == false) {
                _length.Add(i);
            }
            i++;
        }

        if (_length.Count > 0) {
            int hideCount = Math.Min(3, _length.Count);
            for (int l = 0; l < hideCount; l++) {
                int blank = rnd.Next(_length.Count);
                _words[_length[blank]].Hide();
                _length.RemoveAt(blank);
            }
        }
    }
    private void ShowWords() {
        List<int> _length = new List<int>();
        int i = 0;
        foreach (Words j in _words) {
            bool hidden = j.Hidden();
            if (hidden == true) {
                _length.Add(i);
            }
            i++;
        }

        if (_length.Count > 0) {
            int showCount = Math.Min(3, _length.Count);
            for (int l = 0; l < showCount; l++) {
                int blank = rnd.Next(_length.Count);
                _words[_length[blank]].Show();
                _length.RemoveAt(blank);
            }
        }
    }
    private void SplitString(string reference) {
        
        string[] parts = reference.Split(' ');
        int _chapterindex = -1;

        for (int i = 0; i < parts.Length; i++) {
            if (parts[i].Contains(":")) {
                _chapterindex = i;
                break;
            }
        }

        if (_chapterindex == -1) {
            throw new Exception("Invalid reference format");
        }

        // Book name is everything before the chapter index
        string _book = string.Join(" ", parts.Take(_chapterindex));

        string[] chapterVerse = parts[_chapterindex].Split(':');
        int _chapter = int.Parse(chapterVerse[0]);
        
        if (chapterVerse[1].Contains("-")) {
            string[] verses = chapterVerse[1].Split('-');
            int _verse = int.Parse(verses[0]);
            int _endverse = int.Parse(verses[1]);
            _reference = new Reference(_book, _chapter, _verse, _endverse);
        } else {
            int _verse = int.Parse(chapterVerse[1]);
            _reference = new Reference(_book, _chapter, _verse);
        }


    }
    public string DisplayReference() {
        string _fullref = _reference.Display();
        return _fullref;
    }
    public void Display() {
        while(true) {
            Console.Clear();
            string _fullref = _reference.Display();
            Console.Write(_fullref + ": ");
            foreach (Words j in _words) {
                j.Display();
            }
            Console.WriteLine("");
            Console.WriteLine("Press enter to hide words, 1 to show words, and 0 to exit.");
            string hideexit = Console.ReadLine();
            int exit = 2;
            List<int> _length = new List<int>();
            int i = 0;
            foreach (Words j in _words) {
                bool hidden = j.Hidden();
                if (hidden == false) {
                    _length.Add(i);
                }
                i++;
            }
            if (_length.Count == 0) {
                foreach (Words j in _words) {
                    j.Show();
                }
                break;
            }
            try {
                exit = int.Parse(hideexit);
            } catch {}
            if (exit == 0) {
                foreach (Words j in _words) {
                    j.Show();
                }
                break;
            } else if (exit == 1) {
                ShowWords();
            } else {
                HideWords();
            }
        }
    }

    public string Save() {

        return string.Join(" ", _words.Select(w => w.ToString()));

    }
}