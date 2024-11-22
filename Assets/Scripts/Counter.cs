using System.Collections;
using UnityEngine;

public class Counter : MonoBehaviour
{
    [SerializeField] private ButtonText _buttonText;
    [SerializeField] private SecondsText _secondsText;

    private float _elapsedTime = 0f;
    private float _delayInSeconds = 1f;
    private bool _isCounting = false;

    private Coroutine _coroutine;

    public void SwitchCounting()
    {
        if (_isCounting)
        {
            StopCounting();
        }
        else
        {
            StartCounting();
        }
    }

    private void Start()
    {
        if (_buttonText == null)
            _buttonText = GetComponent<ButtonText>();

        if (_secondsText == null)
            _secondsText = GetComponent<SecondsText>();
    }

    private void StartCounting()
    {
        _isCounting = true;
        _coroutine = StartCoroutine(Count());
        _buttonText.UpdateText(_isCounting);
    }

    private void StopCounting()
    {
        _isCounting = false;

        if (_coroutine != null)
        {
            StopCoroutine(_coroutine);
            _coroutine = null;
        }

        _buttonText.UpdateText(_isCounting);
    }

    private IEnumerator Count()
    {
        var wait = new WaitForSeconds(_delayInSeconds);

        while (_isCounting)
        {
            _secondsText.Display(_elapsedTime);
            _elapsedTime += _delayInSeconds;

            yield return wait;
        }
    }
}