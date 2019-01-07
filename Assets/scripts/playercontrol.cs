using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class playercontrol : MonoBehaviour {
    

    public float m_hspeed = 5f;
    public Animator playerani;
    
    public  static float blackflag=-1;
    public static GameObject yellowlayer1;
    public static GameObject P1Label;
    public static float yellowflag1 = -1;
    public static float TouchBombFlag = -1;
    public static float Dieflag1 = -1;
    public static float Countflag = -1;//daojishi//
    public static float P1YPosition;
    public static float WinFlag = -1;
    public static float PauseFlag = -1;
    public static float P1P2YDistance;
    public float m_hp = 3;
    private Vector3 targetPosition;
    [SerializeField]
    private Text MyHpText;
    [SerializeField]
    private Text Score;
    [SerializeField]
    private Image Uiheart;
    [SerializeField]
    private GameObject reborn1;

    // Use this for initialization
    void Start () {
        Countflag = -1;
        TouchBombFlag = -1;
        yellowlayer1 = transform.Find("Yellowcolor").gameObject;
        P1Label=transform.Find("1P").gameObject;
    }
	
	// Update is called once per frame
	void Update ()
    {

        if(Dieflag1==1|| WinFlag == 1||PauseFlag==1 || Countflag == -1)
        {
            return;
        }
        
        UpandDown();
        transform.Translate(Vector2.right * m_hspeed * Time.deltaTime);
        if (playerani.GetNextAnimatorStateInfo(0).IsName("whitetakedamage")|| playerani.GetNextAnimatorStateInfo(0).IsName("blackplayertakedamage"))
        {
            playerani.SetFloat("Damageflag", -1);
        }
        if (m_hp<=0)
        {
            Die();
        }
        P1YPosition = transform.position.y;
        P1P2YDistance = P1YPosition - playercontrol2.P2YPosition;
        
       
    }

    private void OnTriggerEnter2D (Collider2D collision)
    {
        if (collision.gameObject.tag == "yellowstone")
        {
         
            Destroy(collision.gameObject);
            yellowflag1 = 1;
        }
        if (collision.gameObject.tag == "blackfood")
        {
            blackflag = 1;
            playerani.SetFloat("blackflag", 1);
            Destroy(collision.gameObject);
        }
        if (collision.gameObject.tag == "whitefood")
        {
            blackflag = -1;
            playerani.SetFloat("blackflag", -1);
            Destroy(collision.gameObject);
        }
        if (collision.gameObject.tag == "Bomb"&&yellowflag1!=1)
        {

            TouchBombFlag = 1;
            m_hp = 0;
            collision.gameObject.GetComponent<Animator>().SetFloat("touchbomb", 1);
            Uiheart.fillAmount = 0.33f * m_hp;

        }
        if (collision.gameObject.tag == "Nail"&&yellowflag1 != 1 )
        {
            --m_hp;
            Uiheart.fillAmount = 0.33f * m_hp;
            playerani.SetFloat("Damageflag", 1);
        }
        if (collision.gameObject.tag == "blackenemy" && blackflag ==-1 && yellowflag1 != 1)
        {
            --m_hp;
            Uiheart.fillAmount = 0.33f * m_hp;
            playerani.SetFloat("Damageflag", 1);

        }
        if (collision.gameObject.tag == "enemywhite" && blackflag ==1 && yellowflag1 != 1)
        {
            --m_hp;
           
            Uiheart.fillAmount = 0.33f * m_hp;
            playerani.SetFloat("Damageflag", 1);
        }
        if (collision.gameObject.tag == "whiteheart" )
        {
            m_hp++;
             if (m_hp>3)
             { m_hp = 3; }
           
            Uiheart.fillAmount = 0.33f * m_hp;
            Destroy(collision.gameObject);
        }
        if (collision.gameObject.name=="rightcollider")
        {
            WinFlag = 1;

        }
    }
    private void Die()
    {
        playerani.SetFloat("Dieflag", 1);
        m_hspeed = 0;

        if (IsAnimationPlaying("whitedie")|| IsAnimationPlaying("blackplayerdie"))
        {
            Dieflag1 = 1;
            Destroy(P1Label);
            //DeathMenu.GetComponent<Deathmenu>().ShowDeathMenu();
        }
        reborn1.SetActive(true);

    }
    public bool IsAnimationPlaying(string animationName)
    {
        
            AnimatorStateInfo animtorinfo= playerani.GetCurrentAnimatorStateInfo(0);

            
            return animtorinfo.IsName(animationName) && animtorinfo.normalizedTime < 1.0f;

    }
    private void UpandDown()
    {
        if (!(playercontrol2.yellowflag2 == 1 && P1P2YDistance <= 3.3&& playercontrol.P1P2YDistance > 0))
        {
           
            if (Input.GetKeyDown(KeyCode.DownArrow) && (transform.position.y == 6.6f || transform.position.y == 3.3f || transform.position.y == 0 || transform.position.y == -3.3f))
            {
                gameObject.transform.position = new Vector3(transform.position.x, transform.position.y - 3.3f, 0);
            }
        }
        if (!(playercontrol2.yellowflag2 == 1 && P1P2YDistance >= -3.3 && P1P2YDistance < 0))
            if (Input.GetKeyDown(KeyCode.UpArrow) && (transform.position.y == -6.6f || transform.position.y == -3.3f || transform.position.y == 0 || transform.position.y == 3.3f))
        {

            gameObject.transform.position = new Vector3(transform.position.x, transform.position.y + 3.3f, 0);

        }
        

    }

}
