using System;
using System.Collections.Generic;
using System.Linq;
using Bookstore.Data.Sql.DAO;

namespace Bookstore.Data.Sql.Migrations
{
    //klasa odpowiadająca za wypełnienie testowymi danymi bazę danych
    public class DatabaseSeed
    {
        private readonly BookstoreDbContext _context;
        
        public DatabaseSeed(BookstoreDbContext context)
        {
            _context = context;
        }
        
        public void Seed()
        {
            #region CreateClient
            var clientList = BuildClientList();
            //dodanie użytkowników do tabeli Client
            _context.Client.AddRange(clientList);
            //zapisanie zmian w bazie danych
            _context.SaveChanges();
            #endregion
            
            #region CreatePublisher
            var publisherList = BuildPublisherList();
            _context.Publisher.AddRange(publisherList);
            _context.SaveChanges();
            #endregion
            
            #region CreateAuthor
            var authorList = BuildAuthorList();
            _context.Author.AddRange(authorList);
            _context.SaveChanges();
            #endregion
            
            #region CreateOrder
            var orderList = BuildOrderList(clientList);
            _context.Order.AddRange(orderList);
            _context.SaveChanges();
            #endregion
            
            #region CreateBook
            var bookList = BuildBookList(publisherList);
            _context.Book.AddRange(bookList);
            _context.SaveChanges();
            #endregion
            
            #region CreateBookOrder
            var bookOrderList = BuildBookOrderList(bookList, orderList);
            _context.BookOrder.AddRange(bookOrderList);
            _context.SaveChanges();
            #endregion
            
            #region CreateBookAuthor
            var bookAuthorList = BuildBookAuthorList(bookList, authorList);
            _context.BookAuthor.AddRange(bookAuthorList);
            _context.SaveChanges();
            #endregion
            

        }

        private IEnumerable<Client> BuildClientList()
        {
            var clientList = new List<Client>();
            var client = new Client()
            {
                ClientId = 1,
                UserName = "Ritvaa_",
                Password = "zaq1@WSX",
                FirstName = "Adriana",
                LastName = "Barteczko",
                Email = "a.barteczko@student.po.edu.pl",
                PhoneNo = "123456789",
                Street = "RandomStreet",
                HouseNo = "123",
                City = "Random City",
                ZipCode = "44-321",
                Country = "Poland"
            };
            clientList.Add(client);

            var client2 = new Client()
            {
                ClientId = 2,
                UserName = "Nancy",
                Password = "zaq1@WSX",
                FirstName = "Anna",
                LastName = "Mrozek",
                Email = "an.mrozek@student.po.edu.pl",
                PhoneNo = "123456789",
                Street = "RandomStreet",
                HouseNo = "123",
                City = "Random City",
                ZipCode = "44-321",
                Country = "Poland"
            };
            clientList.Add(client2);
            
            for (int i = 3; i <= 10; i++)
            {
                var client3 = new Client()
                {
                    ClientId = i,
                    UserName = "user" + i,
                    Password = "zaq1@WSX",
                    FirstName = "Joe" + i,
                    LastName = "Mrozek",
                    Email = "user" + i + "@student.po.edu.pl",
                    PhoneNo = "123456789",
                    Street = "RandomStreet",
                    HouseNo = "100",
                    City = "Random City",
                    ZipCode = "44-321",
                    Country = "Poland"
                };
                clientList.Add(client3);
            }

            return clientList;
        }
        private IEnumerable<Publisher> BuildPublisherList()
        {
            var publisherList = new List<Publisher>
            {
                new Publisher
                {
                    PublisherId = 1,
                    PublisherName = "Egmont Polska"
                },
                
                new Publisher
                {
                    PublisherId = 2,
                    PublisherName = "Nowy Świat"
                },
                
                new Publisher
                {
                    PublisherId = 3,
                    PublisherName = "Prószyński i S-ka"
                },
                new Publisher
                {
                    PublisherId = 4,
                    PublisherName = "Świat Książki"
                },
                new Publisher
                {
                    PublisherId = 5,
                    PublisherName = "Wydawnictwo Współczesne"
                },
            };
            return publisherList;
        }

        private IEnumerable<Author> BuildAuthorList()
        {
            var authorList = new List<Author>
            {
                new Author
                {
                    AuthorId = 1,
                    FirstName = "Remigiusz",
                    LastName = "Mróz"
                },
                new Author
                {
                    AuthorId = 2,
                    FirstName = "George R.R",
                    LastName = "Martin"
                },
                new Author
                {
                    AuthorId = 3,
                    FirstName = "J.R.R",
                    LastName = "Tolkien"
                },

            };
            return authorList;
        }

