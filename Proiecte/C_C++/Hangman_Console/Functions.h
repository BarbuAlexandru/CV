#include <iostream>
#include <fstream>
#include <vector>
#include <stdlib.h>
#include <time.h>
#include <limits>

using namespace std;


int CheckLetter(char letter);
string GetOnlyUpperLettersText(string txt);
string PickRandomWord(string txt);
string GetHiddenWord(string txt);
int GetLetterFirstPos(char ch, string txt);
string RevealLetters(char ch, string word, string wordGuessed);
bool WordFound(string word, string wordGuessed);