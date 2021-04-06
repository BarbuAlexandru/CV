#include "SemanticAnalyzer.h"
#include <malloc.h>
#include <string.h>

void PrintSymTable(SymTableNode* SymTableHead) {
	int index = 1;
	SymTableNode* auxNode = SymTableHead;
	if (auxNode != NULL) {
		while (auxNode->next != NULL) {
			SymTableEntry* auxEntry = auxNode->entry;
			printf(" - VarDeclaration %d -- DataType: %s -- SymbolName: %s -- ContextName: %s\n",
				index, auxEntry->dataType, auxEntry->symbolName, auxEntry->contextName);
			auxNode = auxNode->next;
			index += 1;
		}
		SymTableEntry* auxEntry = auxNode->entry;
		printf(" - VarDeclaration %d -- DataType: %s -- SymbolName: %s -- ContextName: %s\n",
			index, auxEntry->dataType, auxEntry->symbolName, auxEntry->contextName);
	}
	else {
		printf("The SymTable is Empty!");
	}
}

SymTableNode* SearchNodeSymTable(SymTableNode* SymTableHead, char* dataType, char* symbolName, char* contextName) {
	SymTableNode* auxNode = SymTableHead;
	if (auxNode != NULL) {
		while (auxNode->next != NULL) {
			SymTableEntry* auxEntry = auxNode->entry;
			int found = 1;
			if (dataType!=NULL) {
				if (strcmp(dataType, auxEntry->dataType) != 0) {
					found = 0;
				}
			}
			if (symbolName != NULL) {
				if (strcmp(symbolName, auxEntry->symbolName) != 0) {
					found = 0;
				}
			}
			if (contextName != NULL) {
				if (strcmp(contextName, auxEntry->contextName) != 0) {
					found = 0;
				}
			}
			if (found == 1) {
				return auxNode;
			}
			auxNode = auxNode->next;
		}
		SymTableEntry* auxEntry = auxNode->entry;
		int found = 1;
		if (dataType != NULL) {
			if (strcmp(dataType, auxEntry->dataType) != 0) {
				found = 0;
			}
		}
		if (symbolName != NULL) {
			if (strcmp(symbolName, auxEntry->symbolName) != 0) {
				found = 0;
			}
		}
		if (contextName != NULL) {
			if (strcmp(contextName, auxEntry->contextName) != 0) {
				found = 0;
			}
		}
		if (found == 1) {
			return auxNode;
		}
		auxNode = auxNode->next;
	}
	else {
		printf("The SymTable is Empty!");
	}
	return NULL;
}

void AddEntryToSymTable(SymTableNode** SymTableHead, char* dataType, char* symbolName, char* contextName) {
	//Create the new node
	SymTableEntry* newEntry = (SymTableEntry*)malloc(sizeof(SymTableEntry));
	strcpy(newEntry->dataType, dataType);
	strcpy(newEntry->symbolName, symbolName);
	if (contextName != NULL) {
		strcpy(newEntry->contextName, contextName);
		newEntry->symbolScope = Local;
	}
	else {
		strcpy(newEntry->contextName, "No Context");
		newEntry->symbolScope = Global;
	}
	SymTableNode* newNode = (SymTableNode*)malloc(sizeof(SymTableNode));
	newNode->entry = newEntry;
	newNode->next = NULL;

	//Add it to the list
	if (*SymTableHead == NULL) {
		*SymTableHead = (SymTableNode*)malloc(sizeof(SymTableNode));
		*SymTableHead = newNode;
	}
	else {
		SymTableNode* auxNode = *SymTableHead;
		while(auxNode->next != NULL) {
			auxNode = auxNode->next;
		}
		auxNode->next = newNode;
	}
}

void CreateSymTable(Node* ast, int level, char* dataType, char* symbolName, char* contextName, SymTableNode** SymTableHead) {
	int idx = 0;

	if (ast)
	{
		//Get the context of the variable
		if (strcmp(ast->type,"FunctionDefinition") == 0) {
			contextName = ast->links[1]->links[0]->links[0]->extraData;
		}

		//Get the type of the variable
		if ((strcmp(ast->type, "Declaration") == 0) || (strcmp(ast->type, "ParameterDeclaration") == 0))
		{
			if (ast->links[0]->numLinks > 1) {
				dataType = ast->links[0]->links[ast->links[0]->numLinks - 1]->links[0]->extraData;
				for (idx = ast->links[0]->numLinks - 2; idx >= 0; idx--) {
					strcat(dataType, " ");
					strcat(dataType, ast->links[0]->links[idx]->links[0]->extraData);
				}
			}
			else {
				dataType = ast->links[0]->links[0]->links[0]->extraData;
			}
		}

		//Check if we are into a declaration of a variable
		if (dataType != NULL) {
			//Get the name of the variable
			if (strcmp(ast->type, "Identifier") == 0) {
				symbolName = ast->extraData;
			}
		}

		//If the variable has all the info, add it to the SymTable
		if (dataType!=NULL && symbolName!=NULL) {
			//printf("--HELLOOOO--%s--%s--%s\n", contextName, dataType, symbolName);
			//Add the Entry to the SymTable
			if (SearchNodeSymTable(*SymTableHead, NULL, symbolName, contextName) != NULL) {
				printf("ERROR: The variable was already declared in this context.");
				exit(0);
			}
			AddEntryToSymTable(SymTableHead, dataType, symbolName, contextName);
		}

		for (idx = 0; idx < ast->numLinks; idx++)
		{
			CreateSymTable(ast->links[idx], level + 1, dataType, symbolName, contextName, SymTableHead);
		}
	}
}