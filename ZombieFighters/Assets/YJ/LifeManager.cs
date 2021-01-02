using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//life를 나타내야 한다.
public class LifeManager : MonoBehaviour
{
    public static LifeManager Instance;
    public Slider slider;
    private void Awake()
    {
        Instance = this;
    }
    public int maxHP = 100;
    int curHP;
    public Text textLife;
    // Start is called before the first frame update
    void Start()
    {
        //life의 full은 100이다
        curHP = maxHP;
        textLife.text = curHP.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public int GetHP()
    {
        return curHP;
    }
    public void SetHP(int value)
    {
        curHP = value;
        textLife.text = curHP.ToString();
        slider.value = curHP;
    }
}
