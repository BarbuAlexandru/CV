%{
#include "ast.h"
#include <stdio.h>

Node* astRoot = NULL;
int yyerror(char* s);
extern int yylex(void);

%}
%union{
	
	Node* node;
	char* strings;
	int intVal;
}

%token END
%token AUTO
%token BREAK
%token CASE
%token CHAR
%token CONTINUE
%token CONST
%token DEFAULT
%token DO
%token DOUBLE
%token ELSE
%token ENUM
%token EXTERN
%token FLOAT
%token FOR
%token GOTO
%token IF
%token INLINE
%token INT
%token LONG
%token REGISTER
%token RESTRICT
%token RETURN
%token SIGNED
%token SIZEOF
%token STATIC
%token STRUCT
%token SWITCH
%token TYPEDEF
%token UNION
%token UNSIGNED
%token VOID
%token VOLATILE
%token WHILE
%token SHORT
%token TYPE_NAME
%token _BOOL
%token _COMPLEX
%token _IMAGINARY
%token HEADER
%token DEFINE

%token <strings> CONSTANT
%token <strings> STRING_LITERAL

%token ELLIPSIS
%token RIGHT_ASSIGN
%token LEFT_ASSIGN
%token ADD_ASSIGN
%token SUB_ASSIGN
%token MUL_ASSIGN
%token DIV_ASSIGN
%token MOD_ASSIGN
%token AND_ASSIGN
%token XOR_ASSIGN
%token OR_ASSIGN
%token RIGHT_OP
%token LEFT_OP
%token INC_OP
%token DEC_OP
%token PTR_OP
%token AND_OP
%token OR_OP
%token LE_OP
%token GE_OP
%token EQ_OP
%token NE_OP
%token END_OF_INSTRUCTION
%token LEFT_BRACE
%token RIGHT_BRACE
%token COMMA
%token TWO_POINTS
%token ASSIGN
%token LEFT_PARANTH
%token RIGHT_PARANTH
%token LEFT_BRACKET
%token RIGHT_BRACKET
%token POINT
%token AND
%token NOT
%token INV
%token SUB
%token ADD
%token MUL
%token DIV
%token MOD
%token LESSER
%token GREATER
%token XOR
%token OR
%token QUESTION_MARK

%token <strings> IDENTIFIER

%type <node> program_unit
%type <node> primary_expression
%type <node> postfix_expression
%type <node> argument_expression_list
%type <node> unary_expression
%type <node> unary_operator
%type <node> cast_expression
%type <node> multiplicative_expression
%type <node> additive_expression
%type <node> shift_expression
%type <node> relational_expression
%type <node> equality_expression
%type <node> and_expression
%type <node> exclusive_or_expression
%type <node> inclusive_or_expression
%type <node> logical_and_expression
%type <node> logical_or_expression
%type <node> conditional_expression
%type <node> assignment_expression
%type <node> assignment_operator
%type <node> expression
%type <node> constant_expression
%type <node> declaration
%type <node> declaration_specifiers
%type <node> init_declarator_list
%type <node> init_declarator
%type <node> storage_class_specifier
%type <node> type_specifier
%type <node> struct_or_union_specifier
%type <node> struct_or_union
%type <node> struct_declaration_list
%type <node> struct_declaration
%type <node> specifier_qualifier_list
%type <node> struct_declarator_list
%type <node> struct_declarator
%type <node> enum_specifier
%type <node> enumerator_list
%type <node> enumerator
%type <node> type_qualifier
%type <node> function_specifier
%type <node> declarator
%type <node> direct_declarator
%type <node> pointer
%type <node> type_qualifier_list
%type <node> parameter_type_list
%type <node> parameter_list
%type <node> parameter_declaration
%type <node> identifier_list
%type <node> type_name
%type <node> abstract_declarator
%type <node> direct_abstract_declarator
%type <node> initializer
%type <node> initializer_list
%type <node> designation
%type <node> designator_list
%type <node> designator
%type <node> statement
%type <node> labeled_statement
%type <node> compound_statement
%type <node> block_item_list
%type <node> block_item
%type <node> expression_statement
%type <node> selection_statement
%type <node> iteration_statement
%type <node> jump_statement
%type <node> translation_unit
%type <node> external_declaration
%type <node> function_definition
%type <node> declaration_list


%start program_unit
%%


