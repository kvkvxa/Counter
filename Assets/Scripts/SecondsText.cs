using UnityEngine;
using TMPro;

public class SecondsText : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _seconds;

    public void Display(float time)
    {
        _seconds.text = $"{time:F1}s";
    }
}