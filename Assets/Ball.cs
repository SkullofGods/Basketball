using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class Ball : MonoBehaviour
{
    [HideInInspector] public Rigidbody2D rb;
    [HideInInspector] public CircleCollider2D col;
    public int Score;
    public bool em = true;
    public bool isGo;
    public GameObject Hoop1;
    public GameObject Hoop2;
    public Text scoretext;
    public Timer timerl;
    [HideInInspector] public Vector3 pos { get { return transform.position; } }

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        col = GetComponent<CircleCollider2D>();
    }
    public void Restart()
    {
        SceneManager.LoadScene(0);
    }
    public void Push(Vector2 force)
    {
        rb.AddForce(force, ForceMode2D.Impulse);
    }

    public void ActivateRb()
    {
        rb.isKinematic = false;
    }
    void OnTriggerEnter2D(Collider2D col)
    {
        
        Score++;
        scoretext.text = Score.ToString();
        if (em == true)
        {
          
            Hoop1.SetActive(false);
            Hoop2.SetActive(true);
           
        }
        if (em == false)
        {
          
            Hoop2.SetActive(false);
            Hoop1.SetActive(true);
           
        }
        em = !em;
        timerl.MinusTime();
       
    }
    public void DesactivateRb()
    {
        rb.velocity = Vector3.zero;
        rb.angularVelocity = 0f;
     
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            isGo = true;

        }


    }
   
}
