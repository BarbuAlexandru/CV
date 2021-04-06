/* A Bison parser, made by GNU Bison 3.7.1.  */

/* Bison implementation for Yacc-like parsers in C

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

/* C LALR(1) parser skeleton written by Richard Stallman, by
   simplifying the original so-called "semantic" parser.  */

/* DO NOT RELY ON FEATURES THAT ARE NOT DOCUMENTED in the manual,
   especially those whose name start with YY_ or yy_.  They are
   private implementation details that can be changed or removed.  */

/* All symbols defined below should begin with yy or YY, to avoid
   infringing on user name space.  This should be done even for local
   variables, as they might otherwise be expanded by user macros.
   There are some unavoidable exceptions within include files to
   define necessary library symbols; they are noted "INFRINGES ON
   USER NAME SPACE" below.  */

/* Identify Bison output.  */
#define YYBISON 1

/* Bison version.  */
#define YYBISON_VERSION "3.7.1"

/* Skeleton name.  */
#define YYSKELETON_NAME "yacc.c"

/* Pure parsers.  */
#define YYPURE 0

/* Push parsers.  */
#define YYPUSH 0

/* Pull parsers.  */
#define YYPULL 1




/* First part of user prologue.  */
#line 1 "c.y"

#include "ast.h"
#include <stdio.h>

Node* astRoot = NULL;
int yyerror(char* s);
extern int yylex(void);


#line 81 "c.tab.c"

# ifndef YY_CAST
#  ifdef __cplusplus
#   define YY_CAST(Type, Val) static_cast<Type> (Val)
#   define YY_REINTERPRET_CAST(Type, Val) reinterpret_cast<Type> (Val)
#  else
#   define YY_CAST(Type, Val) ((Type) (Val))
#   define YY_REINTERPRET_CAST(Type, Val) ((Type) (Val))
#  endif
# endif
# ifndef YY_NULLPTR
#  if defined __cplusplus
#   if 201103L <= __cplusplus
#    define YY_NULLPTR nullptr
#   else
#    define YY_NULLPTR 0
#   endif
#  else
#   define YY_NULLPTR ((void*)0)
#  endif
# endif

#include "c.tab.h"
/* Symbol kind.  */
enum yysymbol_kind_t
{
  YYSYMBOL_YYEMPTY = -2,
  YYSYMBOL_YYEOF = 0,                      /* "end of file"  */
  YYSYMBOL_YYerror = 1,                    /* error  */
  YYSYMBOL_YYUNDEF = 2,                    /* "invalid token"  */
  YYSYMBOL_END = 3,                        /* END  */
  YYSYMBOL_AUTO = 4,                       /* AUTO  */
  YYSYMBOL_BREAK = 5,                      /* BREAK  */
  YYSYMBOL_CASE = 6,                       /* CASE  */
  YYSYMBOL_CHAR = 7,                       /* CHAR  */
  YYSYMBOL_CONTINUE = 8,                   /* CONTINUE  */
  YYSYMBOL_CONST = 9,                      /* CONST  */
  YYSYMBOL_DEFAULT = 10,                   /* DEFAULT  */
  YYSYMBOL_DO = 11,                        /* DO  */
  YYSYMBOL_DOUBLE = 12,                    /* DOUBLE  */
  YYSYMBOL_ELSE = 13,                      /* ELSE  */
  YYSYMBOL_ENUM = 14,                      /* ENUM  */
  YYSYMBOL_EXTERN = 15,                    /* EXTERN  */
  YYSYMBOL_FLOAT = 16,                     /* FLOAT  */
  YYSYMBOL_FOR = 17,                       /* FOR  */
  YYSYMBOL_GOTO = 18,                      /* GOTO  */
  YYSYMBOL_IF = 19,                        /* IF  */
  YYSYMBOL_INLINE = 20,                    /* INLINE  */
  YYSYMBOL_INT = 21,                       /* INT  */
  YYSYMBOL_LONG = 22,                      /* LONG  */
  YYSYMBOL_REGISTER = 23,                  /* REGISTER  */
  YYSYMBOL_RESTRICT = 24,                  /* RESTRICT  */
  YYSYMBOL_RETURN = 25,                    /* RETURN  */
  YYSYMBOL_SIGNED = 26,                    /* SIGNED  */
  YYSYMBOL_SIZEOF = 27,                    /* SIZEOF  */
  YYSYMBOL_STATIC = 28,                    /* STATIC  */
  YYSYMBOL_STRUCT = 29,                    /* STRUCT  */
  YYSYMBOL_SWITCH = 30,                    /* SWITCH  */
  YYSYMBOL_TYPEDEF = 31,                   /* TYPEDEF  */
  YYSYMBOL_UNION = 32,                     /* UNION  */
  YYSYMBOL_UNSIGNED = 33,                  /* UNSIGNED  */
  YYSYMBOL_VOID = 34,                      /* VOID  */
  YYSYMBOL_VOLATILE = 35,                  /* VOLATILE  */
  YYSYMBOL_WHILE = 36,                     /* WHILE  */
  YYSYMBOL_SHORT = 37,                     /* SHORT  */
  YYSYMBOL_TYPE_NAME = 38,                 /* TYPE_NAME  */
  YYSYMBOL__BOOL = 39,                     /* _BOOL  */
  YYSYMBOL__COMPLEX = 40,                  /* _COMPLEX  */
  YYSYMBOL__IMAGINARY = 41,                /* _IMAGINARY  */
  YYSYMBOL_HEADER = 42,                    /* HEADER  */
  YYSYMBOL_DEFINE = 43,                    /* DEFINE  */
  YYSYMBOL_CONSTANT = 44,                  /* CONSTANT  */
  YYSYMBOL_STRING_LITERAL = 45,            /* STRING_LITERAL  */
  YYSYMBOL_ELLIPSIS = 46,                  /* ELLIPSIS  */
  YYSYMBOL_RIGHT_ASSIGN = 47,              /* RIGHT_ASSIGN  */
  YYSYMBOL_LEFT_ASSIGN = 48,               /* LEFT_ASSIGN  */
  YYSYMBOL_ADD_ASSIGN = 49,                /* ADD_ASSIGN  */
  YYSYMBOL_SUB_ASSIGN = 50,                /* SUB_ASSIGN  */
  YYSYMBOL_MUL_ASSIGN = 51,                /* MUL_ASSIGN  */
  YYSYMBOL_DIV_ASSIGN = 52,                /* DIV_ASSIGN  */
  YYSYMBOL_MOD_ASSIGN = 53,                /* MOD_ASSIGN  */
  YYSYMBOL_AND_ASSIGN = 54,                /* AND_ASSIGN  */
  YYSYMBOL_XOR_ASSIGN = 55,                /* XOR_ASSIGN  */
  YYSYMBOL_OR_ASSIGN = 56,                 /* OR_ASSIGN  */
  YYSYMBOL_RIGHT_OP = 57,                  /* RIGHT_OP  */
  YYSYMBOL_LEFT_OP = 58,                   /* LEFT_OP  */
  YYSYMBOL_INC_OP = 59,                    /* INC_OP  */
  YYSYMBOL_DEC_OP = 60,                    /* DEC_OP  */
  YYSYMBOL_PTR_OP = 61,                    /* PTR_OP  */
  YYSYMBOL_AND_OP = 62,                    /* AND_OP  */
  YYSYMBOL_OR_OP = 63,                     /* OR_OP  */
  YYSYMBOL_LE_OP = 64,                     /* LE_OP  */
  YYSYMBOL_GE_OP = 65,                     /* GE_OP  */
  YYSYMBOL_EQ_OP = 66,                     /* EQ_OP  */
  YYSYMBOL_NE_OP = 67,                     /* NE_OP  */
  YYSYMBOL_END_OF_INSTRUCTION = 68,        /* END_OF_INSTRUCTION  */
  YYSYMBOL_LEFT_BRACE = 69,                /* LEFT_BRACE  */
  YYSYMBOL_RIGHT_BRACE = 70,               /* RIGHT_BRACE  */
  YYSYMBOL_COMMA = 71,                     /* COMMA  */
  YYSYMBOL_TWO_POINTS = 72,                /* TWO_POINTS  */
  YYSYMBOL_ASSIGN = 73,                    /* ASSIGN  */
  YYSYMBOL_LEFT_PARANTH = 74,              /* LEFT_PARANTH  */
  YYSYMBOL_RIGHT_PARANTH = 75,             /* RIGHT_PARANTH  */
  YYSYMBOL_LEFT_BRACKET = 76,              /* LEFT_BRACKET  */
  YYSYMBOL_RIGHT_BRACKET = 77,             /* RIGHT_BRACKET  */
  YYSYMBOL_POINT = 78,                     /* POINT  */
  YYSYMBOL_AND = 79,                       /* AND  */
  YYSYMBOL_NOT = 80,                       /* NOT  */
  YYSYMBOL_INV = 81,                       /* INV  */
  YYSYMBOL_SUB = 82,                       /* SUB  */
  YYSYMBOL_ADD = 83,                       /* ADD  */
  YYSYMBOL_MUL = 84,                       /* MUL  */
  YYSYMBOL_DIV = 85,                       /* DIV  */
  YYSYMBOL_MOD = 86,                       /* MOD  */
  YYSYMBOL_LESSER = 87,                    /* LESSER  */
  YYSYMBOL_GREATER = 88,                   /* GREATER  */
  YYSYMBOL_XOR = 89,                       /* XOR  */
  YYSYMBOL_OR = 90,                        /* OR  */
  YYSYMBOL_QUESTION_MARK = 91,             /* QUESTION_MARK  */
  YYSYMBOL_IDENTIFIER = 92,                /* IDENTIFIER  */
  YYSYMBOL_YYACCEPT = 93,                  /* $accept  */
  YYSYMBOL_program_unit = 94,              /* program_unit  */
  YYSYMBOL_primary_expression = 95,        /* primary_expression  */
  YYSYMBOL_postfix_expression = 96,        /* postfix_expression  */
  YYSYMBOL_argument_expression_list = 97,  /* argument_expression_list  */
  YYSYMBOL_unary_expression = 98,          /* unary_expression  */
  YYSYMBOL_unary_operator = 99,            /* unary_operator  */
  YYSYMBOL_cast_expression = 100,          /* cast_expression  */
  YYSYMBOL_multiplicative_expression = 101, /* multiplicative_expression  */
  YYSYMBOL_additive_expression = 102,      /* additive_expression  */
  YYSYMBOL_shift_expression = 103,         /* shift_expression  */
  YYSYMBOL_relational_expression = 104,    /* relational_expression  */
  YYSYMBOL_equality_expression = 105,      /* equality_expression  */
  YYSYMBOL_and_expression = 106,           /* and_expression  */
  YYSYMBOL_exclusive_or_expression = 107,  /* exclusive_or_expression  */
  YYSYMBOL_inclusive_or_expression = 108,  /* inclusive_or_expression  */
  YYSYMBOL_logical_and_expression = 109,   /* logical_and_expression  */
  YYSYMBOL_logical_or_expression = 110,    /* logical_or_expression  */
  YYSYMBOL_conditional_expression = 111,   /* conditional_expression  */
  YYSYMBOL_assignment_expression = 112,    /* assignment_expression  */
  YYSYMBOL_assignment_operator = 113,      /* assignment_operator  */
  YYSYMBOL_expression = 114,               /* expression  */
  YYSYMBOL_constant_expression = 115,      /* constant_expression  */
  YYSYMBOL_declaration = 116,              /* declaration  */
  YYSYMBOL_declaration_specifiers = 117,   /* declaration_specifiers  */
  YYSYMBOL_init_declarator_list = 118,     /* init_declarator_list  */
  YYSYMBOL_init_declarator = 119,          /* init_declarator  */
  YYSYMBOL_storage_class_specifier = 120,  /* storage_class_specifier  */
  YYSYMBOL_type_specifier = 121,           /* type_specifier  */
  YYSYMBOL_struct_or_union_specifier = 122, /* struct_or_union_specifier  */
  YYSYMBOL_struct_or_union = 123,          /* struct_or_union  */
  YYSYMBOL_struct_declaration_list = 124,  /* struct_declaration_list  */
  YYSYMBOL_struct_declaration = 125,       /* struct_declaration  */
  YYSYMBOL_specifier_qualifier_list = 126, /* specifier_qualifier_list  */
  YYSYMBOL_struct_declarator_list = 127,   /* struct_declarator_list  */
  YYSYMBOL_struct_declarator = 128,        /* struct_declarator  */
  YYSYMBOL_enum_specifier = 129,           /* enum_specifier  */
  YYSYMBOL_enumerator_list = 130,          /* enumerator_list  */
  YYSYMBOL_enumerator = 131,               /* enumerator  */
  YYSYMBOL_type_qualifier = 132,           /* type_qualifier  */
  YYSYMBOL_function_specifier = 133,       /* function_specifier  */
  YYSYMBOL_declarator = 134,               /* declarator  */
  YYSYMBOL_direct_declarator = 135,        /* direct_declarator  */
  YYSYMBOL_pointer = 136,                  /* pointer  */
  YYSYMBOL_type_qualifier_list = 137,      /* type_qualifier_list  */
  YYSYMBOL_parameter_type_list = 138,      /* parameter_type_list  */
  YYSYMBOL_parameter_list = 139,           /* parameter_list  */
  YYSYMBOL_parameter_declaration = 140,    /* parameter_declaration  */
  YYSYMBOL_identifier_list = 141,          /* identifier_list  */
  YYSYMBOL_type_name = 142,                /* type_name  */
  YYSYMBOL_abstract_declarator = 143,      /* abstract_declarator  */
  YYSYMBOL_direct_abstract_declarator = 144, /* direct_abstract_declarator  */
  YYSYMBOL_initializer = 145,              /* initializer  */
  YYSYMBOL_initializer_list = 146,         /* initializer_list  */
  YYSYMBOL_designation = 147,              /* designation  */
  YYSYMBOL_designator_list = 148,          /* designator_list  */
  YYSYMBOL_designator = 149,               /* designator  */
  YYSYMBOL_statement = 150,                /* statement  */
  YYSYMBOL_labeled_statement = 151,        /* labeled_statement  */
  YYSYMBOL_compound_statement = 152,       /* compound_statement  */
  YYSYMBOL_block_item_list = 153,          /* block_item_list  */
  YYSYMBOL_block_item = 154,               /* block_item  */
  YYSYMBOL_expression_statement = 155,     /* expression_statement  */
  YYSYMBOL_selection_statement = 156,      /* selection_statement  */
  YYSYMBOL_iteration_statement = 157,      /* iteration_statement  */
  YYSYMBOL_jump_statement = 158,           /* jump_statement  */
  YYSYMBOL_translation_unit = 159,         /* translation_unit  */
  YYSYMBOL_external_declaration = 160,     /* external_declaration  */
  YYSYMBOL_function_definition = 161,      /* function_definition  */
  YYSYMBOL_declaration_list = 162          /* declaration_list  */
};
typedef enum yysymbol_kind_t yysymbol_kind_t;




#ifdef short
# undef short
#endif

/* On compilers that do not define __PTRDIFF_MAX__ etc., make sure
   <limits.h> and (if available) <stdint.h> are included
   so that the code can choose integer types of a good width.  */

#ifndef __PTRDIFF_MAX__
# include <limits.h> /* INFRINGES ON USER NAME SPACE */
# if defined __STDC_VERSION__ && 199901 <= __STDC_VERSION__
#  include <stdint.h> /* INFRINGES ON USER NAME SPACE */
#  define YY_STDINT_H
# endif
#endif

/* Narrow types that promote to a signed type and that can represent a
   signed or unsigned integer of at least N bits.  In tables they can
   save space and decrease cache pressure.  Promoting to a signed type
   helps avoid bugs in integer arithmetic.  */

#ifdef __INT_LEAST8_MAX__
typedef __INT_LEAST8_TYPE__ yytype_int8;
#elif defined YY_STDINT_H
typedef int_least8_t yytype_int8;
#else
typedef signed char yytype_int8;
#endif

#ifdef __INT_LEAST16_MAX__
typedef __INT_LEAST16_TYPE__ yytype_int16;
#elif defined YY_STDINT_H
typedef int_least16_t yytype_int16;
#else
typedef short yytype_int16;
#endif

#if defined __UINT_LEAST8_MAX__ && __UINT_LEAST8_MAX__ <= __INT_MAX__
typedef __UINT_LEAST8_TYPE__ yytype_uint8;
#elif (!defined __UINT_LEAST8_MAX__ && defined YY_STDINT_H \
       && UINT_LEAST8_MAX <= INT_MAX)
typedef uint_least8_t yytype_uint8;
#elif !defined __UINT_LEAST8_MAX__ && UCHAR_MAX <= INT_MAX
typedef unsigned char yytype_uint8;
#else
typedef short yytype_uint8;
#endif

#if defined __UINT_LEAST16_MAX__ && __UINT_LEAST16_MAX__ <= __INT_MAX__
typedef __UINT_LEAST16_TYPE__ yytype_uint16;
#elif (!defined __UINT_LEAST16_MAX__ && defined YY_STDINT_H \
       && UINT_LEAST16_MAX <= INT_MAX)
typedef uint_least16_t yytype_uint16;
#elif !defined __UINT_LEAST16_MAX__ && USHRT_MAX <= INT_MAX
typedef unsigned short yytype_uint16;
#else
typedef int yytype_uint16;
#endif

#ifndef YYPTRDIFF_T
# if defined __PTRDIFF_TYPE__ && defined __PTRDIFF_MAX__
#  define YYPTRDIFF_T __PTRDIFF_TYPE__
#  define YYPTRDIFF_MAXIMUM __PTRDIFF_MAX__
# elif defined PTRDIFF_MAX
#  ifndef ptrdiff_t
#   include <stddef.h> /* INFRINGES ON USER NAME SPACE */
#  endif
#  define YYPTRDIFF_T ptrdiff_t
#  define YYPTRDIFF_MAXIMUM PTRDIFF_MAX
# else
#  define YYPTRDIFF_T long
#  define YYPTRDIFF_MAXIMUM LONG_MAX
# endif
#endif

#ifndef YYSIZE_T
# ifdef __SIZE_TYPE__
#  define YYSIZE_T __SIZE_TYPE__
# elif defined size_t
#  define YYSIZE_T size_t
# elif defined __STDC_VERSION__ && 199901 <= __STDC_VERSION__
#  include <stddef.h> /* INFRINGES ON USER NAME SPACE */
#  define YYSIZE_T size_t
# else
#  define YYSIZE_T unsigned
# endif
#endif

#define YYSIZE_MAXIMUM                                  \
  YY_CAST (YYPTRDIFF_T,                                 \
           (YYPTRDIFF_MAXIMUM < YY_CAST (YYSIZE_T, -1)  \
            ? YYPTRDIFF_MAXIMUM                         \
            : YY_CAST (YYSIZE_T, -1)))

#define YYSIZEOF(X) YY_CAST (YYPTRDIFF_T, sizeof (X))


/* Stored state numbers (used for stacks). */
typedef yytype_int16 yy_state_t;

/* State numbers in computations.  */
typedef int yy_state_fast_t;

#ifndef YY_
# if defined YYENABLE_NLS && YYENABLE_NLS
#  if ENABLE_NLS
#   include <libintl.h> /* INFRINGES ON USER NAME SPACE */
#   define YY_(Msgid) dgettext ("bison-runtime", Msgid)
#  endif
# endif
# ifndef YY_
#  define YY_(Msgid) Msgid
# endif
#endif


#ifndef YY_ATTRIBUTE_PURE
# if defined __GNUC__ && 2 < __GNUC__ + (96 <= __GNUC_MINOR__)
#  define YY_ATTRIBUTE_PURE __attribute__ ((__pure__))
# else
#  define YY_ATTRIBUTE_PURE
# endif
#endif

#ifndef YY_ATTRIBUTE_UNUSED
# if defined __GNUC__ && 2 < __GNUC__ + (7 <= __GNUC_MINOR__)
#  define YY_ATTRIBUTE_UNUSED __attribute__ ((__unused__))
# else
#  define YY_ATTRIBUTE_UNUSED
# endif
#endif

/* Suppress unused-variable warnings by "using" E.  */
#if ! defined lint || defined __GNUC__
# define YYUSE(E) ((void) (E))
#else
# define YYUSE(E) /* empty */
#endif

#if defined __GNUC__ && ! defined __ICC && 407 <= __GNUC__ * 100 + __GNUC_MINOR__
/* Suppress an incorrect diagnostic about yylval being uninitialized.  */
# define YY_IGNORE_MAYBE_UNINITIALIZED_BEGIN                            \
    _Pragma ("GCC diagnostic push")                                     \
    _Pragma ("GCC diagnostic ignored \"-Wuninitialized\"")              \
    _Pragma ("GCC diagnostic ignored \"-Wmaybe-uninitialized\"")
# define YY_IGNORE_MAYBE_UNINITIALIZED_END      \
    _Pragma ("GCC diagnostic pop")
#else
# define YY_INITIAL_VALUE(Value) Value
#endif
#ifndef YY_IGNORE_MAYBE_UNINITIALIZED_BEGIN
# define YY_IGNORE_MAYBE_UNINITIALIZED_BEGIN
# define YY_IGNORE_MAYBE_UNINITIALIZED_END
#endif
#ifndef YY_INITIAL_VALUE
# define YY_INITIAL_VALUE(Value) /* Nothing. */
#endif

#if defined __cplusplus && defined __GNUC__ && ! defined __ICC && 6 <= __GNUC__
# define YY_IGNORE_USELESS_CAST_BEGIN                          \
    _Pragma ("GCC diagnostic push")                            \
    _Pragma ("GCC diagnostic ignored \"-Wuseless-cast\"")
