namespace SearchLibrary.Models
{
    public class CourseQuery
    {
        public string Query { get; set; }

        public int Start { get; set; }

        public int Rows { get; set; } = 10;
    }
}
