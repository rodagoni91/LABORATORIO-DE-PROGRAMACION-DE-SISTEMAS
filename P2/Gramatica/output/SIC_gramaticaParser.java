// $ANTLR 3.4 C:\\Users\\dany_\\Desktop\\SIC_gramatica.g 2020-10-01 21:20:03

import org.antlr.runtime.*;
import java.util.Stack;
import java.util.List;
import java.util.ArrayList;

import org.antlr.runtime.debug.*;
import java.io.IOException;
@SuppressWarnings({"all", "warnings", "unchecked"})
public class SIC_gramaticaParser extends DebugParser {
    public static final String[] tokenNames = new String[] {
        "<invalid>", "<EOR>", "<DOWN>", "<UP>", "FINL", "FINLINEA", "NUM", "SIMBOLO", "'ADD'", "'AND'", "'BYTE'", "'C'", "'COMP'", "'DIV'", "'END'", "'J'", "'JEQ'", "'JGT'", "'JLT'", "'JSUB'", "'LDA'", "'LDCG'", "'LDL'", "'LDX'", "'MUL'", "'OR'", "'RD'", "'RESB'", "'RESW'", "'RSUB'", "'STA'", "'START'", "'STCH'", "'STL'", "'STSW'", "'STX'", "'SUB'", "'TD'", "'TIX'", "'WD'", "'WORD'", "'X'"
    };

    public static final int EOF=-1;
    public static final int T__8=8;
    public static final int T__9=9;
    public static final int T__10=10;
    public static final int T__11=11;
    public static final int T__12=12;
    public static final int T__13=13;
    public static final int T__14=14;
    public static final int T__15=15;
    public static final int T__16=16;
    public static final int T__17=17;
    public static final int T__18=18;
    public static final int T__19=19;
    public static final int T__20=20;
    public static final int T__21=21;
    public static final int T__22=22;
    public static final int T__23=23;
    public static final int T__24=24;
    public static final int T__25=25;
    public static final int T__26=26;
    public static final int T__27=27;
    public static final int T__28=28;
    public static final int T__29=29;
    public static final int T__30=30;
    public static final int T__31=31;
    public static final int T__32=32;
    public static final int T__33=33;
    public static final int T__34=34;
    public static final int T__35=35;
    public static final int T__36=36;
    public static final int T__37=37;
    public static final int T__38=38;
    public static final int T__39=39;
    public static final int T__40=40;
    public static final int T__41=41;
    public static final int FINL=4;
    public static final int FINLINEA=5;
    public static final int NUM=6;
    public static final int SIMBOLO=7;

    // delegates
    public Parser[] getDelegates() {
        return new Parser[] {};
    }

    // delegators


public static final String[] ruleNames = new String[] {
    "invalidRule", "inicio", "instruccion", "operacion", "tipoDirectiva", 
    "programa", "proposicion", "etiqueta", "directiva", "fin", "opDirectiva"
};

public static final boolean[] decisionCanBacktrack = new boolean[] {
    false, // invalid decision
    false, false, false, false
};

 
    public int ruleLevel = 0;
    public int getRuleLevel() { return ruleLevel; }
    public void incRuleLevel() { ruleLevel++; }
    public void decRuleLevel() { ruleLevel--; }
    public SIC_gramaticaParser(TokenStream input) {
        this(input, DebugEventSocketProxy.DEFAULT_DEBUGGER_PORT, new RecognizerSharedState());
    }
    public SIC_gramaticaParser(TokenStream input, int port, RecognizerSharedState state) {
        super(input, state);
        DebugEventSocketProxy proxy =
            new DebugEventSocketProxy(this, port, null);

        setDebugListener(proxy);
        try {
            proxy.handshake();
        }
        catch (IOException ioe) {
            reportError(ioe);
        }
    }

public SIC_gramaticaParser(TokenStream input, DebugEventListener dbg) {
    super(input, dbg, new RecognizerSharedState());
}

protected boolean evalPredicate(boolean result, String predicate) {
    dbg.semanticPredicate(result, predicate);
    return result;
}

