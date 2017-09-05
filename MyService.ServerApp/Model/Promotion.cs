using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyService.ServerApp.Model
{
    public class Promotion
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public int MinimalCount { get; set; }

        public int CurrentCount { get; set; }

        public bool IsCancelled { get; set; }

        public bool IsActive { get { return !this.IsCancelled && this.CurrentCount >= this.MinimalCount; } }
    }
}
