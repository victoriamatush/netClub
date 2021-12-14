SELECT AVG(DATEDIFF(day, Date_Of_Getting, Date_Of_Returning))
FROM BookInfo
WHERE Title_Of_Book = {IDOFBOOK}
GROUP BY BookId;