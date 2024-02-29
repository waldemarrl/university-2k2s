alter session set "_ORACLE_SCRIPT"=true;
alter session set "_ORACLE_SCRIPT"=false;

CREATE TABLESPACE TSPDB_LVD
    DATAFILE 'C:\app\orcl_wald\TablespacePDB\TSPDB_LVD.dbf'
    SIZE 30M
    AUTOEXTEND ON NEXT 5M
    MAXSIZE 50M
    EXTENT MANAGEMENT LOCAL;

CREATE ROLE RL_LVDPDB;
GRANT CREATE SESSION,
    CREATE TABLE,
    CREATE VIEW,
    CREATE SEQUENCE,
    CREATE SYNONYM,
    CREATE CLUSTER,
    CREATE PROCEDURE TO RL_LVDPDB;
CREATE PROFILE PF_LVDPDB LIMIT
    PASSWORD_LIFE_TIME 180
    SESSIONS_PER_USER 3
    FAILED_LOGIN_ATTEMPTS 7
    PASSWORD_LOCK_TIME 1
    PASSWORD_REUSE_TIME 10
    PASSWORD_GRACE_TIME DEFAULT
    CONNECT_TIME 180
    IDLE_TIME 30;
CREATE USER LVDPDB IDENTIFIED BY 75980
    DEFAULT TABLESPACE TSPDB_LVD QUOTA UNLIMITED ON TSPDB_LVD
    PROFILE PF_LVDPDB
    ACCOUNT UNLOCK;
GRANT RL_LVDPDB TO LVDPDB;

SELECT * fROM dba_roles;
SELECT * FROM dba_sys_privs;
SELECT * FROM dba_profiles;
SELECT username, account_status, lock_date FROM dba_users;

DROP USER LVDPDB CASCADE;
DROP PROFILE PF_LVDPDB CASCADE;
DROP ROLE RL_LVDPDB;

-----------------------------------------------------------
CREATE GLOBAL TEMPORARY TABLE LESSON(
tlesson char(10 byte) not null,
tlesson_name varchar2(30 byte),
constraint pk_lesson primary key (tlesson)
);
 
INSERT INTO LESSON VALUES('one', 1);
INSERT INTO LESSON VALUES('two', 2);
INSERT INTO LESSON VALUES('three', 3);
COMMIT;

DROP TABLE LESSON;

--------------------------------------------------
CREATE SEQUENCE seq1
    START WITH 1000
    INCREMENT BY 10;

DROP SEQUENCE seq1;

SELECT seq1.NEXTVAL FROM dual;
SELECT seq1.CURRVAL FROM dual;

SELECT * FROM SYS.user_sequences;

CREATE SEQUENCE seq2
    START WITH 10
    INCREMENT BY 10
    MAXVALUE 100
    NOCYCLE;
    
DROP SEQUENCE seq2;

SELECT seq2.NEXTVAL FROM dual; 
SELECT seq2.CURRVAL FROM dual;

CREATE SEQUENCE seq3
    START WITH 10
    INCREMENT BY -10
    MINVALUE -100
    MAXVALUE 100
    NOCYCLE
    ORDER;
    
DROP SEQUENCE seq3;

SELECT seq3.NEXTVAL FROM dual;
SELECT seq3.CURRVAL FROM dual;

CREATE SEQUENCE seq4
    START WITH 10
    INCREMENT BY 1
    MAXVALUE 15
    CYCLE
    CACHE 5
    NOORDER;

DROP SEQUENCE seq4;

SELECT seq4.NEXTVAL FROM dual;
SELECT seq4.CURRVAL FROM dual;

SELECT * FROM SYS.user_sequences;

-------------------------------------------------------

CREATE TABLE T1
(
    N1 number(20),
    N2 number(20),
    N3 number(20),
    N4 number(20)
) STORAGE(buffer_pool KEEP);

DROP TABLE T1;

DECLARE X NUMBER: = 0;
BEGIN
    LOOP
        INSERT INTO T1(N1,N2,N3,N4) VALUES(seq1.NEXTVAL, seq2.NEXTVAL, seq3.NEXTVAL, seq4.NEXTVAL);
        X:= X + 1;
        EXIT WHEN X = 7;
    END LOOP;
END;

SELECT * FROM T1;
---------------------------------------------

CREATE CLUSTER ABC
(
    x number(10),
    v varchar(12)
)HASHKEYS 200;
                
DROP CLUSTER ABC;

CREATE TABLE A
(
    xa number(10),
    va varchar(12),
    tabA char
)CLUSTER ABC(xa,va);

DROP TABLE A;

CREATE TABLE B
(
    xb number(10),
    vb varchar(12),
    tabB char
)CLUSTER ABC(xb,vb);

DROP TABLE B;

CREATE TABLE C
(
    xc number(10),
    vc varchar(12),
    tabC char
)CLUSTER ABC(xc,vc);

DROP TABLE C;

SELECT * FROM user_tables;
SELECT * FROM user_clusters;