program_unit
	: HEADER STRING_LITERAL program_unit			{ $$=$3; addLinkToList($$,CreateHeaderNode(CreateStringLiteralNode($2))); }
	| DEFINE primary_expression program_unit		{ $$=$3; addLinkToList($$,CreateDefineNode($2)); }
	| translation_unit								{ $$ = CreateProgramUnitNode($1); astRoot = $$; }
	;

primary_expression
	: IDENTIFIER								{ $$ = CreatePrimaryExpressionNode(CreateIdentifierNode($1)); }
	| CONSTANT									{ $$ = CreatePrimaryExpressionNode(CreateConstantNode($1)); }
	| STRING_LITERAL							{ $$ = CreatePrimaryExpressionNode(CreateStringLiteralNode($1)); }
	| LEFT_PARANTH expression RIGHT_PARANTH		{ $$ = CreatePrimaryExpressionNode($2);}
	;

postfix_expression
	: primary_expression																	{ $$ = CreatePostfixExpressionNode($1, NULL); }
	| postfix_expression LEFT_BRACKET expression RIGHT_BRACKET								{ $$=$1; addLinkToList($$,$3); }
	| postfix_expression LEFT_PARANTH RIGHT_PARANTH											{ $$=$1; addLinkToList($$,CreateOnlyDataNode("EMPTY")); }
	| postfix_expression LEFT_PARANTH argument_expression_list RIGHT_PARANTH				{ $$=$1; addLinkToList($$,$3); }
	| postfix_expression POINT IDENTIFIER													{ $$=$1; addLinkToList($$,CreateIdentifierNode($3)); }
	| postfix_expression PTR_OP IDENTIFIER													{ $$=$1; addLinkToList($$,CreateIdentifierNode($3)); }
	| postfix_expression INC_OP																{ $$=$1; addLinkToList($$,CreateOnlyDataNode("INC_OP")); }
	| postfix_expression DEC_OP																{ $$=$1; addLinkToList($$,CreateOnlyDataNode("DEC_OP")); }
	| LEFT_PARANTH type_name RIGHT_PARANTH LEFT_BRACE initializer_list RIGHT_BRACE			{ $$ = CreatePostfixExpressionNode($2, $5); }
	| LEFT_PARANTH type_name RIGHT_PARANTH LEFT_BRACE initializer_list COMMA RIGHT_BRACE	{ $$ = CreatePostfixExpressionNode($2, $5); }
	;

argument_expression_list
	: assignment_expression										{ $$ = CreateArgumentExpressionListNode($1); }
	| argument_expression_list COMMA assignment_expression		{ $$=$1; addLinkToList($$,$3); }
	;

unary_expression
	: postfix_expression								{ $$ = CreateUnaryExpressionNode($1, NULL); }
	| INC_OP unary_expression							{ $$=$2; addLinkToList($$,CreateOnlyDataNode("INC_OP")); }
	| DEC_OP unary_expression							{ $$=$2; addLinkToList($$,CreateOnlyDataNode("DEC_OP")); }
	| unary_operator cast_expression					{ $$ = CreateUnaryExpressionNode($1, $2); }
	| SIZEOF unary_expression							{ $$=$2; addLinkToList($$,CreateOnlyDataNode("SIZEOF")); }
	| SIZEOF LEFT_PARANTH type_name RIGHT_PARANTH		{ $$ = CreateUnaryExpressionNode(CreateOnlyDataNode("SIZEOF"), $3); }
	;

unary_operator
	: AND		{ $$ = CreateUnaryOperatorNode(CreateOnlyDataNode("AND")); }
	| MUL		{ $$ = CreateUnaryOperatorNode(CreateOnlyDataNode("MUL")); }
	| ADD		{ $$ = CreateUnaryOperatorNode(CreateOnlyDataNode("ADD")); }
	| SUB		{ $$ = CreateUnaryOperatorNode(CreateOnlyDataNode("SUB")); }
	| INV		{ $$ = CreateUnaryOperatorNode(CreateOnlyDataNode("INV")); }
	| NOT		{ $$ = CreateUnaryOperatorNode(CreateOnlyDataNode("NOT")); }
	;

cast_expression
	: unary_expression											{ $$ = CreateCastExpressionNode($1); }
	| LEFT_PARANTH type_name RIGHT_PARANTH cast_expression		{ $$=$4; addLinkToList($$,$2); }
	;

