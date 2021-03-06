using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Agent : MonoBehaviour
{
    [SerializeField] private float agentSpeed;
    [SerializeField] private int healthPoint;
    public int HealtPoint => healthPoint;

    private void Awake()
    {
        healthPoint = 3;
    }

    private void Update()
    {
        transform.Translate(Vector3.up * agentSpeed * Time.deltaTime);
        CheckAgentCondition();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Wall"))
        {
            transform.Rotate(0, 0, 180);
        }

        if (collision.gameObject.CompareTag("Player"))
        {
            transform.Rotate(0, 0, 180);
            healthPoint -= 1;
        }
    }

    public void CheckAgentCondition()
    {
        if (healthPoint <= 0)
        {
            Destroy(gameObject);
        }
    }
}
