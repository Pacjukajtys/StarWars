using System.Collections.Generic;

namespace StarWars.Contracts.Requests
{
    public class UpdatePostRequest
    {
        public string Name { get; set; }
        public string Planet { get; set; }
        public IEnumerable<string> Episodes { get; set; }
        public IEnumerable<string> Friends { get; set; }
    }
}