multiplicative_expression
	: cast_expression											{ $$ = CreateMultiplicativeExpressionNode($1); }
	| multiplicative_expression MUL cast_expression				{ $$=$1; addLinkToList($$,$3); }
	| multiplicative_expression DIV cast_expression				{ $$=$1; addLinkToList($$,$3); }
	| multiplicative_expression MOD cast_expression				{ $$=$1; addLinkToList($$,$3); }
	;

additive_expression
	: multiplicative_expression									{ $$ = CreateAdditiveExpressionNode($1); }
	| additive_expression ADD multiplicative_expression			{ $$=$1; addLinkToList($$,$3); }
	| additive_expression SUB multiplicative_expression			{ $$=$1; addLinkToList($$,$3); }
	;

shift_expression
	: additive_expression										{ $$ = CreateShiftExpressionNode($1); }
	| shift_expression LEFT_OP additive_expression				{ $$=$1; addLinkToList($$,$3); }
	| shift_expression RIGHT_OP additive_expression				{ $$=$1; addLinkToList($$,$3); }
	;

relational_expression
	: shift_expression											{ $$ = CreateRelationalExpressionNode($1); }
	| relational_expression LESSER shift_expression				{ $$=$1; addLinkToList($$,$3); }
	| relational_expression GREATER shift_expression			{ $$=$1; addLinkToList($$,$3); }
	| relational_expression LE_OP shift_expression				{ $$=$1; addLinkToList($$,$3); }
	| relational_expression GE_OP shift_expression				{ $$=$1; addLinkToList($$,$3); }
	;

equality_expression
	: relational_expression										{ $$ = CreateEqualityExpressionNode($1); }
	| equality_expression EQ_OP relational_expression			{ $$=$1; addLinkToList($$,$3); }
	| equality_expression NE_OP relational_expression			{ $$=$1; addLinkToList($$,$3); }
	;

and_expression
	: equality_expression										{ $$ = CreateAndExpressionNode($1); }
	| and_expression AND equality_expression					{ $$=$1; addLinkToList($$,$3); }
	;

exclusive_or_expression
	: and_expression											{ $$ = CreateExclusiveOrExpressionNode($1); }
	| exclusive_or_expression XOR and_expression				{ $$=$1; addLinkToList($$,$3); }
	;

inclusive_or_expression
	: exclusive_or_expression									{ $$ = CreateInclusiveOrExpressionNode($1); }
	| inclusive_or_expression OR exclusive_or_expression		{ $$=$1; addLinkToList($$,$3); }
	;

logical_and_expression
	: inclusive_or_expression									{ $$ = CreateLogicalAndExpressionNode($1); }
	| logical_and_expression AND_OP inclusive_or_expression		{ $$=$1; addLinkToList($$,$3); }
	;

logical_or_expression
	: logical_and_expression									{ $$ = CreateLogicalOrExpressionNode($1); }
	| logical_or_expression OR_OP logical_and_expression		{ $$=$1; addLinkToList($$,$3); }
	;

conditional_expression
	: logical_or_expression																	{ $$ = CreateConditionalExpressionNode($1); }
	| logical_or_expression QUESTION_MARK expression TWO_POINTS conditional_expression		{ $$=$5; addLinkToList($$,$1); addLinkToList($$,$3); }
	;

assignment_expression
	: conditional_expression																{ $$ = CreateAssignmentExpressionNode($1); }
	| unary_expression assignment_operator assignment_expression							{ $$=$3; addLinkToList($$,$1); addLinkToList($$,$2); }
	;

assignment_operator
	: ASSIGN					{ $$ = CreateAssignmentOperatorNode(CreateOnlyDataNode("ASSIGN")); }
	| MUL_ASSIGN				{ $$ = CreateAssignmentOperatorNode(CreateOnlyDataNode("MUL_ASSIGN")); }
	| DIV_ASSIGN				{ $$ = CreateAssignmentOperatorNode(CreateOnlyDataNode("DIV_ASSIGN")); }
	| MOD_ASSIGN				{ $$ = CreateAssignmentOperatorNode(CreateOnlyDataNode("MOD_ASSIGN")); }
	| ADD_ASSIGN				{ $$ = CreateAssignmentOperatorNode(CreateOnlyDataNode("ADD_ASSIGN")); }
	| SUB_ASSIGN				{ $$ = CreateAssignmentOperatorNode(CreateOnlyDataNode("SUB_ASSIGN")); }
	| LEFT_ASSIGN				{ $$ = CreateAssignmentOperatorNode(CreateOnlyDataNode("LEFT_ASSIGN")); }
	| RIGHT_ASSIGN				{ $$ = CreateAssignmentOperatorNode(CreateOnlyDataNode("RIGHT_ASSIGN")); }
	| AND_ASSIGN				{ $$ = CreateAssignmentOperatorNode(CreateOnlyDataNode("AND_ASSIGN")); }
	| XOR_ASSIGN				{ $$ = CreateAssignmentOperatorNode(CreateOnlyDataNode("XOR_ASSIGN")); }
	| OR_ASSIGN					{ $$ = CreateAssignmentOperatorNode(CreateOnlyDataNode("OR_ASSIGN")); }
	;

