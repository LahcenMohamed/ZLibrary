using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using ZLibrary.Models.DTO;
using ZLibrary.Models;
using ZLibrary.Repository;
using ZLibrary.View.Views;
using GalaSoft.MvvmLight.CommandWpf;

namespace ZLibrary.View.ViewModels
{
    public class BookVM : INotifyPropertyChanged
    {
        private Book _book;
        private BookDTO _selectBook;
        private ObservableCollection<BookDTO> _Books;
        private ObservableCollection<Book> _FillterBooks;
        private ObservableCollection<string> _categoryNames;
        private IDataHalper<Book> dataHalper;
        private CategoryRepo categoryRepo;
        private string _search;
        private string _categroyName;

        public string? Name
        {
            get
            {
                return _book.Name;
            }
            set
            {
                if (_book.Name != value)
                {
                    _book.Name = value;
                    onPropertyChanged(nameof(_book.Name));

                }
            }
        }
        public string? Author
        {
            get { return _book?.Author; }
            set
            {
                if (_book?.Author != value)
                {
                    _book.Author = value;
                    onPropertyChanged(nameof(Author));
                }
            }
        }
        public string? Publisher
        {
            get { return _book?.Publisher; }
            set
            {
                if (_book?.Publisher != value)
                {
                    _book.Publisher = value;
                    onPropertyChanged(nameof(Publisher));
                }
            }
        }
        public byte[]? Photo
        {
            get { return _book?.Photo; }
            set
            {
                if (_book?.Photo != value)
                {
                    _book.Photo = value;
                    onPropertyChanged(nameof(Photo));
                }
            }
        }
        public int? CountOfCopies
        {
            get { return _book?.CountOfCopies; }
            set
            {
                if (_book?.CountOfCopies != value)
                {
                    _book.CountOfCopies = (int)value;
                    onPropertyChanged(nameof(CountOfCopies));
                }
            }
        }
        public int? CategoryID
        {
            get { return _book?.CategoryID; }
            set
            {
                if (_book?.CategoryID != value)
                {
                    _book.CategoryID = (int)value;
                    onPropertyChanged(nameof(CategoryID));
                }
            }
        }
        public string? CategoryName
        {
            get { return _categroyName; }
            set
            {
                if (_categroyName != value)
                {
                    _categroyName = value;
                    onPropertyChanged(nameof(_categroyName));
                }
            }
        }
        public string? AddCategoryName
        {
            get
            {
                return _categroyName;
            }
            set
            {
                if (_categroyName != value)
                {
                    _categroyName = value;
                    onPropertyChanged(nameof(_categroyName));

                }
            }
        }
        public string? Search {
            get
            {
                return _search;
            }
            set
            {
                if (_search != value)
                {
                    _search = value;
                    SearchAsync();
                    onPropertyChanged(nameof(_search));

                }
            }
        }
        public BookDTO? SelectBook
        {
            get { return _selectBook; }
            set
            {
                if (_selectBook != value)
                {
                    _selectBook = value;
                    onPropertyChanged(nameof(SelectBook));
                }
            }
        }
        public ObservableCollection<BookDTO>? Books
        {
            get { return _Books; }
            set
            {
                if (_Books != value)
                {
                    _Books = value;
                    onPropertyChanged(nameof(Books));
                }
            }
        }
        public ObservableCollection<Book>? FillterBooks
        {
            get { return _FillterBooks; }
            set
            {
                if (_FillterBooks != value)
                {
                    _FillterBooks = value;
                    onPropertyChanged(nameof(FillterBooks));
                }
            }
        }
        public ObservableCollection<string>? CategoryNames
        {
            get
            {
                return _categoryNames;
            }
            set
            {
                if (_categoryNames != value)
                {
                    _categoryNames = value;
                    onPropertyChanged(nameof(CategoryNames));
                }
            }
        }
        public ICommand Add { get; }
        public ICommand Edit { get; }
        public ICommand Delete { get; }
        public ICommand Save { get; }
        public ICommand Add_Category { get; }
        public ICommand SaveAddCategory { get; }

