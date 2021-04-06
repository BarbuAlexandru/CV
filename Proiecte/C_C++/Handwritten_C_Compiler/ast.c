#include "ast.h"
#include <malloc.h>
#include <string.h>
#include <stdio.h>

Node* createDefaultNode(const char* nodeName, unsigned int linksCount)
{
	Node* retNode = (Node*)malloc(sizeof(Node));
	if (retNode)
	{
		memset(retNode, 0, sizeof(Node));
		if (nodeName)
		{
			strcpy(retNode->type, nodeName);
		}
		retNode->numLinks = linksCount;
		if (linksCount > 0)
		{
			retNode->links = (Node**)malloc(linksCount * sizeof(Node*));
		}
	}
	return retNode;
}

Node* resizeNodeLinks(Node* nodeToResize, unsigned int newSize)
{
	if (nodeToResize->numLinks == 0)
	{
		nodeToResize->links = (Node**)malloc(newSize * sizeof(Node*));
	}
	else
	{
		nodeToResize->links = (Node**)realloc(nodeToResize->links, newSize * sizeof(Node*));
	}
	nodeToResize->numLinks = newSize;
	return nodeToResize;
}

Node* createListNode(const char* listName, Node* firstLink)
{
	Node* retNode = createDefaultNode(listName, 1);
	retNode->links[0] = firstLink;
	return retNode;
}

void addLinkToList(Node* listNode, Node* linkToAdd)
{
	unsigned int numLinks = listNode->numLinks;
	resizeNodeLinks(listNode, numLinks + 1);
	listNode->links[numLinks] = linkToAdd;
}

void printAst(Node* ast, int level)
{
	int idx = 0;
	if (ast)
	{
		for (idx = 0; idx < level; idx++)
		{
			printf(" ");
		}
		if (ast->type)
		{
			printf("%s ", ast->type);
		}
		if (ast->numLinks)
		{
			printf(" - %d - %s\n", ast->numLinks, ast->extraData);
		}
		else
		{
			printf(" - %s\n", ast->extraData);
		}
		for (idx = 0; idx < ast->numLinks; idx++)
		{
			printAst(ast->links[idx], level + 1);
		}
	}
}




//The create functions for each Node type

Node* CreateOnlyDataNode(const char* data) {
	Node* retVal = createDefaultNode("Data", 0);
	if (data)
		sprintf(retVal->extraData, "%s", data);
	return retVal;
}

Node* CreateIdentifierNode(const char* data) {
	Node* retVal = createDefaultNode("Identifier", 0);
	if (data)
		sprintf(retVal->extraData, "%s", data);
	return retVal;
}

Node* CreateConstantNode(const char* data) {
	Node* retVal = createDefaultNode("Constant", 0);
	if (data)
		sprintf(retVal->extraData, "%s", data);
	return retVal;
}

Node* CreateStringLiteralNode(const char* data) {
	Node* retVal = createDefaultNode("StringLiteral", 0);
	if (data)
		sprintf(retVal->extraData, "%s", data);
	return retVal;
}
Node* CreateHeaderNode(Node* node1) {
	Node* retNode = createDefaultNode("Header", 1);
	if (retNode)
	{
		retNode->links[0] = node1;
	}
	return retNode;
}
Node* CreateDefineNode(Node* node1) {
	Node* retNode = createDefaultNode("Define", 1);
	if (retNode)
	{
		retNode->links[0] = node1;
	}
	return retNode;
}

//Different Nodes

