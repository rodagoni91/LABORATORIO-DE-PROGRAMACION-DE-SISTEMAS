//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     ANTLR Version: 3.4
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

// $ANTLR 3.4 C:\\Users\\dany_\\Desktop\\final1.g 2020-10-16 11:36:41

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
public partial class final1Lexer : Antlr.Runtime.Lexer
{
	public const int EOF=-1;
	public const int T__11=11;
	public const int T__12=12;
	public const int T__13=13;
	public const int DIR=4;
	public const int INT=5;
	public const int NOMBRE=6;
	public const int OPERACION=7;
	public const int OPERACIONDIRECTIVA=8;
	public const int START=9;
	public const int TIPODIRECTIVA=10;

    // delegates
    // delegators

	public final1Lexer()
	{
		OnCreated();
	}

	public final1Lexer(ICharStream input )
		: this(input, new RecognizerSharedState())
	{
	}

	public final1Lexer(ICharStream input, RecognizerSharedState state)
		: base(input, state)
	{

		OnCreated();
	}
	public override string GrammarFileName { get { return "C:\\Users\\dany_\\Desktop\\final1.g"; } }

	private static readonly bool[] decisionCanBacktrack = new bool[0];

	[Conditional("ANTLR_TRACE")]
	protected virtual void OnCreated() {}
	[Conditional("ANTLR_TRACE")]
	protected virtual void EnterRule(string ruleName, int ruleIndex) {}
	[Conditional("ANTLR_TRACE")]
	protected virtual void LeaveRule(string ruleName, int ruleIndex) {}

    [Conditional("ANTLR_TRACE")]
    protected virtual void EnterRule_T__11() {}
    [Conditional("ANTLR_TRACE")]
    protected virtual void LeaveRule_T__11() {}

    // $ANTLR start "T__11"
    [GrammarRule("T__11")]
    private void mT__11()
    {
    	EnterRule_T__11();
    	EnterRule("T__11", 1);
    	TraceIn("T__11", 1);
    		try
    		{
    		int _type = T__11;
    		int _channel = DefaultTokenChannel;
    		// C:\\Users\\dany_\\Desktop\\final1.g:7:7: ( ',X' )
    		DebugEnterAlt(1);
    		// C:\\Users\\dany_\\Desktop\\final1.g:7:9: ',X'
    		{
    		DebugLocation(7, 9);
    		Match(",X"); 


    		}

    		state.type = _type;
    		state.channel = _channel;
    	}
    	finally
    	{
    		TraceOut("T__11", 1);
    		LeaveRule("T__11", 1);
    		LeaveRule_T__11();
        }
    }
    // $ANTLR end "T__11"

    [Conditional("ANTLR_TRACE")]
    protected virtual void EnterRule_T__12() {}
    [Conditional("ANTLR_TRACE")]
    protected virtual void LeaveRule_T__12() {}

    // $ANTLR start "T__12"
    [GrammarRule("T__12")]
    private void mT__12()
    {
    	EnterRule_T__12();
    	EnterRule("T__12", 2);
    	TraceIn("T__12", 2);
    		try
    		{
    		int _type = T__12;
    		int _channel = DefaultTokenChannel;
    		// C:\\Users\\dany_\\Desktop\\final1.g:8:7: ( 'END' )
    		DebugEnterAlt(1);
    		// C:\\Users\\dany_\\Desktop\\final1.g:8:9: 'END'
    		{
    		DebugLocation(8, 9);
    		Match("END"); 


    		}

    		state.type = _type;
    		state.channel = _channel;
    	}
    	finally
    	{
    		TraceOut("T__12", 2);
    		LeaveRule("T__12", 2);
    		LeaveRule_T__12();
        }
    }
    // $ANTLR end "T__12"

    [Conditional("ANTLR_TRACE")]
    protected virtual void EnterRule_T__13() {}
    [Conditional("ANTLR_TRACE")]
    protected virtual void LeaveRule_T__13() {}

    // $ANTLR start "T__13"
    [GrammarRule("T__13")]
    private void mT__13()
    {
    	EnterRule_T__13();
    	EnterRule("T__13", 3);
    	TraceIn("T__13", 3);
    		try
    		{
    		int _type = T__13;
    		int _channel = DefaultTokenChannel;
    		// C:\\Users\\dany_\\Desktop\\final1.g:9:7: ( '\\n' )
    		DebugEnterAlt(1);
    		// C:\\Users\\dany_\\Desktop\\final1.g:9:9: '\\n'
    		{
    		DebugLocation(9, 9);
    		Match('\n'); 

    		}

    		state.type = _type;
    		state.channel = _channel;
    	}
    	finally
    	{
    		TraceOut("T__13", 3);
    		LeaveRule("T__13", 3);
    		LeaveRule_T__13();
        }
    }
    // $ANTLR end "T__13"

    [Conditional("ANTLR_TRACE")]
    protected virtual void EnterRule_OPERACION() {}
    [Conditional("ANTLR_TRACE")]
    protected virtual void LeaveRule_OPERACION() {}

