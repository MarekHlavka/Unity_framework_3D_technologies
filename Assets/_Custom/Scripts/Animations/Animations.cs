using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Animations : MonoBehaviour
{

    [SerializeField] private AnimationCurve waveCurve;

    public float GetWaveCurveValue(float in_value)
    {
        return waveCurve.Evaluate(in_value);
    }
}
