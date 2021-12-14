SELECT Title_Of_Book, COUNT(BookId) AS Popularity, AVG(DATEDIFF(day, Date_Of_Getting, Date_Of_Returning)) AS Avg_Time
FROM BookInfo
WHERE UserId = 1
GROUP BY Title_Of_Book;
