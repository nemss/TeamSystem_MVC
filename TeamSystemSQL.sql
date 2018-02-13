create database TeamSystemDB
go
use TeamSystemDB
go
create table Teams
(
	ID int primary key clustered identity,
	TeamName nvarchar(50) not null
)
go
create table ModelRoles
(
	ID int primary key clustered identity,
	Role nvarchar(50) not null unique
)
go
create table PersonModels
(
	ID int primary key clustered identity,
	UCN nchar(10) unique not null,
	LastName nvarchar(50) not null,
	Team_ID int not null foreign key references Teams(ID),
	ModelRole_ID int not null foreign key references ModelRoles(ID),
	FirstName nvarchar(50) not null,
	MiddleName nvarchar(50),
	BirthDate date not null,
	IsReserve bit not null
)
go
create table StartingMembersOfATeam
(
	ID int primary key clustered identity,
	Team_ID int not null unique foreign key references Teams(ID)
)
go
create table StartingPlayers
(
	Member_ID int foreign key references StartingMembersOfATeam(ID),
	Player_ID int foreign key references PersonModels(ID)
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
create table PersonHistories
(
	ID int primary key clustered identity,
	Full_Name nvarchar(100),
	PreviousTeam nvarchar(50),
	IsReserve bit,
	UpdatedDate datetime
)
go
create table MatchHistories
(
	ID int primary key clustered identity,
	MatchDate smalldatetime,
	HomeTeamPlayer nvarchar(150),
	GuestTeamPlayer nvarchar(150),
	UpdatedDate datetime
)
go
create trigger PersonAudit on PersonModels
after update
as
begin
	insert into PersonHistories
	select (d.FirstName + ' ' + d.LastName), t.TeamName, d.IsReserve, getdate()
	from deleted d,Teams t
	where d.Team_ID = t.ID
end
go
create trigger MatchAudit on Matches
after insert
as
begin
	declare @LatestDate as smalldatetime
	set @LatestDate = (select MAX(MatchDate) from Matches)

	declare @HomeTeamPlayers as table
	(
		ID int primary key identity,
		PlayerInfo nvarchar(150)
	);
	insert into @HomeTeamPlayers
	select (pm.FirstName + ' ' + pm.LastName + ' - ' + mr.Role)
	from Matches m
	join Teams t on m.HomeTeam_ID = t.ID
	join StartingMembersOfATeam sm on t.ID = sm.Team_ID
	join StartingPlayers sp on sm.ID = sp.Member_ID
	join PersonModels pm on sp.Player_ID = pm.ID
	join ModelRoles mr on pm.ModelRole_ID = mr.ID
	where m.MatchDate = @LatestDate

	declare @GuestTeamPlayers as table
	(
		ID int primary key identity,
		PlayerInfo nvarchar(150)
	);
	insert into @GuestTeamPlayers
	select (pm.FirstName + ' ' + pm.LastName + ' - ' + mr.Role)
	from Matches m
	join Teams t on m.GuestTeam_ID = t.ID
	join StartingMembersOfATeam sm on t.ID = sm.Team_ID
	join StartingPlayers sp on sm.ID = sp.Member_ID
	join PersonModels pm on sp.Player_ID = pm.ID
	join ModelRoles mr on pm.ModelRole_ID = mr.ID
	where m.MatchDate = @LatestDate
	
	insert into MatchHistories
	select @LatestDate, htp.PlayerInfo, gtp.PlayerInfo, getdate()
	from @HomeTeamPlayers htp
	join @GuestTeamPlayers gtp on htp.ID = gtp.ID
end
go

--Filling data
--insert into Teams
--values
--	('Manchester United'),
--	('Real Madrid'),
--	('Barcelona'),
--	('Chelsea'),
--	('Arsenal')
--go
--insert into ModelRoles
--values
--	('AssitantCoach'),
--	('Coach'),
--	('Doctor'),
--	('Therapist'),
--	('Player')
--go
--insert into PersonModels
--values
--		--FrontendPersons
--		('9801224522',N'Желев','1','5',      N'Александър',    N'Огнянов','1998-01-22','0'),
--		('9901144522',N'Господинова','1','5',N'Богомила-Мария',N'Жекова','1999-01-14','0'),
--		('9501254523',N'Господинов','1','5', N'Владимир',      N'Господинов','1995-01-25','0'),
--		('9601134524',N'Хараламбиев','1','5',N'Давид',         N'Валериев','1996-01-13','0'),
--		('9701214525',N'Колев','1','5',      N'Добромир',      N'Николаев','1996-01-21','0'),
--		('9702114526',N'Видева','2','5',     N'Елена',         N'Петрова','1997-02-11','0'),
--		('9202024527',N'Георгиев','2','5',   N'Иван',          N'Михайлов','1992-02-02','0'),
--		('9402034528',N'Гюрганин','2','5',   N'Калоян',        N'Юлиянов','1994-02-03','0'),
--		('9502144529',N'Гаров','2','5',      N'Константин',    N'Радосветов','1995-02-14','0'),
--		('9102134530',N'Гадълева','2','5',   N'Кристиана',     N'Красимирова','1991-02-13','0'),
--		('9203114531',N'Първанова','3','5',  N'Мирела',        N'Михайлова','1992-03-11','0'),
--		('9703124532',N'Стоянов','3','5',    N'Михаел',        N'Свиленов','1997-03-12','0'),
--		('9803174533',N'Костадинов','3','5', N'Никола',        N'Славов','1998-03-17','0'),
--		('9903194534',N'Дразова','3','5',    N'Паола',         N'Ясенова','1999-03-19','0'),
--		('9503084535',N'Недев','3','5',      N'Пламен',        N'Красимиров','1995-03-08','0'),
--		('9604134536',N'Костадинова','4','5',N'Радина',        N'Георгиева','1996-04-13','0'),
--		('9804054537',N'Петров','4','5',     N'Радостин',      N'Асенов','1998-04-05','0'),
--		('9104064538',N'Димитров','4','5',   N'Росен',         N'Детелинов','1991-04-06','0'),
--		('9404074539',N'Вараджакова','4','5',N'Стефина',       N'Николаева','1994-04-07','0'),
--		('9504214540',N'Чепов','4','5',      N'Стоян',         N'Георгиев','1995-04-21','0'),
--		('9605204541',N'Златарева','5','5',  N'Таня',          N'Мариева','1996-05-20','0'),
--		('9305114542',N'Стоев','5','5',      N'Теодор',        N'Красимиров','1993-05-11','0'),
--		('9205194543',N'Славов','5','5',     N'Филип',         N'Петков','1992-05-19','0'),
--		('9605284544',N'Велчев','5','5',     N'Филип',         N'Славей','1996-05-28','0'),
--		('9605304545',N'Тончев','5','5',     N'Христо',        N'Георгиев','1996-05-30','0'),
--		--BackendPersons					 				   
--		('8701124546',N'Филисян','1','1',    N'Александър',    N'Сисак','1987-01-12','0'),
--		('8601084547',N'Илчева','2','1',     N'Анна',          N'Миленчева','1986-01-08','0'),
--		('8501234548',N'Вълков','3','1',     N'Атанас',        N'Динков','1985-01-23','0'),
--		('8401064549',N'Цанева','4','1',     N'Вивиян',        N'Ивайло','1984-01-06','0'),
--		('8301274550',N'Кушелиев','5','1',   N'Виктор',        N'Иванов','1983-01-27','0'),
--		('7702184551',N'Ганчев','1','2',     N'Ганчо',         N'Валентинов','1977-02-18','0'),
--		('7602034552',N'Димов','2','2',      N'Георги',        N'Димитров','1976-02-03','0'),
--		('7502244553',N'Христов','3','2',    N'Димитър',       N'Николаев','1975-02-24','0'),
--		('7402174554',N'Добрева','4','2',    N'Ива',           N'Симеонова','1974-02-17','0'),
--		('7302114555',N'Нейчев','5','2',     N'Иван',          N'Колев','1973-02-11','0'),
--		('9003054556',N'Димитров','1','3',   N'Иван',          N'Стефанов','1990-03-05','0'),
--		('9103194557',N'Тумбакова','2','3',  N'Ивет',          N'Пламенова','1991-03-19','0'),
--		('9203164558',N'Кирязов','3','3',    N'Кирил',         N'Русев','1992-03-16','0'),
--		('9303224559',N'Иванов','4','3',     N'Кристиан',      N'Николов','1993-03-22','0'),
--		('8903134560',N'Зангова','5','3',    N'Кристина',      N'Валентинова','1989-03-13','0'),
--		('8704304561',N'Атанасова','1','4',  N'Кристина',      N'Веселинова','1987-04-30','0'),
--		('8604314562',N'Костова','2','4',    N'Лилия',         N'Костова','1986-04-29','0'),
--		('8504014563',N'Чакърова','3','4',   N'Лина',          N'Стефанова','1985-04-01','0'),
--		('9004044564',N'Андреева','4','4',   N'Мария',         N'Недялкова','1990-04-04','0'),
--		('9204204565',N'Ламбрев','5','4',    N'Мирослав',      N'Любомиров','1992-04-20','0')
--go
--insert into StartingMembersOfATeam
--values
--	('1'),
--	('2'),
--	('3'),
--	('4'),
--	('5')
--go
--insert into StartingPlayers
--values
--	('1','1'),
--	('1','2'),
--	('1','3'),
--	('1','4'),
--	('1','5'),
--	('1','26'),
--	('1','31'),
--	('1','36'),
--	('1','41'),
--	('2','6'),
--	('2','7'),
--	('2','8'),
--	('2','9'),
--	('2','10'),
--	('2','27'),
--	('2','32'),
--	('2','37'),
--	('2','42'),
--	('3','11'),
--	('3','12'),
--	('3','13'),
--	('3','14'),
--	('3','15'),
--	('3','28'),
--	('3','33'),
--	('3','38'),
--	('3','43'),
--	('4','16'),
--	('4','17'),
--	('4','18'),
--	('4','19'),
--	('4','20'),
--	('4','29'),
--	('4','34'),
--	('4','39'),
--	('4','44'),
--	('5','21'),
--	('5','22'),
--	('5','23'),
--	('5','24'),
--	('5','30'),
--	('5','35'),
--	('5','40'),
--	('5','45')
--go
--insert into Matches
--values
--	('2018-01-25 12:30:20','1','2','5','7'),
--	('2018-03-29 16:20:10','3','4','','')
--go
----Test queries