Node* CreateProgramUnitNode(Node* node1) {
	Node* retNode = createDefaultNode("ProgramUnit", 1);
	if (retNode)
	{
		retNode->links[0] = node1;
	}
	return retNode;
}
Node* CreatePrimaryExpressionNode(Node* node1) {
	Node* retNode = createDefaultNode("PrimaryExpression", 1);
	if (retNode)
	{
		retNode->links[0] = node1;
	}
	return retNode;
}
Node* CreatePostfixExpressionNode(Node* node1, Node* node2) {
	Node* retNode = createDefaultNode("PostfixExpression", 2);
	if (retNode)
	{
		retNode->links[0] = node1;
		retNode->links[1] = node2;
	}
	return retNode;
}
Node* CreateArgumentExpressionListNode(Node* node1) {
	Node* retNode = createDefaultNode("ArgumentExpressionList", 1);
	if (retNode)
	{
		retNode->links[0] = node1;
	}
	return retNode;
}
Node* CreateUnaryExpressionNode(Node* node1, Node* node2) {
	Node* retNode = createDefaultNode("UnaryExpression", 2);
	if (retNode)
	{
		retNode->links[0] = node1;
		retNode->links[1] = node2;
	}
	return retNode;
}
Node* CreateUnaryOperatorNode(Node* node1) {
	Node* retNode = createDefaultNode("UnaryOperator", 1);
	if (retNode)
	{
		retNode->links[0] = node1;
	}
	return retNode;
}
Node* CreateCastExpressionNode(Node* node1) {
	Node* retNode = createDefaultNode("CastExpression", 1);
	if (retNode)
	{
		retNode->links[0] = node1;
	}
	return retNode;
}
Node* CreateMultiplicativeExpressionNode(Node* node1) {
	Node* retNode = createDefaultNode("MultiplicativeExpression", 1);
	if (retNode)
	{
		retNode->links[0] = node1;
	}
	return retNode;
}
Node* CreateAdditiveExpressionNode(Node* node1) {
	Node* retNode = createDefaultNode("AdditiveExpression", 1);
	if (retNode)
	{
		retNode->links[0] = node1;
	}
	return retNode;
}
Node* CreateShiftExpressionNode(Node* node1) {
	Node* retNode = createDefaultNode("ShiftExpression", 1);
	if (retNode)
	{
		retNode->links[0] = node1;
	}
	return retNode;
}

Node* CreateRelationalExpressionNode(Node* node1) {
	Node* retNode = createDefaultNode("RelationalExpression", 1);
	if (retNode)
	{
		retNode->links[0] = node1;
	}
	return retNode;
}
Node* CreateEqualityExpressionNode(Node* node1) {
	Node* retNode = createDefaultNode("EqualityExpression", 1);
	if (retNode)
	{
		retNode->links[0] = node1;
	}
	return retNode;
}
Node* CreateAndExpressionNode(Node* node1) {
	Node* retNode = createDefaultNode("AndExpression", 1);
	if (retNode)
	{
		retNode->links[0] = node1;
	}
	return retNode;
}
Node* CreateExclusiveOrExpressionNode(Node* node1) {
	Node* retNode = createDefaultNode("ExclusiveOrExpression", 1);
	if (retNode)
	{
		retNode->links[0] = node1;
	}
	return retNode;
}
Node* CreateInclusiveOrExpressionNode(Node* node1) {
	Node* retNode = createDefaultNode("InclusiveOrExpression", 1);
	if (retNode)
	{
		retNode->links[0] = node1;
	}
	return retNode;
}
Node* CreateLogicalAndExpressionNode(Node* node1) {
	Node* retNode = createDefaultNode("LogicalAndExpression", 1);
	if (retNode)
	{
		retNode->links[0] = node1;
	}
	return retNode;
}
Node* CreateLogicalOrExpressionNode(Node* node1) {
	Node* retNode = createDefaultNode("LogicalOrExpression", 1);
	if (retNode)
	{
		retNode->links[0] = node1;
	}
	return retNode;
}
Node* CreateConditionalExpressionNode(Node* node1) {
	Node* retNode = createDefaultNode("ConditionalExpression", 1);
	if (retNode)
	{
		retNode->links[0] = node1;
	}
	return retNode;
}
Node* CreateAssignmentExpressionNode(Node* node1) {
	Node* retNode = createDefaultNode("AssignmentExpression", 1);
	if (retNode)
	{
		retNode->links[0] = node1;
	}
	return retNode;
}
Node* CreateAssignmentOperatorNode(Node* node1) {
	Node* retNode = createDefaultNode("AssignmentOperator", 1);
	if (retNode)
	{
		retNode->links[0] = node1;
	}
	return retNode;
}

