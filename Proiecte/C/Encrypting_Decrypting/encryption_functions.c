/**
* @file encryption_functions.c
* @brief This file contains the functions from the header encryption_functions.h
* @author Barbu Mircea-Alexandru
* @date 05/06/2018
*/


#include <stdio.h>
#include <stdlib.h>
#include <string.h>

#include "encryption_functions.h"
#include "random_functions.h"

/**     This Function takes every word given by the function text_encryption
*   and it adds the letters necessary to encrypt the given word.
*/

char* word_encryption(char* word){
    char encrypted_word[1000]="";
    char letter;
    int i, j, k;
    int nr_different_letters;
    int nr_same_letters;

    for(i=0; i<strlen(word); i++)
    {
        nr_same_letters = rand_nr_gen(6, 1);
        for(k=1; k<=nr_same_letters; k++)
            encrypted_word[strlen(encrypted_word)]=word[i];

        nr_different_letters = rand_nr_gen(2, -1);
        for(j=1; j<=nr_different_letters; j++)
        {
            nr_same_letters = rand_nr_gen(6, 0);
            letter=rand_letter_gen(-1, word[i], word[i+1]);
            for(k=1; k<=nr_same_letters; k++)
                encrypted_word[strlen(encrypted_word)]=letter;
        }
    }

    word=encrypted_word;
    return word;
}

/**     This Function break the text given in the argument into smaller
*   words which are then given to the function word_encryption to be encrypted.
*/

char* text_encryption(char* text){
    char encrypted_text[1000]="";
    char separators[20]=" ,.;:!?-\0";
    char word[1000]="";
    int i;

    for(i=0; i<=strlen(text); i++)
    {
        if(strchr(separators, text[i]) != NULL)
        {
            word[strlen(word)]='\0';
            strcat(encrypted_text, word_encryption(word));
            encrypted_text[strlen(encrypted_text)]=text[i];
            memset(word,0,strlen(word));
        }else{
            word[strlen(word)]=text[i];
        }
    }

    text = encrypted_text;
    return text;
}
