using BlazorAppTest_First.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorAppTest_First.Service
{
    public class MyNoteDBService : IMyNoteService
    {
        public MyNoteDBContent MyNoteDbContext { get; }

        public MyNoteDBService(MyNoteDBContent myNoteDBContent)
        {
            MyNoteDbContext = myNoteDBContent;
        }
        public async Task CreateAsync(MyNote addmyNote)
        {
            await MyNoteDbContext.MyNotes.AddAsync(addmyNote);
            await MyNoteDbContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(MyNote deletemyNote)
        {
            MyNoteDbContext.MyNotes.Remove(await MyNoteDbContext.MyNotes.FirstOrDefaultAsync(x => x.Id == deletemyNote.Id));
            await MyNoteDbContext.SaveChangesAsync();
        }

        public async Task EditAsync(MyNote origMyNote, MyNote myNote)
        {
            var footItem = await MyNoteDbContext.MyNotes.FirstOrDefaultAsync(x=>x.Id==origMyNote.Id);
            if (footItem!=null)
            {
                footItem.title = myNote.title;
                await MyNoteDbContext.SaveChangesAsync();
            }
        }

        public async Task<List<MyNote>> RetriveAsync()
        {
            return await MyNoteDbContext.MyNotes.ToListAsync();
        }
    }
}
