using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gunScript : MonoBehaviour
{

    [SerializeField]
    public GameObject ammo;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(attack());
    }

    // Update is called once per frame
    void Update()
    {
        Player player = GameObject.Find("player").GetComponent<Player>();
        if(player.isAlive == false)
        {
            StopCoroutine("attack");
        }
    }
    IEnumerator attack()
    {
        while (true)
        {
            yield return new WaitForSeconds(1f);

            Instantiate(ammo, transform.position, Quaternion.identity);
        }

    }
}
