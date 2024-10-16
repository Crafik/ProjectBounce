using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameManagerSingleton : MonoBehaviour
{
    public static GameManagerSingleton instance { get; private set; }

    [SerializeField] private LevelList _levelList;
    private int _levelNum;

    private GameObject _currentLevel;

    [SerializeField] private GameObject _bouncerPrefab;
    [SerializeField] private Transform _ballSpawnpoint;
    private GameObject _ball;

    [SerializeField] private GameObject _UI;
    [SerializeField] private TextMeshProUGUI _playButtonText;
    [SerializeField] private TextMeshProUGUI _levelCompleteText;

    void Awake(){
        if (instance != null && instance != this){
            Destroy(instance);
        }
        else{
            instance = this;
        }
    }

    void OnEnable(){
        BouncerFinish.LevelFinished += EndLevel;
        BouncerDestruction.PlayerDeath += PlayerDeath;
    }

    void OnDisable(){
        BouncerFinish.LevelFinished -= EndLevel;
        BouncerDestruction.PlayerDeath -= PlayerDeath;
    }

    void Start(){
        _levelNum = 0;
        StartLevel();
    }

    public void StartLevel(){
        if (_currentLevel != null){
            Destroy(_currentLevel);
        }
        _currentLevel = Instantiate(_levelList.Levels[_levelNum], Vector3.zero, Quaternion.identity);

        if (_ball != null){
            Destroy(_ball);
        }
        _ball = Instantiate(_bouncerPrefab, _ballSpawnpoint.position, Quaternion.identity);

        _UI.SetActive(false);
    }

    private void EndLevel(){
        _UI.SetActive(true);
        _levelNum += 1;

        _levelCompleteText.text = "Level complete";
        _playButtonText.text = "Next level";

        if (_levelNum == _levelList.Levels.Count){
            _UI.transform.GetChild(0).gameObject.SetActive(false);
            _levelCompleteText.text = "Congratulations";
        }
    }

    private void PlayerDeath(){
        _UI.SetActive(true);
        _levelCompleteText.text = "You lost";
        _playButtonText.text = "Restart";
    }
}
