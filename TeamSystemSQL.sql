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
	SurName varchar(50),
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
create trigger MatchAdded on Matches
 for insert
as
begin
	declare @MatchDate smalldatetime
	declare @HomeTeamName varchar(50)
	declare @GuestTeamName varchar(50)
	declare @HomeTeamScore int
	declare @GuestTeamScore int

	select top 1 @MatchDate = MatchDate, @HomeTeamScore = HomeTeamScore, @GuestTeamScore = GuestTeamScore
	from Matches
	order by MatchDate desc

	select top 1 @HomeTeamName = t.TeamName
	from Matches m , Teams t
	where m.HomeTeam_ID = t.ID

	select top 1 @GuestTeamName = t.TeamName
	from Matches m , Teams t
	where m.GuestTeam_ID = t.ID

	insert into HistoryMatches
	values
	(
		@MatchDate,
		@HomeTeamName,
		@GuestTeamName,
		@HomeTeamScore,
		@GuestTeamScore
	)
end

--Filling data
insert into Teams
values('Manchester United')
insert into Teams
values('Real Madrid')
insert into Teams
values('Barcelona')
go
insert into ModelRoles
values('AssitantCoach')
insert into ModelRoles
values('Coach')
insert into ModelRoles
values('Doctor')
insert into ModelRoles
values('Therapist')
insert into ModelRoles
values('Player')
go
insert into PersonModels
values('9701314522','Mechkov','2','5','Simeon','Georgiev','1997-01-31')
insert into PersonModels
values('9701304523','Purvanov','2','5','Valentin','Spasimirov','1997-01-30')
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