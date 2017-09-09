using Raven.Imports.Newtonsoft.Json;

namespace MyService.Application.Model
{
    public class Promotion
    {
       
        public string Id { get; set; }

        public string Name { get; set; }

        public int MinimalCount { get; set; }

        public int CurrentCount { get; set; }

        public bool IsDeleted { get; set; }

        [JsonIgnore]
        public bool IsActive { get { return !this.IsDeleted && this.CurrentCount >= this.MinimalCount; } }
    }
}
