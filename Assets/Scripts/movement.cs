using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class movement : MonoBehaviour
{
    Vector3 playerPosition;
    int speed = 5;
    [SerializeField]
    GameObject enemy;
    // Start is called before the first frame update
    void Start()
    {
        playerPosition = transform.position;
        StartCoroutine(spanEnemys());
        Instantiate(enemy, new Vector3(1f,0,1f),Quaternion.identity);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.W))
        {
            transform.position += Vector3.up * speed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.S))
        {
            transform.position += Vector3.down * speed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.A))
        {
            transform.position += Vector3.left * speed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.D))
        {
            transform.position += Vector3.right * speed * Time.deltaTime;
        }
       
    }

    void OnCollisionEnter2D()
    {
        Debug.Log("collided");
    }

    IEnumerator spanEnemys()
    {
        while (true)
        {
            yield return new WaitForSeconds(2.0f);
            playerPosition = new Vector3(transform.position.x + Random.Range(5f,10f), transform.position.y + Random.Range(5f, 10f), transform.position.z );
            Instantiate(enemy, playerPosition, Quaternion.identity);
        }
    }
}

