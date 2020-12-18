using System.Collections.Generic;
using JsonApiDotNetCore.Resources;
using JsonApiDotNetCore.Resources.Annotations;

namespace MyApi
{
    public class Person : Identifiable
    {
        [Attr]
        public string Name { get; set; }
        
        [HasMany]
        public ICollection<TodoItem> TodoItems { get; set; }
    }
}