using System;

namespace Patterns.MVVMExample
{
    public class ReactiveProperty<T>
    {
        public event Action<T> OnChanged;

        private T _value;
        public T Value
        {
            get => _value;
            set
            {
                _value = value;
                OnChanged?.Invoke(_value);
            }
        }
    }
}