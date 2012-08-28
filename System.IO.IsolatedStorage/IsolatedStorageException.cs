
namespace System.IO.IsolatedStorage
{
    public class IsolatedStorageException : Exception
    {
        public IsolatedStorageException()
            : base()
        {
        }

        public IsolatedStorageException(string message)
            : base(message)
        {
        }

        public IsolatedStorageException(string message, Exception inner)
            : base(message, inner)
        {
        }
    }
}
