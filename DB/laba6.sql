ALTER SYSTEM SET OPEN_CURSORS=300 SCOPE= SPFILE;

SELECT name, value FROM v$parameter WHERE name='open_cursors';

CREATE PFILE = 'LVD_PFILE.ora' FROM SPFILE;

CREATE SPFILE = 'SPFILEORCL1.ora' FROM PFILE='LVD_PFILE.ora';

SELECT name, value FROM v$parameter WHERE name='open_cursors';

CREATE PFILE = 'C:\app\orcl_wald\product\12.1.0\dbhome_1\database\LVD_PFILE.ora' FROM MEMORY; --из init

SHOW PARAMETER SPFILE;
----------------------------------------------------------------
SELECT  name FROM v$controlfile;

SELECT type, record_size, records_total FROM v$controlfile_record_section;

ALTER DATABASE BACKUP CONTROLFILE TO TRACE;
--C:\app\orcl_wald\diag\rdbms\orcl\orcl
----------------------------------------------------------------
SELECT * FROM v$pwfile_users;
----------------------------------------------------------------
SELECT * FROM v$diag_info;
--Oracle Trace Ч это продукт общего назначени€ дл€ сбора данных, управл€емый событи€ми,
--  который сервер Oracle использует дл€ сбора данных о производительности и использовании ресурсов,
--  таких как статистика синтаксического анализа, выполнени€ и выборки SQL, а также статистика ожидани€.

-- ¬ќ——“јЌќ¬»“№ »«Ќј„јЋ№Ќџ≈ ѕј–јћ≈“–џ Ѕј«џ ƒјЌЌџ’ OPEN_CURSORS=300
-- ”ƒјЋ»“№ PFILE и SPFILE
-- ”ƒјЋ»“№ — –»ѕ“ »«ћ≈Ќ≈Ќ»я ”ѕ–ј¬Ћ≈Ќ»я