// $ANTLR 3.4 C:\\Users\\dany_\\Desktop\\antlr2020.g 2020-10-15 21:01:40

import org.antlr.runtime.*;
import java.util.Stack;
import java.util.List;
import java.util.ArrayList;

import org.antlr.runtime.debug.*;
import java.io.IOException;
@SuppressWarnings({"all", "warnings", "unchecked"})
public class antlr2020Parser extends DebugParser {
    public static final String[] tokenNames = new String[] {
        "<invalid>", "<EOR>", "<DOWN>", "<UP>", "DIR", "DIRECCION", "MAYUSCULAS", "MINUSCULAS", "NOMBRE", "NUMERO", "OPDIRECTIVA", "OPERACION", "REGISTRO", "START", "TIPODIRECTIVA", "',X'", "'END'", "'\\n'"
    };

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
    public Parser[] getDelegates() {
        return new Parser[] {};
    }

    // delegators


public static final String[] ruleNames = new String[] {
    "invalidRule", "programa", "inicio", "directiva", "instruccion", "final", 
    "proposicion"
};

public static final boolean[] decisionCanBacktrack = new boolean[] {
    false, // invalid decision
    false, false, false, false, false, false, false, false
};

 
    public int ruleLevel = 0;
    public int getRuleLevel() { return ruleLevel; }
    public void incRuleLevel() { ruleLevel++; }
    public void decRuleLevel() { ruleLevel--; }
    public antlr2020Parser(TokenStream input) {
        this(input, DebugEventSocketProxy.DEFAULT_DEBUGGER_PORT, new RecognizerSharedState());
    }
    public antlr2020Parser(TokenStream input, int port, RecognizerSharedState state) {
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

public antlr2020Parser(TokenStream input, DebugEventListener dbg) {
    super(input, dbg, new RecognizerSharedState());
}

protected boolean evalPredicate(boolean result, String predicate) {
    dbg.semanticPredicate(result, predicate);
    return result;
}

    public String[] getTokenNames() { return antlr2020Parser.tokenNames; }
    public String getGrammarFileName() { return "C:\\Users\\dany_\\Desktop\\antlr2020.g"; }



    // $ANTLR start "programa"
    // C:\\Users\\dany_\\Desktop\\antlr2020.g:4:1: programa : inicio ( proposicion )* final ;
    public final void programa() throws RecognitionException {
        try { dbg.enterRule(getGrammarFileName(), "programa");
        if ( getRuleLevel()==0 ) {dbg.commence();}
        incRuleLevel();
        dbg.location(4, 0);

        try {
            // C:\\Users\\dany_\\Desktop\\antlr2020.g:4:9: ( inicio ( proposicion )* final )
            dbg.enterAlt(1);

            // C:\\Users\\dany_\\Desktop\\antlr2020.g:4:12: inicio ( proposicion )* final
            {
            dbg.location(4,12);
            pushFollow(FOLLOW_inicio_in_programa11);
            inicio();

            state._fsp--;

            dbg.location(4,19);
            // C:\\Users\\dany_\\Desktop\\antlr2020.g:4:19: ( proposicion )*
            try { dbg.enterSubRule(1);

            loop1:
            do {
                int alt1=2;
                try { dbg.enterDecision(1, decisionCanBacktrack[1]);

                int LA1_0 = input.LA(1);

                if ( (LA1_0==NOMBRE||LA1_0==OPERACION) ) {
                    alt1=1;
                }


                } finally {dbg.exitDecision(1);}

                switch (alt1) {
            	case 1 :
            	    dbg.enterAlt(1);

            	    // C:\\Users\\dany_\\Desktop\\antlr2020.g:4:19: proposicion
            	    {
            	    dbg.location(4,19);
            	    pushFollow(FOLLOW_proposicion_in_programa13);
            	    proposicion();

            	    state._fsp--;


            	    }
            	    break;

            	default :
            	    break loop1;
                }
            } while (true);
            } finally {dbg.exitSubRule(1);}

            dbg.location(4,32);
            pushFollow(FOLLOW_final_in_programa16);
            final();

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
        dbg.location(4, 36);

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
    // C:\\Users\\dany_\\Desktop\\antlr2020.g:6:1: inicio : NOMBRE START DIR '\\n' ;
    public final void inicio() throws RecognitionException {
        try { dbg.enterRule(getGrammarFileName(), "inicio");
        if ( getRuleLevel()==0 ) {dbg.commence();}
        incRuleLevel();
        dbg.location(6, 0);

        try {
            // C:\\Users\\dany_\\Desktop\\antlr2020.g:6:8: ( NOMBRE START DIR '\\n' )
            dbg.enterAlt(1);

            // C:\\Users\\dany_\\Desktop\\antlr2020.g:6:10: NOMBRE START DIR '\\n'
            {
            dbg.location(6,10);
            match(input,NOMBRE,FOLLOW_NOMBRE_in_inicio24); 
            dbg.location(6,17);
            match(input,START,FOLLOW_START_in_inicio26); 
            dbg.location(6,23);
            match(input,DIR,FOLLOW_DIR_in_inicio28); 
            dbg.location(6,26);
            match(input,17,FOLLOW_17_in_inicio29); 

            }

        }
        catch (RecognitionException re) {
            reportError(re);
            recover(input,re);
        }

        finally {
        	// do for sure before leaving
        }
        dbg.location(6, 29);

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
    // C:\\Users\\dany_\\Desktop\\antlr2020.g:8:1: proposicion : ( instruccion | directiva ) ( '\\n' )? ;
    public final void proposicion() throws RecognitionException {
        try { dbg.enterRule(getGrammarFileName(), "proposicion");
        if ( getRuleLevel()==0 ) {dbg.commence();}
        incRuleLevel();
        dbg.location(8, 0);

        try {
            // C:\\Users\\dany_\\Desktop\\antlr2020.g:9:2: ( ( instruccion | directiva ) ( '\\n' )? )
            dbg.enterAlt(1);

            // C:\\Users\\dany_\\Desktop\\antlr2020.g:9:4: ( instruccion | directiva ) ( '\\n' )?
            {
            dbg.location(9,4);
            // C:\\Users\\dany_\\Desktop\\antlr2020.g:9:4: ( instruccion | directiva )
            int alt2=2;
            try { dbg.enterSubRule(2);
            try { dbg.enterDecision(2, decisionCanBacktrack[2]);

            int LA2_0 = input.LA(1);

            if ( (LA2_0==NOMBRE) ) {
                int LA2_1 = input.LA(2);

                if ( (LA2_1==TIPODIRECTIVA) ) {
                    alt2=2;
                }
                else if ( (LA2_1==OPERACION) ) {
                    alt2=1;
                }
                else {
                    NoViableAltException nvae =
                        new NoViableAltException("", 2, 1, input);

                    dbg.recognitionException(nvae);
                    throw nvae;

                }
            }
            else if ( (LA2_0==OPERACION) ) {
                alt2=1;
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

                    // C:\\Users\\dany_\\Desktop\\antlr2020.g:9:5: instruccion
                    {
                    dbg.location(9,5);
                    pushFollow(FOLLOW_instruccion_in_proposicion39);
                    instruccion();

                    state._fsp--;


                    }
                    break;
                case 2 :
                    dbg.enterAlt(2);

                    // C:\\Users\\dany_\\Desktop\\antlr2020.g:9:17: directiva
                    {
                    dbg.location(9,17);
                    pushFollow(FOLLOW_directiva_in_proposicion41);
                    directiva();

                    state._fsp--;


                    }
                    break;

            }
            } finally {dbg.exitSubRule(2);}

            dbg.location(9,27);
            // C:\\Users\\dany_\\Desktop\\antlr2020.g:9:27: ( '\\n' )?
            int alt3=2;
            try { dbg.enterSubRule(3);
            try { dbg.enterDecision(3, decisionCanBacktrack[3]);

            int LA3_0 = input.LA(1);

            if ( (LA3_0==17) ) {
                alt3=1;
            }
            } finally {dbg.exitDecision(3);}

            switch (alt3) {
                case 1 :
                    dbg.enterAlt(1);

                    // C:\\Users\\dany_\\Desktop\\antlr2020.g:9:27: '\\n'
                    {
                    dbg.location(9,27);
                    match(input,17,FOLLOW_17_in_proposicion43); 

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
        dbg.location(10, 1);

        }
        finally {
            dbg.exitRule(getGrammarFileName(), "proposicion");
            decRuleLevel();
            if ( getRuleLevel()==0 ) {dbg.terminate();}
        }

        return ;
    }
    // $ANTLR end "proposicion"



    // $ANTLR start "final"
    // C:\\Users\\dany_\\Desktop\\antlr2020.g:12:1: final : 'END' ( NOMBRE )? ( '\\n' )? ;
    public final void final() throws RecognitionException {
        try { dbg.enterRule(getGrammarFileName(), "final");
        if ( getRuleLevel()==0 ) {dbg.commence();}
        incRuleLevel();
        dbg.location(12, 0);

        try {
            // C:\\Users\\dany_\\Desktop\\antlr2020.g:12:7: ( 'END' ( NOMBRE )? ( '\\n' )? )
            dbg.enterAlt(1);

            // C:\\Users\\dany_\\Desktop\\antlr2020.g:12:9: 'END' ( NOMBRE )? ( '\\n' )?
            {
            dbg.location(12,9);
            match(input,16,FOLLOW_16_in_final55); 
            dbg.location(12,15);
            // C:\\Users\\dany_\\Desktop\\antlr2020.g:12:15: ( NOMBRE )?
            int alt4=2;
            try { dbg.enterSubRule(4);
            try { dbg.enterDecision(4, decisionCanBacktrack[4]);

            int LA4_0 = input.LA(1);

            if ( (LA4_0==NOMBRE) ) {
                alt4=1;
            }
            } finally {dbg.exitDecision(4);}

            switch (alt4) {
                case 1 :
                    dbg.enterAlt(1);

                    // C:\\Users\\dany_\\Desktop\\antlr2020.g:12:15: NOMBRE
                    {
                    dbg.location(12,15);
                    match(input,NOMBRE,FOLLOW_NOMBRE_in_final57); 

                    }
                    break;

            }
            } finally {dbg.exitSubRule(4);}

            dbg.location(12,23);
            // C:\\Users\\dany_\\Desktop\\antlr2020.g:12:23: ( '\\n' )?
            int alt5=2;
            try { dbg.enterSubRule(5);
            try { dbg.enterDecision(5, decisionCanBacktrack[5]);

            int LA5_0 = input.LA(1);

            if ( (LA5_0==17) ) {
                alt5=1;
            }
            } finally {dbg.exitDecision(5);}

            switch (alt5) {
                case 1 :
                    dbg.enterAlt(1);

                    // C:\\Users\\dany_\\Desktop\\antlr2020.g:12:23: '\\n'
                    {
                    dbg.location(12,23);
                    match(input,17,FOLLOW_17_in_final60); 

                    }
                    break;

            }
            } finally {dbg.exitSubRule(5);}


            }

        }
        catch (RecognitionException re) {
            reportError(re);
            recover(input,re);
        }

        finally {
        	// do for sure before leaving
        }
        dbg.location(12, 27);

        }
        finally {
            dbg.exitRule(getGrammarFileName(), "final");
            decRuleLevel();
            if ( getRuleLevel()==0 ) {dbg.terminate();}
        }

        return ;
    }
    // $ANTLR end "final"



    // $ANTLR start "instruccion"
    // C:\\Users\\dany_\\Desktop\\antlr2020.g:14:1: instruccion : ( NOMBRE )? OPERACION ( NOMBRE )? ( ',X' )? '\\n' ;
    public final void instruccion() throws RecognitionException {
        try { dbg.enterRule(getGrammarFileName(), "instruccion");
        if ( getRuleLevel()==0 ) {dbg.commence();}
        incRuleLevel();
        dbg.location(14, 0);

        try {
            // C:\\Users\\dany_\\Desktop\\antlr2020.g:15:2: ( ( NOMBRE )? OPERACION ( NOMBRE )? ( ',X' )? '\\n' )
            dbg.enterAlt(1);

            // C:\\Users\\dany_\\Desktop\\antlr2020.g:15:4: ( NOMBRE )? OPERACION ( NOMBRE )? ( ',X' )? '\\n'
            {
            dbg.location(15,4);
            // C:\\Users\\dany_\\Desktop\\antlr2020.g:15:4: ( NOMBRE )?
            int alt6=2;
            try { dbg.enterSubRule(6);
            try { dbg.enterDecision(6, decisionCanBacktrack[6]);

            int LA6_0 = input.LA(1);

            if ( (LA6_0==NOMBRE) ) {
                alt6=1;
            }
            } finally {dbg.exitDecision(6);}

            switch (alt6) {
                case 1 :
                    dbg.enterAlt(1);

                    // C:\\Users\\dany_\\Desktop\\antlr2020.g:15:4: NOMBRE
                    {
                    dbg.location(15,4);
                    match(input,NOMBRE,FOLLOW_NOMBRE_in_instruccion70); 

                    }
                    break;

            }
            } finally {dbg.exitSubRule(6);}

            dbg.location(15,12);
            match(input,OPERACION,FOLLOW_OPERACION_in_instruccion73); 
            dbg.location(15,22);
            // C:\\Users\\dany_\\Desktop\\antlr2020.g:15:22: ( NOMBRE )?
            int alt7=2;
            try { dbg.enterSubRule(7);
            try { dbg.enterDecision(7, decisionCanBacktrack[7]);

            int LA7_0 = input.LA(1);

            if ( (LA7_0==NOMBRE) ) {
                alt7=1;
            }
            } finally {dbg.exitDecision(7);}

            switch (alt7) {
                case 1 :
                    dbg.enterAlt(1);

                    // C:\\Users\\dany_\\Desktop\\antlr2020.g:15:22: NOMBRE
                    {
                    dbg.location(15,22);
                    match(input,NOMBRE,FOLLOW_NOMBRE_in_instruccion75); 

                    }
                    break;

            }
            } finally {dbg.exitSubRule(7);}

            dbg.location(15,29);
            // C:\\Users\\dany_\\Desktop\\antlr2020.g:15:29: ( ',X' )?
            int alt8=2;
            try { dbg.enterSubRule(8);
            try { dbg.enterDecision(8, decisionCanBacktrack[8]);

            int LA8_0 = input.LA(1);

            if ( (LA8_0==15) ) {
                alt8=1;
            }
            } finally {dbg.exitDecision(8);}

            switch (alt8) {
                case 1 :
                    dbg.enterAlt(1);

                    // C:\\Users\\dany_\\Desktop\\antlr2020.g:15:29: ',X'
                    {
                    dbg.location(15,29);
                    match(input,15,FOLLOW_15_in_instruccion77); 

                    }
                    break;

            }
            } finally {dbg.exitSubRule(8);}

            dbg.location(15,35);
            match(input,17,FOLLOW_17_in_instruccion80); 

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
            dbg.exitRule(getGrammarFileName(), "instruccion");
            decRuleLevel();
            if ( getRuleLevel()==0 ) {dbg.terminate();}
        }

        return ;
    }
    // $ANTLR end "instruccion"



    // $ANTLR start "directiva"
    // C:\\Users\\dany_\\Desktop\\antlr2020.g:18:1: directiva : NOMBRE TIPODIRECTIVA OPDIRECTIVA ;
    public final void directiva() throws RecognitionException {
        try { dbg.enterRule(getGrammarFileName(), "directiva");
        if ( getRuleLevel()==0 ) {dbg.commence();}
        incRuleLevel();
        dbg.location(18, 0);

        try {
            // C:\\Users\\dany_\\Desktop\\antlr2020.g:19:2: ( NOMBRE TIPODIRECTIVA OPDIRECTIVA )
            dbg.enterAlt(1);

            // C:\\Users\\dany_\\Desktop\\antlr2020.g:19:4: NOMBRE TIPODIRECTIVA OPDIRECTIVA
            {
            dbg.location(19,4);
            match(input,NOMBRE,FOLLOW_NOMBRE_in_directiva92); 
            dbg.location(19,11);
            match(input,TIPODIRECTIVA,FOLLOW_TIPODIRECTIVA_in_directiva94); 
            dbg.location(19,25);
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
        dbg.location(20, 1);

        }
        finally {
            dbg.exitRule(getGrammarFileName(), "directiva");
            decRuleLevel();
            if ( getRuleLevel()==0 ) {dbg.terminate();}
        }

        return ;
    }
    // $ANTLR end "directiva"

    // Delegated rules


 

    public static final BitSet FOLLOW_inicio_in_programa11 = new BitSet(new long[]{0x0000000000010900L});
    public static final BitSet FOLLOW_proposicion_in_programa13 = new BitSet(new long[]{0x0000000000010900L});
    public static final BitSet FOLLOW_final_in_programa16 = new BitSet(new long[]{0x0000000000000002L});
    public static final BitSet FOLLOW_NOMBRE_in_inicio24 = new BitSet(new long[]{0x0000000000002000L});
    public static final BitSet FOLLOW_START_in_inicio26 = new BitSet(new long[]{0x0000000000000010L});
    public static final BitSet FOLLOW_DIR_in_inicio28 = new BitSet(new long[]{0x0000000000020000L});
    public static final BitSet FOLLOW_17_in_inicio29 = new BitSet(new long[]{0x0000000000000002L});
    public static final BitSet FOLLOW_instruccion_in_proposicion39 = new BitSet(new long[]{0x0000000000020002L});
    public static final BitSet FOLLOW_directiva_in_proposicion41 = new BitSet(new long[]{0x0000000000020002L});
    public static final BitSet FOLLOW_17_in_proposicion43 = new BitSet(new long[]{0x0000000000000002L});
    public static final BitSet FOLLOW_16_in_final55 = new BitSet(new long[]{0x0000000000020102L});
    public static final BitSet FOLLOW_NOMBRE_in_final57 = new BitSet(new long[]{0x0000000000020002L});
    public static final BitSet FOLLOW_17_in_final60 = new BitSet(new long[]{0x0000000000000002L});
    public static final BitSet FOLLOW_NOMBRE_in_instruccion70 = new BitSet(new long[]{0x0000000000000800L});
    public static final BitSet FOLLOW_OPERACION_in_instruccion73 = new BitSet(new long[]{0x0000000000028100L});
    public static final BitSet FOLLOW_NOMBRE_in_instruccion75 = new BitSet(new long[]{0x0000000000028000L});
    public static final BitSet FOLLOW_15_in_instruccion77 = new BitSet(new long[]{0x0000000000020000L});
    public static final BitSet FOLLOW_17_in_instruccion80 = new BitSet(new long[]{0x0000000000000002L});
    public static final BitSet FOLLOW_NOMBRE_in_directiva92 = new BitSet(new long[]{0x0000000000004000L});
    public static final BitSet FOLLOW_TIPODIRECTIVA_in_directiva94 = new BitSet(new long[]{0x0000000000000400L});
    public static final BitSet FOLLOW_OPDIRECTIVA_in_directiva96 = new BitSet(new long[]{0x0000000000000002L});

}