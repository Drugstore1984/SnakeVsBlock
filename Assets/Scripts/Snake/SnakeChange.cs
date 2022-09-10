using UnityEngine;
using UnityEngine.Audio;

public class SnakeChange : MonoBehaviour
{
    private SnakeTail snakeTail;
    private AudioPlayer player;
    private void Start()
    {
        snakeTail = GetComponent<SnakeTail>();
        player = FindObjectOfType<AudioPlayer>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponentInChildren<Health>())
        {
            int recivedHealth = other.gameObject.GetComponentInChildren<Health>().health;

            snakeTail.GetTails(recivedHealth);
            player.Play("Health");
        }
        else if (other.gameObject.GetComponentInChildren<Block>())
        {
            int recivedDamage = other.gameObject.GetComponentInChildren<Block>().damage;

            snakeTail.RemoveTails(recivedDamage);
            player.Play("Block");
        }
    }
}
