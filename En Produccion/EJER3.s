EJER3  		START  		0000
       		RESW   		10H
NUM    		WORD   		64
       		RESB   		64
VALOR  		WORD   		16H
       		HIO
INICIO 		CLEAR  		X
       		LDT    		NUMERO
       		RESW   		10
       		BASE   		TABLA
       		+MUL   		#INICIO
       		LDA    		@VALOR
       		+STA   		#VALORES
       		MULR   		X,A
TEMP   		RESW   		2
CAD    		BYTE   		C'EJERC3'
TABLA  		RESW   		1004H
       		LDCH   		NUM
       		+JGT   		100H,X
       		COMP   		TEMP
       		RESB   		1
       		BYTE   		X'321'
       		RSUB
       		END