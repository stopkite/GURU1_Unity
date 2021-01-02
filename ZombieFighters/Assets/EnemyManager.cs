using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 시간이 흐르다가 일정시간마다 적공장에서 적을 생성해서 자기자신의 위치에 가져다 놓고 방향도 자기자신의 방향으로 회전하고싶다.
// - 적 공장
// - 일정시간
// - 현재시간
public class EnemyManager : MonoBehaviour
{
    // - 적 공장
    public GameObject enemyFactory;
    // - 일정시간
    public float createTime = 1;
    // - 현재시간
    float currentTime;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        // 1. 시간이 흐르다가
        currentTime += Time.deltaTime;
        // 2. 만약 현재시간이 일정시간을 초과하면
        if (currentTime > createTime)
        {
            currentTime = 0;
            // 3. 적공장에서 적을 생성하고
            GameObject enemy = Instantiate(enemyFactory);
            // 4. 적의 위치를 내위치에 가져다 놓고
            enemy.transform.position = this.transform.position;
            // 5. 적의 방향을 내방향으로 돌려놓고싶다.
            enemy.transform.up = this.transform.up;
        }

    }
}
