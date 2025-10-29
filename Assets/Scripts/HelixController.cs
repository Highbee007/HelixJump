using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HelixController : MonoBehaviour
{
    private Vector2 lastTapPos;
    private Vector3 startRotation;

    public Transform topTransform;
    public Transform goalTransform;
    public GameObject helixLevelPrefab;
    private BallController ball;

    public List<Stages> allStages = new List<Stages>();
    private float helixDistance;
    private List<GameObject> spawnedLevels = new List<GameObject>();
    void Awake()
    {
        ball = GameObject.Find("Ball").GetComponent<BallController>();
        startRotation = transform.localEulerAngles;
        helixDistance = topTransform.localPosition.y - (goalTransform.localPosition.y + 0.1f);
        LoadStage(0);
    }


    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            Vector2 currentTapPos = Input.mousePosition;

            if (lastTapPos == Vector2.zero)
            {
                lastTapPos = currentTapPos;
            }

            float delta = lastTapPos.x - currentTapPos.x;
            lastTapPos = currentTapPos;

            transform.Rotate(Vector3.up * delta);

            if (Input.GetMouseButtonUp(0))
            {
                lastTapPos = Vector2.zero;
            }
        }
    }
    public void LoadStage(int stageNumber)
    {
        Stages stage = allStages[Mathf.Clamp(stageNumber, 0, allStages.Count - 1)];

        if (allStages == null)
        {
            Debug.LogError("No stages " + stageNumber + " found in allstage list. Are all stages assigned to the list?");
            return;
        }

        Camera.main.backgroundColor = allStages[stageNumber].stageBackgroundColor;

        ball.GetComponent<MeshRenderer>().material.color = allStages[stageNumber].stageBallColor;

        transform.localEulerAngles = startRotation;

        foreach (GameObject go in spawnedLevels)
        {
            Destroy(go);
        }

        float levelDistance = helixDistance / stage.levels.Count;
        float spawnPosY = transform.localPosition.y;

        for (int i = 0; i < stage.levels.Count; i++)
        {
            spawnPosY -= levelDistance;
            // Create level within scene
            GameObject level = Instantiate(helixLevelPrefab, transform);
            Debug.Log(level);
            level.transform.localPosition = new Vector3(0, spawnPosY, 0);
            spawnedLevels.Add(level);
        }
    }
}