    // $ANTLR start "OPERACION"
    [GrammarRule("OPERACION")]
    private void mOPERACION()
    {
    	EnterRule_OPERACION();
    	EnterRule("OPERACION", 4);
    	TraceIn("OPERACION", 4);
    		try
    		{
    		int _type = OPERACION;
    		int _channel = DefaultTokenChannel;
    		// C:\\Users\\dany_\\Desktop\\final1.g:26:2: ( 'ADD' | 'AND' | 'COMP' | 'DIV' | 'J' | 'JEQ' | 'JGT' | 'JLT' | 'JSUB' | 'LDA' | 'LDCG' | 'LDL' | 'LDX' | 'MUL' | 'OR' | 'RD' | 'RSUB' | 'STA' | 'STCH' | 'STL' | 'STSW' | 'STX' | 'SUB' | 'TD' | 'TIX' | 'WD' )
    		int alt1=26;
    		try { DebugEnterDecision(1, decisionCanBacktrack[1]);
    		switch (input.LA(1))
    		{
    		case 'A':
    			{
    			int LA1_1 = input.LA(2);

    			if ((LA1_1=='D'))
    			{
    				alt1 = 1;
    			}
    			else if ((LA1_1=='N'))
    			{
    				alt1 = 2;
    			}
    			else
    			{
    				NoViableAltException nvae = new NoViableAltException("", 1, 1, input);
    				DebugRecognitionException(nvae);
    				throw nvae;
    			}
    			}
    			break;
    		case 'C':
    			{
    			alt1 = 3;
    			}
    			break;
    		case 'D':
    			{
    			alt1 = 4;
    			}
    			break;
    		case 'J':
    			{
    			switch (input.LA(2))
    			{
    			case 'E':
    				{
    				alt1 = 6;
    				}
    				break;
    			case 'G':
    				{
    				alt1 = 7;
    				}
    				break;
    			case 'L':
    				{
    				alt1 = 8;
    				}
    				break;
    			case 'S':
    				{
    				alt1 = 9;
    				}
    				break;
    			default:
    				alt1=5;
    				break;

    			}

    			}
    			break;
    		case 'L':
    			{
    			int LA1_5 = input.LA(2);

    			if ((LA1_5=='D'))
    			{
    				switch (input.LA(3))
    				{
    				case 'A':
    					{
    					alt1 = 10;
    					}
    					break;
    				case 'C':
    					{
    					alt1 = 11;
    					}
    					break;
    				case 'L':
    					{
    					alt1 = 12;
    					}
    					break;
    				case 'X':
    					{
    					alt1 = 13;
    					}
    					break;
    				default:
    					{
    						NoViableAltException nvae = new NoViableAltException("", 1, 19, input);
    						DebugRecognitionException(nvae);
    						throw nvae;
    					}
    				}

    			}
    			else
    			{
    				NoViableAltException nvae = new NoViableAltException("", 1, 5, input);
    				DebugRecognitionException(nvae);
    				throw nvae;
    			}
    			}
    			break;
    		case 'M':
    			{
    			alt1 = 14;
    			}
    			break;
    		case 'O':
    			{
    			alt1 = 15;
    			}
    			break;
    		case 'R':
    			{
    			int LA1_8 = input.LA(2);

    			if ((LA1_8=='D'))
    			{
    				alt1 = 16;
    			}
    			else if ((LA1_8=='S'))
    			{
    				alt1 = 17;
    			}
    			else
    			{
    				NoViableAltException nvae = new NoViableAltException("", 1, 8, input);
    				DebugRecognitionException(nvae);
    				throw nvae;
    			}
    			}
    			break;
    		case 'S':
    			{
    			int LA1_9 = input.LA(2);

    			if ((LA1_9=='T'))
    			{
    				switch (input.LA(3))
    				{
    				case 'A':
    					{
    					alt1 = 18;
    					}
    					break;
    				case 'C':
    					{
    					alt1 = 19;
    					}
    					break;
    				case 'L':
    					{
    					alt1 = 20;
    					}
    					break;
    				case 'S':
    					{
    					alt1 = 21;
    					}
    					break;
    				case 'X':
    					{
    					alt1 = 22;
    					}
    					break;
    				default:
    					{
    						NoViableAltException nvae = new NoViableAltException("", 1, 22, input);
    						DebugRecognitionException(nvae);
    						throw nvae;
    					}
    				}

    			}
    			else if ((LA1_9=='U'))
    			{
    				alt1 = 23;
    			}
    			else
    			{
    				NoViableAltException nvae = new NoViableAltException("", 1, 9, input);
    				DebugRecognitionException(nvae);
    				throw nvae;
    			}
    			}
    			break;
    		case 'T':
    			{
    			int LA1_10 = input.LA(2);

    			if ((LA1_10=='D'))
    			{
    				alt1 = 24;
    			}
    			else if ((LA1_10=='I'))
    			{
    				alt1 = 25;
    			}
    			else
    			{
    				NoViableAltException nvae = new NoViableAltException("", 1, 10, input);
    				DebugRecognitionException(nvae);
    				throw nvae;
    			}
    			}
    			break;
    		case 'W':
    			{
    			alt1 = 26;
    			}
    			break;
    		default:
    			{
    				NoViableAltException nvae = new NoViableAltException("", 1, 0, input);
    				DebugRecognitionException(nvae);
    				throw nvae;
    			}
    		}

    		} finally { DebugExitDecision(1); }
    		switch (alt1)
    		{
    		case 1:
    			DebugEnterAlt(1);
    			// C:\\Users\\dany_\\Desktop\\final1.g:26:4: 'ADD'
    			{
    			DebugLocation(26, 4);
    			Match("ADD"); 


    			}
    			break;
    		case 2:
    			DebugEnterAlt(2);
    			// C:\\Users\\dany_\\Desktop\\final1.g:26:12: 'AND'
    			{
    			DebugLocation(26, 12);
    			Match("AND"); 


    			}
    			break;
    		case 3:
    			DebugEnterAlt(3);
    			// C:\\Users\\dany_\\Desktop\\final1.g:26:20: 'COMP'
    			{
    			DebugLocation(26, 20);
    			Match("COMP"); 


    			}
    			break;
    		case 4:
    			DebugEnterAlt(4);
    			// C:\\Users\\dany_\\Desktop\\final1.g:26:29: 'DIV'
    			{
    			DebugLocation(26, 29);
    			Match("DIV"); 


    			}
    			break;
    		case 5:
    			DebugEnterAlt(5);
    			// C:\\Users\\dany_\\Desktop\\final1.g:26:37: 'J'
    			{
    			DebugLocation(26, 37);
    			Match('J'); 

    			}
    			break;
    		case 6:
    			DebugEnterAlt(6);
    			// C:\\Users\\dany_\\Desktop\\final1.g:26:43: 'JEQ'
    			{
    			DebugLocation(26, 43);
    			Match("JEQ"); 


    			}
    			break;
    		case 7:
    			DebugEnterAlt(7);
    			// C:\\Users\\dany_\\Desktop\\final1.g:26:51: 'JGT'
    			{
    			DebugLocation(26, 51);
    			Match("JGT"); 


    			}
    			break;
    		case 8:
    			DebugEnterAlt(8);
    			// C:\\Users\\dany_\\Desktop\\final1.g:26:59: 'JLT'
    			{
    			DebugLocation(26, 59);
    			Match("JLT"); 


    			}
    			break;
    		case 9:
    			DebugEnterAlt(9);
    			// C:\\Users\\dany_\\Desktop\\final1.g:26:67: 'JSUB'
    			{
    			DebugLocation(26, 67);
    			Match("JSUB"); 


    			}
    			break;
    		case 10:
    			DebugEnterAlt(10);
    			// C:\\Users\\dany_\\Desktop\\final1.g:26:76: 'LDA'
    			{
    			DebugLocation(26, 76);
    			Match("LDA"); 


    			}
    			break;
    		case 11:
    			DebugEnterAlt(11);
    			// C:\\Users\\dany_\\Desktop\\final1.g:26:84: 'LDCG'
    			{
    			DebugLocation(26, 84);
    			Match("LDCG"); 


    			}
    			break;
    		case 12:
    			DebugEnterAlt(12);
    			// C:\\Users\\dany_\\Desktop\\final1.g:26:93: 'LDL'
    			{
    			DebugLocation(26, 93);
    			Match("LDL"); 


    			}
    			break;
    		case 13:
    			DebugEnterAlt(13);
    			// C:\\Users\\dany_\\Desktop\\final1.g:26:101: 'LDX'
    			{
    			DebugLocation(26, 101);
    			Match("LDX"); 


    			}
    			break;
    		case 14:
    			DebugEnterAlt(14);
    			// C:\\Users\\dany_\\Desktop\\final1.g:26:109: 'MUL'
    			{
    			DebugLocation(26, 109);
    			Match("MUL"); 


    			}
    			break;
    		case 15:
    			DebugEnterAlt(15);
    			// C:\\Users\\dany_\\Desktop\\final1.g:26:117: 'OR'
    			{
    			DebugLocation(26, 117);
    			Match("OR"); 


    			}
    			break;
    		case 16:
    			DebugEnterAlt(16);
    			// C:\\Users\\dany_\\Desktop\\final1.g:26:124: 'RD'
    			{
    			DebugLocation(26, 124);
    			Match("RD"); 


    			}
    			break;
    		case 17:
    			DebugEnterAlt(17);
    			// C:\\Users\\dany_\\Desktop\\final1.g:26:131: 'RSUB'
    			{
    			DebugLocation(26, 131);
    			Match("RSUB"); 


    			}
    			break;
    		case 18:
    			DebugEnterAlt(18);
    			// C:\\Users\\dany_\\Desktop\\final1.g:26:140: 'STA'
    			{
    			DebugLocation(26, 140);
    			Match("STA"); 


    			}
    			break;
    		case 19:
    			DebugEnterAlt(19);
    			// C:\\Users\\dany_\\Desktop\\final1.g:26:148: 'STCH'
    			{
    			DebugLocation(26, 148);
    			Match("STCH"); 


    			}
    			break;
    		case 20:
    			DebugEnterAlt(20);
    			// C:\\Users\\dany_\\Desktop\\final1.g:26:157: 'STL'
    			{
    			DebugLocation(26, 157);
    			Match("STL"); 


    			}
    			break;
    		case 21:
    			DebugEnterAlt(21);
    			// C:\\Users\\dany_\\Desktop\\final1.g:26:165: 'STSW'
    			{
    			DebugLocation(26, 165);
    			Match("STSW"); 


    			}
    			break;
    		case 22:
    			DebugEnterAlt(22);
    			// C:\\Users\\dany_\\Desktop\\final1.g:26:174: 'STX'
    			{
    			DebugLocation(26, 174);
    			Match("STX"); 


    			}
    			break;
    		case 23:
    			DebugEnterAlt(23);
    			// C:\\Users\\dany_\\Desktop\\final1.g:26:182: 'SUB'
    			{
    			DebugLocation(26, 182);
    			Match("SUB"); 


    			}
    			break;
    		case 24:
    			DebugEnterAlt(24);
    			// C:\\Users\\dany_\\Desktop\\final1.g:26:190: 'TD'
    			{
    			DebugLocation(26, 190);
    			Match("TD"); 


    			}
    			break;
    		case 25:
    			DebugEnterAlt(25);
    			// C:\\Users\\dany_\\Desktop\\final1.g:26:197: 'TIX'
    			{
    			DebugLocation(26, 197);
    			Match("TIX"); 


    			}
    			break;
    		case 26:
    			DebugEnterAlt(26);
    			// C:\\Users\\dany_\\Desktop\\final1.g:26:205: 'WD'
    			{
    			DebugLocation(26, 205);
    			Match("WD"); 


    			}
    			break;

    		}
    		state.type = _type;
    		state.channel = _channel;
    	}
    	finally
    	{
    		TraceOut("OPERACION", 4);
    		LeaveRule("OPERACION", 4);
    		LeaveRule_OPERACION();
        }
    }
    // $ANTLR end "OPERACION"

