using Models;


namespace Imtihon_2.Services
{
    public partial  class Library
    {
        private List<Book> BuyurtmaList = new List<Book>();
        public void AttachBookAndCategories(int bookId, int categoryId)
        {
            var book=books.FirstOrDefault(b=>b.Id==bookId);
            var category=categories.FirstOrDefault(c=>c.Id==categoryId);

            if(book==null || category == null)
            {
                Console.WriteLine("Invalid book or category Id");
                return;
            }

            var bookCategories = new BookCategories
            {
                BookId = bookId,
                Book = book,
                CategoryId = categoryId,
                Category = category
            };

            book.BookCategories.Add(bookCategories);
            category.BookCategories.Add(bookCategories);
        }

        public void GetList()
        {
            if (books.Count > 0)
            {
                foreach (var book in books)
                {
                    Console.WriteLine($"Book:{book.Name}");
                    foreach(var bc in book.BookCategories)
                    {
                        Console.WriteLine($" Category: {bc.Category.Name}");
                    }
                }
            }
            else
            {
                Console.WriteLine("Book list is empty");
            }

        }
        
        public void Buyurtma(int bookId)
        {
            var book = books.FirstOrDefault(b => b.Id == bookId);
            if (book == null)
            {
                Console.WriteLine("Invalid book Id");
                return;
            }
            BuyurtmaList.Add(book);
        }

        public void GetBuyurtma()
        {
            if (books.Count > 0)
            {
                Console.WriteLine("Buyurtmalar: ");
                foreach(var book in BuyurtmaList)
                {
                    Console.WriteLine($"Book: {book.Name}");
                }
            }
        }

        public void Report()
        {
            var bookCount=new Dictionary<int, int>();
            foreach(var book in BuyurtmaList)
            {
                if (bookCount.ContainsKey(book.Id))
                {
                    bookCount[book.Id]++;
                }
                else
                {
                    bookCount[book.Id] = 1;
                }
            }
            int maxCount = 0;
            Book bookMax = null;
            foreach(var x in bookCount)
            {
                if(x.Value > maxCount)
                {
                    maxCount = x.Value;
                    bookMax=books.FirstOrDefault(b => b.Id == x.Key);
                }
            }
            Console.WriteLine($"Eng ko`p buyurtma qilingan kitob: {bookMax.Name}");
        }

    }
}
