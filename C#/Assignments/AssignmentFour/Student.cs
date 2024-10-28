using static Assignments.AssignmentFour.ILibraryService;

namespace Assignments.AssignmentFour
{
    public class Student : IBorrower
    {
        public void BorrowBook(string bookId)
        {
            Console.WriteLine($"Student Borrowed book with id: {bookId}");
        }
    }
}
