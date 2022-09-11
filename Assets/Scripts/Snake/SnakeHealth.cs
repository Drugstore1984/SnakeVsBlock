using UnityEngine;
using TMPro;

public class SnakeHealth : MonoBehaviour
{
    private SnakeMove snakeMove;
    private SnakeTail snakeTail;
    private int health;
    [SerializeField] private TextMeshPro _textMeshPro;

    private void Start()
    {
        snakeMove = GetComponent<SnakeMove>();
        snakeTail = GetComponent<SnakeTail>();
    }
    private void Update()
    {
        health = snakeTail.TailsCount();
        _textMeshPro.text = (health + 1).ToString();

        if (snakeTail.isDead)
        {
            snakeMove.SnakeStop();
        }
    }
}
