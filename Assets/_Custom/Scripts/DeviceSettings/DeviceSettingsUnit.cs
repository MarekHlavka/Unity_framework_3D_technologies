using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[System.Serializable]
public class DeviceSettingsUnit
{
    [SerializeField]
    private string _name;
    [SerializeField]
    private UnityAction<float> callFunction;
    [SerializeField]
    private float min;
    [SerializeField]
    private float max;
    [SerializeField]
    private float def;

    public DeviceSettingsUnit(string name, UnityAction<float> callFunction, float min, float max, float def = -1.0f)
    {
        _name = name;
        this.callFunction = callFunction;
        this.min = min;
        this.max = max;
        this.def = def;
        if (def == -1.0f) {
            this.def = max - min;
        }
    }

    public string GetName() {
        return _name;
    }
    public UnityAction<float> GetAction()
    {
        return callFunction;
    }
    public float GetMin()
    {
        return min;
    }
    public float GetMax()
    {
        return max;
    }
    public float GetDef()
    {
        return def;
    }
}
