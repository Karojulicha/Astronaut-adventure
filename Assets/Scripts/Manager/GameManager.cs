using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class GameManager : MonoBehaviour
{
    public static GameManager instance { get; private set; }

    private GameObject PlayButton;
    private GameObject RestartButton;
    public GameObject PanelMenuRestart;
    private bool isPaused = false;

    private void Awake()
    {
        // Asegúrate de que solo haya una instancia del GameManager
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject); // No destruye el GameManager al cargar una nueva escena
        }
        else
        {
            Destroy(gameObject); // Si ya existe una instancia, destruye esta
        }
    }

    private void Start()
    {
        PanelMenuRestart.SetActive(false);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.P) || Input.GetKeyDown(KeyCode.Escape))
        {
            if (isPaused)
            {
                RestartGame();
            }
            else
            {
                PauseGame();
            }
        }
    }
    private void OnEnable()
    {
        // Suscribirse al evento cuando se carga una nueva escena
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    private void OnDisable()
    {
        // Desuscribirse del evento cuando el objeto se desactiva
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        // Solo configuramos los botones cuando se carga el menú o el juego
        if (scene.name == "MenuInitial")
        {
            PlayButton = GameObject.Find("PlayButton");
            RestartButton = GameObject.Find("RestartGameButton");
        }
    }

    public void Play()
    {
        SceneManager.LoadScene("GameFirstScene");
    }

    public void Exit()
    {
        Application.Quit();
    }

    public void PauseGame()
    {
        PanelMenuRestart.SetActive(true);
        Time.timeScale = 0;
        isPaused = true;
    }

    public void RestartGame()
    {
        PanelMenuRestart.SetActive(false);
        Time.timeScale = 1;
        isPaused = false;
    }

    public IEnumerator TimeShow()
    {
        yield return new WaitForSeconds(10f);
    }
    public void WinGame()
    {
        StartCoroutine(TimeShow());
        GameOver();
    }

    public void LoseGame()
    {
        GameOver();
    }

    public void GameOver()
    {
        SceneManager.LoadScene("MenuInitial");
    }
}
