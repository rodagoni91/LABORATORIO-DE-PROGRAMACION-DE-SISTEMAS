// $ANTLR 3.4 C:\\Users\\dany_\\Desktop\\antlr2020.g 2020-10-15 21:01:40

import org.antlr.runtime.*;
import java.util.Stack;
import java.util.List;
import java.util.ArrayList;

@SuppressWarnings({"all", "warnings", "unchecked"})
public class antlr2020Lexer extends Lexer {
    public static final int EOF=-1;
    public static final int T__15=15;
    public static final int T__16=16;
    public static final int T__17=17;
    public static final int DIR=4;
    public static final int DIRECCION=5;
    public static final int MAYUSCULAS=6;
    public static final int MINUSCULAS=7;
    public static final int NOMBRE=8;
    public static final int NUMERO=9;
    public static final int OPDIRECTIVA=10;
    public static final int OPERACION=11;
    public static final int REGISTRO=12;
    public static final int START=13;
    public static final int TIPODIRECTIVA=14;

    // delegates
    // delegators
    public Lexer[] getDelegates() {
        return new Lexer[] {};
    }

    public antlr2020Lexer() {} 
    public antlr2020Lexer(CharStream input) {
        this(input, new RecognizerSharedState());
    }
    public antlr2020Lexer(CharStream input, RecognizerSharedState state) {
        super(input,state);
    }
    public String getGrammarFileName() { return "C:\\Users\\dany_\\Desktop\\antlr2020.g"; }

    // $ANTLR start "T__15"
    public final void mT__15() throws RecognitionException {
        try {
            int _type = T__15;
            int _channel = DEFAULT_TOKEN_CHANNEL;
            // C:\\Users\\dany_\\Desktop\\antlr2020.g:2:7: ( ',X' )
            // C:\\Users\\dany_\\Desktop\\antlr2020.g:2:9: ',X'
            {
            match(",X"); 



            }

            state.type = _type;
            state.channel = _channel;
        }
        finally {
        	// do for sure before leaving
        }
    }
    // $ANTLR end "T__15"

    // $ANTLR start "T__16"
    public final void mT__16() throws RecognitionException {
        try {
            int _type = T__16;
            int _channel = DEFAULT_TOKEN_CHANNEL;
            // C:\\Users\\dany_\\Desktop\\antlr2020.g:3:7: ( 'END' )
            // C:\\Users\\dany_\\Desktop\\antlr2020.g:3:9: 'END'
            {
            match("END"); 



            }

            state.type = _type;
            state.channel = _channel;
        }
        finally {
        	// do for sure before leaving
        }
    }
    // $ANTLR end "T__16"

    // $ANTLR start "T__17"
    public final void mT__17() throws RecognitionException {
        try {
            int _type = T__17;
            int _channel = DEFAULT_TOKEN_CHANNEL;
            // C:\\Users\\dany_\\Desktop\\antlr2020.g:4:7: ( '\\n' )
            // C:\\Users\\dany_\\Desktop\\antlr2020.g:4:9: '\\n'
            {
            match('\n'); 

            }

            state.type = _type;
            state.channel = _channel;
        }
        finally {
        	// do for sure before leaving
        }
    }
    // $ANTLR end "T__17"

