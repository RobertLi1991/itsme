using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class playercontrol2 : MonoBehaviour {
    

    public float m_hspeed2 = 5f;
    public Animator playerani;
    public static GameObject yellowlayer2;
    public  static float blackflag2=-1;
    public static float yellowflag2 = -1;
    public static float TouchBombFlag2 = -1;
    public static float Dieflag2 = -1;
    public static float P2YPosition;
    public static float WinFlag2 = -1;
    public static GameObject P2Label;
    //public static float PauseFlag = -1;
    public float m_hp2 = 3;
    private Vector3 targetPosition;
    [SerializeField]
    private Text MyHpText2;
    [SerializeField]
    private Text Score2;
    [SerializeField]
    private Image Uiheart2;
    [SerializeField]
    private GameObject reborn2;
        

    // Use this for initialization
    void Start () {

        TouchBombFlag2 = -1;
        yellowlayer2 = transform.Find("Yellowcolor2").gameObject;
        P2Label = transform.Find("2P").gameObject;
    }
	
	// Update is called once per frame
	void Update ()
    {
   
        if (Dieflag2 == 1 || WinFlag2 == 1 ||playercontrol.PauseFlag == 1 || playercontrol.Countflag == -1)
        {
            return;
        }

        UpandDown();
        transform.Translate(Vector2.right * m_hspeed2 * Time.deltaTime);
        if (playerani.GetNextAnimatorStateInfo(0).IsName("whitetakedamage")|| playerani.GetNextAnimatorStateInfo(0).IsName("blackplayertakedamage"))
        {
            playerani.SetFloat("Damageflag", -1);
        }
        if (m_hp2<=0)
        {
            Die();
        }
        P2YPosition = transform.position.y;

    }

    private void OnTriggerEnter2D (Collider2D collision)
    {
        if (collision.gameObject.tag == "yellowstone")
        {
           
            Destroy(collision.gameObject);
            yellowflag2 = 1;
        }
        if (collision.gameObject.tag == "blackfood")
        {
            blackflag2 = 1;
            playerani.SetFloat("blackflag", 1);
            Destroy(collision.gameObject);
        }
        if (collision.gameObject.tag == "whitefood")
        {
            blackflag2 = -1;
            playerani.SetFloat("blackflag", -1);
            Destroy(collision.gameObject);
        }
        if (collision.gameObject.tag == "Bomb" && yellowflag2 != 1)
        {

            TouchBombFlag2 = 1;
            m_hp2 = 0;
            collision.gameObject.GetComponent<Animator>().SetFloat("touchbomb", 1);
            Uiheart2.fillAmount = 0.33f * m_hp2;

        }
        if (collision.gameObject.tag == "Nail" && yellowflag2 != 1)
        {
            --m_hp2;
            Uiheart2.fillAmount = 0.33f * m_hp2;
            playerani.SetFloat("Damageflag", 1);
        }
        if (collision.gameObject.tag == "blackenemy" && blackflag2 ==-1 && yellowflag2 != 1)
        {
            --m_hp2;
            Uiheart2.fillAmount = 0.33f * m_hp2;
            playerani.SetFloat("Damageflag", 1);

        }
        if (collision.gameObject.tag == "enemywhite" && blackflag2 ==1 && yellowflag2 != 1)
        {
            --m_hp2;
           
            Uiheart2.fillAmount = 0.33f * m_hp2;
            playerani.SetFloat("Damageflag", 1);
        }
        if (collision.gameObject.tag == "whiteheart" )
        {
            m_hp2++;
             if (m_hp2>3)
             { m_hp2 = 3; }
           
            Uiheart2.fillAmount = 0.33f * m_hp2;
            Destroy(collision.gameObject);
        }
        if (collision.gameObject.name=="rightcollider")
        {
            WinFlag2 = 1;

        }
    }
    private void Die()
    {
        playerani.SetFloat("Dieflag", 1);
        m_hspeed2 = 0;

        if (IsAnimationPlaying("whitedie")|| IsAnimationPlaying("blackplayerdie"))
        {
            Dieflag2 = 1;
            Destroy(P2Label);
            reborn2.SetActive(true);
        }

    }
    public bool IsAnimationPlaying(string animationName)
    {
        
            AnimatorStateInfo animtorinfo= playerani.GetCurrentAnimatorStateInfo(0);

            
            return animtorinfo.IsName(animationName) && animtorinfo.normalizedTime < 1.0f;

    }
    private void UpandDown()
    {
        if (!(playercontrol.yellowflag1 == 1 &&playercontrol.P1P2YDistance>= -3.3&& playercontrol.P1P2YDistance<0))
        {


            if (Input.GetKeyDown(KeyCode.S) && (transform.position.y == 6.6f || transform.position.y == 3.3f || transform.position.y == 0 || transform.position.y == -3.3f))
            {

                gameObject.transform.position = new Vector3(transform.position.x, transform.position.y - 3.3f, 0);
            }
        }
        if (!(playercontrol.yellowflag1 == 1 && playercontrol.P1P2YDistance <= 3.3 && playercontrol.P1P2YDistance > 0))
        {
            if (Input.GetKeyDown(KeyCode.W) && (transform.position.y == -6.6f || transform.position.y == -3.3f || transform.position.y == 0 || transform.position.y == 3.3f))
            {
                gameObject.transform.position = new Vector3(transform.position.x, transform.position.y + 3.3f, 0);
            }
        }

    }
    

}
