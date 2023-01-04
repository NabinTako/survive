using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class invinsibility : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Destroy(this.gameObject, 5f);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            other.gameObject.GetComponent<BoxCollider2D>().isTrigger = true;
            other.gameObject.GetComponent<Player>().StartCoroutine("revert");
            Destroy(this.gameObject);
        }
    }


}