    [Conditional("ANTLR_TRACE")]
    protected virtual void EnterRule_TIPODIRECTIVA() {}
    [Conditional("ANTLR_TRACE")]
    protected virtual void LeaveRule_TIPODIRECTIVA() {}

    // $ANTLR start "TIPODIRECTIVA"
    [GrammarRule("TIPODIRECTIVA")]
    private void mTIPODIRECTIVA()
    {
    	EnterRule_TIPODIRECTIVA();
    	EnterRule("TIPODIRECTIVA", 5);
    	TraceIn("TIPODIRECTIVA", 5);
    		try
    		{
    		int _type = TIPODIRECTIVA;
    		int _channel = DefaultTokenChannel;
    		// C:\\Users\\dany_\\Desktop\\final1.g:29:2: ( 'BYTE' | 'WORD' | 'RESB' | 'RESW' )
    		int alt2=4;
    		try { DebugEnterDecision(2, decisionCanBacktrack[2]);
    		switch (input.LA(1))
    		{
    		case 'B':
    			{
    			alt2 = 1;
    			}
    			break;
    		case 'W':
    			{
    			alt2 = 2;
    			}
    			break;
    		case 'R':
    			{
    			int LA2_3 = input.LA(2);

    			if ((LA2_3=='E'))
    			{
    				int LA2_4 = input.LA(3);

    				if ((LA2_4=='S'))
    				{
    					int LA2_5 = input.LA(4);

    					if ((LA2_5=='B'))
    					{
    						alt2 = 3;
    					}
    					else if ((LA2_5=='W'))
    					{
    						alt2 = 4;
    					}
    					else
    					{
    						NoViableAltException nvae = new NoViableAltException("", 2, 5, input);
    						DebugRecognitionException(nvae);
    						throw nvae;
    					}
    				}
    				else
    				{
    					NoViableAltException nvae = new NoViableAltException("", 2, 4, input);
    					DebugRecognitionException(nvae);
    					throw nvae;
    				}
    			}
    			else
    			{
    				NoViableAltException nvae = new NoViableAltException("", 2, 3, input);
    				DebugRecognitionException(nvae);
    				throw nvae;
    			}
    			}
    			break;
    		default:
    			{
    				NoViableAltException nvae = new NoViableAltException("", 2, 0, input);
    				DebugRecognitionException(nvae);
    				throw nvae;
    			}
    		}

    		} finally { DebugExitDecision(2); }
    		switch (alt2)
    		{
    		case 1:
    			DebugEnterAlt(1);
    			// C:\\Users\\dany_\\Desktop\\final1.g:29:4: 'BYTE'
    			{
    			DebugLocation(29, 4);
    			Match("BYTE"); 


    			}
    			break;
    		case 2:
    			DebugEnterAlt(2);
    			// C:\\Users\\dany_\\Desktop\\final1.g:29:13: 'WORD'
    			{
    			DebugLocation(29, 13);
    			Match("WORD"); 


    			}
    			break;
    		case 3:
    			DebugEnterAlt(3);
    			// C:\\Users\\dany_\\Desktop\\final1.g:29:22: 'RESB'
    			{
    			DebugLocation(29, 22);
    			Match("RESB"); 


    			}
    			break;
    		case 4:
    			DebugEnterAlt(4);
    			// C:\\Users\\dany_\\Desktop\\final1.g:29:31: 'RESW'
    			{
    			DebugLocation(29, 31);
    			Match("RESW"); 


    			}
    			break;

    		}
    		state.type = _type;
    		state.channel = _channel;
    	}
    	finally
    	{
    		TraceOut("TIPODIRECTIVA", 5);
    		LeaveRule("TIPODIRECTIVA", 5);
    		LeaveRule_TIPODIRECTIVA();
        }
    }
    // $ANTLR end "TIPODIRECTIVA"

