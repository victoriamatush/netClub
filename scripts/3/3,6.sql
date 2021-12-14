SELECT  Name, Title_Of_Book, DATEDIFF(day, Register_Date, CONVERT(date, {CURRENTDATE}))
FROM Reader LEFT JOIN BookInfo ON Reader.Id = BookInfo.UserId
WHERE Reader.Id = 1;