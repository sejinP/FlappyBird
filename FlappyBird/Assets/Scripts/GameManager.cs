using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private static GameManager instance;
    public GameObject prefab;
    public Animator an;
    public Text textScore;
    public Text gameOverScore;
    public Text textBestScore;
    public GameObject gameOverMenu;
    public float delayTime;
    public bool isOver = false;

    public int score = 0;
    public int bestScore = 0;

    public static GameManager GetInstance()
    {
        if(instance == null) instance = FindObjectOfType<GameManager>();
        if(instance == null)
        {
            GameObject container = new GameObject("GameManager");
            instance = container.AddComponent<GameManager>();
        }
        return instance;
    }
    void Start()
    {
        StartCoroutine(CreatePipe());
        bestScore = PlayerPrefs.GetInt("bestscore", bestScore);
    }

    void Update()
    {
        if(isOver) an.speed = 0f;
        textScore.text = score.ToString();
        gameOverScore.text = score.ToString();
        textBestScore.text = bestScore.ToString();
        PlayerPrefs.SetInt("bestscore", bestScore);
    }

    IEnumerator CreatePipe()
    {
        float randomY = Random.Range(-2, 3);
        Vector2 position = new Vector2(10, randomY);
        Instantiate(prefab, position, Quaternion.identity);
        yield return new WaitForSeconds(delayTime);
        if(!isOver) StartCoroutine(CreatePipe());
    }

    public void StartButton()
    {
        SceneManager.LoadScene("Main");
    }
}
