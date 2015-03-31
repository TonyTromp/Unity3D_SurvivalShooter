using UnityEngine;
using System.Collections;

public class EnemyMovement : MonoBehaviour
{
    GameObject player;
	PlayerHealth playerHealth;
    EnemyHealth enemyHealth;
    NavMeshAgent nav;


    void Awake ()
    {
        enemyHealth = GetComponent <EnemyHealth> ();
        nav = GetComponent <NavMeshAgent> ();

		player = GameObject.FindGameObjectWithTag ("Player");

		Debug.Log("player" +player.name);
		playerHealth = player.GetComponent<PlayerHealth>();

    }
	

    void Update ()
    {

        if(enemyHealth.currentHealth > 0 && playerHealth.currentHealth > 0 )
        {
            nav.SetDestination (player.transform.position);
        }
        else
        {
            nav.enabled = false;
        }
    }
}
