class Game
{
    private string _phrase;
    private const string MagicWord = "PLAY";

    public Game(string phrase)
    {
        // Store the phrase in uppercase so comparisons are easier later
        _phrase = phrase.ToUpper();
    }

    public string DisplayBlanks()
    {
        // Split the phrase into individual words
        string[] words = _phrase.Split(' ');

        // Build the result word by word
        string result = "";
        for (int w = 0; w < words.Length; w++)
        {
            // Add a double space between words
            if (w > 0)
                result += "  ";

            // Replace each letter in the word with an underscore
            for (int i = 0; i < words[w].Length; i++)
            {
                if (i > 0)
                    result += " "; // single space between letters
                result += "_";
            }
        }

        return result;
    }

    public string Play(char[] guessedLetters)
    {
        // Convert guessed letters to uppercase for easy comparison
        string guessedStr = new string(guessedLetters).ToUpper();

        // Check if easter egg cheat is active (magic word "PLAY" is in the guess)
        bool easterEggActive = ApplyEasterEggCheat(guessedStr);

        // Check if the time cheat is active (current second is divisible by 2)
        bool timeCheatActive = ApplyTimeCheat(DateTime.Now, 2);

        // Split the phrase into words so we can handle word-by-word revealing
        string[] words = _phrase.Split(' ');

        string result = "";
        for (int w = 0; w < words.Length; w++)
        {
            // Add a double space between words
            if (w > 0)
                result += "  ";

            // Time cheat reveals every other word starting at the 2nd word (index 1, 3, 5...)
            bool revealWholeWord = easterEggActive || (timeCheatActive && w % 2 == 1);

            // Build each letter in the word
            for (int i = 0; i < words[w].Length; i++)
            {
                if (i > 0)
                    result += " "; // single space between letters

                char letter = words[w][i];

                // Show the letter if the whole word is revealed OR the letter was guessed
                if (revealWholeWord || guessedStr.Contains(letter))
                    result += letter;
                else
                    result += "_";
            }
        }

        return result;
    }

    public bool IsValid(string guessedLetters)
    {
        // Must be exactly 10 characters
        if (guessedLetters.Length != 10)
            return false;

        // Must not contain any spaces
        if (guessedLetters.Contains(' '))
            return false;

        return true;
    }

    public bool ApplyTimeCheat(DateTime now, int divisibleByValue)
    {
        // Returns true if the current second is evenly divisible by divisibleByValue
        return now.Second % divisibleByValue == 0;
    }

    public bool ApplyEasterEggCheat(string guessedLetters)
    {
        // Returns true if the secret magic word "PLAY" is found in the guessed letters
        return guessedLetters.ToUpper().Contains(MagicWord);
    }
}