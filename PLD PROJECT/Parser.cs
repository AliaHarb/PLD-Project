
using System;
using System.IO;
using System.Runtime.Serialization;
using com.calitha.goldparser.lalr;
using com.calitha.commons;

namespace com.calitha.goldparser
{

    [Serializable()]
    public class SymbolException : System.Exception
    {
        public SymbolException(string message) : base(message)
        {
        }

        public SymbolException(string message,
            Exception inner) : base(message, inner)
        {
        }

        protected SymbolException(SerializationInfo info,
            StreamingContext context) : base(info, context)
        {
        }

    }

    [Serializable()]
    public class RuleException : System.Exception
    {

        public RuleException(string message) : base(message)
        {
        }

        public RuleException(string message,
                             Exception inner) : base(message, inner)
        {
        }

        protected RuleException(SerializationInfo info,
                                StreamingContext context) : base(info, context)
        {
        }

    }

    enum SymbolConstants : int
    {
        SYMBOL_EOF            =  0, // (EOF)
        SYMBOL_ERROR          =  1, // (Error)
        SYMBOL_COMMENT        =  2, // Comment
        SYMBOL_WHITESPACE     =  3, // Whitespace
        SYMBOL_MINUS          =  4, // '-'
        SYMBOL_MINUSMINUS     =  5, // '--'
        SYMBOL_EXCLAMEQ       =  6, // '!='
        SYMBOL_PERCENT        =  7, // '%'
        SYMBOL_LPAREN         =  8, // '('
        SYMBOL_RPAREN         =  9, // ')'
        SYMBOL_TIMES          = 10, // '*'
        SYMBOL_TIMESTIMES     = 11, // '**'
        SYMBOL_COMMA          = 12, // ','
        SYMBOL_DIV            = 13, // '/'
        SYMBOL_COLON          = 14, // ':'
        SYMBOL_SEMI           = 15, // ';'
        SYMBOL_LBRACE         = 16, // '{'
        SYMBOL_RBRACE         = 17, // '}'
        SYMBOL_PLUS           = 18, // '+'
        SYMBOL_PLUSPLUS       = 19, // '++'
        SYMBOL_LT             = 20, // '<'
        SYMBOL_EQ             = 21, // '='
        SYMBOL_EQEQ           = 22, // '=='
        SYMBOL_GT             = 23, // '>'
        SYMBOL_ACTION         = 24, // Action
        SYMBOL_AND            = 25, // AND
        SYMBOL_BREAK          = 26, // Break
        SYMBOL_CHECK          = 27, // Check
        SYMBOL_EQUAL          = 28, // equal
        SYMBOL_FIXED          = 29, // Fixed
        SYMBOL_FLOAT          = 30, // float
        SYMBOL_GET_DATA       = 31, // 'Get_Data'
        SYMBOL_GIVE_BACK      = 32, // 'Give_Back'
        SYMBOL_ID             = 33, // Id
        SYMBOL_INT            = 34, // int
        SYMBOL_KEEP           = 35, // Keep
        SYMBOL_LAUNCH         = 36, // Launch
        SYMBOL_LOOP           = 37, // Loop
        SYMBOL_NUMBER         = 38, // Number
        SYMBOL_OPTION         = 39, // Option
        SYMBOL_OR             = 40, // OR
        SYMBOL_OTHERWISE      = 41, // Otherwise
        SYMBOL_PICK           = 42, // Pick
        SYMBOL_REVERSE        = 43, // Reverse
        SYMBOL_SHOW_ME        = 44, // 'show_Me'
        SYMBOL_STANDARD       = 45, // Standard
        SYMBOL_STRING         = 46, // string
        SYMBOL_STRINGLITERAL  = 47, // StringLiteral
        SYMBOL_TERMINATE      = 48, // Terminate
        SYMBOL_TRUEORFALSE    = 49, // TrueOrFalse
        SYMBOL_ASSIGN         = 50, // <assign>
        SYMBOL_BLOCK          = 51, // <block>
        SYMBOL_CASES          = 52, // <cases>
        SYMBOL_COMMAND        = 53, // <Command>
        SYMBOL_COMPARISON     = 54, // <comparison>
        SYMBOL_COND           = 55, // <cond>
        SYMBOL_DATA_TYPE      = 56, // <data_type>
        SYMBOL_EXP            = 57, // <exp>
        SYMBOL_EXPR           = 58, // <expr>
        SYMBOL_FACTOR         = 59, // <factor>
        SYMBOL_FOR            = 60, // <for>
        SYMBOL_ID2            = 61, // <id>
        SYMBOL_IF             = 62, // <if>
        SYMBOL_INITIALIZATION = 63, // <initialization>
        SYMBOL_INPUT_STMT     = 64, // <input_stmt>
        SYMBOL_ITERATOR       = 65, // <iterator>
        SYMBOL_LOGICAL_AND    = 66, // <logical_and>
        SYMBOL_LOGICAL_OR     = 67, // <logical_or>
        SYMBOL_METHOD_DEF     = 68, // <method_def>
        SYMBOL_OP             = 69, // <op>
        SYMBOL_PARAMS         = 70, // <params>
        SYMBOL_PICK_STMT      = 71, // <pick_stmt>
        SYMBOL_PRINT_STMT     = 72, // <print_stmt>
        SYMBOL_PROGRAM        = 73, // <Program>
        SYMBOL_RETURN_STMT    = 74, // <return_stmt>
        SYMBOL_TERM           = 75, // <term>
        SYMBOL_WHILE_STMT     = 76  // <while_stmt>
    };

