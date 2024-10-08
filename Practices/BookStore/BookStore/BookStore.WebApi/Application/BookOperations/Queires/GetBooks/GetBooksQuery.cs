﻿using AutoMapper;
using BookStoreWebApi.DbOperations;
using Microsoft.EntityFrameworkCore;

namespace BookStoreWebApi.Application.BookOperations.Queires.GetBooks
{
    public class GetBooksQuery
    {
        private readonly IBookStoreDbContext _context;
        private readonly IMapper _mapper;

        public GetBooksQuery(IBookStoreDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public List<BooksViewModel> Handle()
        {
            var bookList = _context.Books.Include(x => x.Genre).Include(x=>x.Author).OrderBy(x => x.Id).ToList();
            //List<BooksViewModel> viewModel = new List<BooksViewModel>();
            //viewModel=bookList.Select(book => new BooksViewModel()
            //{
            //    Title = book.Title,
            //    Genre = ((GenreEnum)book.GenreId).ToString(),
            //    PublishDate = book.PublishDate.Date.ToString("dd/MM/yyy"),
            //    PageCount = book.PageCount,
            //}).ToList();

            List<BooksViewModel> viewModel = _mapper.Map<List<BooksViewModel>>(bookList);

            return viewModel;
        }

        public class BooksViewModel
        {
            public string Title { get; set; }
            public int PageCount { get; set; }
            public string PublishDate { get; set; }
            public string Genre { get; set; }
            public string Author { get; set; }
        }
    }
}
