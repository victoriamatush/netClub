CREATE TABLE Request (
Id INT IDENTITY(1,1) PRIMARY KEY,
Reader_Id INT NOT NULL, 
Book_Id INT NOT NULL,
Date_Of_Request DATE,
Is_Approved BIT
);