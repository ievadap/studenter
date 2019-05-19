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
    HitByPigeon
};

public class Player : MonoBehaviour
{
    public StreetVisualiser StreetNamer;
    public GameOverScreen GameOverScreen;
    public GameObject Curtains;
    public bool IsAlive = true;
    public bool HasBook = false;

    public static Player main;

    void Awake() {
        main = this;
    }

    void Start() {
        IsAlive = false;
        StartCoroutine(StartAfterDelay(2f));
    }

    IEnumerator StartAfterDelay(float delay) {
        yield return new WaitForSeconds(delay);
        gameObject.GetComponent<Timer>().Resume();
        Curtains.GetComponent<Animator>().SetTrigger("Open");
        IsAlive = true;
    }
    // Start is called before the first frame update
    public void Died() {

    }

    void OnCollisionEnter2D(Collision2D col)
    {
        Debug.Log(col.otherCollider.gameObject);
        if (col.gameObject.tag == "Car" || col.gameObject.tag == "Biker" || col.gameObject.tag == "Cat" || col.gameObject.tag == "Pigeon") {
            IsAlive = false;
            Camera.main.transform.parent = null;
            gameObject.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.None;
            // gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(Random.Range(0, 1f), Random.Range(0, 1f)) * 500f);
            gameObject.GetComponent<Rigidbody2D>().AddForce((transform.position - col.transform.position) * 500f);
            gameObject.GetComponent<Rigidbody2D>().AddTorque(Random.Range(-500f, 500f));
            gameObject.GetComponent<BoxCollider2D>().enabled = false;

            if (col.gameObject.tag == "Car") {
                StartCoroutine(ShowGameOverScreenAfterDelay(1f, GameOverType.HitByCar));
            } else if (col.gameObject.tag == "Biker") {
                StartCoroutine(ShowGameOverScreenAfterDelay(1f, GameOverType.HitByBiker));
            } else if (col.gameObject.tag == "Cat") {
                StartCoroutine(ShowGameOverScreenAfterDelay(1f, GameOverType.HitByCat));
            } else if (col.gameObject.tag == "Pigeon") {
                StartCoroutine(ShowGameOverScreenAfterDelay(1f, GameOverType.HitByPigeon));
            }
        }
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Book") {
            HasBook = true;
            gameObject.GetComponent<BookIndicator>().SetBook(true);
            Destroy(col.gameObject);
        } else if (col.gameObject.tag == "Finish") {
            if (HasBook) {
                LevelComplete();
                StartCoroutine(ShowGameOverScreenAfterDelay(0.1f, GameOverType.Success));
            } else {
                StartCoroutine(ShowGameOverScreenAfterDelay(0.1f, GameOverType.FinishWithoutBook));
            }

            Camera.main.GetComponent<CameraZoomout>().StartZoom();
        } else if (col.gameObject.tag == "Street") {
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
        gameObject.GetComponent<Timer>().Stop();
    }

    void ShowGameOverScreen(GameOverType type) {
        IsAlive = false;
        GameOverScreen.gameObject.SetActive(true);
        GameOverScreen.GetComponent<Animator>().SetTrigger("Appear");
        GameOverScreen.SetSprite(type);
        gameObject.GetComponent<Timer>().Stop();
    }

    public void RestartGame() {
        Application.LoadLevel(1);
    }

    public void LevelComplete() {
        PlayerPrefs.SetInt("Score", PlayerPrefs.GetInt("Score", 0) + (int)gameObject.GetComponent<Timer>().TimerCount);
        if (PlayerPrefs.GetInt("Highscore", 0) < PlayerPrefs.GetInt("Score", 0)) {
            PlayerPrefs.SetInt("Highscore", PlayerPrefs.GetInt("Score", 0));
        }
    }
}
