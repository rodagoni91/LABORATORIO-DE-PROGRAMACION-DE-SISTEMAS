// $ANTLR 3.4 C:\\Users\\dany_\\Desktop\\final.g 2020-10-16 09:05:05

import org.antlr.runtime.*;
import java.util.Stack;
import java.util.List;
import java.util.ArrayList;

@SuppressWarnings({"all", "warnings", "unchecked"})
public class finalParser extends Parser {
    public static final String[] tokenNames = new String[] {
        "<invalid>", "<EOR>", "<DOWN>", "<UP>", "ETIQUETA", "NUMERO", "OPDIRECTIVA", "OPERACION", "TIPODIRECTIVA", "',X'", "'END'", "'H'", "'START'", "'\\n'"
    };

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
    public Parser[] getDelegates() {
        return new Parser[] {};
    }

    // delegators


    public finalParser(TokenStream input) {
        this(input, new RecognizerSharedState());
    }
    public finalParser(TokenStream input, RecognizerSharedState state) {
        super(input, state);
    }

    public String[] getTokenNames() { return finalParser.tokenNames; }
    public String getGrammarFileName() { return "C:\\Users\\dany_\\Desktop\\final.g"; }



    // $ANTLR start "programa"
    // C:\\Users\\dany_\\Desktop\\final.g:3:1: programa : inicio ;
    public final void programa() throws RecognitionException {
        try {
            // C:\\Users\\dany_\\Desktop\\final.g:3:9: ( inicio )
            // C:\\Users\\dany_\\Desktop\\final.g:3:11: inicio
            {
            pushFollow(FOLLOW_inicio_in_programa9);
            inicio();

            state._fsp--;


            }

        }
        catch (RecognitionException re) {
            reportError(re);
            recover(input,re);
        }

        finally {
        	// do for sure before leaving
        }
        return ;
    }
    // $ANTLR end "programa"



    // $ANTLR start "inicio"
    // C:\\Users\\dany_\\Desktop\\final.g:5:1: inicio : ETIQUETA 'START' NUMERO ( 'H' )? '\\n' ;
    public final void inicio() throws RecognitionException {
        try {
            // C:\\Users\\dany_\\Desktop\\final.g:5:8: ( ETIQUETA 'START' NUMERO ( 'H' )? '\\n' )
            // C:\\Users\\dany_\\Desktop\\final.g:5:11: ETIQUETA 'START' NUMERO ( 'H' )? '\\n'
            {
            match(input,ETIQUETA,FOLLOW_ETIQUETA_in_inicio18); 

            match(input,12,FOLLOW_12_in_inicio20); 

            match(input,NUMERO,FOLLOW_NUMERO_in_inicio22); 

            // C:\\Users\\dany_\\Desktop\\final.g:5:34: ( 'H' )?
            int alt1=2;
            int LA1_0 = input.LA(1);

            if ( (LA1_0==11) ) {
                alt1=1;
            }
            switch (alt1) {
                case 1 :
                    // C:\\Users\\dany_\\Desktop\\final.g:5:34: 'H'
                    {
                    match(input,11,FOLLOW_11_in_inicio23); 

                    }
                    break;

            }


            match(input,13,FOLLOW_13_in_inicio26); 

            }

        }
        catch (RecognitionException re) {
            reportError(re);
            recover(input,re);
        }

        finally {
        	// do for sure before leaving
        }
        return ;
    }
    // $ANTLR end "inicio"



    // $ANTLR start "proposicion"
    // C:\\Users\\dany_\\Desktop\\final.g:8:1: proposicion : ( instruccion ) ( '\\n' )? ;
    public final void proposicion() throws RecognitionException {
        try {
            // C:\\Users\\dany_\\Desktop\\final.g:9:2: ( ( instruccion ) ( '\\n' )? )
            // C:\\Users\\dany_\\Desktop\\final.g:9:4: ( instruccion ) ( '\\n' )?
            {
            // C:\\Users\\dany_\\Desktop\\final.g:9:4: ( instruccion )
            // C:\\Users\\dany_\\Desktop\\final.g:9:5: instruccion
            {
            pushFollow(FOLLOW_instruccion_in_proposicion39);
            instruccion();

            state._fsp--;


            }


            // C:\\Users\\dany_\\Desktop\\final.g:9:17: ( '\\n' )?
            int alt2=2;
            int LA2_0 = input.LA(1);

            if ( (LA2_0==13) ) {
                alt2=1;
            }
            switch (alt2) {
                case 1 :
                    // C:\\Users\\dany_\\Desktop\\final.g:9:17: '\\n'
                    {
                    match(input,13,FOLLOW_13_in_proposicion41); 

                    }
                    break;

            }


            }

        }
        catch (RecognitionException re) {
            reportError(re);
            recover(input,re);
        }

        finally {
        	// do for sure before leaving
        }
        return ;
    }
    // $ANTLR end "proposicion"



