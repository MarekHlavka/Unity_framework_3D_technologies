using System.Collections;
using System.Collections.Generic;
using System.Web;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class DisplaySettingsSliderPanel : MonoBehaviour
{
    [SerializeField] private TMP_Text _name;
    [SerializeField] private TMP_Text _value;
    [SerializeField] private TMP_Text _minValue;
    [SerializeField] private TMP_Text _maxValue;
    [SerializeField] private Slider _slider;

    public void Init(string _name, float def_value, UnityAction<float> call, float min, float max)
    {
        this._name.text = _name;
        this._value.text = def_value.ToString();
        _slider.onValueChanged.AddListener(call);
        _slider.maxValue = max;
        _maxValue.text = max.ToString();
        _slider.minValue = min;
        _minValue.text = min.ToString();
        _slider.value = def_value;
    }
    public void Update()
    {
        _value.text = _slider.value.ToString();
    }
}
