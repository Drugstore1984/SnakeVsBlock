using System.Collections.Generic;
using UnityEngine;

public class SnakeTail : MonoBehaviour
{
    private List<Transform> _tails = new List<Transform>();
    private List<Vector3> positions = new List<Vector3>();
    [SerializeField] private GameObject _tailPrefab;
    [SerializeField] private float _snakeZOffset = 0.5f;
    [HideInInspector] public bool isDead { get; private set; } = false;
    private Game game;
    private void Start()
    {
        positions.Add(transform.position);
        game = FindObjectOfType<Game>();
    }
    private void Update()
    {
        TailsFollow();
    }
    public void GetTails(int recieveHealth)
    {
        for (int i = 0; i < recieveHealth; i++)
            AddTail();
    }
    public void RemoveTails(int reciveDamage)
    {
        if (TailsCount() > reciveDamage)
        {
            for (int i = 0; i < reciveDamage; i++)
                RemoveTail();
        }
        else
        {
            isDead = true;
            game.OnPlayerDied();
        }
    }
    private void AddTail()
    {
        Vector3 newtailPosition = positions[positions.Count - 1];
        Transform newTail = (Instantiate(_tailPrefab, newtailPosition, Quaternion.identity) as GameObject).transform;
        newTail.SetParent(transform);

        _tails.Add(newTail);
        positions.Add(newTail.position);
        PlayPartcle();
    }
    private void RemoveTail()
    {
        Transform lastTail = _tails[_tails.Count - 1];
        _tails.Remove(lastTail);
        positions.RemoveAt(1);
        lastTail.gameObject.GetComponent<TailDestroy>().Destroy();
        PlayPartcle();
    }
    private void TailsFollow()
    {
        float distance = (transform.position - positions[0]).magnitude;

        if (distance > _snakeZOffset)
        {
            Vector3 direction = (transform.position - positions[0]).normalized;

            positions.Insert(0, positions[0] + direction * _snakeZOffset);
            positions.RemoveAt(positions.Count - 1);

            distance -= _snakeZOffset;
        }

        for (int i = 0; i < _tails.Count; i++)
        {
            _tails[i].position = Vector3.Lerp(positions[i + 1], positions[i], distance / _snakeZOffset);

        }
    }
    public int TailsCount()
    {
        return _tails.Count;
    }
    private void PlayPartcle()
    {
        _tails[0].gameObject.GetComponent<TailDestroy>().PlayParticle();
    }
}