    public String[] getTokenNames() { return SIC_gramaticaParser.tokenNames; }
    public String getGrammarFileName() { return "C:\\Users\\dany_\\Desktop\\SIC_gramatica.g"; }



    // $ANTLR start "programa"
    // C:\\Users\\dany_\\Desktop\\SIC_gramatica.g:2:1: programa : inicio ( proposicion )* fin ;
    public final void programa() throws RecognitionException {
        try { dbg.enterRule(getGrammarFileName(), "programa");
        if ( getRuleLevel()==0 ) {dbg.commence();}
        incRuleLevel();
        dbg.location(2, 0);

        try {
            // C:\\Users\\dany_\\Desktop\\SIC_gramatica.g:2:9: ( inicio ( proposicion )* fin )
            dbg.enterAlt(1);

            // C:\\Users\\dany_\\Desktop\\SIC_gramatica.g:2:11: inicio ( proposicion )* fin
            {
            dbg.location(2,11);
            pushFollow(FOLLOW_inicio_in_programa8);
            inicio();

            state._fsp--;

            dbg.location(2,18);
            // C:\\Users\\dany_\\Desktop\\SIC_gramatica.g:2:18: ( proposicion )*
            try { dbg.enterSubRule(1);

            loop1:
            do {
                int alt1=2;
                try { dbg.enterDecision(1, decisionCanBacktrack[1]);

                int LA1_0 = input.LA(1);

                if ( (LA1_0==SIMBOLO) ) {
                    alt1=1;
                }


                } finally {dbg.exitDecision(1);}

                switch (alt1) {
            	case 1 :
            	    dbg.enterAlt(1);

            	    // C:\\Users\\dany_\\Desktop\\SIC_gramatica.g:2:19: proposicion
            	    {
            	    dbg.location(2,19);
            	    pushFollow(FOLLOW_proposicion_in_programa11);
            	    proposicion();

            	    state._fsp--;


            	    }
            	    break;

            	default :
            	    break loop1;
                }
            } while (true);
            } finally {dbg.exitSubRule(1);}

            dbg.location(2,33);
            pushFollow(FOLLOW_fin_in_programa15);
            fin();

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
        dbg.location(2, 35);

        }
        finally {
            dbg.exitRule(getGrammarFileName(), "programa");
            decRuleLevel();
            if ( getRuleLevel()==0 ) {dbg.terminate();}
        }

        return ;
    }
    // $ANTLR end "programa"



    // $ANTLR start "inicio"
    // C:\\Users\\dany_\\Desktop\\SIC_gramatica.g:4:1: inicio : SIMBOLO 'START' NUM FINLINEA ;
    public final void inicio() throws RecognitionException {
        try { dbg.enterRule(getGrammarFileName(), "inicio");
        if ( getRuleLevel()==0 ) {dbg.commence();}
        incRuleLevel();
        dbg.location(4, 0);

        try {
            // C:\\Users\\dany_\\Desktop\\SIC_gramatica.g:4:8: ( SIMBOLO 'START' NUM FINLINEA )
            dbg.enterAlt(1);

            // C:\\Users\\dany_\\Desktop\\SIC_gramatica.g:4:10: SIMBOLO 'START' NUM FINLINEA
            {
            dbg.location(4,10);
            match(input,SIMBOLO,FOLLOW_SIMBOLO_in_inicio23); 
            dbg.location(4,18);
            match(input,31,FOLLOW_31_in_inicio25); 
            dbg.location(4,26);
            match(input,NUM,FOLLOW_NUM_in_inicio27); 
            dbg.location(4,30);
            match(input,FINLINEA,FOLLOW_FINLINEA_in_inicio29); 

            }

        }
        catch (RecognitionException re) {
            reportError(re);
            recover(input,re);
        }

        finally {
        	// do for sure before leaving
        }
        dbg.location(4, 37);

        }
        finally {
            dbg.exitRule(getGrammarFileName(), "inicio");
            decRuleLevel();
            if ( getRuleLevel()==0 ) {dbg.terminate();}
        }

        return ;
    }
    // $ANTLR end "inicio"



    // $ANTLR start "proposicion"
    // C:\\Users\\dany_\\Desktop\\SIC_gramatica.g:6:1: proposicion : ( instruccion | directiva ) FINLINEA ;
    public final void proposicion() throws RecognitionException {
        try { dbg.enterRule(getGrammarFileName(), "proposicion");
        if ( getRuleLevel()==0 ) {dbg.commence();}
        incRuleLevel();
        dbg.location(6, 0);

        try {
            // C:\\Users\\dany_\\Desktop\\SIC_gramatica.g:7:2: ( ( instruccion | directiva ) FINLINEA )
            dbg.enterAlt(1);

            // C:\\Users\\dany_\\Desktop\\SIC_gramatica.g:7:4: ( instruccion | directiva ) FINLINEA
            {
            dbg.location(7,4);
            // C:\\Users\\dany_\\Desktop\\SIC_gramatica.g:7:4: ( instruccion | directiva )
            int alt2=2;
            try { dbg.enterSubRule(2);
            try { dbg.enterDecision(2, decisionCanBacktrack[2]);

            int LA2_0 = input.LA(1);

            if ( (LA2_0==SIMBOLO) ) {
                int LA2_1 = input.LA(2);

                if ( (LA2_1==FINL||(LA2_1 >= 8 && LA2_1 <= 9)||(LA2_1 >= 12 && LA2_1 <= 13)||(LA2_1 >= 15 && LA2_1 <= 26)||(LA2_1 >= 29 && LA2_1 <= 30)||(LA2_1 >= 32 && LA2_1 <= 39)) ) {
                    alt2=1;
                }
                else if ( (LA2_1==10||(LA2_1 >= 27 && LA2_1 <= 28)||LA2_1==40) ) {
                    alt2=2;
                }
                else {
                    NoViableAltException nvae =
                        new NoViableAltException("", 2, 1, input);

                    dbg.recognitionException(nvae);
                    throw nvae;

                }
            }
            else {
                NoViableAltException nvae =
                    new NoViableAltException("", 2, 0, input);

                dbg.recognitionException(nvae);
                throw nvae;

            }
            } finally {dbg.exitDecision(2);}

            switch (alt2) {
                case 1 :
                    dbg.enterAlt(1);

                    // C:\\Users\\dany_\\Desktop\\SIC_gramatica.g:7:5: instruccion
                    {
                    dbg.location(7,5);
                    pushFollow(FOLLOW_instruccion_in_proposicion39);
                    instruccion();

                    state._fsp--;


                    }
                    break;
                case 2 :
                    dbg.enterAlt(2);

                    // C:\\Users\\dany_\\Desktop\\SIC_gramatica.g:7:19: directiva
                    {
                    dbg.location(7,19);
                    pushFollow(FOLLOW_directiva_in_proposicion43);
                    directiva();

                    state._fsp--;


                    }
                    break;

            }
            } finally {dbg.exitSubRule(2);}

            dbg.location(7,30);
            match(input,FINLINEA,FOLLOW_FINLINEA_in_proposicion46); 

            }

        }
        catch (RecognitionException re) {
            reportError(re);
            recover(input,re);
        }

        finally {
        	// do for sure before leaving
        }
        dbg.location(8, 1);

        }
        finally {
            dbg.exitRule(getGrammarFileName(), "proposicion");
            decRuleLevel();
            if ( getRuleLevel()==0 ) {dbg.terminate();}
        }

        return ;
    }
    // $ANTLR end "proposicion"



    // $ANTLR start "instruccion"
    // C:\\Users\\dany_\\Desktop\\SIC_gramatica.g:10:1: instruccion : etiqueta operacion ( etiqueta | NUM ) ;
    public final void instruccion() throws RecognitionException {
        try { dbg.enterRule(getGrammarFileName(), "instruccion");
        if ( getRuleLevel()==0 ) {dbg.commence();}
        incRuleLevel();
        dbg.location(10, 0);

        try {
            // C:\\Users\\dany_\\Desktop\\SIC_gramatica.g:11:2: ( etiqueta operacion ( etiqueta | NUM ) )
            dbg.enterAlt(1);

            // C:\\Users\\dany_\\Desktop\\SIC_gramatica.g:11:4: etiqueta operacion ( etiqueta | NUM )
            {
            dbg.location(11,4);
            pushFollow(FOLLOW_etiqueta_in_instruccion59);
            etiqueta();

            state._fsp--;

            dbg.location(11,13);
            pushFollow(FOLLOW_operacion_in_instruccion61);
            operacion();

            state._fsp--;

            dbg.location(11,23);
            // C:\\Users\\dany_\\Desktop\\SIC_gramatica.g:11:23: ( etiqueta | NUM )
            int alt3=2;
            try { dbg.enterSubRule(3);
            try { dbg.enterDecision(3, decisionCanBacktrack[3]);

            int LA3_0 = input.LA(1);

            if ( (LA3_0==SIMBOLO) ) {
                alt3=1;
            }
            else if ( (LA3_0==NUM) ) {
                alt3=2;
            }
            else {
                NoViableAltException nvae =
                    new NoViableAltException("", 3, 0, input);

                dbg.recognitionException(nvae);
                throw nvae;

            }
            } finally {dbg.exitDecision(3);}

            switch (alt3) {
                case 1 :
                    dbg.enterAlt(1);

                    // C:\\Users\\dany_\\Desktop\\SIC_gramatica.g:11:24: etiqueta
                    {
                    dbg.location(11,24);
                    pushFollow(FOLLOW_etiqueta_in_instruccion64);
                    etiqueta();

                    state._fsp--;


                    }
                    break;
                case 2 :
                    dbg.enterAlt(2);

                    // C:\\Users\\dany_\\Desktop\\SIC_gramatica.g:11:35: NUM
                    {
                    dbg.location(11,35);
                    match(input,NUM,FOLLOW_NUM_in_instruccion68); 

                    }
                    break;

            }
            } finally {dbg.exitSubRule(3);}


            }

        }
        catch (RecognitionException re) {
            reportError(re);
            recover(input,re);
        }

        finally {
        	// do for sure before leaving
        }
        dbg.location(12, 1);

        }
        finally {
            dbg.exitRule(getGrammarFileName(), "instruccion");
            decRuleLevel();
            if ( getRuleLevel()==0 ) {dbg.terminate();}
        }

        return ;
    }
    // $ANTLR end "instruccion"



    // $ANTLR start "directiva"
    // C:\\Users\\dany_\\Desktop\\SIC_gramatica.g:14:1: directiva : etiqueta tipoDirectiva opDirectiva ;
    public final void directiva() throws RecognitionException {
        try { dbg.enterRule(getGrammarFileName(), "directiva");
        if ( getRuleLevel()==0 ) {dbg.commence();}
        incRuleLevel();
        dbg.location(14, 0);

        try {
            // C:\\Users\\dany_\\Desktop\\SIC_gramatica.g:15:2: ( etiqueta tipoDirectiva opDirectiva )
            dbg.enterAlt(1);

            // C:\\Users\\dany_\\Desktop\\SIC_gramatica.g:15:4: etiqueta tipoDirectiva opDirectiva
            {
            dbg.location(15,4);
            pushFollow(FOLLOW_etiqueta_in_directiva81);
            etiqueta();

            state._fsp--;

            dbg.location(15,13);
            pushFollow(FOLLOW_tipoDirectiva_in_directiva83);
            tipoDirectiva();

            state._fsp--;

            dbg.location(15,27);
            pushFollow(FOLLOW_opDirectiva_in_directiva85);
            opDirectiva();

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
        dbg.location(16, 1);

        }
        finally {
            dbg.exitRule(getGrammarFileName(), "directiva");
            decRuleLevel();
            if ( getRuleLevel()==0 ) {dbg.terminate();}
        }

        return ;
    }
    // $ANTLR end "directiva"



    // $ANTLR start "etiqueta"
    // C:\\Users\\dany_\\Desktop\\SIC_gramatica.g:18:1: etiqueta : SIMBOLO ;
    public final void etiqueta() throws RecognitionException {
        try { dbg.enterRule(getGrammarFileName(), "etiqueta");
        if ( getRuleLevel()==0 ) {dbg.commence();}
        incRuleLevel();
        dbg.location(18, 0);

        try {
            // C:\\Users\\dany_\\Desktop\\SIC_gramatica.g:18:9: ( SIMBOLO )
            dbg.enterAlt(1);

            // C:\\Users\\dany_\\Desktop\\SIC_gramatica.g:18:11: SIMBOLO
            {
            dbg.location(18,11);
            match(input,SIMBOLO,FOLLOW_SIMBOLO_in_etiqueta95); 

            }

        }
        catch (RecognitionException re) {
            reportError(re);
            recover(input,re);
        }

        finally {
        	// do for sure before leaving
        }
        dbg.location(18, 17);

        }
        finally {
            dbg.exitRule(getGrammarFileName(), "etiqueta");
            decRuleLevel();
            if ( getRuleLevel()==0 ) {dbg.terminate();}
        }

        return ;
    }
    // $ANTLR end "etiqueta"



    // $ANTLR start "operacion"
    // C:\\Users\\dany_\\Desktop\\SIC_gramatica.g:20:1: operacion : ( 'ADD' | 'AND' | 'COMP' | 'DIV' | 'J' | 'JEQ' | 'JGT' | 'JLT' | 'JSUB' | 'LDA' | 'LDCG' | 'LDL' | 'LDX' | 'MUL' | 'OR' | 'RD' | 'RSUB' | 'STA' | 'STCH' | 'STL' | 'STSW' | 'STX' | 'SUB' | 'TD' | 'TIX' | 'WD' | FINL );
    public final void operacion() throws RecognitionException {
        try { dbg.enterRule(getGrammarFileName(), "operacion");
        if ( getRuleLevel()==0 ) {dbg.commence();}
        incRuleLevel();
        dbg.location(20, 0);

        try {
            // C:\\Users\\dany_\\Desktop\\SIC_gramatica.g:21:2: ( 'ADD' | 'AND' | 'COMP' | 'DIV' | 'J' | 'JEQ' | 'JGT' | 'JLT' | 'JSUB' | 'LDA' | 'LDCG' | 'LDL' | 'LDX' | 'MUL' | 'OR' | 'RD' | 'RSUB' | 'STA' | 'STCH' | 'STL' | 'STSW' | 'STX' | 'SUB' | 'TD' | 'TIX' | 'WD' | FINL )
            dbg.enterAlt(1);

            // C:\\Users\\dany_\\Desktop\\SIC_gramatica.g:
            {
            dbg.location(21,2);
            if ( input.LA(1)==FINL||(input.LA(1) >= 8 && input.LA(1) <= 9)||(input.LA(1) >= 12 && input.LA(1) <= 13)||(input.LA(1) >= 15 && input.LA(1) <= 26)||(input.LA(1) >= 29 && input.LA(1) <= 30)||(input.LA(1) >= 32 && input.LA(1) <= 39) ) {
                input.consume();
                state.errorRecovery=false;
            }
            else {
                MismatchedSetException mse = new MismatchedSetException(null,input);
                dbg.recognitionException(mse);
                throw mse;
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
        dbg.location(22, 1);

        }
        finally {
            dbg.exitRule(getGrammarFileName(), "operacion");
            decRuleLevel();
            if ( getRuleLevel()==0 ) {dbg.terminate();}
        }

        return ;
    }
    // $ANTLR end "operacion"



    // $ANTLR start "tipoDirectiva"
    // C:\\Users\\dany_\\Desktop\\SIC_gramatica.g:24:1: tipoDirectiva : ( 'BYTE' | 'WORD' | 'RESB' | 'RESW' );
    public final void tipoDirectiva() throws RecognitionException {
        try { dbg.enterRule(getGrammarFileName(), "tipoDirectiva");
        if ( getRuleLevel()==0 ) {dbg.commence();}
        incRuleLevel();
        dbg.location(24, 0);

        try {
            // C:\\Users\\dany_\\Desktop\\SIC_gramatica.g:25:2: ( 'BYTE' | 'WORD' | 'RESB' | 'RESW' )
            dbg.enterAlt(1);

            // C:\\Users\\dany_\\Desktop\\SIC_gramatica.g:
            {
            dbg.location(25,2);
            if ( input.LA(1)==10||(input.LA(1) >= 27 && input.LA(1) <= 28)||input.LA(1)==40 ) {
                input.consume();
                state.errorRecovery=false;
            }
            else {
                MismatchedSetException mse = new MismatchedSetException(null,input);
                dbg.recognitionException(mse);
                throw mse;
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
        dbg.location(26, 1);

        }
        finally {
            dbg.exitRule(getGrammarFileName(), "tipoDirectiva");
            decRuleLevel();
            if ( getRuleLevel()==0 ) {dbg.terminate();}
        }

        return ;
    }
    // $ANTLR end "tipoDirectiva"



    // $ANTLR start "opDirectiva"
    // C:\\Users\\dany_\\Desktop\\SIC_gramatica.g:28:1: opDirectiva : ( NUM | 'C' SIMBOLO | 'X' NUM );
    public final void opDirectiva() throws RecognitionException {
        try { dbg.enterRule(getGrammarFileName(), "opDirectiva");
        if ( getRuleLevel()==0 ) {dbg.commence();}
        incRuleLevel();
        dbg.location(28, 0);

        try {
            // C:\\Users\\dany_\\Desktop\\SIC_gramatica.g:29:2: ( NUM | 'C' SIMBOLO | 'X' NUM )
            int alt4=3;
            try { dbg.enterDecision(4, decisionCanBacktrack[4]);

            switch ( input.LA(1) ) {
            case NUM:
                {
                alt4=1;
                }
                break;
            case 11:
                {
                alt4=2;
                }
                break;
            case 41:
                {
                alt4=3;
                }
                break;
            default:
                NoViableAltException nvae =
                    new NoViableAltException("", 4, 0, input);

                dbg.recognitionException(nvae);
                throw nvae;

            }

            } finally {dbg.exitDecision(4);}

            switch (alt4) {
                case 1 :
                    dbg.enterAlt(1);

                    // C:\\Users\\dany_\\Desktop\\SIC_gramatica.g:29:5: NUM
                    {
                    dbg.location(29,5);
                    match(input,NUM,FOLLOW_NUM_in_opDirectiva247); 

                    }
                    break;
                case 2 :
                    dbg.enterAlt(2);

                    // C:\\Users\\dany_\\Desktop\\SIC_gramatica.g:29:11: 'C' SIMBOLO
                    {
                    dbg.location(29,11);
                    match(input,11,FOLLOW_11_in_opDirectiva251); 
                    dbg.location(29,14);
                    match(input,SIMBOLO,FOLLOW_SIMBOLO_in_opDirectiva252); 

                    }
                    break;
                case 3 :
                    dbg.enterAlt(3);

                    // C:\\Users\\dany_\\Desktop\\SIC_gramatica.g:29:24: 'X' NUM
                    {
                    dbg.location(29,24);
                    match(input,41,FOLLOW_41_in_opDirectiva256); 
                    dbg.location(29,27);
                    match(input,NUM,FOLLOW_NUM_in_opDirectiva257); 

                    }
                    break;

            }
        }
        catch (RecognitionException re) {
            reportError(re);
            recover(input,re);
        }

        finally {
        	// do for sure before leaving
        }
        dbg.location(30, 1);

        }
        finally {
            dbg.exitRule(getGrammarFileName(), "opDirectiva");
            decRuleLevel();
            if ( getRuleLevel()==0 ) {dbg.terminate();}
        }

        return ;
    }
    // $ANTLR end "opDirectiva"



    // $ANTLR start "fin"
    // C:\\Users\\dany_\\Desktop\\SIC_gramatica.g:32:1: fin : 'END' ;
    public final void fin() throws RecognitionException {
        try { dbg.enterRule(getGrammarFileName(), "fin");
        if ( getRuleLevel()==0 ) {dbg.commence();}
        incRuleLevel();
        dbg.location(32, 0);

        try {
            // C:\\Users\\dany_\\Desktop\\SIC_gramatica.g:32:5: ( 'END' )
            dbg.enterAlt(1);

            // C:\\Users\\dany_\\Desktop\\SIC_gramatica.g:32:7: 'END'
            {
            dbg.location(32,7);
            match(input,14,FOLLOW_14_in_fin268); 

            }

        }
        catch (RecognitionException re) {
            reportError(re);
            recover(input,re);
        }

        finally {
        	// do for sure before leaving
        }
        dbg.location(33, 1);

        }
        finally {
            dbg.exitRule(getGrammarFileName(), "fin");
            decRuleLevel();
            if ( getRuleLevel()==0 ) {dbg.terminate();}
        }

        return ;
    }
    // $ANTLR end "fin"

    // Delegated rules


 

    public static final BitSet FOLLOW_inicio_in_programa8 = new BitSet(new long[]{0x0000000000004080L});
    public static final BitSet FOLLOW_proposicion_in_programa11 = new BitSet(new long[]{0x0000000000004080L});
    public static final BitSet FOLLOW_fin_in_programa15 = new BitSet(new long[]{0x0000000000000002L});
    public static final BitSet FOLLOW_SIMBOLO_in_inicio23 = new BitSet(new long[]{0x0000000080000000L});
    public static final BitSet FOLLOW_31_in_inicio25 = new BitSet(new long[]{0x0000000000000040L});
    public static final BitSet FOLLOW_NUM_in_inicio27 = new BitSet(new long[]{0x0000000000000020L});
    public static final BitSet FOLLOW_FINLINEA_in_inicio29 = new BitSet(new long[]{0x0000000000000002L});
    public static final BitSet FOLLOW_instruccion_in_proposicion39 = new BitSet(new long[]{0x0000000000000020L});
    public static final BitSet FOLLOW_directiva_in_proposicion43 = new BitSet(new long[]{0x0000000000000020L});
    public static final BitSet FOLLOW_FINLINEA_in_proposicion46 = new BitSet(new long[]{0x0000000000000002L});
    public static final BitSet FOLLOW_etiqueta_in_instruccion59 = new BitSet(new long[]{0x000000FF67FFB310L});
    public static final BitSet FOLLOW_operacion_in_instruccion61 = new BitSet(new long[]{0x00000000000000C0L});
    public static final BitSet FOLLOW_etiqueta_in_instruccion64 = new BitSet(new long[]{0x0000000000000002L});
    public static final BitSet FOLLOW_NUM_in_instruccion68 = new BitSet(new long[]{0x0000000000000002L});
    public static final BitSet FOLLOW_etiqueta_in_directiva81 = new BitSet(new long[]{0x0000010018000400L});
    public static final BitSet FOLLOW_tipoDirectiva_in_directiva83 = new BitSet(new long[]{0x0000020000000840L});
    public static final BitSet FOLLOW_opDirectiva_in_directiva85 = new BitSet(new long[]{0x0000000000000002L});
    public static final BitSet FOLLOW_SIMBOLO_in_etiqueta95 = new BitSet(new long[]{0x0000000000000002L});
    public static final BitSet FOLLOW_NUM_in_opDirectiva247 = new BitSet(new long[]{0x0000000000000002L});
    public static final BitSet FOLLOW_11_in_opDirectiva251 = new BitSet(new long[]{0x0000000000000080L});
    public static final BitSet FOLLOW_SIMBOLO_in_opDirectiva252 = new BitSet(new long[]{0x0000000000000002L});
    public static final BitSet FOLLOW_41_in_opDirectiva256 = new BitSet(new long[]{0x0000000000000040L});
    public static final BitSet FOLLOW_NUM_in_opDirectiva257 = new BitSet(new long[]{0x0000000000000002L});
    public static final BitSet FOLLOW_14_in_fin268 = new BitSet(new long[]{0x0000000000000002L});

}