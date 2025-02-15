using System;

class Words
{
    public Words(string word) {
        _word = word;
    }
    private string _word;
    private bool _hidden;

    public void Display() {
        if (_hidden == false) {
            Console.Write(_word + " ");
        } else {
            Console.Write(new string('_', _word.Length) + " ");
        }
    }
    public bool Hidden() {
        return _hidden;
    }
    public void Hide() {
        _hidden = true;
    }
    public void Show() {
        _hidden = false;
    }
}