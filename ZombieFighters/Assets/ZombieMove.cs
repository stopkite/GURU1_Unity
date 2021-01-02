using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieMove : MonoBehaviour
{
    // 이동할 때 애미네미션을 Run상태로 바꾸고싶다.
    // 멈췄을 때 애니메이션을 Idle상태로 바꾸고싶다.
    // - 속력
    // - 애니메이터컨트롤러 : 애니메이션을 바꾸기 위함

    public class PlayerMove : MonoBehaviour
    {
        // -속력
        public float speed = 5;
        // -애니메이터컨트롤러 : 애니메이션을 바꾸기 위함
        //현재 상태를 저장해서 같은 상태라면 애니메이션 바꾸는 행동을 두번 하지 않고싶다.

        Animator anim;
        //-상태(2가지) bool
        bool isAttack = false;
        // Start is called before the first frame update
        void Start()
        {
            //게임오브젝트에게 애니메이터 컴포넌트 요청하고싶다.
            anim = gameObject.GetComponent<Animator>();
        }

        // Update is called once per frame
        void Update()
        {
            //사용자의 입력에따라 앞뒤좌우로 이동하고싶다.
            float h = Input.GetAxis("Horizontal");
            float v = Input.GetAxis("Vertical");

            //Vector3 dir = Vector3.right * h + Vector3.forward * v;
            Vector3 dir = new Vector3(h, 0, v)
    ; dir.Normalize();

            transform.position += dir * speed * Time.deltaTime;

            print(dir.magnitude);

            //1.움직임이 없으면 
            if (dir.magnitude == 0)
            {
                //만약 달리고 있었으면
                if (isAttack)
                {//2.애니메이션 상태를 Idle로 하고
                    anim.Play("Idle", 0, 0);
                }
                isAttack = false;
            }
            //3.그렇지 않으면
            else
            {
                //만약 서 있었다면
                if (isAttack == false)
                {//4.Attack으로 하고 싶다.
                    anim.Play("Attack", 0, 0);
                }
                isAttack = true;
            }
        }
    }
}
