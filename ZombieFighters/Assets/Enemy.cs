using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        // 1. 태어날 때 방향을 정하는데 

        int value = Random.Range(0, 10);
        // 2. 만약 30%의 확률에 해당한다면
        if (value < 3)
        {
            // 플레이어 방향으로,
            // target - me
            GameObject target = GameObject.Find("Player");
            transform.up = (target.transform.position - transform.position).normalized;
        }
        else // 3. 그러지 않다면
        {
            // 아래 방향으로
            transform.up = Vector3.down;
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}
