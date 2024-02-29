SELECT * FROM v$sga;

SELECT sum(value) FROM v$sga;

SELECT 
    component,
    max_size, 
    last_oper_mode,
    last_oper_time,
    granule_size,
    current_size/granule_size as Ratio
FROM v$sga_dynamic_components
where current_size > 0;

SELECT * FROM v$sgastat; 

SELECT
    sum(min_size),
    sum(max_size),
    sum(current_size)
FROM v$sga_dynamic_components;

SELECT * FROM v$sga_dynamic_free_memory;
SELECT sum(bytes) FROM v$sgastat where name='free memory'; 

show parameter sga;

SELECT 
    component,
    min_size,
    current_size
FROM  v$sga_dynamic_components;

CREATE TABLE LVD(k int) STORAGE(buffer_pool keep);
CREATE TABLE WAL(k int) STORAGE(buffer_pool DEFAULT);
INSERT INTO LVD VALUES(1);
INSERT INTO WAL VALUES(1);
commit;

DROP TABLE LVD;
DROP TABLE WAL;

SELECT segment_name, segment_type, tablespace_name, buffer_pool FROM user_segments
WHERE segment_name in ('LVD', 'WAL');

SHOW PARAMETER log_buffer;

SELECT name, value FROM v$sysstat WHERE name LIKE '%redo%retries' ;

SELECT pool, name, bytes FROM v$sgastat WHERE pool='large pool';

SELECT username, service_name, server FROM v$session WHERE username is not null;

SELECT name, network_name, pdb FROM v$services;
SELECT * FROM V$BGPROCESS;
SELECT * FROM V$PROCESS;
------------------------------------
lsnrctl.exe
help
--C:\app\orcl_wald\product\12.1.0\dbhome_1\NETWORK\ADMIN
------------------------------------





