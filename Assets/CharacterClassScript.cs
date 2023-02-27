using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterClassScript : MonoBehaviour
{

    [SerializeField] private Dropdown characterDropdown;
    [SerializeField] private Text classText;
    [SerializeField] private List<string> classes = new List<string> ();

    // Start is called before the first frame update
    void Start()
    {
        //classes.Add("Guy");    
        //classes.Add("Girl");    
        //classes.Add("Other");

        classText.text = characterDropdown.options[characterDropdown.value].text;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ChangeClass()
    {
        classText.text = characterDropdown.options[characterDropdown.value].text;
    }
}
