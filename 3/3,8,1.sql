SELECT AVG(Age), AVG(DATEDIFF(day, {CURRENTDATE}, Register_Date))
FROM Reader;