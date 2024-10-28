using static Assignments.AssignmentFour.ILibraryService;

namespace Assignments.AssignmentFour
{
    public class Teacher:IBorrower,IReservable
    {
        public void ReserveBook(string bookId)
        {
            Console.WriteLine($"Teacher reserved the book with id: {bookId}");
        }
        public void BorrowBook(string bookId)
        {
            Console.WriteLine($"Teacher Borrowed book with id: {bookId}");
        }
    }
}
