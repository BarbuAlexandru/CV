#ifndef __SEMANTICANALYZER_H
#define __SEMANTICANALYZER_H

#include "ast.h"
#include<stdio.h>

#define MAX_SYMBOL_NAME 255
#define MAX_DATATYPE_NAME 255
#define MAX_DATA 255

enum IdentifierScope{ Local = 0, Global };

typedef struct symTableEntry {
	char dataType[MAX_DATATYPE_NAME];
	char symbolName[MAX_SYMBOL_NAME];
	enum IdentifierScope symbolScope;
	char contextName[MAX_SYMBOL_NAME];
}SymTableEntry;


typedef struct symTableNode {
	struct SymTableEntry* entry;
	struct SymTableNode* next;
}SymTableNode;


void PrintSymTable(SymTableNode* SymTableHead);

SymTableNode* SearchNodeSymTable(SymTableNode* SymTableHead, char* dataType, char* symbolName, char* contextName);

void AddEntryToSymTable(SymTableNode** SymTableHead, char* dataType, char* symbolName, char* contextName);

void CreateSymTable(Node* ast, int level, char* dataType, char* symbolName, char* contextName, SymTableNode** SymTableHead);

#endif