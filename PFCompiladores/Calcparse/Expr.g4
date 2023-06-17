grammar Expr;
prog:   (expr  NEWLINE )* ;
expr:   expr op=(MULT|DIV) expr { Console.WriteLine("Token Encontrado:" + $op.text); } 
    |   expr op=(SUM|RES) expr {Console.WriteLine("Token Encontrado:" + $op.text);}
    |   INT                 {Console.WriteLine("Token Encontrado:" + $INT.text);}
    /*agregamos la regla y lo mostramos en consola*/
    |   REAL                {Console.WriteLine("Token Encontrado:"+ $REAL.text);}
    ;


MULT : '*';
DIV : '/';
SUM: '+';
RES: '-';
NEWLINE : [\r\n]+ ;
INT     : '-'?[0-9]+ ;
/*agregamos una regla (REAL) y agregamos el signo menos con ? para describir que es opcional, luego 
la regla int seguido de un literal (el punto) y por ultimo otro int para las decimas*/
REAL : '-'?INT'.'INT;
