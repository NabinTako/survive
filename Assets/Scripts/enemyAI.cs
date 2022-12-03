using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class enemyAI : MonoBehaviour
{
    // Start is called before the first frame update
    //You may consider adding a rigid body to the zombie for accurate physics simulation
    [SerializeField]
    private GameObject player;
    private Vector3 playerPosition;
    private Vector3 Scale;
    //This will be the zombie's speed. Adjust as necessary.
    [SerializeField]
    private float speed = 0f;

    [SerializeField]
    private int attackPower = 5;


    private bool isLook = true;
    void Start()
    {
        //At the start of the game, the zombies will find the gameobject called wayPoint.
        player = GameObject.Find("player");
    }

    void Update()
    {
        playerPosition = new Vector3(player.transform.position.x, player.transform.position.y, transform.position.z);
        //Here, the zombie's will follow the waypoint.
        transform.position = Vector3.MoveTowards(transform.position, playerPosition, speed * Time.deltaTime);

        Scale = transform.localScale;
        Vector3 checkPos = transform.position * Time.deltaTime; 
        if (checkPos.x > transform.position.x && isLook)
        {
            change();
        }

    }

    void change()
    {
        Scale.x *= -1;
        transform.localScale = Scale;
        isLook = false;
        /*
        if (isLook == true)
        {
            Vector3 checkPos = transform.position * Time.deltaTime;
            if (checkPos.x > transform.position.x)
            {
                isLook = false;
            }
            else
            {
                //Scale.x *= -1;
            }
        }
        */
    }
    public IEnumerator doDamage()
    {
        movement player = this.player.GetComponent<movement>();
        yield return new WaitForSeconds(1f);
        player.takedamage(attackPower);
        StopCoroutine("doDamage");
    }

}
