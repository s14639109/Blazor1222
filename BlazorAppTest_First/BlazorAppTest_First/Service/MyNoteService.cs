using BlazorAppTest_First.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorAppTest_First.Service
{
    public class MyNoteService : IMyNoteService
    {
        List<MyNote> MyNotes { set; get; }

        public MyNoteService()
        {
            MyNotes = new List<MyNote>()
            {
                new MyNote{ title="buy Apple"},
                new MyNote{ title="buy Banana"},
                new MyNote{ title="buy Guava"}
            };
        }
        public Task CreateAsync(MyNote addmyNote)
        {
            MyNotes.Add(addmyNote);
            return Task.FromResult(0);
        }

        public Task DeleteAsync(MyNote deletemyNote)
        {
            MyNotes.Remove(deletemyNote);
            return Task.FromResult(0);
        }

        public Task EditAsync(MyNote origMyNote, MyNote myNote)
        {
            MyNotes.FirstOrDefault(x=>x.title==origMyNote.title).title=myNote.title;
            return Task.FromResult(0);
        }

        public Task<List<MyNote>> RetriveAsync()
        {
            return Task.FromResult(MyNotes);
        }
    }
}
