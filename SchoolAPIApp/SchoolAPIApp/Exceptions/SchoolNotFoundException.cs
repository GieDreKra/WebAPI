namespace SchoolAPIApp.Exceptions
{
    public class SchoolNotFoundException:Exception
    {
        public SchoolNotFoundException()
        {
        }

        public SchoolNotFoundException(string message)
            : base(message)
        {
        }

        public SchoolNotFoundException(string message, Exception inner)
            : base(message, inner)
        {
        }
    }
}
