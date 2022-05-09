using System;

namespace Bookstore.Domain.DomainExceptions
{
    public class InvalidTitleException: Exception
    {
        public InvalidTitleException(string Title): base(ModifyMessage(Title))
        {
        }
        
        private static string ModifyMessage(string Title)
        {
            return $"The title {Title} is invalid";
        }
    }

}