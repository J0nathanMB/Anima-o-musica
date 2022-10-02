using UnityEngine;

public class ColorLights : MonoBehaviour
{
    Light _light;
    void Start()
    {
        _light = GetComponent<Light>();
    }

    void Update()
    {
        _light.color = new Color(
        AudioPeer._audioBandBuffer[Random.Range(0,8)] * Random.Range(0.0f,1.0f),
        AudioPeer._audioBandBuffer[Random.Range(0,8)] * Random.Range(0.0f,1.0f),
        AudioPeer._audioBandBuffer[Random.Range(0,8)] * Random.Range(0.0f,1.0f)
            );
    }
}
