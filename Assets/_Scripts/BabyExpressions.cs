using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class BabyExpressions : MonoBehaviour
{
    public float _minIntensity { set; get; }
    public float _maxIntensity { set; get; }
    private SkinnedMeshRenderer skin;

    public bool globalIntensity = false;
    
    [SerializeField]
    private int[] blendShapesList;
    


    private int bandCount = 0;
    private const int MAX_BAND = 7;
    private const int MIN_BAND = 0;

    // blend index, band
    private Dictionary<int, int> bandDictionary;
    
    // blend index, toggle
    private Dictionary<int, bool> activeBlend;
    
    // blend index, intensity(active, min, max)
    private Dictionary<int, (bool toggle, float min, float max)> individualIntensity;

    void Awake()
    {
        skin = GetComponent<SkinnedMeshRenderer>();
        bandDictionary = new Dictionary<int, int>();
        activeBlend = new Dictionary<int, bool>();
        individualIntensity = new Dictionary<int, (bool toggle, float min, float max)>();
        _minIntensity = 0;
        _maxIntensity = 75;
    }
    
    void Start ()
    {
        foreach (var blend in blendShapesList)
        {
            bandDictionary.Add(blend, bandCount);
            bandCount = bandCount >= MAX_BAND ? MIN_BAND :  bandCount+1;
            
            activeBlend.Add(blend, true);
            individualIntensity.Add(blend, (true, 0, 100));
        }
    }

    void Update()
    {
        foreach (var blendIndex in blendShapesList)
        {
            if (!activeBlend[blendIndex])
            {
                skin.SetBlendShapeWeight(blendIndex,0);
                continue;
            }

            if (individualIntensity[blendIndex].toggle)
            {
                skin.SetBlendShapeWeight(
                    blendIndex,
                    (AudioPeer._audioBandBuffer[bandDictionary[blendIndex]] * (
                        individualIntensity[blendIndex].max - individualIntensity[blendIndex].min)
                        ) + individualIntensity[blendIndex].min
                );
                continue;
            }
            
            skin.SetBlendShapeWeight(
                blendIndex,
                (AudioPeer._audioBandBuffer[bandDictionary[blendIndex]] * (_maxIntensity - _minIntensity)) + _minIntensity
            );
        }
    }
    
    public void SwitchBlend(int blendID)
    {
        activeBlend[blendID] = !activeBlend[blendID];
    }

    public void SetIndividualBlendIntensityMax(SliderWrapper sw)
    {
        individualIntensity[sw.blendIndex] = (
            individualIntensity[sw.blendIndex].toggle,
            individualIntensity[sw.blendIndex].min,
            sw.floatValue
            );
    }
    
    public void SetIndividualBlendIntensityMin(SliderWrapper sw)
    {
        individualIntensity[sw.blendIndex] = (
            individualIntensity[sw.blendIndex].toggle,
            sw.floatValue,
            individualIntensity[sw.blendIndex].max
        );
    }

    public void ToggleIndividualIntensity(SliderWrapper sw)
    {
        individualIntensity[sw.blendIndex] = (
                sw.boolValue, 
                individualIntensity[sw.blendIndex].min, 
                individualIntensity[sw.blendIndex].max
                );
    }
    
}