    enum RuleConstants : int
    {
        RULE_PROGRAM_LAUNCH_TERMINATE                                     =  0, // <Program> ::= Launch <block> Terminate
        RULE_BLOCK                                                        =  1, // <block> ::= <Command>
        RULE_BLOCK2                                                       =  2, // <block> ::= <Command> <block>
        RULE_COMMAND                                                      =  3, // <Command> ::= <initialization>
        RULE_COMMAND2                                                     =  4, // <Command> ::= <assign>
        RULE_COMMAND3                                                     =  5, // <Command> ::= <if>
        RULE_COMMAND4                                                     =  6, // <Command> ::= <for>
        RULE_COMMAND5                                                     =  7, // <Command> ::= <return_stmt>
        RULE_COMMAND6                                                     =  8, // <Command> ::= <while_stmt>
        RULE_COMMAND7                                                     =  9, // <Command> ::= <pick_stmt>
        RULE_COMMAND8                                                     = 10, // <Command> ::= <print_stmt>
        RULE_COMMAND9                                                     = 11, // <Command> ::= <method_def>
        RULE_COMMAND_SEMI                                                 = 12, // <Command> ::= <iterator> ';'
        RULE_COMMAND10                                                    = 13, // <Command> ::= <input_stmt>
        RULE_INITIALIZATION_ID_EQUAL_SEMI                                 = 14, // <initialization> ::= <data_type> Id equal <expr> ';'
        RULE_INITIALIZATION_FIXED_ID_EQUAL_SEMI                           = 15, // <initialization> ::= Fixed <data_type> Id equal <expr> ';'
        RULE_DATA_TYPE_INT                                                = 16, // <data_type> ::= int
        RULE_DATA_TYPE_FLOAT                                              = 17, // <data_type> ::= float
        RULE_DATA_TYPE_STRING                                             = 18, // <data_type> ::= string
        RULE_DATA_TYPE_TRUEORFALSE                                        = 19, // <data_type> ::= TrueOrFalse
        RULE_PRINT_STMT_SHOW_ME_LPAREN_RPAREN_SEMI                        = 20, // <print_stmt> ::= 'show_Me' '(' <expr> ')' ';'
        RULE_INPUT_STMT_GET_DATA_LPAREN_ID_RPAREN_SEMI                    = 21, // <input_stmt> ::= 'Get_Data' '(' Id ')' ';'
        RULE_ASSIGN_EQ_SEMI                                               = 22, // <assign> ::= <id> '=' <expr> ';'
        RULE_ID_ID                                                        = 23, // <id> ::= Id
        RULE_EXPR_PLUS                                                    = 24, // <expr> ::= <expr> '+' <term>
        RULE_EXPR_MINUS                                                   = 25, // <expr> ::= <expr> '-' <term>
        RULE_EXPR                                                         = 26, // <expr> ::= <term>
        RULE_TERM_TIMES                                                   = 27, // <term> ::= <term> '*' <factor>
        RULE_TERM_DIV                                                     = 28, // <term> ::= <term> '/' <factor>
        RULE_TERM_PERCENT                                                 = 29, // <term> ::= <term> '%' <factor>
        RULE_TERM                                                         = 30, // <term> ::= <factor>
        RULE_FACTOR_TIMESTIMES                                            = 31, // <factor> ::= <factor> '**' <exp>
        RULE_FACTOR                                                       = 32, // <factor> ::= <exp>
        RULE_EXP_LPAREN_RPAREN                                            = 33, // <exp> ::= '(' <expr> ')'
        RULE_EXP                                                          = 34, // <exp> ::= <id>
        RULE_EXP_NUMBER                                                   = 35, // <exp> ::= Number
        RULE_EXP_STRINGLITERAL                                            = 36, // <exp> ::= StringLiteral
        RULE_COND                                                         = 37, // <cond> ::= <logical_or>
        RULE_LOGICAL_OR_OR                                                = 38, // <logical_or> ::= <logical_or> OR <logical_and>
        RULE_LOGICAL_OR                                                   = 39, // <logical_or> ::= <logical_and>
        RULE_LOGICAL_AND_AND                                              = 40, // <logical_and> ::= <logical_and> AND <comparison>
        RULE_LOGICAL_AND                                                  = 41, // <logical_and> ::= <comparison>
        RULE_COMPARISON                                                   = 42, // <comparison> ::= <expr> <op> <expr>
        RULE_COMPARISON_REVERSE_LPAREN_RPAREN                             = 43, // <comparison> ::= Reverse '(' <cond> ')'
        RULE_OP_LT                                                        = 44, // <op> ::= '<'
        RULE_OP_GT                                                        = 45, // <op> ::= '>'
        RULE_OP_EQEQ                                                      = 46, // <op> ::= '=='
        RULE_OP_EXCLAMEQ                                                  = 47, // <op> ::= '!='
        RULE_IF_CHECK_LPAREN_RPAREN_LBRACE_RBRACE                         = 48, // <if> ::= Check '(' <cond> ')' '{' <block> '}'
        RULE_IF_CHECK_LPAREN_RPAREN_LBRACE_RBRACE_OTHERWISE_LBRACE_RBRACE = 49, // <if> ::= Check '(' <cond> ')' '{' <block> '}' Otherwise '{' <block> '}'
        RULE_PICK_STMT_PICK_LPAREN_ID_RPAREN_LBRACE_RBRACE                = 50, // <pick_stmt> ::= Pick '(' Id ')' '{' <cases> '}'
        RULE_CASES_OPTION_NUMBER_COLON_BREAK_SEMI                         = 51, // <cases> ::= Option Number ':' <block> Break ';'
        RULE_CASES_OPTION_NUMBER_COLON_BREAK_SEMI2                        = 52, // <cases> ::= Option Number ':' <block> Break ';' <cases>
        RULE_CASES_STANDARD_COLON_BREAK_SEMI                              = 53, // <cases> ::= Standard ':' <block> Break ';'
        RULE_WHILE_STMT_KEEP_LPAREN_RPAREN_LBRACE_RBRACE                  = 54, // <while_stmt> ::= Keep '(' <cond> ')' '{' <block> '}'
        RULE_FOR_LOOP_LPAREN_ID_EQUAL_SEMI_SEMI_RPAREN_LBRACE_RBRACE      = 55, // <for> ::= Loop '(' <data_type> Id equal <expr> ';' <cond> ';' <iterator> ')' '{' <block> '}'
        RULE_ITERATOR_ID_EQ                                               = 56, // <iterator> ::= Id '=' <expr>
        RULE_ITERATOR_MINUSMINUS_ID                                       = 57, // <iterator> ::= '--' Id
        RULE_ITERATOR_PLUSPLUS_ID                                         = 58, // <iterator> ::= '++' Id
        RULE_ITERATOR_ID_MINUSMINUS                                       = 59, // <iterator> ::= Id '--'
        RULE_ITERATOR_ID_PLUSPLUS                                         = 60, // <iterator> ::= Id '++'
        RULE_METHOD_DEF_ACTION_ID_LPAREN_RPAREN_LBRACE_RBRACE             = 61, // <method_def> ::= Action Id '(' <params> ')' '{' <block> '}'
        RULE_RETURN_STMT_GIVE_BACK_SEMI                                   = 62, // <return_stmt> ::= 'Give_Back' <expr> ';'
        RULE_PARAMS_ID                                                    = 63, // <params> ::= <data_type> Id
        RULE_PARAMS_ID_COMMA                                              = 64, // <params> ::= <data_type> Id ',' <params>
        RULE_PARAMS                                                       = 65  // <params> ::= 
    };

