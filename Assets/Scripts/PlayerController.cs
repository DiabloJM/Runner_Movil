using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
     // A reference to the Rigidbody component 
    private Rigidbody rb;
    
    [Tooltip("How fast the ball moves left/right")]
    [Range(0, 10)]
    public float dodgeSpeed = 5;
    
    [Tooltip("How fast the ball moves forwards automatically")]
    [Range(0, 10)]
    public float rollSpeed = 5;

    // Start is called before the first frame update
    void Start()
    {
        // Get access to our Rigidbody component 
        rb = GetComponent<Rigidbody>();
    }

    /// <summary>
    /// FixedUpdate is called at a fixed framerate and is a prime place to put
    /// Anything based on time.
    /// </summary>
    private void FixedUpdate()
    {
        // Check if we're moving to the side 
        //var horizontalSpeed = Input.GetAxis("Horizontal") * dodgeSpeed;
        rb.AddForce(0, 0, rollSpeed);
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.LeftArrow))
        {
            Vector3 _temp = transform.position;

            if (_temp.x > -1.9f)
            {
                _temp.x -= 1.9f;
                transform.position = _temp;
            }
        }

        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            Vector3 _temp = transform.position;

            if (_temp.x < 1.9f)
            {
                _temp.x += 1.9f;
                transform.position = _temp;
            }
        }
    }
}