create table LVD_t(x number(3), s varchar2(50), constraint pr_d primary key (x));

insert into LVD_t values(6, 'one');
insert into LVD_t values(7, 'two');
insert into LVD_t values(3, 'three');
commit;

select * from LVD_t;

update LVD_t set x=1 where s='one';
update LVD_t set x=2 where s='two';
commit;

select * from LVD_t where x=3;

delete from LVD_t where s='three';
commit;

create table LVD_t1(x number(3),  d varchar(50), constraint fk_d foreign key(x) references LVD_t(x));
insert into LVD_t1 values(1, '1');
insert into LVD_t1 values(2, '2');

select * from LVD_t1;

select * from LVD_t left outer join LVD_t1 
on LVD_t.x=LVD_t1.x;

select * from LVD_t right outer join LVD_t1 
on LVD_t.x=LVD_t1.x;

select * from LVD_t inner join LVD_t1 
on LVD_t.x=LVD_t1.x;

drop table LVD_t1;
drop table LVD_t;