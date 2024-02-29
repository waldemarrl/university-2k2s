SELECT name, open_mode, total_size FROM v$pdbs;

CREATE TABLESPACE TSPDB_LVD
    DATAFILE 'C:\app\orcl_wald\Tablespace\TSPDB_LVD.dbf'
    SIZE 7M
    AUTOEXTEND ON NEXT 5M
    MAXSIZE 30M
    EXTENT MANAGEMENT LOCAL;

DROP TABLESPACE TSPDB_LVD;

CREATE TEMPORARY TABLESPACE TSPDB_TEMP_LVD
    TEMPFILE 'C:\app\orcl_wald\Tablespace\TSPDB_TEMP_LVD.dbf'
    SIZE 5M
    AUTOEXTEND ON NEXT 3M
    MAXSIZE 20M
    EXTENT MANAGEMENT LOCAL;

DROP TABLESPACE TSPDB_TEMP_LVD;

SELECT TABLESPACE_NAME, STATUS, contents loggin from SYS.DBA_TABLESPACES;

SELECT FILE_NAME, TABLESPACE_NAME, STATUS, MAXBYTES, USER_BYTES FROM DBA_DATA_FILES
UNION
SELECT FILE_NAME, TABLESPACE_NAME, STATUS, MAXBYTES, USER_BYTES FROM DBA_TEMP_FILES;

alter session set "_ORACLE_SCRIPT"=true;
alter session set "_ORACLE_SCRIPT"=false;

CREATE ROLE RL_LVDPDB;

SELECT * fROM dba_roles WHERE ROLE LIKE 'RL%';
SELECT * fROM dba_roles;

DROP ROLE RL_LVDPDB;

GRANT CREATE SESSION,
    CREATE TABLE,
    CREATE VIEW,
    CREATE PROCEDURE TO RL_LVDPDB;

SELECT * FROM dba_sys_privs WHERE grantee = 'RL_LVDPDB';
SELECT * FROM dba_sys_privs;

CREATE PROFILE PF_LVDPDB LIMIT
    PASSWORD_LIFE_TIME 180
    SESSIONS_PER_USER 3
    FAILED_LOGIN_ATTEMPTS 7
    PASSWORD_LOCK_TIME 1
    PASSWORD_REUSE_TIME 10
    PASSWORD_GRACE_TIME DEFAULT
    CONNECT_TIME 180
    IDLE_TIME 30;
    
DROP PROFILE PF_LVDPDB;

SELECT * FROM dba_profiles WHERE PROFILE = 'PF_LVDPDB';
SELECT * FROM dba_profiles WHERE PROFILE = 'DEFAULT';

CREATE USER LVDPDB IDENTIFIED BY 12345
    DEFAULT TABLESPACE TS_LVD QUOTA UNLIMITED ON TSPDB_LVD
    TEMPORARY TABLESPACE TSPDB_TEMP_LVD
    PROFILE PF_LVDPDB
    ACCOUNT UNLOCK 
    PASSWORD EXPIRE;
    
ALTER USER LVDPDB QUOTA 2M ON TSPDB_LVD;

GRANT RL_LVDPDB TO LVDPDB;

DROP USER LVDPDB;

-------------------------------
SELECT name, open_mode, total_size FROM v$pdbs;

SELECT object_name, owner,  status FROM dba_objects; 

SELECT TABLESPACE_NAME, sTATUS, CONTENTS LOGGING FROM SYS.dba_tablespaces;

SELECT file_name, tablespace_name, status, maxbytes, user_bytes FROM dba_data_files
UNION
SELECT file_name, tablespace_name, status, maxbytes, user_bytes FROM dba_temp_files;

SELECT * FROM dba_roles;

SELECT * FROM dba_profiles;

SELECT username, account_status, lock_date FROM dba_users;

SELECT USERNAME
FROM v$session
WHERE username IS NOT NULL
GROUP BY USERNAME;

SELECT username, account_status, lock_date FROM dba_users;
----------------------------

create user c##lvd identified by 75980;
grant create session, create table, create view, create procedure to c##lvd;
connect lvd_pdb_admin/75980@//localhost:1521/lvd_pdb.be.by as sysdba;
connect c##lvd/75980@//localhost:1521/orcl.be.by;
connect c##lvd/75980@//localhost:1521/lvd_pdb.be.by;

