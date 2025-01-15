using System;
using UnityEngine;

[CreateAssetMenu(menuName = "Observables/Float Observable")]
public class ObservableFloat : ScriptableObject
{
    [SerializeField] private Observable<float> observable = new Observable<float>(0f);

    public float Value
    {
        get => observable.Value;
        set => observable.Value = value;
    }

    public void Subscribe(Action<float> listener)
    {
        observable.OnValueChanged += listener;
    }

    public void Unsubscribe(Action<float> listener)
    {
        observable.OnValueChanged -= listener;
    }
}