    // $ANTLR start "OPERACION"
    public final void mOPERACION() throws RecognitionException {
        try {
            int _type = OPERACION;
            int _channel = DEFAULT_TOKEN_CHANNEL;
            // C:\\Users\\dany_\\Desktop\\antlr2020.g:22:2: ( 'ADD' | 'AND' | 'COMP' | 'DIV' | 'J' | 'JEQ' | 'JGT' | 'JLT' | 'JSUB' | 'LDA' | 'LDCG' | 'LDL' | 'LDX' | 'MUL' | 'OR' | 'RD' | 'RSUB' | 'STA' | 'STCH' | 'STL' | 'STSW' | 'STX' | 'SUB' | 'TD' | 'TIX' | 'WD' )
            int alt1=26;
            switch ( input.LA(1) ) {
            case 'A':
                {
                int LA1_1 = input.LA(2);

                if ( (LA1_1=='D') ) {
                    alt1=1;
                }
                else if ( (LA1_1=='N') ) {
                    alt1=2;
                }
                else {
                    NoViableAltException nvae =
                        new NoViableAltException("", 1, 1, input);

                    throw nvae;

                }
                }
                break;
            case 'C':
                {
                alt1=3;
                }
                break;
            case 'D':
                {
                alt1=4;
                }
                break;
            case 'J':
                {
                switch ( input.LA(2) ) {
                case 'E':
                    {
                    alt1=6;
                    }
                    break;
                case 'G':
                    {
                    alt1=7;
                    }
                    break;
                case 'L':
                    {
                    alt1=8;
                    }
                    break;
                case 'S':
                    {
                    alt1=9;
                    }
                    break;
                default:
                    alt1=5;
                }

                }
                break;
            case 'L':
                {
                int LA1_5 = input.LA(2);

                if ( (LA1_5=='D') ) {
                    switch ( input.LA(3) ) {
                    case 'A':
                        {
                        alt1=10;
                        }
                        break;
                    case 'C':
                        {
                        alt1=11;
                        }
                        break;
                    case 'L':
                        {
                        alt1=12;
                        }
                        break;
                    case 'X':
                        {
                        alt1=13;
                        }
                        break;
                    default:
                        NoViableAltException nvae =
                            new NoViableAltException("", 1, 19, input);

                        throw nvae;

                    }

                }
                else {
                    NoViableAltException nvae =
                        new NoViableAltException("", 1, 5, input);

                    throw nvae;

                }
                }
                break;
            case 'M':
                {
                alt1=14;
                }
                break;
            case 'O':
                {
                alt1=15;
                }
                break;
            case 'R':
                {
                int LA1_8 = input.LA(2);

                if ( (LA1_8=='D') ) {
                    alt1=16;
                }
                else if ( (LA1_8=='S') ) {
                    alt1=17;
                }
                else {
                    NoViableAltException nvae =
                        new NoViableAltException("", 1, 8, input);

                    throw nvae;

                }
                }
                break;
            case 'S':
                {
                int LA1_9 = input.LA(2);

                if ( (LA1_9=='T') ) {
                    switch ( input.LA(3) ) {
                    case 'A':
                        {
                        alt1=18;
                        }
                        break;
                    case 'C':
                        {
                        alt1=19;
                        }
                        break;
                    case 'L':
                        {
                        alt1=20;
                        }
                        break;
                    case 'S':
                        {
                        alt1=21;
                        }
                        break;
                    case 'X':
                        {
                        alt1=22;
                        }
                        break;
                    default:
                        NoViableAltException nvae =
                            new NoViableAltException("", 1, 22, input);

                        throw nvae;

                    }

                }
                else if ( (LA1_9=='U') ) {
                    alt1=23;
                }
                else {
                    NoViableAltException nvae =
                        new NoViableAltException("", 1, 9, input);

                    throw nvae;

                }
                }
                break;
            case 'T':
                {
                int LA1_10 = input.LA(2);

                if ( (LA1_10=='D') ) {
                    alt1=24;
                }
                else if ( (LA1_10=='I') ) {
                    alt1=25;
                }
                else {
                    NoViableAltException nvae =
                        new NoViableAltException("", 1, 10, input);

                    throw nvae;

                }
                }
                break;
            case 'W':
                {
                alt1=26;
                }
                break;
            default:
                NoViableAltException nvae =
                    new NoViableAltException("", 1, 0, input);

                throw nvae;

            }

            switch (alt1) {
                case 1 :
                    // C:\\Users\\dany_\\Desktop\\antlr2020.g:22:4: 'ADD'
                    {
                    match("ADD"); 



                    }
                    break;
                case 2 :
                    // C:\\Users\\dany_\\Desktop\\antlr2020.g:22:12: 'AND'
                    {
                    match("AND"); 



                    }
                    break;
                case 3 :
                    // C:\\Users\\dany_\\Desktop\\antlr2020.g:22:20: 'COMP'
                    {
                    match("COMP"); 



                    }
                    break;
                case 4 :
                    // C:\\Users\\dany_\\Desktop\\antlr2020.g:22:29: 'DIV'
                    {
                    match("DIV"); 



                    }
                    break;
                case 5 :
                    // C:\\Users\\dany_\\Desktop\\antlr2020.g:22:37: 'J'
                    {
                    match('J'); 

                    }
                    break;
                case 6 :
                    // C:\\Users\\dany_\\Desktop\\antlr2020.g:22:43: 'JEQ'
                    {
                    match("JEQ"); 



                    }
                    break;
                case 7 :
                    // C:\\Users\\dany_\\Desktop\\antlr2020.g:22:51: 'JGT'
                    {
                    match("JGT"); 



                    }
                    break;
                case 8 :
                    // C:\\Users\\dany_\\Desktop\\antlr2020.g:22:59: 'JLT'
                    {
                    match("JLT"); 



                    }
                    break;
                case 9 :
                    // C:\\Users\\dany_\\Desktop\\antlr2020.g:22:67: 'JSUB'
                    {
                    match("JSUB"); 



                    }
                    break;
                case 10 :
                    // C:\\Users\\dany_\\Desktop\\antlr2020.g:22:76: 'LDA'
                    {
                    match("LDA"); 



                    }
                    break;
                case 11 :
                    // C:\\Users\\dany_\\Desktop\\antlr2020.g:22:84: 'LDCG'
                    {
                    match("LDCG"); 



                    }
                    break;
                case 12 :
                    // C:\\Users\\dany_\\Desktop\\antlr2020.g:22:93: 'LDL'
                    {
                    match("LDL"); 



                    }
                    break;
                case 13 :
                    // C:\\Users\\dany_\\Desktop\\antlr2020.g:22:101: 'LDX'
                    {
                    match("LDX"); 



                    }
                    break;
                case 14 :
                    // C:\\Users\\dany_\\Desktop\\antlr2020.g:22:109: 'MUL'
                    {
                    match("MUL"); 



                    }
                    break;
                case 15 :
                    // C:\\Users\\dany_\\Desktop\\antlr2020.g:22:117: 'OR'
                    {
                    match("OR"); 



                    }
                    break;
                case 16 :
                    // C:\\Users\\dany_\\Desktop\\antlr2020.g:22:124: 'RD'
                    {
                    match("RD"); 



                    }
                    break;
                case 17 :
                    // C:\\Users\\dany_\\Desktop\\antlr2020.g:22:131: 'RSUB'
                    {
                    match("RSUB"); 



                    }
                    break;
                case 18 :
                    // C:\\Users\\dany_\\Desktop\\antlr2020.g:22:140: 'STA'
                    {
                    match("STA"); 



                    }
                    break;
                case 19 :
                    // C:\\Users\\dany_\\Desktop\\antlr2020.g:22:148: 'STCH'
                    {
                    match("STCH"); 



                    }
                    break;
                case 20 :
                    // C:\\Users\\dany_\\Desktop\\antlr2020.g:22:157: 'STL'
                    {
                    match("STL"); 



                    }
                    break;
                case 21 :
                    // C:\\Users\\dany_\\Desktop\\antlr2020.g:22:165: 'STSW'
                    {
                    match("STSW"); 



                    }
                    break;
                case 22 :
                    // C:\\Users\\dany_\\Desktop\\antlr2020.g:22:174: 'STX'
                    {
                    match("STX"); 



                    }
                    break;
                case 23 :
                    // C:\\Users\\dany_\\Desktop\\antlr2020.g:22:182: 'SUB'
                    {
                    match("SUB"); 



                    }
                    break;
                case 24 :
                    // C:\\Users\\dany_\\Desktop\\antlr2020.g:22:190: 'TD'
                    {
                    match("TD"); 



                    }
                    break;
                case 25 :
                    // C:\\Users\\dany_\\Desktop\\antlr2020.g:22:197: 'TIX'
                    {
                    match("TIX"); 



                    }
                    break;
                case 26 :
                    // C:\\Users\\dany_\\Desktop\\antlr2020.g:22:205: 'WD'
                    {
                    match("WD"); 



                    }
                    break;

            }
            state.type = _type;
            state.channel = _channel;
        }
        finally {
        	// do for sure before leaving
        }
    }
    // $ANTLR end "OPERACION"

