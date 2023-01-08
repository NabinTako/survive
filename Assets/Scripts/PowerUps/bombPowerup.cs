using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bombPowerup : MonoBehaviour
{
    void Start()
    {
        Destroy(this.gameObject, 10f);
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.tag == "Player")
        {
            GameObject[] enemies;
            enemies = GameObject.FindGameObjectsWithTag("enemy");
            foreach (GameObject enemy in enemies)
            {
                enemy.GetComponent<enemyAI>().takeDmg(30);
            }
            Destroy(this.gameObject);
        }
    }


}
