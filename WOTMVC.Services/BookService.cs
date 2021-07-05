﻿using System;
using System.Collections.Generic;
using System.Linq;
using WOTMVC.Data;
using WOTMVC.Models.BookMods;
using WOTMVC.Models.ChapterMods;
using WOTMVC.Models.CharacterMods;
using WOTMVC.Models.NationMods;

namespace WOTMVC.Services
{
    public class BookService
    {
        private ApplicationDbContext _db = new ApplicationDbContext();

        private readonly Guid _userId;
        public BookService(Guid userId)
        {
            _userId = userId;
        }
        public bool CreateBook(BookCreate model)
        {
            var entity = new Book()
            {
                OwnerId = _userId,
                Title = model.Title,
                PageCount = model.PageCount
            };
            using (var ctx = new ApplicationDbContext())
            {
                ctx.Books.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }
        public IEnumerable<BookListItem> GetBooks()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query = ctx.Books.Where(e => e.OwnerId == _userId)
                    .Select(
                        e =>
                        new BookListItem
                        {
                            BookId = e.BookId,
                            Title = e.Title,
                        }
                    );
                return query.ToArray();
            }
        }
        public IEnumerable<ChapterListItem> GetChapsByBook(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query = ctx.Chapters.Where(e => e.BookId == id)
                    .Select(
                        e =>
                        new ChapterListItem
                        {
                            ChapterId = e.ChapterId,
                            ChapTitle = e.ChapTitle,
                        }
                    );
                return query.ToArray();
            }
        }
        public BookDetail GetBookById(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = ctx.Books.Single(e => e.BookId == id && e.OwnerId == _userId);

                var chapList = GetChapsByBook(id).ToList();
                return new BookDetail
                {
                    BookId = entity.BookId,
                    Title = entity.Title,
                    PageCount = entity.PageCount,
                    Chapters = chapList
                };
            }
        }

        public bool UpdateBook(BookEdit book)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Books
                        .Single(e => e.BookId == book.BookId && e.OwnerId == _userId);
                entity.Title = book.Title;
                entity.Title = book.Title;
                entity.PageCount = book.PageCount;

                return ctx.SaveChanges() == 1;
            }
        }
        public bool DeleteBook(int bookId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity1 =
                ctx
                    .Chapters
                    .Single(e => e.BookId == bookId && e.OwnerId == _userId);
                ctx.Chapters.Remove(entity1);

                var entity =
                    ctx
                    .Books
                    .Single(e => e.BookId == bookId && e.OwnerId == _userId);

                ctx.Books.Remove(entity);

                return ctx.SaveChanges() == 1;
            }
        }

    }
}


