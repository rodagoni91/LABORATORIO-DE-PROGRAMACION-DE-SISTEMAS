grammar sicXE;
options {							
    language=CSharp2;								
}
programa:	inicio (proposicion)* final;
inicio	:	NOMBRE START DIR'\n';
proposicion
	:	(instruccion|directiva)'\n'?
	;
instruccion
	: NOMBRE? UNO NOTACION? NOMBRE',X'?| NOMBRE? DOS NOTACION? NOMBRE',X'? | NOMBRE? '+ '? TRES_CUATRO NOTACION? NOMBRE ',X'?;
final	:	'END' NOMBRE? '\n'?;
directiva
	:	NOMBRE? TIPODIRECTIVA (OPERACIONDIRECTIVA | INT)
	;	
UNO	:	'FIX' | 'FLOAT' | 'HIO' | 'NORM' | 'SIO' | 'TIO';

DOS 	:	'CLEAR' | 'ADDR' | 'COMPR' | 'DIVR' | 'MULR' | 'SHIFTL' | 'SHIFTR' | 'SUBR' | 'SVC' | 'TIXR';

TRES_CUATRO	:	'ADD' | 'ADDF' | 'AND' | 'COMP' | 'COMPRF' | 'DIV' | 'DIVF' | 'J' | 'JEQ' | 'JGT' | 'JLT' | 'JSUB' | 'LDA' | 'LDB' | 'LDCH' | 'LDF' | 'LDL' | 'LDS' | 'LDT'| 'LDX' | 'LPS'| 'MUL' | 'MULF' | 'OR' | 'RD' | 'RSUB'| 'SSK'| 'STA' | 'STB' | 'STCH' | 'STF'| 'STI'| 'STL' | 'STS' | 'STSW' | 'STT' | 'STX' | 'SUB' | 'SUBF' | 'TD' | 'TIX'| 'WD'
	;

NOTACION	:	'@' | '#'
		;

TIPODIRECTIVA
	:	'BYTE' | 'WORD' | 'RESB' | 'RESW' | 'BASE' | 'USE' | 'EQU'
	;
	
OPERACIONDIRECTIVA
	:	'C''\''NOMBRE'\'' | 'X''\''INT'\'';
		
START	:	'START';
INT	:  ('A'..'F'|'0'..'9'|'a'..'f')+;
NOMBRE	:	('A'..'Z'|'a'..'z'|'_')+;
DIR	:	INT'H'?;


