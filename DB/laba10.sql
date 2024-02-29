set serveroutput on;

begin 
    null;
end;

declare 
    x char(100) := 'Hello World';
    begin 
        dbms_output.put_line(x);
    end;
    
---------------------------------------------------------------------
SELECT keyword FROM v$reserved_words WHERE LENGTH = 1 AND keyword !='A';

SELECT keyword FROM v$reserved_words WHERE LENGTH > 1 AND keyword !='A' order by keyword;
---------------------------------------------------------------------

declare 
    x number(3) := 3;
begin
    dbms_output.put_line('x =' || x);
end;

declare 
    x number(3) := 3;
    y number(3) := 5;
    z number(3);
begin
    z := x+y;
    dbms_output.put_line(z);
end;

declare 
    x float(10) := 3.5;
begin
    dbms_output.put_line(x);
end;

declare 
    x number(3) := 3;
    e number(4) := 10;
begin
    dbms_output.put_line(power(x,e));
end;

declare 
    x date;
begin
    x := CURRENT_DATE;
    dbms_output.put_line(x);
end;

declare 
    x char(30) := 'привет';
    y char(30) := 'hello';
begin
    dbms_output.put_line(x);
    dbms_output.put_line(y);
end;

declare 
    x BOOLEAN := true;
    y BOOLEAN := false;
begin 
    if x then dbms_output.put_line('x = '||'true'); end if;
end;

declare
    x constant number(5) := 5; 
    y constant varchar(25) := 'Hello world'; 
    z constant char(7) := 'Hell';            
begin
    dbms_output.put_line(x);
    dbms_output.put_line(y);
    dbms_output.put_line(z);
        exception when others
            then dbms_output.put_line('error = '||n1);
end;

declare
    name varchar(25) := 'Var';
    surname name%TYPE := 'Joe'; 
    y  dual%ROWTYPE;
begin
    select 'a' into y from dual;
    dbms_output.put_line(name);
    dbms_output.put_line(y.dummy);
end;


declare
        x number(2) := 1;
    begin
        if 4>x 
        then 
            dbms_output.put_line('1>'||x);
        ------------
        elsif 1=x 
        then 
            dbms_output.put_line('1='||x);
        ------------
        else 
            dbms_output.put_line('4<'||x);
    end if;
end;

declare
    x pls_integer := 3;
begin
    case x
        when 1 then dbms_output.put_line('1');
        when 2 then dbms_output.put_line('1');
        when 3 then dbms_output.put_line('1');
            else dbms_output.put_line('else');
    end case;
end;

declare
    x pls_integer :=0;
begin
    loop x:=x+1;
        dbms_output.put(x);
    exit when x>5;
        end loop;
    for k in 1..5
        loop dbms_output.put_line(k); 
    end loop;
    while (x>0)
        loop x:=x-1;
            dbms_output.put_line(x);
    end loop;
end;
