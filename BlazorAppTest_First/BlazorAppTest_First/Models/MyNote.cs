using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using System.Text.Json.Serialization;

namespace BlazorAppTest_First.Models
{
    public class MyNote:ICloneable
    {
        [JsonPropertyName("Id")]
        public int Id { set; get; }
        [Required(ErrorMessage="Item can't null!!")]
        [JsonPropertyName("title")]
        public string title { set; get; }

        public MyNote Clone()
        {
            return ((ICloneable)this).Clone() as MyNote;
        }
        object ICloneable.Clone()
        {
            return this.MemberwiseClone();
        }
    }
}
