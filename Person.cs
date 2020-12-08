using JsonApiDotNetCore.Resources;
using JsonApiDotNetCore.Resources.Annotations;

namespace MyApi
{
    public class Person : Identifiable
    {
        [Attr]
        public string Name { get; set; }
    }
}