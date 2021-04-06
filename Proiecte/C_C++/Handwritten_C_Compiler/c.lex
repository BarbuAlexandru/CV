D			[0-9]
L			[a-zA-Z_]
H			[a-fA-F0-9]
E			[Ee][+-]?{D}+
FS			(f|F|l|L)
IS			(u|U|l|L)*

%{
#include "ast.h"
#include <stdio.h>
#include "c.tab.h"

void count();
%}

%%
"/*"			{ comment(); }

"auto"			{ count(); return(AUTO); }
"break"			{ count(); return(BREAK); }
"case"			{ count(); return(CASE); }
"char"			{ count(); return(CHAR); }
"continue"		{ count(); return(CONTINUE); }
"const"			{ count(); return(CONST); }
"default"		{ count(); return(DEFAULT); }
"do"			{ count(); return(DO); }
"double"		{ count(); return(DOUBLE); }
"else"			{ count(); return(ELSE); }
"enum"			{ count(); return(ENUM); }
"extern"		{ count(); return(EXTERN); }
"float"			{ count(); return(FLOAT); }
"for"			{ count(); return(FOR); }
"goto"			{ count(); return(GOTO); }
"if"			{ count(); return(IF); }
"inline"		{ count(); return(INLINE); }
"int"			{ count(); return(INT); }
"long"			{ count(); return(LONG); }
"register"		{ count(); return(REGISTER); }
"restrict"		{ count(); return(RESTRICT); }
"return"		{ count(); return(RETURN); }
"signed"		{ count(); return(SIGNED); }
"sizeof"		{ count(); return(SIZEOF); }
"static"		{ count(); return(STATIC); }
"struct"		{ count(); return(STRUCT); }
"switch"		{ count(); return(SWITCH); }
"typedef"		{ count(); return(TYPEDEF); }
"union"			{ count(); return(UNION); }
"unsigned"		{ count(); return(UNSIGNED); }
"void"			{ count(); return(VOID); }
"volatile"		{ count(); return(VOLATILE); }
"while"			{ count(); return(WHILE); }
"short"			{ count(); return(SHORT); }
"type_name"		{ count(); return(TYPE_NAME); }
"_Bool"			{ count(); return(_BOOL); }
"_Complex"		{ count(); return(_COMPLEX); }
"_Imaginary"	{ count(); return(_IMAGINARY); }
"#include"		{ count(); return(HEADER); }
"#define"		{ count(); return(DEFINE); }

{L}({L}|{D})*			{ count(); yylval.strings = strdup(yytext); return(check_type()); }
0[xX]{H}+{IS}?			{ count(); yylval.strings = strdup(yytext); return(CONSTANT); }
0{D}+{IS}?				{ count(); yylval.strings = strdup(yytext); return(CONSTANT); }
{D}+{IS}?				{ count(); yylval.strings = strdup(yytext); return(CONSTANT); }
{L}?'(\\.|[^\\'])+'		{ count(); yylval.strings = strdup(yytext); return(CONSTANT); }
{D}+{E}{FS}?			{ count(); yylval.strings = strdup(yytext); return(CONSTANT); }
{D}*"."{D}+({E})?{FS}?	{ count(); yylval.strings = strdup(yytext); return(CONSTANT); }
{D}+"."{D}*({E})?{FS}?	{ count(); yylval.strings = strdup(yytext); return(CONSTANT); }
{L}?\"(\\.|[^\\"])*\"	{ count(); yylval.strings = strdup(yytext); return(STRING_LITERAL); }

"..."			{ count(); return(ELLIPSIS); }
">>="			{ count(); return(RIGHT_ASSIGN); }
"<<="			{ count(); return(LEFT_ASSIGN); }
"+="			{ count(); return(ADD_ASSIGN); }
"-="			{ count(); return(SUB_ASSIGN); }
"*="			{ count(); return(MUL_ASSIGN); }
"/="			{ count(); return(DIV_ASSIGN); }
"%="			{ count(); return(MOD_ASSIGN); }
"&="			{ count(); return(AND_ASSIGN); }
"^="			{ count(); return(XOR_ASSIGN); }
"|="			{ count(); return(OR_ASSIGN); }
">>"			{ count(); return(RIGHT_OP); }
"<<"			{ count(); return(LEFT_OP); }
"++"			{ count(); return(INC_OP); }
"--"			{ count(); return(DEC_OP); }
"->"			{ count(); return(PTR_OP); }
"&&"			{ count(); return(AND_OP); }
"||"			{ count(); return(OR_OP); }
"<="			{ count(); return(LE_OP); }
">="			{ count(); return(GE_OP); }
"=="			{ count(); return(EQ_OP); }
"!="			{ count(); return(NE_OP); }
";"				{ count(); return(END_OF_INSTRUCTION); }
"{"				{ count(); return(LEFT_BRACE); }
"}"				{ count(); return(RIGHT_BRACE); }
","				{ count(); return(COMMA); }
":"				{ count(); return(TWO_POINTS); }
"="				{ count(); return(ASSIGN); }
"("				{ count(); return(LEFT_PARANTH); }
")"				{ count(); return(RIGHT_PARANTH); }
"["				{ count(); return(LEFT_BRACKET); }
"]"				{ count(); return(RIGHT_BRACKET); }
"."				{ count(); return(POINT); }
"&"				{ count(); return(AND); }
"!"				{ count(); return(NOT); }
"~"				{ count(); return(INV); }
"-"				{ count(); return(SUB); }
"+"				{ count(); return(ADD); }
"*"				{ count(); return(MUL); }
"/"				{ count(); return(DIV); }
"%"				{ count(); return(MOD); }
"<"				{ count(); return(LESSER); }
">"				{ count(); return(GREATER); }
"^"				{ count(); return(XOR); }
"|"				{ count(); return(OR); }
"?"				{ count(); return(QUESTION_MARK); }

[ \t\v\n\f]		{ count(); }
.			{ warning_message(); }

%%

warning_message()
{
	printf("The string %s was not recongized", yytext);	
}

yywrap()
{
	return(1);
}


comment()
{
	char c, c1;
	
	loop:
		while((c=input())!='*' && c!=0)
			putchar(c);
		if((c1=input())!='/' && c!=0){
			unput(c1);
			goto loop;
		}
		if(c!=0)
			putchar(c1);
}


int column = 0;

void count()
{
	int i;

	for (i = 0; yytext[i] != '\0'; i++)
		if (yytext[i] == '\n')
			column = 0;
		else if (yytext[i] == '\t')
			column += 8 - (column % 8);
		else
			column++;

	ECHO;
}


int check_type()
{
	return(IDENTIFIER);
}