    // $ANTLR start "TIPODIRECTIVA"
    public final void mTIPODIRECTIVA() throws RecognitionException {
        try {
            int _type = TIPODIRECTIVA;
            int _channel = DEFAULT_TOKEN_CHANNEL;
            // C:\\Users\\dany_\\Desktop\\antlr2020.g:26:2: ( 'BYTE' | 'WORD' | 'RESB' | 'RESW' )
            int alt2=4;
            switch ( input.LA(1) ) {
            case 'B':
                {
                alt2=1;
                }
                break;
            case 'W':
                {
                alt2=2;
                }
                break;
            case 'R':
                {
                int LA2_3 = input.LA(2);

                if ( (LA2_3=='E') ) {
                    int LA2_4 = input.LA(3);

                    if ( (LA2_4=='S') ) {
                        int LA2_5 = input.LA(4);

                        if ( (LA2_5=='B') ) {
                            alt2=3;
                        }
                        else if ( (LA2_5=='W') ) {
                            alt2=4;
                        }
                        else {
                            NoViableAltException nvae =
                                new NoViableAltException("", 2, 5, input);

                            throw nvae;

                        }
                    }
                    else {
                        NoViableAltException nvae =
                            new NoViableAltException("", 2, 4, input);

                        throw nvae;

                    }
                }
                else {
                    NoViableAltException nvae =
                        new NoViableAltException("", 2, 3, input);

                    throw nvae;

                }
                }
                break;
            default:
                NoViableAltException nvae =
                    new NoViableAltException("", 2, 0, input);

                throw nvae;

            }

            switch (alt2) {
                case 1 :
                    // C:\\Users\\dany_\\Desktop\\antlr2020.g:26:4: 'BYTE'
                    {
                    match("BYTE"); 



                    }
                    break;
                case 2 :
                    // C:\\Users\\dany_\\Desktop\\antlr2020.g:26:13: 'WORD'
                    {
                    match("WORD"); 



                    }
                    break;
                case 3 :
                    // C:\\Users\\dany_\\Desktop\\antlr2020.g:26:22: 'RESB'
                    {
                    match("RESB"); 



                    }
                    break;
                case 4 :
                    // C:\\Users\\dany_\\Desktop\\antlr2020.g:26:31: 'RESW'
                    {
                    match("RESW"); 



                    }
                    break;

            }
            state.type = _type;
            state.channel = _channel;
        }
        finally {
        	// do for sure before leaving
        }
    }
    // $ANTLR end "TIPODIRECTIVA"

    // $ANTLR start "OPDIRECTIVA"
    public final void mOPDIRECTIVA() throws RecognitionException {
        try {
            int _type = OPDIRECTIVA;
            int _channel = DEFAULT_TOKEN_CHANNEL;
            // C:\\Users\\dany_\\Desktop\\antlr2020.g:30:2: ( NUMERO | REGISTRO ( NUMERO | NOMBRE ) )
            int alt4=2;
            switch ( input.LA(1) ) {
            case 'C':
                {
                switch ( input.LA(2) ) {
                case 'A':
                case 'B':
                case 'C':
                case 'D':
                case 'E':
                case 'F':
                case 'a':
                case 'b':
                case 'c':
                case 'd':
                case 'e':
                case 'f':
                    {
                    alt4=1;
                    }
                    break;
                case '0':
                case '1':
                case '2':
                case '3':
                case '4':
                case '5':
                case '6':
                case '7':
                case '8':
                case '9':
                    {
                    alt4=1;
                    }
                    break;
                case 'G':
                case 'H':
                case 'I':
                case 'J':
                case 'K':
                case 'L':
                case 'M':
                case 'N':
                case 'O':
                case 'P':
                case 'Q':
                case 'R':
                case 'S':
                case 'T':
                case 'U':
                case 'V':
                case 'W':
                case 'X':
                case 'Y':
                case 'Z':
                case '_':
                case 'g':
                case 'h':
                case 'i':
                case 'j':
                case 'k':
                case 'l':
                case 'm':
                case 'n':
                case 'o':
                case 'p':
                case 'q':
                case 'r':
                case 's':
                case 't':
                case 'u':
                case 'v':
                case 'w':
                case 'x':
                case 'y':
                case 'z':
                    {
                    alt4=2;
                    }
                    break;
                default:
                    alt4=1;
                }

                }
                break;
            case '0':
            case '1':
            case '2':
            case '3':
            case '4':
            case '5':
            case '6':
            case '7':
            case '8':
            case '9':
            case 'A':
            case 'B':
            case 'D':
            case 'E':
            case 'F':
            case 'a':
            case 'b':
            case 'c':
            case 'd':
            case 'e':
            case 'f':
                {
                alt4=1;
                }
                break;
            case 'H':
            case 'X':
                {
                alt4=2;
                }
                break;
            default:
                NoViableAltException nvae =
                    new NoViableAltException("", 4, 0, input);

                throw nvae;

            }

            switch (alt4) {
                case 1 :
                    // C:\\Users\\dany_\\Desktop\\antlr2020.g:30:4: NUMERO
                    {
                    mNUMERO(); 


                    }
                    break;
                case 2 :
                    // C:\\Users\\dany_\\Desktop\\antlr2020.g:30:12: REGISTRO ( NUMERO | NOMBRE )
                    {
                    mREGISTRO(); 


                    // C:\\Users\\dany_\\Desktop\\antlr2020.g:30:21: ( NUMERO | NOMBRE )
                    int alt3=2;
                    int LA3_0 = input.LA(1);

                    if ( ((LA3_0 >= '0' && LA3_0 <= '9')||(LA3_0 >= 'A' && LA3_0 <= 'F')||(LA3_0 >= 'a' && LA3_0 <= 'f')) ) {
                        alt3=1;
                    }
                    else if ( ((LA3_0 >= 'G' && LA3_0 <= 'Z')||LA3_0=='_'||(LA3_0 >= 'g' && LA3_0 <= 'z')) ) {
                        alt3=2;
                    }
                    else {
                        NoViableAltException nvae =
                            new NoViableAltException("", 3, 0, input);

                        throw nvae;

                    }
                    switch (alt3) {
                        case 1 :
                            // C:\\Users\\dany_\\Desktop\\antlr2020.g:30:22: NUMERO
                            {
                            mNUMERO(); 


                            }
                            break;
                        case 2 :
                            // C:\\Users\\dany_\\Desktop\\antlr2020.g:30:31: NOMBRE
                            {
                            mNOMBRE(); 


                            }
                            break;

                    }


                    }
                    break;

            }
            state.type = _type;
            state.channel = _channel;
        }
        finally {
        	// do for sure before leaving
        }
    }
    // $ANTLR end "OPDIRECTIVA"

