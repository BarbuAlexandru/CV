#ifndef __AST_H
#define __AST_H

#define MAX_NODE_TYPE 255
#define MAX_EXTRA_DATA 255

//Node declaration
typedef struct node {
	char type[MAX_NODE_TYPE];
	int numLinks;
	char extraData[MAX_EXTRA_DATA];
	struct node** links;
}Node;

//General functions for AST
Node* createDefaultNode(const char* nodeName, unsigned int linksCount);
Node* resizeNodeLinks(Node* nodeToResize, unsigned int newSize);
Node* createListNode(const char* listName, Node* firstLink);
void addLinkToList(Node* listNode, Node* linkToAdd);
void printAst(Node* ast, int level);

//Create the functions for each Node type

Node* CreateOnlyDataNode(const char* data);
Node* CreateIdentifierNode(const char* data);
Node* CreateConstantNode(const char* data);
Node* CreateStringLiteralNode(const char* data);
Node* CreateHeaderNode(Node* node1);
Node* CreateDefineNode(Node* node1);

//Different Nodes

Node* CreateProgramUnitNode(Node* node1);
Node* CreatePrimaryExpressionNode(Node* node1);
Node* CreatePostfixExpressionNode(Node* node1, Node* node2);
Node* CreateArgumentExpressionListNode(Node* node1);
Node* CreateUnaryExpressionNode(Node* node1, Node* node2);
Node* CreateUnaryOperatorNode(Node* node1);
Node* CreateCastExpressionNode(Node* node1);
Node* CreateMultiplicativeExpressionNode(Node* node1);
Node* CreateAdditiveExpressionNode(Node* node1);
Node* CreateShiftExpressionNode(Node* node1);

Node* CreateRelationalExpressionNode(Node* node1);
Node* CreateEqualityExpressionNode(Node* node1);
Node* CreateAndExpressionNode(Node* node1);
Node* CreateExclusiveOrExpressionNode(Node* node1);
Node* CreateInclusiveOrExpressionNode(Node* node1);
Node* CreateLogicalAndExpressionNode(Node* node1);
Node* CreateLogicalOrExpressionNode(Node* node1);
Node* CreateConditionalExpressionNode(Node* node1);
Node* CreateAssignmentExpressionNode(Node* node1);
Node* CreateAssignmentOperatorNode(Node* node1);

Node* CreateExpressionNode(Node* node1);
Node* CreateConstantExpressionNode(Node* node1);
Node* CreateDeclarationNode(Node* node1, Node* node2);
Node* CreateDeclarationSpecifiersNode(Node* node1);
Node* CreateInitDeclaratorListNode(Node* node1);
Node* CreateInitDeclaratorNode(Node* node1, Node* node2);
Node* CreateStorageClassSpecifierNode(Node* node1);
Node* CreateTypeSpecifierNode(Node* node1);
Node* CreateStructOrUnionSpecifierNode(Node* node1, Node* node2, Node* node3);
Node* CreateStructOrUnionNode(Node* node1);

Node* CreateStructDeclarationListNode(Node* node1);
Node* CreateStructDeclarationNode(Node* node1, Node* node2);
Node* CreateSpecifierQualifierListNode(Node* node1);
Node* CreateStructDeclaratorListNode(Node* node1);
Node* CreateStructDeclaratorNode(Node* node1, Node* node2);
Node* CreateEnumSpecifierNode(Node* node1, Node* node2);
Node* CreateEnumeratorListNode(Node* node1);
Node* CreateEnumeratorNode(Node* node1, Node* node2);
Node* CreateTypeQualifierNode(Node* node1);
Node* CreateFunctionSpecifierNode(Node* node1);

Node* CreateDeclaratorNode(Node* node1, Node* node2);
Node* CreateDirectDeclaratorNode(Node* node1);
Node* CreatePointerNode(Node* node1, Node* node2);
Node* CreateTypeQualifierListNode(Node* node1);
Node* CreateParameterTypeListNode(Node* node1);
Node* CreateParameterListNode(Node* node1);
Node* CreateParameterDeclarationNode(Node* node1, Node* node2);
Node* CreateIdentifierListNode(Node* node1);
Node* CreateTypeNameNode(Node* node1, Node* node2);
Node* CreateAbstractDeclaratorNode(Node* node1, Node* node2);

Node* CreateDirectAbstractDeclaratorNode(Node* node1);
Node* CreateInitializerNode(Node* node1);
Node* CreateInitializerListNode(Node* node1, Node* node2);
Node* CreateDesignationNode(Node* node1);
Node* CreateDesignatorListNode(Node* node1);
Node* CreateDesignatorNode(Node* node1);
Node* CreateStatementNode(Node* node1);
Node* CreateLabeledStatementNode(Node* node1, Node* node2);
Node* CreateCompoundStatementNode(Node* node1);
Node* CreateBlockItemListNode(Node* node1);

Node* CreateBlockItemNode(Node* node1);
Node* CreateExpressionStatementNode(Node* node1);
Node* CreateSelectionStatementNode(Node* node1, Node* node2, Node* node3);
Node* CreateIterationStatementNode(Node* node1, Node* node2, Node* node3, Node* node4);
Node* CreateJumpStatementNode(Node* node1);
Node* CreateTranslationUnitNode(Node* node1);
Node* CreateExternalDeclarationNode(Node* node1);
Node* CreateFunctionDefinitionNode(Node* node1, Node* node2, Node* node3, Node* node4);
Node* CreateDeclarationListNode(Node* node1);

#endif