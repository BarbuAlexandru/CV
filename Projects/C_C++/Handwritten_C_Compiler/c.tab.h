/* A Bison parser, made by GNU Bison 3.7.1.  */

/* Bison interface for Yacc-like parsers in C

   Copyright (C) 1984, 1989-1990, 2000-2015, 2018-2020 Free Software Foundation,
   Inc.

   This program is free software: you can redistribute it and/or modify
   it under the terms of the GNU General Public License as published by
   the Free Software Foundation, either version 3 of the License, or
   (at your option) any later version.

   This program is distributed in the hope that it will be useful,
   but WITHOUT ANY WARRANTY; without even the implied warranty of
   MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
   GNU General Public License for more details.

   You should have received a copy of the GNU General Public License
   along with this program.  If not, see <http://www.gnu.org/licenses/>.  */

/* As a special exception, you may create a larger work that contains
   part or all of the Bison parser skeleton and distribute that work
   under terms of your choice, so long as that work isn't itself a
   parser generator using the skeleton or a modified version thereof
   as a parser skeleton.  Alternatively, if you modify or redistribute
   the parser skeleton itself, you may (at your option) remove this
   special exception, which will cause the skeleton and the resulting
   Bison output files to be licensed under the GNU General Public
   License without this special exception.

   This special exception was added by the Free Software Foundation in
   version 2.2 of Bison.  */

/* DO NOT RELY ON FEATURES THAT ARE NOT DOCUMENTED in the manual,
   especially those whose name start with YY_ or yy_.  They are
   private implementation details that can be changed or removed.  */

#ifndef YY_YY_C_TAB_H_INCLUDED
# define YY_YY_C_TAB_H_INCLUDED
/* Debug traces.  */
#ifndef YYDEBUG
# define YYDEBUG 0
#endif
#if YYDEBUG
extern int yydebug;
#endif

