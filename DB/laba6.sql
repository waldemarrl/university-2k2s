ALTER SYSTEM SET OPEN_CURSORS=300 SCOPE= SPFILE;

SELECT name, value FROM v$parameter WHERE name='open_cursors';

CREATE PFILE = 'LVD_PFILE.ora' FROM SPFILE;

CREATE SPFILE = 'SPFILEORCL1.ora' FROM PFILE='LVD_PFILE.ora';

SELECT name, value FROM v$parameter WHERE name='open_cursors';

CREATE PFILE = 'C:\app\orcl_wald\product\12.1.0\dbhome_1\database\LVD_PFILE.ora' FROM MEMORY; --�� init

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
--Oracle Trace � ��� ������� ������ ���������� ��� ����� ������, ����������� ���������,
--  ������� ������ Oracle ���������� ��� ����� ������ � ������������������ � ������������� ��������,
--  ����� ��� ���������� ��������������� �������, ���������� � ������� SQL, � ����� ���������� ��������.

-- ������������ ����������� ��������� ���� ������ OPEN_CURSORS=300
-- ������� PFILE � SPFILE
-- ������� ������ ��������� ����������