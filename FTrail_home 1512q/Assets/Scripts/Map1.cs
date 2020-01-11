using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent (typeof (Light))]
public class Map1 : MonoBehaviour
{
    public int _band;
    public float _minIntensity, _maxIntensity;
    Light _light;

    

    private void Start()
    {
        _light = GetComponent<Light>();
    }

    // Update is called once per frame
    void Update()
	{
        Debug.Log("Light Intensity -------->" + (Map._audioBandBuffer[_band] * (_maxIntensity - _minIntensity)) + _minIntensity);
        _light.intensity = (Map._audioBandBuffer[_band] * (_maxIntensity - _minIntensity)) + _minIntensity;

    }

}
