using System.Collections.Generic;
using System.Linq;

namespace Webinars.Domain.Ddd
{
    public abstract class ValueObject<T> where T : ValueObject<T>
    {
        protected abstract IEnumerable<object> GetAttributesToEqualityCheck();


        public ValueObject()
        {
            
        }
        public override bool Equals(object obj)
        {
            return Equals(obj as T);
        }

        public virtual bool Equals(T other)
        {
            if (other is null)
                return false;
            return GetAttributesToEqualityCheck().SequenceEqual(other.GetAttributesToEqualityCheck());
        }

        public static bool operator ==(ValueObject<T> left, ValueObject<T> right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(ValueObject<T> left, ValueObject<T> right)
        {
            return !(left == right);
        }
    }
}