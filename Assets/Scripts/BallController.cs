using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour
{

    private Rigidbody ballRb;
    public float impulseForce = 5f;
    private bool ignoreCollision;
    public Vector3 startPos;
    public int perfectPass;
    public bool isSuperSpeedActive;

    // Start is called before the first frame update
    void Start()
    {
        ballRb = GetComponent<Rigidbody>();
        startPos = transform.position;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (ignoreCollision)
            return;

        if (isSuperSpeedActive)
        {
            if (!collision.transform.GetComponent<GoalBehaviour>())
            {
                Destroy(collision.transform.parent.gameObject);
                Debug.Log("Destroying platform");
            }
        }
        else
        {
            // Adding ResetLevel Functionality via DeathPart.
            DeathPart deathPart = collision.transform.GetComponent<DeathPart>();
            if (deathPart)
            {
                deathPart.HitDeathPart();
            }
        }

        ballRb.velocity = Vector3.zero;
        ballRb.AddForce(Vector3.up * impulseForce, ForceMode.Impulse);
        ignoreCollision = true;
        Invoke("AllowCollision", .2f);
        perfectPass = 0;
        isSuperSpeedActive = false;
    }

    private void Update()
    {
       if (perfectPass >= 3 && !isSuperSpeedActive)
        {
            isSuperSpeedActive = true;
            ballRb.AddForce(Vector3.down * 10, ForceMode.Impulse);
        }
    }

    void AllowCollision()
    {
        ignoreCollision = false;
    }

    public void ResetBall()
    {
        transform.position = startPos;
    }
}
