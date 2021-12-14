SELECT Title_Of_Book, {CURRENTDATE}-Date_Of_Getting
FROM BookInfo
WHERE UserId = 1 AND Returned = 0;
