﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     ANTLR Version: 3.4
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

// $ANTLR 3.4 C:\\Users\\dany_\\Desktop\\SIC_gramatica.g 2020-10-16 11:37:50

// The variable 'variable' is assigned but its value is never used.
#pragma warning disable 168, 219
// Unreachable code detected.
#pragma warning disable 162
// Missing XML comment for publicly visible type or member 'Type_or_Member'
#pragma warning disable 1591


using System.Collections.Generic;
using Antlr.Runtime;
using Antlr.Runtime.Misc;
using ConditionalAttribute = System.Diagnostics.ConditionalAttribute;

[System.CodeDom.Compiler.GeneratedCode("ANTLR", "3.4")]
[System.CLSCompliant(false)]
public partial class SIC_gramaticaParser : Antlr.Runtime.Parser
{
    internal static readonly string[] tokenNames = new string[] {
        "<invalid>", "<EOR>", "<DOWN>", "<UP>", "DIR", "INT", "NOMBRE", "OPERACION", "OPERACIONDIRECTIVA", "START", "TIPODIRECTIVA", "',X'", "'END'", "'\\n'"
    };
    public const int EOF = -1;
    public const int T__11 = 11;
    public const int T__12 = 12;
    public const int T__13 = 13;
    public const int DIR = 4;
    public const int INT = 5;
    public const int NOMBRE = 6;
    public const int OPERACION = 7;
    public const int OPERACIONDIRECTIVA = 8;
    public const int START = 9;
    public const int TIPODIRECTIVA = 10;

#if ANTLR_DEBUG
		private static readonly bool[] decisionCanBacktrack =
			new bool[]
			{
				false, // invalid decision
				false, false, false, false, false, false, false, false, false
			};
#else
    private static readonly bool[] decisionCanBacktrack = new bool[0];
#endif
    public SIC_gramaticaParser(ITokenStream input)
        : this(input, new RecognizerSharedState())
    {
    }
    public SIC_gramaticaParser(ITokenStream input, RecognizerSharedState state)
        : base(input, state)
    {
        OnCreated();
    }

    public override string[] TokenNames { get { return SIC_gramaticaParser.tokenNames; } }
    public override string GrammarFileName { get { return "C:\\Users\\dany_\\Desktop\\SIC_gramatica.g"; } }


    [Conditional("ANTLR_TRACE")]
    protected virtual void OnCreated() { }
    [Conditional("ANTLR_TRACE")]
    protected virtual void EnterRule(string ruleName, int ruleIndex) { }
    [Conditional("ANTLR_TRACE")]
    protected virtual void LeaveRule(string ruleName, int ruleIndex) { }

    #region Rules

    [Conditional("ANTLR_TRACE")]
    protected virtual void EnterRule_programa() { }
    [Conditional("ANTLR_TRACE")]
    protected virtual void LeaveRule_programa() { }

    // $ANTLR start "programa"
    // C:\\Users\\dany_\\Desktop\\SIC_gramatica.g:14:1: programa : inicio ( proposicion )* final ;
    [GrammarRule("programa")]
    private void programa()
    {
        EnterRule_programa();
        EnterRule("programa", 1);
        TraceIn("programa", 1);
        try
        {
            DebugEnterRule(GrammarFileName, "programa");
            DebugLocation(14, 35);
            try
            {
                // C:\\Users\\dany_\\Desktop\\SIC_gramatica.g:14:9: ( inicio ( proposicion )* final )
                DebugEnterAlt(1);
                // C:\\Users\\dany_\\Desktop\\SIC_gramatica.g:14:11: inicio ( proposicion )* final
                {
                    DebugLocation(14, 11);
                    PushFollow(Follow._inicio_in_programa50);
                    inicio();
                    PopFollow();

                    DebugLocation(14, 18);
                    // C:\\Users\\dany_\\Desktop\\SIC_gramatica.g:14:18: ( proposicion )*
                    try
                    {
                        DebugEnterSubRule(1);
                        while (true)
                        {
                            int alt1 = 2;
                            try
                            {
                                DebugEnterDecision(1, decisionCanBacktrack[1]);
                                int LA1_0 = input.LA(1);

                                if (((LA1_0 >= NOMBRE && LA1_0 <= OPERACION) || LA1_0 == TIPODIRECTIVA))
                                {
                                    alt1 = 1;
                                }


                            }
                            finally { DebugExitDecision(1); }
                            switch (alt1)
                            {
                                case 1:
                                    DebugEnterAlt(1);
                                    // C:\\Users\\dany_\\Desktop\\SIC_gramatica.g:14:18: proposicion
                                    {
                                        DebugLocation(14, 18);
                                        PushFollow(Follow._proposicion_in_programa52);
                                        proposicion();
                                        PopFollow();


                                    }
                                    break;

                                default:
                                    goto loop1;
                            }
                        }

                    loop1:
                        ;

                    }
                    finally { DebugExitSubRule(1); }

                    DebugLocation(14, 31);
                    PushFollow(Follow._final_in_programa55);
                    final();
                    PopFollow();


                }

            }
            catch (RecognitionException re)
            {
                ReportError(re);
                Recover(input, re);
            }
            finally
            {
                TraceOut("programa", 1);
                LeaveRule("programa", 1);
                LeaveRule_programa();
            }
            DebugLocation(14, 35);
        }
        finally { DebugExitRule(GrammarFileName, "programa"); }
        return;

    }
    // $ANTLR end "programa"


