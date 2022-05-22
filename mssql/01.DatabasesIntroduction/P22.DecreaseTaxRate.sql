USE [Hotel]

UPDATE [Payments]
SET [TaxRate] *= 0.97

SELECT [TaxRate]
FROM [Payments]
