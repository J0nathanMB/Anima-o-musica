using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class BabyExpressions : MonoBehaviour
{
    public float _minIntensity { set; get; }
    public float _maxIntensity { set; get; }
    private SkinnedMeshRenderer skin;

    [SerializeField]
    private int[] blendShapesList;

    private int bandCount = 0;
    private const int MAX_BAND = 7;
    private const int MIN_BAND = 0;

    private Dictionary<int, int> bandDictionary;
    private Dictionary<int, bool> activeBlend;

    void Awake()
    {
        skin = GetComponent<SkinnedMeshRenderer>();
        bandDictionary = new Dictionary<int, int>();
        activeBlend = new Dictionary<int, bool>();
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
        }

        if (blendShapesList.Length > 4)
        {
            foreach (var v in bandDictionary)
            {
                Debug.Log("Key: " + v.Key + " | Val: " + v.Value);
            }
        }
    }

    void Update()
    {
        foreach (var blend in blendShapesList)
        {
            if (!activeBlend[blend])
            {
                skin.SetBlendShapeWeight(blend,0);
                continue;
            }
            
            skin.SetBlendShapeWeight(
                blend,
                (AudioPeer._audioBandBuffer[bandDictionary[blend]] * (_maxIntensity - _minIntensity)) + _minIntensity
            );
        }
    }

    public void SwitchBlend(int blendID)
    {
        activeBlend[blendID] = !activeBlend[blendID];
    }
    
}
