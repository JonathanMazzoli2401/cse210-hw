public class Word
{
    private readonly string _text;
    private bool _isHidden;

    public Word(string text)
    {
        _text = text;
        _isHidden = false;
    }

    public bool IsHidden() => _isHidden;

    public void Hide() => _isHidden = true;

    public string GetDisplayText()
    {
        if(!_isHidden) return _text;

        int letters = 0;
        foreach (char c in _text)
            if (char.IsLetter(c)) letters++;
        
        return new string('_', letters > 0 ? letters : _text.Length);
    }
}