        public BookVM()
        {
            _book = new Book();
            _Books = new ObservableCollection<BookDTO>();
            _FillterBooks = new ObservableCollection<Book>();
            _selectBook = new BookDTO();
            dataHalper = new BookRepo();
            Add = new RelayCommand(AddCommand);
            Edit = new RelayCommand(EditCommand);
            Delete = new RelayCommand(DeleteCommand);
            Save = new RelayCommand(SaveCommand);
            Add_Category = new RelayCommand(ADDCotegry);
            SaveAddCategory = new RelayCommand(SaveCategory);
            _categroyName = string.Empty;
            categoryRepo = new CategoryRepo();
            _categoryNames = new ObservableCollection<string>();
            LoadData();
        }

        private void SaveCategory()
        {
            Category category = new Category() { 
             Name = AddCategoryName
            };
            categoryRepo.Add(category);
        }

        private void ADDCotegry()
        {
            AddCategory addCategory = new AddCategory(this);
            addCategory.Show();
        }

        private async void LoadData()
        {
            Thread.Sleep(500);
            _Books.Clear();
            foreach (var item in await dataHalper.GetAll())
            {
                BookDTO bookDTO = new BookDTO()
                {
                    Id = item.Id,
                    Name = item.Name,
                    Author = item.Author,
                    Publisher = item.Publisher,
                    CountOfCopies = item.CountOfCopies,
                    CategoryName = item.Category.Name
                };
                _Books.Add(bookDTO);
            }
        }

        private async void SaveCommand()
        {
            if (SelectBook == null)
            {
                int id = await categoryRepo.FindByName(_categroyName);
                Book book = new Book()
                {
                    Name = Name,
                    Author = Author,
                    Publisher = Publisher,
                    CountOfCopies = (int)CountOfCopies,
                    CategoryID = id
                };
                dataHalper.Add(book);
                LoadData();
            }
            else {
                int id = await categoryRepo.FindByName(_categroyName);
                Book book = new Book()
                {
                    Id = SelectBook.Id,
                    Name = Name,
                    Author = Author,
                    Publisher = Publisher,
                    CountOfCopies = (int)CountOfCopies,
                    CategoryID = id
                };
                dataHalper.Update(book);
                LoadData();
            }
        }

        private void DeleteCommand()
        {
            dataHalper.Delete(SelectBook.Id);
            LoadData();
        }

        private async void EditCommand()
        {
            foreach (var item in await categoryRepo.GetNames())
            {
                _categoryNames.Add(item);
            }
            Name = SelectBook.Name;
            Author = SelectBook.Author;
            Publisher = SelectBook.Publisher;
            CountOfCopies = SelectBook.CountOfCopies;
            CategoryName = SelectBook.CategoryName;

            Add_EditBooks add_EditBooks = new Add_EditBooks(this);
            add_EditBooks.Show();
        }

        private async void AddCommand()
        {
            SelectBook = null;
            foreach (var item in await categoryRepo.GetNames())
            {
                _categoryNames.Add(item);
            }
            Add_EditBooks add_EditBooks = new Add_EditBooks(this);
            add_EditBooks.Show();
        }
        public async void SearchAsync()
        {
            string searchText = Search; // Convert search text to lowercase for case-insensitive search
            _Books.Clear();

            foreach (var book in await dataHalper.SearchAsync(searchText))
            {
                BookDTO bookDTO = new BookDTO()
                {
                    Name = book.Name,
                    Author = book.Author,
                    Publisher = book.Publisher,
                    CountOfCopies = book.CountOfCopies,
                    CategoryName = book.Category.Name,
                    Id = book.Id
                };
                _Books.Add(bookDTO);
            }
        }

        public event PropertyChangedEventHandler? PropertyChanged;
        protected virtual void onPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