expression
	: assignment_expression								{ $$ = CreateExpressionNode($1); }
	| expression COMMA assignment_expression			{ $$=$1; addLinkToList($$,$3); }
	;

constant_expression
	: conditional_expression							{ $$ = CreateConstantExpressionNode($1); }
	;

declaration
	: declaration_specifiers END_OF_INSTRUCTION								{ $$ = CreateDeclarationNode($1, NULL); }
	| declaration_specifiers init_declarator_list END_OF_INSTRUCTION		{ $$ = CreateDeclarationNode($1, $2); }
	;

declaration_specifiers
	: storage_class_specifier												{ $$ = CreateDeclarationSpecifiersNode($1); }
	| storage_class_specifier declaration_specifiers						{ $$=$2; addLinkToList($$,$1); }
	| type_specifier														{ $$ = CreateDeclarationSpecifiersNode($1); }
	| type_specifier declaration_specifiers									{ $$=$2; addLinkToList($$,$1); }
	| type_qualifier														{ $$ = CreateDeclarationSpecifiersNode($1); }
	| type_qualifier declaration_specifiers									{ $$=$2; addLinkToList($$,$1); }
	| function_specifier													{ $$ = CreateDeclarationSpecifiersNode($1); }
	| function_specifier declaration_specifiers								{ $$=$2; addLinkToList($$,$1); }
	;

init_declarator_list
	: init_declarator														{ $$ = CreateInitDeclaratorListNode($1); }
	| init_declarator_list COMMA init_declarator							{ $$=$1; addLinkToList($$,$3); }
	;

init_declarator
	: declarator								{ $$ = CreateInitDeclaratorNode($1, NULL); }
	| declarator ASSIGN initializer				{ $$ = CreateInitDeclaratorNode($1, $3); }
	;

storage_class_specifier
	: TYPEDEF						{ $$ = CreateStorageClassSpecifierNode(CreateOnlyDataNode("TYPEDEF")); }
	| EXTERN						{ $$ = CreateStorageClassSpecifierNode(CreateOnlyDataNode("EXTERN")); }
	| STATIC						{ $$ = CreateStorageClassSpecifierNode(CreateOnlyDataNode("STATIC")); }
	| AUTO							{ $$ = CreateStorageClassSpecifierNode(CreateOnlyDataNode("AUTO")); }
	| REGISTER						{ $$ = CreateStorageClassSpecifierNode(CreateOnlyDataNode("REGISTER")); }
	;

type_specifier
	: VOID								{ $$ = CreateTypeSpecifierNode(CreateOnlyDataNode("VOID")); }
	| CHAR								{ $$ = CreateTypeSpecifierNode(CreateOnlyDataNode("CHAR")); }
	| SHORT								{ $$ = CreateTypeSpecifierNode(CreateOnlyDataNode("SHORT")); }
	| INT								{ $$ = CreateTypeSpecifierNode(CreateOnlyDataNode("INT")); }
	| LONG								{ $$ = CreateTypeSpecifierNode(CreateOnlyDataNode("LONG")); }
	| FLOAT								{ $$ = CreateTypeSpecifierNode(CreateOnlyDataNode("FLOAT")); }
	| DOUBLE							{ $$ = CreateTypeSpecifierNode(CreateOnlyDataNode("DOUBLE")); }
	| SIGNED							{ $$ = CreateTypeSpecifierNode(CreateOnlyDataNode("SIGNED")); }
	| UNSIGNED							{ $$ = CreateTypeSpecifierNode(CreateOnlyDataNode("UNSIGNED")); }
	| _BOOL								{ $$ = CreateTypeSpecifierNode(CreateOnlyDataNode("_BOOL")); }
	| _COMPLEX							{ $$ = CreateTypeSpecifierNode(CreateOnlyDataNode("_COMPLEX")); }
	| _IMAGINARY						{ $$ = CreateTypeSpecifierNode(CreateOnlyDataNode("_IMAGINARY")); }
	| struct_or_union_specifier			{ $$ = CreateTypeSpecifierNode($1); }
	| enum_specifier					{ $$ = CreateTypeSpecifierNode($1); }
	| TYPE_NAME							{ $$ = CreateTypeSpecifierNode(CreateOnlyDataNode("TYPE_NAME")); }
	;

