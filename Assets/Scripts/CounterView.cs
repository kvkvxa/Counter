using UnityEngine;
using TMPro;

public class CounterView : MonoBehaviour
{
    [SerializeField] private Counter _counter;
    [SerializeField] private TextMeshProUGUI _counterText;

    private void OnEnable()
    {
        _counter.OnValueChanged += Display;
    }

    private void OnDisable()
    {
        _counter.OnValueChanged -= Display;
    }

    private void Display(float count)
    {
        _counterText.text = count.ToString();
    }
}