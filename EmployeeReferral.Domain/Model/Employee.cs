using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeReferral.Domain.Model
{
    public class Employee
    {
        public Guid Id { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string EmployeeId { get; set; }
        public string ContactNumber { get; set; }
        public string EmailAddress { get; set; }
        public virtual ICollection<Referral> Referrals { get; set; }
        protected Employee()
        {
        }

        public Employee(Guid id, string lastName, string firstName, string middleName, string employeeId, string contactNumber, string emailAddress)
        {
            Id = id;
            LastName = lastName;
            FirstName = firstName;
            MiddleName = middleName;
            EmployeeId = employeeId;
            ContactNumber = contactNumber;
            EmailAddress = emailAddress;
        }

        public static Employee Create(Guid id, string lastName, string firstName, string middleName, string employeeId, string contactNumber, string emailAddress)
        {
            return new Employee(id, lastName, firstName, middleName, employeeId, contactNumber, emailAddress);
        }
        public void AddReferral(Guid id, Guid jobRequisitionId, string nameOfReferral, string contactNumber, string emailAddress, string confirmationQuestion)
        {
            Referrals.Add(Referral.Create(id, jobRequisitionId, nameOfReferral, contactNumber, emailAddress,
                confirmationQuestion));
        }
    }
}
