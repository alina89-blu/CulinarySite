using System;
using System.Collections.Generic;


namespace CulinarySite.Common.ViewModels.Book
{
    public class BookNameComparer : IComparer<BookDetailListDto>
    {
        public int Compare(BookDetailListDto book1, BookDetailListDto book2)
        {
            if (book1 == null || book2 == null)
            {
                throw new ArgumentException("Некорректное значение параметра");
            }
            return book1.Name.CompareTo(book2.Name);
        }
    }
}
