using CareerCloud.DataAccessLayer;
using CareerCloud.Pocos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CareerCloud.BusinessLogicLayer
{
  
    public class CompanyProfileLogic : BaseLogic<CompanyProfilePoco>
    {
        public CompanyProfileLogic(IDataRepository<CompanyProfilePoco> repository) : base(repository)
        {
        }
        public override void Add(CompanyProfilePoco[] pocos)
        {
            Verify(pocos);
            base.Add(pocos);
        }
        public override void Update(CompanyProfilePoco[] pocos)
        {
            Verify(pocos);
            base.Update(pocos);
        }
        protected override void Verify(CompanyProfilePoco[] pocos)
        {
            List<ValidationException> exceptions = new List<ValidationException>();
            string[] validWebsiteExtensions = new string[] { ".ca", ".com", ".biz"};
            foreach (CompanyProfilePoco poco in pocos)
            {

                if (string.IsNullOrEmpty(poco.CompanyWebsite))
                {
                    exceptions.Add(new ValidationException(600, $"Cannot be empty"));
                }
                else if(!validWebsiteExtensions.Any(t => poco.CompanyWebsite.EndsWith(t)))
                {
                    exceptions.Add(new ValidationException(600, $"Valid websites must end with the following extensions – '.ca', '.com', '.biz'"));
                }

                if (string.IsNullOrEmpty(poco.ContactPhone))
                {
                    exceptions.Add(new ValidationException(601, $"Cannot be empty"));
                }
                else
                {
                    string[] phoneComponents = poco.ContactPhone.Split('-');
                    if (phoneComponents.Length < 3)
                    {
                        exceptions.Add(new ValidationException(601, $"Must correspond to a valid phone number "));
                    }
                    else
                    {
                        if (phoneComponents[0].Length < 3)
                        {
                            exceptions.Add(new ValidationException(601, $"Must correspond to a valid phone number "));
                        }
                        else if (phoneComponents[1].Length < 3)
                        {
                            exceptions.Add(new ValidationException(601, $"Must correspond to a valid phone number "));
                        }
                        else if (phoneComponents[2].Length < 4)
                        {
                            exceptions.Add(new ValidationException(601, $"Must correspond to a valid phone number "));
                        }
                    }
                }
                
            }
            if (exceptions.Count > 0)
            {
                throw new AggregateException(exceptions);
            }
        }

    }
}
