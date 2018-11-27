using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class playercontrol : MonoBehaviour {
    

    public float m_hspeed = 5f;
    public Animator playerani;
    
    public  static float blackflag=-1;
    public static float TouchBombFlag = -1;
    public static float Dieflag = -1;
    public static float Countflag = -1;
    public float WinFlag = -1;
    public static float PauseFlag = -1;
    public float m_hp = 3;
    private Vector3 targetPosition;
    [SerializeField]
    private Text MyHpText;
    [SerializeField]
    private Text Score;
    [SerializeField]
    private Image Uiheart;
    public GameObject PassLevelMenu;
    public GameObject DeathMenu;
    
    // Use this for initialization
    void Start () {
        Countflag = -1;
        TouchBombFlag = -1;
    }
	
	// Update is called once per frame
	void Update ()
    {   
        if(Dieflag==1|| WinFlag == 1||PauseFlag==1 || Countflag == -1)
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
    }

    private void OnTriggerEnter2D (Collider2D collision)
    {
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
        if (collision.gameObject.tag == "Bomb")
        {

            TouchBombFlag = 1;
            m_hp = 0;
            collision.gameObject.GetComponent<Animator>().SetFloat("touchbomb", 1);
            Uiheart.fillAmount = 0.33f * m_hp;

        }
        if (collision.gameObject.tag == "Nail" )
        {
            --m_hp;
            Uiheart.fillAmount = 0.33f * m_hp;
            playerani.SetFloat("Damageflag", 1);
        }
        if (collision.gameObject.tag == "blackenemy" && blackflag ==-1)
        {
            --m_hp;
            Uiheart.fillAmount = 0.33f * m_hp;
            playerani.SetFloat("Damageflag", 1);

        }
        if (collision.gameObject.tag == "enemywhite" && blackflag ==1)
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
           PassLevelMenu.GetComponent<Passlevelmenu>().ShowPassLevelMenu(ScoreManager.score);
        }
    }
    private void Die()
    {
        playerani.SetFloat("Dieflag", 1);
        m_hspeed = 0;

        if (IsAnimationPlaying("whitedie")|| IsAnimationPlaying("blackplayerdie"))
        {
            DeathMenu.GetComponent<Deathmenu>().ShowDeathMenu();
        }

    }
    public bool IsAnimationPlaying(string animationName)
    {
        
            AnimatorStateInfo animtorinfo= playerani.GetCurrentAnimatorStateInfo(0);

            
            return animtorinfo.IsName(animationName) && animtorinfo.normalizedTime < 1.0f;

    }
    private void UpandDown()
    {
        
        if (Input.GetKeyDown(KeyCode.DownArrow) &&(transform.position.y == 3.3f  || transform.position.y == 0))
        {
            
            gameObject.transform.position = new Vector3(transform.position.x, transform.position.y-3.3f , 0);
           
             
        }
       
        else if (Input.GetKeyDown(KeyCode.UpArrow) && (transform.position.y == -3.3f  || transform.position.y == 0))
        {
           
            gameObject.transform.position = new Vector3(transform.position.x, transform.position.y + 3.3f , 0);
           
        }
        

    }

}
