using UnityEngine;
using UnityEngine.UI;

public class SpeedBar : MonoBehaviour
{
    [SerializeField] private Slider speedSlider;
    [SerializeField] private ObservableFloat maxSpeed;
    public ObservableFloat currentSpeed;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        if (speedSlider != null)
        {
            speedSlider.minValue = 0;
            speedSlider.maxValue = maxSpeed.Value;
            UpdateSpeedBar(0);
        }
    }

    private void UpdateSpeedBar(float speed)
    {
        if (speedSlider != null)
        {
            speedSlider.value = currentSpeed.Value;
        }
    }


    // Update is called once per frame
    void Update()
    {
        UpdateSpeedBar(currentSpeed.Value);
    }
}
