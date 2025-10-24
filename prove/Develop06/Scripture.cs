public class Scripture
{
    // Member variables
    private List<Word> _scripture = [];
    private Reference _reference;

    // Constructor
    public Scripture(string[] scripture, string reference)
    {
        foreach (string word in scripture)
        {
            _scripture.Add(new Word(word));
        }

        string[] referenceArray = reference.Split(":");
        int lastSpace = referenceArray[0].LastIndexOf(" ");
        string book = referenceArray[0][..lastSpace];
        int chapter = int.Parse(referenceArray[0][lastSpace..]);
        int firstVerse;
        int lastVerse;

        if (referenceArray[1].Contains('-'))
        {
            string[] verses = referenceArray[1].Split('-');
            firstVerse = int.Parse(verses[0]);
            lastVerse = int.Parse(verses[1]);
        }
        else
        {
            firstVerse = int.Parse(referenceArray[1]);
            lastVerse = int.Parse(referenceArray[1]);
        }

        _reference = new Reference(book, chapter, firstVerse, lastVerse);
    }

    // Methods
    public void Display()
    {
        // Display Scripture?
        foreach(Word word in _scripture)
        {
            word.Display();
        }
    }

    public bool ChooseWordsToHide()
    {
        // Chooses which words to hide and calls Hide() function to do it
        Random r = new Random();

        for (int i = 0; i < 3; i++)
        {
            Word[] notHidden = [.. _scripture.Where(word => !word.IsHidden())];
            if (notHidden.Length == 0)
            {
                return false;
            }
            int rIndex = r.Next(notHidden.Count());

            notHidden[rIndex].Hide();
        }
        return true;
    }
       
}   