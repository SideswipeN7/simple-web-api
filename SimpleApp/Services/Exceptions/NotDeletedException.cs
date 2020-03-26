using System;

namespace SimpleApp.Services
{
    public class NotDeletedException : Exception
    {
        public NotDeletedException(Guid guid) : base($"Failed to delele object with id: {guid}") { }
    }
}