# define YY_IGNORE_USELESS_CAST_END            \
    _Pragma ("GCC diagnostic pop")
#endif
#ifndef YY_IGNORE_USELESS_CAST_BEGIN
# define YY_IGNORE_USELESS_CAST_BEGIN
# define YY_IGNORE_USELESS_CAST_END
#endif


#define YY_ASSERT(E) ((void) (0 && (E)))

#if !defined yyoverflow

/* The parser invokes alloca or malloc; define the necessary symbols.  */

# ifdef YYSTACK_USE_ALLOCA
#  if YYSTACK_USE_ALLOCA
#   ifdef __GNUC__
#    define YYSTACK_ALLOC __builtin_alloca
#   elif defined __BUILTIN_VA_ARG_INCR
#    include <alloca.h> /* INFRINGES ON USER NAME SPACE */
#   elif defined _AIX
#    define YYSTACK_ALLOC __alloca
#   elif defined _MSC_VER
#    include <malloc.h> /* INFRINGES ON USER NAME SPACE */
#    define alloca _alloca
#   else
#    define YYSTACK_ALLOC alloca
#    if ! defined _ALLOCA_H && ! defined EXIT_SUCCESS
#     include <stdlib.h> /* INFRINGES ON USER NAME SPACE */
      /* Use EXIT_SUCCESS as a witness for stdlib.h.  */
#     ifndef EXIT_SUCCESS
#      define EXIT_SUCCESS 0
#     endif
#    endif
#   endif
#  endif
# endif

# ifdef YYSTACK_ALLOC
   /* Pacify GCC's 'empty if-body' warning.  */
#  define YYSTACK_FREE(Ptr) do { /* empty */; } while (0)
#  ifndef YYSTACK_ALLOC_MAXIMUM
    /* The OS might guarantee only one guard page at the bottom of the stack,
       and a page size can be as small as 4096 bytes.  So we cannot safely
       invoke alloca (N) if N exceeds 4096.  Use a slightly smaller number
       to allow for a few compiler-allocated temporary stack slots.  */
#   define YYSTACK_ALLOC_MAXIMUM 4032 /* reasonable circa 2006 */
#  endif
# else
#  define YYSTACK_ALLOC YYMALLOC
#  define YYSTACK_FREE YYFREE
#  ifndef YYSTACK_ALLOC_MAXIMUM
#   define YYSTACK_ALLOC_MAXIMUM YYSIZE_MAXIMUM
#  endif
#  if (defined __cplusplus && ! defined EXIT_SUCCESS \
       && ! ((defined YYMALLOC || defined malloc) \
             && (defined YYFREE || defined free)))
#   include <stdlib.h> /* INFRINGES ON USER NAME SPACE */
#   ifndef EXIT_SUCCESS
#    define EXIT_SUCCESS 0
#   endif
#  endif
#  ifndef YYMALLOC
#   define YYMALLOC malloc
#   if ! defined malloc && ! defined EXIT_SUCCESS
void *malloc (YYSIZE_T); /* INFRINGES ON USER NAME SPACE */
#   endif
#  endif
#  ifndef YYFREE
#   define YYFREE free
#   if ! defined free && ! defined EXIT_SUCCESS
void free (void *); /* INFRINGES ON USER NAME SPACE */
#   endif
#  endif
# endif
#endif /* !defined yyoverflow */

#if (! defined yyoverflow \
     && (! defined __cplusplus \
         || (defined YYSTYPE_IS_TRIVIAL && YYSTYPE_IS_TRIVIAL)))

/* A type that is properly aligned for any stack member.  */
union yyalloc
{
  yy_state_t yyss_alloc;
  YYSTYPE yyvs_alloc;
};

/* The size of the maximum gap between one aligned stack and the next.  */
# define YYSTACK_GAP_MAXIMUM (YYSIZEOF (union yyalloc) - 1)

/* The size of an array large to enough to hold all stacks, each with
   N elements.  */
# define YYSTACK_BYTES(N) \
     ((N) * (YYSIZEOF (yy_state_t) + YYSIZEOF (YYSTYPE)) \
      + YYSTACK_GAP_MAXIMUM)

# define YYCOPY_NEEDED 1

/* Relocate STACK from its old location to the new one.  The
   local variables YYSIZE and YYSTACKSIZE give the old and new number of
   elements in the stack, and YYPTR gives the new location of the
   stack.  Advance YYPTR to a properly aligned location for the next
   stack.  */
# define YYSTACK_RELOCATE(Stack_alloc, Stack)                           \
    do                                                                  \
      {                                                                 \
        YYPTRDIFF_T yynewbytes;                                         \
        YYCOPY (&yyptr->Stack_alloc, Stack, yysize);                    \
        Stack = &yyptr->Stack_alloc;                                    \
        yynewbytes = yystacksize * YYSIZEOF (*Stack) + YYSTACK_GAP_MAXIMUM; \
        yyptr += yynewbytes / YYSIZEOF (*yyptr);                        \
      }                                                                 \
    while (0)

#endif

#if defined YYCOPY_NEEDED && YYCOPY_NEEDED
/* Copy COUNT objects from SRC to DST.  The source and destination do
   not overlap.  */
# ifndef YYCOPY
#  if defined __GNUC__ && 1 < __GNUC__
#   define YYCOPY(Dst, Src, Count) \
      __builtin_memcpy (Dst, Src, YY_CAST (YYSIZE_T, (Count)) * sizeof (*(Src)))
#  else
#   define YYCOPY(Dst, Src, Count)              \
      do                                        \
        {                                       \
          YYPTRDIFF_T yyi;                      \
          for (yyi = 0; yyi < (Count); yyi++)   \
            (Dst)[yyi] = (Src)[yyi];            \
        }                                       \
      while (0)
#  endif
# endif
#endif /* !YYCOPY_NEEDED */

/* YYFINAL -- State number of the termination state.  */
#define YYFINAL  49
/* YYLAST -- Last index in YYTABLE.  */
#define YYLAST   1900

/* YYNTOKENS -- Number of terminals.  */
#define YYNTOKENS  93
/* YYNNTS -- Number of nonterminals.  */
#define YYNNTS  70
/* YYNRULES -- Number of rules.  */
#define YYNRULES  241
/* YYNSTATES -- Number of states.  */
#define YYNSTATES  408

/* YYMAXUTOK -- Last valid token kind.  */
#define YYMAXUTOK   347


/* YYTRANSLATE(TOKEN-NUM) -- Symbol number corresponding to TOKEN-NUM
   as returned by yylex, with out-of-bounds checking.  */
#define YYTRANSLATE(YYX)                                \
  (0 <= (YYX) && (YYX) <= YYMAXUTOK                     \
   ? YY_CAST (yysymbol_kind_t, yytranslate[YYX])        \
   : YYSYMBOL_YYUNDEF)

/* YYTRANSLATE[TOKEN-NUM] -- Symbol number corresponding to TOKEN-NUM
   as returned by yylex.  */
static const yytype_int8 yytranslate[] =
{
       0,     2,     2,     2,     2,     2,     2,     2,     2,     2,
       2,     2,     2,     2,     2,     2,     2,     2,     2,     2,
       2,     2,     2,     2,     2,     2,     2,     2,     2,     2,
       2,     2,     2,     2,     2,     2,     2,     2,     2,     2,
       2,     2,     2,     2,     2,     2,     2,     2,     2,     2,
       2,     2,     2,     2,     2,     2,     2,     2,     2,     2,
       2,     2,     2,     2,     2,     2,     2,     2,     2,     2,
       2,     2,     2,     2,     2,     2,     2,     2,     2,     2,
       2,     2,     2,     2,     2,     2,     2,     2,     2,     2,
       2,     2,     2,     2,     2,     2,     2,     2,     2,     2,
       2,     2,     2,     2,     2,     2,     2,     2,     2,     2,
       2,     2,     2,     2,     2,     2,     2,     2,     2,     2,
       2,     2,     2,     2,     2,     2,     2,     2,     2,     2,
       2,     2,     2,     2,     2,     2,     2,     2,     2,     2,
       2,     2,     2,     2,     2,     2,     2,     2,     2,     2,
       2,     2,     2,     2,     2,     2,     2,     2,     2,     2,
       2,     2,     2,     2,     2,     2,     2,     2,     2,     2,
       2,     2,     2,     2,     2,     2,     2,     2,     2,     2,
       2,     2,     2,     2,     2,     2,     2,     2,     2,     2,
       2,     2,     2,     2,     2,     2,     2,     2,     2,     2,
       2,     2,     2,     2,     2,     2,     2,     2,     2,     2,
       2,     2,     2,     2,     2,     2,     2,     2,     2,     2,
       2,     2,     2,     2,     2,     2,     2,     2,     2,     2,
       2,     2,     2,     2,     2,     2,     2,     2,     2,     2,
       2,     2,     2,     2,     2,     2,     2,     2,     2,     2,
       2,     2,     2,     2,     2,     2,     1,     2,     3,     4,
       5,     6,     7,     8,     9,    10,    11,    12,    13,    14,
      15,    16,    17,    18,    19,    20,    21,    22,    23,    24,
      25,    26,    27,    28,    29,    30,    31,    32,    33,    34,
      35,    36,    37,    38,    39,    40,    41,    42,    43,    44,
      45,    46,    47,    48,    49,    50,    51,    52,    53,    54,
      55,    56,    57,    58,    59,    60,    61,    62,    63,    64,
      65,    66,    67,    68,    69,    70,    71,    72,    73,    74,
      75,    76,    77,    78,    79,    80,    81,    82,    83,    84,
      85,    86,    87,    88,    89,    90,    91,    92
};

#if YYDEBUG
  /* YYRLINE[YYN] -- Source line where rule number YYN was defined.  */
static const yytype_int16 yyrline[] =
{
       0,   187,   187,   188,   189,   193,   194,   195,   196,   200,
     201,   202,   203,   204,   205,   206,   207,   208,   209,   213,
     214,   218,   219,   220,   221,   222,   223,   227,   228,   229,
     230,   231,   232,   236,   237,   241,   242,   243,   244,   248,
     249,   250,   254,   255,   256,   260,   261,   262,   263,   264,
     268,   269,   270,   274,   275,   279,   280,   284,   285,   289,
     290,   294,   295,   299,   300,   304,   305,   309,   310,   311,
     312,   313,   314,   315,   316,   317,   318,   319,   323,   324,
     328,   332,   333,   337,   338,   339,   340,   341,   342,   343,
     344,   348,   349,   353,   354,   358,   359,   360,   361,   362,
     366,   367,   368,   369,   370,   371,   372,   373,   374,   375,
     376,   377,   378,   379,   380,   384,   385,   386,   390,   391,
     395,   396,   400,   404,   405,   406,   407,   411,   412,   416,
     417,   418,   422,   423,   424,   425,   426,   430,   431,   435,
     436,   440,   441,   442,   446,   450,   451,   455,   456,   457,
     458,   459,   460,   461,   462,   463,   464,   465,   466,   467,
     471,   472,   473,   474,   478,   479,   484,   485,   489,   490,
     494,   495,   496,   500,   501,   505,   506,   510,   511,   512,
     516,   517,   518,   519,   520,   521,   522,   523,   524,   525,
     526,   530,   531,   532,   536,   537,   538,   539,   543,   547,
     548,   552,   553,   557,   558,   559,   560,   561,   562,   566,
     567,   568,   572,   573,   577,   578,   582,   583,   587,   588,
     592,   593,   594,   598,   599,   600,   601,   602,   603,   607,
     608,   609,   610,   611,   615,   616,   620,   621,   625,   626,
     630,   631
};
#endif

/** Accessing symbol of state STATE.  */
#define YY_ACCESSING_SYMBOL(State) YY_CAST (yysymbol_kind_t, yystos[State])

#if YYDEBUG || 0
/* The user-facing name of the symbol whose (internal) number is
   YYSYMBOL.  No bounds checking.  */
static const char *yysymbol_name (yysymbol_kind_t yysymbol) YY_ATTRIBUTE_UNUSED;

/* YYTNAME[SYMBOL-NUM] -- String name of the symbol SYMBOL-NUM.
   First, the terminals, then, starting at YYNTOKENS, nonterminals.  */
static const char *const yytname[] =
{
  "\"end of file\"", "error", "\"invalid token\"", "END", "AUTO", "BREAK",
  "CASE", "CHAR", "CONTINUE", "CONST", "DEFAULT", "DO", "DOUBLE", "ELSE",
  "ENUM", "EXTERN", "FLOAT", "FOR", "GOTO", "IF", "INLINE", "INT", "LONG",
  "REGISTER", "RESTRICT", "RETURN", "SIGNED", "SIZEOF", "STATIC", "STRUCT",
  "SWITCH", "TYPEDEF", "UNION", "UNSIGNED", "VOID", "VOLATILE", "WHILE",
  "SHORT", "TYPE_NAME", "_BOOL", "_COMPLEX", "_IMAGINARY", "HEADER",
  "DEFINE", "CONSTANT", "STRING_LITERAL", "ELLIPSIS", "RIGHT_ASSIGN",
  "LEFT_ASSIGN", "ADD_ASSIGN", "SUB_ASSIGN", "MUL_ASSIGN", "DIV_ASSIGN",
  "MOD_ASSIGN", "AND_ASSIGN", "XOR_ASSIGN", "OR_ASSIGN", "RIGHT_OP",
  "LEFT_OP", "INC_OP", "DEC_OP", "PTR_OP", "AND_OP", "OR_OP", "LE_OP",
  "GE_OP", "EQ_OP", "NE_OP", "END_OF_INSTRUCTION", "LEFT_BRACE",
  "RIGHT_BRACE", "COMMA", "TWO_POINTS", "ASSIGN", "LEFT_PARANTH",
  "RIGHT_PARANTH", "LEFT_BRACKET", "RIGHT_BRACKET", "POINT", "AND", "NOT",
  "INV", "SUB", "ADD", "MUL", "DIV", "MOD", "LESSER", "GREATER", "XOR",
  "OR", "QUESTION_MARK", "IDENTIFIER", "$accept", "program_unit",
  "primary_expression", "postfix_expression", "argument_expression_list",
  "unary_expression", "unary_operator", "cast_expression",
  "multiplicative_expression", "additive_expression", "shift_expression",
  "relational_expression", "equality_expression", "and_expression",
  "exclusive_or_expression", "inclusive_or_expression",
  "logical_and_expression", "logical_or_expression",
  "conditional_expression", "assignment_expression", "assignment_operator",
  "expression", "constant_expression", "declaration",
  "declaration_specifiers", "init_declarator_list", "init_declarator",
  "storage_class_specifier", "type_specifier", "struct_or_union_specifier",
  "struct_or_union", "struct_declaration_list", "struct_declaration",
  "specifier_qualifier_list", "struct_declarator_list",
  "struct_declarator", "enum_specifier", "enumerator_list", "enumerator",
  "type_qualifier", "function_specifier", "declarator",
  "direct_declarator", "pointer", "type_qualifier_list",
  "parameter_type_list", "parameter_list", "parameter_declaration",
  "identifier_list", "type_name", "abstract_declarator",
  "direct_abstract_declarator", "initializer", "initializer_list",
  "designation", "designator_list", "designator", "statement",
  "labeled_statement", "compound_statement", "block_item_list",
  "block_item", "expression_statement", "selection_statement",
  "iteration_statement", "jump_statement", "translation_unit",
  "external_declaration", "function_definition", "declaration_list", YY_NULLPTR
};

static const char *
yysymbol_name (yysymbol_kind_t yysymbol)
{
  return yytname[yysymbol];
}
#endif

#ifdef YYPRINT
/* YYTOKNUM[NUM] -- (External) token number corresponding to the
   (internal) symbol number NUM (which must be that of a token).  */
static const yytype_int16 yytoknum[] =
{
       0,   256,   257,   258,   259,   260,   261,   262,   263,   264,
     265,   266,   267,   268,   269,   270,   271,   272,   273,   274,
     275,   276,   277,   278,   279,   280,   281,   282,   283,   284,
     285,   286,   287,   288,   289,   290,   291,   292,   293,   294,
     295,   296,   297,   298,   299,   300,   301,   302,   303,   304,
     305,   306,   307,   308,   309,   310,   311,   312,   313,   314,
     315,   316,   317,   318,   319,   320,   321,   322,   323,   324,
     325,   326,   327,   328,   329,   330,   331,   332,   333,   334,
     335,   336,   337,   338,   339,   340,   341,   342,   343,   344,
     345,   346,   347
};
#endif

#define YYPACT_NINF (-324)

#define yypact_value_is_default(Yyn) \
  ((Yyn) == YYPACT_NINF)

#define YYTABLE_NINF (-1)

#define yytable_value_is_error(Yyn) \
  0

  /* YYPACT[STATE-NUM] -- Index in YYTABLE of the portion describing
     STATE-NUM.  */
static const yytype_int16 yypact[] =
{
    1784,  -324,  -324,  -324,  -324,   -40,  -324,  -324,  -324,  -324,
    -324,  -324,  -324,  -324,  -324,  -324,  -324,  -324,  -324,  -324,
    -324,  -324,  -324,  -324,  -324,  -324,   -21,   -32,    35,  -324,
      33,  1824,  1824,  -324,   -39,  -324,  1824,  1824,  1824,  -324,
    -324,   -38,   -23,  1784,  -324,  -324,  1521,  -324,  1784,  -324,
    -324,   109,    12,  -324,   -45,  -324,  1061,    36,    -3,  -324,
    -324,  1859,     7,  -324,  -324,  -324,    -7,   124,  -324,   -38,
    -324,  1547,  1588,  1588,   769,  -324,  -324,  -324,  -324,  -324,
    -324,  -324,   241,   199,  1521,  -324,   182,   129,   221,    65,
     220,     4,    49,    86,   157,   -43,  -324,  -324,    60,  -324,
     130,  -324,  -324,    12,  -324,   109,   329,  1210,  -324,    33,
    -324,  1117,   653,   796,    36,  1859,  1667,  -324,   106,  1859,
    1859,  1521,  -324,   -36,   222,   769,  -324,   769,  -324,  -324,
      98,   155,  -324,  -324,   151,  1251,  1521,   169,  -324,  -324,
    -324,  -324,  -324,  -324,  -324,  -324,  -324,  -324,  -324,  1521,
    -324,  -324,  1521,  1521,  1521,  1521,  1521,  1521,  1521,  1521,
    1521,  1521,  1521,  1521,  1521,  1521,  1521,  1521,  1521,  1521,
    1521,  1521,  -324,  -324,  -324,  -324,  -324,   197,   172,  1521,
     206,   217,   690,   224,   204,   231,  1277,   233,   238,  -324,
    -324,   219,    29,  -324,  -324,  -324,  -324,   418,  -324,  -324,
    -324,  -324,  -324,  1184,  -324,  -324,  -324,  -324,  -324,  -324,
     115,   239,   245,  -324,    70,    16,  -324,   253,   254,   857,
    -324,  -324,  -324,  1521,   135,  -324,   246,  -324,  1706,  -324,
    -324,  -324,  -324,  -324,   -27,   267,   300,   965,  1319,   183,
    -324,   195,  1345,  -324,  -324,    75,  -324,   -16,  -324,  -324,
    -324,  -324,  -324,   182,   182,   129,   129,   221,   221,   221,
     221,    65,    65,   220,     4,    49,    86,   157,   232,  -324,
    -324,   304,  -324,   690,   341,   499,   310,  1521,  -324,   156,
    1521,  1521,   690,  -324,  -324,  -324,  1521,   287,  -324,   240,
    1210,   137,  -324,   580,  -324,    11,  -324,  -324,  1746,   288,
    -324,   884,  -324,  -324,  1521,  -324,   305,   306,  -324,  -324,
     106,  1521,  -324,  -324,   312,   312,  -324,   309,   311,  -324,
     308,   313,   195,  1022,  1386,  1184,  -324,  1521,  -324,  -324,
    1521,   690,  -324,   317,  1412,  1412,  -324,   102,  -324,   121,
     143,  -324,   315,  -324,  -324,  1115,  -324,  -324,  -324,  -324,
    -324,  -324,   316,   318,  -324,  -324,  -324,  -324,  -324,  -324,
    -324,  -324,  -324,   319,  -324,   323,   324,   250,  -324,  -324,
    -324,  1521,  1454,  1480,   690,   690,   690,  -324,  -324,  -324,
    1210,  -324,  -324,  -324,  -324,  -324,  -324,  1143,   158,   690,
     161,   690,   185,   374,  -324,  -324,  -324,  -324,   328,  -324,
     690,  -324,   690,   690,  -324,  -324,  -324,  -324
};

  /* YYDEFACT[STATE-NUM] -- Default reduction number in state STATE-NUM.
     Performed when YYTABLE does not specify something else to do.  Zero
     means the default is an error.  */
