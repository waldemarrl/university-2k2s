SELECT TABLESPACE_NAME, sTATUS, CONTENTS LOGGING FROM SYS.dba_tablespaces;

CREATE TABLESPACE LVD_QDATA
    DATAFILE 'C:\app\orcl_wald\TablespacePDB\LVD_QDATAA.dbf'
    SIZE 10M
    AUTOEXTEND ON NEXT 5M
    MAXSIZE 30M
    --UNIFORM SIZE 10M -- Ó‰ËÌ‡ÍÓ‚˚È ‡ÁÏÂ extent
    EXTENT MANAGEMENT LOCAL;
    
DROP TABLESPACE LVD_QDATA;    
    
ALTER TABLESPACE LVD_QDATA
    OFFLINE;

ALTER TABLESPACE LVD_QDATA
    ONLINE;

alter session set "_ORACLE_SCRIPT"=true;
alter session set "_ORACLE_SCRIPT"=false;

CREATE ROLE RL_LVDPDB;
GRANT CREATE SESSION,
    CREATE TABLE,
    CREATE VIEW,
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
    DEFAULT TABLESPACE LVD_QDATA QUOTA UNLIMITED ON LVD_QDATA
    PROFILE PF_LVDPDB
    ACCOUNT UNLOCK;
ALTER USER LVDPDB QUOTA 2M ON LVD_QDATA;
GRANT RL_LVDPDB TO LVDPDB;

SELECT * fROM dba_roles;
SELECT * FROM dba_sys_privs;
SELECT * FROM dba_profiles;
SELECT username, account_status, lock_date FROM dba_users;

DROP USER LVDPDB CASCADE;
DROP PROFILE PF_LVDPDB;
DROP ROLE RL_LVDPDB;

------------------------------------------
create table LVD_T(id number(15) PRIMARY KEY,name varchar2(10))
    TABLESPACE LVD_QDATA;
    --NOROWDEPENDENCIES;
    --ROWDEPENDENCIES; -- ÚÓÚ Ò‡Ï˚È ROWSCN

insert into LVD_T values(5, 'BAddZ');
insert into LVD_T values(2, 'IBS');
insert into LVD_T values(3, 'SRG');
commit;

SELECT * FROM lvd_t;

delete lvd_t;
rollback;

drop table LVD_T PURGE; -- Û‰‡ÎÂÌËÂ ·ÂÁ ÓÚÍ‡Ú‡
drop table LVD_T;
-------------------------------------------
SELECT
    tablespace_name,
    block_size,
    initial_extent,
    initial_extent/block_size,
    extent_management,
    segment_space_management,
    bigfile
    FROM dba_tablespaces;
    
SELECT table_name, tablespace_name FROM dba_tables;

SELECT owner, segment_name, segment_type, tablespace_name, bytes, blocks, buffer_pool FROM dba_segments
WHERE tablespace_name='LVD_QDATA';

SHOW PARAMETER SEGMENT;
---------------------------------------------
SELECT table_name, tablespace_name FROM user_tables;

SELECT object_name, original_name, operation, type, ts_name, createtime, droptime FROM user_recyclebin;

FLASHBACK TABLE LVD_T TO BEFORE DROP;
---------------------------------------------
SELECT owner, segment_name, segment_type, tablespace_name, bytes, blocks, buffer_pool FROM dba_segments
WHERE tablespace_name='LVD_QDATA';

---------------------------------------------
BEGIN
FOR k IN 1..10000
loop
INSERT INTO LVD_T(id, name) VALUES(k, 'a');
END loop;
COMMIT;
END;
---------------------------------------------

SELECT owner, segment_name, segment_type, tablespace_name, extents, bytes, blocks, buffer_pool FROM dba_segments
WHERE tablespace_name='LVD_QDATAA';

SELECT * FROM dba_extents WHERE  tablespace_name = 'LVD_QDATAA';

SELECT * FROM dba_extents;

SHOW PARAMETERS DBA_EXTENTS;

----------------------------------------------
SELECT id, name, ROWID FROM LVD_T;
SELECT id, name, ORA_ROWSCN FROM LVD_T;
----------------------------------------------

--”ƒ¿À»“‹ “¿¡À»◊ÕŒ≈ œ–Œ—“–¿—“¬Œ
--”ƒ¿À»“‹ ¬—≈ ƒ¿ÕÕ€≈ œŒÀ‹«Œ¬¿“≈Àﬂ

