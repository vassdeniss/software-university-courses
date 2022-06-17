-- Connect to the 'CigarShop' database for execution of this query
USE [CigarShop]

GO

-- Insert name, brand id, taste id, size id, price and image url into the 'Cigars' table
INSERT INTO [Cigars] 
     VALUES ('COHIBA ROBUSTO', 9, 1, 5, 15.50, 'cohiba-robusto-stick_18.jpg')
          , ('COHIBA SIGLO I', 9, 1, 10, 410.00, 'cohiba-siglo-i-stick_12.jpg')
		  , ('HOYO DE MONTERREY LE HOYO DU MAIRE', 14, 5, 11, 7.50, 'hoyo-du-maire-stick_17.jpg')
		  , ('HOYO DE MONTERREY LE HOYO DE SAN JUAN', 14, 4, 15, 32.00, 'hoyo-de-san-juan-stick_20.jpg')
		  , ('TRINIDAD COLONIALES',	2, 3, 8, 85.21, 'trinidad-coloniales-stick_30.jpg')

GO

-- Insert town, country, street and zip code into the 'Addresses' table
INSERT INTO [Addresses]
     VALUES ('Sofia', 'Bulgaria', '18 Bul. Vasil levski', '1000')
          , ('Athens', 'Greece', '4342 McDonald Avenue', '10435')
          , ('Zagreb', 'Croatia', '4333 Lauren Drive', '10000')

GO
