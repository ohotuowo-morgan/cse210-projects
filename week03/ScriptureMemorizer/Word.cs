public class Word
{
    private string _text;
    private bool _isHidden;

    public Word (string word)
    {
        _text = word;
        _isHidden = false;
    }

    public void Hide()
    {
        _isHidden = true;
    }

    public bool IsHidden()
    {
        return _isHidden;
    }

    public string GetDisplayText()
    {
        if (!_isHidden)
        {
            return _text;
        }else
        {
            int length = _text.Length;
            return new string ('_', length);
        }
    }
}