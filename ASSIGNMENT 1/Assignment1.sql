create database Match;

create table FootBallLeague 
(
	MatchID int NOT NULL PRIMARY KEY,
	TeamName1 nvarchar(50), 
	TeamName2 nvarchar(50), 
	MatchStatus nvarchar(50), 
	WinningTeam nvarchar(50), 
	Points int
)

CREATE PROCEDURE spInsertData 
@MatchId int,
@TeamName1 nvarchar(50),
@TeamName2 nvarchar(50),
@MatchStatus nvarchar(50),
@WinningTeam nvarchar(50),
@Points int
AS 
BEGIN
	insert into FootBallLeague(MatchId,TeamName1,TeamName2,MatchStatus,WinningTeam,Points)
	values (@MatchId,@TeamName1,@TeamName2,@MatchStatus,@WinningTeam,@Points)
END


exec spInsertData 1006,'Brazil','France','Win','Brazil',4;


CREATE PROCEDURE spRetriveWinning
AS
BEGIN
select WinningTeam from FootBallLeague where TeamName1 = WinningTeam or TeamName2 = WinningTeam
END

ALTER PROCEDURE spRetriveWinning
AS
BEGIN
select MatchID, WinningTeam from FootBallLeague where TeamName1 = WinningTeam or TeamName2 = WinningTeam
END

exec spRetriveWinning

CREATE PROCEDURE spMatachesPlayedByJapan
AS
BEGIN
select * from FootBallLeague where TeamName1 = 'Japan' or TeamName2 = 'Japan'
END

exec spMatachesPlayedByJapan

Insert into FootBallLeague
values (1001,'Italy','France','Win','France',4)

Insert into FootBallLeague
values (1002,'Brazil','Portugal','Draw',null,2)

Insert into FootBallLeague
values (1003,'England','Japan','Win','England',4)

Insert into FootBallLeague
values (1004,'USA','Russia','Win','Russia',4)

Insert into FootBallLeague
values (1005,'Portugal','Italy','Draw',null,2)


drop table FootBallLeague;

select * from FootBallLeague


CREATE PROCEDURE spRetriveStatusAsWin
AS
BEGIN
select * from FootBallLeague where MatchStatus = 'Win'
END

exec spRetriveStatusAsWin

