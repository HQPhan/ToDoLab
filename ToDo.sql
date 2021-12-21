-- create database ToDo;
create table Employee(
Id int primary key auto_increment not null,
`Name` nvarchar(20),
 Hours int check (hours <= 40),
 Title nvarchar(40)
);
insert into Employee 
values(0,'Elizabeth Loudmouth',40,'Auditor'),
(0,'Tom Sawyer',40,'Resolution Analyst'),
(0,'Bobby Bowie',40,'Underwriter'),
(0,'Freddy Krueger',40,'Appraiser'),
(0,'Maam',40,'Team Leader');

create table ToDos(
Id int primary key auto_increment not null,
`Name` nvarchar(25),
 Description nvarchar(100),
 AssignedTo int,
 foreign key (assignedTo) references Employee(id),
 HoursNeeded int,
 IsCompleted bool
);

insert into ToDos
values(0,'Call','Answer the phone and do not hang up', 2, 30, 0),
(0,'Audit','Match datapoint from document to data and pass if match or fail if not match', 1, 40, 0),
(0,'Research','Check clients IPAC score', 3, 35, 0),
(0,'Appraise','Go to clients house and appraise the house', 4, 16, 0),
(0,'Supervise','Lead a team or employees', 5, 40, 0);

create table Assignment(
id int primary key auto_increment not null,
EmployeeId int,
ToDoId int,
foreign key (EmployeeId) References Employee(Id),
foreign key (ToDoId) references ToDos(Id)
);
insert into Assignment
Values(0, 1, 2),
(0,2,1),
(0,3,3),
(0,4,4),
(0,5,5);

select * from Employee;
select * from ToDos;
select * from Assignment;
-- drop database todolist;
-- drop database todo
