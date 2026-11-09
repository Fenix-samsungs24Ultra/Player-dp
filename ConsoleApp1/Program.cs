

public class Book
{
    public string Author;
    public string Title;
    public string Publisher;

    public int Year;
    
    public Book (string author, string title, string publisher, int year)
    {
     
        Author = author;
        Title = title;
        Publisher = publisher;
        Year = year;
    }
}public class Program
{
    public static void Main()
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8;
        Console.InputEncoding = System.Text.Encoding.UTF8;
        bool exit = false;
        List<Book> books = new List<Book>();
        do
        {
            Console.WriteLine("Введіть автора книги:");
            string author = Console.ReadLine();
            Console.WriteLine("Введіть назву книги:");
            string title = Console.ReadLine();
            Console.WriteLine("Введіть видавництво книги:");
            string publisher = Console.ReadLine();
            Console.WriteLine("Введіть рік видання книги:");
            int year = int.Parse(Console.ReadLine());
            Book book = new Book(author, title, publisher, year);
            books.Add(book);
            Console.WriteLine("Для завершення введіть 'exit'");
            if (Console.ReadLine() == "exit")
            {
                exit = true;
            }
            else
            {
                Console.WriteLine("Продовжити введення книг...");
            }
        } while (!exit);
        Console.WriteLine("Введіть автора книги для пошуку:");
        string searchAuthor = Console.ReadLine();
        bool found = false; 
        foreach (Book book in books)
        {
            if (book.Author == searchAuthor && book.Year < 2009)
            {
                Console.WriteLine($"Автор: {book.Author}, Назва: {book.Title}, Видавництво: {book.Publisher}, Рік видання: {book.Year}");
                found = true;
            }
        }
        if (!found)
        {
            Console.WriteLine("Книги цього автора, видані до 2009 року, не знайдено.");
        }
    }
}