static const yytype_uint8 yydefact[] =
{
       0,    98,   101,   141,   106,     0,    96,   105,   144,   103,
     104,    99,   142,   107,    97,   118,    95,   119,   108,   100,
     143,   102,   114,   109,   110,   111,     0,     0,     0,   237,
       0,    83,    85,   112,     0,   113,    87,    89,     4,   234,
     236,     0,   136,     0,     6,     7,     0,     5,     0,     1,
      81,     0,   160,   147,     0,    91,    93,   146,     0,    84,
      86,     0,   117,    88,    90,   235,   139,     0,   137,     0,
       2,     0,     0,     0,     0,    27,    32,    31,    30,    29,
      28,     9,    21,    33,     0,    35,    39,    42,    45,    50,
      53,    55,    57,    59,    61,    63,    65,    78,     0,     3,
       0,   164,   162,   161,    82,     0,     0,     0,   240,     0,
     239,     0,     0,     0,   145,   124,     0,   120,     0,   126,
       0,     0,   132,     0,     0,     0,    25,     0,    22,    23,
     175,     0,    15,    16,     0,     0,     0,     0,    74,    73,
      71,    72,    68,    69,    70,    75,    76,    77,    67,     0,
      33,    24,     0,     0,     0,     0,     0,     0,     0,     0,
       0,     0,     0,     0,     0,     0,     0,     0,     0,     0,
       0,     0,     8,   148,   165,   163,    92,    93,     0,     0,
       0,     0,     0,     0,     0,     0,     0,     0,     0,   218,
     212,     5,     0,   216,   217,   203,   204,     0,   214,   205,
     206,   207,   208,     0,   191,    94,   241,   238,   159,   173,
     172,     0,   166,   168,     0,     0,   156,    28,     0,     0,
     123,   116,   121,     0,     0,   127,   129,   125,     0,    80,
     140,   134,   138,   133,     0,     0,     0,     0,     0,   177,
     176,   178,     0,    14,    11,     0,    19,     0,    13,    66,
      36,    37,    38,    41,    40,    44,    43,    48,    49,    46,
      47,    51,    52,    54,    56,    58,    60,    62,     0,    79,
     231,     0,   230,     0,     0,     0,     0,     0,   232,     0,
       0,     0,     0,   219,   213,   215,     0,     0,   194,     0,
       0,     0,   199,     0,   170,   177,   171,   157,     0,     0,
     158,     0,   155,   151,     0,   150,    28,     0,   130,   122,
       0,     0,   115,   135,    26,     0,   187,     0,     0,   181,
      28,     0,   179,     0,     0,     0,    34,     0,    12,    10,
       0,     0,   211,     0,     0,     0,   229,     0,   233,     0,
       0,   209,     0,   202,   192,     0,   195,   198,   200,   167,
     169,   174,     0,     0,   154,   149,   128,   131,   188,   180,
     185,   182,   189,     0,   183,    28,     0,     0,    20,    64,
     210,     0,     0,     0,     0,     0,     0,   201,   193,   196,
       0,   152,   153,   190,   186,   184,    17,     0,     0,     0,
       0,     0,     0,   220,   222,   223,   197,    18,     0,   227,
       0,   225,     0,     0,   224,   228,   226,   221
};

  /* YYPGOTO[NTERM-NUM].  */
static const yytype_int16 yypgoto[] =
{
    -324,    63,   375,  -324,  -324,     2,  -324,   -26,   167,   171,
     103,   208,   242,   248,   237,   247,   236,  -324,  -102,  -104,
    -324,   -46,  -164,   -49,     1,  -324,   301,  -324,    17,  -324,
    -324,   296,  -110,    24,  -324,   107,  -324,   349,  -115,   -11,
    -324,   -25,   -56,   -35,   -95,  -101,  -324,   122,  -324,   148,
    -116,  -223,  -103,    94,  -323,  -324,   140,   -94,  -324,   -29,
    -324,   263,  -265,  -324,  -324,  -324,  -324,   423,  -324,  -324
};

  /* YYDEFGOTO[NTERM-NUM].  */
static const yytype_int16 yydefgoto[] =
{
      -1,    28,    81,    82,   245,    83,    84,    85,    86,    87,
      88,    89,    90,    91,    92,    93,    94,    95,    96,    97,
     149,   192,   230,    29,   109,    54,    55,    31,    32,    33,
      34,   116,   117,   118,   224,   225,    35,    67,    68,    36,
      37,   100,    57,    58,   103,   317,   212,   213,   214,   131,
     318,   241,   288,   289,   290,   291,   292,   194,   195,   196,
     197,   198,   199,   200,   201,   202,    38,    39,    40,   111
};

  /* YYTABLE[YYPACT[STATE-NUM]] -- What to do in state STATE-NUM.  If
     positive, shift that token.  If negative, reduce the rule whose
     number is the opposite.  If YYTABLE_NINF, syntax error.  */
static const yytype_int16 yytable[] =
{
      98,    30,   114,   204,   205,    56,   222,   108,   232,   218,
     335,   211,    44,    45,   240,   271,   322,   102,   219,   229,
     169,     3,   380,   104,    43,     3,   105,   110,    98,    41,
      61,   246,    59,    60,   231,    49,    12,    63,    64,    30,
      12,   101,    46,   313,    30,   249,    69,    20,   170,    30,
     119,    20,    42,    62,    66,   171,    66,   193,   151,   308,
      47,   329,   206,   119,   380,    66,   121,   269,   175,   372,
     373,    51,   322,   126,   128,   129,   120,   229,   115,    98,
     177,    98,   207,   165,   177,   293,   150,   238,   274,    53,
     247,   115,   174,   226,   296,   239,    52,   283,   130,   204,
     171,    50,   101,    53,   119,   119,    70,    51,   119,   119,
     112,    99,   113,   210,   119,   307,   119,    52,   222,   232,
     301,   229,   342,   150,   268,    53,   250,   251,   252,   159,
     160,   171,   115,   115,   321,   172,   115,   115,   166,   220,
     279,   299,   115,   227,   115,   300,   327,   357,   193,   130,
     328,   130,   161,   162,   150,   150,   150,   150,   150,   150,
     150,   150,   150,   150,   150,   150,   150,   150,   150,   150,
     150,   150,   237,   171,   238,   295,   167,   374,   223,   332,
      51,   150,    52,    51,   229,   294,   204,   346,   341,   293,
      52,   238,   171,    52,   122,   123,   375,   352,    53,    52,
     353,    53,   239,   309,   101,   173,   310,    53,   174,   229,
     347,   155,   156,   286,   171,   287,   326,   119,   376,   168,
     366,   204,   363,   368,   338,   150,   334,   171,   369,   171,
     242,   337,   171,   398,   339,   340,   400,   370,   210,   114,
     270,   204,   379,   243,   150,   115,   138,   139,   140,   141,
     142,   143,   144,   145,   146,   147,   171,   237,   295,   238,
     402,   248,   257,   258,   259,   260,   152,   153,   154,   323,
     107,   324,   148,   235,   272,   236,   204,   396,   157,   158,
     393,   394,   395,   204,   379,   226,   163,   164,   150,   273,
     174,   282,   233,   234,   210,   399,   276,   401,   275,   210,
     132,   133,   134,   171,   330,   277,   405,   280,   406,   407,
     344,   345,   281,   150,   297,   135,   298,   136,   311,   137,
     386,   387,   253,   254,   210,   388,   390,   392,   255,   256,
     302,   303,   150,     1,   178,   179,     2,   180,     3,   181,
     182,     4,   314,     5,     6,     7,   183,   184,   185,     8,
       9,    10,    11,    12,   186,    13,    71,    14,    15,   187,
      16,    17,    18,    19,    20,   188,    21,    22,    23,    24,
      25,   261,   262,    44,    45,   315,   331,   333,   336,   343,
     351,   325,   354,   355,   358,   360,   359,   403,    72,    73,
     361,   371,   377,   381,   383,   382,   404,   189,   106,   190,
     384,   385,    48,    74,   265,   267,   176,   263,    75,    76,
      77,    78,    79,    80,   264,   266,   228,   356,   124,   367,
     350,   191,     1,   178,   179,     2,   180,     3,   181,   182,
       4,   348,     5,     6,     7,   183,   184,   185,     8,     9,
      10,    11,    12,   186,    13,    71,    14,    15,   187,    16,
      17,    18,    19,    20,   188,    21,    22,    23,    24,    25,
     285,    65,    44,    45,     0,     0,     0,     0,     0,     0,
       0,     0,     0,     0,     0,     0,     0,    72,    73,     0,
       0,     0,     0,     0,     0,     0,   189,   106,   284,     0,
       0,     0,    74,     0,     0,     0,     0,    75,    76,    77,
      78,    79,    80,     1,     0,     0,     2,     0,     3,     0,
     191,     4,     0,     5,     6,     7,     0,     0,     0,     8,
       9,    10,    11,    12,     0,    13,    71,    14,    15,     0,
      16,    17,    18,    19,    20,     0,    21,    22,    23,    24,
      25,     0,     0,    44,    45,     0,     0,     0,     0,     0,
       0,     0,     0,     0,     0,     0,     0,     0,    72,    73,
       0,     0,     0,     0,     0,     0,     0,   189,     0,     0,
       0,     0,     0,    74,     0,     0,     0,     0,    75,    76,
      77,    78,    79,    80,     1,     0,     0,     2,     0,     3,
       0,    47,     4,     0,     5,     6,     7,     0,     0,     0,
       8,     9,    10,    11,    12,     0,    13,     0,    14,    15,
       0,    16,    17,    18,    19,    20,     0,    21,    22,    23,
      24,    25,     0,     0,     0,     0,     0,     0,     0,     0,
       0,     0,     0,     0,     0,     0,     0,     0,     0,     0,
       0,     0,     0,     0,     0,     0,     0,     0,     0,     0,
       0,     0,     0,     0,   293,   316,   238,     1,     0,     0,
       2,     0,     3,     0,    52,     4,     0,     5,     6,     7,
       0,     0,    53,     8,     9,    10,    11,    12,     0,    13,
       0,    14,    15,     0,    16,    17,    18,    19,    20,     0,
      21,    22,    23,    24,    25,   178,   179,     0,   180,     0,
     181,   182,     0,     0,     0,     0,     0,   183,   184,   185,
       0,     0,     0,     0,     0,   186,     0,    71,     0,     0,
     187,     0,     0,     0,     0,     0,   188,     0,   208,     0,
       0,     0,     0,     0,    44,    45,     0,     0,     0,     0,
       0,     0,     0,     0,     0,   209,     0,     0,     0,    72,
      73,     0,     0,     0,     0,     0,     0,     0,   189,   106,
       0,     0,     0,     0,    74,     0,     0,     0,     0,    75,
      76,    77,    78,    79,    80,     0,     2,     0,     3,     0,
       0,     4,   191,     5,     0,     7,     0,     0,     0,     0,
       9,    10,     0,    12,     0,    13,    71,     0,    15,     0,
       0,    17,    18,    19,    20,     3,    21,    22,    23,    24,
      25,     0,     0,    44,    45,     0,     0,     0,     0,     0,
      12,     0,     0,    71,   215,     0,     0,     0,    72,    73,
       0,    20,     0,     0,     0,     0,     0,     0,     0,     0,
      44,    45,     0,    74,     0,     0,     0,     0,    75,    76,
      77,    78,    79,    80,     0,    72,    73,     0,     0,     0,
       0,    47,     0,     0,     0,     0,     3,     0,     0,     0,
      74,     0,     0,   216,     0,    75,    76,    77,    78,    79,
     217,    12,     0,     0,    71,   304,     0,     0,    47,     0,
       0,     0,    20,     3,     0,     0,     0,     0,     0,     0,
       0,    44,    45,     0,     0,     0,     0,     0,    12,     0,
       0,    71,     0,     0,     0,     0,    72,    73,     0,    20,
       0,     0,     0,     0,     0,     0,     0,     0,    44,    45,
       0,    74,     0,     0,   305,     0,    75,    76,    77,    78,
      79,   306,     0,    72,    73,     0,     0,     0,     0,    47,
       0,     0,     0,     0,     0,     0,     0,     0,    74,     0,
       0,     0,     0,    75,    76,    77,    78,    79,    80,     1,
       0,     0,     2,     0,     3,     0,    47,     4,     0,     5,
       6,     7,     0,     0,     0,     8,     9,    10,    11,    12,
       0,    13,     0,    14,    15,     0,    16,    17,    18,    19,
      20,     0,    21,    22,    23,    24,    25,     0,     0,     0,
       0,     0,     0,     0,     0,     0,     0,     0,     0,     0,
       0,     0,     0,     0,     0,     0,     1,     0,     0,     2,
       0,     3,     0,     0,     4,     0,     5,     6,     7,   237,
     316,   238,     8,     9,    10,    11,    12,     0,    13,    52,
      14,    15,     0,    16,    17,    18,    19,    20,     0,    21,
      22,    23,    24,    25,     0,     1,     0,     0,     2,     0,
       3,     0,     0,     4,     0,     5,     6,     7,     0,     0,
       0,     8,     9,    10,    11,    12,     0,    13,     0,    14,
      15,     0,    16,    17,    18,    19,    20,   362,    21,    22,
      23,    24,    25,     0,     0,     0,     0,     0,     0,     0,
       0,     0,     0,     0,     0,     0,     0,     0,     0,     0,
       0,     1,     0,     0,     2,     0,     3,     0,     0,     4,
     106,     5,     6,     7,   107,     0,     0,     8,     9,    10,
      11,    12,    71,    13,     0,    14,    15,     0,    16,    17,
      18,    19,    20,     0,    21,    22,    23,    24,    25,    44,
      45,     0,     0,     0,     0,     0,     0,     0,     0,     0,
      71,     0,     0,     0,    72,    73,     0,     0,     0,     0,
       0,     0,     0,     0,   203,   378,   106,    44,    45,    74,
       0,   286,     0,   287,    75,    76,    77,    78,    79,    80,
       0,     0,    72,    73,     0,     0,     0,    47,     0,     0,
       0,    71,   203,   397,     0,     0,     0,    74,     0,   286,
       0,   287,    75,    76,    77,    78,    79,    80,    44,    45,
       0,     0,     0,     0,     0,    47,     0,    71,     0,     0,
       0,     0,     0,    72,    73,     0,     0,     0,     0,     0,
       0,     0,     0,   203,    44,    45,     0,     0,    74,     0,
     286,     0,   287,    75,    76,    77,    78,    79,    80,    72,
      73,     0,     0,     0,     0,     0,    47,     0,    71,   203,
       0,     0,     0,     0,    74,     0,     0,     0,     0,    75,
      76,    77,    78,    79,    80,    44,    45,     0,     0,     0,
       0,     0,    47,     0,    71,     0,     0,     0,     0,     0,
      72,    73,     0,     0,     0,     0,     0,     0,     0,     0,
       0,    44,    45,     0,     0,    74,   244,     0,     0,     0,
      75,    76,    77,    78,    79,    80,    72,    73,     0,     0,
       0,     0,     0,    47,     0,   278,    71,     0,     0,     0,
       0,    74,     0,     0,     0,     0,    75,    76,    77,    78,
      79,    80,     0,    44,    45,     0,     0,     0,     0,    47,
       0,     0,    71,     0,     0,     0,     0,     0,    72,    73,
       0,     0,     0,     0,     0,     0,     0,     0,     0,    44,
      45,     0,     0,    74,     0,     0,   319,     0,    75,    76,
      77,    78,    79,   320,    72,    73,     0,     0,     0,     0,
       0,    47,     0,    71,   325,     0,     0,     0,     0,    74,
       0,     0,     0,     0,    75,    76,    77,    78,    79,    80,
      44,    45,     0,     0,     0,     0,     0,    47,     0,    71,
       0,     0,     0,     0,     0,    72,    73,     0,     0,     0,
       0,     0,     0,     0,     0,     0,    44,    45,     0,     0,
      74,     0,     0,   364,     0,    75,    76,    77,    78,    79,
     365,    72,    73,     0,     0,     0,     0,     0,    47,     0,
     189,    71,     0,     0,     0,     0,    74,     0,     0,     0,
       0,    75,    76,    77,    78,    79,    80,     0,    44,    45,
       0,     0,     0,     0,    47,     0,     0,    71,     0,     0,
       0,     0,     0,    72,    73,     0,     0,     0,     0,     0,
       0,     0,     0,     0,    44,    45,     0,     0,    74,   389,
       0,     0,     0,    75,    76,    77,    78,    79,    80,    72,
      73,     0,     0,     0,     0,     0,    47,     0,    71,     0,
       0,     0,     0,     0,    74,   391,     0,     0,     0,    75,
      76,    77,    78,    79,    80,    44,    45,     0,     0,     0,
       0,     0,    47,     0,    71,     0,     0,     0,     0,     0,
      72,    73,     0,     0,     0,     0,     0,     0,     0,     0,
       0,    44,    45,     0,     0,    74,     0,     0,     0,     0,
      75,    76,    77,    78,    79,    80,    72,    73,     0,     0,
       0,     0,     0,    47,     0,    71,     0,     0,     0,     0,
       0,   125,     0,     0,     0,     0,    75,    76,    77,    78,
      79,    80,    44,    45,     0,     0,     0,     0,     0,    47,
       0,     0,     0,     0,     0,     0,     0,    72,    73,     0,
       0,     0,     0,     0,     0,     0,     0,     0,     0,     0,
       0,     0,   127,     0,     0,     0,     0,    75,    76,    77,
      78,    79,    80,     0,     2,     0,     3,     0,     0,     4,
      47,     5,     0,     7,     0,     0,     0,     0,     9,    10,
       0,    12,     0,    13,     0,     0,    15,     0,     0,    17,
      18,    19,    20,     0,    21,    22,    23,    24,    25,     0,
       0,     0,     0,     2,     0,     3,     0,     0,     4,     0,
       5,     0,     7,     0,     0,     0,     0,     9,    10,     0,
      12,     0,    13,     0,     0,    15,     0,   221,    17,    18,
      19,    20,     0,    21,    22,    23,    24,    25,     0,     0,
       1,     0,     0,     2,     0,     3,     0,     0,     4,     0,
       5,     6,     7,     0,     0,     0,     8,     9,    10,    11,
      12,     0,    13,     0,    14,    15,   312,    16,    17,    18,
      19,    20,     0,    21,    22,    23,    24,    25,     1,     0,
       0,     2,   349,     3,     0,     0,     4,     0,     5,     6,
       7,     0,     0,     0,     8,     9,    10,    11,    12,     0,
      13,     0,    14,    15,     0,    16,    17,    18,    19,    20,
       0,    21,    22,    23,    24,    25,    26,    27,     1,     0,
       0,     2,     0,     3,     0,     0,     4,     0,     5,     6,
       7,     0,     0,     0,     8,     9,    10,    11,    12,     0,
      13,     0,    14,    15,     0,    16,    17,    18,    19,    20,
       0,    21,    22,    23,    24,    25,     2,     0,     3,     0,
       0,     4,     0,     5,     0,     7,     0,     0,     0,     0,
       9,    10,     0,    12,     0,    13,     0,     0,    15,     0,
       0,    17,    18,    19,    20,     0,    21,    22,    23,    24,
      25
};

