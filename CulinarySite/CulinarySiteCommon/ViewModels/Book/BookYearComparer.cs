using System;
using System.Collections.Generic;


namespace CulinarySite.Common.ViewModels.Book
{
    public class BookYearComparer : IComparer<BookDetailListDto>
    {
        public int Compare(BookDetailListDto book1, BookDetailListDto book2)
        {
            if (book1 == null || book2 == null)
            {
                throw new ArgumentException("Некорректное значение параметра");
            }
            return book1.CreationYear.CompareTo(book2.CreationYear);
        }
    }
}
