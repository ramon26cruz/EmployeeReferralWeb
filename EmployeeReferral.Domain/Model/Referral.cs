using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeReferral.Domain.Model
{
    public class Referral
    {
        protected Referral()
        {
        }

        public Referral(Guid id, Guid jobRequisitionId, string nameOfReferral, string contactNumber, string emailAddress, string confirmationQuestion)
        {
            Id = id;
            JobRequisitionId = jobRequisitionId;
            NameOfReferral = nameOfReferral;
            ContactNumber = contactNumber;
            EmailAddress = emailAddress;
            ConfirmationQuestion = confirmationQuestion;
        }

        public static Referral Create(Guid id, Guid jobRequisitionId, string nameOfReferral, string contactNumber, string emailAddress, string confirmationQuestion)
        {
            return new Referral(id, jobRequisitionId, nameOfReferral, contactNumber, emailAddress, confirmationQuestion);
        }

        public Guid Id { get; set; }
        public virtual JobRequisition JobRequisition { get; set; }
        public Guid JobRequisitionId { get; set; }
        public string NameOfReferral { get; set; }
        public string ContactNumber { get; set; }
        public string EmailAddress { get; set; }
        public string ConfirmationQuestion { get; set; }
        
    }
}
