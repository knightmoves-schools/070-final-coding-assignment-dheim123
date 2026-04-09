using System;

namespace knightmoves;
interface Cheatable 
{
  // Do not change this file
  bool ApplyTimeCheat(DateTime now, int divisibleByValue);
  bool ApplyEasterEggCheat(string magicWord);
}