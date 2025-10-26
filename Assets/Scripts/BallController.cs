using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour
{

    private Rigidbody ballRb;
    public float impulseForce = 5f;
    private bool ignoreCollision;
    public Vector3 startPos;

    // Start is called before the first frame update
    void Start()
    {
        ballRb = GetComponent<Rigidbody>();
        startPos = transform.position;
    }

    private void OnCollisionEnter(Collision collision)
    {
        // Adding ResetLevel Functionality via DeathPart.
        DeathPart deathPart = collision.transform.GetComponent<DeathPart>();
        if (deathPart)
        {
            deathPart.HitDeathPart();
        }

        if (ignoreCollision)
            return;

        ballRb.velocity = Vector3.zero;
        ballRb.AddForce(Vector3.up * impulseForce, ForceMode.Impulse);
        ignoreCollision = true;
        Invoke("AllowCollision", .2f);
    }

    private void AllowCollision()
    {
        ignoreCollision = false;
    }

    public void ResetBall()
    {
        transform.position = startPos;
    }
}
