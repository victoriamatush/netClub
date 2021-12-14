SELECT TOP(1) Title_Of_Book, COUNT(Title_Of_Book)
FROM BookInfo
WHERE Date_Of_Getting >= CONVERT(date, '2000-7-7')
GROUP BY Title_Of_Book
ORDER BY COUNT(Title_Of_Book) DESC;