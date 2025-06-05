using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// libraryBookList.txt를 읽고 
namespace _250527_consoleTest
{
    class Library
    {
        static LibrarySystem library; // Make library accessible to helper methods

        static void Main()
        {
            library = new LibrarySystem("서울시 도서관", "Library-001");
            Console.WriteLine($"{library.LibraryName}에 오신 것을 환영합니다! (ID: {library.LibraryId})!");
            Console.WriteLine("--------------------------------------------------");

            while (true)
            {
                Console.Write("유저아이디를 입력해 주세요. (종료하시려면 'exit'을 입력해 주세요.): ");
                string idInput = Console.ReadLine()?.Trim();

                if (string.Equals(idInput, "exit", StringComparison.OrdinalIgnoreCase))
                {
                    Console.WriteLine("시스템 종료중. 안녕히 가세요!");
                    break;
                }

                if (!library.CheckID(idInput))
                {
                    Console.WriteLine("--------------------------------------------------");
                    continue;
                }

                if (library.IsAdmin)
                {
                    AdminMenu();
                }
                else
                {
                    UserMenu();
                }
                Console.WriteLine("최근 접속 유저 로그아웃 중...");
                Console.WriteLine("--------------------------------------------------");
            }
        }

        static void AdminMenu()
        {
            while (true)
            {
                Console.WriteLine("\n--- 관리자 메뉴 ---");
                Console.WriteLine("1. 책 추가하기");
                Console.WriteLine("2. 책 검색하기");
                Console.WriteLine("3. 책 대여하기");
                Console.WriteLine("4. 책 반납하기");
                Console.WriteLine("5. 모든 책 보기");
                Console.WriteLine("6. 로그아웃");
                Console.Write("옵션을 선택해 주세요: ");
                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        AddBook();
                        break;
                    case "2":
                        SearchBookAndShowInfo();
                        break;
                    case "3":
                        RentBook();
                        break;
                    case "4":
                        ReturnBook();
                        break;
                    case "5":
                        library.ShowAllOwnedBooks();
                        return;
                    case "6":
                        return;
                    default:
                        Console.WriteLine("유효하지 않은 입력입니다. 다시 시도해 주세요.");
                        break;
                }
            }
        }

