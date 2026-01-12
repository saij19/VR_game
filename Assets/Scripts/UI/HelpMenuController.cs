using UnityEngine;
using UnityEngine.XR;
using UnityEngine.XR.Interaction.Toolkit.Interactors;

public class HelpMenuController : MonoBehaviour
{
    public Canvas menuCanvas;
    public XRRayInteractor UIRayLeft;
    public XRRayInteractor UIRayRight;
    public XRDirectInteractor DirectLeft;
    public XRDirectInteractor DirectRight;

    bool menuOpen;

    public void Start()
    {
        menuOpen = false;
        UIRayLeft.gameObject.SetActive(false);
        UIRayRight.gameObject.SetActive(false);
        DirectLeft.gameObject.SetActive(true);
        DirectRight.gameObject.SetActive(true);
    }

    public void ToggleMenu()
    {
        Debug.Log("AAAAAAA - Help Button Pressed");
        menuOpen = !menuOpen;
        menuCanvas.gameObject.SetActive(!menuCanvas.gameObject.activeSelf); 

        UIRayLeft.gameObject.SetActive(menuOpen);
        UIRayRight.gameObject.SetActive(menuOpen);

        DirectLeft.gameObject.SetActive(!menuOpen);
        DirectRight.gameObject.SetActive(!menuOpen);

        if (menuOpen)
        {
            UIRayLeft.maxRaycastDistance = 2f;
            UIRayRight.maxRaycastDistance = 10f;
        }
        
    }
}