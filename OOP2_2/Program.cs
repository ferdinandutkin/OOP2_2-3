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
        


        public enum FileExtension { doc, docx, pdf, djvu, txt};

        class ELib
        {

            public ELib()
            {

            }
            public FileExtension Extension { get; set; }
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
            Application.Run(new CollectionForm(typeof(Person)));
        }
    }
}
