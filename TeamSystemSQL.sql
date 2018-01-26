create database TeamSystem
go
use TeamSystem
go
create table Teams
(
	ID int primary key identity,
	TeamName varchar(50) not null
)
create table PersonModels
(
	ID int primary key identity,
	UCN char(10) unique not null,
	FirstName varchar(50) not null,
	SurName varchar(50),
	LastName varchar(50) not null,
	BirthDate date not null
)
--create table StartingMembers
--(
--	ID int primary key identity,
--	Team_ID int unique not null foreign key references Teams(ID)
--)
create table Players
(
	ID int primary key identity,
	PersonModel_ID int unique not null foreign key references PersonModels(ID) on delete cascade,
	Team_ID int foreign key references Teams(ID) on delete cascade
	--StartingMembers_ID int not null foreign key references StartingMembers(ID) on delete cascade
)
create table Coaches
(
	ID int primary key identity,
	PersonModel_ID int unique not null foreign key references PersonModels(ID) on delete cascade,
	Team_ID int unique foreign key references Teams(ID) on delete cascade
	--StartingMembers_ID int unique foreign key references StartingMembers(ID) on delete cascade
)
create table AssistentCoaches
(
	ID int primary key identity,
	PersonModel_ID int unique not null foreign key references PersonModels(ID) on delete cascade,
	Team_ID int unique foreign key references Teams(ID) on delete cascade
	--StartingMembers_ID int unique foreign key references StartingMembers(ID) on delete cascade
)
create table Doctors
(
	ID int primary key identity,
	PersonModel_ID int unique not null foreign key references PersonModels(ID) on delete cascade,
	Team_ID int unique foreign key references Teams(ID) on delete cascade
	--StartingMembers_ID int unique foreign key references StartingMembers(ID) on delete cascade
)
create table Therapists
(
	ID int primary key identity,
	PersonModel_ID int unique not null foreign key references PersonModels(ID) on delete cascade,
	Team_ID int unique foreign key references Teams(ID) on delete cascade
	--StartingMembers_ID int unique foreign key references StartingMembers(ID) on delete cascade
)