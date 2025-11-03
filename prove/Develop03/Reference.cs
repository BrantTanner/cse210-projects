public class Reference
{
    // Member variables
    private string _book;
    private int _chatper;
    private int _fverse;
    private int _lverse;

    // Constructors
    public Reference(string book, int chapter, int fverse, int lverse)
    {
        _book = book;
        _chatper = chapter;
        _fverse = fverse;
        _lverse = lverse;
    }

    // Methods
    public string GetReference()
    {
        // Display member variables for use and determine if it has Fv and Lv or just FV(set _lverse to 0)

        string reference = _book + " " + _chatper + ":" + _fverse;
        if (_fverse != _lverse)
        {
            reference += "-" + _lverse;
        }

        return reference;
    }
    // public void Display(reference)
    // {
    //     Console.Write(reference);
    // } 
}
   