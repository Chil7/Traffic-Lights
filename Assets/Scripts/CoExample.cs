using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoExample : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
      if (Input.GetKeyDown(KeyCode.Space)) 
        {
            StartCoroutine(WaitandPrint(2f));
        }   
    }


    private IEnumerator WaitandPrint(float _waitTIme)
    {
        Debug.Log("1st is YEs");
        yield return new WaitForSeconds(_waitTIme);
        Debug.Log("2nd is " + _waitTIme);
        yield return new WaitForSeconds(_waitTIme + 4f);
        Debug.Log("3rd is " + _waitTIme);

    }
}