    [Conditional("ANTLR_TRACE")]
    protected virtual void EnterRule_inicio() { }
    [Conditional("ANTLR_TRACE")]
    protected virtual void LeaveRule_inicio() { }

    // $ANTLR start "inicio"
    // C:\\Users\\dany_\\Desktop\\SIC_gramatica.g:15:1: inicio : NOMBRE START DIR '\\n' ;
    [GrammarRule("inicio")]
    private void inicio()
    {
        EnterRule_inicio();
        EnterRule("inicio", 2);
        TraceIn("inicio", 2);
        try
        {
            DebugEnterRule(GrammarFileName, "inicio");
            DebugLocation(15, 29);
            try
            {
                // C:\\Users\\dany_\\Desktop\\SIC_gramatica.g:15:8: ( NOMBRE START DIR '\\n' )
                DebugEnterAlt(1);
                // C:\\Users\\dany_\\Desktop\\SIC_gramatica.g:15:10: NOMBRE START DIR '\\n'
                {
                    DebugLocation(15, 10);
                    Match(input, NOMBRE, Follow._NOMBRE_in_inicio62);
                    DebugLocation(15, 17);
                    Match(input, START, Follow._START_in_inicio64);
                    DebugLocation(15, 23);
                    Match(input, DIR, Follow._DIR_in_inicio66);
                    DebugLocation(15, 26);
                    Match(input, 13, Follow._13_in_inicio67);

                }

            }
            catch (RecognitionException re)
            {
                ReportError(re);
                Recover(input, re);
            }
            finally
            {
                TraceOut("inicio", 2);
                LeaveRule("inicio", 2);
                LeaveRule_inicio();
            }
            DebugLocation(15, 29);
        }
        finally { DebugExitRule(GrammarFileName, "inicio"); }
        return;

    }
    // $ANTLR end "inicio"


    [Conditional("ANTLR_TRACE")]
    protected virtual void EnterRule_proposicion() { }
    [Conditional("ANTLR_TRACE")]
    protected virtual void LeaveRule_proposicion() { }

