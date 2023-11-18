namespace Biblioteque
{

    /// <summary>
    /// Класс книги 
    /// </summary>
    public class Book
    {
        private string? _name;
        private string? _author;
        private double _condition;
        // Название книги
        public string? Name
        {
            get { return _name; }
            set { if (value != null) _name = value; }
        }
        // Автор книги
        public string? Author
        {
            get { return _author; }
            set { if (value != null) _author = value; }
        }

        // Состояние книги
        public double Condition
        {
            get { return _condition; }
            set
            {
                if (value > 0 && value <= 100) _condition = value;
            }
        }
        // Наличие книги
        public int Owner { get; private set; } = 0;
        /// <summary>
        /// Метод для обозначения книги как взятой
        /// </summary>
        /// <param name="Owner"></param>
        public void MarkAsTaken(Customer Owner)
        {
            this.Owner = Owner.Id;
            Condition -= 1;
        }
        /// <summary>
        /// Метод для обозначения книги возвращенной
        /// </summary>
        public void MarkAsReturned()
        {
            this.Owner = 0;
        }

        public Book(string Name, string Author, double Condition)
        {
            this.Name = Name;
            this.Author = Author;
            this.Condition = Condition;
        }
        public Book(string Name, string Author, double Condition,int Owner) : this(Name, Author, Condition)
        {
            this.Owner = Owner;
        }

    }

}