    // $ANTLR start "REGISTRO"
    public final void mREGISTRO() throws RecognitionException {
        try {
            int _type = REGISTRO;
            int _channel = DEFAULT_TOKEN_CHANNEL;
            // C:\\Users\\dany_\\Desktop\\antlr2020.g:32:9: ( 'X' | 'C' | 'H' )
            // C:\\Users\\dany_\\Desktop\\antlr2020.g:
            {
            if ( input.LA(1)=='C'||input.LA(1)=='H'||input.LA(1)=='X' ) {
                input.consume();
            }
            else {
                MismatchedSetException mse = new MismatchedSetException(null,input);
                recover(mse);
                throw mse;
            }


            }

            state.type = _type;
            state.channel = _channel;
        }
        finally {
        	// do for sure before leaving
        }
    }
    // $ANTLR end "REGISTRO"

    // $ANTLR start "DIRECCION"
    public final void mDIRECCION() throws RecognitionException {
        try {
            int _type = DIRECCION;
            int _channel = DEFAULT_TOKEN_CHANNEL;
            // C:\\Users\\dany_\\Desktop\\antlr2020.g:35:2: ( 'DIRECCION' )
            // C:\\Users\\dany_\\Desktop\\antlr2020.g:35:4: 'DIRECCION'
            {
            match("DIRECCION"); 



            }

            state.type = _type;
            state.channel = _channel;
        }
        finally {
        	// do for sure before leaving
        }
    }
    // $ANTLR end "DIRECCION"

    // $ANTLR start "START"
    public final void mSTART() throws RecognitionException {
        try {
            int _type = START;
            int _channel = DEFAULT_TOKEN_CHANNEL;
            // C:\\Users\\dany_\\Desktop\\antlr2020.g:38:7: ( 'START' )
            // C:\\Users\\dany_\\Desktop\\antlr2020.g:38:9: 'START'
            {
            match("START"); 



            }

            state.type = _type;
            state.channel = _channel;
        }
        finally {
        	// do for sure before leaving
        }
    }
    // $ANTLR end "START"

    // $ANTLR start "DIR"
    public final void mDIR() throws RecognitionException {
        try {
            int _type = DIR;
            int _channel = DEFAULT_TOKEN_CHANNEL;
            // C:\\Users\\dany_\\Desktop\\antlr2020.g:41:5: ( NUMERO ( 'H' )? )
            // C:\\Users\\dany_\\Desktop\\antlr2020.g:41:7: NUMERO ( 'H' )?
            {
            mNUMERO(); 


            // C:\\Users\\dany_\\Desktop\\antlr2020.g:41:13: ( 'H' )?
            int alt5=2;
            int LA5_0 = input.LA(1);

            if ( (LA5_0=='H') ) {
                alt5=1;
            }
            switch (alt5) {
                case 1 :
                    // C:\\Users\\dany_\\Desktop\\antlr2020.g:41:13: 'H'
                    {
                    match('H'); 

                    }
                    break;

            }


            }

            state.type = _type;
            state.channel = _channel;
        }
        finally {
        	// do for sure before leaving
        }
    }
    // $ANTLR end "DIR"

    // $ANTLR start "MAYUSCULAS"
    public final void mMAYUSCULAS() throws RecognitionException {
        try {
            int _type = MAYUSCULAS;
            int _channel = DEFAULT_TOKEN_CHANNEL;
            // C:\\Users\\dany_\\Desktop\\antlr2020.g:44:2: ( 'A' .. 'Z' )
            // C:\\Users\\dany_\\Desktop\\antlr2020.g:
            {
            if ( (input.LA(1) >= 'A' && input.LA(1) <= 'Z') ) {
                input.consume();
            }
            else {
                MismatchedSetException mse = new MismatchedSetException(null,input);
                recover(mse);
                throw mse;
            }


            }

            state.type = _type;
            state.channel = _channel;
        }
        finally {
        	// do for sure before leaving
        }
    }
    // $ANTLR end "MAYUSCULAS"

    // $ANTLR start "MINUSCULAS"
    public final void mMINUSCULAS() throws RecognitionException {
        try {
            int _type = MINUSCULAS;
            int _channel = DEFAULT_TOKEN_CHANNEL;
            // C:\\Users\\dany_\\Desktop\\antlr2020.g:47:2: ( 'a' .. 'z' )
            // C:\\Users\\dany_\\Desktop\\antlr2020.g:
            {
            if ( (input.LA(1) >= 'a' && input.LA(1) <= 'z') ) {
                input.consume();
            }
            else {
                MismatchedSetException mse = new MismatchedSetException(null,input);
                recover(mse);
                throw mse;
            }


            }

            state.type = _type;
            state.channel = _channel;
        }
        finally {
        	// do for sure before leaving
        }
    }
    // $ANTLR end "MINUSCULAS"

