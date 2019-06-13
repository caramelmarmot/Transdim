using System;
using System.Collections.Generic;

namespace Transdim.DomainModel
{
    public class ModalParameters
    {
        private Dictionary<string, object> parameters;

        public ModalParameters()
        {
            parameters = new Dictionary<string, object>();
        }

        public ModalParameters(string key, object value)
        {
            parameters = new Dictionary<string, object>();
            
            parameters.Add(key, value);
        }


        public ModalParameters(Dictionary<string, object> modalParameters)
        {
            parameters = new Dictionary<string, object>();
            foreach (var parameter in modalParameters)
            {
                parameters.Add(parameter.Key, parameter.Value);
            }
        }

        public void Add(string parameterName, object value)
        {
            parameters[parameterName] = value;
        }

        public T Get<T>(string parameterName)
        {
            if (!parameters.ContainsKey(parameterName))
            {
                throw new KeyNotFoundException($"{parameterName} does not exist in modal parameters");
            }

            return (T)parameters[parameterName];
        }
    }
}