struct_or_union_specifier
	: struct_or_union IDENTIFIER LEFT_BRACE struct_declaration_list RIGHT_BRACE					{ $$ = CreateStructOrUnionSpecifierNode($1, CreateIdentifierNode($2), $4); }
	| struct_or_union LEFT_BRACE struct_declaration_list RIGHT_BRACE							{ $$ = CreateStructOrUnionSpecifierNode($1, $3, NULL); }
	| struct_or_union IDENTIFIER																{ $$ = CreateStructOrUnionSpecifierNode($1, CreateIdentifierNode($2), NULL); }
	;

struct_or_union
	: STRUCT							{ $$ = CreateStructOrUnionNode(CreateOnlyDataNode("STRUCT")); }
	| UNION								{ $$ = CreateStructOrUnionNode(CreateOnlyDataNode("UNION")); }
	;

struct_declaration_list
	: struct_declaration								{ $$ = CreateStructDeclarationListNode($1); }
	| struct_declaration_list struct_declaration		{ $$=$1; addLinkToList($$,$2); }
	;

struct_declaration
	: specifier_qualifier_list struct_declarator_list END_OF_INSTRUCTION		{ $$ = CreateStructDeclarationNode($1, $2); }
	;

specifier_qualifier_list
	: type_specifier specifier_qualifier_list									{ $$=$2; addLinkToList($$,$1); }
	| type_specifier															{ $$ = CreateSpecifierQualifierListNode($1); }
	| type_qualifier specifier_qualifier_list									{ $$=$2; addLinkToList($$,$1); }
	| type_qualifier															{ $$ = CreateSpecifierQualifierListNode($1); }
	;

struct_declarator_list
	: struct_declarator															{ $$ = CreateStructDeclaratorListNode($1); }
	| struct_declarator_list COMMA struct_declarator							{ $$=$1; addLinkToList($$,$3); }
	;

struct_declarator
	: declarator																{ $$ = CreateStructDeclaratorNode($1, NULL); }
	| TWO_POINTS constant_expression											{ $$ = CreateStructDeclaratorNode($2, NULL); }
	| declarator TWO_POINTS constant_expression									{ $$ = CreateStructDeclaratorNode($1, $3); }
	;

enum_specifier
	: ENUM LEFT_BRACE enumerator_list RIGHT_BRACE								{ $$ = CreateEnumSpecifierNode($3, NULL); }
	| ENUM IDENTIFIER LEFT_BRACE enumerator_list RIGHT_BRACE					{ $$ = CreateEnumSpecifierNode(CreateIdentifierNode($2), $4); }
	| ENUM LEFT_BRACE enumerator_list COMMA RIGHT_BRACE							{ $$ = CreateEnumSpecifierNode($3, NULL); }
	| ENUM IDENTIFIER LEFT_BRACE enumerator_list COMMA RIGHT_BRACE				{ $$ = CreateEnumSpecifierNode(CreateIdentifierNode($2), $4); }
	| ENUM IDENTIFIER															{ $$ = CreateEnumSpecifierNode(CreateIdentifierNode($2), NULL); }
	;

enumerator_list
	: enumerator																{ $$ = CreateEnumeratorListNode($1); }
	| enumerator_list COMMA enumerator											{ $$=$1; addLinkToList($$,$3); }
	;

enumerator
	: IDENTIFIER																{ $$ = CreateEnumeratorNode(CreateIdentifierNode($1), NULL); }
	| IDENTIFIER ASSIGN constant_expression										{ $$ = CreateEnumeratorNode(CreateIdentifierNode($1), $3); }
	;

type_qualifier
	: CONST																		{ $$ = CreateTypeQualifierNode(CreateOnlyDataNode("CONST")); }
	| RESTRICT																	{ $$ = CreateTypeQualifierNode(CreateOnlyDataNode("RESTRICT")); }
	| VOLATILE																	{ $$ = CreateTypeQualifierNode(CreateOnlyDataNode("VOLATILE")); }
	;

