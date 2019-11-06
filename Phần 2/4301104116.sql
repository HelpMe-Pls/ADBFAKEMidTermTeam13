use master
go
use ADBTeam13SpatialDB
go

--select ma, khuvuc.MakeValid().STArea() from quanly

--a
select quydinh.ma as N'Mã đất', quydinh.Mucdich  N'Loại đất', quanly.khuvuc.MakeValid().STArea()*quydinh.Matdo as N'Lượng nước m3/ha' from quanly
join quydinh on quydinh.ma = quanly.ma

--b
Declare @min float
set @min = (select min(khuvuc.MakeValid().STArea()) from quanly)
select quydinh.Mucdich as N'Loại đất có diện tích bé nhất', quydinh.ma as N'Mã đất' from quanly 
join quydinh on quanly.ma=quydinh.ma
where khuvuc.MakeValid().STArea() = @min

--c
DECLARE @kenh geometry
SET @kenh = geometry::STPolyFromText(
	'POLYGON((2 4, 4 4, 4 -2, 2 -2, 2 4))', 4326);
SELECT ma, 
khuvuc.MakeValid().STIntersection(@kenh).STArea() as N'Diện tích bị mất (ha)'
FROM quanly
/*UPDATE quanly SET
	khuvuc = khuvuc.MakeValid().STDifference(@kenh)

SELECT Ma as N'Mã đất', khuvuc from quanly*/
