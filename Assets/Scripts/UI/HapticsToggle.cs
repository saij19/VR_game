using UnityEngine;
using UnityEngine.XR;
using UnityEngine.XR.Interaction.Toolkit.Feedback;

public class HapticsToggle : MonoBehaviour
{
    
    public GameObject directLeft;
    public GameObject directRight;

    public void setHaptics()
    {
        
        if (directLeft.GetComponent<SimpleHapticFeedback>().enabled && directRight.GetComponent<SimpleHapticFeedback>().enabled)
        {
            directLeft.GetComponent<SimpleHapticFeedback>().enabled = false;
            directRight.GetComponent<SimpleHapticFeedback>().enabled = false;
        }
        else
        {
            directLeft.GetComponent<SimpleHapticFeedback>().enabled = true;
            directRight.GetComponent<SimpleHapticFeedback>().enabled = true;
        }
    }
}
