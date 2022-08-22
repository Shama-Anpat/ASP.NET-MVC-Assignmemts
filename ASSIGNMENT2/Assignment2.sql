select * from BusInfom

ALTER PROCEDURE spInsertData 
@BoardingPoint nvarchar(50),
@TravelDate date,
@Amount decimal(12,0),
@Rating int
AS 
BEGIN
	insert into BusInfom(BoardingPoint,TravelDate,Amount,Rating)
	values (@BoardingPoint,@TravelDate,@Amount,@Rating) 
	return SCOPE_IDENTITY()
END

exec spInsertData PUN, '2017-12-10', 543.00, 4
exec spInsertData MUM, '2017-01-28', 500.50, 4
exec spInsertData MUM, '2016-11-06', 510.00, 4
exec spInsertData BGL, '2017-06-18', 400.65, 2

create procedure spRetriveByAmount
AS
BEGIN
select BoardingPoint, TravelDate from BusInfom where Amount > 450
END

exec spRetriveByAmount

create procedure spRetriveByRatings
AS
BEGIN
select BusId ,BoardingPoint from BusInfom where Rating > 3 
END

exec spRetriveByRatings

create procedure spRetriveByBoardingPoint
AS
BEGIN
select * from BusInfom where BoardingPoint = 'MUM'
END

exec spRetriveByBoardingPoint

create procedure spRetriveByDate
AS
BEGIN
	select BusId,BoardingPoint from BusInfom where TravelDate = '2017-12-10'
END

exec spRetriveByDate

