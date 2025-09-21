create database ZelisTrainingDB
use ZelisTrainingDB

create table Employee(
EmpId int primary key,
EmpName varchar(30),
Designation varchar(30),
EmpEmail varchar(40),
EmpPhoneNo varchar(10))

create table Technology(
TechnologyId int primary key,
TechnologyName varchar(30),
Level char check (Level in ('B','I','A')),
Duration int)

create table Trainer(
TrainerId int primary key,
TrainerName varchar(30),
TrainerType char check (TrainerType in ('I','E')),
TrainerEmail varchar(40),
TrainerPhoneNo varchar(10))

create table Training(
TrainingId int primary key,
TrainerId int references Trainer(TrainerId),
TechnologyId int references Technology(TechnologyId),
StartDate DateTime,
EndDate DateTime)

create table Trainee(
TrainingId int references Training(TrainingId),
EmpId int references Employee(EmpId),
Status char check (Status in ('C','N')),
primary key (TrainingId, EmpId)
)


