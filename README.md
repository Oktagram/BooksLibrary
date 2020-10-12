# BooksLibrary

Before startup configure Connection string in appsettings.json (DefaultConnection).

Execute /database/seed from Swagger to insert data into db. Use may use it several times if you want more data.

There are 2 roles: Reader and Librarian.

Credentials for Reader user: login 'reader' pass 'reader'.
Credentials for Librarian user: login 'librarian' pass 'librarian'.

Reader can make a book order for specific date.
Librarian can add and remove books.

Obtaining books data available for all authenticated users.

Use /auth/sign-in to obtain access token. Then click 'Authorize' button on the top right and enter 'Bearer <token value>'. After this you can access /books endpoints.

/signalr.html logs into browser console Add Book, Remove Book and Order Book events.