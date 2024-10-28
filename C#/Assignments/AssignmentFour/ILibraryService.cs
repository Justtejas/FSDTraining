namespace Assignments.AssignmentFour
{
    public interface ILibraryService
    {
        public interface IBorrower
        {
            void BorrowBook(string bookId);
        }
        public interface IReservable
        {
            void ReserveBook(string bookId);
        }
       
        public interface IInventoryManager
        {
            void AddBook(string bookId);
            void RemoveBook(string bookId);
        }

    }
}
