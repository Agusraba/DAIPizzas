CREATE PROCEDURE sp_delete
@pId int
AS
BEGIN
DELETE FROM Pizzas WHERE Id = @pId
END

exec sp_delete 1004


