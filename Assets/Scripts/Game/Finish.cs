using UnityEngine;

public class Finish : MonoBehaviour
{
    private Game game;
    private void Awake()
    {
        game = FindObjectOfType<Game>();
    }
    private void OnTriggerEnter(Collider other)
    {
        other.gameObject.GetComponent<SnakeMove>().SnakeStop();
        game.OnPlayerFinish();
    }
}