    // $ANTLR start "NUMERO"
    public final void mNUMERO() throws RecognitionException {
        try {
            int _type = NUMERO;
            int _channel = DEFAULT_TOKEN_CHANNEL;
            // C:\\Users\\dany_\\Desktop\\antlr2020.g:49:8: ( ( '0' .. '9' | 'A' .. 'F' | 'a' .. 'f' )+ )
            // C:\\Users\\dany_\\Desktop\\antlr2020.g:49:10: ( '0' .. '9' | 'A' .. 'F' | 'a' .. 'f' )+
            {
            // C:\\Users\\dany_\\Desktop\\antlr2020.g:49:10: ( '0' .. '9' | 'A' .. 'F' | 'a' .. 'f' )+
            int cnt6=0;
            loop6:
            do {
                int alt6=2;
                int LA6_0 = input.LA(1);

                if ( ((LA6_0 >= '0' && LA6_0 <= '9')||(LA6_0 >= 'A' && LA6_0 <= 'F')||(LA6_0 >= 'a' && LA6_0 <= 'f')) ) {
                    alt6=1;
                }


                switch (alt6) {
            	case 1 :
            	    // C:\\Users\\dany_\\Desktop\\antlr2020.g:
            	    {
            	    if ( (input.LA(1) >= '0' && input.LA(1) <= '9')||(input.LA(1) >= 'A' && input.LA(1) <= 'F')||(input.LA(1) >= 'a' && input.LA(1) <= 'f') ) {
            	        input.consume();
            	    }
            	    else {
            	        MismatchedSetException mse = new MismatchedSetException(null,input);
            	        recover(mse);
            	        throw mse;
            	    }


            	    }
            	    break;

            	default :
            	    if ( cnt6 >= 1 ) break loop6;
                        EarlyExitException eee =
                            new EarlyExitException(6, input);
                        throw eee;
                }
                cnt6++;
            } while (true);


            }

            state.type = _type;
            state.channel = _channel;
        }
        finally {
        	// do for sure before leaving
        }
    }
    // $ANTLR end "NUMERO"

    // $ANTLR start "NOMBRE"
    public final void mNOMBRE() throws RecognitionException {
        try {
            int _type = NOMBRE;
            int _channel = DEFAULT_TOKEN_CHANNEL;
            // C:\\Users\\dany_\\Desktop\\antlr2020.g:51:8: ( ( MAYUSCULAS | MINUSCULAS | '_' ) ( MAYUSCULAS | MINUSCULAS | NUMERO | '_' )* )
            // C:\\Users\\dany_\\Desktop\\antlr2020.g:51:10: ( MAYUSCULAS | MINUSCULAS | '_' ) ( MAYUSCULAS | MINUSCULAS | NUMERO | '_' )*
            {
            if ( (input.LA(1) >= 'A' && input.LA(1) <= 'Z')||input.LA(1)=='_'||(input.LA(1) >= 'a' && input.LA(1) <= 'z') ) {
                input.consume();
            }
            else {
                MismatchedSetException mse = new MismatchedSetException(null,input);
                recover(mse);
                throw mse;
            }


            // C:\\Users\\dany_\\Desktop\\antlr2020.g:51:38: ( MAYUSCULAS | MINUSCULAS | NUMERO | '_' )*
            loop7:
            do {
                int alt7=5;
                switch ( input.LA(1) ) {
                case 'A':
                case 'B':
                case 'C':
                case 'D':
                case 'E':
                case 'F':
                case 'G':
                case 'H':
                case 'I':
                case 'J':
                case 'K':
                case 'L':
                case 'M':
                case 'N':
                case 'O':
                case 'P':
                case 'Q':
                case 'R':
                case 'S':
                case 'T':
                case 'U':
                case 'V':
                case 'W':
                case 'X':
                case 'Y':
                case 'Z':
                    {
                    alt7=1;
                    }
                    break;
                case 'a':
                case 'b':
                case 'c':
                case 'd':
                case 'e':
                case 'f':
                case 'g':
                case 'h':
                case 'i':
                case 'j':
                case 'k':
                case 'l':
                case 'm':
                case 'n':
                case 'o':
                case 'p':
                case 'q':
                case 'r':
                case 's':
                case 't':
                case 'u':
                case 'v':
                case 'w':
                case 'x':
                case 'y':
                case 'z':
                    {
                    alt7=2;
                    }
                    break;
                case '0':
                case '1':
                case '2':
                case '3':
                case '4':
                case '5':
                case '6':
                case '7':
                case '8':
                case '9':
                    {
                    alt7=3;
                    }
                    break;
                case '_':
                    {
                    alt7=4;
                    }
                    break;

                }

                switch (alt7) {
            	case 1 :
            	    // C:\\Users\\dany_\\Desktop\\antlr2020.g:51:39: MAYUSCULAS
            	    {
            	    mMAYUSCULAS(); 


            	    }
            	    break;
            	case 2 :
            	    // C:\\Users\\dany_\\Desktop\\antlr2020.g:51:50: MINUSCULAS
            	    {
            	    mMINUSCULAS(); 


            	    }
            	    break;
            	case 3 :
            	    // C:\\Users\\dany_\\Desktop\\antlr2020.g:51:61: NUMERO
            	    {
            	    mNUMERO(); 


            	    }
            	    break;
            	case 4 :
            	    // C:\\Users\\dany_\\Desktop\\antlr2020.g:51:68: '_'
            	    {
            	    match('_'); 

            	    }
            	    break;

            	default :
            	    break loop7;
                }
            } while (true);


            }

            state.type = _type;
            state.channel = _channel;
        }
        finally {
        	// do for sure before leaving
        }
    }
    // $ANTLR end "NOMBRE"