        private IEnumerable<Order> BuildOrderList(IEnumerable<Client> clientList)
        {
            var orderList = new List<Order>
            {
                new Order
                {
                    ClientId = clientList.FirstOrDefault().ClientId,
                    OrderDate = DateTime.UtcNow,
                    Quantity = 3,
                },
                new Order
                {
                    ClientId = clientList.FirstOrDefault().ClientId,
                    OrderDate = DateTime.UtcNow.AddMinutes(60),
                    Quantity = 4,
                },
                new Order
                {
                    ClientId = clientList.FirstOrDefault().ClientId,
                    OrderDate = DateTime.UtcNow.AddMinutes(20),
                    Quantity = 3,
                },
                new Order
                {
                    ClientId = clientList.FirstOrDefault().ClientId,
                    OrderDate = DateTime.UtcNow.AddMinutes(90),
                    Quantity = 3,
                },
                new Order
                {
                    ClientId = clientList.FirstOrDefault().ClientId,
                    OrderDate = DateTime.UtcNow.AddMinutes(30),
                    Quantity = 3,
                },
                new Order
                {
                    ClientId = clientList.FirstOrDefault().ClientId,
                    OrderDate = DateTime.UtcNow,
                    Quantity = 3,
                },
                new Order
                {
                    ClientId = clientList.FirstOrDefault().ClientId,
                    OrderDate = DateTime.UtcNow.AddMinutes(50),
                    Quantity = 3,
                },
                new Order
                {
                    ClientId = clientList.FirstOrDefault().ClientId,
                    OrderDate = DateTime.UtcNow,
                    Quantity = 3,
                },
                new Order
                {
                    ClientId = clientList.FirstOrDefault().ClientId,
                    OrderDate = DateTime.UtcNow.AddMinutes(120),
                    Quantity = 3,
                },
                new Order
                {
                    ClientId = clientList.FirstOrDefault().ClientId,
                    OrderDate = DateTime.UtcNow.AddMinutes(75),
                    Quantity = 3,
                }
                
            };
            return orderList;
        }
        
        private IEnumerable<DAO.Book> BuildBookList(IEnumerable<Publisher> publisherList)
        {
            var bookList = new List<DAO.Book>();
            for (int i = 1; i <= 10; i++)
            {
                var book = new DAO.Book()
                {
                    BookId = i,
                    Title = "RandomBook" + i,
                    Description = "RandomBook" + i,
                    Price = 20+i%8+i,
                    PublisherId = publisherList.FirstOrDefault().PublisherId,
                    // BookAuthors = new List<BookAuthor>()
                    // {
                    //     new BookAuthor()
                    //     {
                    //         BookAuthorId = 1,
                    //         BookId = 1,
                    //         AuthorId = 1
                    //     },
                    //     new BookAuthor()
                    //     {
                    //         BookAuthorId = 2,
                    //         BookId = 1,
                    //         AuthorId = 2
                    //     },
                    //     new BookAuthor()
                    //     {
                    //         BookAuthorId = 3,
                    //         BookId = 1,
                    //         AuthorId = 3
                    //     }
                    // }
                };
                bookList.Add(book);
            }
            return bookList;
        }
        
        private IEnumerable<BookAuthor> BuildBookAuthorList(IEnumerable<DAO.Book> bookList, IEnumerable<Author> authorList)
        {
            var bookauthorList = new List<BookAuthor>();
            for (int i = 1; i <= 10; i++)
            {
                var bookauthor = new BookAuthor()
                {
                    BookAuthorId = i,
                    BookId = i,
                    AuthorId = 2
                };
                bookauthorList.Add(bookauthor);
            }
            return bookauthorList;
        }
        
        private IEnumerable<BookOrder> BuildBookOrderList(IEnumerable<DAO.Book> bookList, IEnumerable<Order> orderList)
        {
            var bookorderList = new List<BookOrder>();
            for (int i = 1; i <= 10; i++)
            {
                var bookorder = new BookOrder()
                {
                    BookOrderId = i,
                    BookId = i,
                    OrderId = i
                    // Quantity = i
                };
                bookorderList.Add(bookorder);
            }
            return bookorderList;
        }
        
    }

}