static const yytype_int16 yycheck[] =
{
      46,     0,    58,   107,   107,    30,   116,    56,   123,   113,
     275,   112,    44,    45,   130,   179,   239,    52,   113,   121,
      63,     9,   345,    68,    45,     9,    71,    56,    74,    69,
      69,   135,    31,    32,    70,     0,    24,    36,    37,    38,
      24,    52,    74,    70,    43,   149,    69,    35,    91,    48,
      61,    35,    92,    92,    92,    71,    92,   106,    84,   223,
      92,    77,   111,    74,   387,    92,    73,   171,   103,   334,
     335,    74,   295,    71,    72,    73,    69,   179,    61,   125,
     105,   127,   111,    79,   109,    74,    84,    76,   182,    92,
     136,    74,   103,   118,   210,   130,    84,    68,    74,   203,
      71,    68,   113,    92,   115,   116,    43,    74,   119,   120,
      74,    48,    76,   112,   125,   219,   127,    84,   228,   234,
     215,   223,   286,   121,   170,    92,   152,   153,   154,    64,
      65,    71,   115,   116,   238,    75,   119,   120,    89,   115,
     186,    71,   125,   119,   127,    75,    71,   311,   197,   125,
      75,   127,    87,    88,   152,   153,   154,   155,   156,   157,
     158,   159,   160,   161,   162,   163,   164,   165,   166,   167,
     168,   169,    74,    71,    76,   210,    90,    75,    72,   273,
      74,   179,    84,    74,   286,   210,   290,   290,   282,    74,
      84,    76,    71,    84,    70,    71,    75,   301,    92,    84,
     304,    92,   237,    68,   215,    75,    71,    92,   219,   311,
      73,    82,    83,    76,    71,    78,   242,   228,    75,    62,
     324,   325,   323,   327,    68,   223,   275,    71,   330,    71,
      75,   277,    71,    75,   280,   281,    75,   331,   237,   295,
      68,   345,   345,    92,   242,   228,    47,    48,    49,    50,
      51,    52,    53,    54,    55,    56,    71,    74,   293,    76,
      75,    92,   159,   160,   161,   162,    84,    85,    86,    74,
      73,    76,    73,   125,    68,   127,   380,   380,    57,    58,
     374,   375,   376,   387,   387,   310,    66,    67,   286,    72,
     301,    72,    70,    71,   293,   389,    92,   391,    74,   298,
      59,    60,    61,    71,    72,    74,   400,    74,   402,   403,
      70,    71,    74,   311,    75,    74,    71,    76,    72,    78,
      70,    71,   155,   156,   323,   371,   372,   373,   157,   158,
      77,    77,   330,     4,     5,     6,     7,     8,     9,    10,
      11,    12,    75,    14,    15,    16,    17,    18,    19,    20,
      21,    22,    23,    24,    25,    26,    27,    28,    29,    30,
      31,    32,    33,    34,    35,    36,    37,    38,    39,    40,
      41,   163,   164,    44,    45,    75,    72,    36,    68,    92,
      92,    69,    77,    77,    75,    77,    75,    13,    59,    60,
      77,    74,    77,    77,    75,    77,    68,    68,    69,    70,
      77,    77,    27,    74,   167,   169,   105,   165,    79,    80,
      81,    82,    83,    84,   166,   168,   120,   310,    69,   325,
     298,    92,     4,     5,     6,     7,     8,     9,    10,    11,
      12,   291,    14,    15,    16,    17,    18,    19,    20,    21,
      22,    23,    24,    25,    26,    27,    28,    29,    30,    31,
      32,    33,    34,    35,    36,    37,    38,    39,    40,    41,
     197,    38,    44,    45,    -1,    -1,    -1,    -1,    -1,    -1,
      -1,    -1,    -1,    -1,    -1,    -1,    -1,    59,    60,    -1,
      -1,    -1,    -1,    -1,    -1,    -1,    68,    69,    70,    -1,
      -1,    -1,    74,    -1,    -1,    -1,    -1,    79,    80,    81,
      82,    83,    84,     4,    -1,    -1,     7,    -1,     9,    -1,
      92,    12,    -1,    14,    15,    16,    -1,    -1,    -1,    20,
      21,    22,    23,    24,    -1,    26,    27,    28,    29,    -1,
      31,    32,    33,    34,    35,    -1,    37,    38,    39,    40,
      41,    -1,    -1,    44,    45,    -1,    -1,    -1,    -1,    -1,
      -1,    -1,    -1,    -1,    -1,    -1,    -1,    -1,    59,    60,
      -1,    -1,    -1,    -1,    -1,    -1,    -1,    68,    -1,    -1,
      -1,    -1,    -1,    74,    -1,    -1,    -1,    -1,    79,    80,
      81,    82,    83,    84,     4,    -1,    -1,     7,    -1,     9,
      -1,    92,    12,    -1,    14,    15,    16,    -1,    -1,    -1,
      20,    21,    22,    23,    24,    -1,    26,    -1,    28,    29,
      -1,    31,    32,    33,    34,    35,    -1,    37,    38,    39,
      40,    41,    -1,    -1,    -1,    -1,    -1,    -1,    -1,    -1,
      -1,    -1,    -1,    -1,    -1,    -1,    -1,    -1,    -1,    -1,
      -1,    -1,    -1,    -1,    -1,    -1,    -1,    -1,    -1,    -1,
      -1,    -1,    -1,    -1,    74,    75,    76,     4,    -1,    -1,
       7,    -1,     9,    -1,    84,    12,    -1,    14,    15,    16,
      -1,    -1,    92,    20,    21,    22,    23,    24,    -1,    26,
      -1,    28,    29,    -1,    31,    32,    33,    34,    35,    -1,
      37,    38,    39,    40,    41,     5,     6,    -1,     8,    -1,
      10,    11,    -1,    -1,    -1,    -1,    -1,    17,    18,    19,
      -1,    -1,    -1,    -1,    -1,    25,    -1,    27,    -1,    -1,
      30,    -1,    -1,    -1,    -1,    -1,    36,    -1,    75,    -1,
      -1,    -1,    -1,    -1,    44,    45,    -1,    -1,    -1,    -1,
      -1,    -1,    -1,    -1,    -1,    92,    -1,    -1,    -1,    59,
      60,    -1,    -1,    -1,    -1,    -1,    -1,    -1,    68,    69,
      -1,    -1,    -1,    -1,    74,    -1,    -1,    -1,    -1,    79,
      80,    81,    82,    83,    84,    -1,     7,    -1,     9,    -1,
      -1,    12,    92,    14,    -1,    16,    -1,    -1,    -1,    -1,
      21,    22,    -1,    24,    -1,    26,    27,    -1,    29,    -1,
      -1,    32,    33,    34,    35,     9,    37,    38,    39,    40,
      41,    -1,    -1,    44,    45,    -1,    -1,    -1,    -1,    -1,
      24,    -1,    -1,    27,    28,    -1,    -1,    -1,    59,    60,
      -1,    35,    -1,    -1,    -1,    -1,    -1,    -1,    -1,    -1,
      44,    45,    -1,    74,    -1,    -1,    -1,    -1,    79,    80,
      81,    82,    83,    84,    -1,    59,    60,    -1,    -1,    -1,
      -1,    92,    -1,    -1,    -1,    -1,     9,    -1,    -1,    -1,
      74,    -1,    -1,    77,    -1,    79,    80,    81,    82,    83,
      84,    24,    -1,    -1,    27,    28,    -1,    -1,    92,    -1,
      -1,    -1,    35,     9,    -1,    -1,    -1,    -1,    -1,    -1,
      -1,    44,    45,    -1,    -1,    -1,    -1,    -1,    24,    -1,
      -1,    27,    -1,    -1,    -1,    -1,    59,    60,    -1,    35,
      -1,    -1,    -1,    -1,    -1,    -1,    -1,    -1,    44,    45,
      -1,    74,    -1,    -1,    77,    -1,    79,    80,    81,    82,
      83,    84,    -1,    59,    60,    -1,    -1,    -1,    -1,    92,
      -1,    -1,    -1,    -1,    -1,    -1,    -1,    -1,    74,    -1,
      -1,    -1,    -1,    79,    80,    81,    82,    83,    84,     4,
      -1,    -1,     7,    -1,     9,    -1,    92,    12,    -1,    14,
      15,    16,    -1,    -1,    -1,    20,    21,    22,    23,    24,
      -1,    26,    -1,    28,    29,    -1,    31,    32,    33,    34,
      35,    -1,    37,    38,    39,    40,    41,    -1,    -1,    -1,
      -1,    -1,    -1,    -1,    -1,    -1,    -1,    -1,    -1,    -1,
      -1,    -1,    -1,    -1,    -1,    -1,     4,    -1,    -1,     7,
      -1,     9,    -1,    -1,    12,    -1,    14,    15,    16,    74,
      75,    76,    20,    21,    22,    23,    24,    -1,    26,    84,
      28,    29,    -1,    31,    32,    33,    34,    35,    -1,    37,
      38,    39,    40,    41,    -1,     4,    -1,    -1,     7,    -1,
       9,    -1,    -1,    12,    -1,    14,    15,    16,    -1,    -1,
      -1,    20,    21,    22,    23,    24,    -1,    26,    -1,    28,
      29,    -1,    31,    32,    33,    34,    35,    75,    37,    38,
      39,    40,    41,    -1,    -1,    -1,    -1,    -1,    -1,    -1,
      -1,    -1,    -1,    -1,    -1,    -1,    -1,    -1,    -1,    -1,
      -1,     4,    -1,    -1,     7,    -1,     9,    -1,    -1,    12,
      69,    14,    15,    16,    73,    -1,    -1,    20,    21,    22,
      23,    24,    27,    26,    -1,    28,    29,    -1,    31,    32,
      33,    34,    35,    -1,    37,    38,    39,    40,    41,    44,
      45,    -1,    -1,    -1,    -1,    -1,    -1,    -1,    -1,    -1,
      27,    -1,    -1,    -1,    59,    60,    -1,    -1,    -1,    -1,
      -1,    -1,    -1,    -1,    69,    70,    69,    44,    45,    74,
      -1,    76,    -1,    78,    79,    80,    81,    82,    83,    84,
      -1,    -1,    59,    60,    -1,    -1,    -1,    92,    -1,    -1,
      -1,    27,    69,    70,    -1,    -1,    -1,    74,    -1,    76,
      -1,    78,    79,    80,    81,    82,    83,    84,    44,    45,
      -1,    -1,    -1,    -1,    -1,    92,    -1,    27,    -1,    -1,
      -1,    -1,    -1,    59,    60,    -1,    -1,    -1,    -1,    -1,
      -1,    -1,    -1,    69,    44,    45,    -1,    -1,    74,    -1,
      76,    -1,    78,    79,    80,    81,    82,    83,    84,    59,
      60,    -1,    -1,    -1,    -1,    -1,    92,    -1,    27,    69,
      -1,    -1,    -1,    -1,    74,    -1,    -1,    -1,    -1,    79,
      80,    81,    82,    83,    84,    44,    45,    -1,    -1,    -1,
      -1,    -1,    92,    -1,    27,    -1,    -1,    -1,    -1,    -1,
      59,    60,    -1,    -1,    -1,    -1,    -1,    -1,    -1,    -1,
      -1,    44,    45,    -1,    -1,    74,    75,    -1,    -1,    -1,
      79,    80,    81,    82,    83,    84,    59,    60,    -1,    -1,
      -1,    -1,    -1,    92,    -1,    68,    27,    -1,    -1,    -1,
      -1,    74,    -1,    -1,    -1,    -1,    79,    80,    81,    82,
      83,    84,    -1,    44,    45,    -1,    -1,    -1,    -1,    92,
      -1,    -1,    27,    -1,    -1,    -1,    -1,    -1,    59,    60,
      -1,    -1,    -1,    -1,    -1,    -1,    -1,    -1,    -1,    44,
      45,    -1,    -1,    74,    -1,    -1,    77,    -1,    79,    80,
      81,    82,    83,    84,    59,    60,    -1,    -1,    -1,    -1,
      -1,    92,    -1,    27,    69,    -1,    -1,    -1,    -1,    74,
      -1,    -1,    -1,    -1,    79,    80,    81,    82,    83,    84,
      44,    45,    -1,    -1,    -1,    -1,    -1,    92,    -1,    27,
      -1,    -1,    -1,    -1,    -1,    59,    60,    -1,    -1,    -1,
      -1,    -1,    -1,    -1,    -1,    -1,    44,    45,    -1,    -1,
      74,    -1,    -1,    77,    -1,    79,    80,    81,    82,    83,
      84,    59,    60,    -1,    -1,    -1,    -1,    -1,    92,    -1,
      68,    27,    -1,    -1,    -1,    -1,    74,    -1,    -1,    -1,
      -1,    79,    80,    81,    82,    83,    84,    -1,    44,    45,
      -1,    -1,    -1,    -1,    92,    -1,    -1,    27,    -1,    -1,
      -1,    -1,    -1,    59,    60,    -1,    -1,    -1,    -1,    -1,
      -1,    -1,    -1,    -1,    44,    45,    -1,    -1,    74,    75,
      -1,    -1,    -1,    79,    80,    81,    82,    83,    84,    59,
      60,    -1,    -1,    -1,    -1,    -1,    92,    -1,    27,    -1,
      -1,    -1,    -1,    -1,    74,    75,    -1,    -1,    -1,    79,
      80,    81,    82,    83,    84,    44,    45,    -1,    -1,    -1,
      -1,    -1,    92,    -1,    27,    -1,    -1,    -1,    -1,    -1,
      59,    60,    -1,    -1,    -1,    -1,    -1,    -1,    -1,    -1,
      -1,    44,    45,    -1,    -1,    74,    -1,    -1,    -1,    -1,
      79,    80,    81,    82,    83,    84,    59,    60,    -1,    -1,
      -1,    -1,    -1,    92,    -1,    27,    -1,    -1,    -1,    -1,
      -1,    74,    -1,    -1,    -1,    -1,    79,    80,    81,    82,
      83,    84,    44,    45,    -1,    -1,    -1,    -1,    -1,    92,
      -1,    -1,    -1,    -1,    -1,    -1,    -1,    59,    60,    -1,
      -1,    -1,    -1,    -1,    -1,    -1,    -1,    -1,    -1,    -1,
      -1,    -1,    74,    -1,    -1,    -1,    -1,    79,    80,    81,
      82,    83,    84,    -1,     7,    -1,     9,    -1,    -1,    12,
      92,    14,    -1,    16,    -1,    -1,    -1,    -1,    21,    22,
      -1,    24,    -1,    26,    -1,    -1,    29,    -1,    -1,    32,
      33,    34,    35,    -1,    37,    38,    39,    40,    41,    -1,
      -1,    -1,    -1,     7,    -1,     9,    -1,    -1,    12,    -1,
      14,    -1,    16,    -1,    -1,    -1,    -1,    21,    22,    -1,
      24,    -1,    26,    -1,    -1,    29,    -1,    70,    32,    33,
      34,    35,    -1,    37,    38,    39,    40,    41,    -1,    -1,
       4,    -1,    -1,     7,    -1,     9,    -1,    -1,    12,    -1,
      14,    15,    16,    -1,    -1,    -1,    20,    21,    22,    23,
      24,    -1,    26,    -1,    28,    29,    70,    31,    32,    33,
      34,    35,    -1,    37,    38,    39,    40,    41,     4,    -1,
      -1,     7,    46,     9,    -1,    -1,    12,    -1,    14,    15,
      16,    -1,    -1,    -1,    20,    21,    22,    23,    24,    -1,
      26,    -1,    28,    29,    -1,    31,    32,    33,    34,    35,
      -1,    37,    38,    39,    40,    41,    42,    43,     4,    -1,
      -1,     7,    -1,     9,    -1,    -1,    12,    -1,    14,    15,
      16,    -1,    -1,    -1,    20,    21,    22,    23,    24,    -1,
      26,    -1,    28,    29,    -1,    31,    32,    33,    34,    35,
      -1,    37,    38,    39,    40,    41,     7,    -1,     9,    -1,
      -1,    12,    -1,    14,    -1,    16,    -1,    -1,    -1,    -1,
      21,    22,    -1,    24,    -1,    26,    -1,    -1,    29,    -1,
      -1,    32,    33,    34,    35,    -1,    37,    38,    39,    40,
      41
};

  /* YYSTOS[STATE-NUM] -- The (internal number of the) accessing
     symbol of state STATE-NUM.  */
static const yytype_uint8 yystos[] =
{
       0,     4,     7,     9,    12,    14,    15,    16,    20,    21,
      22,    23,    24,    26,    28,    29,    31,    32,    33,    34,
      35,    37,    38,    39,    40,    41,    42,    43,    94,   116,
     117,   120,   121,   122,   123,   129,   132,   133,   159,   160,
     161,    69,    92,    45,    44,    45,    74,    92,    95,     0,
      68,    74,    84,    92,   118,   119,   134,   135,   136,   117,
     117,    69,    92,   117,   117,   160,    92,   130,   131,    69,
      94,    27,    59,    60,    74,    79,    80,    81,    82,    83,
      84,    95,    96,    98,    99,   100,   101,   102,   103,   104,
     105,   106,   107,   108,   109,   110,   111,   112,   114,    94,
     134,   132,   136,   137,    68,    71,    69,    73,   116,   117,
     152,   162,    74,    76,   135,   121,   124,   125,   126,   132,
      69,    73,    70,    71,   130,    74,    98,    74,    98,    98,
     126,   142,    59,    60,    61,    74,    76,    78,    47,    48,
      49,    50,    51,    52,    53,    54,    55,    56,    73,   113,
      98,   100,    84,    85,    86,    82,    83,    57,    58,    64,
      65,    87,    88,    66,    67,    79,    89,    90,    62,    63,
      91,    71,    75,    75,   132,   136,   119,   134,     5,     6,
       8,    10,    11,    17,    18,    19,    25,    30,    36,    68,
      70,    92,   114,   116,   150,   151,   152,   153,   154,   155,
     156,   157,   158,    69,   112,   145,   116,   152,    75,    92,
     117,   138,   139,   140,   141,    28,    77,    84,   112,   137,
     126,    70,   125,    72,   127,   128,   134,   126,   124,   111,
     115,    70,   131,    70,    71,   142,   142,    74,    76,   136,
     143,   144,    75,    92,    75,    97,   112,   114,    92,   112,
     100,   100,   100,   101,   101,   102,   102,   103,   103,   103,
     103,   104,   104,   105,   106,   107,   108,   109,   114,   112,
      68,   115,    68,    72,   150,    74,    92,    74,    68,   114,
      74,    74,    72,    68,    70,   154,    76,    78,   145,   146,
     147,   148,   149,    74,   134,   136,   143,    75,    71,    71,
      75,   137,    77,    77,    28,    77,    84,   112,   115,    68,
      71,    72,    70,    70,    75,    75,    75,   138,   143,    77,
      84,   112,   144,    74,    76,    69,   100,    71,    75,    77,
      72,    72,   150,    36,   116,   155,    68,   114,    68,   114,
     114,   150,   115,    92,    70,    71,   145,    73,   149,    46,
     140,    92,   112,   112,    77,    77,   128,   115,    75,    75,
      77,    77,    75,   138,    77,    84,   112,   146,   112,   111,
     150,    74,   155,   155,    75,    75,    75,    77,    70,   145,
     147,    77,    77,    75,    77,    77,    70,    71,   114,    75,
     114,    75,   114,   150,   150,   150,   145,    70,    75,   150,
      75,   150,    75,    13,    68,   150,   150,   150
};

  /* YYR1[YYN] -- Symbol number of symbol that rule YYN derives.  */
static const yytype_uint8 yyr1[] =
{
       0,    93,    94,    94,    94,    95,    95,    95,    95,    96,
      96,    96,    96,    96,    96,    96,    96,    96,    96,    97,
      97,    98,    98,    98,    98,    98,    98,    99,    99,    99,
      99,    99,    99,   100,   100,   101,   101,   101,   101,   102,
     102,   102,   103,   103,   103,   104,   104,   104,   104,   104,
     105,   105,   105,   106,   106,   107,   107,   108,   108,   109,
     109,   110,   110,   111,   111,   112,   112,   113,   113,   113,
     113,   113,   113,   113,   113,   113,   113,   113,   114,   114,
     115,   116,   116,   117,   117,   117,   117,   117,   117,   117,
     117,   118,   118,   119,   119,   120,   120,   120,   120,   120,
     121,   121,   121,   121,   121,   121,   121,   121,   121,   121,
     121,   121,   121,   121,   121,   122,   122,   122,   123,   123,
     124,   124,   125,   126,   126,   126,   126,   127,   127,   128,
     128,   128,   129,   129,   129,   129,   129,   130,   130,   131,
     131,   132,   132,   132,   133,   134,   134,   135,   135,   135,
     135,   135,   135,   135,   135,   135,   135,   135,   135,   135,
     136,   136,   136,   136,   137,   137,   138,   138,   139,   139,
     140,   140,   140,   141,   141,   142,   142,   143,   143,   143,
     144,   144,   144,   144,   144,   144,   144,   144,   144,   144,
     144,   145,   145,   145,   146,   146,   146,   146,   147,   148,
     148,   149,   149,   150,   150,   150,   150,   150,   150,   151,
     151,   151,   152,   152,   153,   153,   154,   154,   155,   155,
     156,   156,   156,   157,   157,   157,   157,   157,   157,   158,
     158,   158,   158,   158,   159,   159,   160,   160,   161,   161,
     162,   162
};

  /* YYR2[YYN] -- Number of symbols on the right hand side of rule YYN.  */
static const yytype_int8 yyr2[] =
{
       0,     2,     3,     3,     1,     1,     1,     1,     3,     1,
       4,     3,     4,     3,     3,     2,     2,     6,     7,     1,
       3,     1,     2,     2,     2,     2,     4,     1,     1,     1,
       1,     1,     1,     1,     4,     1,     3,     3,     3,     1,
       3,     3,     1,     3,     3,     1,     3,     3,     3,     3,
       1,     3,     3,     1,     3,     1,     3,     1,     3,     1,
       3,     1,     3,     1,     5,     1,     3,     1,     1,     1,
       1,     1,     1,     1,     1,     1,     1,     1,     1,     3,
       1,     2,     3,     1,     2,     1,     2,     1,     2,     1,
       2,     1,     3,     1,     3,     1,     1,     1,     1,     1,
       1,     1,     1,     1,     1,     1,     1,     1,     1,     1,
       1,     1,     1,     1,     1,     5,     4,     2,     1,     1,
       1,     2,     3,     2,     1,     2,     1,     1,     3,     1,
       2,     3,     4,     5,     5,     6,     2,     1,     3,     1,
       3,     1,     1,     1,     1,     2,     1,     1,     3,     5,
       4,     4,     6,     6,     5,     4,     3,     4,     4,     3,
       1,     2,     2,     3,     1,     2,     1,     3,     1,     3,
       2,     2,     1,     1,     3,     1,     2,     1,     1,     2,
       3,     2,     3,     3,     4,     3,     4,     2,     3,     3,
       4,     1,     3,     4,     1,     2,     3,     4,     2,     1,
       2,     3,     2,     1,     1,     1,     1,     1,     1,     3,
       4,     3,     2,     3,     1,     2,     1,     1,     1,     2,
       5,     7,     5,     5,     7,     6,     7,     6,     7,     3,
       2,     2,     2,     3,     1,     2,     1,     1,     4,     3,
       1,     2
};


enum { YYENOMEM = -2 };

#define yyerrok         (yyerrstatus = 0)
#define yyclearin       (yychar = YYEMPTY)

#define YYACCEPT        goto yyacceptlab
#define YYABORT         goto yyabortlab
#define YYERROR         goto yyerrorlab


#define YYRECOVERING()  (!!yyerrstatus)

#define YYBACKUP(Token, Value)                                    \
  do                                                              \
    if (yychar == YYEMPTY)                                        \
      {                                                           \
        yychar = (Token);                                         \
        yylval = (Value);                                         \
        YYPOPSTACK (yylen);                                       \
        yystate = *yyssp;                                         \
        goto yybackup;                                            \
      }                                                           \
    else                                                          \
      {                                                           \
        yyerror (YY_("syntax error: cannot back up")); \
        YYERROR;                                                  \
      }                                                           \
  while (0)

/* Backward compatibility with an undocumented macro.
   Use YYerror or YYUNDEF. */
#define YYERRCODE YYUNDEF


/* Enable debugging if requested.  */
#if YYDEBUG

# ifndef YYFPRINTF
#  include <stdio.h> /* INFRINGES ON USER NAME SPACE */
#  define YYFPRINTF fprintf
# endif

# define YYDPRINTF(Args)                        \
do {                                            \
  if (yydebug)                                  \
    YYFPRINTF Args;                             \
} while (0)

/* This macro is provided for backward compatibility. */
# ifndef YY_LOCATION_PRINT
#  define YY_LOCATION_PRINT(File, Loc) ((void) 0)
# endif


