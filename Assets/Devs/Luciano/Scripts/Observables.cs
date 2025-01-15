using System;
using UnityEngine;

[Serializable]
public class Observable<T>
{
    [SerializeField] private T value;

    public event Action<T> OnValueChanged;

    public T Value
    {
        get => value;
        set
        {
            if (!Equals(this.value, value))
            {
                this.value = value;
                OnValueChanged?.Invoke(this.value);
            }
        }
    }

    public Observable(T initialValue)
    {
        value = initialValue;
    }
}