    // $ANTLR start "final"
    // C:\\Users\\dany_\\Desktop\\final.g:12:1: final : 'END' ( ETIQUETA )? ( '\\n' )? ;
    public final void final() throws RecognitionException {
        try {
            // C:\\Users\\dany_\\Desktop\\final.g:12:7: ( 'END' ( ETIQUETA )? ( '\\n' )? )
            // C:\\Users\\dany_\\Desktop\\final.g:12:9: 'END' ( ETIQUETA )? ( '\\n' )?
            {
            match(input,10,FOLLOW_10_in_final53); 

            // C:\\Users\\dany_\\Desktop\\final.g:12:15: ( ETIQUETA )?
            int alt3=2;
            int LA3_0 = input.LA(1);

            if ( (LA3_0==ETIQUETA) ) {
                alt3=1;
            }
            switch (alt3) {
                case 1 :
                    // C:\\Users\\dany_\\Desktop\\final.g:12:15: ETIQUETA
                    {
                    match(input,ETIQUETA,FOLLOW_ETIQUETA_in_final55); 

                    }
                    break;

            }


            // C:\\Users\\dany_\\Desktop\\final.g:12:25: ( '\\n' )?
            int alt4=2;
            int LA4_0 = input.LA(1);

            if ( (LA4_0==13) ) {
                alt4=1;
            }
            switch (alt4) {
                case 1 :
                    // C:\\Users\\dany_\\Desktop\\final.g:12:25: '\\n'
                    {
                    match(input,13,FOLLOW_13_in_final58); 

                    }
                    break;

            }


            }

        }
        catch (RecognitionException re) {
            reportError(re);
            recover(input,re);
        }

        finally {
        	// do for sure before leaving
        }
        return ;
    }
    // $ANTLR end "final"



    // $ANTLR start "instruccion"
    // C:\\Users\\dany_\\Desktop\\final.g:14:1: instruccion : ( ETIQUETA )? OPERACION ( ETIQUETA )? ( ',X' )? '\\n' ;
    public final void instruccion() throws RecognitionException {
        try {
            // C:\\Users\\dany_\\Desktop\\final.g:15:2: ( ( ETIQUETA )? OPERACION ( ETIQUETA )? ( ',X' )? '\\n' )
            // C:\\Users\\dany_\\Desktop\\final.g:15:4: ( ETIQUETA )? OPERACION ( ETIQUETA )? ( ',X' )? '\\n'
            {
            // C:\\Users\\dany_\\Desktop\\final.g:15:4: ( ETIQUETA )?
            int alt5=2;
            int LA5_0 = input.LA(1);

            if ( (LA5_0==ETIQUETA) ) {
                alt5=1;
            }
            switch (alt5) {
                case 1 :
                    // C:\\Users\\dany_\\Desktop\\final.g:15:4: ETIQUETA
                    {
                    match(input,ETIQUETA,FOLLOW_ETIQUETA_in_instruccion69); 

                    }
                    break;

            }


            match(input,OPERACION,FOLLOW_OPERACION_in_instruccion72); 

            // C:\\Users\\dany_\\Desktop\\final.g:15:24: ( ETIQUETA )?
            int alt6=2;
            int LA6_0 = input.LA(1);

            if ( (LA6_0==ETIQUETA) ) {
                alt6=1;
            }
            switch (alt6) {
                case 1 :
                    // C:\\Users\\dany_\\Desktop\\final.g:15:24: ETIQUETA
                    {
                    match(input,ETIQUETA,FOLLOW_ETIQUETA_in_instruccion74); 

                    }
                    break;

            }


            // C:\\Users\\dany_\\Desktop\\final.g:15:33: ( ',X' )?
            int alt7=2;
            int LA7_0 = input.LA(1);

            if ( (LA7_0==9) ) {
                alt7=1;
            }
            switch (alt7) {
                case 1 :
                    // C:\\Users\\dany_\\Desktop\\final.g:15:33: ',X'
                    {
                    match(input,9,FOLLOW_9_in_instruccion76); 

                    }
                    break;

            }


            match(input,13,FOLLOW_13_in_instruccion79); 

            }

        }
        catch (RecognitionException re) {
            reportError(re);
            recover(input,re);
        }

        finally {
        	// do for sure before leaving
        }
        return ;
    }
    // $ANTLR end "instruccion"