# define YY_SYMBOL_PRINT(Title, Kind, Value, Location)                    \
do {                                                                      \
  if (yydebug)                                                            \
    {                                                                     \
      YYFPRINTF (stderr, "%s ", Title);                                   \
      yy_symbol_print (stderr,                                            \
                  Kind, Value); \
      YYFPRINTF (stderr, "\n");                                           \
    }                                                                     \
} while (0)


/*-----------------------------------.
| Print this symbol's value on YYO.  |
`-----------------------------------*/

static void
yy_symbol_value_print (FILE *yyo,
                       yysymbol_kind_t yykind, YYSTYPE const * const yyvaluep)
{
  FILE *yyoutput = yyo;
  YYUSE (yyoutput);
  if (!yyvaluep)
    return;
# ifdef YYPRINT
  if (yykind < YYNTOKENS)
    YYPRINT (yyo, yytoknum[yykind], *yyvaluep);
# endif
  YY_IGNORE_MAYBE_UNINITIALIZED_BEGIN
  YYUSE (yykind);
  YY_IGNORE_MAYBE_UNINITIALIZED_END
}


/*---------------------------.
| Print this symbol on YYO.  |
`---------------------------*/

static void
yy_symbol_print (FILE *yyo,
                 yysymbol_kind_t yykind, YYSTYPE const * const yyvaluep)
{
  YYFPRINTF (yyo, "%s %s (",
             yykind < YYNTOKENS ? "token" : "nterm", yysymbol_name (yykind));

  yy_symbol_value_print (yyo, yykind, yyvaluep);
  YYFPRINTF (yyo, ")");
}

/*------------------------------------------------------------------.
| yy_stack_print -- Print the state stack from its BOTTOM up to its |
| TOP (included).                                                   |
`------------------------------------------------------------------*/

static void
yy_stack_print (yy_state_t *yybottom, yy_state_t *yytop)
{
  YYFPRINTF (stderr, "Stack now");
  for (; yybottom <= yytop; yybottom++)
    {
      int yybot = *yybottom;
      YYFPRINTF (stderr, " %d", yybot);
    }
  YYFPRINTF (stderr, "\n");
}

# define YY_STACK_PRINT(Bottom, Top)                            \
do {                                                            \
  if (yydebug)                                                  \
    yy_stack_print ((Bottom), (Top));                           \
} while (0)


/*------------------------------------------------.
| Report that the YYRULE is going to be reduced.  |
`------------------------------------------------*/

static void
yy_reduce_print (yy_state_t *yyssp, YYSTYPE *yyvsp,
                 int yyrule)
{
  int yylno = yyrline[yyrule];
  int yynrhs = yyr2[yyrule];
  int yyi;
  YYFPRINTF (stderr, "Reducing stack by rule %d (line %d):\n",
             yyrule - 1, yylno);
  /* The symbols being reduced.  */
  for (yyi = 0; yyi < yynrhs; yyi++)
    {
      YYFPRINTF (stderr, "   $%d = ", yyi + 1);
      yy_symbol_print (stderr,
                       YY_ACCESSING_SYMBOL (+yyssp[yyi + 1 - yynrhs]),
                       &yyvsp[(yyi + 1) - (yynrhs)]);
      YYFPRINTF (stderr, "\n");
    }
}

# define YY_REDUCE_PRINT(Rule)          \
do {                                    \
  if (yydebug)                          \
    yy_reduce_print (yyssp, yyvsp, Rule); \
} while (0)

/* Nonzero means print parse trace.  It is left uninitialized so that
   multiple parsers can coexist.  */
int yydebug;
#else /* !YYDEBUG */
# define YYDPRINTF(Args) ((void) 0)
# define YY_SYMBOL_PRINT(Title, Kind, Value, Location)
# define YY_STACK_PRINT(Bottom, Top)
# define YY_REDUCE_PRINT(Rule)
#endif /* !YYDEBUG */


/* YYINITDEPTH -- initial size of the parser's stacks.  */
#ifndef YYINITDEPTH
# define YYINITDEPTH 200
#endif

/* YYMAXDEPTH -- maximum size the stacks can grow to (effective only
   if the built-in stack extension method is used).

   Do not make this value too large; the results are undefined if
   YYSTACK_ALLOC_MAXIMUM < YYSTACK_BYTES (YYMAXDEPTH)
   evaluated with infinite-precision integer arithmetic.  */

#ifndef YYMAXDEPTH
# define YYMAXDEPTH 10000
#endif






/*-----------------------------------------------.
| Release the memory associated to this symbol.  |
`-----------------------------------------------*/

static void
yydestruct (const char *yymsg,
            yysymbol_kind_t yykind, YYSTYPE *yyvaluep)
{
  YYUSE (yyvaluep);
  if (!yymsg)
    yymsg = "Deleting";
  YY_SYMBOL_PRINT (yymsg, yykind, yyvaluep, yylocationp);

  YY_IGNORE_MAYBE_UNINITIALIZED_BEGIN
  YYUSE (yykind);
  YY_IGNORE_MAYBE_UNINITIALIZED_END
}


/* Lookahead token kind.  */
int yychar;

/* The semantic value of the lookahead symbol.  */
YYSTYPE yylval;
/* Number of syntax errors so far.  */
int yynerrs;




/*----------.
| yyparse.  |
`----------*/

