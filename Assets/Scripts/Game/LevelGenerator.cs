using UnityEngine;

public class LevelGenerator : MonoBehaviour
{
    [SerializeField] private GameObject _startPlatform;
    [SerializeField] private GameObject[] _levelPlatform;
    [SerializeField] private GameObject _finishPlatform;
    private GameObject levelParent;
    private ProgressBar progressBar;
    private void SpawnPlatform(GameObject prefab)
    {
        GameObject temp = Instantiate(prefab, transform.position, Quaternion.Euler(0, -90, 0));
        transform.position = temp.transform.GetChild(0).transform.position;
        temp.transform.parent = levelParent.transform;
    }
    private GameObject RandomPlatform()
    {
        int random = Random.Range(0, _levelPlatform.Length);
        return _levelPlatform[random];

    }
    public void GenerateLevel(int levelLength)
    {
        levelParent = new GameObject("Level");
        levelParent.AddComponent<Level>();
        SpawnPlatform(_startPlatform);

        for (int i = 0; i < levelLength; i++)
        {
            SpawnPlatform(RandomPlatform());
        }

        SpawnPlatform(_finishPlatform);

        GetProgressBar();
    }
    private void GetProgressBar()
    {
        progressBar = FindObjectOfType<ProgressBar>();
        progressBar.SetProgressBarParameters();
    }

}
