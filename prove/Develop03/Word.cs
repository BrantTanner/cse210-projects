using System.Reflection.Metadata;

public class Word
{
    // Member variables
    private string _word;
    private bool _hidden = false;

    // Constructors
    public Word(string word)
    {
        _word = word;
    }

    // Methods
    public void Hide()
    {
        // Hide words by replacing them with underscore
        _hidden = true;

    }
    
    public bool IsHidden()
    {
        return _hidden;
    }

    public void Display()
    {
        // Display word either as hidden or not
        if (_hidden)
        {
            int numberOfUnderscores = _word.Length;
            string underscore = new string('_', numberOfUnderscores);
            Console.Write(underscore + " ");
        }
        else
        {
           Console.Write(_word + " "); 
        }
        
    }
}