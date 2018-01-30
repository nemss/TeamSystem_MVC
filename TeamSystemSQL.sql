create database TeamSystemDB
go
use TeamSystemDB
go
create table Teams
(
	ID int primary key identity,
	TeamName varchar(50) not null
)
go
create table TeamMembers
(
	ID int primary key identity,
	Team_ID int unique not null foreign key references Teams(ID)
)
go
create table PersonModels
(
	ID int primary key identity,
	UCN char(10) unique not null,
	FirstName varchar(50) not null,
	SurName varchar(50),
	LastName varchar(50) not null,
	BirthDate date not null
)
go
create table Players
(
	ID int primary key identity,
	PersonModel_ID int unique not null foreign key references PersonModels(ID) on delete cascade,
	TeamMember_ID int foreign key references TeamMembers(ID)
)
go
create table Coaches
(
	ID int primary key identity,
	PersonModel_ID int unique not null foreign key references PersonModels(ID) on delete cascade,
	TeamMember_ID int unique foreign key references TeamMembers(ID)
)
go
create table AssistentCoaches
(
	ID int primary key identity,
	PersonModel_ID int unique not null foreign key references PersonModels(ID) on delete cascade,
	TeamMember_ID int unique foreign key references TeamMembers(ID)
)
go
create table Doctors
(
	ID int primary key identity,
	PersonModel_ID int unique not null foreign key references PersonModels(ID) on delete cascade,
	TeamMember_ID int unique foreign key references TeamMembers(ID)
)
go
create table Therapists
(
	ID int primary key identity,
	PersonModel_ID int unique not null foreign key references PersonModels(ID) on delete cascade,
	TeamMember_ID int unique foreign key references TeamMembers(ID)
)
go
create table Matches
(
	ID int primary key identity,
	Result varchar(7),
	MatchDate smalldatetime,
	HomeTeam_ID int foreign key references Teams(ID),
	GuestTeam_ID int foreign key references Teams(ID)
)
go

--Filling data
insert into Teams
values('Barcelona')
insert into Teams
values('Real Madrid')
insert into Teams
values('Manchester United')
go
insert into TeamMembers
values('2')
insert into TeamMembers
values('3')
go
insert into PersonModels
values('9701314522','Simeon','Georgiev','Mechkov','1997-01-31')
insert into PersonModels
values('9701314523','Valenti','Spasimirov','Parvanov','1993-02-23')
insert into PersonModels
values('9701314524','Ivan','Rosenov','Ivanov','1992-03-15')
insert into PersonModels
values('9701314525','Boris','Krasimirov','Tiutiukov','1996-05-18')
insert into PersonModels
values('9701314526','Tinko','Spasov','Boqdjiev','1998-04-27')
insert into PersonModels
values('9701314527','Nikolay','Tsvetanov','Tanchev','1991-06-22')
insert into PersonModels
values('9701314528','Georgi','Vaklinov','Vaklinov','1990-07-01')
insert into PersonModels
values('9701314529','Rosen','Detelinov','Dimitrov','1989-08-07')
insert into PersonModels
values('9701314530','Stoqn','Georgiev','Chepov','1988-09-13')
insert into PersonModels
values('9701314531','Filip','Petkov','Slavov','1987-10-09')
insert into PersonModels
values('9701314532','Kolio','Cukata','Petrovich','1969-06-11')
go
insert into AssistentCoaches
values('1','1')
insert into AssistentCoaches
values('2','2')
insert into Coaches
values('3','1')
insert into Coaches
values('4','2')
insert into Doctors
values('5','1')
insert into Doctors
values('6','2')
insert into Therapists
values('7','1')
insert into Therapists
values('8','2')
insert into Players
values('9','1')
insert into Players
values('10','2')
insert into Players
values('11','1')
go
insert into Matches
values('','2018-01-25','2','3')
insert into Matches
values('','2018-01-31','3','2')
go

--Test queries
select pm.UCN,(pm.FirstName + ' ' + pm.SurName + ' ' + pm.LastName) as Full_Name,pm.BirthDate
from Matches m,Teams t,TeamMembers tm,Players p,PersonModels pm
where m.HomeTeam_ID = t.ID and tm.Team_ID = t.ID and p.TeamMember_ID = tm.ID and p.PersonModel_ID = pm.ID and m.MatchDate = '2018-01-25'