using System;
using UnityEngine;

[CreateAssetMenu(menuName = "Observables/Bool Observable")]
public class ObservableBool : ScriptableObject
{
    [SerializeField] private Observable<bool> observable = new Observable<bool>(false);

    public bool Value
    {
        get => observable.Value;
        set => observable.Value = value;
    }

    public void Subscribe(Action<bool> listener)
    {
        observable.OnValueChanged += listener;
    }

    public void Unsubscribe(Action<bool> listener)
    {
        observable.OnValueChanged -= listener;
    }
}