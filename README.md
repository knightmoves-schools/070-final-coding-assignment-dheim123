# 070 Word Guessing Game
## Game Overview
Each time the player starts the game they have one opportunity to guess 10 letters and the matching letters will be revealed.  Each game round presents a new random phrase which the player has a single chance to guess.

## How to Run the Game
- Open a terminal window
  - [VSCode Instructions](https://code.visualstudio.com/docs/terminal/basics)
  - [Codespaces Instructions](https://code.visualstudio.com/docs/terminal/basics)
- Run the following command `dotnet run`
- You will be prompted to enter 10 letters and then press the enter button
- You will see the following results

```
@pairing4good ➜ /workspaces/km__c-sharp__final_coding_assignment__070 (main) $ dotnet run
Please enter 10 letters that you want revealed for: _ _ _ _  _ _ _ _  _ _ _ _  _ _ _  _ _ _ _
ABCDE
MAKE THIS WORK FOR REAL


================================
========= GAME RESULTS =========
================================
The hidden phrase was: Get A Grip On Yourself
```

## Small Commits
Small commits ensure that you save working code in Git so you can go back to a know working Game at any point.
1. Run `dotnet run`
2. Make a small coding change based on the rules below
3. Run `dotnet run` to determine if your change worked
4. If your coding change worked (even partially) then commit your code.
5. Repeat steps 1 through 4 until the Game satisfies all of the rules below

## Game Rules
_Make all of your changes in the Game.cs file_
- **Convert Phrase to Blanks**
  - Should use the `phrase` provided in the construtor to display blanks instead of letters when the `DisplayBlanks` method is called (example: "THIS IS AN EXAMPLE" would look like this `_ _ _ _  _ _  _ _  _ _ _ _ _ _ _`)
- **Show Results with Revealed Matching Letters**
  - Should return a string that reveals all of the letters that match when 10 letters are passed to the `Play` method
- **10 Letter Guess Validation**
  - Should return `false` from the `IsValid` method when more than 10 letters are provided
  - Should return `false` from the `IsValid` method when less than 10 letters are provided
  - Should return `false` from the `IsValid` method when the string `guessedLetters` contains spaces
  - Should return `true` from the `IsValid` method when the string `guessedLetters` is 10 letters without spaces
- **Game Play Method Logic**
  - Should return the `phrase` blanks with matching letters revealed from the `Play` method when `IsValid` returns `true` (example: when user guesses `ABCDEFGHIJ` for the phrase `YOU ARE THE BEST` then the `Play` method would return `_ _ _  A _ E  _ H E  B E _ _`)
- **Game Cheats**
  - Should implement the `ApplyTimeCheat` and `ApplyEasterEggCheat` methods within the `Game` class (these 2 methods exist in `/interfaces/Cheatable.cs`)
  - Should reveal all the correctly guessed letters and every other word starting at the second word when the `ApplyTimeCheat` determines that the second value within the `now` date time is evenly divisible by the `divisibleByValue` (example: if the `second` is 41, and the `divisibleByValue` is 2, when user guesses `ABCDEFGHIJ` for the phrase `YOU ARE THE BEST`, the `ApplyTimeCheat` returns `false` and the `Play` method would just return `_ _ _  A _ E  _ H E  B E _ _`. But if the `second` is 42, and the `divisibleByValue` is 2, `ApplyTimeCheat` returns `true` and the `Play` method would return would return `_ _ _  A R E  _ H E  B E S T`, revealing every other word starting at the second word)
  - Should reveal all the letters no matter what is guessed if the `magicWord` is contained within the `guessedLetters` passed to the `Play` method. You may determine what the `magicWord` will be. (example: if the magic word is `play` when user guesses `ABCDEFGHIJ` for the phrase `YOU ARE THE BEST`, the `ApplyEasterEggCheat` returns `false` then the `Play` method would return `_ _ _  A _ E  _ H E  B E _ _` but if the user guesses`PLAYBCDEFG` `ApplyEasterEggCheat` returns `true` and it would reveal the entire phrase `Y O U  A R E  T H E  B E S T`)

## Next Steps
**Once you complete the game please:**
1. Set up a time for a 2 hour Pairing Assessment with your classroom guide.

**During the Pairing Assessment you will:**
1. Demonstrate your working code to your classroom guide.
2. Explain your code to your classroom guide (`Game.cs`)
3. Make 6 live changes to your code with your classroom guide.

Copyright &copy; 2023 Knight Moves. All Rights Reserved.

