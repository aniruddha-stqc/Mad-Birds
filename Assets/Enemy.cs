using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField]
    private GameObject _cloudParticlePrefab;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        //Check enemy colliding with bird
        Bird bird = collision.collider.GetComponent<Bird>();

        if(bird)
        {
            //Spawn cloud
            Instantiate(_cloudParticlePrefab, transform.position, Quaternion.identity);
            Destroy(gameObject);
            return;
        }


        // Enemy hits enemy ignore
        Enemy enemy = collision.collider.GetComponent<Enemy>();

        if(enemy != null)
        {
            return;
        }

        // If any things hits from top more or less steep angle
         
        if( collision.contacts[0].normal.y < -0.30)
        {
            //Spawn cloud
            Instantiate(_cloudParticlePrefab, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
    }
} 
