
class Game
{
    private string phrase;

    // You can change the magic word if you want
    private const string magicWord = "PLAY";

    public Game(string inputPhrase)
    {
        // Store the phrase in uppercase so comparisons are easier later
        phrase = inputPhrase.ToUpper();
    }

    public string DisplayBlanks()
    {
        string result = "";

        // Go through each letter in the phrase
        foreach (char letter in phrase)
        {
            if (letter == ' ')
            {
                result += "  ";
            }
            else
            {
                result += "_ ";
            }
        }

        return result;
    }

    public string Play(char[] guessedLetters)
    {
        // Convert guesses to a string and uppercase
        string guesses = new string(guessedLetters).ToUpper();

        // Check if cheats are active
        bool timeCheat = ApplyTimeCheat(DateTime.Now, 2);
        bool easterEgg = ApplyEasterEggCheat(guesses);

        string result = "";

        // Split the phrase into words (so we can reveal whole words)
        string[] words = phrase.Split(' ');

        // Loop through each word
        for (int w = 0; w < words.Length; w++)
        {
            // Add space between words
            if (w > 0)
            {
                result += "  ";
            }

            // Time cheat: reveal every other word starting at 2nd word
            bool revealWholeWord = easterEgg || (timeCheat && w % 2 == 1);

            // Loop through each letter in the word
            foreach (char letter in words[w])
            {
                if (revealWholeWord)
                {
                    // Show entire word if cheat is active
                    result += letter + " ";
                }
                else if (guesses.Contains(letter))
                {
                    // Show guessed letters
                    result += letter + " ";
                }
                else
                {
                    // Otherwise hide letter
                    result += "_ ";
                }
            }
        }

        return result;
    }

    public bool IsValid(string guessedLetters)
    {
        if (guessedLetters.Length != 10)
        {
            return false;
        }

        if (guessedLetters.Contains(" "))
        {
            return false;
        }

        return true;
    }

    public bool ApplyTimeCheat(DateTime now, int divisibleByValue)
    {
        // Returns true if the current second is divisible by the value
        return now.Second % divisibleByValue == 0;
    }

    public bool ApplyEasterEggCheat(string guessedLetters)
    {
        // Returns true if the magic word is inside the guesses
        return guessedLetters.Contains(magicWord);
    }
}

