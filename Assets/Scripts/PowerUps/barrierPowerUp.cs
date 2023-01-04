using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class barrierPowerUp : MonoBehaviour
{
    // Start is called before the first frame update
    Vector3 scale;
    void Start()
    {
        scale = transform.localScale;
    }

    // Update is called once per frame
    void Update()
    {
        scale = new Vector3(0.5f,0.5f,1);
        transform.localScale = scale;
    }
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "enemy")
        {
            other.gameObject.GetComponent<enemyAI>().takeDmg(20);
        }
    }
}