    // $ANTLR start "proposicion"
    // C:\\Users\\dany_\\Desktop\\SIC_gramatica.g:16:1: proposicion : ( instruccion | directiva ) ( '\\n' )? ;
    [GrammarRule("proposicion")]
    private void proposicion()
    {
        EnterRule_proposicion();
        EnterRule("proposicion", 3);
        TraceIn("proposicion", 3);
        try
        {
            DebugEnterRule(GrammarFileName, "proposicion");
            DebugLocation(16, 1);
            try
            {
                // C:\\Users\\dany_\\Desktop\\SIC_gramatica.g:17:2: ( ( instruccion | directiva ) ( '\\n' )? )
                DebugEnterAlt(1);
                // C:\\Users\\dany_\\Desktop\\SIC_gramatica.g:17:4: ( instruccion | directiva ) ( '\\n' )?
                {
                    DebugLocation(17, 4);
                    // C:\\Users\\dany_\\Desktop\\SIC_gramatica.g:17:4: ( instruccion | directiva )
                    int alt2 = 2;
                    try
                    {
                        DebugEnterSubRule(2);
                        try
                        {
                            DebugEnterDecision(2, decisionCanBacktrack[2]);
                            switch (input.LA(1))
                            {
                                case NOMBRE:
                                    {
                                        int LA2_1 = input.LA(2);

                                        if ((LA2_1 == OPERACION))
                                        {
                                            alt2 = 1;
                                        }
                                        else if ((LA2_1 == TIPODIRECTIVA))
                                        {
                                            alt2 = 2;
                                        }
                                        else
                                        {
                                            NoViableAltException nvae = new NoViableAltException("", 2, 1, input);
                                            DebugRecognitionException(nvae);
                                            throw nvae;
                                        }
                                    }
                                    break;
                                case OPERACION:
                                    {
                                        alt2 = 1;
                                    }
                                    break;
                                case TIPODIRECTIVA:
                                    {
                                        alt2 = 2;
                                    }
                                    break;
                                default:
                                    {
                                        NoViableAltException nvae = new NoViableAltException("", 2, 0, input);
                                        DebugRecognitionException(nvae);
                                        throw nvae;
                                    }
                            }

                        }
                        finally { DebugExitDecision(2); }
                        switch (alt2)
                        {
                            case 1:
                                DebugEnterAlt(1);
                                // C:\\Users\\dany_\\Desktop\\SIC_gramatica.g:17:5: instruccion
                                {
                                    DebugLocation(17, 5);
                                    PushFollow(Follow._instruccion_in_proposicion76);
                                    instruccion();
                                    PopFollow();


                                }
                                break;
                            case 2:
                                DebugEnterAlt(2);
                                // C:\\Users\\dany_\\Desktop\\SIC_gramatica.g:17:17: directiva
                                {
                                    DebugLocation(17, 17);
                                    PushFollow(Follow._directiva_in_proposicion78);
                                    directiva();
                                    PopFollow();


                                }
                                break;

                        }
                    }
                    finally { DebugExitSubRule(2); }

                    DebugLocation(17, 27);
                    // C:\\Users\\dany_\\Desktop\\SIC_gramatica.g:17:27: ( '\\n' )?
                    int alt3 = 2;
                    try
                    {
                        DebugEnterSubRule(3);
                        try
                        {
                            DebugEnterDecision(3, decisionCanBacktrack[3]);
                            int LA3_0 = input.LA(1);

                            if ((LA3_0 == 13))
                            {
                                alt3 = 1;
                            }
                        }
                        finally { DebugExitDecision(3); }
                        switch (alt3)
                        {
                            case 1:
                                DebugEnterAlt(1);
                                // C:\\Users\\dany_\\Desktop\\SIC_gramatica.g:17:27: '\\n'
                                {
                                    DebugLocation(17, 27);
                                    Match(input, 13, Follow._13_in_proposicion80);

                                }
                                break;

                        }
                    }
                    finally { DebugExitSubRule(3); }


                }

            }
            catch (RecognitionException re)
            {
                ReportError(re);
                Recover(input, re);
            }
            finally
            {
                TraceOut("proposicion", 3);
                LeaveRule("proposicion", 3);
                LeaveRule_proposicion();
            }
            DebugLocation(18, 1);
        }
        finally { DebugExitRule(GrammarFileName, "proposicion"); }
        return;

    }
    // $ANTLR end "proposicion"


    [Conditional("ANTLR_TRACE")]
    protected virtual void EnterRule_final() { }
    [Conditional("ANTLR_TRACE")]
    protected virtual void LeaveRule_final() { }

