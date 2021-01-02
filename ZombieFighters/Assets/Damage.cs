using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Damage : MonoBehaviour
{
    public static Damage Instance;
    public GameObject DamageObject;

    // Start is called before the first frame update
    void Start()
    {
        Instance = this;
        DamageObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
