using System;
using System.Collections;
using UnityEngine;

public class Counter : MonoBehaviour
{
    [SerializeField] private ButtonText _buttonText;
    [SerializeField] private CounterView _counterView;

    public event Action<bool> OnCountingIsActive;
    public event Action<float> OnValueChanged;

    private int _counterDelta = 1;
    private int _value = 0;
    private float _delayInSeconds = 0.5f;
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

    private void StartCounting()
    {
        _isCounting = true;
        _coroutine = StartCoroutine(Count());
        OnCountingIsActive?.Invoke(_isCounting);
    }

    private void StopCounting()
    {
        _isCounting = false;

        if (_coroutine != null)
        {
            StopCoroutine(_coroutine);
            _coroutine = null;
        }

        OnCountingIsActive?.Invoke(_isCounting);
    }

    private IEnumerator Count()
    {
        var wait = new WaitForSeconds(_delayInSeconds);

        while (_isCounting)
        {
            OnValueChanged?.Invoke(_value);
            _value +=  _counterDelta;

            yield return wait;
        }
    }
}