using System.Collections.Generic;

namespace Transdim.DomainModel
{
    public class ModalParameters
    {
        private Dictionary<string, object> Parameters;

        public ModalParameters()
        {
            Parameters = new Dictionary<string, object>();
        }

        public void Add(string parameterName, object value)
        {
            Parameters[parameterName] = value;
        }

        public T Get<T>(string parameterName)
        {
            if (!Parameters.ContainsKey(parameterName))
            {
                throw new KeyNotFoundException($"{parameterName} does not exist in modal parameters");
            }

            return (T)Parameters[parameterName];
        }
    }
}
