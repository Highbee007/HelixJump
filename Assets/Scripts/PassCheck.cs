using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PassCheck : MonoBehaviour
{
    // Start is called before the first frame update
    private void OnTriggerEnter(Collider other)
    {
        GameManager.singleton.AddScore(5);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
