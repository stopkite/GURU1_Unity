using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class TimerManager : MonoBehaviour
{
    public float time = 120;
    public Text timer;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (time != 0)
        {
            time -= Time.deltaTime;
            if (time <= 0)
            {
                time = 0;
                if (time == 0)
                {
                    SceneManager.LoadScene(2);
                }
               /* if (ZombieCountM.zombieCountM.GetZombieL() != 0)
                {
                    GameManager.Instance.gameOverUI.SetActive(true);
                
                } */
            }
            string str = string.Format("{0:f2}", time);
            timer.text = str;
        }
    }
}
