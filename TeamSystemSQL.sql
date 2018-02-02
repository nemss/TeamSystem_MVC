create database TeamSystemDB
go
use TeamSystemDB
go
create table Teams
(
	ID int primary key clustered identity,
	TeamName varchar(50) not null
)
go
create table ModelRoles
(
	ID int primary key clustered identity,
	Role varchar(50) not null unique
)
go
create table PersonModels
(
	ID int primary key clustered identity,
	UCN char(10) unique not null,
	LastName varchar(50) not null,
	Team_ID int not null foreign key references Teams(ID),
	ModelRole_ID int not null foreign key references ModelRoles(ID),
	FirstName varchar(50) not null,
	MiddleName varchar(50),
	BirthDate date not null
)
go
create table TeamMembers
(
	ID int primary key clustered identity,
	Team_ID int unique not null foreign key references Teams(ID),
	AssistantCoach_ID int unique not null foreign key references PersonModels(ID),
	Coach_ID int unique not null foreign key references PersonModels(ID),
	Doctor int unique not null foreign key references PersonModels(ID),
	Therapist_ID int unique not null foreign key references PersonModels(ID)
)
go
create table StartingPlayers
(
	PersonModel_ID int not null foreign key references PersonModels(ID),
	TeamMember_ID int not null foreign key references TeamMembers(ID)
)
go
create table Matches
(
	ID int primary key clustered identity,
	MatchDate smalldatetime,
	HomeTeam_ID int foreign key references Teams(ID),
	GuestTeam_ID int foreign key references Teams(ID),
	HomeTeamScore int,
	GuestTeamScore int
)
go
create table HistoryMatches
(
	ID int primary key clustered identity,
	MatchDate smalldatetime,
	HomeTeam varchar(50),
	GuestTeam varchar(50),
	HomeTeamScore int,
	GuestTeamScore int
)
go
--create trigger MatchAdded on Matches
-- for insert
--as
--begin
--	declare @MatchDate smalldatetime
--	declare @HomeTeamName varchar(50)
--	declare @GuestTeamName varchar(50)
--	declare @HomeTeamScore int
--	declare @GuestTeamScore int

--	select top 1 @MatchDate = MatchDate, @HomeTeamScore = HomeTeamScore, @GuestTeamScore = GuestTeamScore
--	from Matches
--	order by MatchDate desc

--	select top 1 @HomeTeamName = t.TeamName
--	from Matches m , Teams t
--	where m.HomeTeam_ID = t.ID

--	select top 1 @GuestTeamName = t.TeamName
--	from Matches m , Teams t
--	where m.GuestTeam_ID = t.ID

--	insert into HistoryMatches
--	values
--	(
--		@MatchDate,
--		@HomeTeamName,
--		@GuestTeamName,
--		@HomeTeamScore,
--		@GuestTeamScore
--	)
--end

--Filling data
insert into Teams
values
	('Manchester United'),
	('Real Madrid'),
	('Barcelona'),
	('Chelsea'),
	('Arsenal')
go
insert into ModelRoles
values
	('AssitantCoach'),
	('Coach'),
	('Doctor'),
	('Therapist'),
	('Player')
