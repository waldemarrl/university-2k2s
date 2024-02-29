CREATE TABLE AUTHORS(
ID_AUTHOR INT PRIMARY KEY,
FIO NVARCHAR(100)
);

INSERT INTO AUTHORS(ID_AUTHOR, FIO)
VALUES (1, '����������� ������ ���������'),
(2, '��������� ������� ����������'),
(3, '�������� ����� ����������'),
(4, '�������� ���� �������������'),
(5, '����������� Ը��� ����������'),
(6, '�������� ���� ���������'),
(7, '������ ������� ����������'),
(8, '����� ���� ����������'),
(9, '������ ��������� ���������'),
(10, '�������� ���� ���������');

SELECT * FROM AUTHORS;

CREATE TABLE BOOKS(
ID_BOOK INT PRIMARY KEY,
NAME_BOOK NVARCHAR(50),
ID_AUTHOR INT FOREIGN KEY REFERENCES AUTHORS(ID_AUTHOR),
THE_YEAR_OF_PUBLISHING SMALLINT,
COUNT_BOOKS SMALLINT
);

INSERT INTO BOOKS(ID_BOOK, NAME_BOOK, ID_AUTHOR, THE_YEAR_OF_PUBLISHING, COUNT_BOOKS)
VALUES(1, '��� ����� �����������', 9, 2012, 100),
(2, '��� ���������', 8, 2011, 100),
(3, '������ ����������', 7, 2008, 200),
(4, '���� �� ���', 6, 2015, 150),
(5, '�����������', 5, 2017, 300),
(6, '�������� �����', 10, 2010, 120),
(7, '�������� ���', 4, 2009, 125),
(8, '���� ����', 3, 2008, 110),
(9, '�����', 2, 2012, 80),
(10, '1984', 1, 2019, 50);

SELECT * FROM BOOKS;

CREATE TABLE READERS(
READER_TICKET INT PRIMARY KEY,
FIO NVARCHAR(100),
ADDRESS_READERS NVARCHAR(50),
TELEPHONE NVARCHAR(13)
);

INSERT INTO READERS(READER_TICKET, FIO, ADDRESS_READERS, TELEPHONE)
VALUES (123, '����� Ը��� ����������', '������', '445403394'),
(345, '������� ��� Ը�������', '��������', '296704783'),
(678, '��������� ����� ������������', '�������', '294583901'),
(901, '�������� ���� ����������', '�������', '441094357'),
(234, '����� ���� ���������', '���������', '294316976'),
(456, '�������� ������� ��������', '����������', '294300596'),
(789, '����� ������ ����������', '��������', '441234987'),
(012, '������� ���� ����������', '��������', '298543215'),
(231, '������ ����� Ը�������', '������', '446954320'),
(954, '���������� �������� ����������', '���', '298456120');

SELECT * FROM READERS;

CREATE TABLE EDITION(
ID_EDITION INT PRIMARY KEY,
ID_BOOK INT FOREIGN KEY REFERENCES BOOKS(ID_BOOK),
DATE_EDITION SMALLINT,
DATE_SURRENDER SMALLINT,
READER_TICKET INT FOREIGN KEY REFERENCES READERS(READER_TICKET),
);

INSERT INTO EDITION(ID_EDITION, ID_BOOK, DATE_EDITION, DATE_SURRENDER, READER_TICKET)
VALUES (2, 1, 2012, 2013, 123), 
(3, 3, 2008, 2009, 123), 
(4, 4, 2015, 2016, 123), 
(5, 5, 2017, 2018, 123), 
(6, 6, 2010, 2011, 123), 
(7, 7, 2009, 2010, 123), 
(8, 8, 2008, 2009, 123), 
(9, 9, 2012, 2013, 123), 
(10, 10, 2019, 2020, 123), 
(1, 2, 2011, 2012, 123);

SELECT * FROM EDITION;
