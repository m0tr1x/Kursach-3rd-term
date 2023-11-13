namespace Biblioteque
{

    /// <summary>
    /// Класс книги 
    /// </summary>
    class Book
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
        public bool Avaliable { get; set; }
        public void MarkAsTaken()
        {
            this.Avaliable = false;
            Condition -= 1;
        }

        public void MarkAsReturned()
        {
            this.Avaliable = true;
        }

        public Book(string Name, string Author, double Condition, bool Avaliable)
        {
            this.Name = Name;
            this.Author = Author;
            this.Condition = Condition;
            this.Avaliable = Avaliable;
        }

    }

}