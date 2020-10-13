grammar SIC_gramatica;

options {							
    language=CSharp2;								//lenguaje objetivo de la gramatica
}

programa: inicio proposicion fin FINLINEA;

inicio	: SIMBOLO 'START' NUM NL+;

proposicion
	:	 (instruccion | directiva)+  NL+ | NL+
	;
	
instruccion 
	:	etiqueta operacion (etiqueta | NUM)
	;
	
directiva
	:	etiqueta tipoDirectiva opDirectiva
	;
	
etiqueta:	SIMBOLO;

operacion
	:	'ADD' | 'AND' | 'COMP' | 'DIV' | 'J' | 'JEQ' | 'JGT' | 'JLT' | 'JSUB' | 'LDA' | 'LDCG' | 'LDL' | 'LDX' | 'MUL' | 'OR' | 'RD' | 'RSUB' | 'STA' | 'STCH' | 'STL' | 'STSW' | 'STX' | 'SUB' | 'TD' | 'TIX' | 'WD' | FINL 
	;
	
tipoDirectiva
	:	'BYTE' | 'WORD' | 'RESB' | 'RESW'
	;
	
opDirectiva 
	: 	NUM | 'C'SIMBOLO | 'X'NUM
	;
	
fin	: 'END' etiqueta
	;

SIMBOLO	: ('a' | 'b' )*;

NUM	:	 ('0'..'9')* | ('a'..'f' |  'A'..'F' | '0'..'9')*;

FINLINEA:	'\n';

NL  :   '\r'? '\n' ;
