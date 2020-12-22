using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BlazorAppTest_First.Models;

namespace BlazorAppTest_First.Service
{
    public interface IMyNoteService
    {
        /*新增新紀錄*/
        Task CreateAsync(MyNote addmyNote);

        /*刪除紀錄*/
        Task DeleteAsync(MyNote deletemyNote);

        /*查詢所有紀錄*/
        Task<List<MyNote>> RetriveAsync();

        /*編輯紀錄*/
        Task EditAsync(MyNote origMyNote, MyNote myNote);
    }
}
