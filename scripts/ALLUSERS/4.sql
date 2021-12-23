SELECT BOOK.BOOKID, TITLE, NAME, SURNAME
FROM BOOKAUTHORS 
LEFT JOIN AUTHOR ON BOOKAUTHORS.AUTHORID = AUTHOR.AUTHORID
LEFT JOIN BOOK ON BOOKAUTHORS.BOOKID = BOOK.BOOKID
WHERE TITLE LIKE '%';