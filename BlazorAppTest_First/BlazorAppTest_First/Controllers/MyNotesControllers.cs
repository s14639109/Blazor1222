using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using BlazorAppTest_First.Models;

namespace BlazorAppTest_First.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MyNotesControllers : ControllerBase
    {
        public MyNoteDBContent MynoteDbContext { get; }

        public MyNotesControllers(MyNoteDBContent myNoteDBContext)
        {
            MynoteDbContext = myNoteDBContext;
        }

        [HttpGet]
        public IEnumerable<MyNote> Get()
        {
            return MynoteDbContext.MyNotes.ToList();
        }

        [HttpGet("{id}",Name ="Get")]
        public MyNote Get(int id)
        {
            return MynoteDbContext.MyNotes.FirstOrDefault(x => x.Id == id);
        }

        [HttpPost]
        public void Post([FromBody] MyNote myNote)
        {
            MynoteDbContext.MyNotes.Add(myNote);
            MynoteDbContext.SaveChanges();
        }

        [HttpPut("{id}")]
        public void Put(int id,[FromBody]MyNote myNote)
        {
            MyNote NoteItem = MynoteDbContext.MyNotes.FirstOrDefault(x => x.Id == id);
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            MynoteDbContext.MyNotes.Remove(MynoteDbContext.MyNotes.FirstOrDefault(x=>x.Id==id));
            MynoteDbContext.SaveChanges();

        }
    }
}
