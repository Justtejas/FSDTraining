using static Assignments.AssignmentFour.ILibraryService;
namespace Assignments.AssignmentFour
{
    internal class Librarian: IInventoryManager
    {
        public void AddBook(string bookId)
        {
            Console.WriteLine($"Librarian added the book with id: {bookId}");
        }
       public void RemoveBook(string bookId)
        {
            Console.WriteLine($"Librarian removed the book with id: {bookId}");
        }
    }
}