    // $ANTLR start "final"
    // C:\\Users\\dany_\\Desktop\\SIC_gramatica.g:19:1: final : 'END' ( NOMBRE )? ( '\\n' )? ;
    [GrammarRule("final")]
    private void final()
    {
        EnterRule_final();
        EnterRule("final", 4);
        TraceIn("final", 4);
        try
        {
            DebugEnterRule(GrammarFileName, "final");
            DebugLocation(19, 27);
            try
            {
                // C:\\Users\\dany_\\Desktop\\SIC_gramatica.g:19:7: ( 'END' ( NOMBRE )? ( '\\n' )? )
                DebugEnterAlt(1);
                // C:\\Users\\dany_\\Desktop\\SIC_gramatica.g:19:9: 'END' ( NOMBRE )? ( '\\n' )?
                {
                    DebugLocation(19, 9);
                    Match(input, 12, Follow._12_in_final90);
                    DebugLocation(19, 15);
                    // C:\\Users\\dany_\\Desktop\\SIC_gramatica.g:19:15: ( NOMBRE )?
                    int alt4 = 2;
                    try
                    {
                        DebugEnterSubRule(4);
                        try
                        {
                            DebugEnterDecision(4, decisionCanBacktrack[4]);
                            int LA4_0 = input.LA(1);

                            if ((LA4_0 == NOMBRE))
                            {
                                alt4 = 1;
                            }
                        }
                        finally { DebugExitDecision(4); }
                        switch (alt4)
                        {
                            case 1:
                                DebugEnterAlt(1);
                                // C:\\Users\\dany_\\Desktop\\SIC_gramatica.g:19:15: NOMBRE
                                {
                                    DebugLocation(19, 15);
                                    Match(input, NOMBRE, Follow._NOMBRE_in_final92);

                                }
                                break;

                        }
                    }
                    finally { DebugExitSubRule(4); }

                    DebugLocation(19, 23);
                    // C:\\Users\\dany_\\Desktop\\SIC_gramatica.g:19:23: ( '\\n' )?
                    int alt5 = 2;
                    try
                    {
                        DebugEnterSubRule(5);
                        try
                        {
                            DebugEnterDecision(5, decisionCanBacktrack[5]);
                            int LA5_0 = input.LA(1);

                            if ((LA5_0 == 13))
                            {
                                alt5 = 1;
                            }
                        }
                        finally { DebugExitDecision(5); }
                        switch (alt5)
                        {
                            case 1:
                                DebugEnterAlt(1);
                                // C:\\Users\\dany_\\Desktop\\SIC_gramatica.g:19:23: '\\n'
                                {
                                    DebugLocation(19, 23);
                                    Match(input, 13, Follow._13_in_final95);

                                }
                                break;

                        }
                    }
                    finally { DebugExitSubRule(5); }


                }

            }
            catch (RecognitionException re)
            {
                ReportError(re);
                Recover(input, re);
            }
            finally
            {
                TraceOut("final", 4);
                LeaveRule("final", 4);
                LeaveRule_final();
            }
            DebugLocation(19, 27);
        }
        finally { DebugExitRule(GrammarFileName, "final"); }
        return;

    }
    // $ANTLR end "final"


    [Conditional("ANTLR_TRACE")]
    protected virtual void EnterRule_instruccion() { }
    [Conditional("ANTLR_TRACE")]
    protected virtual void LeaveRule_instruccion() { }

