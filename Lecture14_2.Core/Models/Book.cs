namespace Lecture14_2.Core.Models
{
    public class Book
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public int PublicationYear { get; set; }
        public string Genre { get; set; }

        public Book()
        {

        }

        public override string ToString()
        {
            return $"ID: {Id} | Title: {Title} | Author: {Author} | Year: {PublicationYear} | Genre: {Genre}";
        }
    }
}
