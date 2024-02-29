CREATE TABLE AUTHORS(
ID_AUTHOR INT PRIMARY KEY,
FIO NVARCHAR(100)
);

INSERT INTO AUTHORS(ID_AUTHOR, FIO)
VALUES (1, 'Кальчевский Даниил Андреевич'),
(2, 'Потапович Алексей Викторович'),
(3, 'Эльзаров Урмат Эльзарович'),
(4, 'Гончаров Иван Александрович'),
(5, 'Достоевский Фёдор Михайлович'),
(6, 'Тургенев Иван Сергеевич'),
(7, 'Гоголь Николай Васильевич'),
(8, 'Бунин Иван Алексеевич'),
(9, 'Пушкин Александр Сергеевич'),
(10, 'Ахматова Анна Андреевна');

SELECT * FROM AUTHORS;

CREATE TABLE BOOKS(
ID_BOOK INT PRIMARY KEY,
NAME_BOOK NVARCHAR(50),
ID_AUTHOR INT FOREIGN KEY REFERENCES AUTHORS(ID_AUTHOR),
THE_YEAR_OF_PUBLISHING SMALLINT,
COUNT_BOOKS SMALLINT
);

INSERT INTO BOOKS(ID_BOOK, NAME_BOOK, ID_AUTHOR, THE_YEAR_OF_PUBLISHING, COUNT_BOOKS)
VALUES(1, 'Как стать миллионером', 9, 2012, 100),
(2, 'Три мушкетера', 8, 2011, 100),
(3, 'Братья Карамазовы', 7, 2008, 200),
(4, 'Горе от ума', 6, 2015, 150),
(5, 'Воскресение', 5, 2017, 300),
(6, 'Робинзон Крузо', 10, 2010, 120),
(7, 'Вишневый сад', 4, 2009, 125),
(8, 'Дядя Ваня', 3, 2008, 110),
(9, 'Чайка', 2, 2012, 80),
(10, '1984', 1, 2019, 50);

SELECT * FROM BOOKS;

CREATE TABLE READERS(
READER_TICKET INT PRIMARY KEY,
FIO NVARCHAR(100),
ADDRESS_READERS NVARCHAR(50),
TELEPHONE NVARCHAR(13)
);

INSERT INTO READERS(READER_TICKET, FIO, ADDRESS_READERS, TELEPHONE)
VALUES (123, 'Ершов Фёдор Дмитриевич', 'Россия', '445403394'),
(345, 'Петрова Ева Фёдоровна', 'Беларусь', '296704783'),
(678, 'Большаков Денис Владимирович', 'Украина', '294583901'),
(901, 'Селезнев Иван Николаевич', 'Молдова', '441094357'),
(234, 'Царев Леон Андреевич', 'Казахстан', '294316976'),
(456, 'Панфилов Дмитрий Егорович', 'Узбекистан', '294300596'),
(789, 'Орлов Матвей Михайлович', 'Киргизия', '441234987'),
(012, 'Назаров Леон Степанович', 'Пакистан', '298543215'),
(231, 'Рыжова Дарья Фёдоровна', 'Англия', '446954320'),
(954, 'Олейникова Вероника Данииловна', 'США', '298456120');

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
