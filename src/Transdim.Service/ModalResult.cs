using System;

namespace Transdim.Service
{
    public class ModalResult
    {
        public object Data { get; }
        public Type DataType { get; }

        protected ModalResult(object data, Type resultType)
        {
            Data = data;
            DataType = resultType;
        }

        public static ModalResult Ok() => new ModalResult(null, null);

        public static ModalResult Ok<T>(T result) => new ModalResult(result, typeof(T));
    }
}
