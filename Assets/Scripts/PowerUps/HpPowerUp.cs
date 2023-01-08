using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HpPowerUp : MonoBehaviour
{
    void Start()
    {
        Destroy(this.gameObject, 10f);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            other.gameObject.GetComponent<Player>().addLife();
            Destroy(this.gameObject);
        }
    }
}
