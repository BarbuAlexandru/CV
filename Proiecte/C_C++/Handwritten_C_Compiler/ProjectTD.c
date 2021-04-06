#include "ast.h"
#include "c.tab.h"
#include "SemanticAnalyzer.h"
#include <stdio.h>
#include <errno.h>
#include <malloc.h>

extern FILE* yyin;
extern int yyparse(void);
extern int yylex(void);
extern int yydebug;
extern Node* astRoot;

int main()
{
    //yydebug = 1;
    yyin = fopen("input.csrc", "rt");

    //The SymTable
    SymTableNode* SymTableHead = NULL;

    if (yyin != NULL)
    {
        int result = yyparse();
        switch (result) {
        case 0:
            printf("\nParse successful\n");
            break;
        case 1:
            printf("\nInvalid input encountered\n");
            break;
        case 2:
            printf("\nOut of memory\n");
            break;
        default:
            break;
        }
        printf("\n\n The AST is: \n\n");
        printAst(astRoot, 0);

        printf("\n\n The Symbols Table is: \n\n");
        CreateSymTable(astRoot, 0, NULL, NULL, NULL, &SymTableHead);
        PrintSymTable(SymTableHead);


        if (SearchNodeSymTable(SymTableHead, "INT", NULL, "function2")) {
            printf("\nFound\n");
        }
        else {
            printf("\nNot Found\n");
        }

        fclose(yyin);
    }
    else
    {
        printf("The input file couldn't be opened. Error: %d", errno);
    }
}

