using System;
using Bookstore.Domain.DomainExceptions;
using Xunit;

namespace Bookstore.Domain.Tests.Book
{
    public class BookTest
    {
        public BookTest()
        {
            //Arrange
            //Act
            //Assert
        }

        [Fact]
        public void AddBook_Returns_throws_Exception()
        {
            Assert.Throws<InvalidTitleException>
                (() => new Domain.Book.Book("E,mjkwEm_-:!%-NFDYL]-9i-p9Y?MFM!/b7bUBataa", "Desctiption", (decimal) 21.37, "Image", 1));
        }
    }
}