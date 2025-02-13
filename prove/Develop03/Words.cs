using System;

class Words
{
    public Words(string word) {
        _word = word;
    }
    private string _word;

    public void Display() {
        Console.Write(_word + " ");
    }
}