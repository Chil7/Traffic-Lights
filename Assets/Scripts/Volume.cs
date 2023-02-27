using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Volume : MonoBehaviour
{
    private float volume;

    [SerializeField] Text volumeText;
    [SerializeField] Slider volumeSlider;

    
    // Start is called before the first frame update
    void Start()
    {
        volume = 200f;

        volumeText.text = "Volume: " + volume + "%";
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ChangeVolume()
    {
        volume = volumeSlider.value;
        volumeText.text = "Volume: " + volume + "%";
    }
}
