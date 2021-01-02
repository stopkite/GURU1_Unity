using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

//남은 좀비 수를 알려주어야 한다.
public class ZombieCountM : MonoBehaviour
{
    public static ZombieCountM zombieCountM;
    private void Awake()
    {
        zombieCountM = this;
    }
    GameObject[] zombie;
    int ZombieF;
    int ZombieL;
    public Text textZombieF;
    public Text textZombieL;

    // Start is called before the first frame update
    void Start()
    {
        zombie = GameObject.FindGameObjectsWithTag("Enemy");
        ZombieF = zombie.Length;
        ZombieL = ZombieF;
        textZombieF.text = ZombieF.ToString();
        textZombieL.text = ZombieL.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        if (ZombieL == 0)
        {
          //  SceneManager.LoadScene("Success");
        }
    }
    public int GetZombieL()
    {
        return ZombieL;
    }

    public void SetZombieL()
    {
        ZombieL -= 1;
        textZombieL.text = ZombieL.ToString();
    }
}
