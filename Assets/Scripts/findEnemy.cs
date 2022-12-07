using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class findEnemy : MonoBehaviour
{
    GameObject closeEnemy;
    private void Start()
    {
        
    }
    private void Update()
    {
        closeEnemy = FindClosestEnemy();
        Debug.DrawLine(this.transform.position, closeEnemy.transform.position,Color.black);
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
}