function_specifier
	: INLINE																	{ $$ = CreateFunctionSpecifierNode(CreateOnlyDataNode("INLINE")); }
	;

declarator
	: pointer direct_declarator													{ $$ = CreateDeclaratorNode($1, $2); }
	| direct_declarator															{ $$ = CreateDeclaratorNode($1, NULL); }
	;

direct_declarator
	: IDENTIFIER																						{ $$ = CreateDirectDeclaratorNode(CreateIdentifierNode($1)); }
	| LEFT_PARANTH declarator RIGHT_PARANTH																{ $$ = CreateDirectDeclaratorNode($2); }
	| direct_declarator LEFT_BRACKET type_qualifier_list assignment_expression RIGHT_BRACKET			{ $$=$1; addLinkToList($$,$3); addLinkToList($$,$4); }
	| direct_declarator LEFT_BRACKET type_qualifier_list RIGHT_BRACKET									{ $$=$1; addLinkToList($$,$3); }
	| direct_declarator LEFT_BRACKET assignment_expression RIGHT_BRACKET								{ $$=$1; addLinkToList($$,$3); }
	| direct_declarator LEFT_BRACKET STATIC type_qualifier_list assignment_expression RIGHT_BRACKET		{ $$=$1; addLinkToList($$,$4); addLinkToList($$,$5); }
	| direct_declarator LEFT_BRACKET type_qualifier_list STATIC assignment_expression RIGHT_BRACKET		{ $$=$1; addLinkToList($$,$3); addLinkToList($$,$5); }
	| direct_declarator LEFT_BRACKET type_qualifier_list MUL RIGHT_BRACKET								{ $$=$1; addLinkToList($$,$3); }
	| direct_declarator LEFT_BRACKET MUL RIGHT_BRACKET													{ $$=$1; addLinkToList($$,CreateOnlyDataNode("MUL")); }
	| direct_declarator LEFT_BRACKET RIGHT_BRACKET														{ $$=$1; addLinkToList($$,CreateOnlyDataNode("EMPTY")); }
	| direct_declarator LEFT_PARANTH parameter_type_list RIGHT_PARANTH									{ $$=$1; addLinkToList($$,$3); }
	| direct_declarator LEFT_PARANTH identifier_list RIGHT_PARANTH										{ $$=$1; addLinkToList($$,$3); }
	| direct_declarator LEFT_PARANTH RIGHT_PARANTH														{ $$=$1; addLinkToList($$,CreateOnlyDataNode("EMPTY")); }
	;

pointer
	: MUL													{ $$ = CreatePointerNode(CreateOnlyDataNode("MUL"), NULL); }
	| MUL type_qualifier_list								{ $$ = CreatePointerNode(CreateOnlyDataNode("MUL"), $2); }
	| MUL pointer											{ $$=$2; addLinkToList($$,CreateOnlyDataNode("MUL")); }
	| MUL type_qualifier_list pointer						{ $$=$3; addLinkToList($$, $2); }
	;

type_qualifier_list
	: type_qualifier										{ $$ = CreateTypeQualifierListNode($1); }
	| type_qualifier_list type_qualifier					{ $$=$1; addLinkToList($$, $2); }
	;


parameter_type_list
	: parameter_list										{ $$ = CreateParameterTypeListNode($1); }
	| parameter_list COMMA ELLIPSIS							{ $$ = CreateParameterTypeListNode($1); }
	;

parameter_list
	: parameter_declaration									{ $$ = CreateParameterListNode($1); }
	| parameter_list COMMA parameter_declaration			{ $$=$1; addLinkToList($$, $3); }
	;

parameter_declaration
	: declaration_specifiers declarator						{ $$ = CreateParameterDeclarationNode($1,$2); }
	| declaration_specifiers abstract_declarator			{ $$ = CreateParameterDeclarationNode($1,$2); }
	| declaration_specifiers								{ $$ = CreateParameterDeclarationNode($1,NULL); }
	;

identifier_list
	: IDENTIFIER											{ $$ = CreateIdentifierListNode(CreateIdentifierNode($1)); }
	| identifier_list COMMA IDENTIFIER						{ $$=$1; addLinkToList($$, CreateIdentifierNode($3)); }
	;

