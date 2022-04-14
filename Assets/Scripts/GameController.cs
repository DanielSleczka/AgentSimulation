using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    [Header("Time")]
    [SerializeField] private float minTimeToRespawn;
    [SerializeField] private float maxTimeToRespawn;
    private float getTimeToRespawn;
    private float currentTime;

    [Header("Agent")]
    [SerializeField] private float maxNumberOfAgents;
    [SerializeField] private Agent agent;

    [Header("Map")]
    [SerializeField] private List<Transform> spawnPoints;


    private void Start()
    {
        SetTimeToRespawn();
    }


    private void Update()
    {
        CheckRespawnCondition();
    }

    public void CheckRespawnCondition()
    {
        if (currentTime >= getTimeToRespawn)
        {
            GenerateNewAgent();
            SetTimeToRespawn();
        }

        currentTime += Time.deltaTime;
        Debug.Log(currentTime);
    }

    public void SetTimeToRespawn()
    {
        getTimeToRespawn = Random.Range(minTimeToRespawn, maxTimeToRespawn);
        currentTime = 0f;
    }


    public void GenerateNewAgent()
    {
        Agent newAgent = Instantiate(agent);
        newAgent.transform.position = spawnPoints[Random.Range(0, spawnPoints.Count)].position;
        newAgent.transform.Rotate(0, 0, Random.Range(0, 360));
    }

}
