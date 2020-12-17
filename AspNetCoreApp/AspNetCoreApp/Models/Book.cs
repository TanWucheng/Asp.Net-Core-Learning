using System;
using System.ComponentModel.DataAnnotations;

namespace AspNetCoreApp.Models
{
    public class Book
    {
        public int Id { get; set; }

        [Display(Name = "标题")]
        public string Title { get; set; }

        [Display(Name = "出版日期")]
        [DataType(DataType.Date)]
        public DateTime PublicationDate { get; set; }

        [Display(Name = "作者")]
        public string Author { get; set; }

        [Display(Name = "价格")]
        public decimal Price { get; set; }

        [Display(Name = "类型")]
        public string Type { get; set; }
    }
}