Node* CreateExpressionNode(Node* node1) {
	Node* retNode = createDefaultNode("Expression", 1);
	if (retNode)
	{
		retNode->links[0] = node1;
	}
	return retNode;
}
Node* CreateConstantExpressionNode(Node* node1) {
	Node* retNode = createDefaultNode("ConstantExpression", 1);
	if (retNode)
	{
		retNode->links[0] = node1;
	}
	return retNode;
}
Node* CreateDeclarationNode(Node* node1, Node* node2) {
	Node* retNode = createDefaultNode("Declaration", 2);
	if (retNode)
	{
		retNode->links[0] = node1;
		retNode->links[1] = node2;
	}
	return retNode;
}
Node* CreateDeclarationSpecifiersNode(Node* node1) {
	Node* retNode = createDefaultNode("DeclarationSpecifiers", 1);
	if (retNode)
	{
		retNode->links[0] = node1;
	}
	return retNode;
}
Node* CreateInitDeclaratorListNode(Node* node1) {
	Node* retNode = createDefaultNode("InitDeclaratorList", 1);
	if (retNode)
	{
		retNode->links[0] = node1;
	}
	return retNode;
}
Node* CreateInitDeclaratorNode(Node* node1, Node* node2) {
	Node* retNode = createDefaultNode("InitDeclarator", 2);
	if (retNode)
	{
		retNode->links[0] = node1;
		retNode->links[1] = node2;
	}
	return retNode;
}
Node* CreateStorageClassSpecifierNode(Node* node1) {
	Node* retNode = createDefaultNode("StorageClassSpecifier", 1);
	if (retNode)
	{
		retNode->links[0] = node1;
	}
	return retNode;
}
Node* CreateTypeSpecifierNode(Node* node1) {
	Node* retNode = createDefaultNode("TypeSpecifier", 1);
	if (retNode)
	{
		retNode->links[0] = node1;
	}
	return retNode;
}
Node* CreateStructOrUnionSpecifierNode(Node* node1, Node* node2, Node* node3) {
	Node* retNode = createDefaultNode("StructOrUnionSpecifier", 3);
	if (retNode)
	{
		retNode->links[0] = node1;
		retNode->links[1] = node2;
		retNode->links[2] = node3;
	}
	return retNode;
}
Node* CreateStructOrUnionNode(Node* node1) {
	Node* retNode = createDefaultNode("StructOrUnion", 1);
	if (retNode)
	{
		retNode->links[0] = node1;
	}
	return retNode;
}

Node* CreateStructDeclarationListNode(Node* node1) {
	Node* retNode = createDefaultNode("StructDeclarationList", 1);
	if (retNode)
	{
		retNode->links[0] = node1;
	}
	return retNode;
}
Node* CreateStructDeclarationNode(Node* node1, Node* node2) {
	Node* retNode = createDefaultNode("StructDeclaration", 2);
	if (retNode)
	{
		retNode->links[0] = node1;
		retNode->links[1] = node2;
	}
	return retNode;
}
Node* CreateSpecifierQualifierListNode(Node* node1) {
	Node* retNode = createDefaultNode("SpecifierQualifierList", 1);
	if (retNode)
	{
		retNode->links[0] = node1;
	}
	return retNode;
}
Node* CreateStructDeclaratorListNode(Node* node1) {
	Node* retNode = createDefaultNode("StructDeclaratorList", 1);
	if (retNode)
	{
		retNode->links[0] = node1;
	}
	return retNode;
}
Node* CreateStructDeclaratorNode(Node* node1, Node* node2) {
	Node* retNode = createDefaultNode("StructDeclarator", 2);
	if (retNode)
	{
		retNode->links[0] = node1;
		retNode->links[1] = node2;
	}
	return retNode;
}
Node* CreateEnumSpecifierNode(Node* node1, Node* node2) {
	Node* retNode = createDefaultNode("EnumSpecifier", 2);
	if (retNode)
	{
		retNode->links[0] = node1;
		retNode->links[1] = node2;
	}
	return retNode;
}
Node* CreateEnumeratorListNode(Node* node1) {
	Node* retNode = createDefaultNode("EnumeratorList", 1);
	if (retNode)
	{
		retNode->links[0] = node1;
	}
	return retNode;
}
Node* CreateEnumeratorNode(Node* node1, Node* node2) {
	Node* retNode = createDefaultNode("Enumerator", 2);
	if (retNode)
	{
		retNode->links[0] = node1;
		retNode->links[1] = node2;
	}
	return retNode;
}
Node* CreateTypeQualifierNode(Node* node1) {
	Node* retNode = createDefaultNode("TypeQualifier", 1);
	if (retNode)
	{
		retNode->links[0] = node1;
	}
	return retNode;
}
Node* CreateFunctionSpecifierNode(Node* node1) {
	Node* retNode = createDefaultNode("FunctionSpecifier", 1);
	if (retNode)
	{
		retNode->links[0] = node1;
	}
	return retNode;
}

