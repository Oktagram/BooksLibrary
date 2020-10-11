﻿using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace BooksLibrary.Application.Books.Commands.AddBook
{
    public class AddBookCommandHandler : IRequestHandler<AddBookCommand, int>
    {
        public Task<int> Handle(AddBookCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
