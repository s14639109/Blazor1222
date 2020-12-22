using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorAppTest_First.Models
{
    public class MyNoteDBContent:DbContext
    {
        public MyNoteDBContent(DbContextOptions<MyNoteDBContent> options) :
            base(options)
        {

        }
        public DbSet<MyNote> MyNotes { set; get; }
    }
}
