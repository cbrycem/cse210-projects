using System;

class Reference
{
    public Reference() {

    }
    public Reference(string book, int chapter, int verse) {
        _book = book;
        _chapter = chapter;
        _verse = verse;
        _endverse = null;
    }
    public Reference(string book, int chapter, int verse, int endverse) {
        _book = book;
        _chapter = chapter;
        _verse = verse;
        _endverse = endverse;
    }
    private int _chapter;
    private int _verse;
    private int? _endverse;
    private string _book;

    public string Display() {
        if (_endverse.HasValue) {
            return $"{_book} {_chapter}:{_verse}-{_endverse}"; // Range format
        } else {
            return $"{_book} {_chapter}:{_verse}"; // Single verse format
        }
    }
}