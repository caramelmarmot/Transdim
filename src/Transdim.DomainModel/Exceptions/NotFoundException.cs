using System;

namespace Transdim.DomainModel.Exceptions
{
    public class NotFoundException : Exception
    {
        public NotFoundException(string message)
           : base(message)
        {
        }

        public NotFoundException(Exception innerException, string message = null)
            : base(message, innerException)
        {
        }
    }
}
