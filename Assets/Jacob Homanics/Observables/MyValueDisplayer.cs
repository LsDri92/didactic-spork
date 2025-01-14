using JacobHomanics.Core.Observables;
using UnityEngine;
using UnityEngine.UI;

public class MyValueDisplayer : MonoBehaviour
{
	public Text Text;

	public void Set(Observable observable)
	{
		Text.text = observable.GetValue().ToString();
	}
}
