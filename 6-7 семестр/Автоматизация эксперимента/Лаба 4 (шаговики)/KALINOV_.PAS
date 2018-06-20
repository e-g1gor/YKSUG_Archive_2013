program shag;
uses crt;
var z,w, r,j,k:longint;

procedure move(speed,steps,revers,mode,accselerate:longint);
   var o,i,k:longint;
   begin
   o:=20000;
   k:=0;
   clrscr;
   if revers=0 then
   begin
   for i:=0 to 2505 do
   begin
      port[$378]:=1;
      k:=k+1;
      writeln(k);
      if k>steps then break;
      if k= steps then break;
      if o>speed then
      o:=o-500;
      delay(o);
      port[$378]:=1+2;
      k:=k+1;
      writeln(k);
      if k>steps then break;
      if k= steps then break;
      if o>3000 then
      begin
      if o>speed then
      o:=o-500;
      delay(o);
      end;
      port[$378]:=2;
      k:=k+1;
      writeln(k);
      if k>steps then break;
      if k= steps then break;
      if o>3000 then
      begin
      if o>speed then
      o:=o-500;
      delay(o);
      end;
      port[$378]:=2+4;
      k:=k+1;
      writeln(k);
      if k>steps then break;
      if k= steps then break;
      if o>3000 then
      begin
      if o>speed then
      o:=o-500;
      end;
      delay(o);
      port[$378]:=4;
      k:=k+1;
      writeln(k);
      if k>steps then break;
      if k= steps then break;
      if o>3000 then
      begin
      if o>speed then
      o:=o-500;
      delay(o);
      end;
      port[$378]:=4+8;
      k:=k+1;
      writeln(k);
      if k>steps then break;
      if k= steps then break;
      if o>3000 then
      begin
      if o>speed then
      o:=o-500;
      delay(o);
      end;
      port[$378]:=8;
      k:=k+1;
      writeln(k);
      if k>steps then break;
      if k= steps then break;
      if o>3000 then
      begin
      if o>speed then
      o:=o-500;
      end;
      delay(o);
      port[$378]:=1+8;
      k:=k+1;
      writeln(k);
      if o>3000 then
      begin
      if o>speed then
      o:=o-500;
      end;
      delay(o);
      if k>steps then break;
      if k= steps then break;
   end;
end;



if revers=1 then
   begin
   for i:=0 to 255 do
   begin
      port[$378]:=9;
      k:=k+1;
      writeln(k);
      if k>steps then break;
      if k= steps then break;
      delay(speed);
      port[$378]:=8;
      k:=k+1;
      writeln(k);
      if k>steps then break;
      if k= steps then break;
      delay(speed);
      port[$378]:=12;
      k:=k+1;
      writeln(k);
      if k>steps then break;
      if k= steps then break;
      delay(speed);
      port[$378]:=4;
      k:=k+1;
      writeln(k);
      if k>steps then break;
      if k= steps then break;
      delay(speed);
      port[$378]:=6;
      k:=k+1;
      writeln(k);
      if k>steps then break;
      if k= steps then break;
      delay(speed);
      port[$378]:=2;
      k:=k+1;
      writeln(k);
      if k>steps then break;
      if k= steps then break;
      delay(speed);
      port[$378]:=3;
      k:=k+1;
      writeln(k);
      if k>steps then break;
      if k= steps then break;
      delay(speed);
      port[$378]:=1;
      k:=k+1;
      writeln(k);
      delay(speed);
      if k>steps then break;
      if k= steps then break;
   end;
end;
end;
begin

writeln('Vedite skorost,shagi,revers') ;
readln(j);
readln(k);
readln(r);
move(j,k,r,0,0);




if 0>1 then begin

for z:=0 to 50 do
begin
port[$378]:=1+2;
delay(5000);
port[$378]:=2+4;
delay(5000);
port[$378]:=4+8;
delay(5000);
port[$378]:=8+1;
delay(5000);
end;
for z:=0 to 50 do
begin
port[$378]:=1+8;
delay(5000);
port[$378]:=4+8;
delay(5000);
port[$378]:=4+2;
delay(5000);
port[$378]:=2+1;
delay(5000);
end;
w:=50000;
for z:=0 to 10 do
begin
port[$378]:=1+2;
if w>10000 then
w:=w-500;
delay(w);
port[$378]:=2+4;
if w>10000 then
w:=w-500;
delay(w);
port[$378]:=4+8;
if w>10000 then
w:=w-500;
delay(w);
port[$378]:=8+1;
if w>3000 then
w:=w-500;
delay(w);
end;


writeln('Vedite skorost,shagi,revers') ;
readln(j);
readln(k);
readln(r);
move(j,k,r,0,0);
end;
end.