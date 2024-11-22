using TMPro;
using UnityEngine;

public class ButtonText : MonoBehaviour
{
    [SerializeField] private Counter _counter;
    [SerializeField] private TextMeshProUGUI _buttonText;

    private void OnEnable()
    {
        _counter.OnCountingIsActive += UpdateText;
    }

    private void OnDisable()
    {
        _counter.OnCountingIsActive -= UpdateText;
    }

    private void UpdateText(bool isCounting)
    {
        _buttonText.text = isCounting ? "Stop" : "Start";
    }
}