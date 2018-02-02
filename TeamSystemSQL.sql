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
		('9701314522','Mechkov','1','5','Simeon','Georgiev','1997-01-31'),
		('9701314522','Mechkov','1','5','Simeon','Georgiev','1997-01-31'),
		('9701314523','Mechkov','1','5','Simeon','Georgiev','1997-01-31'),
		('9701314524','Mechkov','1','5','Simeon','Georgiev','1997-01-31'),
		('9701314525','Mechkov','1','5','Simeon','Georgiev','1997-01-31'),
		('9701314526','Mechkov','2','5','Simeon','Georgiev','1997-01-31'),
		('9701314527','Mechkov','2','5','Simeon','Georgiev','1997-01-31'),
		('9701314528','Mechkov','2','5','Simeon','Georgiev','1997-01-31'),
		('9701314529','Mechkov','2','5','Simeon','Georgiev','1997-01-31'),
		('9701314530','Mechkov','2','5','Simeon','Georgiev','1997-01-31'),
		('9701314531','Mechkov','3','5','Simeon','Georgiev','1997-01-31'),
		('9701314532','Mechkov','3','5','Simeon','Georgiev','1997-01-31'),
		('9701314533','Mechkov','3','5','Simeon','Georgiev','1997-01-31'),
		('9701314534','Mechkov','3','5','Simeon','Georgiev','1997-01-31'),
		('9701314535','Mechkov','3','5','Simeon','Georgiev','1997-01-31'),
		('9701314536','Mechkov','4','5','Simeon','Georgiev','1997-01-31'),
		('9701314537','Mechkov','4','5','Simeon','Georgiev','1997-01-31'),
		('9701314538','Mechkov','4','5','Simeon','Georgiev','1997-01-31'),
		('9701314539','Mechkov','4','5','Simeon','Georgiev','1997-01-31'),
		('9701314540','Mechkov','4','5','Simeon','Georgiev','1997-01-31'),
		('9701314541','Mechkov','5','5','Simeon','Georgiev','1997-01-31'),
		('9701314542','Mechkov','5','5','Simeon','Georgiev','1997-01-31'),
		('9701314543','Mechkov','5','5','Simeon','Georgiev','1997-01-31'),
		('9701314544','Mechkov','5','5','Simeon','Georgiev','1997-01-31'),
		('9701314545','Mechkov','5','5','Simeon','Georgiev','1997-01-31'),

		('9701314546','Mechkov','1','1','Simeon','Georgiev','1997-01-31'),
		('9701314547','Mechkov','2','1','Simeon','Georgiev','1997-01-31'),
		('9701314548','Mechkov','3','1','Simeon','Georgiev','1997-01-31'),
		('9701314549','Mechkov','4','1','Simeon','Georgiev','1997-01-31'),
		('9701314550','Mechkov','5','1','Simeon','Georgiev','1997-01-31'),
		('9701314551','Mechkov','1','2','Simeon','Georgiev','1997-01-31'),
		('9701314552','Mechkov','2','2','Simeon','Georgiev','1997-01-31'),
		('9701314553','Mechkov','3','2','Simeon','Georgiev','1997-01-31'),
		('9701314554','Mechkov','4','2','Simeon','Georgiev','1997-01-31'),
		('9701314555','Mechkov','5','2','Simeon','Georgiev','1997-01-31'),
		('9701314556','Mechkov','1','3','Simeon','Georgiev','1997-01-31'),
		('9701314557','Mechkov','2','3','Simeon','Georgiev','1997-01-31'),
		('9701314558','Mechkov','3','3','Simeon','Georgiev','1997-01-31'),
		('9701314559','Mechkov','4','3','Simeon','Georgiev','1997-01-31'),
		('9701314560','Mechkov','5','3','Simeon','Georgiev','1997-01-31'),
		('9701314561','Mechkov','1','4','Simeon','Georgiev','1997-01-31'),
		('9701314562','Mechkov','2','4','Simeon','Georgiev','1997-01-31'),
		('9701314563','Mechkov','3','4','Simeon','Georgiev','1997-01-31'),
		('9701314564','Mechkov','4','4','Simeon','Georgiev','1997-01-31'),
		('9701314565','Mechkov','5','4','Simeon','Georgiev','1997-01-31')
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
