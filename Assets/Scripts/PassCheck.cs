using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PassCheck : MonoBehaviour
{
    private BallController ball;
    // Start is called before the first frame update
    private void Start()
    {
        ball = GameObject.Find("Ball").GetComponent<BallController>();
    }
    // Start is called before the first frame update
    private void OnTriggerEnter(Collider other)
    {
        GameManager.singleton.AddScore(5);
        ball.perfectPass++;
        Debug.Log("Perfect pass increased to " + ball.perfectPass);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