    [Conditional("ANTLR_TRACE")]
    protected virtual void EnterRule_OPERACIONDIRECTIVA() {}
    [Conditional("ANTLR_TRACE")]
    protected virtual void LeaveRule_OPERACIONDIRECTIVA() {}

    // $ANTLR start "OPERACIONDIRECTIVA"
    [GrammarRule("OPERACIONDIRECTIVA")]
    private void mOPERACIONDIRECTIVA()
    {
    	EnterRule_OPERACIONDIRECTIVA();
    	EnterRule("OPERACIONDIRECTIVA", 6);
    	TraceIn("OPERACIONDIRECTIVA", 6);
    		try
    		{
    		int _type = OPERACIONDIRECTIVA;
    		int _channel = DefaultTokenChannel;
    		// C:\\Users\\dany_\\Desktop\\final1.g:33:2: ( 'C' '\\'' NOMBRE '\\'' | 'X' '\\'' INT '\\'' )
    		int alt3=2;
    		try { DebugEnterDecision(3, decisionCanBacktrack[3]);
    		int LA3_0 = input.LA(1);

    		if ((LA3_0=='C'))
    		{
    			alt3 = 1;
    		}
    		else if ((LA3_0=='X'))
    		{
    			alt3 = 2;
    		}
    		else
    		{
    			NoViableAltException nvae = new NoViableAltException("", 3, 0, input);
    			DebugRecognitionException(nvae);
    			throw nvae;
    		}
    		} finally { DebugExitDecision(3); }
    		switch (alt3)
    		{
    		case 1:
    			DebugEnterAlt(1);
    			// C:\\Users\\dany_\\Desktop\\final1.g:33:4: 'C' '\\'' NOMBRE '\\''
    			{
    			DebugLocation(33, 4);
    			Match('C'); 
    			DebugLocation(33, 7);
    			Match('\''); 
    			DebugLocation(33, 11);
    			mNOMBRE(); 
    			DebugLocation(33, 17);
    			Match('\''); 

    			}
    			break;
    		case 2:
    			DebugEnterAlt(2);
    			// C:\\Users\\dany_\\Desktop\\final1.g:33:24: 'X' '\\'' INT '\\''
    			{
    			DebugLocation(33, 24);
    			Match('X'); 
    			DebugLocation(33, 27);
    			Match('\''); 
    			DebugLocation(33, 31);
    			mINT(); 
    			DebugLocation(33, 34);
    			Match('\''); 

    			}
    			break;

    		}
    		state.type = _type;
    		state.channel = _channel;
    	}
    	finally
    	{
    		TraceOut("OPERACIONDIRECTIVA", 6);
    		LeaveRule("OPERACIONDIRECTIVA", 6);
    		LeaveRule_OPERACIONDIRECTIVA();
        }
    }
    // $ANTLR end "OPERACIONDIRECTIVA"

    [Conditional("ANTLR_TRACE")]
    protected virtual void EnterRule_START() {}
    [Conditional("ANTLR_TRACE")]
    protected virtual void LeaveRule_START() {}

