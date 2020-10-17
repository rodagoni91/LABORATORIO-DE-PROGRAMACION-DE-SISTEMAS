grammar SIC_gramatica;

							//nombre de la gramatica
/*
*opciones de compilacion de la gramatica
*/
options {							
    language=CSharp2;								//lenguaje objetivo de la gramatica
}

/*
*	Reglas del Parser
*/
programa:	inicio proposicion* final;
inicio	:	NOMBRE START DIR'\n';
proposicion
	:	(instruccion|directiva)'\n'?
	;
final	:	'END' NOMBRE? '\n'?;
instruccion
	:	NOMBRE? OPERACION NOMBRE?',X'? '\n'
	;
directiva
	:	NOMBRE? TIPODIRECTIVA (OPERACIONDIRECTIVA | INT)
	;
OPERACION
	:	'ADD' | 'AND' | 'COMP' | 'DIV' | 'J' | 'JEQ' | 'JGT' | 'JLT' | 'JSUB' | 'LDA' | 'LDCG' | 'LDL' | 'LDX' | 'MUL' | 'OR' | 'RD' | 'RSUB' | 'STA' | 'STCH' | 'STL' | 'STSW' | 'STX' | 'SUB' | 'TD' | 'TIX' | 'WD'  
	;
TIPODIRECTIVA
	:	'BYTE' | 'WORD' | 'RESB' | 'RESW'
	;
	
OPERACIONDIRECTIVA
	:	'C''\''NOMBRE'\'' | 'X''\''INT'\'';
		
START	:	'START';
INT	:  ('A'..'F'|'0'..'9'|'a'..'f')+;
NOMBRE	:	('A'..'Z'|'a'..'z'|'_')+;
DIR	:	INT'H'?;