    public void mTokens() throws RecognitionException {
        // C:\\Users\\dany_\\Desktop\\antlr2020.g:1:8: ( T__15 | T__16 | T__17 | OPERACION | TIPODIRECTIVA | OPDIRECTIVA | REGISTRO | DIRECCION | START | DIR | MAYUSCULAS | MINUSCULAS | NUMERO | NOMBRE )
        int alt8=14;
        alt8 = dfa8.predict(input);
        switch (alt8) {
            case 1 :
                // C:\\Users\\dany_\\Desktop\\antlr2020.g:1:10: T__15
                {
                mT__15(); 


                }
                break;
            case 2 :
                // C:\\Users\\dany_\\Desktop\\antlr2020.g:1:16: T__16
                {
                mT__16(); 


                }
                break;
            case 3 :
                // C:\\Users\\dany_\\Desktop\\antlr2020.g:1:22: T__17
                {
                mT__17(); 


                }
                break;
            case 4 :
                // C:\\Users\\dany_\\Desktop\\antlr2020.g:1:28: OPERACION
                {
                mOPERACION(); 


                }
                break;
            case 5 :
                // C:\\Users\\dany_\\Desktop\\antlr2020.g:1:38: TIPODIRECTIVA
                {
                mTIPODIRECTIVA(); 


                }
                break;
            case 6 :
                // C:\\Users\\dany_\\Desktop\\antlr2020.g:1:52: OPDIRECTIVA
                {
                mOPDIRECTIVA(); 


                }
                break;
            case 7 :
                // C:\\Users\\dany_\\Desktop\\antlr2020.g:1:64: REGISTRO
                {
                mREGISTRO(); 


                }
                break;
            case 8 :
                // C:\\Users\\dany_\\Desktop\\antlr2020.g:1:73: DIRECCION
                {
                mDIRECCION(); 


                }
                break;
            case 9 :
                // C:\\Users\\dany_\\Desktop\\antlr2020.g:1:83: START
                {
                mSTART(); 


                }
                break;
            case 10 :
                // C:\\Users\\dany_\\Desktop\\antlr2020.g:1:89: DIR
                {
                mDIR(); 


                }
                break;
            case 11 :
                // C:\\Users\\dany_\\Desktop\\antlr2020.g:1:93: MAYUSCULAS
                {
                mMAYUSCULAS(); 


                }
                break;
            case 12 :
                // C:\\Users\\dany_\\Desktop\\antlr2020.g:1:104: MINUSCULAS
                {
                mMINUSCULAS(); 


                }
                break;
            case 13 :
                // C:\\Users\\dany_\\Desktop\\antlr2020.g:1:115: NUMERO
                {
                mNUMERO(); 


                }
                break;
            case 14 :
                // C:\\Users\\dany_\\Desktop\\antlr2020.g:1:122: NOMBRE
                {
                mNOMBRE(); 


                }
                break;

        }

    }