go
insert into PersonModels
values
		('9801224522','Желев','1','5','Александър','Огнянов','1998-01-22'),
		('9901144522','Господинова','1','5','Богомила-Мария','Жекова','1999-01-14'),
		('9501254523','Господинов','1','5','Владимир','Господинов','1995-01-25'),
		('9601134524','Хараламбиев','1','5','Давид','Валериев','1996-01-13'),
		('9701214525','Колев','1','5','Добромир','Николаев','1996-01-21'),
		('9702114526','Видева','2','5','Елена','Петрова','1997-02-11'),
		('9202024527','Георгиев','2','5','Иван','Михайлов','1992-02-02'),
		('9402034528','Гюрганин','2','5','Калоян','Юлиянов','1994-02-03'),
		('9502144529','Гаров','2','5','Константин','Радосветов','1995-02-14'),
		('9102134530','Гадълева','2','5','Кристиана','Красимирова','1991-02-13'),
		('9203114531','Първанова','3','5','Мирела','Михайлова','1992-03-11'),
		('9703124532','Стоянов','3','5','Михаел','Свиленов','1997-03-12'),
		('9803174533','Костадинов','3','5','Никола','Славов','1998-03-17'),
		('9903194534','Дразова','3','5','Паола','Ясенова','1999-03-19'),
		('9503084535','Недев','3','5','Пламен','Красимиров','1995-03-08'),
		('9604134536','Костадинова','4','5','Радина','Георгиева','1996-04-13'),
		('9804054537','Петров','4','5','Радостин','Асенов','1998-04-05'),
		('9104064538','Димитров','4','5','Росен','Детелинов','1991-04-06'),
		('9404074539','Вараджакова','4','5','Стефина','Николаева','1994-04-07'),
		('9504214540','Чепов','4','5','Стоян','Георгиев','1995-04-21'),
		('9605204541','Златарева','5','5','Таня','Мариева','1996-05-20'),
		('9305114542','Стоев','5','5','Теодор','Красимиров','1993-05-11'),
		('9205194543','Славов','5','5','Филип','Петков','1992-05-19'),
		('9605284544','Велчев','5','5','Филип','Славей','1996-05-28'),
		('9605304545','Тончев','5','5','Христо','Георгиев','1996-05-30'),

		('8701124546','Mechkov','1','1','Simeon','Georgiev','1987-01-12'),
		('8601084547','Mechkov','2','1','Simeon','Georgiev','1986-01-08'),
		('8501234548','Mechkov','3','1','Simeon','Georgiev','1985-01-23'),
		('8401064549','Mechkov','4','1','Simeon','Georgiev','1984-01-06'),
		('8301274550','Mechkov','5','1','Simeon','Georgiev','1983-01-27'),
		('7702184551','Mechkov','1','2','Simeon','Georgiev','1977-02-18'),
		('7602034552','Mechkov','2','2','Simeon','Georgiev','1976-02-03'),
		('7502244553','Mechkov','3','2','Simeon','Georgiev','1975-02-24'),
		('7402174554','Mechkov','4','2','Simeon','Georgiev','1974-02-17'),
		('7302114555','Mechkov','5','2','Simeon','Georgiev','1973-02-11'),
		('9003054556','Mechkov','1','3','Simeon','Georgiev','1990-03-05'),
		('9103194557','Mechkov','2','3','Simeon','Georgiev','1991-03-19'),
		('9203164558','Mechkov','3','3','Simeon','Georgiev','1992-03-16'),
		('9303224559','Mechkov','4','3','Simeon','Georgiev','1993-03-22'),
		('8903134560','Mechkov','5','3','Simeon','Georgiev','1989-03-13'),
		('8704304561','Mechkov','1','4','Simeon','Georgiev','1987-04-30'),
		('8604314562','Mechkov','2','4','Simeon','Georgiev','1986-04-31'),
		('8504014563','Mechkov','3','4','Simeon','Georgiev','1985-04-01'),
		('9004044564','Mechkov','4','4','Simeon','Georgiev','1990-04-04'),
		('9204204565','Mechkov','5','4','Simeon','Georgiev','1992-04-20')
go
insert into Matches
values('2018-01-25','1','2','5','7')
insert into Matches
values('2018-01-31','2','1','9','3')
go


--Test queries
select *
from HistoryMatches

--select pm.UCN,(pm.FirstName + ' ' + pm.SurName + ' ' + pm.LastName) as Full_Name,pm.BirthDate
--from Matches m,Teams t,TeamMembers tm,Players p,PersonModels pm
--where m.HomeTeam_ID = t.ID and tm.Team_ID = t.ID and p.TeamMember_ID = tm.ID and p.PersonModel_ID = pm.ID and m.MatchDate = '2018-01-25'
