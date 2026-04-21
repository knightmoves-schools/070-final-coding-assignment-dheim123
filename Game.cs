class Game
{
    private string phrase;

    public Game(string inputPhrase)
    {
        // Store the phrase in uppercase so comparisons are easier later
        phrase = inputPhrase.ToUpper();
    }

    public string DisplayBlanks()
    {
        // This will hold the result we build and return
        string result = "";

        // Go through each letter in the phrase one at a time
        foreach (char letter in phrase)
        {
            // If the character is a space, keep spacing between words
            if (letter == ' ')
            {
                result += "  "; // double space between words
            }
            else
            {
                // Otherwise, show an underscore for each hidden letter
                result += "_ ";
            }
        }

        // Return the finished blank version of the phrase
        return result;
    }

    public string Play(char[] guessedLetters)
    {
        // Convert the char array into a string and make it uppercase
        // This makes it easier to compare letters later
        string guesses = new string(guessedLetters).ToUpper();

        // This will hold the result we build and return
        string result = "";

        // Go through each letter in the phrase
        foreach (char letter in phrase)
        {
            // If it's a space, keep it
            if (letter == ' ')
            {
                result += "  ";
            }
            // If the guessed letters contain this letter, reveal it
            else if (guesses.Contains(letter))
            {
                result += letter + " ";
            }
            else
            {
                // Otherwise, keep it hidden
                result += "_ ";
            }
        }

        // Return the updated phrase showing guessed letters
        return result;
    }

    public bool IsValid(string guessedLetters)
    {
        // Must be exactly 10 characters
        if (guessedLetters.Length != 10)
        {
            return false;
        }

        // Must not contain any spaces
        if (guessedLetters.Contains(" "))
        {
            return false;
        }

        // If both checks pass, the input is valid
        return true;
    }
}
