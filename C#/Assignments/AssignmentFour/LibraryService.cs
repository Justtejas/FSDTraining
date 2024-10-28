using static Assignments.AssignmentFour.ILibraryService;

namespace Assignments.AssignmentFour
{
    public class LibraryService
    {
        
        private readonly IBorrower _borrower;
        private readonly IReservable _reservable;
        private readonly IInventoryManager _inventoryManager;
        public LibraryService(IBorrower borrower = null, IReservable reservable = null, IInventoryManager inventoryManager = null)
        {
            _borrower = borrower;
            _reservable = reservable;
            _inventoryManager = inventoryManager;
        }

        public void BorrowBook(string bookId)
        {
            _borrower?.BorrowBook(bookId);
        }

        public void ReserveBook(string bookId)
        {
            _reservable?.ReserveBook(bookId);
        }

        public void AddBookToInventory(string bookId)
        {
            _inventoryManager?.AddBook(bookId);
        }

        public void RemoveBookFromInventory(string bookId)
        {
            _inventoryManager?.RemoveBook(bookId);
        }
    }
}