    // $ANTLR start "instruccion"
    // C:\\Users\\dany_\\Desktop\\SIC_gramatica.g:20:1: instruccion : ( NOMBRE )? OPERACION ( NOMBRE )? ( ',X' )? '\\n' ;
    [GrammarRule("instruccion")]
    private void instruccion()
    {
        EnterRule_instruccion();
        EnterRule("instruccion", 5);
        TraceIn("instruccion", 5);
        try
        {
            DebugEnterRule(GrammarFileName, "instruccion");
            DebugLocation(20, 1);
            try
            {
                // C:\\Users\\dany_\\Desktop\\SIC_gramatica.g:21:2: ( ( NOMBRE )? OPERACION ( NOMBRE )? ( ',X' )? '\\n' )
                DebugEnterAlt(1);
                // C:\\Users\\dany_\\Desktop\\SIC_gramatica.g:21:4: ( NOMBRE )? OPERACION ( NOMBRE )? ( ',X' )? '\\n'
                {
                    DebugLocation(21, 4);
                    // C:\\Users\\dany_\\Desktop\\SIC_gramatica.g:21:4: ( NOMBRE )?
                    int alt6 = 2;
                    try
                    {
                        DebugEnterSubRule(6);
                        try
                        {
                            DebugEnterDecision(6, decisionCanBacktrack[6]);
                            int LA6_0 = input.LA(1);

                            if ((LA6_0 == NOMBRE))
                            {
                                alt6 = 1;
                            }
                        }
                        finally { DebugExitDecision(6); }
                        switch (alt6)
                        {
                            case 1:
                                DebugEnterAlt(1);
                                // C:\\Users\\dany_\\Desktop\\SIC_gramatica.g:21:4: NOMBRE
                                {
                                    DebugLocation(21, 4);
                                    Match(input, NOMBRE, Follow._NOMBRE_in_instruccion104);

                                }
                                break;

                        }
                    }
                    finally { DebugExitSubRule(6); }

                    DebugLocation(21, 12);
                    Match(input, OPERACION, Follow._OPERACION_in_instruccion107);
                    DebugLocation(21, 22);
                    // C:\\Users\\dany_\\Desktop\\SIC_gramatica.g:21:22: ( NOMBRE )?
                    int alt7 = 2;
                    try
                    {
                        DebugEnterSubRule(7);
                        try
                        {
                            DebugEnterDecision(7, decisionCanBacktrack[7]);
                            int LA7_0 = input.LA(1);

                            if ((LA7_0 == NOMBRE))
                            {
                                alt7 = 1;
                            }
                        }
                        finally { DebugExitDecision(7); }
                        switch (alt7)
                        {
                            case 1:
                                DebugEnterAlt(1);
                                // C:\\Users\\dany_\\Desktop\\SIC_gramatica.g:21:22: NOMBRE
                                {
                                    DebugLocation(21, 22);
                                    Match(input, NOMBRE, Follow._NOMBRE_in_instruccion109);

                                }
                                break;

                        }
                    }
                    finally { DebugExitSubRule(7); }

                    DebugLocation(21, 29);
                    // C:\\Users\\dany_\\Desktop\\SIC_gramatica.g:21:29: ( ',X' )?
                    int alt8 = 2;
                    try
                    {
                        DebugEnterSubRule(8);
                        try
                        {
                            DebugEnterDecision(8, decisionCanBacktrack[8]);
                            int LA8_0 = input.LA(1);

                            if ((LA8_0 == 11))
                            {
                                alt8 = 1;
                            }
                        }
                        finally { DebugExitDecision(8); }
                        switch (alt8)
                        {
                            case 1:
                                DebugEnterAlt(1);
                                // C:\\Users\\dany_\\Desktop\\SIC_gramatica.g:21:29: ',X'
                                {
                                    DebugLocation(21, 29);
                                    Match(input, 11, Follow._11_in_instruccion111);

                                }
                                break;

                        }
                    }
                    finally { DebugExitSubRule(8); }

                    DebugLocation(21, 35);
                    Match(input, 13, Follow._13_in_instruccion114);

                }

            }
            catch (RecognitionException re)
            {
                ReportError(re);
                Recover(input, re);
            }
            finally
            {
                TraceOut("instruccion", 5);
                LeaveRule("instruccion", 5);
                LeaveRule_instruccion();
            }
            DebugLocation(22, 1);
        }
        finally { DebugExitRule(GrammarFileName, "instruccion"); }
        return;

    }
    // $ANTLR end "instruccion"


    [Conditional("ANTLR_TRACE")]
    protected virtual void EnterRule_directiva() { }
    [Conditional("ANTLR_TRACE")]
    protected virtual void LeaveRule_directiva() { }

