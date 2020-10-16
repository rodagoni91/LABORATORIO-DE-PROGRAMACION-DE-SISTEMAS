grammar SIC_gramatica;

/*
    Reglas de análisis sintáctico
*/
prog : inicio linea* fin ;
inicio : SIMBOLO DIRECTIVA_START NUMERO NL+ ;
fin : DIRECTIVA_END SIMBOLO? NL* EOF;
linea
    :   (SIMBOLO?|(SIMBOLO+NUMERO)) instruccion NL
    |   (SIMBOLO?|(SIMBOLO+NUMERO)) instruccion2 NL
    |   (SIMBOLO?|(SIMBOLO+NUMERO)) instruccion3 NL
    |   (SIMBOLO?|(SIMBOLO+NUMERO)) instruccion4 NL
    |   NL
    ;
instruccion
    :   ('+'?MNEMONICO) ('@'|'#')? (SIMBOLO?|NUMERO?|(SIMBOLO+NUMERO)) (','+'X')?
    |   RSUB
    |   BASE (SIMBOLO+NUMERO?)
    |   directiva
    ;

instruccion2
    :   MNEMONICO2V2 (('A'|'X'|'L'|'B'|'S'|'T'|'F')+','+(('A'|'X'|'L'|'B'|'S'|'T'|'F')|NUMERO))
    ;

instruccion3
    :   MNEMONICO2V1 ('A'|'X'|'L'|'B'|'S'|'T'|'F')
    ;

instruccion4
    :   MNEMONICO1
    ; 

directiva
    :   DIRECTIVA_NUM NUMERO
    |   DIRECTIVA_VAL (VALOR|NUMERO)
    ;

/*
    Reglas de anáisis léxico
*/
NUMERO
    :   [0-9]+ // Decimal
    |   [0-9a-fA-F]+ H // Hexadecimal
    |   [01]+ B // Binario;
    ;
VALOR
    :   C '\'' [a-zA-Z0-9]+ '\''
    |   X '\'' [0-9a-fA-F]+ '\''
    ;

MNEMONICO
    :   A D D
    |   A D D F
    |   A N D
    |   C O M P
    |   C O M P F
    |   D I V
    |   D I V F
    |   J E Q
    |   J G T
    |   J L T
    |   J S U B
    |   J
    |   L D A
    |   L D B
    |   L D F
    |   L D S
    |   L D T
    |   L P S
    |   L D C H
    |   L D L
    |   L D X
    |   M U L
    |   M U L F
    |   O R
    |   R D
    |   S S K
    |   S T A
    |   S T B
    |   S T C H
    |   S T F
    |   S T I
    |   S T L
    |   S T S
    |   S T S W
    |   S T X
    |   S T T
    |   S U B
    |   S U B F
    |   T D
    |   T I X
    |   W D
    ;

MNEMONICO1
    :   F I X
    |   F L O A T
    |   H I O
    |   N O R M 
    |   S I O
    |   T I O
    ;

MNEMONICO2V2
    :   A D D R
    |   C O M P R
    |   D I V R
    |   M U L R
    |   R M O
    |   S U B R
    |   S H I F T L
    |   S H I F T R
    ;

MNEMONICO2V1
    :   C L E A R
    |   T I X R     
    ;

RSUB : R S U B ;
BASE : B A S E ;
DIRECTIVA_NUM
    :   R E S W
    |   R E S B
    ;
DIRECTIVA_VAL
    :   B Y T E
    |   W O R D
    ;
DIRECTIVA_END : E N D ;
DIRECTIVA_START : S T A R T ;
SIMBOLO : [a-zA-Z]+ ;   // Checar palabras reservadas.
WS : [ \t]+ -> skip ;
NL  :   '\r'? '\n' ;

/*
    Fragmentos para el análisis léxico
*/
fragment A : [aA] ;
fragment B : [bB] ;
fragment C : [cC] ;
fragment D : [dD] ;
fragment E : [eE] ;
fragment F : [fF] ;
fragment G : [gG] ;
fragment H : [hH] ;
fragment I : [iI] ;
fragment J : [jJ] ;
fragment K : [kK] ;
fragment L : [lL] ;
fragment M : [mM] ;
fragment N : [nN] ;
fragment O : [oO] ;
fragment P : [pP] ;
fragment Q : [qQ] ;
fragment R : [rR] ;
fragment S : [sS] ;
fragment T : [tT] ;
fragment U : [uU] ;
fragment V : [vV] ;
fragment W : [wW] ;
fragment X : [xX] ;
fragment Y : [yY] ;
fragment Z : [zZ] ;
