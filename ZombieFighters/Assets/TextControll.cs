using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextControll : MonoBehaviour
{
    public static TextControll Instance;
    public GameObject readyText;

    private void Awake()
    {
        if (TextControll.Instance == null)
        {
            TextControll.Instance = this;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        readyText.SetActive(false);
        StartCoroutine(ShowReady());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator ShowReady()
    {
        int count = 0;
        while(count < 10)
        {
            readyText.SetActive(true);
            yield return new WaitForSeconds(0.5f);

            readyText.SetActive(false);

            yield return new WaitForSeconds(0.5f);
            count++;
        }
    }
}