    public class MyParser
    {
        private LALRParser parser;
        ListBox lst;
        ListBox ls;
        public MyParser(string filename,ListBox lst,ListBox ls)
        {
            FileStream stream = new FileStream(filename,
                                               FileMode.Open, 
                                               FileAccess.Read, 
                                               FileShare.Read);
            this.lst = lst;
            this.ls = ls;
            Init(stream);
            stream.Close();
        }

        public MyParser(string baseName, string resourceName)
        {
            byte[] buffer = ResourceUtil.GetByteArrayResource(
                System.Reflection.Assembly.GetExecutingAssembly(),
                baseName,
                resourceName);
            MemoryStream stream = new MemoryStream(buffer);
            Init(stream);
            stream.Close();
        }

        public MyParser(Stream stream)
        {
            Init(stream);
        }

        private void Init(Stream stream)
        {
            CGTReader reader = new CGTReader(stream);
            parser = reader.CreateNewParser();
            parser.TrimReductions = false;
            parser.StoreTokens = LALRParser.StoreTokensMode.NoUserObject;

            parser.OnTokenError += new LALRParser.TokenErrorHandler(TokenErrorEvent);
            parser.OnParseError += new LALRParser.ParseErrorHandler(ParseErrorEvent);
            parser.OnTokenRead +=new LALRParser.TokenReadHandler(TokenReadEvent);
        }