type_name
	: specifier_qualifier_list								{ $$ = CreateTypeNameNode($1,NULL); }
	| specifier_qualifier_list abstract_declarator			{ $$ = CreateTypeNameNode($1,$2); }
	;

abstract_declarator
	: pointer												{ $$ = CreateAbstractDeclaratorNode($1,NULL); }
	| direct_abstract_declarator							{ $$ = CreateAbstractDeclaratorNode($1,NULL); }
	| pointer direct_abstract_declarator					{ $$ = CreateAbstractDeclaratorNode($1,$2); }
	;

direct_abstract_declarator
	: LEFT_PARANTH abstract_declarator RIGHT_PARANTH									{ $$ = CreateDirectAbstractDeclaratorNode($2); }
	| LEFT_BRACKET RIGHT_BRACKET														{ $$ = CreateDirectAbstractDeclaratorNode(CreateOnlyDataNode("EMPTY")); }
	| LEFT_BRACKET assignment_expression RIGHT_BRACKET									{ $$ = CreateDirectAbstractDeclaratorNode($2); }
	| direct_abstract_declarator LEFT_BRACKET RIGHT_BRACKET								{ $$=$1; addLinkToList($$, CreateOnlyDataNode("EMPTY")); }
	| direct_abstract_declarator LEFT_BRACKET assignment_expression RIGHT_BRACKET		{ $$=$1; addLinkToList($$, $3); }
	| LEFT_BRACKET MUL RIGHT_BRACKET													{ $$ = CreateDirectAbstractDeclaratorNode(CreateOnlyDataNode("MUL")); }
	| direct_abstract_declarator LEFT_BRACKET MUL RIGHT_BRACKET							{ $$=$1; addLinkToList($$, CreateOnlyDataNode("MUL")); }
	| LEFT_PARANTH RIGHT_PARANTH														{ $$ = CreateDirectAbstractDeclaratorNode(CreateOnlyDataNode("EMPTY")); }
	| LEFT_PARANTH parameter_type_list RIGHT_PARANTH									{ $$ = CreateDirectAbstractDeclaratorNode($2); }
	| direct_abstract_declarator LEFT_PARANTH RIGHT_PARANTH								{ $$=$1; addLinkToList($$, CreateOnlyDataNode("EMPTY")); }
	| direct_abstract_declarator LEFT_PARANTH parameter_type_list RIGHT_PARANTH			{ $$=$1; addLinkToList($$, $3); }
	;

initializer
	: assignment_expression																{ $$ = CreateInitializerNode($1); }
	| LEFT_BRACE initializer_list RIGHT_BRACE											{ $$ = CreateInitializerNode($2); }
	| LEFT_BRACE initializer_list COMMA RIGHT_BRACE										{ $$ = CreateInitializerNode($2); }
	;

initializer_list
	: initializer																		{ $$ = CreateInitializerListNode($1, NULL); }
	| designation initializer															{ $$ = CreateInitializerListNode($1, $2); }
	| initializer_list COMMA initializer												{ $$=$1; addLinkToList($$, $3); }
	| initializer_list COMMA designation initializer									{ $$=$1; addLinkToList($$, $3); addLinkToList($$, $4); }
	;

designation
	: designator_list ASSIGN															{ $$ = CreateDesignationNode($1); }
	;

designator_list
	: designator																		{ $$ = CreateDesignatorListNode($1); }
	| designator_list designator														{ $$=$1; addLinkToList($$, $2); }
	;

designator
	: LEFT_BRACKET constant_expression RIGHT_BRACKET									{ $$ = CreateDesignatorNode($2); }
	| POINT IDENTIFIER																	{ $$ = CreateDesignatorNode(CreateIdentifierNode($2)); }
	;

statement
	: labeled_statement																	{ $$ = CreateStatementNode($1); }
	| compound_statement																{ $$ = CreateStatementNode($1); }
	| expression_statement																{ $$ = CreateStatementNode($1); }
	| selection_statement																{ $$ = CreateStatementNode($1); }
	| iteration_statement																{ $$ = CreateStatementNode($1); }
	| jump_statement																	{ $$ = CreateStatementNode($1); }
	;

labeled_statement
	: IDENTIFIER TWO_POINTS statement													{ $$ = CreateLabeledStatementNode(CreateIdentifierNode($1),$3); }
	| CASE constant_expression TWO_POINTS statement										{ $$ = CreateLabeledStatementNode($2,$4); }
	| DEFAULT TWO_POINTS statement														{ $$ = CreateLabeledStatementNode(CreateOnlyDataNode("DEFAULT"),$3); }
	;

