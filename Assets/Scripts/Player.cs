using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    Vector3 playerPosition;
    Vector3 playerScale;
    [SerializeField]
    int life = 100;
    int speed = 5;

    public bool isAlive = true;
    [SerializeField]
    GameObject[] enemy;
    [SerializeField]
    GameObject playerDied;
    DificultyType dificultyType;

    Animator animate;

    enemyAI enemyAI;
    GameObject[] EveryEnemies;
    // Start is called before the first frame update
    void Start()
    {
        playerPosition = transform.position;
        playerScale = transform.localScale;
        StartCoroutine(spanEnemys());
        animate = GetComponent<Animator>();
        dificultyType = GameObject.Find("level").GetComponent<DificultyType>();
        if (dificultyType == null)
        {
            Debug.Log("Something went wrong, Level not assigned");
        }
        else
        {
            Debug.Log("not null");
        }
        Debug.Log(dificultyType.enemySpanTime);

    }

    // Update is called once per frame
    void Update()
    {
        EveryEnemies = GameObject.FindGameObjectsWithTag("enemy");

        if (life < 0)
        {
            
            isAlive = false;
            foreach (GameObject enemy in EveryEnemies)
            {
                enemy.GetComponent<enemyAI>().isPlayerAlive = false;
            }
            Instantiate(playerDied,transform.position,Quaternion.identity);
            GameObject.Find("Canvas").GetComponent<score>().stopTime();
            Destroy(this.gameObject);
        }
        if (Input.GetKey(KeyCode.W))
        {
            transform.position += Vector3.up * speed * Time.deltaTime;
            animate.SetBool("isRunning", true);
        }
        else if (Input.GetKey(KeyCode.S))
        {
            transform.position += Vector3.down * speed * Time.deltaTime;
            animate.SetBool("isRunning", true);
        }
        else if (Input.GetKey(KeyCode.A))
        {
            transform.position += Vector3.left * speed * Time.deltaTime;
            animate.SetBool("isRunning", true);
            playerScale.x = -3;
            transform.localScale = playerScale;
        }
        else if (Input.GetKey(KeyCode.D))
        {
            transform.position += Vector3.right * speed * Time.deltaTime;
            animate.SetBool("isRunning", true);
            playerScale.x = 3;
            transform.localScale = playerScale;
        }
        else
        {
            animate.SetBool("isRunning", false);

        }
       
    }
    private void OnCollisionStay2D(Collision2D collision)
    {

        enemyAI = collision.gameObject.GetComponent<enemyAI>();
        //Debug.Log(collision.gameObject.name);
        if (collision.gameObject.tag == "enemy")
        {
            enemyAI.StartCoroutine("doDamage");
        }
    }
    public void takedamage(int dmgValue)
    {
        life -= dmgValue;
    }

    IEnumerator spanEnemys()
    {
      //spanTime = ;
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
}