        public void Parse(string source)
        {
            NonterminalToken token = parser.Parse(source);
            if (token != null)
            {
                Object obj = CreateObject(token);
                //todo: Use your object any way you like
            }
        }

        private Object CreateObject(Token token)
        {
            if (token is TerminalToken)
                return CreateObjectFromTerminal((TerminalToken)token);
            else
                return CreateObjectFromNonterminal((NonterminalToken)token);
        }

        private Object CreateObjectFromTerminal(TerminalToken token)
        {
            switch (token.Symbol.Id)
            {
                case (int)SymbolConstants.SYMBOL_EOF :
                //(EOF)
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_ERROR :
                //(Error)
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_COMMENT :
                //Comment
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_WHITESPACE :
                //Whitespace
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_MINUS :
                //'-'
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_MINUSMINUS :
                //'--'
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_EXCLAMEQ :
                //'!='
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_PERCENT :
                //'%'
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_LPAREN :
                //'('
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_RPAREN :
                //')'
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_TIMES :
                //'*'
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_TIMESTIMES :
                //'**'
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_COMMA :
                //','
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_DIV :
                //'/'
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_COLON :
                //':'
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_SEMI :
                //';'
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_LBRACE :
                //'{'
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_RBRACE :
                //'}'
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_PLUS :
                //'+'
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_PLUSPLUS :
                //'++'
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_LT :
                //'<'
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_EQ :
                //'='
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_EQEQ :
                //'=='
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_GT :
                //'>'
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_ACTION :
                //Action
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_AND :
                //AND
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_BREAK :
                //Break
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_CHECK :
                //Check
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_EQUAL :
                //equal
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_FIXED :
                //Fixed
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_FLOAT :
                //float
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_GET_DATA :
                //'Get_Data'
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_GIVE_BACK :
                //'Give_Back'
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_ID :
                //Id
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_INT :
                //int
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_KEEP :
                //Keep
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_LAUNCH :
                //Launch
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_LOOP :
                //Loop
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_NUMBER :
                //Number
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_OPTION :
                //Option
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_OR :
                //OR
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_OTHERWISE :
                //Otherwise
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_PICK :
                //Pick
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_REVERSE :
                //Reverse
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_SHOW_ME :
                //'show_Me'
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_STANDARD :
                //Standard
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_STRING :
                //string
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_STRINGLITERAL :
                //StringLiteral
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_TERMINATE :
                //Terminate
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_TRUEORFALSE :
                //TrueOrFalse
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_ASSIGN :
                //<assign>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_BLOCK :
                //<block>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_CASES :
                //<cases>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_COMMAND :
                //<Command>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_COMPARISON :
                //<comparison>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_COND :
                //<cond>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_DATA_TYPE :
                //<data_type>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_EXP :
                //<exp>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_EXPR :
                //<expr>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_FACTOR :
                //<factor>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_FOR :
                //<for>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_ID2 :
                //<id>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_IF :
                //<if>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_INITIALIZATION :
                //<initialization>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_INPUT_STMT :
                //<input_stmt>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_ITERATOR :
                //<iterator>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_LOGICAL_AND :
                //<logical_and>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_LOGICAL_OR :
                //<logical_or>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_METHOD_DEF :
                //<method_def>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_OP :
                //<op>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_PARAMS :
                //<params>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_PICK_STMT :
                //<pick_stmt>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_PRINT_STMT :
                //<print_stmt>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_PROGRAM :
                //<Program>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_RETURN_STMT :
                //<return_stmt>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_TERM :
                //<term>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_WHILE_STMT :
                //<while_stmt>
                //todo: Create a new object that corresponds to the symbol
                return null;

            }
            throw new SymbolException("Unknown symbol");
        }

