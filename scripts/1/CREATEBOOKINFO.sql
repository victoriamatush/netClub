CREATE TABLE BookInfo (
Id INT IDENTITY(1,1) PRIMARY KEY,
UserId INT NOT NULL,
BookId INT NOT NULL,
Title_Of_Book VARCHAR(10) NOT NULL,
Date_Of_Getting DATE,
Date_Of_Returning DATE,
Returned BIT
);