Node* CreateDeclaratorNode(Node* node1, Node* node2) {
	Node* retNode = createDefaultNode("Declarator", 2);
	if (retNode)
	{
		retNode->links[0] = node1;
		retNode->links[1] = node2;
	}
	return retNode;
}
Node* CreateDirectDeclaratorNode(Node* node1) {
	Node* retNode = createDefaultNode("DirectDeclarator", 1);
	if (retNode)
	{
		retNode->links[0] = node1;
	}
	return retNode;
}
Node* CreatePointerNode(Node* node1, Node* node2) {
	Node* retNode = createDefaultNode("Pointer", 2);
	if (retNode)
	{
		retNode->links[0] = node1;
		retNode->links[1] = node2;
	}
	return retNode;
}
Node* CreateTypeQualifierListNode(Node* node1) {
	Node* retNode = createDefaultNode("TypeQualifierList", 1);
	if (retNode)
	{
		retNode->links[0] = node1;
	}
	return retNode;
}
Node* CreateParameterTypeListNode(Node* node1) {
	Node* retNode = createDefaultNode("ParameterTypeList", 1);
	if (retNode)
	{
		retNode->links[0] = node1;
	}
	return retNode;
}
Node* CreateParameterListNode(Node* node1) {
	Node* retNode = createDefaultNode("ParameterList", 1);
	if (retNode)
	{
		retNode->links[0] = node1;
	}
	return retNode;
}
Node* CreateParameterDeclarationNode(Node* node1, Node* node2) {
	Node* retNode = createDefaultNode("ParameterDeclaration", 2);
	if (retNode)
	{
		retNode->links[0] = node1;
		retNode->links[1] = node2;
	}
	return retNode;
}
Node* CreateIdentifierListNode(Node* node1) {
	Node* retNode = createDefaultNode("IdentifierList", 1);
	if (retNode)
	{
		retNode->links[0] = node1;
	}
	return retNode;
}
Node* CreateTypeNameNode(Node* node1, Node* node2) {
	Node* retNode = createDefaultNode("TypeName", 2);
	if (retNode)
	{
		retNode->links[0] = node1;
		retNode->links[1] = node2;
	}
	return retNode;
}
Node* CreateAbstractDeclaratorNode(Node* node1, Node* node2) {
	Node* retNode = createDefaultNode("AbstractDeclarator", 2);
	if (retNode)
	{
		retNode->links[0] = node1;
		retNode->links[1] = node2;
	}
	return retNode;
}