        public Object CreateObjectFromNonterminal(NonterminalToken token)
        {
            switch (token.Rule.Id)
            {
                case (int)RuleConstants.RULE_PROGRAM_LAUNCH_TERMINATE :
                //<Program> ::= Launch <block> Terminate
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_BLOCK :
                //<block> ::= <Command>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_BLOCK2 :
                //<block> ::= <Command> <block>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_COMMAND :
                //<Command> ::= <initialization>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_COMMAND2 :
                //<Command> ::= <assign>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_COMMAND3 :
                //<Command> ::= <if>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_COMMAND4 :
                //<Command> ::= <for>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_COMMAND5 :
                //<Command> ::= <return_stmt>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_COMMAND6 :
                //<Command> ::= <while_stmt>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_COMMAND7 :
                //<Command> ::= <pick_stmt>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_COMMAND8 :
                //<Command> ::= <print_stmt>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_COMMAND9 :
                //<Command> ::= <method_def>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_COMMAND_SEMI :
                //<Command> ::= <iterator> ';'
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_COMMAND10 :
                //<Command> ::= <input_stmt>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_INITIALIZATION_ID_EQUAL_SEMI :
                //<initialization> ::= <data_type> Id equal <expr> ';'
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_INITIALIZATION_FIXED_ID_EQUAL_SEMI :
                //<initialization> ::= Fixed <data_type> Id equal <expr> ';'
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_DATA_TYPE_INT :
                //<data_type> ::= int
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_DATA_TYPE_FLOAT :
                //<data_type> ::= float
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_DATA_TYPE_STRING :
                //<data_type> ::= string
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_DATA_TYPE_TRUEORFALSE :
                //<data_type> ::= TrueOrFalse
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_PRINT_STMT_SHOW_ME_LPAREN_RPAREN_SEMI :
                //<print_stmt> ::= 'show_Me' '(' <expr> ')' ';'
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_INPUT_STMT_GET_DATA_LPAREN_ID_RPAREN_SEMI :
                //<input_stmt> ::= 'Get_Data' '(' Id ')' ';'
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_ASSIGN_EQ_SEMI :
                //<assign> ::= <id> '=' <expr> ';'
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_ID_ID :
                //<id> ::= Id
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_EXPR_PLUS :
                //<expr> ::= <expr> '+' <term>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_EXPR_MINUS :
                //<expr> ::= <expr> '-' <term>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_EXPR :
                //<expr> ::= <term>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_TERM_TIMES :
                //<term> ::= <term> '*' <factor>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_TERM_DIV :
                //<term> ::= <term> '/' <factor>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_TERM_PERCENT :
                //<term> ::= <term> '%' <factor>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_TERM :
                //<term> ::= <factor>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_FACTOR_TIMESTIMES :
                //<factor> ::= <factor> '**' <exp>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_FACTOR :
                //<factor> ::= <exp>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_EXP_LPAREN_RPAREN :
                //<exp> ::= '(' <expr> ')'
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_EXP :
                //<exp> ::= <id>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_EXP_NUMBER :
                //<exp> ::= Number
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_EXP_STRINGLITERAL :
                //<exp> ::= StringLiteral
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_COND :
                //<cond> ::= <logical_or>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_LOGICAL_OR_OR :
                //<logical_or> ::= <logical_or> OR <logical_and>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_LOGICAL_OR :
                //<logical_or> ::= <logical_and>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_LOGICAL_AND_AND :
                //<logical_and> ::= <logical_and> AND <comparison>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_LOGICAL_AND :
                //<logical_and> ::= <comparison>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_COMPARISON :
                //<comparison> ::= <expr> <op> <expr>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_COMPARISON_REVERSE_LPAREN_RPAREN :
                //<comparison> ::= Reverse '(' <cond> ')'
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_OP_LT :
                //<op> ::= '<'
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_OP_GT :
                //<op> ::= '>'
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_OP_EQEQ :
                //<op> ::= '=='
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_OP_EXCLAMEQ :
                //<op> ::= '!='
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_IF_CHECK_LPAREN_RPAREN_LBRACE_RBRACE :
                //<if> ::= Check '(' <cond> ')' '{' <block> '}'
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_IF_CHECK_LPAREN_RPAREN_LBRACE_RBRACE_OTHERWISE_LBRACE_RBRACE :
                //<if> ::= Check '(' <cond> ')' '{' <block> '}' Otherwise '{' <block> '}'
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_PICK_STMT_PICK_LPAREN_ID_RPAREN_LBRACE_RBRACE :
                //<pick_stmt> ::= Pick '(' Id ')' '{' <cases> '}'
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_CASES_OPTION_NUMBER_COLON_BREAK_SEMI :
                //<cases> ::= Option Number ':' <block> Break ';'
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_CASES_OPTION_NUMBER_COLON_BREAK_SEMI2 :
                //<cases> ::= Option Number ':' <block> Break ';' <cases>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_CASES_STANDARD_COLON_BREAK_SEMI :
                //<cases> ::= Standard ':' <block> Break ';'
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_WHILE_STMT_KEEP_LPAREN_RPAREN_LBRACE_RBRACE :
                //<while_stmt> ::= Keep '(' <cond> ')' '{' <block> '}'
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_FOR_LOOP_LPAREN_ID_EQUAL_SEMI_SEMI_RPAREN_LBRACE_RBRACE :
                //<for> ::= Loop '(' <data_type> Id equal <expr> ';' <cond> ';' <iterator> ')' '{' <block> '}'
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_ITERATOR_ID_EQ :
                //<iterator> ::= Id '=' <expr>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_ITERATOR_MINUSMINUS_ID :
                //<iterator> ::= '--' Id
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_ITERATOR_PLUSPLUS_ID :
                //<iterator> ::= '++' Id
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_ITERATOR_ID_MINUSMINUS :
                //<iterator> ::= Id '--'
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_ITERATOR_ID_PLUSPLUS :
                //<iterator> ::= Id '++'
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_METHOD_DEF_ACTION_ID_LPAREN_RPAREN_LBRACE_RBRACE :
                //<method_def> ::= Action Id '(' <params> ')' '{' <block> '}'
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_RETURN_STMT_GIVE_BACK_SEMI :
                //<return_stmt> ::= 'Give_Back' <expr> ';'
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_PARAMS_ID :
                //<params> ::= <data_type> Id
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_PARAMS_ID_COMMA :
                //<params> ::= <data_type> Id ',' <params>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_PARAMS :
                //<params> ::= 
                //todo: Create a new object using the stored tokens.
                return null;

            }
            throw new RuleException("Unknown rule");
        }

        private void TokenErrorEvent(LALRParser parser, TokenErrorEventArgs args)
        {
            string message = "Token error with input: '"+args.Token.ToString()+"'";
            //todo: Report message to UI?
        }

        private void ParseErrorEvent(LALRParser parser, ParseErrorEventArgs args)
        {
            string message = "Parse error caused by token: '"+args.UnexpectedToken.ToString()+" In Line"+args.UnexpectedToken.Location.LineNr;
            lst.Items.Add(message);
            string m2="Expected token: "+args.ExpectedTokens.ToString();
            lst.Items.Add(m2);
            //todo: Report message to UI?
        }

        private void TokenReadEvent (LALRParser parser, TokenReadEventArgs args)
        {
            string info = args.Token.Text + " \t \t  " +(SymbolConstants) args.Token.Symbol.Id;

            ls.Items.Add(info);
        }


    }
}