/* Token kinds.  */
#ifndef YYTOKENTYPE
# define YYTOKENTYPE
  enum yytokentype
  {
    YYEMPTY = -2,
    YYEOF = 0,                     /* "end of file"  */
    YYerror = 256,                 /* error  */
    YYUNDEF = 257,                 /* "invalid token"  */
    END = 258,                     /* END  */
    AUTO = 259,                    /* AUTO  */
    BREAK = 260,                   /* BREAK  */
    CASE = 261,                    /* CASE  */
    CHAR = 262,                    /* CHAR  */
    CONTINUE = 263,                /* CONTINUE  */
    CONST = 264,                   /* CONST  */
    DEFAULT = 265,                 /* DEFAULT  */
    DO = 266,                      /* DO  */
    DOUBLE = 267,                  /* DOUBLE  */
    ELSE = 268,                    /* ELSE  */
    ENUM = 269,                    /* ENUM  */
    EXTERN = 270,                  /* EXTERN  */
    FLOAT = 271,                   /* FLOAT  */
    FOR = 272,                     /* FOR  */
    GOTO = 273,                    /* GOTO  */
    IF = 274,                      /* IF  */
    INLINE = 275,                  /* INLINE  */
    INT = 276,                     /* INT  */
    LONG = 277,                    /* LONG  */
    REGISTER = 278,                /* REGISTER  */
    RESTRICT = 279,                /* RESTRICT  */
    RETURN = 280,                  /* RETURN  */
    SIGNED = 281,                  /* SIGNED  */
    SIZEOF = 282,                  /* SIZEOF  */
    STATIC = 283,                  /* STATIC  */
    STRUCT = 284,                  /* STRUCT  */
    SWITCH = 285,                  /* SWITCH  */
    TYPEDEF = 286,                 /* TYPEDEF  */
    UNION = 287,                   /* UNION  */
    UNSIGNED = 288,                /* UNSIGNED  */
    VOID = 289,                    /* VOID  */
    VOLATILE = 290,                /* VOLATILE  */
    WHILE = 291,                   /* WHILE  */
    SHORT = 292,                   /* SHORT  */
    TYPE_NAME = 293,               /* TYPE_NAME  */
    _BOOL = 294,                   /* _BOOL  */
    _COMPLEX = 295,                /* _COMPLEX  */
    _IMAGINARY = 296,              /* _IMAGINARY  */
    HEADER = 297,                  /* HEADER  */
    DEFINE = 298,                  /* DEFINE  */
    CONSTANT = 299,                /* CONSTANT  */
    STRING_LITERAL = 300,          /* STRING_LITERAL  */
    ELLIPSIS = 301,                /* ELLIPSIS  */
    RIGHT_ASSIGN = 302,            /* RIGHT_ASSIGN  */
    LEFT_ASSIGN = 303,             /* LEFT_ASSIGN  */
    ADD_ASSIGN = 304,              /* ADD_ASSIGN  */
    SUB_ASSIGN = 305,              /* SUB_ASSIGN  */
    MUL_ASSIGN = 306,              /* MUL_ASSIGN  */
    DIV_ASSIGN = 307,              /* DIV_ASSIGN  */
    MOD_ASSIGN = 308,              /* MOD_ASSIGN  */
    AND_ASSIGN = 309,              /* AND_ASSIGN  */
    XOR_ASSIGN = 310,              /* XOR_ASSIGN  */
    OR_ASSIGN = 311,               /* OR_ASSIGN  */
    RIGHT_OP = 312,                /* RIGHT_OP  */
    LEFT_OP = 313,                 /* LEFT_OP  */
    INC_OP = 314,                  /* INC_OP  */
    DEC_OP = 315,                  /* DEC_OP  */
    PTR_OP = 316,                  /* PTR_OP  */
    AND_OP = 317,                  /* AND_OP  */
    OR_OP = 318,                   /* OR_OP  */
    LE_OP = 319,                   /* LE_OP  */
    GE_OP = 320,                   /* GE_OP  */
    EQ_OP = 321,                   /* EQ_OP  */
    NE_OP = 322,                   /* NE_OP  */
    END_OF_INSTRUCTION = 323,      /* END_OF_INSTRUCTION  */
    LEFT_BRACE = 324,              /* LEFT_BRACE  */
    RIGHT_BRACE = 325,             /* RIGHT_BRACE  */
    COMMA = 326,                   /* COMMA  */
    TWO_POINTS = 327,              /* TWO_POINTS  */
    ASSIGN = 328,                  /* ASSIGN  */
    LEFT_PARANTH = 329,            /* LEFT_PARANTH  */
    RIGHT_PARANTH = 330,           /* RIGHT_PARANTH  */
    LEFT_BRACKET = 331,            /* LEFT_BRACKET  */
    RIGHT_BRACKET = 332,           /* RIGHT_BRACKET  */
    POINT = 333,                   /* POINT  */
    AND = 334,                     /* AND  */
    NOT = 335,                     /* NOT  */
    INV = 336,                     /* INV  */
    SUB = 337,                     /* SUB  */
    ADD = 338,                     /* ADD  */
    MUL = 339,                     /* MUL  */
    DIV = 340,                     /* DIV  */
    MOD = 341,                     /* MOD  */
    LESSER = 342,                  /* LESSER  */
    GREATER = 343,                 /* GREATER  */
    XOR = 344,                     /* XOR  */
    OR = 345,                      /* OR  */
    QUESTION_MARK = 346,           /* QUESTION_MARK  */
    IDENTIFIER = 347               /* IDENTIFIER  */
  };
  typedef enum yytokentype yytoken_kind_t;
#endif

/* Value type.  */
#if ! defined YYSTYPE && ! defined YYSTYPE_IS_DECLARED
union YYSTYPE
{
#line 10 "c.y"

	
	Node* node;
	char* strings;
	int intVal;

#line 163 "c.tab.h"

};
typedef union YYSTYPE YYSTYPE;
# define YYSTYPE_IS_TRIVIAL 1
# define YYSTYPE_IS_DECLARED 1
#endif


extern YYSTYPE yylval;

int yyparse (void);

#endif /* !YY_YY_C_TAB_H_INCLUDED  */
