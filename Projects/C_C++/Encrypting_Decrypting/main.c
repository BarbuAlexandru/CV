/**
* @file main.c
* @brief This file is the main file, which calls the rest of the files.
* @author Barbu Mircea-Alexandru
* @date 05/06/2018
*/


#include <stdio.h>
#include <stdlib.h>
#include <time.h>
#include <string.h>

#include "encryption_functions.h"
#include "decryption_functions.h"

int main(){
    srand(time(NULL));

    char normal_text[1000]="";
    char encrypted_text[1000]="";
    char decrypted_text[1000]="";

    printf("Enter the text that will be encrypted: ");
    gets(normal_text);

    strcpy(encrypted_text, text_encryption(normal_text));
    printf("\nThe encrypted text is:\n%s\n", encrypted_text);

    strcpy(decrypted_text, text_decryption(encrypted_text));
    printf("\nThe decrypted text is:\n%s\n", decrypted_text);

    printf("\nPress Enter to exit.\n");
    getchar();

    return 0;
}
