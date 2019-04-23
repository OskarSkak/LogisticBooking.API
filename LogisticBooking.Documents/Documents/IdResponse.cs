using System;

namespace LogisticBooking.Documents.Documents
{
    public class IdResponse : Response
    {
        public Guid Id { get; private set; }

        public IdResponse(Guid id, bool isSuccessful = true, string message = null, Exception exception = null) : base(isSuccessful, exception, message)
        {
            Id = id;
        }

        public static IdResponse Successful(Guid id)
        {
            return new IdResponse(id);
        }

        public new static IdResponse Unsuccessful(string message = null, Exception exception = null)
        {
            return new IdResponse(Guid.Empty, false, message, exception);
        }
    }
}