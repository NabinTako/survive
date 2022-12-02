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
    //This will be the zombie's speed. Adjust as necessary.
    private float speed = 4.0f;
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
    }

}