    // $ANTLR start "START"
    [GrammarRule("START")]
    private void mSTART()
    {
    	EnterRule_START();
    	EnterRule("START", 7);
    	TraceIn("START", 7);
    		try
    		{
    		int _type = START;
    		int _channel = DefaultTokenChannel;
    		// C:\\Users\\dany_\\Desktop\\final1.g:35:7: ( 'START' )
    		DebugEnterAlt(1);
    		// C:\\Users\\dany_\\Desktop\\final1.g:35:9: 'START'
    		{
    		DebugLocation(35, 9);
    		Match("START"); 


    		}

    		state.type = _type;
    		state.channel = _channel;
    	}
    	finally
    	{
    		TraceOut("START", 7);
    		LeaveRule("START", 7);
    		LeaveRule_START();
        }
    }
    // $ANTLR end "START"

    [Conditional("ANTLR_TRACE")]
    protected virtual void EnterRule_INT() {}
    [Conditional("ANTLR_TRACE")]
    protected virtual void LeaveRule_INT() {}

    // $ANTLR start "INT"
    [GrammarRule("INT")]
    private void mINT()
    {
    	EnterRule_INT();
    	EnterRule("INT", 8);
    	TraceIn("INT", 8);
    		try
    		{
    		int _type = INT;
    		int _channel = DefaultTokenChannel;
    		// C:\\Users\\dany_\\Desktop\\final1.g:36:5: ( ( 'A' .. 'F' | '0' .. '9' | 'a' .. 'f' )+ )
    		DebugEnterAlt(1);
    		// C:\\Users\\dany_\\Desktop\\final1.g:36:8: ( 'A' .. 'F' | '0' .. '9' | 'a' .. 'f' )+
    		{
    		DebugLocation(36, 8);
    		// C:\\Users\\dany_\\Desktop\\final1.g:36:8: ( 'A' .. 'F' | '0' .. '9' | 'a' .. 'f' )+
    		int cnt4=0;
    		try { DebugEnterSubRule(4);
    		while (true)
    		{
    			int alt4=2;
    			try { DebugEnterDecision(4, decisionCanBacktrack[4]);
    			int LA4_0 = input.LA(1);

    			if (((LA4_0>='0' && LA4_0<='9')||(LA4_0>='A' && LA4_0<='F')||(LA4_0>='a' && LA4_0<='f')))
    			{
    				alt4 = 1;
    			}


    			} finally { DebugExitDecision(4); }
    			switch (alt4)
    			{
    			case 1:
    				DebugEnterAlt(1);
    				// C:\\Users\\dany_\\Desktop\\final1.g:
    				{
    				DebugLocation(36, 8);
    				input.Consume();


    				}
    				break;

    			default:
    				if (cnt4 >= 1)
    					goto loop4;

    				EarlyExitException eee4 = new EarlyExitException( 4, input );
    				DebugRecognitionException(eee4);
    				throw eee4;
    			}
    			cnt4++;
    		}
    		loop4:
    			;

    		} finally { DebugExitSubRule(4); }


    		}

    		state.type = _type;
    		state.channel = _channel;
    	}
    	finally
    	{
    		TraceOut("INT", 8);
    		LeaveRule("INT", 8);
    		LeaveRule_INT();
        }
    }
    // $ANTLR end "INT"

    [Conditional("ANTLR_TRACE")]
    protected virtual void EnterRule_NOMBRE() {}
    [Conditional("ANTLR_TRACE")]
    protected virtual void LeaveRule_NOMBRE() {}

    // $ANTLR start "NOMBRE"
    [GrammarRule("NOMBRE")]
    private void mNOMBRE()
    {
    	EnterRule_NOMBRE();
    	EnterRule("NOMBRE", 9);
    	TraceIn("NOMBRE", 9);
    		try
    		{
    		int _type = NOMBRE;
    		int _channel = DefaultTokenChannel;
    		// C:\\Users\\dany_\\Desktop\\final1.g:37:8: ( ( 'A' .. 'Z' | 'a' .. 'z' | '_' )+ )
    		DebugEnterAlt(1);
    		// C:\\Users\\dany_\\Desktop\\final1.g:37:10: ( 'A' .. 'Z' | 'a' .. 'z' | '_' )+
    		{
    		DebugLocation(37, 10);
    		// C:\\Users\\dany_\\Desktop\\final1.g:37:10: ( 'A' .. 'Z' | 'a' .. 'z' | '_' )+
    		int cnt5=0;
    		try { DebugEnterSubRule(5);
    		while (true)
    		{
    			int alt5=2;
    			try { DebugEnterDecision(5, decisionCanBacktrack[5]);
    			int LA5_0 = input.LA(1);

    			if (((LA5_0>='A' && LA5_0<='Z')||LA5_0=='_'||(LA5_0>='a' && LA5_0<='z')))
    			{
    				alt5 = 1;
    			}


    			} finally { DebugExitDecision(5); }
    			switch (alt5)
    			{
    			case 1:
    				DebugEnterAlt(1);
    				// C:\\Users\\dany_\\Desktop\\final1.g:
    				{
    				DebugLocation(37, 10);
    				input.Consume();


    				}
    				break;

    			default:
    				if (cnt5 >= 1)
    					goto loop5;

    				EarlyExitException eee5 = new EarlyExitException( 5, input );
    				DebugRecognitionException(eee5);
    				throw eee5;
    			}
    			cnt5++;
    		}
    		loop5:
    			;

    		} finally { DebugExitSubRule(5); }


    		}

    		state.type = _type;
    		state.channel = _channel;
    	}
    	finally
    	{
    		TraceOut("NOMBRE", 9);
    		LeaveRule("NOMBRE", 9);
    		LeaveRule_NOMBRE();
        }
    }
    // $ANTLR end "NOMBRE"

    [Conditional("ANTLR_TRACE")]
    protected virtual void EnterRule_DIR() {}
    [Conditional("ANTLR_TRACE")]
    protected virtual void LeaveRule_DIR() {}

