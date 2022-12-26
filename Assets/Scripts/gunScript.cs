using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gunScript : MonoBehaviour
{

    [SerializeField]
    public GameObject ammo;
    DificultyType dificultyType;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(attack());
        dificultyType = GameObject.Find("level").GetComponent<DificultyType>();
        if (dificultyType == null) Debug.Log("Something went wrong, Level not assigned");
    }

    // Update is called once per frame
    void Update()
    {
        Player player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
        if (player.isAlive == false)
        {
            StopCoroutine("attack");
        }
    }
    IEnumerator attack()
    {
       // float fireRate = dificultyType.fireRate;
        while (true)
        {
            yield return new WaitForSeconds(1f);

            Instantiate(ammo, transform.position, Quaternion.identity);
        }

    }
}
