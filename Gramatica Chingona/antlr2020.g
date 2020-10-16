grammar antlr2020;
options
{
    language=CSharp;
}


programa:	 inicio proposicion* final;

inicio	:	NOMBRE START DIR'\n';

proposicion
	:	(instruccion|directiva)'\n'?
	;
	
final	:	'END' NOMBRE? '\n'?;

instruccion
	:	NOMBRE? OPERACION NOMBRE?',X'? '\n'
	;
	
directiva
	:	NOMBRE TIPODIRECTIVA OPDIRECTIVA
	;
OPERACION
	:	'ADD' | 'AND' | 'COMP' | 'DIV' | 'J' | 'JEQ' | 'JGT' | 'JLT' | 'JSUB' | 'LDA' | 'LDCG' | 'LDL' | 'LDX' | 'MUL' | 'OR' | 'RD' | 'RSUB' | 'STA' | 'STCH' | 'STL' | 'STSW' | 'STX' | 'SUB' | 'TD' | 'TIX' | 'WD'  
	;
	
TIPODIRECTIVA
	:	'BYTE' | 'WORD' | 'RESB' | 'RESW'
	;
	
OPDIRECTIVA
	:	NUMERO| REGISTRO (NUMERO | NOMBRE)
	;
REGISTRO:	'X' | 'C'| 'H';
	
DIRECCION
	:	'DIRECCION'
	;
	
START	:	'START'
;
        
DIR	:	NUMERO'H'?;

MAYUSCULAS
	:	'A'..'Z';

MINUSCULAS
	:	'a'..'z';

NUMERO	: ('0'..'9'|'A'..'F'|'a'..'f')+;

NOMBRE	:	(MAYUSCULAS|MINUSCULAS|'_') (MAYUSCULAS|MINUSCULAS|NUMERO|'_')*
    	;
