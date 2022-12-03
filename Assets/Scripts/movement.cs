using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class movement : MonoBehaviour
{
    Vector3 playerPosition;
    [SerializeField]
    int life = 100;
    int speed = 5;
    [SerializeField]
    GameObject enemy;

    enemyAI enemyAI;
    // Start is called before the first frame update
    void Start()
    {
        playerPosition = transform.position;
        enemyAI = GameObject.FindGameObjectWithTag("enemy").GetComponent<enemyAI>();
       // StartCoroutine(spanEnemys());
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
    private void OnCollisionStay2D(Collision2D collision)
    {
        Debug.Log(collision.gameObject.name);
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
        while (true)
        {
            yield return new WaitForSeconds(2.0f);
            playerPosition = new Vector3(transform.position.x + Random.Range(5f,10f), transform.position.y + Random.Range(5f, 10f), transform.position.z );
            Instantiate(enemy, playerPosition, Quaternion.identity);
        }
    }
}

