#include "Functions.h"

int main()
{
    //Open the files
    ifstream infile;
    bool gameRunning = 1;
    int choice;
    string lifeWord = "HANGMAN";
    string word;
    string wordGuessed;
    string input_txt;
    char ch;


    while (gameRunning) {
        cout << "\n -> Select Game Difficulty:\n"<<"\t - eazy: \t1\n" << "\t - normal: \t2\n" << "\t - hard: \t3\n"<<"\t - exit: \t4\n";
        cout << "\n -> User Choice: \t";
        cin >> choice;
        switch (choice) {
        case 1:
            infile.open("words_eazy.txt");
            break;
        case 2:
            infile.open("words_normal.txt");
            break;
        case 3:
            infile.open("words_hard.txt");
            break;
        default:
            exit(0);
            break;
        }

        while (infile >> noskipws >> ch) {
            input_txt.push_back(ch);
        }

        word = GetOnlyUpperLettersText(PickRandomWord(input_txt));
        wordGuessed = GetHiddenWord(word);
        
        int life = 0;
        string alreadyTriedLetters;
        while (life <= lifeWord.size()) {
            if (life < lifeWord.size()) {
                //The user has some lifes left
                cout << "\n =====================================================\n";
                cout << "\n -> LIFE: \t\t";
                for (int i = 0; i < lifeWord.size(); i++) {
                    if (life > i) {
                        cout << lifeWord[i];
                    }
                    else {
                        cout << "_";
                    }
                }
                cout << "\n -> Guessed WORD: \t" << wordGuessed;
                cout << "\n -> Enter a letter: \t";
                cin >> ch;
                if (ch > 'Z') {
                    ch -= 32;
                }
                if (GetLetterFirstPos(ch, word) != -1) {
                    if (GetLetterFirstPos(ch, wordGuessed)==-1) {
                        wordGuessed = RevealLetters(ch, word, wordGuessed);
                        cout << "\n -> You found another letter.\n";
                    }
                    else {
                        cout << "\n -> You already found this letter. Choose another.\n";
                    }
                }
                else {
                    if (GetLetterFirstPos(ch, alreadyTriedLetters) == -1) {
                        alreadyTriedLetters.push_back(ch);
                        cout << "\n -> The word doesn't containt this letter.\n";
                        life += 1;
                    }
                    else {
                        cout << "\n ->  You already tried this letter. Choose another.\n";
                    }
                }
                if (WordFound(word, wordGuessed)) {
                    //the user won
                    cout << "\n =====================================================\n";
                    cout << "\n \t-> YOU WON <-\n";
                    cout << "\n -> THE WORD WAS: " << word << "\n -> YOU GUESSED:  " << wordGuessed;
                    cout << "\n\n -> Press a Letter and Enter to continue... ;)";
                    cin >> ch;
                    life = lifeWord.size()+1;
                    cout << "\n =====================================================\n";
                }
            }
            else {
                //The user lost
                cout << "\n =====================================================\n";
                cout << "\n -> LIFE: "<<lifeWord;
                cout << "\n\n \t-> YOU LOST <- \n";
                cout << "\n -> THE WORD WAS: " << word << "\n -> YOU GUESSED:  " << wordGuessed;
                cout << "\n\n -> Press a Letter and Enter to continue... ;)";
                cin >> ch;
                life += 1;
                cout << "\n =====================================================\n";
            }
        }
    }

    infile.close();
}