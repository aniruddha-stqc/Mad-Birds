using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Bird : MonoBehaviour
{
    private Vector3 _initialPosition;
    private bool _birdWasLaunched;
    private float _timeSittingAround;

    [SerializeField]
    private float _launchPower = 500;
    

    private void Awake()
    {
        //Store initial position
        _initialPosition = transform.position;
    }

    private void Update()
    {
        GetComponent<LineRenderer>().SetPosition(0, transform.position);
        GetComponent<LineRenderer>().SetPosition(1, _initialPosition );

        if (_birdWasLaunched &&
            GetComponent<Rigidbody2D>().velocity.magnitude <= 0.1)
        {
            //How long the bird is inactive
            _timeSittingAround += Time.deltaTime;
        }
        // if bird goes too high reload scene
        if(transform.position.y > 10 ||
           transform.position.y < -10 ||
           transform.position.x > 10 ||
           transform.position.x < -10 ||
           _timeSittingAround > 3)
        {
            string currentSceneName = SceneManager.GetActiveScene().name;
            SceneManager.LoadScene(currentSceneName);
        }
    }

    //Turn bird red on press
    private void OnMouseDown()
    {
        GetComponent<SpriteRenderer>().color = Color.red;
        //Add line when touched
        GetComponent<LineRenderer>().enabled = true;
    }

    //Turn bird green on release
    private void OnMouseUp()
    {
        GetComponent<SpriteRenderer>().color = Color.white;

        // Give directional force
        Vector2 directionToInitialPosition = _initialPosition - transform.position;
        GetComponent<Rigidbody2D>().AddForce(directionToInitialPosition * _launchPower);
        // make it fall down
        GetComponent<Rigidbody2D>().gravityScale = 1;   
        _birdWasLaunched = true;
        //Remove line render when released 
        GetComponent<LineRenderer>().enabled = false;
    }

    private void OnMouseDrag()
    {
        Vector3 newPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        transform.position = new Vector3(newPosition.x, newPosition.y);
    }
}
