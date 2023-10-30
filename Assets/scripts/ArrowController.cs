using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowController : MonoBehaviour
{
    public float speedArrow;
    public float liveArrow;

    private Vector2 arrowDirection;
    private float timeAlive = 0f;
    //public Transform transformArrow;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        moventArrow();

    }

    private void moventArrow() {
        transform.Translate(Vector2.right * speedArrow * Time.fixedDeltaTime);

        if (arrowDirection == Vector2.right)
        {
            GetComponent<SpriteRenderer>().flipX = false;

        }
        else
        {
            GetComponent<SpriteRenderer>().flipX = true;
        }
        timeAlive += Time.fixedDeltaTime;

        if (timeAlive>= liveArrow) { 
            Destroy(gameObject);
        }
    }

    public void setDirection(Vector2 dir)
    {
        arrowDirection = dir;

    }
}
