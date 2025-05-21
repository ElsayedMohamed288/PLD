
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
        SYMBOL_EOF        =  0, // (EOF)
        SYMBOL_ERROR      =  1, // (Error)
        SYMBOL_WHITESPACE =  2, // Whitespace
        SYMBOL_MINUS      =  3, // '-'
        SYMBOL_MINUSMINUS =  4, // '--'
        SYMBOL_EXCLAMEQ   =  5, // '!='
        SYMBOL_PERCENT    =  6, // '%'
        SYMBOL_LPAREN     =  7, // '('
        SYMBOL_RPAREN     =  8, // ')'
        SYMBOL_TIMES      =  9, // '*'
        SYMBOL_TIMESTIMES = 10, // '**'
        SYMBOL_DIV        = 11, // '/'
        SYMBOL_PLUS       = 12, // '+'
        SYMBOL_PLUSPLUS   = 13, // '++'
        SYMBOL_LT         = 14, // '<'
        SYMBOL_EQ         = 15, // '='
        SYMBOL_EQEQ       = 16, // '=='
        SYMBOL_GT         = 17, // '>'
        SYMBOL_BEGIN      = 18, // Begin
        SYMBOL_CHECK      = 19, // check
        SYMBOL_DEC        = 20, // dec
        SYMBOL_DIGIT      = 21, // Digit
        SYMBOL_DO         = 22, // do
        SYMBOL_DONE       = 23, // Done
        SYMBOL_ELSE       = 24, // else
        SYMBOL_FROM       = 25, // from
        SYMBOL_ID         = 26, // Id
        SYMBOL_LOOP       = 27, // loop
        SYMBOL_NUM        = 28, // num
        SYMBOL_STEP       = 29, // step
        SYMBOL_TEXT       = 30, // text
        SYMBOL_TO         = 31, // to
        SYMBOL_WORD       = 32, // word
        SYMBOL_ASSIGN     = 33, // <assign>
        SYMBOL_CONCEPT    = 34, // <concept>
        SYMBOL_COND       = 35, // <cond>
        SYMBOL_DATA       = 36, // <data>
        SYMBOL_DIGIT2     = 37, // <digit>
        SYMBOL_EXP        = 38, // <exp>
        SYMBOL_EXPR       = 39, // <expr>
        SYMBOL_FACTOR     = 40, // <factor>
        SYMBOL_FOR_STMT   = 41, // <for_stmt>
        SYMBOL_ID2        = 42, // <id>
        SYMBOL_IF_STMT    = 43, // <if_stmt>
        SYMBOL_OP         = 44, // <op>
        SYMBOL_PROGRAM    = 45, // <program>
        SYMBOL_STEP2      = 46, // <step>
        SYMBOL_STMT_LIST  = 47, // <stmt_list>
        SYMBOL_TERM       = 48  // <term>
    };

    enum RuleConstants : int
    {
        RULE_PROGRAM_BEGIN_DONE                                     =  0, // <program> ::= Begin <stmt_list> Done
        RULE_STMT_LIST                                              =  1, // <stmt_list> ::= <concept>
        RULE_STMT_LIST2                                             =  2, // <stmt_list> ::= <concept> <stmt_list>
        RULE_CONCEPT                                                =  3, // <concept> ::= <assign>
        RULE_CONCEPT2                                               =  4, // <concept> ::= <if_stmt>
        RULE_CONCEPT3                                               =  5, // <concept> ::= <for_stmt>
        RULE_ASSIGN_EQ                                              =  6, // <assign> ::= <id> '=' <expr>
        RULE_ID_ID                                                  =  7, // <id> ::= Id
        RULE_EXPR_PLUS                                              =  8, // <expr> ::= <expr> '+' <term>
        RULE_EXPR_MINUS                                             =  9, // <expr> ::= <expr> '-' <term>
        RULE_EXPR                                                   = 10, // <expr> ::= <term>
        RULE_TERM_TIMES                                             = 11, // <term> ::= <term> '*' <factor>
        RULE_TERM_DIV                                               = 12, // <term> ::= <term> '/' <factor>
        RULE_TERM_PERCENT                                           = 13, // <term> ::= <term> '%' <factor>
        RULE_TERM                                                   = 14, // <term> ::= <factor>
        RULE_FACTOR_TIMESTIMES                                      = 15, // <factor> ::= <factor> '**' <exp>
        RULE_FACTOR                                                 = 16, // <factor> ::= <exp>
        RULE_EXP_LPAREN_RPAREN                                      = 17, // <exp> ::= '(' <expr> ')'
        RULE_EXP                                                    = 18, // <exp> ::= <id>
        RULE_EXP2                                                   = 19, // <exp> ::= <digit>
        RULE_DIGIT_DIGIT                                            = 20, // <digit> ::= Digit
        RULE_IF_STMT_CHECK_LPAREN_RPAREN_BEGIN_DONE                 = 21, // <if_stmt> ::= check '(' <cond> ')' Begin <stmt_list> Done
        RULE_IF_STMT_CHECK_LPAREN_RPAREN_BEGIN_DONE_ELSE_BEGIN_DONE = 22, // <if_stmt> ::= check '(' <cond> ')' Begin <stmt_list> Done else Begin <stmt_list> Done
        RULE_COND                                                   = 23, // <cond> ::= <expr> <op> <expr>
        RULE_OP_LT                                                  = 24, // <op> ::= '<'
        RULE_OP_GT                                                  = 25, // <op> ::= '>'
        RULE_OP_EQEQ                                                = 26, // <op> ::= '=='
        RULE_OP_EXCLAMEQ                                            = 27, // <op> ::= '!='
        RULE_FOR_STMT_LOOP_FROM_TO_STEP_DO_BEGIN_DONE               = 28, // <for_stmt> ::= loop <data> <id> from <expr> to <expr> step <step> do Begin <stmt_list> Done
        RULE_DATA_NUM                                               = 29, // <data> ::= num
        RULE_DATA_DEC                                               = 30, // <data> ::= dec
        RULE_DATA_TEXT                                              = 31, // <data> ::= text
        RULE_DATA_WORD                                              = 32, // <data> ::= word
        RULE_STEP_MINUSMINUS                                        = 33, // <step> ::= '--' <id>
        RULE_STEP_MINUSMINUS2                                       = 34, // <step> ::= <id> '--'
        RULE_STEP_PLUSPLUS                                          = 35, // <step> ::= '++' <id>
        RULE_STEP_PLUSPLUS2                                         = 36, // <step> ::= <id> '++'
        RULE_STEP                                                   = 37  // <step> ::= <assign>
    };

    public class MyParser
    {
        private LALRParser parser;
        ListBox lst;
        ListBox ls;

        public MyParser(string filename,ListBox lst, ListBox ls)
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
            parser.OnTokenRead += new LALRParser.TokenReadHandler(TokenReadEvent);
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

                case (int)SymbolConstants.SYMBOL_DIV :
                //'/'
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

                case (int)SymbolConstants.SYMBOL_BEGIN :
                //Begin
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_CHECK :
                //check
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_DEC :
                //dec
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_DIGIT :
                //Digit
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_DO :
                //do
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_DONE :
                //Done
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_ELSE :
                //else
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_FROM :
                //from
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_ID :
                //Id
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_LOOP :
                //loop
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_NUM :
                //num
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_STEP :
                //step
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_TEXT :
                //text
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_TO :
                //to
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_WORD :
                //word
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_ASSIGN :
                //<assign>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_CONCEPT :
                //<concept>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_COND :
                //<cond>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_DATA :
                //<data>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_DIGIT2 :
                //<digit>
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

                case (int)SymbolConstants.SYMBOL_FOR_STMT :
                //<for_stmt>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_ID2 :
                //<id>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_IF_STMT :
                //<if_stmt>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_OP :
                //<op>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_PROGRAM :
                //<program>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_STEP2 :
                //<step>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_STMT_LIST :
                //<stmt_list>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_TERM :
                //<term>
                //todo: Create a new object that corresponds to the symbol
                return null;

            }
            throw new SymbolException("Unknown symbol");
        }

        public Object CreateObjectFromNonterminal(NonterminalToken token)
        {
            switch (token.Rule.Id)
            {
                case (int)RuleConstants.RULE_PROGRAM_BEGIN_DONE :
                //<program> ::= Begin <stmt_list> Done
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_STMT_LIST :
                //<stmt_list> ::= <concept>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_STMT_LIST2 :
                //<stmt_list> ::= <concept> <stmt_list>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_CONCEPT :
                //<concept> ::= <assign>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_CONCEPT2 :
                //<concept> ::= <if_stmt>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_CONCEPT3 :
                //<concept> ::= <for_stmt>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_ASSIGN_EQ :
                //<assign> ::= <id> '=' <expr>
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

                case (int)RuleConstants.RULE_EXP2 :
                //<exp> ::= <digit>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_DIGIT_DIGIT :
                //<digit> ::= Digit
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_IF_STMT_CHECK_LPAREN_RPAREN_BEGIN_DONE :
                //<if_stmt> ::= check '(' <cond> ')' Begin <stmt_list> Done
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_IF_STMT_CHECK_LPAREN_RPAREN_BEGIN_DONE_ELSE_BEGIN_DONE :
                //<if_stmt> ::= check '(' <cond> ')' Begin <stmt_list> Done else Begin <stmt_list> Done
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_COND :
                //<cond> ::= <expr> <op> <expr>
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

                case (int)RuleConstants.RULE_FOR_STMT_LOOP_FROM_TO_STEP_DO_BEGIN_DONE :
                //<for_stmt> ::= loop <data> <id> from <expr> to <expr> step <step> do Begin <stmt_list> Done
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_DATA_NUM :
                //<data> ::= num
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_DATA_DEC :
                //<data> ::= dec
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_DATA_TEXT :
                //<data> ::= text
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_DATA_WORD :
                //<data> ::= word
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_STEP_MINUSMINUS :
                //<step> ::= '--' <id>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_STEP_MINUSMINUS2 :
                //<step> ::= <id> '--'
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_STEP_PLUSPLUS :
                //<step> ::= '++' <id>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_STEP_PLUSPLUS2 :
                //<step> ::= <id> '++'
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_STEP :
                //<step> ::= <assign>
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
            string message = "Parse error caused by token: '"+args.UnexpectedToken.ToString()+"In line: "+args.UnexpectedToken.Location.LineNr;
            lst.Items.Add(message);
            string m2 = "Expected tocked:  " + args.ExpectedTokens.ToString();
            lst.Items.Add(m2);
            //todo: Report message to UI?
        }
        
        private void TokenReadEvent(LALRParser parser, TokenReadEventArgs args)
        {
            string info = args.Token.Text + "    \t \t" + (SymbolConstants)args.Token.Symbol.Id;
            ls.Items.Add(info);
        }


    }
}
