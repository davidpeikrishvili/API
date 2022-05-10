using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
namespace AnimeAPI.Models
{
    public  class Response
    {
        [Key]
        public  int StatusCode { get; set; }
        public string StatusDesc { get; set; }
        public info? info { get; set; }
        public Theme? theme { get; set; }
    }
}
