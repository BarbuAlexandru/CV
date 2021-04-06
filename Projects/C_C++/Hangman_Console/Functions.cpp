#include "Functions.h"

int CheckLetter(char letter) {
	// returns 1 if the letter is upper case
	// returns 0 if the letter is lower case
	// returns -1 if the symbol is not a letter
	if (letter >= 'A' && letter <= 'Z') {
		return 1;
	}
	if (letter >= 'a' && letter <= 'z') {
		return 0;
	}
	return -1;
}

string GetOnlyUpperLettersText(string txt) {
	//Return a string that contains ONLY the alphabetical characters of a text (Uppercased)
	string newTxt = txt;
	for (int i = 0; i < newTxt.size(); i++) {
		if ((newTxt[i] < 'A' || newTxt[i] > 'Z') && (newTxt[i] < 'a' || newTxt[i] > 'z'))
		{
			newTxt.erase(i, 1);
			i--;
		}
		else {
			if (newTxt[i] >= 'a' && newTxt[i] <= 'z') {
				newTxt[i] -= ('a' - 'A');
			}
		}
	}
	return newTxt;
}

string PickRandomWord(string txt) {
	srand(time(NULL));
	string word;
	vector<string> possibleWords;

	for (int i = 0; i < txt.size(); i++) {
		if (CheckLetter(txt[i]) != -1) {
			word.push_back(txt[i]);
		}
		if (CheckLetter(txt[i]) == -1 || i >= txt.size() - 1) {
			possibleWords.push_back(word);
			word.clear();
		}
	}
	return possibleWords[(rand()%possibleWords.size())];
}

string GetHiddenWord(string txt) {
	string newTxt;
	for (int i = 0; i < txt.size(); i++) {
		newTxt.push_back('_');
	}
	return newTxt;
}

int GetLetterFirstPos(char ch, string txt) {
	// if it founds the letter ch, it returns the first position
	// if not it returns -1
	for (int i = 0; i < txt.size(); i++) {
		if (ch == txt[i]) {
			return i;
		}
	}
	return -1;
}

string RevealLetters(char ch, string word, string wordGuessed) {
	string newTxt;
	for (int i = 0; i < word.size(); i++) {
		if (word[i] == ch) {
			newTxt.push_back(word[i]);
		}
		else {
			newTxt.push_back(wordGuessed[i]);
		}
	}
	return newTxt;
}

bool WordFound(string word, string wordGuessed) {
	for (int i = 0; i < word.size(); i++) {
		if (word[i] != wordGuessed[i]) {
			return false;
		}
	}
	return true;
}