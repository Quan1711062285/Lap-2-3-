using LapTrinhWeb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Runtime.Serialization;

namespace LapTrinhWeb.Controllers
{
    public class BookController : Controller
    {
        // GET: Book
        public String HelloTeacher(String university)
        { 
            return "Hello Thay Hung - University" + university;
        }

        public ActionResult ListBook()
        {
            var books = new List<string>();
            books.Add("HTML & CSS3 The compleete Manual - Arthor Name Book 1");
            books.Add("HTML5 & CSS Reponsive web Design cookbook - Author Name Book 2");
            books.Add("Profestional ASP.NET MVC5 - Author Name Book 2");
            ViewBag.Books = books;
            return View();
        }
        public ActionResult ListBookModel()
        {
            var books = new List<Book>();
            books.Add(new Book(1, "HTML & CSS3 The compleete Manual", "Arthor Name Book 1", "/Content/Img/html.png"));
            books.Add(new Book(2, "HTML5 & CSS Reponsive web Design cookbook", "Author Name Book 2", "/Content/Img/3055598863e2ad0.jpg"));
            books.Add(new Book(3, "Profestional ASP.NET MVC5", "Author Name Book 2", "/Content/Img/pro-asp-net-mvc-5.jpg"));
            return View(books);
        }
        [HttpPost, ActionName("EditBook")]
        [ValidateAntiForgeryToken]
        public ActionResult EditBook (int id,string Title,string Author, string ImageCover)
        {
            var books = new List<Book>();
            books.Add(new Book(1, "HTML & CSS3 The compleete Manual", "Arthor Name Book 1", "/Content/Img/html.png"));
            books.Add(new Book(2, "HTML5 & CSS Reponsive web Design cookbook", "Author Name Book 2", "/Content/Img/3055598863e2ad0.jpg"));
            books.Add(new Book(3, "Profestional ASP.NET MVC5", "Author Name Book 2", "/Content/Img/pro-asp-net-mvc-5.jpg"));
            Book book = new Book();
            if(id == null)
            {
                return HttpNotFound();
            }
            foreach(Book b in books)
            {
                if(b.Id==id)
                {
                    b.Title = Title;
                    b.Author = Author;
                    b.ImageCover = ImageCover;
                    break;
                }
            }
            
            return View("ListBookModel",books);
        }
        public ActionResult CreateBook()
        {
            return View();
        }
        [HttpPost, ActionName("CreateaBook")]
        [ValidateAntiForgeryToken]
        public ActionResult Contact([Bind(Include="Id, Title, Author, ImageCover")]Book book)
        {
            var books = new List<Book>();
            //sach mac dinh
            books.Add(new Book(1, "HTML & CSS3 The compleete Manual", "Arthor Name Book 1", "/Content/Img/html.png"));
            books.Add(new Book(2, "HTML5 & CSS Reponsive web Design cookbook", "Author Name Book 2", "/Content/Img/3055598863e2ad0.jpg"));
            books.Add(new Book(3, "Profestional ASP.NET MVC5", "Author Name Book 2", "/Content/Img/pro-asp-net-mvc-5.jpg"));
            try
            {
                if(ModelState.IsValid)
                {
                    //Them moi sach
                    books.Add(book);
                }
            }
            catch (RetrylimitExceededException /*dex*/)
            {
                ModelState.AddModelError("", "Error Save Data");
            }
            return View("ListBookModel", books);
        }
    }

    [Serializable]
    internal class RetrylimitExceededException : Exception
    {
        public RetrylimitExceededException()
        {
        }

        public RetrylimitExceededException(string message) : base(message)
        {
        }

        public RetrylimitExceededException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected RetrylimitExceededException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
