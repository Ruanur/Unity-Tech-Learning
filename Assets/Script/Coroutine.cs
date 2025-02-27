using UnityEngine;
using System.Collections.Generic;
using System.Collections;
using Unity.VisualScripting;


public class Corutine : MonoBehaviour
{
    public bool isDelay;
    public float delayTime = 5.0f;
    public float accTime;

     void Start()
     {
        StartCoroutine(Return());
        StartCoroutine(Break());
     }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            {
                StartCoroutine(Return());
                StartCoroutine(Break());
            }
        }   
    }

    IEnumerator Return()
    {
        Debug.Log("Return() 1");
        yield return null;
        Debug.Log("Return() 2");

    }
    IEnumerator Break()
    {
        Debug.Log("Break() 1");
        yield break;
        Debug.Log("Break() 2");

    }
}