    // $ANTLR start "DIR"
    [GrammarRule("DIR")]
    private void mDIR()
    {
    	EnterRule_DIR();
    	EnterRule("DIR", 10);
    	TraceIn("DIR", 10);
    		try
    		{
    		int _type = DIR;
    		int _channel = DefaultTokenChannel;
    		// C:\\Users\\dany_\\Desktop\\final1.g:38:5: ( INT ( 'H' )? )
    		DebugEnterAlt(1);
    		// C:\\Users\\dany_\\Desktop\\final1.g:38:7: INT ( 'H' )?
    		{
    		DebugLocation(38, 7);
    		mINT(); 
    		DebugLocation(38, 10);
    		// C:\\Users\\dany_\\Desktop\\final1.g:38:10: ( 'H' )?
    		int alt6=2;
    		try { DebugEnterSubRule(6);
    		try { DebugEnterDecision(6, decisionCanBacktrack[6]);
    		int LA6_0 = input.LA(1);

    		if ((LA6_0=='H'))
    		{
    			alt6 = 1;
    		}
    		} finally { DebugExitDecision(6); }
    		switch (alt6)
    		{
    		case 1:
    			DebugEnterAlt(1);
    			// C:\\Users\\dany_\\Desktop\\final1.g:38:10: 'H'
    			{
    			DebugLocation(38, 10);
    			Match('H'); 

    			}
    			break;

    		}
    		} finally { DebugExitSubRule(6); }


    		}

    		state.type = _type;
    		state.channel = _channel;
    	}
    	finally
    	{
    		TraceOut("DIR", 10);
    		LeaveRule("DIR", 10);
    		LeaveRule_DIR();
        }
    }
    // $ANTLR end "DIR"

    public override void mTokens()
    {
    	// C:\\Users\\dany_\\Desktop\\final1.g:1:8: ( T__11 | T__12 | T__13 | OPERACION | TIPODIRECTIVA | OPERACIONDIRECTIVA | START | INT | NOMBRE | DIR )
    	int alt7=10;
    	try { DebugEnterDecision(7, decisionCanBacktrack[7]);
    	try
    	{
    		alt7 = dfa7.Predict(input);
    	}
    	catch (NoViableAltException nvae)
    	{
    		DebugRecognitionException(nvae);
    		throw;
    	}
    	} finally { DebugExitDecision(7); }
    	switch (alt7)
    	{
    	case 1:
    		DebugEnterAlt(1);
    		// C:\\Users\\dany_\\Desktop\\final1.g:1:10: T__11
    		{
    		DebugLocation(1, 10);
    		mT__11(); 

    		}
    		break;
    	case 2:
    		DebugEnterAlt(2);
    		// C:\\Users\\dany_\\Desktop\\final1.g:1:16: T__12
    		{
    		DebugLocation(1, 16);
    		mT__12(); 

    		}
    		break;
    	case 3:
    		DebugEnterAlt(3);
    		// C:\\Users\\dany_\\Desktop\\final1.g:1:22: T__13
    		{
    		DebugLocation(1, 22);
    		mT__13(); 

    		}
    		break;
    	case 4:
    		DebugEnterAlt(4);
    		// C:\\Users\\dany_\\Desktop\\final1.g:1:28: OPERACION
    		{
    		DebugLocation(1, 28);
    		mOPERACION(); 

    		}
    		break;
    	case 5:
    		DebugEnterAlt(5);
    		// C:\\Users\\dany_\\Desktop\\final1.g:1:38: TIPODIRECTIVA
    		{
    		DebugLocation(1, 38);
    		mTIPODIRECTIVA(); 

    		}
    		break;
    	case 6:
    		DebugEnterAlt(6);
    		// C:\\Users\\dany_\\Desktop\\final1.g:1:52: OPERACIONDIRECTIVA
    		{
    		DebugLocation(1, 52);
    		mOPERACIONDIRECTIVA(); 

    		}
    		break;
    	case 7:
    		DebugEnterAlt(7);
    		// C:\\Users\\dany_\\Desktop\\final1.g:1:71: START
    		{
    		DebugLocation(1, 71);
    		mSTART(); 

    		}
    		break;
    	case 8:
    		DebugEnterAlt(8);
    		// C:\\Users\\dany_\\Desktop\\final1.g:1:77: INT
    		{
    		DebugLocation(1, 77);
    		mINT(); 

    		}
    		break;
    	case 9:
    		DebugEnterAlt(9);
    		// C:\\Users\\dany_\\Desktop\\final1.g:1:81: NOMBRE
    		{
    		DebugLocation(1, 81);
    		mNOMBRE(); 

    		}
    		break;
    	case 10:
    		DebugEnterAlt(10);
    		// C:\\Users\\dany_\\Desktop\\final1.g:1:88: DIR
    		{
    		DebugLocation(1, 88);
    		mDIR(); 

    		}
    		break;

    	}

    }


	#region DFA
	DFA7 dfa7;

	protected override void InitDFAs()
	{
		base.InitDFAs();
		dfa7 = new DFA7(this);
	}

