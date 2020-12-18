using JsonApiDotNetCore.Resources;
using JsonApiDotNetCore.Resources.Annotations;

namespace MyApi
{
    public class TodoItem : Identifiable
    {
        [Attr]
        public string Todo { get; set; }
        
        [Attr]
        public uint Priority { get; set; }

        [HasOne]
        public Person Owner { get; set; }
    }
}