
PROGRAM ACP;
USES CRT;
VAR XIN,XOUT,I,M: INTEGER;
BEGIN

XOUT:=0;
PORT[$378]:=0;
M:=128;
FOR I:=0 TO 7 DO
BEGIN
PORT[$378]:=(M OR XOUT);
DELAY(1);
XIN:=PORT[$379];
IF XIN=94 THEN XOUT:=XOUT+M;
M:=ROUND(M/2);
END;


WRITE('U�� = ',XOUT/100:1:1,' �����.');
READLN;
CLRSCR;

END.