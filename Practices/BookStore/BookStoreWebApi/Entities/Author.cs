﻿namespace BookStoreWebApi.Entities
{
    public class Author
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime BirthDate { get; set; }
        public int BookId { get; set; }
        public List<Book> Books { get; set; }
    }
}
