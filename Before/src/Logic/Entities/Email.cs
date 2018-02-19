using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Logic.Entities
{
    public class Email : ValueObject<Email>
    {
        private Email(string value)
        {
            Value = value;
        }

        public static Result<Email> Create(string email)
        {
            email = (email ?? string.Empty).Trim();

            if (email.Length == 0)
                return Result.Fail<Email>("Email should not be empty");

            if (!Regex.IsMatch(email, @"^(.+)@(.+)$"))
                return Result.Fail<Email>("Email is invalid");
                     
            return Result.OK(new Email(email));
        }


        public string Value { get; }

        protected override bool EqualsCore(Email other)
        {
            return Value.Equals(other.Value, StringComparison.InvariantCultureIgnoreCase);
        }

        protected override int GetHashCodeCore()
        {
            return Value.GetHashCode();
        }

        public static implicit operator string(Email email)
        {
            return email.Value;
        }

        public static explicit operator Email(string email)
        {
            return Create(email).Value;
        }
    }
}
