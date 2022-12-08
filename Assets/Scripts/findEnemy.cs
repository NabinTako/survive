using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class findEnemy : MonoBehaviour
{
    GameObject closeEnemy;
    float speed = 0.5f;
    private void Start()
    {
        
    }
    private void Update() { 
        if()
        closeEnemy = FindClosestEnemy();

        transform.position = Vector3.MoveTowards(transform.position, closeEnemy.transform.position, speed * Time.deltaTime);
    }
    public GameObject FindClosestEnemy()
    {
        GameObject[] enemies;
        enemies = GameObject.FindGameObjectsWithTag("enemy");
        GameObject closest = null;
        float distance = Mathf.Infinity;
        Vector3 position = this.transform.position;
        foreach (GameObject enemy in enemies)
        {
            Vector3 diff = enemy.transform.position - position;
            float curDistance = diff.sqrMagnitude;
            if (curDistance < distance)
            {
                closest = enemy;
                distance = curDistance;
            }
        }
        return closest;
    }
    private void OnCollisionEnter2D(Collision2D other)
    {
        if(other.gameObject.tag == "enemy")
        {
            other.gameObject.GetComponent<enemyAI>().takeDmg(50);
            Destroy(this.gameObject);
        }
    }

}