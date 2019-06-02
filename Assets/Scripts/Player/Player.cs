using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum GameOverType {
    Success,
    Timer,
    FinishWithoutBook,
    HitByCar,
    HitByBiker,
    HitByCat,
    HitByPidgeon
};

public class Player : MonoBehaviour
{
    public StreetVisualiser StreetNamer;
    public GameObject Curtains;
    public Timer timer;
    public GameOverScreen GameOverScreen;
    public BookIndicator bookIndicator;

    public bool IsAlive = true;
    public bool HasBook = false;

    public static Player instance;

    void Awake() {
        instance = this;
    }

    void Start() {
        IsAlive = false;
        StartCoroutine(StartAfterDelay(2f));
    }

    IEnumerator StartAfterDelay(float delay) {
        yield return new WaitForSeconds(delay);
        timer.Resume();
        Curtains.GetComponent<Animator>().SetTrigger("Open");
        IsAlive = true;
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "Car" || col.gameObject.tag == "Biker" || col.gameObject.tag == "Cat" || col.gameObject.tag == "Pigeon") {

            IsAlive = false;
            Camera.main.transform.parent = null;

            gameObject.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.None;
            gameObject.GetComponent<Rigidbody2D>().AddForce((transform.position - col.transform.position) * 500f);
            gameObject.GetComponent<Rigidbody2D>().AddTorque(Random.Range(-500f, 500f));

            gameObject.GetComponent<BoxCollider2D>().enabled = false;

            switch (col.gameObject.tag)
            {
                case "Car":
                    StartCoroutine(ShowGameOverScreenAfterDelay(1f, GameOverType.HitByCar));
                    break;
                case "Biker":
                    StartCoroutine(ShowGameOverScreenAfterDelay(1f, GameOverType.HitByBiker));
                    break;
                case "Cat":
                    StartCoroutine(ShowGameOverScreenAfterDelay(1f, GameOverType.HitByCat));
                    break;
                case "Pigeon":
                    StartCoroutine(ShowGameOverScreenAfterDelay(1f, GameOverType.HitByPidgeon));
                    break;
            }
        }
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Book")
        {
            HasBook = true;
            bookIndicator.SetBook(true);
            Destroy(col.gameObject);
        }
        else if (col.gameObject.tag == "Finish")
        {
            if (HasBook)
            {
                LevelComplete();
                StartCoroutine(ShowGameOverScreenAfterDelay(0.1f, GameOverType.Success));
            }
            else
            {
                StartCoroutine(ShowGameOverScreenAfterDelay(0.1f, GameOverType.FinishWithoutBook));
            }

            Camera.main.GetComponent<CameraZoomout>().StartZoom();
        }
        else if (col.gameObject.tag == "Street")
        {
            StreetNamer.ShowStreet(col.gameObject.name);
        }
    }

    public void TimerDone() {
        StartCoroutine(ShowGameOverScreenAfterDelay(0.1f, GameOverType.Timer));
    }

    IEnumerator ShowGameOverScreenAfterDelay(float delay, GameOverType type) {
        IsAlive = false;
        yield return new WaitForSeconds(delay);
        ShowGameOverScreen(type);
    }

    void ShowGameOverScreen(GameOverType type) {
        IsAlive = false;
        GameOverScreen.gameObject.SetActive(true);
        GameOverScreen.GetComponent<Animator>().SetTrigger("Appear");
        GameOverScreen.SetSprite(type);
        timer.Stop();
    }

    public void RestartGame() {
        UnityEngine.SceneManagement.SceneManager.LoadScene(1);
    }

    public void LevelComplete() {

        PlayerPrefs.SetInt("Score", (int)timer.TimerCount);

        if (PlayerPrefs.GetInt("Highscore", 0) < PlayerPrefs.GetInt("Score", 0)) {
            PlayerPrefs.SetInt("Highscore", PlayerPrefs.GetInt("Score", 0));
        }
    }
}