    protected DFA8 dfa8 = new DFA8(this);
    static final String DFA8_eotS =
        "\2\uffff\1\30\1\uffff\3\30\1\54\7\56\2\30\1\73\1\30\1\56\1\30\1"+
        "\100\1\uffff\1\26\1\uffff\1\30\1\77\3\30\1\26\10\30\5\26\1\uffff"+
        "\1\26\1\uffff\1\26\2\54\4\26\1\54\1\26\1\54\2\26\1\uffff\3\30\2"+
        "\uffff\1\154\2\54\15\30\1\54\1\26\3\54\1\26\1\54\1\26\3\54\2\26"+
        "\1\54\1\26\1\54\1\26\3\54\2\26\5\30\1\uffff\1\54\1\26\3\54\2\172"+
        "\1\26\2\54\2\172\1\26\1\uffff\1\175\1\26\1\uffff\2\26\1\u0081\1"+
        "\uffff";
    static final String DFA8_eofS =
        "\u0082\uffff";
    static final String DFA8_minS =
        "\1\12\1\uffff\1\60\1\uffff\22\60\1\uffff\1\104\1\uffff\5\60\1\104"+
        "\10\60\1\122\1\121\2\124\1\125\1\uffff\1\101\1\uffff\1\114\2\60"+
        "\1\125\1\123\1\101\1\102\1\60\1\130\1\60\1\122\1\124\1\uffff\3\60"+
        "\2\uffff\21\60\1\105\3\60\1\102\1\60\1\107\3\60\2\102\1\60\1\110"+
        "\1\60\1\127\3\60\1\104\1\105\5\60\1\uffff\1\60\1\103\5\60\1\124"+
        "\4\60\1\103\1\uffff\1\60\1\111\1\uffff\1\117\1\116\1\60\1\uffff";
    static final String DFA8_maxS =
        "\1\172\1\uffff\1\172\1\uffff\20\172\1\146\1\172\1\uffff\1\104\1"+
        "\uffff\5\172\1\104\10\172\1\126\1\121\2\124\1\125\1\uffff\1\130"+
        "\1\uffff\1\114\2\172\1\125\1\123\1\130\1\102\1\172\1\130\1\172\1"+
        "\122\1\124\1\uffff\3\172\2\uffff\21\172\1\105\3\172\1\102\1\172"+
        "\1\107\3\172\1\102\1\127\1\172\1\110\1\172\1\127\3\172\1\104\1\105"+
        "\5\172\1\uffff\1\172\1\103\5\172\1\124\4\172\1\103\1\uffff\1\172"+
        "\1\111\1\uffff\1\117\1\116\1\172\1\uffff";
    static final String DFA8_acceptS =
        "\1\uffff\1\1\1\uffff\1\3\22\uffff\1\16\1\uffff\1\6\23\uffff\1\4"+
        "\1\uffff\1\13\14\uffff\1\7\3\uffff\1\12\1\14\53\uffff\1\2\15\uffff"+
        "\1\5\2\uffff\1\11\3\uffff\1\10";
    static final String DFA8_specialS =
        "\u0082\uffff}>";
    static final String[] DFA8_transitionS = {
            "\1\3\41\uffff\1\1\3\uffff\12\24\7\uffff\1\4\1\17\1\5\1\6\1\2"+
            "\1\20\1\23\1\21\1\23\1\7\1\23\1\10\1\11\1\23\1\12\2\23\1\13"+
            "\1\14\1\15\2\23\1\16\1\21\2\23\4\uffff\1\26\1\uffff\6\22\24"+
            "\25",
            "",
            "\12\34\7\uffff\6\31\1\26\1\32\5\26\1\27\14\26\4\uffff\1\26"+
            "\1\uffff\6\33\24\26",
            "",
            "\12\34\7\uffff\3\31\1\35\2\31\1\26\1\32\5\26\1\36\14\26\4\uffff"+
            "\1\26\1\uffff\6\33\24\26",
            "\12\41\7\uffff\6\40\1\43\1\42\6\43\1\37\13\43\4\uffff\1\46"+
            "\1\uffff\6\44\24\45",
            "\12\34\7\uffff\6\31\1\26\1\32\1\47\21\26\4\uffff\1\26\1\uffff"+
            "\6\33\24\26",
            "\12\26\7\uffff\4\26\1\50\1\26\1\51\4\26\1\52\6\26\1\53\7\26"+
            "\4\uffff\1\26\1\uffff\32\26",
            "\12\26\7\uffff\3\26\1\55\26\26\4\uffff\1\26\1\uffff\32\26",
            "\12\26\7\uffff\24\26\1\57\5\26\4\uffff\1\26\1\uffff\32\26",
            "\12\26\7\uffff\21\26\1\60\10\26\4\uffff\1\26\1\uffff\32\26",
            "\12\26\7\uffff\3\26\1\61\1\63\15\26\1\62\7\26\4\uffff\1\26"+
            "\1\uffff\32\26",
            "\12\26\7\uffff\23\26\1\64\1\65\5\26\4\uffff\1\26\1\uffff\32"+
            "\26",
            "\12\26\7\uffff\3\26\1\66\4\26\1\67\21\26\4\uffff\1\26\1\uffff"+
            "\32\26",
            "\12\26\7\uffff\3\26\1\70\12\26\1\71\13\26\4\uffff\1\26\1\uffff"+
            "\32\26",
            "\12\34\7\uffff\6\31\1\26\1\32\20\26\1\72\1\26\4\uffff\1\26"+
            "\1\uffff\6\33\24\26",
            "\12\34\7\uffff\6\31\1\26\1\32\22\26\4\uffff\1\26\1\uffff\6"+
            "\33\24\26",
            "\12\75\7\uffff\6\74\24\43\4\uffff\1\46\1\uffff\6\76\24\45",
            "\12\34\7\uffff\6\31\1\26\1\32\22\26\4\uffff\1\26\1\uffff\6"+
            "\33\24\26",
            "\12\26\7\uffff\32\26\4\uffff\1\26\1\uffff\32\26",
            "\12\24\7\uffff\6\24\1\uffff\1\77\30\uffff\6\24",
            "\12\26\7\uffff\32\26\4\uffff\1\26\1\uffff\32\26",
            "",
            "\1\101",
            "",
            "\12\34\7\uffff\6\31\1\26\1\32\22\26\4\uffff\1\26\1\uffff\6"+
            "\33\24\26",
            "\12\26\7\uffff\32\26\4\uffff\1\26\1\uffff\32\26",
            "\12\34\7\uffff\6\31\1\26\1\32\22\26\4\uffff\1\26\1\uffff\6"+
            "\33\24\26",
            "\12\34\7\uffff\6\31\1\26\1\32\22\26\4\uffff\1\26\1\uffff\6"+
            "\33\24\26",
            "\12\34\7\uffff\3\31\1\102\2\31\1\26\1\32\22\26\4\uffff\1\26"+
            "\1\uffff\6\33\24\26",
            "\1\103",
            "\12\111\7\uffff\6\105\6\107\1\104\15\107\4\uffff\1\112\1\uffff"+
            "\6\106\24\110",
            "\12\116\7\uffff\6\113\1\107\1\115\22\107\4\uffff\1\112\1\uffff"+
            "\6\114\24\110",
            "\12\41\7\uffff\6\117\1\26\1\32\22\26\4\uffff\1\26\1\uffff\6"+
            "\120\24\26",
            "\12\111\7\uffff\6\105\24\107\4\uffff\1\112\1\uffff\6\106\24"+
            "\110",
            "\12\111\7\uffff\6\105\24\107\4\uffff\1\112\1\uffff\6\106\24"+
            "\110",
            "\12\116\7\uffff\6\113\1\107\1\115\22\107\4\uffff\1\112\1\uffff"+
            "\6\114\24\110",
            "\12\111\7\uffff\6\105\24\107\4\uffff\1\112\1\uffff\6\106\24"+
            "\110",
            "\12\111\7\uffff\6\105\24\107\4\uffff\1\112\1\uffff\6\106\24"+
            "\110",
            "\1\122\3\uffff\1\121",
            "\1\123",
            "\1\124",
            "\1\125",
            "\1\126",
            "",
            "\1\127\1\uffff\1\130\10\uffff\1\131\13\uffff\1\132",
            "",
            "\1\133",
            "\12\26\7\uffff\32\26\4\uffff\1\26\1\uffff\32\26",
            "\12\26\7\uffff\32\26\4\uffff\1\26\1\uffff\32\26",
            "\1\134",
            "\1\135",
            "\1\136\1\uffff\1\137\10\uffff\1\140\6\uffff\1\141\4\uffff\1"+
            "\142",
            "\1\143",
            "\12\26\7\uffff\32\26\4\uffff\1\26\1\uffff\32\26",
            "\1\144",
            "\12\26\7\uffff\32\26\4\uffff\1\26\1\uffff\32\26",
            "\1\145",
            "\1\146",
            "",
            "\12\151\7\uffff\6\147\24\107\4\uffff\1\112\1\uffff\6\150\24"+
            "\110",
            "\12\75\7\uffff\6\152\24\26\4\uffff\1\26\1\uffff\6\153\24\26",
            "\12\151\7\uffff\6\147\24\107\4\uffff\1\112\1\uffff\6\150\24"+
            "\110",
            "",
            "",
            "\12\26\7\uffff\32\26\4\uffff\1\26\1\uffff\32\26",
            "\12\34\7\uffff\6\31\1\26\1\32\22\26\4\uffff\1\26\1\uffff\6"+
            "\33\24\26",
            "\12\26\7\uffff\32\26\4\uffff\1\26\1\uffff\32\26",
            "\12\111\7\uffff\6\105\11\107\1\155\12\107\4\uffff\1\112\1\uffff"+
            "\6\106\24\110",
            "\12\111\7\uffff\6\105\24\107\4\uffff\1\112\1\uffff\6\106\24"+
            "\110",
            "\12\111\7\uffff\6\105\24\107\4\uffff\1\112\1\uffff\6\106\24"+
            "\110",
            "\12\111\7\uffff\6\105\24\107\4\uffff\1\112\1\uffff\6\106\24"+
            "\110",
            "\12\111\7\uffff\6\105\24\107\4\uffff\1\112\1\uffff\6\106\24"+
            "\110",
            "\12\111\7\uffff\6\105\24\107\4\uffff\1\112\1\uffff\6\106\24"+
            "\110",
            "\12\111\7\uffff\6\105\24\107\4\uffff\1\112\1\uffff\6\106\24"+
            "\110",
            "\12\116\7\uffff\6\113\1\107\1\115\22\107\4\uffff\1\112\1\uffff"+
            "\6\114\24\110",
            "\12\116\7\uffff\6\113\1\107\1\115\22\107\4\uffff\1\112\1\uffff"+
            "\6\114\24\110",
            "\12\111\7\uffff\6\105\24\107\4\uffff\1\112\1\uffff\6\106\24"+
            "\110",
            "\12\116\7\uffff\6\113\1\107\1\115\22\107\4\uffff\1\112\1\uffff"+
            "\6\114\24\110",
            "\12\41\7\uffff\6\117\1\26\1\32\22\26\4\uffff\1\26\1\uffff\6"+
            "\120\24\26",
            "\12\41\7\uffff\6\117\1\26\1\32\22\26\4\uffff\1\26\1\uffff\6"+
            "\120\24\26",
            "\12\26\7\uffff\32\26\4\uffff\1\26\1\uffff\32\26",
            "\1\156",
            "\12\26\7\uffff\32\26\4\uffff\1\26\1\uffff\32\26",
            "\12\26\7\uffff\32\26\4\uffff\1\26\1\uffff\32\26",
            "\12\26\7\uffff\32\26\4\uffff\1\26\1\uffff\32\26",
            "\1\157",
            "\12\26\7\uffff\32\26\4\uffff\1\26\1\uffff\32\26",
            "\1\160",
            "\12\26\7\uffff\32\26\4\uffff\1\26\1\uffff\32\26",
            "\12\26\7\uffff\32\26\4\uffff\1\26\1\uffff\32\26",
            "\12\26\7\uffff\32\26\4\uffff\1\26\1\uffff\32\26",
            "\1\161",
            "\1\162\24\uffff\1\163",
            "\12\26\7\uffff\21\26\1\164\10\26\4\uffff\1\26\1\uffff\32\26",
            "\1\165",
            "\12\26\7\uffff\32\26\4\uffff\1\26\1\uffff\32\26",
            "\1\166",
            "\12\26\7\uffff\32\26\4\uffff\1\26\1\uffff\32\26",
            "\12\26\7\uffff\32\26\4\uffff\1\26\1\uffff\32\26",
            "\12\26\7\uffff\32\26\4\uffff\1\26\1\uffff\32\26",
            "\1\167",
            "\1\170",
            "\12\151\7\uffff\6\147\24\107\4\uffff\1\112\1\uffff\6\150\24"+
            "\110",
            "\12\151\7\uffff\6\147\24\107\4\uffff\1\112\1\uffff\6\150\24"+
            "\110",
            "\12\151\7\uffff\6\147\24\107\4\uffff\1\112\1\uffff\6\150\24"+
            "\110",
            "\12\75\7\uffff\6\152\24\26\4\uffff\1\26\1\uffff\6\153\24\26",
            "\12\75\7\uffff\6\152\24\26\4\uffff\1\26\1\uffff\6\153\24\26",
            "",
            "\12\111\7\uffff\6\105\24\107\4\uffff\1\112\1\uffff\6\106\24"+
            "\110",
            "\1\171",
            "\12\26\7\uffff\32\26\4\uffff\1\26\1\uffff\32\26",
            "\12\26\7\uffff\32\26\4\uffff\1\26\1\uffff\32\26",
            "\12\26\7\uffff\32\26\4\uffff\1\26\1\uffff\32\26",
            "\12\26\7\uffff\32\26\4\uffff\1\26\1\uffff\32\26",
            "\12\26\7\uffff\32\26\4\uffff\1\26\1\uffff\32\26",
            "\1\173",
            "\12\26\7\uffff\32\26\4\uffff\1\26\1\uffff\32\26",
            "\12\26\7\uffff\32\26\4\uffff\1\26\1\uffff\32\26",
            "\12\26\7\uffff\32\26\4\uffff\1\26\1\uffff\32\26",
            "\12\26\7\uffff\32\26\4\uffff\1\26\1\uffff\32\26",
            "\1\174",
            "",
            "\12\26\7\uffff\32\26\4\uffff\1\26\1\uffff\32\26",
            "\1\176",
            "",
            "\1\177",
            "\1\u0080",
            "\12\26\7\uffff\32\26\4\uffff\1\26\1\uffff\32\26",
            ""
    };

