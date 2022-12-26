using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class enemyAI : MonoBehaviour
{
    private GameObject player;


    private score score;
    [SerializeField]
    private GameObject deathAnimation;
    private Vector3 playerPosition;
    private Vector3 Scale;
    //This will be the enemy speed.
    [SerializeField]
    private float speed;

    [SerializeField]
    private int attackPower = 5;
    private float objectScale;
    public int scorepoint;

    [SerializeField]
    private int HP = 100;


    public bool isPlayerAlive = true;
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        score = GameObject.Find("Canvas").GetComponent<score>();
        Scale = transform.localScale;
        objectScale = transform.localScale.x;
        StartCoroutine(leftRight());
        speed = GameObject.Find("level").GetComponent<DificultyType>().enemySpeed;
    }

    void Update()
    {
        if (isPlayerAlive)
        {
            playerPosition = new Vector3(player.transform.position.x, player.transform.position.y, transform.position.z);
        }
        //Here, the zombie's will follow the waypoint.
        transform.position = Vector3.MoveTowards(transform.position, playerPosition, speed * Time.deltaTime);

        if(HP < 0)
        {
            Instantiate(deathAnimation,transform.position,Quaternion.identity);
            score.addScore(scorepoint);
            Destroy(this.gameObject);
        }

    }
    public void takeDmg(int attackPower)
    {
        HP -= attackPower;
    }
    public IEnumerator doDamage()
    {
        Player player = this.player.GetComponent<Player>();
        yield return new WaitForSeconds(0.5f);
        player.takedamage(attackPower);
        StopCoroutine("doDamage");
    }
    IEnumerator leftRight() //  makes enemies look to left or right.
    {
         while (true)
        {
            Vector3 checkPos = transform.position;
            yield return new WaitForSeconds(0.2f);
            if (checkPos.x > transform.position.x)
            {
                Scale.x = objectScale;
                transform.localScale = Scale;
            }
            else
            {
                Scale.x = -objectScale;
                transform.localScale = Scale;
        }
        }
    }

}
