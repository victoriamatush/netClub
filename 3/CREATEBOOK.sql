CREATE TABLE Book (
Id INT IDENTITY(1,1) PRIMARY KEY,
Title VARCHAR(10) NOT NULL,
Author VARCHAR(10) NOT NULL,
Co_author VARCHAR(10),
Is_Available BIT,
Num_Of_Readers INT
);