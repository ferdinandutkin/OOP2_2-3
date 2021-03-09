using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OOP2_2
{
    
    static class Program
    {
        public enum Occupation
        {
           Duck, Quack
        }
        


        public enum FileExtensions { docx, pdf, djvu, fb2};



        public enum BookGenres { Fantasy, Detective, Classics, Horror}


        public abstract class BookFactory
        {
            [FactoryMethod(Name = ".pdf книга")]
            public abstract Book CreatePDFBook(string name, int fileSize, Book.PublisherInfo publisher, List<Book.AuthorInfo> authors);

            [FactoryMethod(Name = ".docx книга")]
            public abstract Book CreateDOCXBook(string name, int fileSize, Book.PublisherInfo publisher, List<Book.AuthorInfo> authors);

            [FactoryMethod(Name = ".djvu книга")]
            public abstract Book CreateDJVUBook(string name, int fileSize, Book.PublisherInfo publisher, List<Book.AuthorInfo> authors);

        }



        public abstract class GenreBookFactory : BookFactory
        {
            protected Book CreateBookWithTargetGenre(string name, int fileSize, Book.PublisherInfo publisher, List<Book.AuthorInfo> authors, FileExtensions extension)
                => new Book() { Name = name, FileSize = fileSize, Publisher = publisher, Authors = authors, Genre = TargetGenre, Extension = extension };


            protected abstract BookGenres TargetGenre { get; set; }


            public override Book CreatePDFBook(string name, int fileSize, Book.PublisherInfo publisher, List<Book.AuthorInfo> authors)
                => CreateBookWithTargetGenre(name, fileSize, publisher, authors, FileExtensions.pdf);
         
            public override Book CreateDOCXBook(string name, int fileSize, Book.PublisherInfo publisher, List<Book.AuthorInfo> authors) 
                => CreateBookWithTargetGenre(name, fileSize, publisher, authors, FileExtensions.docx);
            public override Book CreateDJVUBook(string name, int fileSize, Book.PublisherInfo publisher, List<Book.AuthorInfo> authors)
                => CreateBookWithTargetGenre(name, fileSize, publisher, authors, FileExtensions.djvu);
        }



        [FactoryClass("Фэнтези книги")]
        public class FantasyBookFactory : GenreBookFactory
        {
            protected override BookGenres TargetGenre { get; set; } = BookGenres.Fantasy;  
         
        }


        [FactoryClass("Детективные книги")]
        public class DetectiveBookFactory : GenreBookFactory
        {
            protected override BookGenres TargetGenre { get; set; } = BookGenres.Detective;

        }


        [FactoryClass("Классическая литература")]
        public class ClassicBookFactory : GenreBookFactory
        {
            protected override BookGenres TargetGenre { get; set; } = BookGenres.Classics;

        }

        [FactoryClass("Книги ужасов")]
        public class HorrorBookFactory : GenreBookFactory
        {
            protected override BookGenres TargetGenre { get; set; } = BookGenres.Horror;

        }


        public class Book
        {

            public Book()
            {

            }

            public BookGenres Genre { get; set; }
            public FileExtensions Extension { get; set; }
            public int FileSize { get; set; }
            public string Name { get; set; } = "";

            public class AuthorInfo
            {
                public AuthorInfo()
                {

                }
                public string Name { get; set; } = "";
                public int BirthYear { get; set; }

                public string Country { get; set; } = "";

            }

       

            public class PublisherInfo
            {
                 public PublisherInfo()
                {

                }
                public string Name { get; set; } = "";
                public int FoundationYear { get; set; }

                public bool Private { get; set; }


            }

            public PublisherInfo Publisher { get; set; } = new();
            public List<AuthorInfo> Authors { get; set; } = new List<AuthorInfo>() { new(), new(), new(), new(), new() };
        }

        public class Person
        {

            public class Test
            {
                public class Test2
                {
                    public string Field1 { get; set; } = string.Empty;
                    public string Field2 { get; set; } = string.Empty;
                }

                public bool b { get; set; } = default;

                public Test2 Field3 { get; set; } = new();
                public string Field1 { get; set; }  = string.Empty;
                public List<int> ListArr { get; set; } = new List<int>(){ 1, 4, 5, 6, 3, 2, 45 };

                public string Field2 { get; set; } = string.Empty;
            }

         
         public Test TestProp { get; set; } = new();
            public Occupation Occupation { get; set; }
         
            public int Age { get; set; } = default;
            public string Name { get; set; } = string.Empty;
        
        }




      
        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new CollectionForm(typeof(Book), typeof(BookFactory)));
        }
    }
}
