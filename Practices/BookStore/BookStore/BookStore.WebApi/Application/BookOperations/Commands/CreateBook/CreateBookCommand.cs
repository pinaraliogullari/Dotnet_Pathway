﻿using AutoMapper;
using BookStoreWebApi.DbOperations;
using BookStoreWebApi.Entities;

namespace BookStoreWebApi.Application.BookOperations.Commands.CreateBook
{
    public class CreateBookCommand
    {
        public CreateBookModel Model { get; set; }
        private readonly IBookStoreDbContext _context;
        private readonly IMapper _mapper;

        public CreateBookCommand(IBookStoreDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public void Handle()
        {
            var book = _context.Books.SingleOrDefault(x => x.Title == Model.Title);
            if (book is not null)
                throw new InvalidOperationException("Kitap zaten mevcut");
            //book = new Book()
            //{
            //    Title = Model.Title,
            //    PageCount = Model.PageCount,
            //    GenreId = Model.GenreId,
            //    PublishDate = Model.PublishDate,
            //};

            book = _mapper.Map<Book>(Model);

            _context.Books.Add(book);
            _context.SaveChanges();
        }

        public class CreateBookModel
        {
            public string Title { get; set; }
            public int GenreId { get; set; }
            public int PageCount { get; set; }
            public DateTime PublishDate { get; set; }
        }
    }
}