int
yyparse (void)
{
    yy_state_fast_t yystate = 0;
    /* Number of tokens to shift before error messages enabled.  */
    int yyerrstatus = 0;

    /* Refer to the stacks through separate pointers, to allow yyoverflow
       to reallocate them elsewhere.  */

    /* Their size.  */
    YYPTRDIFF_T yystacksize = YYINITDEPTH;

    /* The state stack: array, bottom, top.  */
    yy_state_t yyssa[YYINITDEPTH];
    yy_state_t *yyss = yyssa;
    yy_state_t *yyssp = yyss;

    /* The semantic value stack: array, bottom, top.  */
    YYSTYPE yyvsa[YYINITDEPTH];
    YYSTYPE *yyvs = yyvsa;
    YYSTYPE *yyvsp = yyvs;

  int yyn;
  /* The return value of yyparse.  */
  int yyresult;
  /* Lookahead symbol kind.  */
  yysymbol_kind_t yytoken = YYSYMBOL_YYEMPTY;
  /* The variables used to return semantic value and location from the
     action routines.  */
  YYSTYPE yyval;



#define YYPOPSTACK(N)   (yyvsp -= (N), yyssp -= (N))

  /* The number of symbols on the RHS of the reduced rule.
     Keep to zero when no symbol should be popped.  */
  int yylen = 0;

  YYDPRINTF ((stderr, "Starting parse\n"));

  yychar = YYEMPTY; /* Cause a token to be read.  */
  goto yysetstate;


/*------------------------------------------------------------.
| yynewstate -- push a new state, which is found in yystate.  |
`------------------------------------------------------------*/
yynewstate:
  /* In all cases, when you get here, the value and location stacks
     have just been pushed.  So pushing a state here evens the stacks.  */
  yyssp++;


/*--------------------------------------------------------------------.
| yysetstate -- set current state (the top of the stack) to yystate.  |
`--------------------------------------------------------------------*/
yysetstate:
  YYDPRINTF ((stderr, "Entering state %d\n", yystate));
  YY_ASSERT (0 <= yystate && yystate < YYNSTATES);
  YY_IGNORE_USELESS_CAST_BEGIN
  *yyssp = YY_CAST (yy_state_t, yystate);
  YY_IGNORE_USELESS_CAST_END
  YY_STACK_PRINT (yyss, yyssp);

  if (yyss + yystacksize - 1 <= yyssp)
#if !defined yyoverflow && !defined YYSTACK_RELOCATE
    goto yyexhaustedlab;
#else
    {
      /* Get the current used size of the three stacks, in elements.  */
      YYPTRDIFF_T yysize = yyssp - yyss + 1;

# if defined yyoverflow
      {
        /* Give user a chance to reallocate the stack.  Use copies of
           these so that the &'s don't force the real ones into
           memory.  */
        yy_state_t *yyss1 = yyss;
        YYSTYPE *yyvs1 = yyvs;

        /* Each stack pointer address is followed by the size of the
           data in use in that stack, in bytes.  This used to be a
           conditional around just the two extra args, but that might
           be undefined if yyoverflow is a macro.  */
        yyoverflow (YY_("memory exhausted"),
                    &yyss1, yysize * YYSIZEOF (*yyssp),
                    &yyvs1, yysize * YYSIZEOF (*yyvsp),
                    &yystacksize);
        yyss = yyss1;
        yyvs = yyvs1;
      }
# else /* defined YYSTACK_RELOCATE */
      /* Extend the stack our own way.  */
      if (YYMAXDEPTH <= yystacksize)
        goto yyexhaustedlab;
      yystacksize *= 2;
      if (YYMAXDEPTH < yystacksize)
        yystacksize = YYMAXDEPTH;

      {
        yy_state_t *yyss1 = yyss;
        union yyalloc *yyptr =
          YY_CAST (union yyalloc *,
                   YYSTACK_ALLOC (YY_CAST (YYSIZE_T, YYSTACK_BYTES (yystacksize))));
        if (! yyptr)
          goto yyexhaustedlab;
        YYSTACK_RELOCATE (yyss_alloc, yyss);
        YYSTACK_RELOCATE (yyvs_alloc, yyvs);
#  undef YYSTACK_RELOCATE
        if (yyss1 != yyssa)
          YYSTACK_FREE (yyss1);
      }
# endif

      yyssp = yyss + yysize - 1;
      yyvsp = yyvs + yysize - 1;

      YY_IGNORE_USELESS_CAST_BEGIN
      YYDPRINTF ((stderr, "Stack size increased to %ld\n",
                  YY_CAST (long, yystacksize)));
      YY_IGNORE_USELESS_CAST_END

      if (yyss + yystacksize - 1 <= yyssp)
        YYABORT;
    }
#endif /* !defined yyoverflow && !defined YYSTACK_RELOCATE */

  if (yystate == YYFINAL)
    YYACCEPT;

  goto yybackup;


/*-----------.
| yybackup.  |
`-----------*/
yybackup:
  /* Do appropriate processing given the current state.  Read a
     lookahead token if we need one and don't already have one.  */

  /* First try to decide what to do without reference to lookahead token.  */
  yyn = yypact[yystate];
  if (yypact_value_is_default (yyn))
    goto yydefault;

  /* Not known => get a lookahead token if don't already have one.  */

  /* YYCHAR is either empty, or end-of-input, or a valid lookahead.  */
  if (yychar == YYEMPTY)
    {
      YYDPRINTF ((stderr, "Reading a token\n"));
      yychar = yylex ();
    }

  if (yychar <= YYEOF)
    {
      yychar = YYEOF;
      yytoken = YYSYMBOL_YYEOF;
      YYDPRINTF ((stderr, "Now at end of input.\n"));
    }
  else if (yychar == YYerror)
    {
      /* The scanner already issued an error message, process directly
         to error recovery.  But do not keep the error token as
         lookahead, it is too special and may lead us to an endless
         loop in error recovery. */
      yychar = YYUNDEF;
      yytoken = YYSYMBOL_YYerror;
      goto yyerrlab1;
    }
  else
    {
      yytoken = YYTRANSLATE (yychar);
      YY_SYMBOL_PRINT ("Next token is", yytoken, &yylval, &yylloc);
    }

  /* If the proper action on seeing token YYTOKEN is to reduce or to
     detect an error, take that action.  */
  yyn += yytoken;
  if (yyn < 0 || YYLAST < yyn || yycheck[yyn] != yytoken)
    goto yydefault;
  yyn = yytable[yyn];
  if (yyn <= 0)
    {
      if (yytable_value_is_error (yyn))
        goto yyerrlab;
      yyn = -yyn;
      goto yyreduce;
    }

  /* Count tokens shifted since error; after three, turn off error
     status.  */
  if (yyerrstatus)
    yyerrstatus--;

  /* Shift the lookahead token.  */
  YY_SYMBOL_PRINT ("Shifting", yytoken, &yylval, &yylloc);
  yystate = yyn;
  YY_IGNORE_MAYBE_UNINITIALIZED_BEGIN
  *++yyvsp = yylval;
  YY_IGNORE_MAYBE_UNINITIALIZED_END

  /* Discard the shifted token.  */
  yychar = YYEMPTY;
  goto yynewstate;


/*-----------------------------------------------------------.
| yydefault -- do the default action for the current state.  |
`-----------------------------------------------------------*/
yydefault:
  yyn = yydefact[yystate];
  if (yyn == 0)
    goto yyerrlab;
  goto yyreduce;


/*-----------------------------.
| yyreduce -- do a reduction.  |
`-----------------------------*/
yyreduce:
  /* yyn is the number of a rule to reduce with.  */
  yylen = yyr2[yyn];

  /* If YYLEN is nonzero, implement the default value of the action:
     '$$ = $1'.

     Otherwise, the following line sets YYVAL to garbage.
     This behavior is undocumented and Bison
     users should not rely upon it.  Assigning to YYVAL
     unconditionally makes the parser a bit smaller, and it avoids a
     GCC warning that YYVAL may be used uninitialized.  */
  yyval = yyvsp[1-yylen];


  YY_REDUCE_PRINT (yyn);
  switch (yyn)
    {
  case 2: /* program_unit: HEADER STRING_LITERAL program_unit  */
#line 187 "c.y"
                                                                { (yyval.node)=(yyvsp[0].node); addLinkToList((yyval.node),CreateHeaderNode(CreateStringLiteralNode((yyvsp[-1].strings)))); }
#line 1849 "c.tab.c"
    break;

  case 3: /* program_unit: DEFINE primary_expression program_unit  */
#line 188 "c.y"
                                                                { (yyval.node)=(yyvsp[0].node); addLinkToList((yyval.node),CreateDefineNode((yyvsp[-1].node))); }
#line 1855 "c.tab.c"
    break;

  case 4: /* program_unit: translation_unit  */
#line 189 "c.y"
                                                                                        { (yyval.node) = CreateProgramUnitNode((yyvsp[0].node)); astRoot = (yyval.node); }
#line 1861 "c.tab.c"
    break;

  case 5: /* primary_expression: IDENTIFIER  */
#line 193 "c.y"
                                                                                { (yyval.node) = CreatePrimaryExpressionNode(CreateIdentifierNode((yyvsp[0].strings))); }
#line 1867 "c.tab.c"
    break;

  case 6: /* primary_expression: CONSTANT  */
#line 194 "c.y"
                                                                                        { (yyval.node) = CreatePrimaryExpressionNode(CreateConstantNode((yyvsp[0].strings))); }
#line 1873 "c.tab.c"
    break;

  case 7: /* primary_expression: STRING_LITERAL  */
#line 195 "c.y"
                                                                                { (yyval.node) = CreatePrimaryExpressionNode(CreateStringLiteralNode((yyvsp[0].strings))); }
#line 1879 "c.tab.c"
    break;

  case 8: /* primary_expression: LEFT_PARANTH expression RIGHT_PARANTH  */
#line 196 "c.y"
                                                        { (yyval.node) = CreatePrimaryExpressionNode((yyvsp[-1].node));}
#line 1885 "c.tab.c"
    break;

  case 9: /* postfix_expression: primary_expression  */
#line 200 "c.y"
                                                                                                                                                                { (yyval.node) = CreatePostfixExpressionNode((yyvsp[0].node), NULL); }
#line 1891 "c.tab.c"
    break;

  case 10: /* postfix_expression: postfix_expression LEFT_BRACKET expression RIGHT_BRACKET  */
#line 201 "c.y"
                                                                                                                                { (yyval.node)=(yyvsp[-3].node); addLinkToList((yyval.node),(yyvsp[-1].node)); }
#line 1897 "c.tab.c"
    break;

  case 11: /* postfix_expression: postfix_expression LEFT_PARANTH RIGHT_PARANTH  */
#line 202 "c.y"
                                                                                                                                        { (yyval.node)=(yyvsp[-2].node); addLinkToList((yyval.node),CreateOnlyDataNode("EMPTY")); }
#line 1903 "c.tab.c"
    break;

  case 12: /* postfix_expression: postfix_expression LEFT_PARANTH argument_expression_list RIGHT_PARANTH  */
#line 203 "c.y"
                                                                                                                { (yyval.node)=(yyvsp[-3].node); addLinkToList((yyval.node),(yyvsp[-1].node)); }
#line 1909 "c.tab.c"
    break;

  case 13: /* postfix_expression: postfix_expression POINT IDENTIFIER  */
#line 204 "c.y"
                                                                                                                                                { (yyval.node)=(yyvsp[-2].node); addLinkToList((yyval.node),CreateIdentifierNode((yyvsp[0].strings))); }
#line 1915 "c.tab.c"
    break;

  case 14: /* postfix_expression: postfix_expression PTR_OP IDENTIFIER  */
#line 205 "c.y"
                                                                                                                                                { (yyval.node)=(yyvsp[-2].node); addLinkToList((yyval.node),CreateIdentifierNode((yyvsp[0].strings))); }
#line 1921 "c.tab.c"
    break;

  case 15: /* postfix_expression: postfix_expression INC_OP  */
#line 206 "c.y"
                                                                                                                                                                { (yyval.node)=(yyvsp[-1].node); addLinkToList((yyval.node),CreateOnlyDataNode("INC_OP")); }
#line 1927 "c.tab.c"
    break;

  case 16: /* postfix_expression: postfix_expression DEC_OP  */
#line 207 "c.y"
                                                                                                                                                                { (yyval.node)=(yyvsp[-1].node); addLinkToList((yyval.node),CreateOnlyDataNode("DEC_OP")); }
#line 1933 "c.tab.c"
    break;

  case 17: /* postfix_expression: LEFT_PARANTH type_name RIGHT_PARANTH LEFT_BRACE initializer_list RIGHT_BRACE  */
#line 208 "c.y"
                                                                                                        { (yyval.node) = CreatePostfixExpressionNode((yyvsp[-4].node), (yyvsp[-1].node)); }
#line 1939 "c.tab.c"
    break;

  case 18: /* postfix_expression: LEFT_PARANTH type_name RIGHT_PARANTH LEFT_BRACE initializer_list COMMA RIGHT_BRACE  */
#line 209 "c.y"
                                                                                                { (yyval.node) = CreatePostfixExpressionNode((yyvsp[-5].node), (yyvsp[-2].node)); }
#line 1945 "c.tab.c"
    break;

  case 19: /* argument_expression_list: assignment_expression  */
#line 213 "c.y"
                                                                                                        { (yyval.node) = CreateArgumentExpressionListNode((yyvsp[0].node)); }
#line 1951 "c.tab.c"
    break;

  case 20: /* argument_expression_list: argument_expression_list COMMA assignment_expression  */
#line 214 "c.y"
                                                                        { (yyval.node)=(yyvsp[-2].node); addLinkToList((yyval.node),(yyvsp[0].node)); }
#line 1957 "c.tab.c"
    break;

  case 21: /* unary_expression: postfix_expression  */
#line 218 "c.y"
                                                                                        { (yyval.node) = CreateUnaryExpressionNode((yyvsp[0].node), NULL); }
#line 1963 "c.tab.c"
    break;

  case 22: /* unary_expression: INC_OP unary_expression  */
#line 219 "c.y"
                                                                                        { (yyval.node)=(yyvsp[0].node); addLinkToList((yyval.node),CreateOnlyDataNode("INC_OP")); }
#line 1969 "c.tab.c"
    break;

  case 23: /* unary_expression: DEC_OP unary_expression  */
#line 220 "c.y"
                                                                                        { (yyval.node)=(yyvsp[0].node); addLinkToList((yyval.node),CreateOnlyDataNode("DEC_OP")); }
#line 1975 "c.tab.c"
    break;

  case 24: /* unary_expression: unary_operator cast_expression  */
#line 221 "c.y"
                                                                                { (yyval.node) = CreateUnaryExpressionNode((yyvsp[-1].node), (yyvsp[0].node)); }
#line 1981 "c.tab.c"
    break;

  case 25: /* unary_expression: SIZEOF unary_expression  */
#line 222 "c.y"
                                                                                        { (yyval.node)=(yyvsp[0].node); addLinkToList((yyval.node),CreateOnlyDataNode("SIZEOF")); }
#line 1987 "c.tab.c"
    break;

  case 26: /* unary_expression: SIZEOF LEFT_PARANTH type_name RIGHT_PARANTH  */
#line 223 "c.y"
                                                                { (yyval.node) = CreateUnaryExpressionNode(CreateOnlyDataNode("SIZEOF"), (yyvsp[-1].node)); }
#line 1993 "c.tab.c"
    break;

  case 27: /* unary_operator: AND  */
#line 227 "c.y"
                        { (yyval.node) = CreateUnaryOperatorNode(CreateOnlyDataNode("AND")); }
#line 1999 "c.tab.c"
    break;

  case 28: /* unary_operator: MUL  */
#line 228 "c.y"
                        { (yyval.node) = CreateUnaryOperatorNode(CreateOnlyDataNode("MUL")); }
#line 2005 "c.tab.c"
    break;

  case 29: /* unary_operator: ADD  */
#line 229 "c.y"
                        { (yyval.node) = CreateUnaryOperatorNode(CreateOnlyDataNode("ADD")); }
#line 2011 "c.tab.c"
    break;

  case 30: /* unary_operator: SUB  */
#line 230 "c.y"
                        { (yyval.node) = CreateUnaryOperatorNode(CreateOnlyDataNode("SUB")); }
#line 2017 "c.tab.c"
    break;

  case 31: /* unary_operator: INV  */
#line 231 "c.y"
                        { (yyval.node) = CreateUnaryOperatorNode(CreateOnlyDataNode("INV")); }
#line 2023 "c.tab.c"
    break;

  case 32: /* unary_operator: NOT  */
#line 232 "c.y"
                        { (yyval.node) = CreateUnaryOperatorNode(CreateOnlyDataNode("NOT")); }
#line 2029 "c.tab.c"
    break;

  case 33: /* cast_expression: unary_expression  */
#line 236 "c.y"
                                                                                                                { (yyval.node) = CreateCastExpressionNode((yyvsp[0].node)); }
#line 2035 "c.tab.c"
    break;

  case 34: /* cast_expression: LEFT_PARANTH type_name RIGHT_PARANTH cast_expression  */
#line 237 "c.y"
                                                                        { (yyval.node)=(yyvsp[0].node); addLinkToList((yyval.node),(yyvsp[-2].node)); }
#line 2041 "c.tab.c"
    break;

  case 35: /* multiplicative_expression: cast_expression  */
#line 241 "c.y"
                                                                                                                { (yyval.node) = CreateMultiplicativeExpressionNode((yyvsp[0].node)); }
#line 2047 "c.tab.c"
    break;

  case 36: /* multiplicative_expression: multiplicative_expression MUL cast_expression  */
#line 242 "c.y"
                                                                                { (yyval.node)=(yyvsp[-2].node); addLinkToList((yyval.node),(yyvsp[0].node)); }
#line 2053 "c.tab.c"
    break;

  case 37: /* multiplicative_expression: multiplicative_expression DIV cast_expression  */
#line 243 "c.y"
                                                                                { (yyval.node)=(yyvsp[-2].node); addLinkToList((yyval.node),(yyvsp[0].node)); }
#line 2059 "c.tab.c"
    break;

  case 38: /* multiplicative_expression: multiplicative_expression MOD cast_expression  */
#line 244 "c.y"
                                                                                { (yyval.node)=(yyvsp[-2].node); addLinkToList((yyval.node),(yyvsp[0].node)); }
#line 2065 "c.tab.c"
    break;

  case 39: /* additive_expression: multiplicative_expression  */
#line 248 "c.y"
                                                                                                        { (yyval.node) = CreateAdditiveExpressionNode((yyvsp[0].node)); }
#line 2071 "c.tab.c"
    break;

  case 40: /* additive_expression: additive_expression ADD multiplicative_expression  */
#line 249 "c.y"
                                                                                { (yyval.node)=(yyvsp[-2].node); addLinkToList((yyval.node),(yyvsp[0].node)); }
#line 2077 "c.tab.c"
    break;

  case 41: /* additive_expression: additive_expression SUB multiplicative_expression  */
#line 250 "c.y"
                                                                                { (yyval.node)=(yyvsp[-2].node); addLinkToList((yyval.node),(yyvsp[0].node)); }
#line 2083 "c.tab.c"
    break;

  case 42: /* shift_expression: additive_expression  */
#line 254 "c.y"
                                                                                                        { (yyval.node) = CreateShiftExpressionNode((yyvsp[0].node)); }
#line 2089 "c.tab.c"
    break;

  case 43: /* shift_expression: shift_expression LEFT_OP additive_expression  */
#line 255 "c.y"
                                                                                { (yyval.node)=(yyvsp[-2].node); addLinkToList((yyval.node),(yyvsp[0].node)); }
#line 2095 "c.tab.c"
    break;

  case 44: /* shift_expression: shift_expression RIGHT_OP additive_expression  */
#line 256 "c.y"
                                                                                { (yyval.node)=(yyvsp[-2].node); addLinkToList((yyval.node),(yyvsp[0].node)); }
#line 2101 "c.tab.c"
    break;

  case 45: /* relational_expression: shift_expression  */
#line 260 "c.y"
                                                                                                                { (yyval.node) = CreateRelationalExpressionNode((yyvsp[0].node)); }
#line 2107 "c.tab.c"
    break;

  case 46: /* relational_expression: relational_expression LESSER shift_expression  */
#line 261 "c.y"
                                                                                { (yyval.node)=(yyvsp[-2].node); addLinkToList((yyval.node),(yyvsp[0].node)); }
#line 2113 "c.tab.c"
    break;

  case 47: /* relational_expression: relational_expression GREATER shift_expression  */
#line 262 "c.y"
                                                                                { (yyval.node)=(yyvsp[-2].node); addLinkToList((yyval.node),(yyvsp[0].node)); }
#line 2119 "c.tab.c"
    break;

  case 48: /* relational_expression: relational_expression LE_OP shift_expression  */
#line 263 "c.y"
                                                                                { (yyval.node)=(yyvsp[-2].node); addLinkToList((yyval.node),(yyvsp[0].node)); }
#line 2125 "c.tab.c"
    break;

  case 49: /* relational_expression: relational_expression GE_OP shift_expression  */
#line 264 "c.y"
                                                                                { (yyval.node)=(yyvsp[-2].node); addLinkToList((yyval.node),(yyvsp[0].node)); }
#line 2131 "c.tab.c"
    break;

  case 50: /* equality_expression: relational_expression  */
#line 268 "c.y"
                                                                                                        { (yyval.node) = CreateEqualityExpressionNode((yyvsp[0].node)); }
#line 2137 "c.tab.c"
    break;

  case 51: /* equality_expression: equality_expression EQ_OP relational_expression  */
#line 269 "c.y"
                                                                                { (yyval.node)=(yyvsp[-2].node); addLinkToList((yyval.node),(yyvsp[0].node)); }
#line 2143 "c.tab.c"
    break;

  case 52: /* equality_expression: equality_expression NE_OP relational_expression  */
#line 270 "c.y"
                                                                                { (yyval.node)=(yyvsp[-2].node); addLinkToList((yyval.node),(yyvsp[0].node)); }
#line 2149 "c.tab.c"
    break;

  case 53: /* and_expression: equality_expression  */
#line 274 "c.y"
                                                                                                        { (yyval.node) = CreateAndExpressionNode((yyvsp[0].node)); }
#line 2155 "c.tab.c"
    break;

  case 54: /* and_expression: and_expression AND equality_expression  */
#line 275 "c.y"
                                                                                        { (yyval.node)=(yyvsp[-2].node); addLinkToList((yyval.node),(yyvsp[0].node)); }
#line 2161 "c.tab.c"
    break;

  case 55: /* exclusive_or_expression: and_expression  */
#line 279 "c.y"
                                                                                                                { (yyval.node) = CreateExclusiveOrExpressionNode((yyvsp[0].node)); }
#line 2167 "c.tab.c"
    break;

  case 56: /* exclusive_or_expression: exclusive_or_expression XOR and_expression  */
#line 280 "c.y"
                                                                                { (yyval.node)=(yyvsp[-2].node); addLinkToList((yyval.node),(yyvsp[0].node)); }
#line 2173 "c.tab.c"
    break;

  case 57: /* inclusive_or_expression: exclusive_or_expression  */
#line 284 "c.y"
                                                                                                        { (yyval.node) = CreateInclusiveOrExpressionNode((yyvsp[0].node)); }
#line 2179 "c.tab.c"
    break;

  case 58: /* inclusive_or_expression: inclusive_or_expression OR exclusive_or_expression  */
#line 285 "c.y"
                                                                        { (yyval.node)=(yyvsp[-2].node); addLinkToList((yyval.node),(yyvsp[0].node)); }
#line 2185 "c.tab.c"
    break;

  case 59: /* logical_and_expression: inclusive_or_expression  */
#line 289 "c.y"
                                                                                                        { (yyval.node) = CreateLogicalAndExpressionNode((yyvsp[0].node)); }
#line 2191 "c.tab.c"
    break;

  case 60: /* logical_and_expression: logical_and_expression AND_OP inclusive_or_expression  */
#line 290 "c.y"
                                                                        { (yyval.node)=(yyvsp[-2].node); addLinkToList((yyval.node),(yyvsp[0].node)); }
#line 2197 "c.tab.c"
    break;

  case 61: /* logical_or_expression: logical_and_expression  */
#line 294 "c.y"
                                                                                                        { (yyval.node) = CreateLogicalOrExpressionNode((yyvsp[0].node)); }
#line 2203 "c.tab.c"
    break;

  case 62: /* logical_or_expression: logical_or_expression OR_OP logical_and_expression  */
#line 295 "c.y"
                                                                        { (yyval.node)=(yyvsp[-2].node); addLinkToList((yyval.node),(yyvsp[0].node)); }
#line 2209 "c.tab.c"
    break;

  case 63: /* conditional_expression: logical_or_expression  */
#line 299 "c.y"
                                                                                                                                                                { (yyval.node) = CreateConditionalExpressionNode((yyvsp[0].node)); }
#line 2215 "c.tab.c"
    break;

  case 64: /* conditional_expression: logical_or_expression QUESTION_MARK expression TWO_POINTS conditional_expression  */
#line 300 "c.y"
                                                                                                        { (yyval.node)=(yyvsp[0].node); addLinkToList((yyval.node),(yyvsp[-4].node)); addLinkToList((yyval.node),(yyvsp[-2].node)); }
#line 2221 "c.tab.c"
    break;

  case 65: /* assignment_expression: conditional_expression  */
#line 304 "c.y"
                                                                                                                                                                { (yyval.node) = CreateAssignmentExpressionNode((yyvsp[0].node)); }
#line 2227 "c.tab.c"
    break;

  case 66: /* assignment_expression: unary_expression assignment_operator assignment_expression  */
#line 305 "c.y"
                                                                                                                        { (yyval.node)=(yyvsp[0].node); addLinkToList((yyval.node),(yyvsp[-2].node)); addLinkToList((yyval.node),(yyvsp[-1].node)); }
#line 2233 "c.tab.c"
    break;

  case 67: /* assignment_operator: ASSIGN  */
#line 309 "c.y"
                                                        { (yyval.node) = CreateAssignmentOperatorNode(CreateOnlyDataNode("ASSIGN")); }
#line 2239 "c.tab.c"
    break;

  case 68: /* assignment_operator: MUL_ASSIGN  */
#line 310 "c.y"
                                                { (yyval.node) = CreateAssignmentOperatorNode(CreateOnlyDataNode("MUL_ASSIGN")); }
#line 2245 "c.tab.c"
    break;

  case 69: /* assignment_operator: DIV_ASSIGN  */
#line 311 "c.y"
                                                { (yyval.node) = CreateAssignmentOperatorNode(CreateOnlyDataNode("DIV_ASSIGN")); }
#line 2251 "c.tab.c"
    break;

  case 70: /* assignment_operator: MOD_ASSIGN  */
#line 312 "c.y"
                                                { (yyval.node) = CreateAssignmentOperatorNode(CreateOnlyDataNode("MOD_ASSIGN")); }
#line 2257 "c.tab.c"
    break;

  case 71: /* assignment_operator: ADD_ASSIGN  */
#line 313 "c.y"
                                                { (yyval.node) = CreateAssignmentOperatorNode(CreateOnlyDataNode("ADD_ASSIGN")); }
#line 2263 "c.tab.c"
    break;

  case 72: /* assignment_operator: SUB_ASSIGN  */
#line 314 "c.y"
                                                { (yyval.node) = CreateAssignmentOperatorNode(CreateOnlyDataNode("SUB_ASSIGN")); }
#line 2269 "c.tab.c"
    break;

  case 73: /* assignment_operator: LEFT_ASSIGN  */
#line 315 "c.y"
                                                { (yyval.node) = CreateAssignmentOperatorNode(CreateOnlyDataNode("LEFT_ASSIGN")); }
#line 2275 "c.tab.c"
    break;

  case 74: /* assignment_operator: RIGHT_ASSIGN  */
#line 316 "c.y"
                                                { (yyval.node) = CreateAssignmentOperatorNode(CreateOnlyDataNode("RIGHT_ASSIGN")); }
#line 2281 "c.tab.c"
    break;

  case 75: /* assignment_operator: AND_ASSIGN  */
#line 317 "c.y"
                                                { (yyval.node) = CreateAssignmentOperatorNode(CreateOnlyDataNode("AND_ASSIGN")); }
#line 2287 "c.tab.c"
    break;

  case 76: /* assignment_operator: XOR_ASSIGN  */
#line 318 "c.y"
                                                { (yyval.node) = CreateAssignmentOperatorNode(CreateOnlyDataNode("XOR_ASSIGN")); }
#line 2293 "c.tab.c"
    break;

  case 77: /* assignment_operator: OR_ASSIGN  */
#line 319 "c.y"
                                                        { (yyval.node) = CreateAssignmentOperatorNode(CreateOnlyDataNode("OR_ASSIGN")); }
#line 2299 "c.tab.c"
    break;

  case 78: /* expression: assignment_expression  */
#line 323 "c.y"
                                                                                        { (yyval.node) = CreateExpressionNode((yyvsp[0].node)); }
#line 2305 "c.tab.c"
    break;

  case 79: /* expression: expression COMMA assignment_expression  */
#line 324 "c.y"
                                                                        { (yyval.node)=(yyvsp[-2].node); addLinkToList((yyval.node),(yyvsp[0].node)); }
#line 2311 "c.tab.c"
    break;

  case 80: /* constant_expression: conditional_expression  */
#line 328 "c.y"
                                                                                        { (yyval.node) = CreateConstantExpressionNode((yyvsp[0].node)); }
#line 2317 "c.tab.c"
    break;

  case 81: /* declaration: declaration_specifiers END_OF_INSTRUCTION  */
#line 332 "c.y"
                                                                                                                { (yyval.node) = CreateDeclarationNode((yyvsp[-1].node), NULL); }
#line 2323 "c.tab.c"
    break;

  case 82: /* declaration: declaration_specifiers init_declarator_list END_OF_INSTRUCTION  */
#line 333 "c.y"
                                                                                        { (yyval.node) = CreateDeclarationNode((yyvsp[-2].node), (yyvsp[-1].node)); }
#line 2329 "c.tab.c"
    break;

  case 83: /* declaration_specifiers: storage_class_specifier  */
#line 337 "c.y"
                                                                                                                                { (yyval.node) = CreateDeclarationSpecifiersNode((yyvsp[0].node)); }
#line 2335 "c.tab.c"
    break;

  case 84: /* declaration_specifiers: storage_class_specifier declaration_specifiers  */
#line 338 "c.y"
                                                                                                        { (yyval.node)=(yyvsp[0].node); addLinkToList((yyval.node),(yyvsp[-1].node)); }
#line 2341 "c.tab.c"
    break;

  case 85: /* declaration_specifiers: type_specifier  */
#line 339 "c.y"
                                                                                                                                        { (yyval.node) = CreateDeclarationSpecifiersNode((yyvsp[0].node)); }
#line 2347 "c.tab.c"
    break;

  case 86: /* declaration_specifiers: type_specifier declaration_specifiers  */
#line 340 "c.y"
                                                                                                                { (yyval.node)=(yyvsp[0].node); addLinkToList((yyval.node),(yyvsp[-1].node)); }
#line 2353 "c.tab.c"
    break;

  case 87: /* declaration_specifiers: type_qualifier  */
#line 341 "c.y"
                                                                                                                                        { (yyval.node) = CreateDeclarationSpecifiersNode((yyvsp[0].node)); }
#line 2359 "c.tab.c"
    break;

  case 88: /* declaration_specifiers: type_qualifier declaration_specifiers  */
#line 342 "c.y"
                                                                                                                { (yyval.node)=(yyvsp[0].node); addLinkToList((yyval.node),(yyvsp[-1].node)); }
#line 2365 "c.tab.c"
    break;

  case 89: /* declaration_specifiers: function_specifier  */
#line 343 "c.y"
                                                                                                                                { (yyval.node) = CreateDeclarationSpecifiersNode((yyvsp[0].node)); }
#line 2371 "c.tab.c"
    break;

  case 90: /* declaration_specifiers: function_specifier declaration_specifiers  */
#line 344 "c.y"
                                                                                                                { (yyval.node)=(yyvsp[0].node); addLinkToList((yyval.node),(yyvsp[-1].node)); }
#line 2377 "c.tab.c"
    break;

  case 91: /* init_declarator_list: init_declarator  */
#line 348 "c.y"
                                                                                                                                        { (yyval.node) = CreateInitDeclaratorListNode((yyvsp[0].node)); }
#line 2383 "c.tab.c"
    break;

  case 92: /* init_declarator_list: init_declarator_list COMMA init_declarator  */
#line 349 "c.y"
                                                                                                        { (yyval.node)=(yyvsp[-2].node); addLinkToList((yyval.node),(yyvsp[0].node)); }
#line 2389 "c.tab.c"
    break;

  case 93: /* init_declarator: declarator  */
#line 353 "c.y"
                                                                                { (yyval.node) = CreateInitDeclaratorNode((yyvsp[0].node), NULL); }
#line 2395 "c.tab.c"
    break;

  case 94: /* init_declarator: declarator ASSIGN initializer  */
#line 354 "c.y"
                                                                { (yyval.node) = CreateInitDeclaratorNode((yyvsp[-2].node), (yyvsp[0].node)); }
#line 2401 "c.tab.c"
    break;

  case 95: /* storage_class_specifier: TYPEDEF  */
#line 358 "c.y"
                                                                { (yyval.node) = CreateStorageClassSpecifierNode(CreateOnlyDataNode("TYPEDEF")); }
#line 2407 "c.tab.c"
    break;

  case 96: /* storage_class_specifier: EXTERN  */
#line 359 "c.y"
                                                                { (yyval.node) = CreateStorageClassSpecifierNode(CreateOnlyDataNode("EXTERN")); }
#line 2413 "c.tab.c"
    break;

  case 97: /* storage_class_specifier: STATIC  */
#line 360 "c.y"
                                                                { (yyval.node) = CreateStorageClassSpecifierNode(CreateOnlyDataNode("STATIC")); }
#line 2419 "c.tab.c"
    break;

  case 98: /* storage_class_specifier: AUTO  */
#line 361 "c.y"
                                                                { (yyval.node) = CreateStorageClassSpecifierNode(CreateOnlyDataNode("AUTO")); }
#line 2425 "c.tab.c"
    break;

  case 99: /* storage_class_specifier: REGISTER  */
#line 362 "c.y"
                                                                { (yyval.node) = CreateStorageClassSpecifierNode(CreateOnlyDataNode("REGISTER")); }
#line 2431 "c.tab.c"
    break;

  case 100: /* type_specifier: VOID  */
#line 366 "c.y"
                                                                        { (yyval.node) = CreateTypeSpecifierNode(CreateOnlyDataNode("VOID")); }
#line 2437 "c.tab.c"
    break;

  case 101: /* type_specifier: CHAR  */
#line 367 "c.y"
                                                                        { (yyval.node) = CreateTypeSpecifierNode(CreateOnlyDataNode("CHAR")); }
#line 2443 "c.tab.c"
    break;

  case 102: /* type_specifier: SHORT  */
#line 368 "c.y"
                                                                        { (yyval.node) = CreateTypeSpecifierNode(CreateOnlyDataNode("SHORT")); }
#line 2449 "c.tab.c"
    break;

  case 103: /* type_specifier: INT  */
#line 369 "c.y"
                                                                        { (yyval.node) = CreateTypeSpecifierNode(CreateOnlyDataNode("INT")); }
#line 2455 "c.tab.c"
    break;

  case 104: /* type_specifier: LONG  */
#line 370 "c.y"
                                                                        { (yyval.node) = CreateTypeSpecifierNode(CreateOnlyDataNode("LONG")); }
#line 2461 "c.tab.c"
    break;

  case 105: /* type_specifier: FLOAT  */
#line 371 "c.y"
                                                                        { (yyval.node) = CreateTypeSpecifierNode(CreateOnlyDataNode("FLOAT")); }
#line 2467 "c.tab.c"
    break;

  case 106: /* type_specifier: DOUBLE  */
#line 372 "c.y"
                                                                        { (yyval.node) = CreateTypeSpecifierNode(CreateOnlyDataNode("DOUBLE")); }
#line 2473 "c.tab.c"
    break;

  case 107: /* type_specifier: SIGNED  */
#line 373 "c.y"
                                                                        { (yyval.node) = CreateTypeSpecifierNode(CreateOnlyDataNode("SIGNED")); }
#line 2479 "c.tab.c"
    break;

  case 108: /* type_specifier: UNSIGNED  */
#line 374 "c.y"
                                                                        { (yyval.node) = CreateTypeSpecifierNode(CreateOnlyDataNode("UNSIGNED")); }
#line 2485 "c.tab.c"
    break;

  case 109: /* type_specifier: _BOOL  */
#line 375 "c.y"
                                                                        { (yyval.node) = CreateTypeSpecifierNode(CreateOnlyDataNode("_BOOL")); }
#line 2491 "c.tab.c"
    break;

  case 110: /* type_specifier: _COMPLEX  */
#line 376 "c.y"
                                                                        { (yyval.node) = CreateTypeSpecifierNode(CreateOnlyDataNode("_COMPLEX")); }
#line 2497 "c.tab.c"
    break;

  case 111: /* type_specifier: _IMAGINARY  */
#line 377 "c.y"
                                                                { (yyval.node) = CreateTypeSpecifierNode(CreateOnlyDataNode("_IMAGINARY")); }
#line 2503 "c.tab.c"
    break;

  case 112: /* type_specifier: struct_or_union_specifier  */
#line 378 "c.y"
                                                        { (yyval.node) = CreateTypeSpecifierNode((yyvsp[0].node)); }
#line 2509 "c.tab.c"
    break;

  case 113: /* type_specifier: enum_specifier  */
#line 379 "c.y"
                                                                { (yyval.node) = CreateTypeSpecifierNode((yyvsp[0].node)); }
#line 2515 "c.tab.c"
    break;

  case 114: /* type_specifier: TYPE_NAME  */
#line 380 "c.y"
                                                                        { (yyval.node) = CreateTypeSpecifierNode(CreateOnlyDataNode("TYPE_NAME")); }
#line 2521 "c.tab.c"
    break;

  case 115: /* struct_or_union_specifier: struct_or_union IDENTIFIER LEFT_BRACE struct_declaration_list RIGHT_BRACE  */
#line 384 "c.y"
                                                                                                                        { (yyval.node) = CreateStructOrUnionSpecifierNode((yyvsp[-4].node), CreateIdentifierNode((yyvsp[-3].strings)), (yyvsp[-1].node)); }
#line 2527 "c.tab.c"
    break;

  case 116: /* struct_or_union_specifier: struct_or_union LEFT_BRACE struct_declaration_list RIGHT_BRACE  */
#line 385 "c.y"
                                                                                                                                { (yyval.node) = CreateStructOrUnionSpecifierNode((yyvsp[-3].node), (yyvsp[-1].node), NULL); }
#line 2533 "c.tab.c"
    break;

  case 117: /* struct_or_union_specifier: struct_or_union IDENTIFIER  */
#line 386 "c.y"
                                                                                                                                                                { (yyval.node) = CreateStructOrUnionSpecifierNode((yyvsp[-1].node), CreateIdentifierNode((yyvsp[0].strings)), NULL); }
#line 2539 "c.tab.c"
    break;

  case 118: /* struct_or_union: STRUCT  */
#line 390 "c.y"
                                                                        { (yyval.node) = CreateStructOrUnionNode(CreateOnlyDataNode("STRUCT")); }
#line 2545 "c.tab.c"
    break;

  case 119: /* struct_or_union: UNION  */
#line 391 "c.y"
                                                                        { (yyval.node) = CreateStructOrUnionNode(CreateOnlyDataNode("UNION")); }
#line 2551 "c.tab.c"
    break;

  case 120: /* struct_declaration_list: struct_declaration  */
#line 395 "c.y"
                                                                                        { (yyval.node) = CreateStructDeclarationListNode((yyvsp[0].node)); }
#line 2557 "c.tab.c"
    break;

  case 121: /* struct_declaration_list: struct_declaration_list struct_declaration  */
#line 396 "c.y"
                                                                { (yyval.node)=(yyvsp[-1].node); addLinkToList((yyval.node),(yyvsp[0].node)); }
#line 2563 "c.tab.c"
    break;

  case 122: /* struct_declaration: specifier_qualifier_list struct_declarator_list END_OF_INSTRUCTION  */
#line 400 "c.y"
                                                                                        { (yyval.node) = CreateStructDeclarationNode((yyvsp[-2].node), (yyvsp[-1].node)); }
#line 2569 "c.tab.c"
    break;

  case 123: /* specifier_qualifier_list: type_specifier specifier_qualifier_list  */
#line 404 "c.y"
                                                                                                                        { (yyval.node)=(yyvsp[0].node); addLinkToList((yyval.node),(yyvsp[-1].node)); }
#line 2575 "c.tab.c"
    break;

  case 124: /* specifier_qualifier_list: type_specifier  */
#line 405 "c.y"
                                                                                                                                                { (yyval.node) = CreateSpecifierQualifierListNode((yyvsp[0].node)); }
#line 2581 "c.tab.c"
    break;

  case 125: /* specifier_qualifier_list: type_qualifier specifier_qualifier_list  */
#line 406 "c.y"
                                                                                                                        { (yyval.node)=(yyvsp[0].node); addLinkToList((yyval.node),(yyvsp[-1].node)); }
#line 2587 "c.tab.c"
    break;

  case 126: /* specifier_qualifier_list: type_qualifier  */
#line 407 "c.y"
                                                                                                                                                { (yyval.node) = CreateSpecifierQualifierListNode((yyvsp[0].node)); }
#line 2593 "c.tab.c"
    break;

  case 127: /* struct_declarator_list: struct_declarator  */
#line 411 "c.y"
                                                                                                                                                { (yyval.node) = CreateStructDeclaratorListNode((yyvsp[0].node)); }
#line 2599 "c.tab.c"
    break;

  case 128: /* struct_declarator_list: struct_declarator_list COMMA struct_declarator  */
#line 412 "c.y"
                                                                                                                { (yyval.node)=(yyvsp[-2].node); addLinkToList((yyval.node),(yyvsp[0].node)); }
#line 2605 "c.tab.c"
    break;

  case 129: /* struct_declarator: declarator  */
#line 416 "c.y"
                                                                                                                                                { (yyval.node) = CreateStructDeclaratorNode((yyvsp[0].node), NULL); }
#line 2611 "c.tab.c"
    break;

  case 130: /* struct_declarator: TWO_POINTS constant_expression  */
#line 417 "c.y"
                                                                                                                                { (yyval.node) = CreateStructDeclaratorNode((yyvsp[0].node), NULL); }
#line 2617 "c.tab.c"
    break;

  case 131: /* struct_declarator: declarator TWO_POINTS constant_expression  */
#line 418 "c.y"
                                                                                                                        { (yyval.node) = CreateStructDeclaratorNode((yyvsp[-2].node), (yyvsp[0].node)); }
#line 2623 "c.tab.c"
    break;

  case 132: /* enum_specifier: ENUM LEFT_BRACE enumerator_list RIGHT_BRACE  */
#line 422 "c.y"
                                                                                                                { (yyval.node) = CreateEnumSpecifierNode((yyvsp[-1].node), NULL); }
#line 2629 "c.tab.c"
    break;

  case 133: /* enum_specifier: ENUM IDENTIFIER LEFT_BRACE enumerator_list RIGHT_BRACE  */
#line 423 "c.y"
                                                                                                        { (yyval.node) = CreateEnumSpecifierNode(CreateIdentifierNode((yyvsp[-3].strings)), (yyvsp[-1].node)); }
#line 2635 "c.tab.c"
    break;

  case 134: /* enum_specifier: ENUM LEFT_BRACE enumerator_list COMMA RIGHT_BRACE  */
#line 424 "c.y"
                                                                                                                { (yyval.node) = CreateEnumSpecifierNode((yyvsp[-2].node), NULL); }
#line 2641 "c.tab.c"
    break;

  case 135: /* enum_specifier: ENUM IDENTIFIER LEFT_BRACE enumerator_list COMMA RIGHT_BRACE  */
#line 425 "c.y"
                                                                                                { (yyval.node) = CreateEnumSpecifierNode(CreateIdentifierNode((yyvsp[-4].strings)), (yyvsp[-2].node)); }
#line 2647 "c.tab.c"
    break;

  case 136: /* enum_specifier: ENUM IDENTIFIER  */
#line 426 "c.y"
                                                                                                                                                { (yyval.node) = CreateEnumSpecifierNode(CreateIdentifierNode((yyvsp[0].strings)), NULL); }
#line 2653 "c.tab.c"
    break;

  case 137: /* enumerator_list: enumerator  */
#line 430 "c.y"
                                                                                                                                                { (yyval.node) = CreateEnumeratorListNode((yyvsp[0].node)); }
#line 2659 "c.tab.c"
    break;

  case 138: /* enumerator_list: enumerator_list COMMA enumerator  */
#line 431 "c.y"
                                                                                                                                { (yyval.node)=(yyvsp[-2].node); addLinkToList((yyval.node),(yyvsp[0].node)); }
#line 2665 "c.tab.c"
    break;

  case 139: /* enumerator: IDENTIFIER  */
#line 435 "c.y"
                                                                                                                                                { (yyval.node) = CreateEnumeratorNode(CreateIdentifierNode((yyvsp[0].strings)), NULL); }
#line 2671 "c.tab.c"
    break;

  case 140: /* enumerator: IDENTIFIER ASSIGN constant_expression  */
#line 436 "c.y"
                                                                                                                        { (yyval.node) = CreateEnumeratorNode(CreateIdentifierNode((yyvsp[-2].strings)), (yyvsp[0].node)); }
#line 2677 "c.tab.c"
    break;

  case 141: /* type_qualifier: CONST  */
#line 440 "c.y"
                                                                                                                                                        { (yyval.node) = CreateTypeQualifierNode(CreateOnlyDataNode("CONST")); }
#line 2683 "c.tab.c"
    break;

  case 142: /* type_qualifier: RESTRICT  */
#line 441 "c.y"
                                                                                                                                                        { (yyval.node) = CreateTypeQualifierNode(CreateOnlyDataNode("RESTRICT")); }
#line 2689 "c.tab.c"
    break;

  case 143: /* type_qualifier: VOLATILE  */
#line 442 "c.y"
                                                                                                                                                        { (yyval.node) = CreateTypeQualifierNode(CreateOnlyDataNode("VOLATILE")); }
#line 2695 "c.tab.c"
    break;

  case 144: /* function_specifier: INLINE  */
#line 446 "c.y"
                                                                                                                                                        { (yyval.node) = CreateFunctionSpecifierNode(CreateOnlyDataNode("INLINE")); }
#line 2701 "c.tab.c"
    break;

  case 145: /* declarator: pointer direct_declarator  */
#line 450 "c.y"
                                                                                                                                        { (yyval.node) = CreateDeclaratorNode((yyvsp[-1].node), (yyvsp[0].node)); }
#line 2707 "c.tab.c"
    break;

  case 146: /* declarator: direct_declarator  */
#line 451 "c.y"
                                                                                                                                                { (yyval.node) = CreateDeclaratorNode((yyvsp[0].node), NULL); }
#line 2713 "c.tab.c"
    break;

  case 147: /* direct_declarator: IDENTIFIER  */
#line 455 "c.y"
                                                                                                                                                                                                { (yyval.node) = CreateDirectDeclaratorNode(CreateIdentifierNode((yyvsp[0].strings))); }
#line 2719 "c.tab.c"
    break;

  case 148: /* direct_declarator: LEFT_PARANTH declarator RIGHT_PARANTH  */
#line 456 "c.y"
                                                                                                                                                                        { (yyval.node) = CreateDirectDeclaratorNode((yyvsp[-1].node)); }
#line 2725 "c.tab.c"
    break;

  case 149: /* direct_declarator: direct_declarator LEFT_BRACKET type_qualifier_list assignment_expression RIGHT_BRACKET  */
#line 457 "c.y"
                                                                                                                        { (yyval.node)=(yyvsp[-4].node); addLinkToList((yyval.node),(yyvsp[-2].node)); addLinkToList((yyval.node),(yyvsp[-1].node)); }
#line 2731 "c.tab.c"
    break;

  case 150: /* direct_declarator: direct_declarator LEFT_BRACKET type_qualifier_list RIGHT_BRACKET  */
#line 458 "c.y"
                                                                                                                                                { (yyval.node)=(yyvsp[-3].node); addLinkToList((yyval.node),(yyvsp[-1].node)); }
#line 2737 "c.tab.c"
    break;

  case 151: /* direct_declarator: direct_declarator LEFT_BRACKET assignment_expression RIGHT_BRACKET  */
#line 459 "c.y"
                                                                                                                                        { (yyval.node)=(yyvsp[-3].node); addLinkToList((yyval.node),(yyvsp[-1].node)); }
#line 2743 "c.tab.c"
    break;

  case 152: /* direct_declarator: direct_declarator LEFT_BRACKET STATIC type_qualifier_list assignment_expression RIGHT_BRACKET  */
#line 460 "c.y"
                                                                                                                { (yyval.node)=(yyvsp[-5].node); addLinkToList((yyval.node),(yyvsp[-2].node)); addLinkToList((yyval.node),(yyvsp[-1].node)); }
#line 2749 "c.tab.c"
    break;

  case 153: /* direct_declarator: direct_declarator LEFT_BRACKET type_qualifier_list STATIC assignment_expression RIGHT_BRACKET  */
#line 461 "c.y"
                                                                                                                { (yyval.node)=(yyvsp[-5].node); addLinkToList((yyval.node),(yyvsp[-3].node)); addLinkToList((yyval.node),(yyvsp[-1].node)); }
#line 2755 "c.tab.c"
    break;

  case 154: /* direct_declarator: direct_declarator LEFT_BRACKET type_qualifier_list MUL RIGHT_BRACKET  */
#line 462 "c.y"
                                                                                                                                        { (yyval.node)=(yyvsp[-4].node); addLinkToList((yyval.node),(yyvsp[-2].node)); }
#line 2761 "c.tab.c"
    break;

  case 155: /* direct_declarator: direct_declarator LEFT_BRACKET MUL RIGHT_BRACKET  */
#line 463 "c.y"
                                                                                                                                                                { (yyval.node)=(yyvsp[-3].node); addLinkToList((yyval.node),CreateOnlyDataNode("MUL")); }
#line 2767 "c.tab.c"
    break;

  case 156: /* direct_declarator: direct_declarator LEFT_BRACKET RIGHT_BRACKET  */
#line 464 "c.y"
                                                                                                                                                                { (yyval.node)=(yyvsp[-2].node); addLinkToList((yyval.node),CreateOnlyDataNode("EMPTY")); }
#line 2773 "c.tab.c"
    break;

  case 157: /* direct_declarator: direct_declarator LEFT_PARANTH parameter_type_list RIGHT_PARANTH  */
#line 465 "c.y"
                                                                                                                                                { (yyval.node)=(yyvsp[-3].node); addLinkToList((yyval.node),(yyvsp[-1].node)); }
#line 2779 "c.tab.c"
    break;

  case 158: /* direct_declarator: direct_declarator LEFT_PARANTH identifier_list RIGHT_PARANTH  */
#line 466 "c.y"
                                                                                                                                                { (yyval.node)=(yyvsp[-3].node); addLinkToList((yyval.node),(yyvsp[-1].node)); }
#line 2785 "c.tab.c"
    break;

  case 159: /* direct_declarator: direct_declarator LEFT_PARANTH RIGHT_PARANTH  */
#line 467 "c.y"
                                                                                                                                                                { (yyval.node)=(yyvsp[-2].node); addLinkToList((yyval.node),CreateOnlyDataNode("EMPTY")); }
#line 2791 "c.tab.c"
    break;

  case 160: /* pointer: MUL  */
#line 471 "c.y"
                                                                                                                { (yyval.node) = CreatePointerNode(CreateOnlyDataNode("MUL"), NULL); }
#line 2797 "c.tab.c"
    break;

  case 161: /* pointer: MUL type_qualifier_list  */
#line 472 "c.y"
                                                                                                { (yyval.node) = CreatePointerNode(CreateOnlyDataNode("MUL"), (yyvsp[0].node)); }
#line 2803 "c.tab.c"
    break;

  case 162: /* pointer: MUL pointer  */
#line 473 "c.y"
                                                                                                        { (yyval.node)=(yyvsp[0].node); addLinkToList((yyval.node),CreateOnlyDataNode("MUL")); }
#line 2809 "c.tab.c"
    break;

  case 163: /* pointer: MUL type_qualifier_list pointer  */
#line 474 "c.y"
                                                                                        { (yyval.node)=(yyvsp[0].node); addLinkToList((yyval.node), (yyvsp[-1].node)); }
#line 2815 "c.tab.c"
    break;

  case 164: /* type_qualifier_list: type_qualifier  */
#line 478 "c.y"
                                                                                                        { (yyval.node) = CreateTypeQualifierListNode((yyvsp[0].node)); }
#line 2821 "c.tab.c"
    break;

  case 165: /* type_qualifier_list: type_qualifier_list type_qualifier  */
#line 479 "c.y"
                                                                                { (yyval.node)=(yyvsp[-1].node); addLinkToList((yyval.node), (yyvsp[0].node)); }
#line 2827 "c.tab.c"
    break;

  case 166: /* parameter_type_list: parameter_list  */
#line 484 "c.y"
                                                                                                        { (yyval.node) = CreateParameterTypeListNode((yyvsp[0].node)); }
#line 2833 "c.tab.c"
    break;

  case 167: /* parameter_type_list: parameter_list COMMA ELLIPSIS  */
#line 485 "c.y"
                                                                                        { (yyval.node) = CreateParameterTypeListNode((yyvsp[-2].node)); }
#line 2839 "c.tab.c"
    break;

  case 168: /* parameter_list: parameter_declaration  */
#line 489 "c.y"
                                                                                                { (yyval.node) = CreateParameterListNode((yyvsp[0].node)); }
#line 2845 "c.tab.c"
    break;

  case 169: /* parameter_list: parameter_list COMMA parameter_declaration  */
#line 490 "c.y"
                                                                        { (yyval.node)=(yyvsp[-2].node); addLinkToList((yyval.node), (yyvsp[0].node)); }
#line 2851 "c.tab.c"
    break;

  case 170: /* parameter_declaration: declaration_specifiers declarator  */
#line 494 "c.y"
                                                                                        { (yyval.node) = CreateParameterDeclarationNode((yyvsp[-1].node),(yyvsp[0].node)); }
#line 2857 "c.tab.c"
    break;

  case 171: /* parameter_declaration: declaration_specifiers abstract_declarator  */
#line 495 "c.y"
                                                                        { (yyval.node) = CreateParameterDeclarationNode((yyvsp[-1].node),(yyvsp[0].node)); }
#line 2863 "c.tab.c"
    break;

  case 172: /* parameter_declaration: declaration_specifiers  */
#line 496 "c.y"
                                                                                                { (yyval.node) = CreateParameterDeclarationNode((yyvsp[0].node),NULL); }
#line 2869 "c.tab.c"
    break;

  case 173: /* identifier_list: IDENTIFIER  */
#line 500 "c.y"
                                                                                                        { (yyval.node) = CreateIdentifierListNode(CreateIdentifierNode((yyvsp[0].strings))); }
#line 2875 "c.tab.c"
    break;

  case 174: /* identifier_list: identifier_list COMMA IDENTIFIER  */
#line 501 "c.y"
                                                                                        { (yyval.node)=(yyvsp[-2].node); addLinkToList((yyval.node), CreateIdentifierNode((yyvsp[0].strings))); }
#line 2881 "c.tab.c"
    break;

  case 175: /* type_name: specifier_qualifier_list  */
#line 505 "c.y"
                                                                                                { (yyval.node) = CreateTypeNameNode((yyvsp[0].node),NULL); }
#line 2887 "c.tab.c"
    break;

  case 176: /* type_name: specifier_qualifier_list abstract_declarator  */
#line 506 "c.y"
                                                                        { (yyval.node) = CreateTypeNameNode((yyvsp[-1].node),(yyvsp[0].node)); }
#line 2893 "c.tab.c"
    break;

  case 177: /* abstract_declarator: pointer  */
#line 510 "c.y"
                                                                                                                { (yyval.node) = CreateAbstractDeclaratorNode((yyvsp[0].node),NULL); }
#line 2899 "c.tab.c"
    break;

  case 178: /* abstract_declarator: direct_abstract_declarator  */
#line 511 "c.y"
                                                                                        { (yyval.node) = CreateAbstractDeclaratorNode((yyvsp[0].node),NULL); }
#line 2905 "c.tab.c"
    break;

  case 179: /* abstract_declarator: pointer direct_abstract_declarator  */
#line 512 "c.y"
                                                                                { (yyval.node) = CreateAbstractDeclaratorNode((yyvsp[-1].node),(yyvsp[0].node)); }
#line 2911 "c.tab.c"
    break;

  case 180: /* direct_abstract_declarator: LEFT_PARANTH abstract_declarator RIGHT_PARANTH  */
#line 516 "c.y"
                                                                                                                                { (yyval.node) = CreateDirectAbstractDeclaratorNode((yyvsp[-1].node)); }
#line 2917 "c.tab.c"
    break;

  case 181: /* direct_abstract_declarator: LEFT_BRACKET RIGHT_BRACKET  */
#line 517 "c.y"
                                                                                                                                                { (yyval.node) = CreateDirectAbstractDeclaratorNode(CreateOnlyDataNode("EMPTY")); }
#line 2923 "c.tab.c"
    break;

  case 182: /* direct_abstract_declarator: LEFT_BRACKET assignment_expression RIGHT_BRACKET  */
#line 518 "c.y"
                                                                                                                                { (yyval.node) = CreateDirectAbstractDeclaratorNode((yyvsp[-1].node)); }
#line 2929 "c.tab.c"
    break;

  case 183: /* direct_abstract_declarator: direct_abstract_declarator LEFT_BRACKET RIGHT_BRACKET  */
#line 519 "c.y"
                                                                                                                        { (yyval.node)=(yyvsp[-2].node); addLinkToList((yyval.node), CreateOnlyDataNode("EMPTY")); }
#line 2935 "c.tab.c"
    break;

  case 184: /* direct_abstract_declarator: direct_abstract_declarator LEFT_BRACKET assignment_expression RIGHT_BRACKET  */
#line 520 "c.y"
                                                                                                { (yyval.node)=(yyvsp[-3].node); addLinkToList((yyval.node), (yyvsp[-1].node)); }
#line 2941 "c.tab.c"
    break;

  case 185: /* direct_abstract_declarator: LEFT_BRACKET MUL RIGHT_BRACKET  */
#line 521 "c.y"
                                                                                                                                                { (yyval.node) = CreateDirectAbstractDeclaratorNode(CreateOnlyDataNode("MUL")); }
#line 2947 "c.tab.c"
    break;

  case 186: /* direct_abstract_declarator: direct_abstract_declarator LEFT_BRACKET MUL RIGHT_BRACKET  */
#line 522 "c.y"
                                                                                                                        { (yyval.node)=(yyvsp[-3].node); addLinkToList((yyval.node), CreateOnlyDataNode("MUL")); }
#line 2953 "c.tab.c"
    break;

  case 187: /* direct_abstract_declarator: LEFT_PARANTH RIGHT_PARANTH  */
#line 523 "c.y"
                                                                                                                                                { (yyval.node) = CreateDirectAbstractDeclaratorNode(CreateOnlyDataNode("EMPTY")); }
#line 2959 "c.tab.c"
    break;

  case 188: /* direct_abstract_declarator: LEFT_PARANTH parameter_type_list RIGHT_PARANTH  */
#line 524 "c.y"
                                                                                                                                { (yyval.node) = CreateDirectAbstractDeclaratorNode((yyvsp[-1].node)); }
#line 2965 "c.tab.c"
    break;

  case 189: /* direct_abstract_declarator: direct_abstract_declarator LEFT_PARANTH RIGHT_PARANTH  */
#line 525 "c.y"
                                                                                                                        { (yyval.node)=(yyvsp[-2].node); addLinkToList((yyval.node), CreateOnlyDataNode("EMPTY")); }
#line 2971 "c.tab.c"
    break;

  case 190: /* direct_abstract_declarator: direct_abstract_declarator LEFT_PARANTH parameter_type_list RIGHT_PARANTH  */
#line 526 "c.y"
                                                                                                        { (yyval.node)=(yyvsp[-3].node); addLinkToList((yyval.node), (yyvsp[-1].node)); }
#line 2977 "c.tab.c"
    break;

  case 191: /* initializer: assignment_expression  */
#line 530 "c.y"
                                                                                                                                                        { (yyval.node) = CreateInitializerNode((yyvsp[0].node)); }
#line 2983 "c.tab.c"
    break;

  case 192: /* initializer: LEFT_BRACE initializer_list RIGHT_BRACE  */
#line 531 "c.y"
                                                                                                                                        { (yyval.node) = CreateInitializerNode((yyvsp[-1].node)); }
#line 2989 "c.tab.c"
    break;

  case 193: /* initializer: LEFT_BRACE initializer_list COMMA RIGHT_BRACE  */
#line 532 "c.y"
                                                                                                                                { (yyval.node) = CreateInitializerNode((yyvsp[-2].node)); }
#line 2995 "c.tab.c"
    break;

  case 194: /* initializer_list: initializer  */
#line 536 "c.y"
                                                                                                                                                                { (yyval.node) = CreateInitializerListNode((yyvsp[0].node), NULL); }
#line 3001 "c.tab.c"
    break;

  case 195: /* initializer_list: designation initializer  */
#line 537 "c.y"
                                                                                                                                                        { (yyval.node) = CreateInitializerListNode((yyvsp[-1].node), (yyvsp[0].node)); }
#line 3007 "c.tab.c"
    break;

  case 196: /* initializer_list: initializer_list COMMA initializer  */
#line 538 "c.y"
                                                                                                                                        { (yyval.node)=(yyvsp[-2].node); addLinkToList((yyval.node), (yyvsp[0].node)); }
#line 3013 "c.tab.c"
    break;

  case 197: /* initializer_list: initializer_list COMMA designation initializer  */
#line 539 "c.y"
                                                                                                                                { (yyval.node)=(yyvsp[-3].node); addLinkToList((yyval.node), (yyvsp[-1].node)); addLinkToList((yyval.node), (yyvsp[0].node)); }
#line 3019 "c.tab.c"
    break;

  case 198: /* designation: designator_list ASSIGN  */
#line 543 "c.y"
                                                                                                                                                        { (yyval.node) = CreateDesignationNode((yyvsp[-1].node)); }
#line 3025 "c.tab.c"
    break;

  case 199: /* designator_list: designator  */
#line 547 "c.y"
                                                                                                                                                                { (yyval.node) = CreateDesignatorListNode((yyvsp[0].node)); }
#line 3031 "c.tab.c"
    break;

  case 200: /* designator_list: designator_list designator  */
#line 548 "c.y"
                                                                                                                                                { (yyval.node)=(yyvsp[-1].node); addLinkToList((yyval.node), (yyvsp[0].node)); }
#line 3037 "c.tab.c"
    break;

  case 201: /* designator: LEFT_BRACKET constant_expression RIGHT_BRACKET  */
#line 552 "c.y"
                                                                                                                                { (yyval.node) = CreateDesignatorNode((yyvsp[-1].node)); }
#line 3043 "c.tab.c"
    break;

  case 202: /* designator: POINT IDENTIFIER  */
#line 553 "c.y"
                                                                                                                                                                { (yyval.node) = CreateDesignatorNode(CreateIdentifierNode((yyvsp[0].strings))); }
#line 3049 "c.tab.c"
    break;

  case 203: /* statement: labeled_statement  */
#line 557 "c.y"
                                                                                                                                                                { (yyval.node) = CreateStatementNode((yyvsp[0].node)); }
#line 3055 "c.tab.c"
    break;

  case 204: /* statement: compound_statement  */
#line 558 "c.y"
                                                                                                                                                        { (yyval.node) = CreateStatementNode((yyvsp[0].node)); }
#line 3061 "c.tab.c"
    break;

  case 205: /* statement: expression_statement  */
#line 559 "c.y"
                                                                                                                                                        { (yyval.node) = CreateStatementNode((yyvsp[0].node)); }
#line 3067 "c.tab.c"
    break;

  case 206: /* statement: selection_statement  */
#line 560 "c.y"
                                                                                                                                                        { (yyval.node) = CreateStatementNode((yyvsp[0].node)); }
#line 3073 "c.tab.c"
    break;

  case 207: /* statement: iteration_statement  */
#line 561 "c.y"
                                                                                                                                                        { (yyval.node) = CreateStatementNode((yyvsp[0].node)); }
#line 3079 "c.tab.c"
    break;

  case 208: /* statement: jump_statement  */
#line 562 "c.y"
                                                                                                                                                                { (yyval.node) = CreateStatementNode((yyvsp[0].node)); }
#line 3085 "c.tab.c"
    break;

  case 209: /* labeled_statement: IDENTIFIER TWO_POINTS statement  */
#line 566 "c.y"
                                                                                                                                                { (yyval.node) = CreateLabeledStatementNode(CreateIdentifierNode((yyvsp[-2].strings)),(yyvsp[0].node)); }
#line 3091 "c.tab.c"
    break;

  case 210: /* labeled_statement: CASE constant_expression TWO_POINTS statement  */
#line 567 "c.y"
                                                                                                                                { (yyval.node) = CreateLabeledStatementNode((yyvsp[-2].node),(yyvsp[0].node)); }
#line 3097 "c.tab.c"
    break;

  case 211: /* labeled_statement: DEFAULT TWO_POINTS statement  */
#line 568 "c.y"
                                                                                                                                                { (yyval.node) = CreateLabeledStatementNode(CreateOnlyDataNode("DEFAULT"),(yyvsp[0].node)); }
#line 3103 "c.tab.c"
    break;

  case 212: /* compound_statement: LEFT_BRACE RIGHT_BRACE  */
#line 572 "c.y"
                                                                                                                                                        { (yyval.node) = CreateCompoundStatementNode(CreateOnlyDataNode("EMPTY")); }
#line 3109 "c.tab.c"
    break;

  case 213: /* compound_statement: LEFT_BRACE block_item_list RIGHT_BRACE  */
#line 573 "c.y"
                                                                                                                                        { (yyval.node) = CreateCompoundStatementNode((yyvsp[-1].node)); }
#line 3115 "c.tab.c"
    break;

  case 214: /* block_item_list: block_item  */
#line 577 "c.y"
                                                                                                                                                                { (yyval.node) = CreateBlockItemListNode((yyvsp[0].node)); }
#line 3121 "c.tab.c"
    break;

  case 215: /* block_item_list: block_item_list block_item  */
#line 578 "c.y"
                                                                                                                                                { (yyval.node)=(yyvsp[-1].node); addLinkToList((yyval.node), (yyvsp[0].node)); }
#line 3127 "c.tab.c"
    break;

  case 216: /* block_item: declaration  */
#line 582 "c.y"
                                                                                                                                                                { (yyval.node) = CreateBlockItemNode((yyvsp[0].node)); }
#line 3133 "c.tab.c"
    break;

  case 217: /* block_item: statement  */
#line 583 "c.y"
                                                                                                                                                                        { (yyval.node) = CreateBlockItemNode((yyvsp[0].node)); }
#line 3139 "c.tab.c"
    break;

  case 218: /* expression_statement: END_OF_INSTRUCTION  */
#line 587 "c.y"
                                                                                                                                                        { (yyval.node) = CreateExpressionStatementNode(CreateOnlyDataNode("END_OF_INSTRUCTION")); }
#line 3145 "c.tab.c"
    break;

  case 219: /* expression_statement: expression END_OF_INSTRUCTION  */
#line 588 "c.y"
                                                                                                                                                { (yyval.node) = CreateExpressionStatementNode((yyvsp[-1].node)); }
#line 3151 "c.tab.c"
    break;

  case 220: /* selection_statement: IF LEFT_PARANTH expression RIGHT_PARANTH statement  */
#line 592 "c.y"
                                                                                                                        { (yyval.node) = CreateSelectionStatementNode((yyvsp[-2].node),(yyvsp[0].node), NULL); }
#line 3157 "c.tab.c"
    break;

  case 221: /* selection_statement: IF LEFT_PARANTH expression RIGHT_PARANTH statement ELSE statement  */
#line 593 "c.y"
                                                                                                                { (yyval.node) = CreateSelectionStatementNode((yyvsp[-4].node),(yyvsp[-2].node), (yyvsp[0].node)); }
#line 3163 "c.tab.c"
    break;

  case 222: /* selection_statement: SWITCH LEFT_PARANTH expression RIGHT_PARANTH statement  */
#line 594 "c.y"
                                                                                                                        { (yyval.node) = CreateSelectionStatementNode((yyvsp[-2].node),(yyvsp[0].node), NULL); }
#line 3169 "c.tab.c"
    break;

  case 223: /* iteration_statement: WHILE LEFT_PARANTH expression RIGHT_PARANTH statement  */
#line 598 "c.y"
                                                                                                                                                                { (yyval.node) = CreateIterationStatementNode((yyvsp[-2].node),(yyvsp[0].node), NULL, NULL); }
#line 3175 "c.tab.c"
    break;

  case 224: /* iteration_statement: DO statement WHILE LEFT_PARANTH expression RIGHT_PARANTH END_OF_INSTRUCTION  */
#line 599 "c.y"
                                                                                                                                        { (yyval.node) = CreateIterationStatementNode((yyvsp[-5].node),(yyvsp[-2].node), NULL, NULL); }
#line 3181 "c.tab.c"
    break;

  case 225: /* iteration_statement: FOR LEFT_PARANTH expression_statement expression_statement RIGHT_PARANTH statement  */
#line 600 "c.y"
                                                                                                                                { (yyval.node) = CreateIterationStatementNode((yyvsp[-3].node),(yyvsp[-2].node), (yyvsp[0].node), NULL); }
#line 3187 "c.tab.c"
    break;

  case 226: /* iteration_statement: FOR LEFT_PARANTH expression_statement expression_statement expression RIGHT_PARANTH statement  */
#line 601 "c.y"
                                                                                                                        { (yyval.node) = CreateIterationStatementNode((yyvsp[-4].node),(yyvsp[-3].node), (yyvsp[-2].node), (yyvsp[0].node)); }
#line 3193 "c.tab.c"
    break;

  case 227: /* iteration_statement: FOR LEFT_PARANTH declaration expression_statement RIGHT_PARANTH statement  */
#line 602 "c.y"
                                                                                                                                                { (yyval.node) = CreateIterationStatementNode((yyvsp[-3].node),(yyvsp[-2].node), (yyvsp[0].node), NULL); }
#line 3199 "c.tab.c"
    break;

  case 228: /* iteration_statement: FOR LEFT_PARANTH declaration expression_statement expression RIGHT_PARANTH statement  */
#line 603 "c.y"
                                                                                                                                { (yyval.node) = CreateIterationStatementNode((yyvsp[-4].node),(yyvsp[-3].node), (yyvsp[-2].node), (yyvsp[0].node)); }
#line 3205 "c.tab.c"
    break;

  case 229: /* jump_statement: GOTO IDENTIFIER END_OF_INSTRUCTION  */
#line 607 "c.y"
                                                                        { (yyval.node) = CreateJumpStatementNode(CreateIdentifierNode((yyvsp[-1].strings))); }
#line 3211 "c.tab.c"
    break;

  case 230: /* jump_statement: CONTINUE END_OF_INSTRUCTION  */
#line 608 "c.y"
                                                                                { (yyval.node) = CreateJumpStatementNode(CreateOnlyDataNode("CONTINUE")); }
#line 3217 "c.tab.c"
    break;

  case 231: /* jump_statement: BREAK END_OF_INSTRUCTION  */
#line 609 "c.y"
                                                                                        { (yyval.node) = CreateJumpStatementNode(CreateOnlyDataNode("BREAK")); }
#line 3223 "c.tab.c"
    break;

  case 232: /* jump_statement: RETURN END_OF_INSTRUCTION  */
#line 610 "c.y"
                                                                                        { (yyval.node) = CreateJumpStatementNode(CreateOnlyDataNode("RETURN")); }
#line 3229 "c.tab.c"
    break;

  case 233: /* jump_statement: RETURN expression END_OF_INSTRUCTION  */
#line 611 "c.y"
                                                                        { (yyval.node) = CreateJumpStatementNode((yyvsp[-1].node)); }
#line 3235 "c.tab.c"
    break;

  case 234: /* translation_unit: external_declaration  */
#line 615 "c.y"
                                                                                        { (yyval.node) = CreateTranslationUnitNode((yyvsp[0].node)); }
#line 3241 "c.tab.c"
    break;

  case 235: /* translation_unit: translation_unit external_declaration  */
#line 616 "c.y"
                                                                        { (yyval.node)=(yyvsp[-1].node); addLinkToList((yyval.node), (yyvsp[0].node)); }
#line 3247 "c.tab.c"
    break;

  case 236: /* external_declaration: function_definition  */
#line 620 "c.y"
                                                                                        { (yyval.node) = CreateExternalDeclarationNode((yyvsp[0].node)); }
#line 3253 "c.tab.c"
    break;

  case 237: /* external_declaration: declaration  */
#line 621 "c.y"
                                                                                                { (yyval.node) = CreateExternalDeclarationNode((yyvsp[0].node)); }
#line 3259 "c.tab.c"
    break;

  case 238: /* function_definition: declaration_specifiers declarator declaration_list compound_statement  */
#line 625 "c.y"
                                                                                                { (yyval.node) = CreateFunctionDefinitionNode((yyvsp[-3].node),(yyvsp[-2].node),(yyvsp[-1].node),(yyvsp[0].node)); }
#line 3265 "c.tab.c"
    break;

  case 239: /* function_definition: declaration_specifiers declarator compound_statement  */
#line 626 "c.y"
                                                                                                                { (yyval.node) = CreateFunctionDefinitionNode((yyvsp[-2].node),(yyvsp[-1].node),(yyvsp[0].node),NULL); }
#line 3271 "c.tab.c"
    break;

  case 240: /* declaration_list: declaration  */
#line 630 "c.y"
                                                                                                { (yyval.node) = CreateDeclarationListNode((yyvsp[0].node)); }
#line 3277 "c.tab.c"
    break;

  case 241: /* declaration_list: declaration_list declaration  */
#line 631 "c.y"
                                                                                { (yyval.node)=(yyvsp[-1].node); addLinkToList((yyval.node), (yyvsp[0].node)); }
#line 3283 "c.tab.c"
    break;


#line 3287 "c.tab.c"

      default: break;
    }
  /* User semantic actions sometimes alter yychar, and that requires
     that yytoken be updated with the new translation.  We take the
     approach of translating immediately before every use of yytoken.
     One alternative is translating here after every semantic action,
     but that translation would be missed if the semantic action invokes
     YYABORT, YYACCEPT, or YYERROR immediately after altering yychar or
     if it invokes YYBACKUP.  In the case of YYABORT or YYACCEPT, an
     incorrect destructor might then be invoked immediately.  In the
     case of YYERROR or YYBACKUP, subsequent parser actions might lead
     to an incorrect destructor call or verbose syntax error message
     before the lookahead is translated.  */
  YY_SYMBOL_PRINT ("-> $$ =", YY_CAST (yysymbol_kind_t, yyr1[yyn]), &yyval, &yyloc);

  YYPOPSTACK (yylen);
  yylen = 0;

  *++yyvsp = yyval;

  /* Now 'shift' the result of the reduction.  Determine what state
     that goes to, based on the state we popped back to and the rule
     number reduced by.  */
  {
    const int yylhs = yyr1[yyn] - YYNTOKENS;
    const int yyi = yypgoto[yylhs] + *yyssp;
    yystate = (0 <= yyi && yyi <= YYLAST && yycheck[yyi] == *yyssp
               ? yytable[yyi]
               : yydefgoto[yylhs]);
  }

  goto yynewstate;


/*--------------------------------------.
| yyerrlab -- here on detecting error.  |
`--------------------------------------*/
yyerrlab:
  /* Make sure we have latest lookahead translation.  See comments at
     user semantic actions for why this is necessary.  */
  yytoken = yychar == YYEMPTY ? YYSYMBOL_YYEMPTY : YYTRANSLATE (yychar);
  /* If not already recovering from an error, report this error.  */
  if (!yyerrstatus)
    {
      ++yynerrs;
      yyerror (YY_("syntax error"));
    }

  if (yyerrstatus == 3)
    {
      /* If just tried and failed to reuse lookahead token after an
         error, discard it.  */

      if (yychar <= YYEOF)
        {
          /* Return failure if at end of input.  */
          if (yychar == YYEOF)
            YYABORT;
        }
      else
        {
          yydestruct ("Error: discarding",
                      yytoken, &yylval);
          yychar = YYEMPTY;
        }
    }

  /* Else will try to reuse lookahead token after shifting the error
     token.  */
  goto yyerrlab1;


/*---------------------------------------------------.
| yyerrorlab -- error raised explicitly by YYERROR.  |
`---------------------------------------------------*/
yyerrorlab:
  /* Pacify compilers when the user code never invokes YYERROR and the
     label yyerrorlab therefore never appears in user code.  */
  if (0)
    YYERROR;

  /* Do not reclaim the symbols of the rule whose action triggered
     this YYERROR.  */
  YYPOPSTACK (yylen);
  yylen = 0;
  YY_STACK_PRINT (yyss, yyssp);
  yystate = *yyssp;
  goto yyerrlab1;


/*-------------------------------------------------------------.
| yyerrlab1 -- common code for both syntax error and YYERROR.  |
`-------------------------------------------------------------*/
yyerrlab1:
  yyerrstatus = 3;      /* Each real token shifted decrements this.  */

  /* Pop stack until we find a state that shifts the error token.  */
  for (;;)
    {
      yyn = yypact[yystate];
      if (!yypact_value_is_default (yyn))
        {
          yyn += YYSYMBOL_YYerror;
          if (0 <= yyn && yyn <= YYLAST && yycheck[yyn] == YYSYMBOL_YYerror)
            {
              yyn = yytable[yyn];
              if (0 < yyn)
                break;
            }
        }

      /* Pop the current state because it cannot handle the error token.  */
      if (yyssp == yyss)
        YYABORT;


      yydestruct ("Error: popping",
                  YY_ACCESSING_SYMBOL (yystate), yyvsp);
      YYPOPSTACK (1);
      yystate = *yyssp;
      YY_STACK_PRINT (yyss, yyssp);
    }

  YY_IGNORE_MAYBE_UNINITIALIZED_BEGIN
  *++yyvsp = yylval;
  YY_IGNORE_MAYBE_UNINITIALIZED_END


  /* Shift the error token.  */
  YY_SYMBOL_PRINT ("Shifting", YY_ACCESSING_SYMBOL (yyn), yyvsp, yylsp);

  yystate = yyn;
  goto yynewstate;


/*-------------------------------------.
| yyacceptlab -- YYACCEPT comes here.  |
`-------------------------------------*/
yyacceptlab:
  yyresult = 0;
  goto yyreturn;


/*-----------------------------------.
| yyabortlab -- YYABORT comes here.  |
`-----------------------------------*/
yyabortlab:
  yyresult = 1;
  goto yyreturn;


#if !defined yyoverflow
/*-------------------------------------------------.
| yyexhaustedlab -- memory exhaustion comes here.  |
`-------------------------------------------------*/
yyexhaustedlab:
  yyerror (YY_("memory exhausted"));
  yyresult = 2;
  goto yyreturn;
#endif


/*-------------------------------------------------------.
| yyreturn -- parsing is finished, clean up and return.  |
`-------------------------------------------------------*/
yyreturn:
  if (yychar != YYEMPTY)
    {
      /* Make sure we have latest lookahead translation.  See comments at
         user semantic actions for why this is necessary.  */
      yytoken = YYTRANSLATE (yychar);
      yydestruct ("Cleanup: discarding lookahead",
                  yytoken, &yylval);
    }
  /* Do not reclaim the symbols of the rule whose action triggered
     this YYABORT or YYACCEPT.  */
  YYPOPSTACK (yylen);
  YY_STACK_PRINT (yyss, yyssp);
  while (yyssp != yyss)
    {
      yydestruct ("Cleanup: popping",
                  YY_ACCESSING_SYMBOL (+*yyssp), yyvsp);
      YYPOPSTACK (1);
    }
#ifndef yyoverflow
  if (yyss != yyssa)
    YYSTACK_FREE (yyss);
#endif

  return yyresult;
}

#line 636 "c.y"

#include <stdio.h>

extern char yytext[];
extern int column;

yyerror(char const *s)
{
	fflush(stdout);
	printf("\n%*s\n%*s\n", column, "^", column, s);
}
