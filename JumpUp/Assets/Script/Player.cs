using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    [Header("Awake variables")]
    Rigidbody2D body;
    SpriteRenderer sprite;
    Animator anim;

    [Header("Player Movement")]
    public float velocidadeMaxima;

    [Header("Jump Player")]
    public Transform checkGround;
    public LayerMask whatIsGround;
    public float radius;

    public float forcaPulo;
    public bool isGrounded;

    public bool pular = false;

    [Header("Lives")]
    public float lives;
    public Text TextLives;

    public bool Morreu = false;

    [Header("Checkpoints")]
    public GameObject lastCheckpoint;

    public GameObject firstCheckpoint;
    public GameObject lastcheckpointGreen1;
    public GameObject lastcheckpointGreen2;
    public GameObject lastcheckpointGreen3;
    public GameObject lastcheckpointGreen4;

    public GameObject lastcheckpoint1;
    public GameObject lastcheckpoint2;
    public GameObject lastcheckpoint3;
    public GameObject lastcheckpoint4;

    [Header("Hearts")]
    public GameObject Coracao1;
    public GameObject Coracao2;

    public GameObject Coracao1Dois;
    public GameObject Coracao2Dois;

    [Header("Variables for GameManager")]
    public static bool isDead = false;
    public static bool isPaused = false;


    [Header("Others")]
    public GameObject Spawner;
    public GameObject PainelMorreu;
    public GameObject Dano;
    public GameObject Parabens;
    public GameObject PainelPause;

    private void Awake()
    {
        body = GetComponent<Rigidbody2D>();
        sprite = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
    }
    void Start()
    {
        TextLives.text = lives.ToString();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            pular = true;
        }
    }

    private void FixedUpdate()
    {
        //Movement player
        float movimento = Input.GetAxis("Horizontal");

        body.velocity = new Vector2(movimento * velocidadeMaxima, body.velocity.y);

        if ((movimento > 0 && sprite.flipX) || (movimento < 0 && !sprite.flipX))
        {
            Flip();
        }

        //Check ground
        isGrounded = Physics2D.OverlapCircle(checkGround.position, radius, whatIsGround);

        //Jump
        if (pular)
        {
            body.AddForce(new Vector2(body.velocity.x, forcaPulo));
            GetComponent<AudioSource>().Play();
            pular = false;
        }

        if (isGrounded)
        {
            anim.SetBool("Pulando", false);
        }

        else
        {
            anim.SetBool("Pulando", true);
        }

        //Lives
        if (lives <= 0)
        {
            isDead = true;
        }
    }

    void Flip()
    {
        sprite.flipX = !sprite.flipX;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Spy"))
        {
            lives -= 1;
            Dano.SetActive(true);
            TextLives.text = lives.ToString();
        }

        if (collision.gameObject.CompareTag("LimitesChão"))
        {
            if (lives == 1)
            {
                lives -= 1;
            }
            else if( lives == 2)
            {
                lives -= 2;
            }

            else if (lives == 3)
            {
                lives -= 3;
            }
            
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Spy"))
        {
            Dano.SetActive(false);
        }
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.gameObject.CompareTag("Portal"))
        {
            Parabens.SetActive(true);
            pular = false;
            Time.timeScale = 0;
        }

        if (collision.gameObject.CompareTag("Coração"))
        {
            lives += 1;
            TextLives.text = lives.ToString();
        }

        if (collision.gameObject.CompareTag("Coração2"))
        {
            lives += 5;
            TextLives.text = lives.ToString();
            //Spawner.SetActive(true);
        }

        if (collision.gameObject.CompareTag("Checkpoint"))
        {
            lastCheckpoint = collision.gameObject;
        }

            if (collision.gameObject.CompareTag("Checkpoint1"))
        {
            lastcheckpointGreen1.SetActive(true);
            lastCheckpoint = collision.gameObject;
            lastcheckpoint1.SetActive(false);
            lastcheckpoint3.SetActive(true);
            lastcheckpoint2.SetActive(true);
        }

        if (collision.gameObject.CompareTag("Checkpoint2"))
        {
            lastCheckpoint = collision.gameObject;
            lastcheckpointGreen2.SetActive(true);
            lastcheckpointGreen1.SetActive(false);
            lastcheckpoint2.SetActive(false);
            lastcheckpoint1.SetActive(true);
            lastcheckpoint3.SetActive(true);

        }

        if (collision.gameObject.CompareTag("Checkpoint3"))
        {
            lastcheckpointGreen3.SetActive(true);
            lastCheckpoint = collision.gameObject;
            lastcheckpointGreen1.SetActive(false);
            lastcheckpointGreen2.SetActive(false);
            lastcheckpoint3.SetActive(false);
            lastcheckpoint2.SetActive(true);
            lastcheckpoint1.SetActive(true);
        }

        if (collision.gameObject.CompareTag("Checkpoint4"))
        {
            lastcheckpointGreen4.SetActive(true);
            lastcheckpoint4.SetActive(false);
            lastCheckpoint = collision.gameObject;
            lastcheckpoint3.SetActive(true);
            lastcheckpoint2.SetActive(true);
            lastcheckpoint1.SetActive(true);
        }
    }

    public void Denovo()
    {
        isDead = false;
        pular = false;
        Dano.SetActive(false);
        lives += 2;
        TextLives.text = lives.ToString();
        transform.position = lastCheckpoint.transform.position;
        Time.timeScale = 1;
        PainelMorreu.SetActive(false);
        Coracao1.SetActive(true);
        Coracao2.SetActive(false);

       // Coracao1Dois.SetActive(true);
     //   Coracao2Dois.SetActive(false);

        //Spawner.SetActive(false);
    }

    public void Checkpoint()
    {
        transform.position = lastCheckpoint.transform.position;
        PainelPause.SetActive(false);
        Time.timeScale = 1;
        pular = false;
        Coracao1.SetActive(true);
        Coracao2.SetActive(false);

       // Spawner.SetActive(false);
    }

    public void MenuMute()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("MenuMute");
        Time.timeScale = 1;
    }


    public void LevelDois()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("Level2");
        Time.timeScale = 1;

        if(lives == 1)
        {
            lives += 1;
            TextLives.text = lives.ToString();
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(checkGround.position, radius);
    }
}
