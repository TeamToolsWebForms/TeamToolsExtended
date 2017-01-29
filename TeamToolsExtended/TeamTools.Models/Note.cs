using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeamTools.Models
{
    public class Note
    {
        // related user

        public int Id { get; set; }

        public string Title { get; set; }

        public string Content { get; set; }
    }
}
