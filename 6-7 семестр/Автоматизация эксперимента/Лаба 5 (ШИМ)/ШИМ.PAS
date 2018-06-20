program PWM;
  uses crt;
  var tp,t:longint;
  var tf:real;
  var ch:char;
begin
  clrscr;
  tf:=0;
  t:=0;
  tp:=100;
  while 1=1 do
    begin
    tf:=0;
    repeat
      port[$378]:=1;
      delay(t);
      port[$378]:=0;
      delay(tp-t);
    until KeyPressed;
    ch:=readkey;

    if ch='b' then
      while 1=1 do
        begin
        port[$378]:=1;
        delay(round(tp*sin(tf)*sin(tf)));
        port[$378]:=0;
        delay(round(tp*cos(tf)*cos(tf)));
        tf:=tf+0.001;
        if tf>3.14 then break;
    end;

    if ord(ch)=77 then t:=t+1;
    if t>100 then t:=100;
    if ord(ch)=75 then t:=t-1;
    if t<0 then t:=0;
  end;
end.
