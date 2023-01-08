using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    Vector3 playerPosition;
    Vector3 playerHealthBar;

    [SerializeField]
    int life = 100;
    int speed = 7;

    public bool isAlive = true;
    [SerializeField]
    GameObject[] enemy;
    [SerializeField]
    GameObject playerDied;
    [SerializeField]
    GameObject playerHealth;

    GameObject[] EveryEnemies;


    Animator animate;
    SpriteRenderer playerSprite;

    DificultyType dificultyType;
    enemyAI enemyAI;
    // Start is called before the first frame update
    void Start()
    {
        playerPosition = transform.position;
        playerHealthBar = playerHealth.transform.localScale;

        StartCoroutine(spanEnemys());
        animate = GetComponent<Animator>();
        playerSprite = GetComponent<SpriteRenderer>();

        playerHealth.SetActive(false);
        dificultyType = GameObject.Find("level").GetComponent<DificultyType>();
        if (dificultyType == null)
        {
            Debug.Log("Something went wrong, Level not assigned");
        }

    }

    // Update is called once per frame
    void Update()
    {
        EveryEnemies = GameObject.FindGameObjectsWithTag("enemy");

        movement();
       
    }

    public void movement()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        if (Input.GetKey(KeyCode.A))
        {
            playerSprite.flipX = true;
        }
        if (Input.GetKey(KeyCode.D))
        {
            playerSprite.flipX = false;
        }
        if (Input.GetKey(KeyCode.W) && Input.GetKey(KeyCode.S))
        {
            transform.position += Vector3.zero;
            animate.SetBool("isRunning", false);
        }
        else if (Input.GetKey(KeyCode.A) && Input.GetKey(KeyCode.D))
        {
            transform.position += Vector3.zero;
            animate.SetBool("isRunning", false);
        }
        else if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D))
        {
            animate.SetBool("isRunning", true);
            transform.position += new Vector3(horizontal, vertical,0) * speed * Time.deltaTime;
        }
        else
        {
            animate.SetBool("isRunning", false);

        }

        
    }
    public void takedamage(int dmgValue)
    {
        life -= dmgValue;
    }
    public void addLife()
    {
        life += 20;
        checkLife();
    }
    public void checkLife()
    {
        if (life < 0)
        {

            isAlive = false;
            foreach (GameObject enemy in EveryEnemies)
            {
                enemy.GetComponent<enemyAI>().isPlayerAlive = false;
            }
            Instantiate(playerDied, transform.position, Quaternion.identity);
            GameObject.Find("Canvas").GetComponent<score>().stopTime();
            Destroy(this.gameObject);
        }else if(life >= 100)
        {

            playerHealth.SetActive(false);
        }
        else if(life > 90 && life <100)
        {

            playerHealthBar.x = 0.2f;
            playerHealth.transform.localScale = playerHealthBar;
        }
        else if(life > 80 && life <= 90)
        {
            playerHealthBar.x = 0.17f;
            playerHealth.transform.localScale = playerHealthBar;
        }
        else if (life > 70 && life <= 80)
        {
            playerHealthBar.x = 0.15f;
            playerHealth.transform.localScale = playerHealthBar;
        }
        else if (life > 60 && life <= 70)
        {
            playerHealthBar.x = 0.14f;
            playerHealth.transform.localScale = playerHealthBar;
        }
        else if (life > 50 && life <= 60)
        {
            playerHealthBar.x = 0.12f;
            playerHealth.transform.localScale = playerHealthBar;
        }
        else if (life > 40 && life <= 50)
        {
            playerHealthBar.x = 0.1f;
            playerHealth.transform.localScale = playerHealthBar;
        }
        else if (life > 30 && life <= 40)
        {
            playerHealthBar.x = 0.08f;
            playerHealth.transform.localScale = playerHealthBar;
        }
        else if (life > 20 && life <= 30)
        {
            playerHealthBar.x = 0.06f;
            playerHealth.transform.localScale = playerHealthBar;
        }
        else if (life >= 10 && life <= 20)
        {
            playerHealthBar.x = 0.04f;
            playerHealth.transform.localScale = playerHealthBar;
        }
        else
        {
            playerHealthBar.x = 0.02f;
            playerHealth.transform.localScale = playerHealthBar;
        }
    }
    private void OnCollisionStay2D(Collision2D collision)
    {

        enemyAI = collision.gameObject.GetComponent<enemyAI>();
        //Debug.Log(collision.gameObject.name);
        if (collision.gameObject.tag == "enemy")
        {
            playerHealth.SetActive(true);
            enemyAI.StartCoroutine("doDamage");
        }
        checkLife();
    }
    IEnumerator spanEnemys()
    {
        while (isAlive)
        {
            yield return new WaitForSeconds(2f);
            int num = (int)Mathf.Ceil(Random.Range(0f, 3f));
            for (int i = 0; i < dificultyType.enemyNumber; i++)
            {
                playerPosition = new Vector3(transform.position.x + Random.Range(5f, 10f), transform.position.y + Random.Range(5f, 10f), transform.position.z);
                Instantiate(enemy[num], playerPosition, Quaternion.identity);
            }
        }
    }
    public IEnumerator revert()
    {

        this.gameObject.GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, 0.5f);
        yield return new WaitForSeconds(2f);
        this.gameObject.GetComponent<BoxCollider2D>().isTrigger = false;
        this.gameObject.GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, 1);
    }


}

