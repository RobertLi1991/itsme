using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class playercontrol : MonoBehaviour {
    
    public float m_speed = 5f;
    public float m_hspeed = 5f;
    public Animator playerani;
    public float blackflag=-1;
    public float m_hp = 3;
    public float m_blackpoint=0;
    public float m_whitepoint=0;
    public float m_wbproportion = 0;
    private Vector3 targetPosition;
    [SerializeField]
    private Text MyHpText;
    [SerializeField]
    private Text MywhiteproportionText;
    [SerializeField]
    private Slider WhiteProportion;
    [SerializeField]
    private Image Uiheart;
    
    public GameObject PassLevelMenu;
    public GameObject DeathMenu;
    // Use this for initialization
    void Start () {
        Time.timeScale = 1f;
    }
	
	// Update is called once per frame
	void Update ()
    {
        
        UpandDown();
        transform.Translate(Vector2.right * m_hspeed * Time.deltaTime);
        Debug.Log(Time.deltaTime);
        if (m_hp<=0)
        {
            Die();
        }
        m_wbproportion = m_whitepoint / (m_whitepoint + m_blackpoint);
        WhiteProportion.value = m_wbproportion;
        MywhiteproportionText.text = "White proportion:" + (m_wbproportion * 100).ToString("#0.0")+"%";
       

    }

    private void OnTriggerEnter2D (Collider2D collision)
    {
        if(collision.gameObject.tag=="blackfood")
        {   
            blackflag = 1;
            playerani.SetFloat("blackflag",1);
            
            m_blackpoint=foodparent.addpoint(m_blackpoint,collision.gameObject.name);
            
        }
        if (collision.gameObject.tag == "whitefood")
        {
            blackflag = -1;
            playerani.SetFloat("blackflag", -1);
            
            m_whitepoint = foodparent.addpoint(m_whitepoint, collision.gameObject.name);

        }
        if(collision.gameObject.tag == "tombstone")
        {
          
            m_hp = 0;
           
            Uiheart.fillAmount = 0.33f*m_hp;
        }
        if (collision.gameObject.tag == "blackenemy" && blackflag ==-1)
        {
            --m_hp;
            
            Uiheart.fillAmount = 0.33f * m_hp;
        }
        if (collision.gameObject.tag == "enemywhite" && blackflag ==1)
        {
            --m_hp;
           
            Uiheart.fillAmount = 0.33f * m_hp;
        }
        if (collision.gameObject.tag == "whiteheart" )
        {
            m_hp++;
             if (m_hp>3)
             { m_hp = 3; }
           
            Uiheart.fillAmount = 0.33f * m_hp;
        }
        if (collision.gameObject.name=="rightcollider")
        {
            if (m_wbproportion>=0.6)
            {
                PassLevelMenu.GetComponent<Passlevelmenu>().ShowPassLevelMenu(m_wbproportion);

            }
            else
            {
                DeathMenu.GetComponent<Deathmenu>().ShowDeathMenu();
            }
        }
    }
    private void Die()
    {
        DeathMenu.GetComponent<Deathmenu>().ShowDeathMenu();
       
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
