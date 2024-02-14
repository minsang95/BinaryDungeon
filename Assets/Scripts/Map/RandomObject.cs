using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomObject : MonoBehaviour
{

    public GameObject[] Objects;
    private int rand;

    // Start is called before the first frame update
    void Start()
    {
        
    }


    void MakeObject()
    {
        rand = Random.Range(0, Objects.Length);
    }

}
