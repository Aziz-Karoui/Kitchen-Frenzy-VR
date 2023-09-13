using UnityEngine;
using TMPro;
using System.IO;

public class Timer : MonoBehaviour
{
    public float totalTime = 60f;

    public TextMeshProUGUI timerText;
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI highScoreText;

    public GameObject StartArea;
    public GameObject player;
    public GameObject gameOver;
    public GameObject youWin;

    public GameObject burgerTop;
    public GameObject burgerBottom;
    public GameObject burgerKhass;
    public GameObject burgerHam;
    public GameObject burgerSlice;
    public Material burgerMaterial;
    public Material burgerMaterial2;
    public Material initialBurgerMaterial;

    private bool isRunning = false;
    private bool booler = false;
    private float timeRemaining;

    private Collider cubeCollider;
    private bool timer = false;
    private float highScore;

    private string highScoreFilePath; 

    private void Start()
    {
        timeRemaining = totalTime;
        timerText.SetText(FormatTime(timeRemaining));
        cubeCollider = StartArea.GetComponent<Collider>();
        burgerBottom.GetComponent<MeshRenderer>().material = initialBurgerMaterial;

        highScoreFilePath = Path.Combine(Application.persistentDataPath, "highscore.txt");

        LoadHighScore();
    }

    private void OnTriggerEnter(Collider thisObjectCollider)
    {
        if (thisObjectCollider == cubeCollider)
        {
            StartTimer();
            StartArea.SetActive(false);
            booler = true;
        }
    }

    private void Update()
    {
        if (isRunning)
        {
            timeRemaining -= Time.deltaTime;
            timerText.text = FormatTime(timeRemaining);

            if (timeRemaining <= 0f)
            {
                StopTimer();
                player.transform.position = new Vector3(5f, 0f, 3f);

                if (burgerBottom.transform.IsChildOf(burgerHam.transform) &&
                    burgerHam.transform.IsChildOf(burgerSlice.transform) &&
                    burgerSlice.transform.IsChildOf(burgerKhass.transform) &&
                    burgerKhass.transform.IsChildOf(burgerTop.transform) &&
                    burgerBottom.GetComponent<MeshRenderer>().material != initialBurgerMaterial)
                {
                    youWin.SetActive(true);
                }
                else
                {
                    gameOver.SetActive(true);
                }
            }
        }

        

        if (timer == false)
        {
            if (burgerBottom.transform.IsChildOf(burgerHam.transform) &&
                burgerHam.transform.IsChildOf(burgerSlice.transform) &&
                burgerSlice.transform.IsChildOf(burgerKhass.transform) &&
                burgerKhass.transform.IsChildOf(burgerTop.transform) &&
                burgerBottom.GetComponent<MeshRenderer>().material.name == "Bread3 (Instance)")
            {
                StopTimer();
                timer = true;
                youWin.SetActive(true);
                scoreText.text = FormatTime(timeRemaining);
                
                if (timeRemaining > highScore)
                {
                    highScore = timeRemaining;
                    highScoreText.text = FormatTime(highScore);

                    SaveHighScore();
                }
            }
        }

        if (booler == true)
        {
            StartTimer();
        }
    }

    private void StartTimer()
    {
        isRunning = true;
    }

    private void StopTimer()
    {
        isRunning = false;
    }

    private string FormatTime(float time)
    {
        int minutes = Mathf.FloorToInt(time / 60f);
        int seconds = Mathf.FloorToInt(time % 60f);

        return string.Format("{0:00}:{1:00}", minutes, seconds);
    }

    private void SaveHighScore()
    {
        using (StreamWriter writer = new StreamWriter(highScoreFilePath, false))
        {
            writer.Write(highScore.ToString());
        }
    }

    private void LoadHighScore()
    {
        if (File.Exists(highScoreFilePath))
        {
            string scoreString = File.ReadAllText(highScoreFilePath);
            if (float.TryParse(scoreString, out float loadedHighScore))
            {
                highScore = loadedHighScore;
                highScoreText.text = FormatTime(highScore);
            }
        }
    }
}
