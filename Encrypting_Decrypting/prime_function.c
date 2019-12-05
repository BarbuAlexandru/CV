/**
* @file prime_function.c
* @brief This file contains the function from the header file prime_function.h
* @author Barbu Mircea-Alexandru
* @date 05/06/2018
*/

#include <stdio.h>
#include <stdlib.h>

#include "prime_function.h"

/**     This function checks if a number is prime, and if it is, it returns
*   the value 1, and if it is not it returns the value 0
*/

int its_prime(int number){

    int prim=1;
    int i;

    if(number==0 || number==1)
        return 0;

    for(i=2; i<=number/2; i++)
        if(number%i==0)
            prim=0;

    return prim;
}
