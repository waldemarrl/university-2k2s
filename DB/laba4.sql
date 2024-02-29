SELECT TABLESPACE_NAME, STATUS, CONTENTS LOGGING FROM SYS.dba_tablespaces;

SELECT * FROM v$logfile;

SELECT group#, status, members FROM v$log;

SELECT * FROM v$log;

ALTER DATABASE ADD LOGFILE GROUP 4 'C:\app\orcl_wald\oradata\orcl\REDO04.LOG'
    SIZE 50M BLOCKSIZE 512;
SELECT group#, sequence#, bytes,status, members, first_change# FROM v$log;

ALTER DATABASE ADD LOGFILE MEMBER 'C:\app\orcl_wald\oradata\orcl\REDO041.LOG' TO GROUP 4;
SELECT group#, sequence#, bytes,status, members, first_change# FROM v$log;

ALTER SYSTEM SWITCH LOGFILE;
SELECT group#, sequence#, bytes,status, members, first_change# FROM v$log;

ALTER DATABASE DROP LOGFILE MEMBER 'C:\app\orcl_wald\oradata\orcl\REDO041.LOG';
SELECT group#, sequence#, bytes,status, members, first_change# FROM v$log;

ALTER DATABASE DROP LOGFILE MEMBER 'C:\app\orcl_wald\oradata\orcl\REDO04.LOG';
SELECT group#, sequence#, bytes,status, members, first_change# FROM v$log;

ALTER DATABASE DROP LOGFILE GROUP 4;
SELECT group#, sequence#, bytes,status, members, first_change# FROM v$log;

SELECT name, log_mode FROM v$database;

SELECT instance_name, archiver, active_state FROM v$instance;

SELECT * FROM v$log;

ALTER SYSTEM SWITCH LOGFILE;
SELECT * FROM v$archived_log;
SELECT group#, sequence#, bytes,status, members, first_change# FROM v$log;

ARCHIVE LOG LIST;
SHOW PARAMETER DB_RECOVERY;

SELECT instance_name, archiver, active_state FROM v$instance;
-------------------------------
shutdown immediate;
startup mount;
--alter database archivelog;
--alter database noarchivelog;
alter database open;
-------------------------------
SHOW PARAMETER CONTROL;

SELECT name FROM v$controlfile;

SELECT type, record_size, records_total FROM v$controlfile_record_section;

--¬€ Àﬁ◊»“‹ ¿–’»¬¿÷»ﬁ
--”ƒ¿À»“‹ LOG-‘¿…À€
--”ƒ¿À»“‹ √–”œœ”