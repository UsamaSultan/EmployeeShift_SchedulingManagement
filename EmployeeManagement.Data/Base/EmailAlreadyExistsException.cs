using EmployeeManagement.Data.Base;

namespace EmployeeManagement.Data.Base
{
    public class EmailAlreadyExistsException : BaseException
    {
        //This is just for reference, additional effort ;) 
        public EmailAlreadyExistsException() : base("Email already exists") { }
    }
}
