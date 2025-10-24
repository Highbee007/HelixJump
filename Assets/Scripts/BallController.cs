using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour
{

    public Rigidbody ballRb;
    public float impulseFloat = 5f;
    private bool isNextCollision;

    // Start is called before the first frame update
    void Start()
    {
        ballRb = GetComponent<Rigidbody>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        ballRb.velocity = Vector3.zero;
        ballRb.AddForce(Vector3.up, ForceMode.Impulse);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
