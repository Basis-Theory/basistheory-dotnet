using System;
using System.Net;

namespace BasisTheory.net.Common.Errors
{
    public class BasisTheoryException : Exception
    {
        public BasisTheoryException()
        {
        }

        public BasisTheoryException(string message)
            : base(message)
        {
        }

        public BasisTheoryException(string message, Exception err)
            : base(message, err)
        {
        }

        public BasisTheoryException(HttpStatusCode httpStatusCode, BasisTheoryError error, string message)
            : base(message)
        {
            this.HttpStatusCode = httpStatusCode;
            this.Error = error;
        }

        public HttpStatusCode HttpStatusCode { get; set; }

        public BasisTheoryError Error { get; set; }
    }
}
