using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 사용자가 마우스 왼쪽 버튼을 누르면 카메라가 보고있는 지점에 총을 쏘고싶다.
// - 총알자국 공장
public class Gun : MonoBehaviour
{
    public AudioSource audio;
    public AudioClip gunsound;

    // - 총알자국 공장
    public GameObject bulletImpactFactory;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        // 1. 사용자가 마우스 왼쪽 버튼을 누르면
        if (Input.GetButtonDown("Fire1"))
        {
            this.audio = this.gameObject.AddComponent<AudioSource>();
            this.audio.clip = this.gunsound;
            this.audio.loop = false;
            this.audio.Play();

            // 2. 카메라가 보고있는 지점에 
            // - 시선
            Ray ray = new Ray(Camera.main.transform.position, Camera.main.transform.forward);
            // - 닿은곳의 정보
            RaycastHit hitInfo;
            // 충돌 필터링(특정 레이어만 충돌)
            //int layer = 1 << LayerMask.NameToLayer("Enemy");
            // - 바라본다
            if (Physics.Raycast(ray, out hitInfo, 10000))
            {
                // 시선이 닿았다.
                print(hitInfo.transform.name);
                GameObject bImpact = Instantiate(bulletImpactFactory);
                bImpact.transform.position = hitInfo.point;
                // 총알이 튀는 방향을 부딪힌 곳의 법선벡터 방향으로 회전하고싶다.
                bImpact.transform.forward = hitInfo.normal;
                Destroy(bImpact, 3);
                // 부딪힌것이 Enemy라면 데미지를 입히고 싶다.
                if (hitInfo.transform.name.Contains("Enemy"))
                {
                    Follow enemy = hitInfo.transform.gameObject.GetComponent<Follow>();
                    if (enemy != null)
                    {
                        enemy.AddDamage();
                    }
                }
            }
            else
            {
                // 시선이 닿지 않았다.(허공)
            }

            // 3. 총을 쏘고싶다.
            // 4. 그 넘을 파괴하고싶다.
        }
        if (Input.GetButtonDown("Fire2"))
        {
            Camera.main.fieldOfView = 15;
        }
        else if (Input.GetButtonUp("Fire2"))
        {
            Camera.main.fieldOfView = 60;
        }
    }
}
