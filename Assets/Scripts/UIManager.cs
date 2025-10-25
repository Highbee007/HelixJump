using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{

    [SerializeField] private TextMeshProUGUI textScore;
    [SerializeField] private TextMeshProUGUI textBestScore;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        textScore.text = "Score: " + GameManager.singleton.score;
        textBestScore.text = "Best Score: " + GameManager.singleton.best;
    }
}
