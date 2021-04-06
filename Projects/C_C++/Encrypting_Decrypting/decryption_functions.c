/**
* @file decryption_functions.c
* @brief This file contains the functions from the header file decryption_functions.h
* @author Barbu Mircea-Alexandru
* @date 05/06/2018
*/

#include <stdio.h>
#include <stdlib.h>
#include <string.h>

#include "decryption_functions.h"
#include "prime_function.h"

/**     This function will decrypt a word given by argument. Every letter of the word
*   will be counted and if a letter is in prime number sets, then it will be added to
*   the decrypted word, if not, it will be ignored.
*/

char* word_decryption(char* word){
    char decrypted_word[1000]="";
    char letter = word[0];
    int nr_appearances=0;
    int i;

    for(i=0; i<=strlen(word); i++)
    {
        if(word[i]==letter){
            nr_appearances+=1;
        }else{
            if(its_prime(nr_appearances)==1)
                decrypted_word[strlen(decrypted_word)]=letter;

            nr_appearances=1;
            letter=word[i];
        }
    }

    word=decrypted_word;
    return word;
}

/**     This function break the text given by argument in words and then it gives every word
*   to the function word_decryption which returns the decrypted words which added to the decrypted
*   text by this function.
*/

char* text_decryption(char* text){
    char decrypted_text[1000]="";
    char separators[20]=" ,.;:!?-\0";
    char word[1000]="";
    int i;

    for(i=0; i<=strlen(text); i++)
    {
        if(strchr(separators, text[i]) != NULL)
        {
            word[strlen(word)]='\0';
            strcat(decrypted_text, word_decryption(word));
            decrypted_text[strlen(decrypted_text)]=text[i];
            memset(word,0,strlen(word));
        }else{
            word[strlen(word)]=text[i];
        }
    }

    text = decrypted_text;
    return text;
}
