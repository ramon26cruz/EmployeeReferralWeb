using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeReferral.Domain.Model
{
    public class JobRequisition
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public bool IsActive { get; set; }
        protected JobRequisition()
        {
        }
        private JobRequisition(Guid id, string title, string description, bool isActive)
        {
            Id = id;
            Title = title;
            Description = description;
            IsActive = isActive;
        }
        public static JobRequisition Create(Guid id, string title, string description, bool isActive)
        {
            return new JobRequisition(id, title, description, isActive);
        }
    }
}
