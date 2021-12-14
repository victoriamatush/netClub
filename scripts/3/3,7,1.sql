SELECT AVG(DATEDIFF(day, Date_Of_Getting, Date_Of_Returning))
FROM BookInfo
WHERE Title_Of_Book = 'Title'
GROUP BY Title_Of_Book;