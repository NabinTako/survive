using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class enemyAI : MonoBehaviour
{
    // Start is called before the first frame update
    //You may consider adding a rigid body to the zombie for accurate physics simulation
    private GameObject player;
    [SerializeField]
    private GameObject deathAnimation;
    private Vector3 playerPosition;
    private Vector3 Scale;
    //This will be the zombie's speed. Adjust as necessary.
    [SerializeField]
    private float speed = 0f;

    [SerializeField]
    private int attackPower = 5;
    private float objectScale;

    [SerializeField]
    private int HP = 100;


    public bool isPlayerAlive = true;
    void Start()
    {
        //At the start of the game, the zombies will find the gameobject called wayPoint.
        player = GameObject.Find("player");
        Scale = transform.localScale;
        objectScale = transform.localScale.x;
        StartCoroutine(leftRight());
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
            Destroy(this.gameObject);
        }

    }
    public void takeDmg(int attackPower)
    {
        HP -= attackPower;
    }
    public IEnumerator doDamage()
    {
        movement player = this.player.GetComponent<movement>();
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
                Scale.x = -objectScale;
                transform.localScale = Scale;
            }
            else
            {
                Scale.x = objectScale;
                transform.localScale = Scale;
        }
        }
    }

}
