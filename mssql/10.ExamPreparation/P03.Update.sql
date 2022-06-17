-- Connect to the 'CigarShop' database for execution of this query
USE [CigarShop]

GO

-- Update the 'Cigars' table and increase the price by 20% where the taste is spicy
UPDATE [Cigars]
   SET [PriceForSingleCigar] *= 1.2
 WHERE [TastId] = 1

GO

-- Update the 'Brands' table and set the description to 'New description' where the description is NULL
UPDATE [Brands]
   SET [BrandDescription] = 'New description'
 WHERE [BrandDescription] IS NULL

GO
