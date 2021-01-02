using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

// 사용자의 입력에따라 이동하고싶다.
// - 속력
// 사용자가 점프 버튼을 누르면 점프를 뛰고 싶다.
// - 중력 Gravity
// - 점프할 힘
// - y속도
public class PlayerMove : MonoBehaviour
{

    // - 중력 Gravity
    public float gravity = -9.81f;
    // - 점프할 힘
    public float jumpPower = 10;
    // - y속도
    public float yVelocity;

    public AudioSource audio;
    public AudioClip AttackSound;

    CharacterController cc;
    // - 속력
    public float speed = 5;
    public GameObject uiMannager;
    public float repeatDamagePeriod = 2;
    private float lastHitTime;
    // Start is called before the first frame update
    void Start()
    {
        cc = gameObject.GetComponent<CharacterController>();
        lastHitTime = 0;
    }

    // Update is called once per frame
    void Update()
    {
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");

        Vector3 dir = new Vector3(h, 0, v);
        // 문제발생!!
        // 카메라가 보고 있는 앞 방향을 기준으로 방향을 결정하고싶다.
        dir = Camera.main.transform.TransformDirection(dir);
        dir.Normalize();

        // 만약 공중에 있을 때
        //if (cc.collisionFlags != CollisionFlags.Below)
        if (cc.isGrounded == false)
        {
            // 중력을 상시로 받고 싶다.
            yVelocity += gravity * Time.deltaTime;
        }
        dir.y = yVelocity;

        // 1. 점프 뛴 횟수가 2회 미만이다 그리고 사용자가 점프 버튼을 누르면
        if (jumpCount < jumpMaxCount - 1 && Input.GetButtonDown("Jump"))
        {
            // 2. 점프를 뛰고 싶다.
            yVelocity = jumpPower;
            jumpCount++;
        }
        // 만약 땅에 도착하면 점프 뛴 횟수를 0으로 초기화 하고싶다.
        if (cc.isGrounded)
        {
            jumpCount = 0;
        }

        cc.Move(dir * speed * Time.deltaTime);
    }
    int jumpCount;
    public int jumpMaxCount = 2;

    /*
    private void OnCollisionEnter(Collision other)
    {
        if(other.gameObject.name.Contains("Enemy"))
        {
            LifeManager hp = other.gameObject.GetComponent<LifeManager>();
            hp.SetHP(hp.GetHP() - 5);
            if(hp.GetHP()==0)
            {
                Destroy(this.gameObject);
            }
            print("Collision");
        }
    }
    */

    float hitTime;
    void OnControllerColliderHit(ControllerColliderHit hit)
    {
        if (Time.time - hitTime <= 0.2f)
        {
            return;
        }
        if (hit.gameObject.name.Contains("Enemy"))
        {
            this.audio = this.gameObject.AddComponent<AudioSource>();
            this.audio.clip = this.AttackSound;
            this.audio.loop = false;
            this.audio.Play();

            hitTime = Time.time;
            // 한대 맞았다
            // 화면을 한번 깜빡 거리고싶다.
            //  -> UI를 켰다가 0.1초 후에 끄고싶다.
            LifeManager hp = uiMannager.GetComponent<LifeManager>();
            hp.SetHP(hp.GetHP() - 5);
            hp.slider.value = hp.GetHP();
            StartCoroutine("ieWait");
            StartCoroutine("ieHit");

            if (hp.GetHP() <= 0)
            {
                Destroy(this);
                SceneManager.LoadScene("GameOver");
            //    GameManager.Instance.gameOverUI.SetActive(true);

            }
           
        }
    }

    IEnumerator ieHit()
    {
        Damage.Instance.DamageObject.SetActive(true);
        // UI 켬
        yield return new WaitForSeconds(0.1f);
        // UI 끔
        Damage.Instance.DamageObject.SetActive(false);
    }

    IEnumerator ieWait()
    {
        yield return new WaitForSeconds(4);
    }

}
