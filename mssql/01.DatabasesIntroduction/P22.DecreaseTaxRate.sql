GO

USE [Hotel]

GO

UPDATE [Payments]
SET [TaxRate] *= 0.97

GO

SELECT [TaxRate]
FROM [Payments]