	private class DFA7 : DFA
	{
		private const string DFA7_eotS =
			"\x2\xFFFF\x1\x15\x1\xFFFF\x3\x15\x1\x20\x7\x13\x1\x15\x1\x13\x2\x15\x1"+
			"\xFFFF\x1\x13\x2\xFFFF\x1\x15\x2\x13\x1\xFFFF\x5\x13\x1\xFFFF\x2\x13"+
			"\x2\x20\x4\x13\x1\x20\x1\x13\x1\x20\x2\x13\x1\xFFFF\x1\x48\x2\x20\x1"+
			"\x13\x4\x20\x1\x13\x1\x20\x1\x13\x3\x20\x2\x13\x1\x20\x1\x13\x1\x20\x1"+
			"\x13\x3\x20\x2\x13\x1\xFFFF\x4\x20\x2\x54\x1\x13\x2\x20\x2\x54\x1\xFFFF"+
			"\x1\x56\x1\xFFFF";
		private const string DFA7_eofS =
			"\x57\xFFFF";
		private const string DFA7_minS =
			"\x1\xA\x1\xFFFF\x1\x30\x1\xFFFF\x1\x30\x1\x27\x1\x30\x1\x41\x1\x44\x1"+
			"\x55\x1\x52\x1\x44\x1\x54\x2\x44\x1\x30\x1\x27\x2\x30\x1\xFFFF\x1\x44"+
			"\x2\xFFFF\x1\x30\x1\x44\x1\x4D\x1\xFFFF\x1\x56\x1\x51\x2\x54\x1\x55\x1"+
			"\xFFFF\x1\x41\x1\x4C\x2\x41\x1\x55\x1\x53\x1\x41\x1\x42\x1\x41\x1\x58"+
			"\x1\x41\x1\x52\x1\x54\x1\xFFFF\x1\x41\x1\x30\x1\x41\x1\x50\x4\x41\x1"+
			"\x42\x1\x41\x1\x47\x3\x41\x2\x42\x1\x41\x1\x48\x1\x41\x1\x57\x3\x41\x1"+
			"\x44\x1\x45\x1\xFFFF\x6\x41\x1\x54\x4\x41\x1\xFFFF\x1\x41\x1\xFFFF";
		private const string DFA7_maxS =
			"\x1\x7A\x1\xFFFF\x1\x7A\x1\xFFFF\x4\x7A\x1\x44\x1\x55\x1\x52\x1\x53\x1"+
			"\x55\x1\x49\x1\x4F\x1\x7A\x1\x27\x1\x7A\x1\x66\x1\xFFFF\x1\x44\x2\xFFFF"+
			"\x1\x7A\x1\x44\x1\x4D\x1\xFFFF\x1\x56\x1\x51\x2\x54\x1\x55\x1\xFFFF\x1"+
			"\x58\x1\x4C\x2\x7A\x1\x55\x1\x53\x1\x58\x1\x42\x1\x7A\x1\x58\x1\x7A\x1"+
			"\x52\x1\x54\x1\xFFFF\x3\x7A\x1\x50\x4\x7A\x1\x42\x1\x7A\x1\x47\x3\x7A"+
			"\x1\x42\x1\x57\x1\x7A\x1\x48\x1\x7A\x1\x57\x3\x7A\x1\x44\x1\x45\x1\xFFFF"+
			"\x6\x7A\x1\x54\x4\x7A\x1\xFFFF\x1\x7A\x1\xFFFF";
		private const string DFA7_acceptS =
			"\x1\xFFFF\x1\x1\x1\xFFFF\x1\x3\xF\xFFFF\x1\x9\x1\xFFFF\x1\x8\x1\x9\x3"+
			"\xFFFF\x1\x6\x5\xFFFF\x1\x4\xD\xFFFF\x1\xA\x19\xFFFF\x1\x2\xB\xFFFF\x1"+
			"\x5\x1\xFFFF\x1\x7";
		private const string DFA7_specialS =
			"\x57\xFFFF}>";
		private static readonly string[] DFA7_transitionS =
			{
				"\x1\x3\x21\xFFFF\x1\x1\x3\xFFFF\xA\x12\x7\xFFFF\x1\x4\x1\xF\x1\x5\x1"+
				"\x6\x1\x2\x1\x11\x3\x13\x1\x7\x1\x13\x1\x8\x1\x9\x1\x13\x1\xA\x2\x13"+
				"\x1\xB\x1\xC\x1\xD\x2\x13\x1\xE\x1\x10\x2\x13\x4\xFFFF\x1\x13\x1\xFFFF"+
				"\x6\x11\x14\x13",
				"",
				"\xA\x12\x7\xFFFF\x6\x11\x1\x13\x1\x16\x5\x13\x1\x14\xC\x13\x4\xFFFF"+
				"\x1\x13\x1\xFFFF\x6\x11\x14\x13",
				"",
				"\xA\x12\x7\xFFFF\x3\x11\x1\x17\x2\x11\x1\x13\x1\x16\x5\x13\x1\x18\xC"+
				"\x13\x4\xFFFF\x1\x13\x1\xFFFF\x6\x11\x14\x13",
				"\x1\x1A\x8\xFFFF\xA\x12\x7\xFFFF\x6\x11\x1\x13\x1\x16\x6\x13\x1\x19"+
				"\xB\x13\x4\xFFFF\x1\x13\x1\xFFFF\x6\x11\x14\x13",
				"\xA\x12\x7\xFFFF\x6\x11\x1\x13\x1\x16\x1\x1B\x11\x13\x4\xFFFF\x1\x13"+
				"\x1\xFFFF\x6\x11\x14\x13",
				"\x4\x13\x1\x1C\x1\x13\x1\x1D\x4\x13\x1\x1E\x6\x13\x1\x1F\x7\x13\x4"+
				"\xFFFF\x1\x13\x1\xFFFF\x1A\x13",
				"\x1\x21",
				"\x1\x22",
				"\x1\x23",
				"\x1\x24\x1\x26\xD\xFFFF\x1\x25",
				"\x1\x27\x1\x28",
				"\x1\x29\x4\xFFFF\x1\x2A",
				"\x1\x2B\xA\xFFFF\x1\x2C",
				"\xA\x12\x7\xFFFF\x6\x11\x1\x13\x1\x16\x10\x13\x1\x2D\x1\x13\x4\xFFFF"+
				"\x1\x13\x1\xFFFF\x6\x11\x14\x13",
				"\x1\x1A",
				"\xA\x12\x7\xFFFF\x6\x11\x1\x13\x1\x16\x12\x13\x4\xFFFF\x1\x13\x1\xFFFF"+
				"\x6\x11\x14\x13",
				"\xA\x12\x7\xFFFF\x6\x12\x1\xFFFF\x1\x2E\x18\xFFFF\x6\x12",
				"",
				"\x1\x2F",
				"",
				"",
				"\xA\x12\x7\xFFFF\x3\x11\x1\x30\x2\x11\x1\x13\x1\x16\x12\x13\x4\xFFFF"+
				"\x1\x13\x1\xFFFF\x6\x11\x14\x13",
				"\x1\x31",
				"\x1\x32",
				"",
				"\x1\x33",
				"\x1\x34",
				"\x1\x35",
				"\x1\x36",
				"\x1\x37",
				"",
				"\x1\x38\x1\xFFFF\x1\x39\x8\xFFFF\x1\x3A\xB\xFFFF\x1\x3B",
				"\x1\x3C",
				"\x1A\x13\x4\xFFFF\x1\x13\x1\xFFFF\x1A\x13",
				"\x1A\x13\x4\xFFFF\x1\x13\x1\xFFFF\x1A\x13",
				"\x1\x3D",
				"\x1\x3E",
				"\x1\x3F\x1\xFFFF\x1\x40\x8\xFFFF\x1\x41\x6\xFFFF\x1\x42\x4\xFFFF\x1"+
				"\x43",
				"\x1\x44",
				"\x1A\x13\x4\xFFFF\x1\x13\x1\xFFFF\x1A\x13",
				"\x1\x45",
				"\x1A\x13\x4\xFFFF\x1\x13\x1\xFFFF\x1A\x13",
				"\x1\x46",
				"\x1\x47",
				"",
				"\x1A\x13\x4\xFFFF\x1\x13\x1\xFFFF\x1A\x13",
				"\xA\x12\x7\xFFFF\x6\x11\x1\x13\x1\x16\x12\x13\x4\xFFFF\x1\x13\x1\xFFFF"+
				"\x6\x11\x14\x13",
				"\x1A\x13\x4\xFFFF\x1\x13\x1\xFFFF\x1A\x13",
				"\x1\x49",
				"\x1A\x13\x4\xFFFF\x1\x13\x1\xFFFF\x1A\x13",
				"\x1A\x13\x4\xFFFF\x1\x13\x1\xFFFF\x1A\x13",
				"\x1A\x13\x4\xFFFF\x1\x13\x1\xFFFF\x1A\x13",
				"\x1A\x13\x4\xFFFF\x1\x13\x1\xFFFF\x1A\x13",
				"\x1\x4A",
				"\x1A\x13\x4\xFFFF\x1\x13\x1\xFFFF\x1A\x13",
				"\x1\x4B",
				"\x1A\x13\x4\xFFFF\x1\x13\x1\xFFFF\x1A\x13",
				"\x1A\x13\x4\xFFFF\x1\x13\x1\xFFFF\x1A\x13",
				"\x1A\x13\x4\xFFFF\x1\x13\x1\xFFFF\x1A\x13",
				"\x1\x4C",
				"\x1\x4D\x14\xFFFF\x1\x4E",
				"\x11\x13\x1\x4F\x8\x13\x4\xFFFF\x1\x13\x1\xFFFF\x1A\x13",
				"\x1\x50",
				"\x1A\x13\x4\xFFFF\x1\x13\x1\xFFFF\x1A\x13",
				"\x1\x51",
				"\x1A\x13\x4\xFFFF\x1\x13\x1\xFFFF\x1A\x13",
				"\x1A\x13\x4\xFFFF\x1\x13\x1\xFFFF\x1A\x13",
				"\x1A\x13\x4\xFFFF\x1\x13\x1\xFFFF\x1A\x13",
				"\x1\x52",
				"\x1\x53",
				"",
				"\x1A\x13\x4\xFFFF\x1\x13\x1\xFFFF\x1A\x13",
				"\x1A\x13\x4\xFFFF\x1\x13\x1\xFFFF\x1A\x13",
				"\x1A\x13\x4\xFFFF\x1\x13\x1\xFFFF\x1A\x13",
				"\x1A\x13\x4\xFFFF\x1\x13\x1\xFFFF\x1A\x13",
				"\x1A\x13\x4\xFFFF\x1\x13\x1\xFFFF\x1A\x13",
				"\x1A\x13\x4\xFFFF\x1\x13\x1\xFFFF\x1A\x13",
				"\x1\x55",
				"\x1A\x13\x4\xFFFF\x1\x13\x1\xFFFF\x1A\x13",
				"\x1A\x13\x4\xFFFF\x1\x13\x1\xFFFF\x1A\x13",
				"\x1A\x13\x4\xFFFF\x1\x13\x1\xFFFF\x1A\x13",
				"\x1A\x13\x4\xFFFF\x1\x13\x1\xFFFF\x1A\x13",
				"",
				"\x1A\x13\x4\xFFFF\x1\x13\x1\xFFFF\x1A\x13",
				""
			};

