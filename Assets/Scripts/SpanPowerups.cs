using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.Search;
using UnityEngine;

public class SpanPowerups : MonoBehaviour
{
    Player player;

    [SerializeField]
    private GameObject[] powerUps;
    Vector3 spanPosition;
    // Start is called before the first frame update
    void Start()
    {
      player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
        StartCoroutine("spanPowerUps");
    }
    private void Update()
    {
        if(player.isAlive == false)
        {
            StopCoroutine(spanPowerUps());
        }
    }
    IEnumerator spanPowerUps()
    {
        while (player.isAlive)
        {
         yield return new WaitForSeconds(5f);
         int powerupIndex = (int) Mathf.Floor(Random.Range(0f, 5f));
         spanPosition = new Vector3(Random.Range(-8.6f, 8.6f), Random.Range(-4.5f, 4.5f),1);
         Instantiate(powerUps[powerupIndex], spanPosition, Quaternion.identity);
            
        }
    }
}
