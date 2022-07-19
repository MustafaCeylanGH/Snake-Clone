using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaitController : MonoBehaviour
{
    [SerializeField] private float xMinBoundary, xMaxBoundary, yMinBoundary, yMaxBoundary;
    private SnakeController snakeController;


    private void Start()
    {
        snakeController = GameObject.FindObjectOfType<SnakeController>();
       RandomBaitPosition();
    }
    private void RandomBaitPosition()
    {
        float xPos = Random.Range(xMinBoundary, xMaxBoundary);
        float yPos = Random.Range(yMinBoundary, yMaxBoundary);
        transform.position = new Vector2(xPos, yPos);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "SnakeHead")
        {
            RandomBaitPosition();
            snakeController.CreateTail();
        }
    }


}
