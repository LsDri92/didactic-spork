using System;
using UnityEngine;

[CreateAssetMenu(menuName = "Observables/Int Observable")]
public class ObservableInt : ScriptableObject
{
    [SerializeField] private Observable<int> observable = new Observable<int>(1);

    public int Value
    {
        get => observable.Value;
        set => observable.Value = value;
    }

    public void Subscribe(Action<int> listener)
    {
        observable.OnValueChanged += listener;
    }

    public void Unsubscribe(Action<int> listener)
    {
        observable.OnValueChanged -= listener;
    }
}