    // $ANTLR start "directiva"
    // C:\\Users\\dany_\\Desktop\\final.g:18:1: directiva : ( ETIQUETA )? TIPODIRECTIVA OPDIRECTIVA ;
    public final void directiva() throws RecognitionException {
        try {
            // C:\\Users\\dany_\\Desktop\\final.g:19:2: ( ( ETIQUETA )? TIPODIRECTIVA OPDIRECTIVA )
            // C:\\Users\\dany_\\Desktop\\final.g:19:4: ( ETIQUETA )? TIPODIRECTIVA OPDIRECTIVA
            {
            // C:\\Users\\dany_\\Desktop\\final.g:19:4: ( ETIQUETA )?
            int alt8=2;
            int LA8_0 = input.LA(1);

            if ( (LA8_0==ETIQUETA) ) {
                alt8=1;
            }
            switch (alt8) {
                case 1 :
                    // C:\\Users\\dany_\\Desktop\\final.g:19:4: ETIQUETA
                    {
                    match(input,ETIQUETA,FOLLOW_ETIQUETA_in_directiva91); 

                    }
                    break;

            }


            match(input,TIPODIRECTIVA,FOLLOW_TIPODIRECTIVA_in_directiva94); 

            match(input,OPDIRECTIVA,FOLLOW_OPDIRECTIVA_in_directiva96); 

            }

        }
        catch (RecognitionException re) {
            reportError(re);
            recover(input,re);
        }

        finally {
        	// do for sure before leaving
        }
        return ;
    }
    // $ANTLR end "directiva"

    // Delegated rules


 

    public static final BitSet FOLLOW_inicio_in_programa9 = new BitSet(new long[]{0x0000000000000002L});
    public static final BitSet FOLLOW_ETIQUETA_in_inicio18 = new BitSet(new long[]{0x0000000000001000L});
    public static final BitSet FOLLOW_12_in_inicio20 = new BitSet(new long[]{0x0000000000000020L});
    public static final BitSet FOLLOW_NUMERO_in_inicio22 = new BitSet(new long[]{0x0000000000002800L});
    public static final BitSet FOLLOW_11_in_inicio23 = new BitSet(new long[]{0x0000000000002000L});
    public static final BitSet FOLLOW_13_in_inicio26 = new BitSet(new long[]{0x0000000000000002L});
    public static final BitSet FOLLOW_instruccion_in_proposicion39 = new BitSet(new long[]{0x0000000000002002L});
    public static final BitSet FOLLOW_13_in_proposicion41 = new BitSet(new long[]{0x0000000000000002L});
    public static final BitSet FOLLOW_10_in_final53 = new BitSet(new long[]{0x0000000000002012L});
    public static final BitSet FOLLOW_ETIQUETA_in_final55 = new BitSet(new long[]{0x0000000000002002L});
    public static final BitSet FOLLOW_13_in_final58 = new BitSet(new long[]{0x0000000000000002L});
    public static final BitSet FOLLOW_ETIQUETA_in_instruccion69 = new BitSet(new long[]{0x0000000000000080L});
    public static final BitSet FOLLOW_OPERACION_in_instruccion72 = new BitSet(new long[]{0x0000000000002210L});
    public static final BitSet FOLLOW_ETIQUETA_in_instruccion74 = new BitSet(new long[]{0x0000000000002200L});
    public static final BitSet FOLLOW_9_in_instruccion76 = new BitSet(new long[]{0x0000000000002000L});
    public static final BitSet FOLLOW_13_in_instruccion79 = new BitSet(new long[]{0x0000000000000002L});
    public static final BitSet FOLLOW_ETIQUETA_in_directiva91 = new BitSet(new long[]{0x0000000000000100L});
    public static final BitSet FOLLOW_TIPODIRECTIVA_in_directiva94 = new BitSet(new long[]{0x0000000000000040L});
    public static final BitSet FOLLOW_OPDIRECTIVA_in_directiva96 = new BitSet(new long[]{0x0000000000000002L});

}