using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    private void Awake()
    {
        Instance = this;
    }

    public GameObject gameOverUI;

    // Start is called before the first frame update
    void Start()
    {
      //  gameOverUI.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
    }
  public  void OnRetry()
        {
        SceneManager.LoadScene("GameStart");
    }
   public void OnQuit()
        {
        Application.Quit();
    }

 
    
}
