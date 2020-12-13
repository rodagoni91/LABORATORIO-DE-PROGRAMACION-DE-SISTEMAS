// $ANTLR 3.4 C:\\Users\\dany_\\Desktop\\final.g 2020-10-16 09:05:05

import org.antlr.runtime.*;
import java.util.Stack;
import java.util.List;
import java.util.ArrayList;

@SuppressWarnings({"all", "warnings", "unchecked"})
public class finalLexer extends Lexer {
    public static final int EOF=-1;
    public static final int T__9=9;
    public static final int T__10=10;
    public static final int T__11=11;
    public static final int T__12=12;
    public static final int T__13=13;
    public static final int ETIQUETA=4;
    public static final int NUMERO=5;
    public static final int OPDIRECTIVA=6;
    public static final int OPERACION=7;
    public static final int TIPODIRECTIVA=8;

    // delegates
    // delegators
    public Lexer[] getDelegates() {
        return new Lexer[] {};
    }

    public finalLexer() {} 
    public finalLexer(CharStream input) {
        this(input, new RecognizerSharedState());
    }
    public finalLexer(CharStream input, RecognizerSharedState state) {
        super(input,state);
    }
    public String getGrammarFileName() { return "C:\\Users\\dany_\\Desktop\\final.g"; }

    // $ANTLR start "T__9"
    public final void mT__9() throws RecognitionException {
        try {
            int _type = T__9;
            int _channel = DEFAULT_TOKEN_CHANNEL;
            // C:\\Users\\dany_\\Desktop\\final.g:2:6: ( ',X' )
            // C:\\Users\\dany_\\Desktop\\final.g:2:8: ',X'
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
    // $ANTLR end "T__9"

    // $ANTLR start "T__10"
    public final void mT__10() throws RecognitionException {
        try {
            int _type = T__10;
            int _channel = DEFAULT_TOKEN_CHANNEL;
            // C:\\Users\\dany_\\Desktop\\final.g:3:7: ( 'END' )
            // C:\\Users\\dany_\\Desktop\\final.g:3:9: 'END'
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
    // $ANTLR end "T__10"

    // $ANTLR start "T__11"
    public final void mT__11() throws RecognitionException {
        try {
            int _type = T__11;
            int _channel = DEFAULT_TOKEN_CHANNEL;
            // C:\\Users\\dany_\\Desktop\\final.g:4:7: ( 'H' )
            // C:\\Users\\dany_\\Desktop\\final.g:4:9: 'H'
            {
            match('H'); 

            }

            state.type = _type;
            state.channel = _channel;
        }
        finally {
        	// do for sure before leaving
        }
    }
    // $ANTLR end "T__11"

    // $ANTLR start "T__12"
    public final void mT__12() throws RecognitionException {
        try {
            int _type = T__12;
            int _channel = DEFAULT_TOKEN_CHANNEL;
            // C:\\Users\\dany_\\Desktop\\final.g:5:7: ( 'START' )
            // C:\\Users\\dany_\\Desktop\\final.g:5:9: 'START'
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
    // $ANTLR end "T__12"

    // $ANTLR start "T__13"
    public final void mT__13() throws RecognitionException {
        try {
            int _type = T__13;
            int _channel = DEFAULT_TOKEN_CHANNEL;
            // C:\\Users\\dany_\\Desktop\\final.g:6:7: ( '\\n' )
            // C:\\Users\\dany_\\Desktop\\final.g:6:9: '\\n'
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
    // $ANTLR end "T__13"

    // $ANTLR start "OPERACION"
    public final void mOPERACION() throws RecognitionException {
        try {
            int _type = OPERACION;
            int _channel = DEFAULT_TOKEN_CHANNEL;
            // C:\\Users\\dany_\\Desktop\\final.g:23:2: ( 'ADD' | 'AND' | 'COMP' | 'DIV' | 'J' | 'JEQ' | 'JGT' | 'JLT' | 'JSUB' | 'LDA' | 'LDCG' | 'LDL' | 'LDX' | 'MUL' | 'OR' | 'RD' | 'RSUB' | 'STA' | 'STCH' | 'STL' | 'STSW' | 'STX' | 'SUB' | 'TD' | 'TIX' | 'WD' )
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
                    // C:\\Users\\dany_\\Desktop\\final.g:23:4: 'ADD'
                    {
                    match("ADD"); 



                    }
                    break;
                case 2 :
                    // C:\\Users\\dany_\\Desktop\\final.g:23:12: 'AND'
                    {
                    match("AND"); 



                    }
                    break;
                case 3 :
                    // C:\\Users\\dany_\\Desktop\\final.g:23:20: 'COMP'
                    {
                    match("COMP"); 



                    }
                    break;
                case 4 :
                    // C:\\Users\\dany_\\Desktop\\final.g:23:29: 'DIV'
                    {
                    match("DIV"); 



                    }
                    break;
                case 5 :
                    // C:\\Users\\dany_\\Desktop\\final.g:23:37: 'J'
                    {
                    match('J'); 

                    }
                    break;
                case 6 :
                    // C:\\Users\\dany_\\Desktop\\final.g:23:43: 'JEQ'
                    {
                    match("JEQ"); 



                    }
                    break;
                case 7 :
                    // C:\\Users\\dany_\\Desktop\\final.g:23:51: 'JGT'
                    {
                    match("JGT"); 



                    }
                    break;
                case 8 :
                    // C:\\Users\\dany_\\Desktop\\final.g:23:59: 'JLT'
                    {
                    match("JLT"); 



                    }
                    break;
                case 9 :
                    // C:\\Users\\dany_\\Desktop\\final.g:23:67: 'JSUB'
                    {
                    match("JSUB"); 



                    }
                    break;
                case 10 :
                    // C:\\Users\\dany_\\Desktop\\final.g:23:76: 'LDA'
                    {
                    match("LDA"); 



                    }
                    break;
                case 11 :
                    // C:\\Users\\dany_\\Desktop\\final.g:23:84: 'LDCG'
                    {
                    match("LDCG"); 



                    }
                    break;
                case 12 :
                    // C:\\Users\\dany_\\Desktop\\final.g:23:93: 'LDL'
                    {
                    match("LDL"); 



                    }
                    break;
                case 13 :
                    // C:\\Users\\dany_\\Desktop\\final.g:23:101: 'LDX'
                    {
                    match("LDX"); 



                    }
                    break;
                case 14 :
                    // C:\\Users\\dany_\\Desktop\\final.g:23:109: 'MUL'
                    {
                    match("MUL"); 



                    }
                    break;
                case 15 :
                    // C:\\Users\\dany_\\Desktop\\final.g:23:117: 'OR'
                    {
                    match("OR"); 



                    }
                    break;
                case 16 :
                    // C:\\Users\\dany_\\Desktop\\final.g:23:124: 'RD'
                    {
                    match("RD"); 



                    }
                    break;
                case 17 :
                    // C:\\Users\\dany_\\Desktop\\final.g:23:131: 'RSUB'
                    {
                    match("RSUB"); 



                    }
                    break;
                case 18 :
                    // C:\\Users\\dany_\\Desktop\\final.g:23:140: 'STA'
                    {
                    match("STA"); 



                    }
                    break;
                case 19 :
                    // C:\\Users\\dany_\\Desktop\\final.g:23:148: 'STCH'
                    {
                    match("STCH"); 



                    }
                    break;
                case 20 :
                    // C:\\Users\\dany_\\Desktop\\final.g:23:157: 'STL'
                    {
                    match("STL"); 



                    }
                    break;
                case 21 :
                    // C:\\Users\\dany_\\Desktop\\final.g:23:165: 'STSW'
                    {
                    match("STSW"); 



                    }
                    break;
                case 22 :
                    // C:\\Users\\dany_\\Desktop\\final.g:23:174: 'STX'
                    {
                    match("STX"); 



                    }
                    break;
                case 23 :
                    // C:\\Users\\dany_\\Desktop\\final.g:23:182: 'SUB'
                    {
                    match("SUB"); 



                    }
                    break;
                case 24 :
                    // C:\\Users\\dany_\\Desktop\\final.g:23:190: 'TD'
                    {
                    match("TD"); 



                    }
                    break;
                case 25 :
                    // C:\\Users\\dany_\\Desktop\\final.g:23:197: 'TIX'
                    {
                    match("TIX"); 



                    }
                    break;
                case 26 :
                    // C:\\Users\\dany_\\Desktop\\final.g:23:205: 'WD'
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

    // $ANTLR start "OPDIRECTIVA"
    public final void mOPDIRECTIVA() throws RecognitionException {
        try {
            int _type = OPDIRECTIVA;
            int _channel = DEFAULT_TOKEN_CHANNEL;
            // C:\\Users\\dany_\\Desktop\\final.g:28:2: ( 'SOS' )
            // C:\\Users\\dany_\\Desktop\\final.g:28:4: 'SOS'
            {
            match("SOS"); 



            }

            state.type = _type;
            state.channel = _channel;
        }
        finally {
        	// do for sure before leaving
        }
    }
    // $ANTLR end "OPDIRECTIVA"

    // $ANTLR start "TIPODIRECTIVA"
    public final void mTIPODIRECTIVA() throws RecognitionException {
        try {
            int _type = TIPODIRECTIVA;
            int _channel = DEFAULT_TOKEN_CHANNEL;
            // C:\\Users\\dany_\\Desktop\\final.g:32:2: ( 'BYTE' | 'WORD' | 'RESB' | 'RESW' )
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
                    // C:\\Users\\dany_\\Desktop\\final.g:32:4: 'BYTE'
                    {
                    match("BYTE"); 



                    }
                    break;
                case 2 :
                    // C:\\Users\\dany_\\Desktop\\final.g:32:13: 'WORD'
                    {
                    match("WORD"); 



                    }
                    break;
                case 3 :
                    // C:\\Users\\dany_\\Desktop\\final.g:32:22: 'RESB'
                    {
                    match("RESB"); 



                    }
                    break;
                case 4 :
                    // C:\\Users\\dany_\\Desktop\\final.g:32:31: 'RESW'
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

    // $ANTLR start "ETIQUETA"
    public final void mETIQUETA() throws RecognitionException {
        try {
            int _type = ETIQUETA;
            int _channel = DEFAULT_TOKEN_CHANNEL;
            // C:\\Users\\dany_\\Desktop\\final.g:35:9: ( ( 'a' .. 'z' | 'A' .. 'Z' | '_' ) ( 'a' .. 'z' | 'A' .. 'Z' | '0' .. '9' | '_' )* )
            // C:\\Users\\dany_\\Desktop\\final.g:35:11: ( 'a' .. 'z' | 'A' .. 'Z' | '_' ) ( 'a' .. 'z' | 'A' .. 'Z' | '0' .. '9' | '_' )*
            {
            if ( (input.LA(1) >= 'A' && input.LA(1) <= 'Z')||input.LA(1)=='_'||(input.LA(1) >= 'a' && input.LA(1) <= 'z') ) {
                input.consume();
            }
            else {
                MismatchedSetException mse = new MismatchedSetException(null,input);
                recover(mse);
                throw mse;
            }


            // C:\\Users\\dany_\\Desktop\\final.g:35:35: ( 'a' .. 'z' | 'A' .. 'Z' | '0' .. '9' | '_' )*
            loop3:
            do {
                int alt3=2;
                int LA3_0 = input.LA(1);

                if ( ((LA3_0 >= '0' && LA3_0 <= '9')||(LA3_0 >= 'A' && LA3_0 <= 'Z')||LA3_0=='_'||(LA3_0 >= 'a' && LA3_0 <= 'z')) ) {
                    alt3=1;
                }


                switch (alt3) {
            	case 1 :
            	    // C:\\Users\\dany_\\Desktop\\final.g:
            	    {
            	    if ( (input.LA(1) >= '0' && input.LA(1) <= '9')||(input.LA(1) >= 'A' && input.LA(1) <= 'Z')||input.LA(1)=='_'||(input.LA(1) >= 'a' && input.LA(1) <= 'z') ) {
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
            	    break loop3;
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
    // $ANTLR end "ETIQUETA"

    // $ANTLR start "NUMERO"
    public final void mNUMERO() throws RecognitionException {
        try {
            int _type = NUMERO;
            int _channel = DEFAULT_TOKEN_CHANNEL;
            // C:\\Users\\dany_\\Desktop\\final.g:38:8: ( ( 'A' .. 'F' | '0' .. '9' | 'a' .. 'f' )+ )
            // C:\\Users\\dany_\\Desktop\\final.g:38:10: ( 'A' .. 'F' | '0' .. '9' | 'a' .. 'f' )+
            {
            // C:\\Users\\dany_\\Desktop\\final.g:38:10: ( 'A' .. 'F' | '0' .. '9' | 'a' .. 'f' )+
            int cnt4=0;
            loop4:
            do {
                int alt4=2;
                int LA4_0 = input.LA(1);

                if ( ((LA4_0 >= '0' && LA4_0 <= '9')||(LA4_0 >= 'A' && LA4_0 <= 'F')||(LA4_0 >= 'a' && LA4_0 <= 'f')) ) {
                    alt4=1;
                }


                switch (alt4) {
            	case 1 :
            	    // C:\\Users\\dany_\\Desktop\\final.g:
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
            	    if ( cnt4 >= 1 ) break loop4;
                        EarlyExitException eee =
                            new EarlyExitException(4, input);
                        throw eee;
                }
                cnt4++;
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

    public void mTokens() throws RecognitionException {
        // C:\\Users\\dany_\\Desktop\\final.g:1:8: ( T__9 | T__10 | T__11 | T__12 | T__13 | OPERACION | OPDIRECTIVA | TIPODIRECTIVA | ETIQUETA | NUMERO )
        int alt5=10;
        alt5 = dfa5.predict(input);
        switch (alt5) {
            case 1 :
                // C:\\Users\\dany_\\Desktop\\final.g:1:10: T__9
                {
                mT__9(); 


                }
                break;
            case 2 :
                // C:\\Users\\dany_\\Desktop\\final.g:1:15: T__10
                {
                mT__10(); 


                }
                break;
            case 3 :
                // C:\\Users\\dany_\\Desktop\\final.g:1:21: T__11
                {
                mT__11(); 


                }
                break;
            case 4 :
                // C:\\Users\\dany_\\Desktop\\final.g:1:27: T__12
                {
                mT__12(); 


                }
                break;
            case 5 :
                // C:\\Users\\dany_\\Desktop\\final.g:1:33: T__13
                {
                mT__13(); 


                }
                break;
            case 6 :
                // C:\\Users\\dany_\\Desktop\\final.g:1:39: OPERACION
                {
                mOPERACION(); 


                }
                break;
            case 7 :
                // C:\\Users\\dany_\\Desktop\\final.g:1:49: OPDIRECTIVA
                {
                mOPDIRECTIVA(); 


                }
                break;
            case 8 :
                // C:\\Users\\dany_\\Desktop\\final.g:1:61: TIPODIRECTIVA
                {
                mTIPODIRECTIVA(); 


                }
                break;
            case 9 :
                // C:\\Users\\dany_\\Desktop\\final.g:1:75: ETIQUETA
                {
                mETIQUETA(); 


                }
                break;
            case 10 :
                // C:\\Users\\dany_\\Desktop\\final.g:1:84: NUMERO
                {
                mNUMERO(); 


                }
                break;

        }

    }


    protected DFA5 dfa5 = new DFA5(this);
    static final String DFA5_eotS =
        "\2\uffff\1\22\1\26\1\22\1\uffff\3\22\1\42\10\22\2\uffff\2\22\1\uffff"+
        "\13\22\1\uffff\2\22\2\42\2\22\1\42\1\22\1\42\2\22\1\110\1\42\1\22"+
        "\1\42\1\22\2\42\1\114\2\42\1\22\4\42\1\22\1\42\1\22\3\42\2\22\1"+
        "\42\2\22\1\uffff\1\22\2\42\1\uffff\4\42\4\126\1\127\2\uffff";
    static final String DFA5_eofS =
        "\130\uffff";
    static final String DFA5_minS =
        "\1\12\1\uffff\2\60\1\117\1\uffff\4\60\1\104\1\125\1\122\3\104\2"+
        "\60\2\uffff\1\104\1\60\1\uffff\1\101\1\102\1\123\1\60\1\104\1\115"+
        "\1\126\1\121\2\124\1\125\1\uffff\1\101\1\114\2\60\1\125\1\123\1"+
        "\60\1\130\1\60\1\122\1\124\2\60\1\110\1\60\1\127\5\60\1\120\4\60"+
        "\1\102\1\60\1\107\3\60\2\102\1\60\1\104\1\105\1\uffff\1\124\2\60"+
        "\1\uffff\11\60\2\uffff";
    static final String DFA5_maxS =
        "\1\172\1\uffff\1\146\1\172\1\125\1\uffff\3\146\1\172\1\104\1\125"+
        "\1\122\1\123\1\111\1\117\2\146\2\uffff\1\104\1\146\1\uffff\1\130"+
        "\1\102\1\123\1\146\1\104\1\115\1\126\1\121\2\124\1\125\1\uffff\1"+
        "\130\1\114\2\172\1\125\1\123\1\172\1\130\1\172\1\122\1\124\2\172"+
        "\1\110\1\172\1\127\5\172\1\120\4\172\1\102\1\172\1\107\3\172\1\102"+
        "\1\127\1\172\1\104\1\105\1\uffff\1\124\2\172\1\uffff\11\172\2\uffff";
    static final String DFA5_acceptS =
        "\1\uffff\1\1\3\uffff\1\5\14\uffff\1\11\1\12\2\uffff\1\3\13\uffff"+
        "\1\6\45\uffff\1\2\3\uffff\1\7\11\uffff\1\10\1\4";
    static final String DFA5_specialS =
        "\130\uffff}>";
    static final String[] DFA5_transitionS = {
            "\1\5\41\uffff\1\1\3\uffff\12\23\7\uffff\1\6\1\20\1\7\1\10\1"+
            "\2\1\21\1\22\1\3\1\22\1\11\1\22\1\12\1\13\1\22\1\14\2\22\1\15"+
            "\1\4\1\16\2\22\1\17\3\22\4\uffff\1\22\1\uffff\6\21\24\22",
            "",
            "\12\25\7\uffff\6\25\7\uffff\1\24\22\uffff\6\25",
            "\12\22\7\uffff\32\22\4\uffff\1\22\1\uffff\32\22",
            "\1\31\4\uffff\1\27\1\30",
            "",
            "\12\25\7\uffff\3\25\1\32\2\25\7\uffff\1\33\22\uffff\6\25",
            "\12\25\7\uffff\6\25\10\uffff\1\34\21\uffff\6\25",
            "\12\25\7\uffff\6\25\2\uffff\1\35\27\uffff\6\25",
            "\12\22\7\uffff\4\22\1\36\1\22\1\37\4\22\1\40\6\22\1\41\7\22"+
            "\4\uffff\1\22\1\uffff\32\22",
            "\1\43",
            "\1\44",
            "\1\45",
            "\1\46\1\50\15\uffff\1\47",
            "\1\51\4\uffff\1\52",
            "\1\53\12\uffff\1\54",
            "\12\25\7\uffff\6\25\22\uffff\1\55\7\uffff\6\25",
            "\12\25\7\uffff\6\25\32\uffff\6\25",
            "",
            "",
            "\1\56",
            "\12\25\7\uffff\6\25\32\uffff\6\25",
            "",
            "\1\57\1\uffff\1\60\10\uffff\1\61\6\uffff\1\62\4\uffff\1\63",
            "\1\64",
            "\1\65",
            "\12\25\7\uffff\3\25\1\66\2\25\32\uffff\6\25",
            "\1\67",
            "\1\70",
            "\1\71",
            "\1\72",
            "\1\73",
            "\1\74",
            "\1\75",
            "",
            "\1\76\1\uffff\1\77\10\uffff\1\100\13\uffff\1\101",
            "\1\102",
            "\12\22\7\uffff\32\22\4\uffff\1\22\1\uffff\32\22",
            "\12\22\7\uffff\32\22\4\uffff\1\22\1\uffff\32\22",
            "\1\103",
            "\1\104",
            "\12\22\7\uffff\32\22\4\uffff\1\22\1\uffff\32\22",
            "\1\105",
            "\12\22\7\uffff\32\22\4\uffff\1\22\1\uffff\32\22",
            "\1\106",
            "\1\107",
            "\12\22\7\uffff\32\22\4\uffff\1\22\1\uffff\32\22",
            "\12\22\7\uffff\21\22\1\111\10\22\4\uffff\1\22\1\uffff\32\22",
            "\1\112",
            "\12\22\7\uffff\32\22\4\uffff\1\22\1\uffff\32\22",
            "\1\113",
            "\12\22\7\uffff\32\22\4\uffff\1\22\1\uffff\32\22",
            "\12\22\7\uffff\32\22\4\uffff\1\22\1\uffff\32\22",
            "\12\22\7\uffff\32\22\4\uffff\1\22\1\uffff\32\22",
            "\12\25\7\uffff\6\25\24\22\4\uffff\1\22\1\uffff\6\25\24\22",
            "\12\22\7\uffff\32\22\4\uffff\1\22\1\uffff\32\22",
            "\1\115",
            "\12\22\7\uffff\32\22\4\uffff\1\22\1\uffff\32\22",
            "\12\22\7\uffff\32\22\4\uffff\1\22\1\uffff\32\22",
            "\12\22\7\uffff\32\22\4\uffff\1\22\1\uffff\32\22",
            "\12\22\7\uffff\32\22\4\uffff\1\22\1\uffff\32\22",
            "\1\116",
            "\12\22\7\uffff\32\22\4\uffff\1\22\1\uffff\32\22",
            "\1\117",
            "\12\22\7\uffff\32\22\4\uffff\1\22\1\uffff\32\22",
            "\12\22\7\uffff\32\22\4\uffff\1\22\1\uffff\32\22",
            "\12\22\7\uffff\32\22\4\uffff\1\22\1\uffff\32\22",
            "\1\120",
            "\1\121\24\uffff\1\122",
            "\12\22\7\uffff\32\22\4\uffff\1\22\1\uffff\32\22",
            "\1\123",
            "\1\124",
            "",
            "\1\125",
            "\12\22\7\uffff\32\22\4\uffff\1\22\1\uffff\32\22",
            "\12\22\7\uffff\32\22\4\uffff\1\22\1\uffff\32\22",
            "",
            "\12\22\7\uffff\32\22\4\uffff\1\22\1\uffff\32\22",
            "\12\22\7\uffff\32\22\4\uffff\1\22\1\uffff\32\22",
            "\12\22\7\uffff\32\22\4\uffff\1\22\1\uffff\32\22",
            "\12\22\7\uffff\32\22\4\uffff\1\22\1\uffff\32\22",
            "\12\22\7\uffff\32\22\4\uffff\1\22\1\uffff\32\22",
            "\12\22\7\uffff\32\22\4\uffff\1\22\1\uffff\32\22",
            "\12\22\7\uffff\32\22\4\uffff\1\22\1\uffff\32\22",
            "\12\22\7\uffff\32\22\4\uffff\1\22\1\uffff\32\22",
            "\12\22\7\uffff\32\22\4\uffff\1\22\1\uffff\32\22",
            "",
            ""
    };

    static final short[] DFA5_eot = DFA.unpackEncodedString(DFA5_eotS);
    static final short[] DFA5_eof = DFA.unpackEncodedString(DFA5_eofS);
    static final char[] DFA5_min = DFA.unpackEncodedStringToUnsignedChars(DFA5_minS);
    static final char[] DFA5_max = DFA.unpackEncodedStringToUnsignedChars(DFA5_maxS);
    static final short[] DFA5_accept = DFA.unpackEncodedString(DFA5_acceptS);
    static final short[] DFA5_special = DFA.unpackEncodedString(DFA5_specialS);
    static final short[][] DFA5_transition;

    static {
        int numStates = DFA5_transitionS.length;
        DFA5_transition = new short[numStates][];
        for (int i=0; i<numStates; i++) {
            DFA5_transition[i] = DFA.unpackEncodedString(DFA5_transitionS[i]);
        }
    }

    class DFA5 extends DFA {

        public DFA5(BaseRecognizer recognizer) {
            this.recognizer = recognizer;
            this.decisionNumber = 5;
            this.eot = DFA5_eot;
            this.eof = DFA5_eof;
            this.min = DFA5_min;
            this.max = DFA5_max;
            this.accept = DFA5_accept;
            this.special = DFA5_special;
            this.transition = DFA5_transition;
        }
        public String getDescription() {
            return "1:1: Tokens : ( T__9 | T__10 | T__11 | T__12 | T__13 | OPERACION | OPDIRECTIVA | TIPODIRECTIVA | ETIQUETA | NUMERO );";
        }
    }
 

}