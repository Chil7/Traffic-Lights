using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerName : MonoBehaviour
{
    public string playerName;

    [SerializeField] private Text inputText;
    [SerializeField] private InputField inputField;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void NameChange()
    {
        playerName = inputField.text;
        inputText.text = "Name: " + playerName;
    }
}
