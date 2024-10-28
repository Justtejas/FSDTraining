using static Assignments.AssignmentFour.ILibraryService;

namespace Assignments.AssignmentFour
{
    public class LibraryManagement
    {
        public void LibraryManagementMethod()
        {
            IBorrower studentBorrower = new Student();
            var studentService = new LibraryService(studentBorrower);

            studentService.BorrowBook("book123");

            IBorrower teacherBorrower = new Teacher();
            IReservable teacherReservable = new Teacher();
            var teacherService = new LibraryService(teacherBorrower, teacherReservable);

            teacherService.BorrowBook("book456");
            teacherService.ReserveBook("book789");

            IInventoryManager librarianInventory = new Librarian();
            var librarianService = new LibraryService(inventoryManager: librarianInventory);

            librarianService.AddBookToInventory("book101");
            librarianService.RemoveBookFromInventory("book102");
        }
    }
}
