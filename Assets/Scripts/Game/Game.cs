using UnityEngine;
using TMPro;

public class Game : MonoBehaviour
{
    [SerializeField] private GameObject _lostMenu;
    [SerializeField] private GameObject _wonMenu;
    [SerializeField] private int _startLevelLength = 5;
    private LevelGenerator generator;
    [SerializeField] private TextMeshProUGUI _currentLevel,_nextLevel;
    private AudioPlayer _player;
    public enum State
    {
        Playing,
        Won,
        Loss
    }
    public State CurrentState { get; private set; }
    private void Start()
    {
        generator = FindObjectOfType<LevelGenerator>();
        _player = FindObjectOfType<AudioPlayer>();
    }
    public void OnPlayerDied()
    {
        if (CurrentState != State.Playing) return;

        CurrentState = State.Loss;
        _lostMenu.SetActive(true);
    }
    public void OnPlayerFinish()
    {
        if (CurrentState != State.Playing) return;

        CurrentState = State.Won;
        _wonMenu.SetActive(true);
        LevelIndex++;
        _player.Play("Finish");
    }
    public int LevelIndex
    {
        get => PlayerPrefs.GetInt(LevelIndexString, 0);
        set
        {
            PlayerPrefs.SetInt(LevelIndexString,value);
            PlayerPrefs.Save();
        }
    }
    private const string LevelIndexString = "LevelIndex";
    public void DeleteCurrentLevel()
    {
        Level currentLevel = FindObjectOfType<Level>();
        Destroy(currentLevel.gameObject);
        CurrentState = State.Playing;
    }
    public void GenerateNewLevel()
    {
        generator.GenerateLevel(_startLevelLength + LevelIndex / 2);
        LevelText();
    }
    private void LevelText()
    {
        _currentLevel.text = (LevelIndex + 1).ToString();
        _nextLevel.text = (LevelIndex + 2).ToString();
    }
}
