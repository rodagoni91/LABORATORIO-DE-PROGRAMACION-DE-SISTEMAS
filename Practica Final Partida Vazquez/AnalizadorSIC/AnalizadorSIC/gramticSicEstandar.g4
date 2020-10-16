grammar gramticSicEstandar;
options
{
    language=CSharp;
    output=AST;
	ASTLabelType=CommonTree;
}

/*
 * Parser Rules
 */

programa
	:
	(inicio proposiciones fin) | EOF
	;

inicio	
	:
	(NOMBRE | ETIQUETA) START NUMD #InicioDecimal
	|
	(NOMBRE | ETIQUETA) START NUMH #InicioHexadecimal
	;
	
fin	
	:
	END (entrada)? #FunEnd
	;

entrada
	:
	ETIQUETA
	;
	
proposiciones
	:
	(proposicion)+
	;

proposicion
	:
	instruccion #CodInstruccion
	|
	directiva #CodDirectiva
	;
	
instruccion
	:
	etiqueta? F4? CODOP oper #CInstruccion
	|etiqueta? CODOPRSUB #CodRsub
	|etiqueta? F1					#FormatoUno
	|etiqueta? F21 registros #FomratoDosUno
	|etiqueta? F22 registros (COMMA (registros|'X'))? #FormatoDosDos
	|etiqueta? F2N registros  COMMA (NUMD|NUMH) #FormatoDosN
	;

registros:
		REGISTROS;
directiva/*DEFINICION DIRECTIVA*/
	:
	etiqueta? tipodir operdir #FuncionDirectiva
	|
	etiqueta? byte constantes #FuncionByte
	|BASE ETIQUETA #FuncionBase
	;
	
tipodir/*TIPO DIRECTIVA*/
	:
	WORD
	|
	RESB
	|
	RESW
	| ORG	
;

byte
	:
	BYTE  
	;
	
etiqueta
	:
	ETIQUETA
	;
	
oper	
	:
	MODO? (ETIQUETA|(NUMD|NUMH))(COMMA INDICE)? #InstruccionOperendo
	;

indexado
	:
	INDICE
	;

operdir
	:
	NUMD
	|
	NUMH
	;
	
constantes
	:
	CONSTCAD #ConstanteCadena
	|
	CONSTHEX #ConstanteValor
	;

/*
 * Lexer Rules
 */

fragment LETMAYS
	:	
		'A'..'Z'
	;
	
fragment LETMINS
	:
		'a'..'z'	
	;

fragment LETHEX
	:
		'A'..'F'	
	;

fragment NUMEROS
	:
		'0'..'9'
	;

fragment AP
	: 
		'\''
	;

COMMA 	: ','; /*Definimos la coma para la separar el operando del registro X*/
INDICE	: 'X';/*La X es para indicar el registro X como un operando*/
CAD	: 'C';/*La letra C es para indicar que un valor se trate como cadena*/
START	: 'START';/*Es para definir la directiva start que va al comienzo del programa*/
END	: 'END';/*Es para definir la directiva end que se pone al fianl del programa*/
/*Esta es la lista de directivas del esamblador*/
RESB	: 'RESB';
BYTE	: 'BYTE';
RESW	: 'RESW';
WORD	: 'WORD';
BASE	: 'BASE';
ORG		: 'ORG';
REGISTROS:('A'|'X'|'B'|'S'|'T'|'F'|'L'|'SW'|'CP'|'PC');
/*formatos*/
F4:'+';
F1:('HIO'|'FIX'|'SIO'|'TIO'|'FLOAT');
F21:('SVC'|'TIXR');
F22:('ADDR'|'COMPR'|'DIVR'|'MULR'|'RMO'|'SUBR'|'CLEAR');
F2N:('SHIFTL'|'SHIFTR');
MODO:('#'|'@');
/*Esta es la lista de las instrucciones del esamblador*/
CODOPRSUB:'RSUB';
CODOP: 'ADD'|'AND'|'COMP'|'DIV'|'J'|'JEQ'|'JGT'|'JLT'|'JSUB'|'LDA'|
	  'LDCH'|'LDL'|'LDX'|'MUL'|'OR'|'RD'|'STA'|'STCH'|'STL'|
	  'STSW'|'STX'|'SUB'|'TD'|'TIX'|'WD'|'ADDF'|'COMP'|'COMPF'|
	'DIV'|'DIVF'|'LDB'|'LDF'|'LDS'|'LDT'|'LPS'|'MUL'|'MULF'|'NORM'|'RSUB'|'SHIFTR'|'SSK'|
	  'STB'|'STF'|'STI'|'STS'|'STT'|'SUBF'|'WD'
;
/*Define una palabra conformada por letras minusculas*/
MINUSCULAS: LETMINS+;
/*Define como se conforma la definicion de una constamte en hexadecimal*/
CONSTHEX: ('X '(AP(LETHEX| NUMEROS)*AP))|('X'(AP (LETHEX| NUMEROS)*AP));
/*Define un numero decimal*/
NUMD	: (NUMEROS)+;
/*Define un nemero hexadecimal*/
NUMH	: (LETHEX | NUMEROS)+('H'|'h');
/*Define que la etiquueta de una linea esta conformado por letras mayusculas*/
ETIQUETA: (LETMAYS|NUMD)+;
/*Define que el nombre del programa puede ser una combinacion de letras con numeros*/
NOMBRE	: (LETMAYS | NUMEROS)+;
/*Define la estructura de una constante de tipo cadena*/
CONSTCAD: ('C '(AP (LETMAYS|MINUSCULAS|NUMD)* AP))|('C'(AP (LETMAYS|MINUSCULAS|NUMD)* AP));
/*Define los caracteres que se salta en una lectura*/
TABULADOR: (' '|'\t'|'\r'|';'|'['|']'|'.'|'\n')+{Skip();};