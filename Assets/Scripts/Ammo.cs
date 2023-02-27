using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Ammo : MonoBehaviour
{
    private int ammoCount;

    [SerializeField] InputField amoField;

    [SerializeField] private Text ammoText;
    // Start is called before the first frame update
    void Start()
    {
        ammoCount = 40;
        ammoText.text = "Current Ammo:" + ammoCount;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Fire()
    {
        ammoCount--;
        ammoText.text = "Current Ammo:" + ammoCount;
    }

    public void AmmoIncrease()
    {
        ammoCount += int.Parse(amoField.text);
        ammoText.text = "Current Ammo:" + ammoCount;
    }
}
