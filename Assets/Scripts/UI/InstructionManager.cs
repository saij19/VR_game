using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class UIPanelController : MonoBehaviour
{
    public GameObject welcomePanel;
    public GameObject instruction1Panel;
    public GameObject instruction2Panel;
    public GameObject finalPanel;
    public GameObject finalDoor;
    public InputActionProperty aButtonAction;
    public InputActionProperty bButtonAction;

    private float welcomeTimer = 120f;
    private int state = 0;

    void OnEnable()
    {
        aButtonAction.action.Enable();
        bButtonAction.action.Enable();
    }

    void OnDisable()
    {
        aButtonAction.action.Disable();
        bButtonAction.action.Disable();
    }

    void Start()
    {
        welcomePanel.SetActive(true);
        instruction1Panel.SetActive(false);
        instruction2Panel.SetActive(false);
        finalPanel.SetActive(false);

    }

    void Update()
    {
        bool aPressed = aButtonAction.action.WasPressedThisFrame();
        bool bPressed = bButtonAction.action.WasPressedThisFrame();

        if (state == 0)
        {
            welcomeTimer -= Time.deltaTime;
            if (aPressed || welcomeTimer <= 0f)
            {
                welcomePanel.SetActive(false);
                instruction1Panel.SetActive(true);
                state = 1;
            }
        }
        else if (state == 1 && aPressed)
        {
            instruction1Panel.SetActive(false);
            instruction2Panel.SetActive(true);
            state = 2;
        }
        else if (state == 2 && aPressed)
        {
            instruction2Panel.SetActive(false);
            finalPanel.SetActive(true);
            state = 3;
        }
        else if (state == 3 && aPressed && !finalDoor.activeSelf)
        {
            finalPanel.SetActive(false);
            state = -1;
        } 
        else if (state == 3 && bPressed && !finalDoor.activeSelf)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            state = 0;

        }
    }
}