Node* CreateDirectAbstractDeclaratorNode(Node* node1) {
	Node* retNode = createDefaultNode("DirectAbstractDeclarator", 1);
	if (retNode)
	{
		retNode->links[0] = node1;
	}
	return retNode;
}
Node* CreateInitializerNode(Node* node1) {
	Node* retNode = createDefaultNode("Initializer", 1);
	if (retNode)
	{
		retNode->links[0] = node1;
	}
	return retNode;
}
Node* CreateInitializerListNode(Node* node1, Node* node2) {
	Node* retNode = createDefaultNode("InitializerList", 2);
	if (retNode)
	{
		retNode->links[0] = node1;
		retNode->links[1] = node2;
	}
	return retNode;
}
Node* CreateDesignationNode(Node* node1) {
	Node* retNode = createDefaultNode("Designation", 1);
	if (retNode)
	{
		retNode->links[0] = node1;
	}
	return retNode;
}
Node* CreateDesignatorListNode(Node* node1) {
	Node* retNode = createDefaultNode("DesignatorList", 1);
	if (retNode)
	{
		retNode->links[0] = node1;
	}
	return retNode;
}
Node* CreateDesignatorNode(Node* node1) {
	Node* retNode = createDefaultNode("Designator", 1);
	if (retNode)
	{
		retNode->links[0] = node1;
	}
	return retNode;
}
Node* CreateStatementNode(Node* node1) {
	Node* retNode = createDefaultNode("Statement", 1);
	if (retNode)
	{
		retNode->links[0] = node1;
	}
	return retNode;
}
Node* CreateLabeledStatementNode(Node* node1, Node* node2) {
	Node* retNode = createDefaultNode("LabeledStatement", 2);
	if (retNode)
	{
		retNode->links[0] = node1;
		retNode->links[1] = node2;
	}
	return retNode;
}
Node* CreateCompoundStatementNode(Node* node1) {
	Node* retNode = createDefaultNode("CompoundStatement", 1);
	if (retNode)
	{
		retNode->links[0] = node1;
	}
	return retNode;
}
Node* CreateBlockItemListNode(Node* node1) {
	Node* retNode = createDefaultNode("BlockItemList", 1);
	if (retNode)
	{
		retNode->links[0] = node1;
	}
	return retNode;
}

Node* CreateBlockItemNode(Node* node1) {
	Node* retNode = createDefaultNode("BlockItem", 1);
	if (retNode)
	{
		retNode->links[0] = node1;
	}
	return retNode;
}
Node* CreateExpressionStatementNode(Node* node1) {
	Node* retNode = createDefaultNode("ExpressionStatement", 1);
	if (retNode)
	{
		retNode->links[0] = node1;
	}
	return retNode;
}
Node* CreateSelectionStatementNode(Node* node1, Node* node2, Node* node3) {
	Node* retNode = createDefaultNode("SelectionStatement", 3);
	if (retNode)
	{
		retNode->links[0] = node1;
		retNode->links[1] = node2;
		retNode->links[2] = node3;
	}
	return retNode;
}
Node* CreateIterationStatementNode(Node* node1, Node* node2, Node* node3, Node* node4) {
	Node* retNode = createDefaultNode("IterationStatement", 4);
	if (retNode)
	{
		retNode->links[0] = node1;
		retNode->links[1] = node2;
		retNode->links[2] = node3;
		retNode->links[3] = node4;
	}
	return retNode;
}
Node* CreateJumpStatementNode(Node* node1) {
	Node* retNode = createDefaultNode("JumpStatement", 1);
	if (retNode)
	{
		retNode->links[0] = node1;
	}
	return retNode;
}
Node* CreateTranslationUnitNode(Node* node1) {
	Node* retNode = createDefaultNode("TranslationUnit", 1);
	if (retNode)
	{
		retNode->links[0] = node1;
	}
	return retNode;
}
Node* CreateExternalDeclarationNode(Node* node1) {
	Node* retNode = createDefaultNode("ExternalDeclaration", 1);
	if (retNode)
	{
		retNode->links[0] = node1;
	}
	return retNode;
}
Node* CreateFunctionDefinitionNode(Node* node1, Node* node2, Node* node3, Node* node4) {
	Node* retNode = createDefaultNode("FunctionDefinition", 4);
	if (retNode)
	{
		retNode->links[0] = node1;
		retNode->links[1] = node2;
		retNode->links[2] = node3;
		retNode->links[3] = node4;
	}
	return retNode;
}
Node* CreateDeclarationListNode(Node* node1) {
	Node* retNode = createDefaultNode("DeclarationList", 1);
	if (retNode)
	{
		retNode->links[0] = node1;
	}
	return retNode;
}