    static final short[] DFA8_eot = DFA.unpackEncodedString(DFA8_eotS);
    static final short[] DFA8_eof = DFA.unpackEncodedString(DFA8_eofS);
    static final char[] DFA8_min = DFA.unpackEncodedStringToUnsignedChars(DFA8_minS);
    static final char[] DFA8_max = DFA.unpackEncodedStringToUnsignedChars(DFA8_maxS);
    static final short[] DFA8_accept = DFA.unpackEncodedString(DFA8_acceptS);
    static final short[] DFA8_special = DFA.unpackEncodedString(DFA8_specialS);
    static final short[][] DFA8_transition;

    static {
        int numStates = DFA8_transitionS.length;
        DFA8_transition = new short[numStates][];
        for (int i=0; i<numStates; i++) {
            DFA8_transition[i] = DFA.unpackEncodedString(DFA8_transitionS[i]);
        }
    }

    class DFA8 extends DFA {

        public DFA8(BaseRecognizer recognizer) {
            this.recognizer = recognizer;
            this.decisionNumber = 8;
            this.eot = DFA8_eot;
            this.eof = DFA8_eof;
            this.min = DFA8_min;
            this.max = DFA8_max;
            this.accept = DFA8_accept;
            this.special = DFA8_special;
            this.transition = DFA8_transition;
        }
        public String getDescription() {
            return "1:1: Tokens : ( T__15 | T__16 | T__17 | OPERACION | TIPODIRECTIVA | OPDIRECTIVA | REGISTRO | DIRECCION | START | DIR | MAYUSCULAS | MINUSCULAS | NUMERO | NOMBRE );";
        }
    }
 

}