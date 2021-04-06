/**
* @file random_functions.c
* @brief This file contains the functions from the header file random_functions.h
* @author Barbu Mircea-Alexandru
* @date 05/06/2018
*/

#include <stdio.h>
#include <stdlib.h>
#include <time.h>
#include <string.h>

#include "random_functions.h"
#include "prime_function.h"

/**     This functions generates a random number, if the argument nr_kind is 0,
*   the function will generate a non-prime number, if the argument nr_kind is 1,
*   the function will generate a prime number, and if the argument is not 1 nor 0,
*   the function will generate a random number, prime or not.
*/

int rand_nr_gen(int nr_max,int nr_kind){

    srand(rand());
    int generated_number;
    int prime_numbers[]={2,3,5,7,11,13,17,19,23,29,31,37,41,43,47,49};

    switch(nr_kind)
    {
        case 0:
            generated_number = (rand() % nr_max)+1;
            if(its_prime(generated_number)!=0)
                return rand_nr_gen(nr_max, nr_kind);
        break;

        case 1:
            generated_number = (rand() % 16);
            generated_number = prime_numbers[generated_number];
            if(generated_number>nr_max)
                return rand_nr_gen(nr_max, nr_kind);
        break;

        default:
            generated_number = (rand() % nr_max)+1;
        break;
    }

    return generated_number;
}

/**     This function will generate a random letter. if the argument letter_kind is
*   0, the function will generate a small letter, and if the argument is 1 will generate
*   an uppercase letter. If the argument letter_kind is not 1 nor 0, it will generate
*   a random letter, lowercase or uppercase.
*/

char rand_letter_gen(int letter_kind, char exception_1, char exception_2){

    char letter;

    letter = rand_nr_gen(26, -1) + 64;

    if(letter_kind==0)
        letter+=32;

    if(letter_kind!=0 && letter_kind!=1)
    {
        letter_kind=rand_nr_gen(2,-1)-1;
        letter = rand_letter_gen(letter_kind, exception_1, exception_2);
    }

    if(letter==exception_1 || letter==exception_2)
        return rand_letter_gen(letter_kind, exception_1, exception_2);

    return letter;
}
