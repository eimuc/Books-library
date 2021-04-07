# Library Console App

A .NET console application, written in C#.

#### Commands:

 - `add "bookname" "author" "category" "language" "date" "isbn"` - Example: add Titanic JohnSnow Romance English 2010 5452698745 (date must be 4 numbers, isbn 10 numbers)
 - `take "bookname" "username" "days"` - Example: take Titanic DavidLee 14 (max 60days)
 - `return "bookname" "username"` - Example: return Titanic DavidLee
 - `list "filtername"` - all, author, category, language, isbn, name, available Example: list all
 - `delete "bookname"`- Example: delete Titanic