        static void UserMenu()
        {
            while (true)
            {
                Console.WriteLine("\n--- User Menu ---");
                Console.WriteLine("1. 책 검색하기(정보 보기)");
                Console.WriteLine("2. 책 대여하기");
                Console.WriteLine("3. 책 반납하기");
                Console.WriteLine("4. 로그아웃");
                Console.Write("옵션을 선택해 주세요: ");
                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        SearchBookAndShowInfo(); // 이름 변경
                        break;
                    case "2":
                        RentBook();
                        break;
                    case "3":
                        ReturnBook();
                        break;
                    case "4":
                        return;
                    default:
                        Console.WriteLine("유효하지 않은 입력입니다. 다시 시도해 주세요.");
                        break;
                }
            }
        }

        static void AddBook()
        {
            if (!library.IsAdmin)
            {
                Console.WriteLine("접근 거부. 관리자만 도서를 추가할 수 있습니다.");
                return;
            }
            Console.WriteLine("\n--- 새 도서를 추가해 주세요. ---");
            Console.Write("ISBN를 입력해 주세요.: ");
            string isbn = Console.ReadLine()?.Trim();
            Console.Write("책 제목을 입력해 주세요.: ");
            string bookName = Console.ReadLine()?.Trim();
            Console.Write("작가명을 입력해 주세요.: ");
            string author = Console.ReadLine()?.Trim();
            Console.Write("출판사를 입력해 주세요.: ");
            string publisher = Console.ReadLine()?.Trim();

            try
            {
                Book newBook = new Book(isbn, bookName, author, publisher);
                library.AddBook(newBook); // 성공/실패 메시지는 AddBook 내부에서 처리
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine($"도서 생성 오류: {ex.Message}");
            }
        }

        static void SearchBookAndShowInfo()
        {
            Console.Write("찾고자 하는 도서의 ISBN를 입력해 주세요.: ");
            string isbnToSearch = Console.ReadLine()?.Trim();
            // TryGetBookByISBN 사용
            if (library.TryGetBookByISBN(isbnToSearch, out Book foundBook))
            {
                library.ShowBookInfo(foundBook);
            }
            else
            {
                Console.WriteLine($"도서의 ISBN '{isbnToSearch}'를 찾을 수 없습니다.");
            }
        }

        static void RentBook()
        {
            Console.Write("대여하고자 하는 도서의 ISBN를 입력해 주세요: ");
            string isbnToRent = Console.ReadLine()?.Trim();

            // TryGetBookByISBN 사용
            if (library.TryGetBookByISBN(isbnToRent, out Book bookToRent))
            {
                library.RentBook(bookToRent);
            }
            else
            {
                Console.WriteLine($"도서의 ISBN '{isbnToRent}'를 찾을 수 없습니다. 대출할 수 없습니다.");
            }
        }

        static void ReturnBook()
        {
            Console.Write("반납하고자 하는 도서의 ISBN를 입력해 주세요: ");
            string isbnToReturn = Console.ReadLine()?.Trim();

            // TryGetBookByISBN 사용
            if (library.TryGetBookByISBN(isbnToReturn, out Book bookToReturn))
            {
                library.ReturnBook(bookToReturn);
            }
            else
            {
                Console.WriteLine($"도서의 ISBN '{isbnToReturn}'를 찾을 수 없습니다. 반납할 수 없습니다.");
            }
        }
    }

    // Book.cs
    public class Book
    {
        public string BookName { get; set; }
        public string Publisher { get; set; }
        public string Author { get; set; }
        public string ISBN { get; set; } // Changed from Barcode
        public bool IsBorrowed { get; set; }

        // Constructor to initialize the book
        public Book(string isbn, string bookName, string author, string publisher)
        {
            if (string.IsNullOrWhiteSpace(isbn))
                throw new ArgumentException("ISBN은 null 또는 whitespace가 될 수 없습니다.", nameof(isbn));
            if (string.IsNullOrWhiteSpace(bookName))
                throw new ArgumentException("BookName null 또는 whitespace가 될 수 없습니다.", nameof(bookName));

            ISBN = isbn;
            BookName = bookName;
            Author = author ?? string.Empty; // Allow empty author/publisher if not critical
            Publisher = publisher ?? string.Empty;
            IsBorrowed = false;
        }

        public override string ToString()
        {
            return $"ISBN: {ISBN}, 제목: \"{BookName}\" by {Author}, 출판사: {Publisher}, 상태: {(IsBorrowed ? "대여중" : "대여가능")}";
        }
    }

    public class LibrarySystem
    {
        public string LibraryName { get; set; }
        public string LibraryId { get; set; }
        public bool IsAdmin { get; private set; }

        public Dictionary<string, Book> OwnedBooks { get; private set; }
        public Dictionary<string, Book> BorrowedBooks { get; private set; }

        private List<string> validUserIDs;
        private List<string> adminIDs;
        private string currentUserID;

        private const string BookListFileName = "libraryBookList.txt"; // 파일 이름 상수화

        public LibrarySystem(string libraryName, string libraryId)
        {
            LibraryName = libraryName;
            LibraryId = libraryId;

            OwnedBooks = new Dictionary<string, Book>(StringComparer.OrdinalIgnoreCase);
            BorrowedBooks = new Dictionary<string, Book>(StringComparer.OrdinalIgnoreCase);

            validUserIDs = new List<string>();
            adminIDs = new List<string>();
            IsAdmin = false;

            // 샘플 데이터 초기화 대신 파일에서 읽어오도록 변경
            if (!ReadBookList())
            {
                Console.WriteLine($"Warning: '{BookListFileName}'을 읽을 수 없습니다. 샘플 데이터를 로드합니다.");
                InitializeSampleData(); // 파일 읽기 실패 시 예비 데이터 사용
            }

            InitializeSampleUser();
        }

        // 책 목록을 파일에서 읽어오는 메서드
        /// <summary>
        /// Reads the book list from libraryBookList.txt and initializes OwnedBooks.
        /// Each line in the file should be in the format: ISBN,BookName,Author,Publisher
        /// </summary>
        /// <returns>True if the book list was read and processed successfully (or file doesn't exist), false if an error occurred during reading or parsing.</returns>
        public bool ReadBookList()
        {
            if (!File.Exists(BookListFileName))
            {
                Console.WriteLine($"Information: '{BookListFileName}'파일을 찾을 수 없습니다.");
                // 파일이 없는 것은 오류가 아닐 수 있으므로 true를 반환하거나,
                // 빈 파일 생성 후 false를 반환하여 샘플 데이터 로드를 유도할 수 있습니다.
                // 여기서는 파일이 없으면 아무것도 로드하지 않고 성공으로 간주합니다.
                // 만약 파일이 반드시 있어야 한다면 여기서 false를 반환할 수 있습니다.
                return true;
            }

            try
            {
                string[] lines = File.ReadAllLines(BookListFileName);
                int lineNumber = 0;
                foreach (string line in lines)
                {
                    lineNumber++;
                    if (string.IsNullOrWhiteSpace(line) || line.StartsWith("#")) // 주석이나 빈 줄 건너뛰기
                    {
                        continue;
                    }

                    string[] parts = line.Split(','); // CSV 형식으로 가정 (쉼표로 구분)
                    if (parts.Length == 4)
                    {
                        string isbn = parts[0].Trim();
                        string bookName = parts[1].Trim();
                        string author = parts[2].Trim();
                        string publisher = parts[3].Trim();

                        if (string.IsNullOrWhiteSpace(isbn) || string.IsNullOrWhiteSpace(bookName))
                        {
                            Console.WriteLine($"Warning: Invalid data on line {lineNumber} in '{BookListFileName}'. ISBN or BookName is empty. Skipping.");
                            continue;
                        }

                        if (OwnedBooks.ContainsKey(isbn))
                        {
                            Console.WriteLine($"Warning: Duplicate ISBN '{isbn}' found on line {lineNumber} in '{BookListFileName}'. Skipping.");
                            continue;
                        }

                        Book newBook = new Book(isbn, bookName, author, publisher);
                        OwnedBooks.Add(newBook.ISBN, newBook);
                        // 파일에서 로드된 책은 기본적으로 IsBorrowed = false (Book 생성자에서 처리)
                    }
                    else
                    {
                        Console.WriteLine($"Warning: Invalid format on line {lineNumber} in '{BookListFileName}'. Expected 4 parts, got {parts.Length}. Skipping. Line content: {line}");
                    }
                }
                Console.WriteLine($"{OwnedBooks.Count} books loaded successfully from '{BookListFileName}'.");
                return true;
            }
            catch (IOException ex) // 파일 읽기 관련 예외
            {
                Console.WriteLine($"Error reading book list file '{BookListFileName}': {ex.Message}");
                return false;
            }
            catch (Exception ex) // 그 외 일반적인 예외 (예: ArgumentException from Book constructor)
            {
                Console.WriteLine($"An unexpected error occurred while processing '{BookListFileName}': {ex.Message}");
                return false;
            }
        }

        private void InitializeSampleData()
        {
            AddBook(new Book("978-0345391803", "The Hitchhiker's Guide to the Galaxy", "Douglas Adams", "Pan Books"));
            AddBook(new Book("978-0141439518", "Pride and Prejudice", "Jane Austen", "Penguin Classics"));
            AddBook(new Book("978-0451524935", "1984", "George Orwell", "Signet Classic"));
            AddBook(new Book("978-0061120084", "To Kill a Mockingbird", "Harper Lee", "Harper Perennial"));

            Console.WriteLine("------------- 도서 등록 완료 ----------------");
        }

        private void InitializeSampleUser()
        {
            validUserIDs.Add("user123");
            validUserIDs.Add("user456");
            adminIDs.Add("admin001");
            validUserIDs.AddRange(adminIDs);

            Console.WriteLine("------------ 사용자 등록 완료 ---------------");
        }

        public bool AddBook(Book bookToAdd)
        {
            if (bookToAdd == null || string.IsNullOrWhiteSpace(bookToAdd.ISBN))
            {
                Console.WriteLine("Error: 책 또는 ISBN은 null 또는 비어있을 수 없습니다.");
                return false;
            }
            if (OwnedBooks.ContainsKey(bookToAdd.ISBN))
            {
                Console.WriteLine($"Error: 도서 ISBN '{bookToAdd.ISBN}' 이미 존재합니다.");
                return false;
            }
            OwnedBooks.Add(bookToAdd.ISBN, bookToAdd);
            bookToAdd.IsBorrowed = false;

            if (!File.Exists(BookListFileName))
            {
                Console.WriteLine($"Information: '{BookListFileName}'파일을 찾을 수 없습니다.");
                // 파일이 없는 것은 오류가 아닐 수 있으므로 true를 반환하거나,
                // 빈 파일 생성 후 false를 반환하여 샘플 데이터 로드를 유도할 수 있습니다.
                // 여기서는 파일이 없으면 아무것도 로드하지 않고 성공으로 간주합니다.
                // 만약 파일이 반드시 있어야 한다면 여기서 false를 반환할 수 있습니다.
                return true;
            }
            else
            {
                string bookInfo = $"\n{bookToAdd.ISBN},{bookToAdd.BookName},{bookToAdd.Author},{bookToAdd.Publisher}";
                File.AppendAllText(BookListFileName, bookInfo);
            }



            Console.WriteLine($"Book '{bookToAdd.BookName}' (ISBN: {bookToAdd.ISBN})가 도서관에 추가되었습니다.");
            return true;
        }

        public bool CheckID(string id)
        {
            if (string.IsNullOrWhiteSpace(id)) return false;
            if (validUserIDs.Contains(id))
            {
                currentUserID = id;
                IsAdmin = adminIDs.Contains(id);
                Console.WriteLine($"ID '{id}' 확인. 사용자는 {(IsAdmin ? "관리자 입니다" : "일반 사용자 입니다")}.");
                return true;
            }
            Console.WriteLine($"ID '{id}'는 등록되지 않은 사용자 입니다.");
            IsAdmin = false;
            currentUserID = null;
            return false;
        }

        public bool CheckBook(string isbn)
        {
            if (string.IsNullOrWhiteSpace(isbn)) return false;
            return OwnedBooks.ContainsKey(isbn);
        }

        /// <summary>
        /// Searches for a book by its ISBN using the Try-Get pattern.
        /// </summary>
        /// <param name="isbn">The ISBN of the book to search for.</param>
        /// <param name="foundBook">The book object if found; otherwise, null.</param>
        /// <returns>True if the book is found, false otherwise.</returns>
        public bool TryGetBookByISBN(string isbn, out Book foundBook)
        {
            foundBook = null;
            if (string.IsNullOrWhiteSpace(isbn)) return false;
            return OwnedBooks.TryGetValue(isbn, out foundBook);
        }

        /// <summary>
        /// Finds a book by its ISBN and returns the Book object or null if not found.
        /// </summary>
        /// <param name="isbn">The ISBN of the book to search for.</param>
        /// <returns>The Book object if found; otherwise, null.</returns>
        public Book FindBookByISBN(string isbn)
        {
            if (string.IsNullOrWhiteSpace(isbn)) return null;
            OwnedBooks.TryGetValue(isbn, out Book foundBook);
            return foundBook; // Returns null if TryGetValue fails
        }

        /// <summary>
        /// Checks if a book equivalent to the provided book object (matched by ISBN)
        /// exists in the library's owned collection.
        /// This method adheres to the original diagram's signature SearchBook(Book): bool
        /// but has limited practical use for typical user-driven search scenarios compared to ISBN-based searches.
        /// </summary>
        /// <param name="bookToSearch">The book object to check for existence.</param>
        /// <returns>True if an equivalent book (by ISBN) exists, false otherwise.</returns>
        public bool SearchBook(Book bookToSearch)
        {
            if (bookToSearch == null || string.IsNullOrWhiteSpace(bookToSearch.ISBN))
            {
                Console.WriteLine("Warning: null 값이거나 ISBN이 없는 도서검색을 시도하였습니다.");
                return false;
            }
            // Check if a book with the same ISBN exists in our collection
            return OwnedBooks.ContainsKey(bookToSearch.ISBN);
        }

        public bool ReturnBook(Book bookToReturn)
        {
            if (bookToReturn == null || string.IsNullOrWhiteSpace(bookToReturn.ISBN))
            {
                Console.WriteLine("Error: 반납하려는 도서의 ISBN가 유효하지 않습니다.");
                return false;
            }
            if (OwnedBooks.TryGetValue(bookToReturn.ISBN, out Book actualBookInSystem))
            {
                if (actualBookInSystem.IsBorrowed)
                {
                    actualBookInSystem.IsBorrowed = false;
                    BorrowedBooks.Remove(actualBookInSystem.ISBN);
                    Console.WriteLine($"Book '{actualBookInSystem.BookName}' (ISBN: {actualBookInSystem.ISBN})이 성공적으로 반납되었습니다. {currentUserID ?? "N/A"}.");
                    return true;
                }
                else
                {
                    Console.WriteLine($"Error: Book '{actualBookInSystem.BookName}' (ISBN: {actualBookInSystem.ISBN})은 대여중으로 확인되지 않습니다.");
                    return false;
                }
            }
            else
            {
                Console.WriteLine($"Error: Book with ISBN '{bookToReturn.ISBN}'은 라이브러리 시스템에서 발견되지 않습니다.");
                return false;
            }
        }

        public bool RentBook(Book bookToRent)
        {
            if (bookToRent == null || string.IsNullOrWhiteSpace(bookToRent.ISBN))
            {
                Console.WriteLine("Error: 대여하려는 도서의 ISBN이 유효하지 않습니다.");
                return false;
            }
            if (string.IsNullOrWhiteSpace(currentUserID))
            {
                Console.WriteLine("Error: 현재 로그인한 사용자가 없습니다.");
                return false;
            }
            if (OwnedBooks.TryGetValue(bookToRent.ISBN, out Book actualBookInSystem))
            {
                if (!actualBookInSystem.IsBorrowed)
                {
                    actualBookInSystem.IsBorrowed = true;
                    BorrowedBooks.Add(actualBookInSystem.ISBN, actualBookInSystem);
                    Console.WriteLine($"Book '{actualBookInSystem.BookName}' (ISBN: {actualBookInSystem.ISBN})를 성공적으로 대여했습니다. by {currentUserID}.");
                    return true;
                }
                else
                {
                    Console.WriteLine($"Error: Book '{actualBookInSystem.BookName}' (ISBN: {actualBookInSystem.ISBN})는 이미 대여중 입니다.");
                    return false;
                }
            }
            else
            {
                Console.WriteLine($"Error: Book with ISBN '{bookToRent.ISBN}'는 도서관 목록에서 찾을 수 없습니다.");
                return false;
            }
        }

        public void ShowBookInfo(Book book)
        {
            if (book != null)
            {
                Console.WriteLine("\n--- 책 정보 ---");
                Console.WriteLine(book.ToString());
            }
            else
            {
                Console.WriteLine("book 객체가 null이므로 책 정보를 표시할 수 없습니다.");
            }
        }

        /// <summary>
        /// Displays all books currently owned by the library, sorted by BookName.
        /// </summary>
        public void ShowAllOwnedBooks()
        {
            Console.WriteLine("\n--- All Owned Books ---");
            if (OwnedBooks.Count == 0)
            {
                Console.WriteLine("There are no books currently registered in the library.");
                return;
            }

            // 책 이름으로 정렬하여 표시
            var sortedBooks = OwnedBooks.Values.OrderBy(book => book.BookName).ToList();

            Console.WriteLine($"Total books: {sortedBooks.Count}");
            Console.WriteLine("----------------------------------------------------------------------------------------------------");
            Console.WriteLine(String.Format("| {0,-18} | {1,-35} | {2,-20} | {3,-15} | {4,-10} |", "ISBN", "Book Name", "Author", "Publisher", "Status"));
            Console.WriteLine("----------------------------------------------------------------------------------------------------");
            foreach (Book book in sortedBooks)
            {
                Console.WriteLine(String.Format("| {0,-18} | {1,-35} | {2,-20} | {3,-15} | {4,-10} |",
                    book.ISBN,
                    Truncate(book.BookName, 33), // 길이 제한
                    Truncate(book.Author, 18),
                    Truncate(book.Publisher, 13),
                    book.IsBorrowed ? "Borrowed" : "Available"));
            }
            Console.WriteLine("----------------------------------------------------------------------------------------------------");
        }

        // 문자열 길이 자르기 헬퍼 함수 (테이블 형식 맞추기용)
        private string Truncate(string value, int maxLength)
        {
            if (string.IsNullOrEmpty(value)) return value;
            return value.Length <= maxLength ? value : value.Substring(0, maxLength - 3) + "...";
        }
    }
}
