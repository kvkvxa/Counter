using TMPro;
using UnityEngine;

public class ButtonText : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _buttonText;

    public void UpdateText(bool isCounting)
    {
        _buttonText.text = isCounting ? "Stop" : "Start";
    }
}