    // $ANTLR start "directiva"
    // C:\\Users\\dany_\\Desktop\\SIC_gramatica.g:23:1: directiva : ( NOMBRE )? TIPODIRECTIVA ( OPERACIONDIRECTIVA | INT ) ;
    [GrammarRule("directiva")]
    private void directiva()
    {
        EnterRule_directiva();
        EnterRule("directiva", 6);
        TraceIn("directiva", 6);
        try
        {
            DebugEnterRule(GrammarFileName, "directiva");
            DebugLocation(23, 1);
            try
            {
                // C:\\Users\\dany_\\Desktop\\SIC_gramatica.g:24:2: ( ( NOMBRE )? TIPODIRECTIVA ( OPERACIONDIRECTIVA | INT ) )
                DebugEnterAlt(1);
                // C:\\Users\\dany_\\Desktop\\SIC_gramatica.g:24:4: ( NOMBRE )? TIPODIRECTIVA ( OPERACIONDIRECTIVA | INT )
                {
                    DebugLocation(24, 4);
                    // C:\\Users\\dany_\\Desktop\\SIC_gramatica.g:24:4: ( NOMBRE )?
                    int alt9 = 2;
                    try
                    {
                        DebugEnterSubRule(9);
                        try
                        {
                            DebugEnterDecision(9, decisionCanBacktrack[9]);
                            int LA9_0 = input.LA(1);

                            if ((LA9_0 == NOMBRE))
                            {
                                alt9 = 1;
                            }
                        }
                        finally { DebugExitDecision(9); }
                        switch (alt9)
                        {
                            case 1:
                                DebugEnterAlt(1);
                                // C:\\Users\\dany_\\Desktop\\SIC_gramatica.g:24:4: NOMBRE
                                {
                                    DebugLocation(24, 4);
                                    Match(input, NOMBRE, Follow._NOMBRE_in_directiva124);

                                }
                                break;

                        }
                    }
                    finally { DebugExitSubRule(9); }

                    DebugLocation(24, 12);
                    Match(input, TIPODIRECTIVA, Follow._TIPODIRECTIVA_in_directiva127);
                    DebugLocation(24, 26);
                    if (input.LA(1) == INT || input.LA(1) == OPERACIONDIRECTIVA)
                    {
                        input.Consume();
                        state.errorRecovery = false;
                    }
                    else
                    {
                        MismatchedSetException mse = new MismatchedSetException(null, input);
                        DebugRecognitionException(mse);
                        throw mse;
                    }


                }

            }
            catch (RecognitionException re)
            {
                ReportError(re);
                Recover(input, re);
            }
            finally
            {
                TraceOut("directiva", 6);
                LeaveRule("directiva", 6);
                LeaveRule_directiva();
            }
            DebugLocation(25, 1);
        }
        finally { DebugExitRule(GrammarFileName, "directiva"); }
        return;

    }
    // $ANTLR end "directiva"
    #endregion Rules


    #region Follow sets
    private static class Follow
    {
        public static readonly BitSet _inicio_in_programa50 = new BitSet(new ulong[] { 0x14C0UL });
        public static readonly BitSet _proposicion_in_programa52 = new BitSet(new ulong[] { 0x14C0UL });
        public static readonly BitSet _final_in_programa55 = new BitSet(new ulong[] { 0x2UL });
        public static readonly BitSet _NOMBRE_in_inicio62 = new BitSet(new ulong[] { 0x200UL });
        public static readonly BitSet _START_in_inicio64 = new BitSet(new ulong[] { 0x10UL });
        public static readonly BitSet _DIR_in_inicio66 = new BitSet(new ulong[] { 0x2000UL });
        public static readonly BitSet _13_in_inicio67 = new BitSet(new ulong[] { 0x2UL });
        public static readonly BitSet _instruccion_in_proposicion76 = new BitSet(new ulong[] { 0x2002UL });
        public static readonly BitSet _directiva_in_proposicion78 = new BitSet(new ulong[] { 0x2002UL });
        public static readonly BitSet _13_in_proposicion80 = new BitSet(new ulong[] { 0x2UL });
        public static readonly BitSet _12_in_final90 = new BitSet(new ulong[] { 0x2042UL });
        public static readonly BitSet _NOMBRE_in_final92 = new BitSet(new ulong[] { 0x2002UL });
        public static readonly BitSet _13_in_final95 = new BitSet(new ulong[] { 0x2UL });
        public static readonly BitSet _NOMBRE_in_instruccion104 = new BitSet(new ulong[] { 0x80UL });
        public static readonly BitSet _OPERACION_in_instruccion107 = new BitSet(new ulong[] { 0x2840UL });
        public static readonly BitSet _NOMBRE_in_instruccion109 = new BitSet(new ulong[] { 0x2800UL });
        public static readonly BitSet _11_in_instruccion111 = new BitSet(new ulong[] { 0x2000UL });
        public static readonly BitSet _13_in_instruccion114 = new BitSet(new ulong[] { 0x2UL });
        public static readonly BitSet _NOMBRE_in_directiva124 = new BitSet(new ulong[] { 0x400UL });
        public static readonly BitSet _TIPODIRECTIVA_in_directiva127 = new BitSet(new ulong[] { 0x120UL });
        public static readonly BitSet _set_in_directiva129 = new BitSet(new ulong[] { 0x2UL });
    }
    #endregion Follow sets
}
