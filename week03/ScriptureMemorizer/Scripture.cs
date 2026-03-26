using System;
using System.Collections.Generic;

public class Scripture 
{
    private Reference _reference;
    private List<Word> _words = new List<Word>();

    public Scripture(Reference reference, string text)
    {
        _reference = reference;
        string[] splitWords = text.Split(' ');

        foreach(string wordText in splitWords)
        {
            Word newWord = new Word(wordText);
            _words.Add(newWord);
        }
    }

    public void HideRandomWords(int numberToHide)
    {
        Random random = new Random();
        int hiddenCount = 0;

        List<Word> availableWords = _words.FindAll(w => !w.IsHidden());
        int actualToHide = Math.Min(numberToHide, availableWords.Count);

        while (hiddenCount < actualToHide)
        {
            int index = random.Next(_words.Count);
            if (!_words[index].IsHidden())
            {
                _words[index].Hide();
                hiddenCount++;
            }
        }
    }

    public string GetDisplayText()
    {
        string scriptureText = _reference.GetDisplayText() + " ";

        foreach (Word word in _words)
        {
            scriptureText += word.GetDisplayText() + " ";
        }

        return scriptureText.Trim();
    }

    public bool IsCompletelyHidden()
    {
        foreach (Word word in _words)
        {
            if (!word.IsHidden())
            {
                return false;
            }
        }
        return true;
    }
}