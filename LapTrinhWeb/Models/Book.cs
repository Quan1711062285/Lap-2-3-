using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace LapTrinhWeb.Models
{
    public class Book
    {
        private int id;
        private string title;
        private string author;
        private string image_cover;

        public Book()
        {

        }
        public Book(int id ,string title ,string author ,string image_cover)
        {
            this.id = id;
            this.title = title;
            this.author = author;
            this.image_cover = image_cover;
   
        }
        public int Id
        {
            get { return id;}

        }
   
        [Required(ErrorMessage= "Tieu de khong dc trong")]
        [StringLength(250,ErrorMessage= "Tieu de sach ko vuot qua 250 ky tu")]
        [Display(Name ="Tieu de")]

        public string Title
        {
            get { return title; }
            set { title = value;}
        }
        public string Author
        {
            get { return author; }
            set { author = value; }
        }
        public string CodeSach
        {
            get { return CodeSach; }
            set { CodeSach = value; }
        }
        public string ImageCover
        {
            get { return image_cover; }
            set { image_cover = value; }

        }
    }
}