using System;

namespace WfaServer.Model
{
    public class Promotion
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public int MinimalCount { get; set; }

        public int CurrentCount { get; set; }

        public bool IsCancelled { get; set; }

        public bool IsActive { get { return !this.IsCancelled && this.CurrentCount >= this.MinimalCount; }  }
    }
}