		private static readonly short[] DFA7_eot = DFA.UnpackEncodedString(DFA7_eotS);
		private static readonly short[] DFA7_eof = DFA.UnpackEncodedString(DFA7_eofS);
		private static readonly char[] DFA7_min = DFA.UnpackEncodedStringToUnsignedChars(DFA7_minS);
		private static readonly char[] DFA7_max = DFA.UnpackEncodedStringToUnsignedChars(DFA7_maxS);
		private static readonly short[] DFA7_accept = DFA.UnpackEncodedString(DFA7_acceptS);
		private static readonly short[] DFA7_special = DFA.UnpackEncodedString(DFA7_specialS);
		private static readonly short[][] DFA7_transition;

		static DFA7()
		{
			int numStates = DFA7_transitionS.Length;
			DFA7_transition = new short[numStates][];
			for ( int i=0; i < numStates; i++ )
			{
				DFA7_transition[i] = DFA.UnpackEncodedString(DFA7_transitionS[i]);
			}
		}

		public DFA7( BaseRecognizer recognizer )
		{
			this.recognizer = recognizer;
			this.decisionNumber = 7;
			this.eot = DFA7_eot;
			this.eof = DFA7_eof;
			this.min = DFA7_min;
			this.max = DFA7_max;
			this.accept = DFA7_accept;
			this.special = DFA7_special;
			this.transition = DFA7_transition;
		}

		public override string Description { get { return "1:1: Tokens : ( T__11 | T__12 | T__13 | OPERACION | TIPODIRECTIVA | OPERACIONDIRECTIVA | START | INT | NOMBRE | DIR );"; } }

		public override void Error(NoViableAltException nvae)
		{
			DebugRecognitionException(nvae);
		}
	}

 
	#endregion

}