compound_statement
	: LEFT_BRACE RIGHT_BRACE															{ $$ = CreateCompoundStatementNode(CreateOnlyDataNode("EMPTY")); }
	| LEFT_BRACE block_item_list RIGHT_BRACE											{ $$ = CreateCompoundStatementNode($2); }
	;

block_item_list
	: block_item																		{ $$ = CreateBlockItemListNode($1); }
	| block_item_list block_item														{ $$=$1; addLinkToList($$, $2); }
	;

block_item
	: declaration																		{ $$ = CreateBlockItemNode($1); }
	| statement																			{ $$ = CreateBlockItemNode($1); }
	;

expression_statement
	: END_OF_INSTRUCTION																{ $$ = CreateExpressionStatementNode(CreateOnlyDataNode("END_OF_INSTRUCTION")); }
	| expression END_OF_INSTRUCTION														{ $$ = CreateExpressionStatementNode($1); }
	;

selection_statement
	: IF LEFT_PARANTH expression RIGHT_PARANTH statement								{ $$ = CreateSelectionStatementNode($3,$5, NULL); }
	| IF LEFT_PARANTH expression RIGHT_PARANTH statement ELSE statement					{ $$ = CreateSelectionStatementNode($3,$5, $7); }
	| SWITCH LEFT_PARANTH expression RIGHT_PARANTH statement							{ $$ = CreateSelectionStatementNode($3,$5, NULL); }
	;

iteration_statement
	: WHILE LEFT_PARANTH expression RIGHT_PARANTH statement													{ $$ = CreateIterationStatementNode($3,$5, NULL, NULL); }
	| DO statement WHILE LEFT_PARANTH expression RIGHT_PARANTH END_OF_INSTRUCTION							{ $$ = CreateIterationStatementNode($2,$5, NULL, NULL); }
	| FOR LEFT_PARANTH expression_statement expression_statement RIGHT_PARANTH statement					{ $$ = CreateIterationStatementNode($3,$4, $6, NULL); }
	| FOR LEFT_PARANTH expression_statement expression_statement expression RIGHT_PARANTH statement			{ $$ = CreateIterationStatementNode($3,$4, $5, $7); }
	| FOR LEFT_PARANTH declaration expression_statement RIGHT_PARANTH statement								{ $$ = CreateIterationStatementNode($3,$4, $6, NULL); }
	| FOR LEFT_PARANTH declaration expression_statement expression RIGHT_PARANTH statement					{ $$ = CreateIterationStatementNode($3,$4, $5, $7); }
	;

jump_statement
	: GOTO IDENTIFIER END_OF_INSTRUCTION				{ $$ = CreateJumpStatementNode(CreateIdentifierNode($2)); }
	| CONTINUE END_OF_INSTRUCTION						{ $$ = CreateJumpStatementNode(CreateOnlyDataNode("CONTINUE")); }
	| BREAK END_OF_INSTRUCTION							{ $$ = CreateJumpStatementNode(CreateOnlyDataNode("BREAK")); }
	| RETURN END_OF_INSTRUCTION							{ $$ = CreateJumpStatementNode(CreateOnlyDataNode("RETURN")); }
	| RETURN expression END_OF_INSTRUCTION				{ $$ = CreateJumpStatementNode($2); }
	;

translation_unit
	: external_declaration								{ $$ = CreateTranslationUnitNode($1); }
	| translation_unit external_declaration				{ $$=$1; addLinkToList($$, $2); }
	;

external_declaration
	: function_definition								{ $$ = CreateExternalDeclarationNode($1); }
	| declaration										{ $$ = CreateExternalDeclarationNode($1); }
	;

function_definition
	: declaration_specifiers declarator declaration_list compound_statement			{ $$ = CreateFunctionDefinitionNode($1,$2,$3,$4); }
	| declaration_specifiers declarator compound_statement							{ $$ = CreateFunctionDefinitionNode($1,$2,$3,NULL); }
	;

declaration_list
	: declaration										{ $$ = CreateDeclarationListNode($1); }
	| declaration_list declaration						{ $$=$1; addLinkToList($$, $2); }
	;



%%
#include <stdio.h>

extern char yytext[];
extern int column;

yyerror(char const *s)
{
	fflush(stdout);
	printf("\n%*s\n%*s\n", column, "^", column, s);
}