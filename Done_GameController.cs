using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
using UnityEngine.UI;

public class Done_GameController : MonoBehaviour
{
    public GameObject[] hazards;
    public GameObject[] hazardsHard;
    public Vector3 spawnValues;
    public int hazardCount;
    public float spawnWait;
    public float startWait;
    public float waveWait;

    public bool ModeHard;

    public Text scoreText;
    public Text restartText;
    public Text gameOverText;
    public Text winText;
    public Text hectic;

    private bool gameOver;
    private bool restart;
    private int score;

    public Done_BGScroller bgscroller;

    public GameObject starfield;
    public AudioSource gameControllerMusic;
    public AudioClip winSong;
    public AudioClip loseSong;


    void Start()
    {
        gameOver = false;
        restart = false;
        restartText.text = "";
        gameOverText.text = "";
        winText.text = "";
        score = 0;
        UpdateScore();
        StartCoroutine(SpawnWaves());
        hectic.text = "Press H for hectic";
    }
    private void FixedUpdate()
    {
        if (Input.GetKey("escape"))
            Application.Quit();
    }

    void Update()
    {

        if (Input.GetKeyDown(KeyCode.H))
        {
            ModeHard = true;
            hectic.text = "HECTIC!";
        }

        if (restart)
        {
            if (Input.GetKeyDown(KeyCode.Q))
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            }
        }
    }

    IEnumerator SpawnWaves()
    {

        yield return new WaitForSeconds(startWait);
        while (true)
        {
            for (int i = 0; i < hazardCount; i++)
            {
                GameObject hazard;
                if (ModeHard)
                {
                    hazard = hazardsHard[Random.Range(0, hazardsHard.Length)];
                } else
                {
                    hazard = hazards[Random.Range(0, hazards.Length)];
                }       

                Vector3 spawnPosition = new Vector3(Random.Range(-spawnValues.x, spawnValues.x), spawnValues.y, spawnValues.z);
                Quaternion spawnRotation = Quaternion.identity;
                Instantiate(hazard, spawnPosition, spawnRotation);
                yield return new WaitForSeconds(spawnWait);
            }
            yield return new WaitForSeconds(waveWait);

            if (gameOver)
            {
                restartText.text = "Press 'Q' for Restart";
                restart = true;
                break;
            }
        }



    }

    public void AddScore(int newScoreValue)
    {
        score += newScoreValue;
        UpdateScore();
    }

    void UpdateScore()
    {
        scoreText.text = "Points: " + score;
        if (score >= 100 )
        {
            gameWon();
            gameOver = true;
            restart = true;
        }
    }

    public void gameWon()
    {
        winText.text = "Success!!! Made by Os";
            starfield.SetActive(true);
            gameControllerMusic.clip = winSong;
            gameControllerMusic.Play();
            bgscroller.scrollSpeed = -10f;
    }

    public void GameOver()
    {
        gameOverText.text = "Game Over!";
        gameOver = true;
        gameControllerMusic.clip = loseSong;
        gameControllerMusic.Play();

    }
}
