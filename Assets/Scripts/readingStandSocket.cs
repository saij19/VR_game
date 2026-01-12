using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.XR.Interaction.Toolkit.Interactors;

public class ReadingStandSocket : MonoBehaviour
{
    private XRSocketInteractor socket;

    void Awake()
    {
        socket = GetComponent<XRSocketInteractor>();
    }

    void OnEnable()
    {
        socket.selectEntered.AddListener(OnBookPlaced);
        socket.selectExited.AddListener(OnBookRemoved);
    }

    void OnDisable()
    {
        socket.selectEntered.RemoveListener(OnBookPlaced);
        socket.selectExited.RemoveListener(OnBookRemoved);
    }

    private void OnBookPlaced(SelectEnterEventArgs args)
    {
        // The occupant is the newly placed book
        BookVisualSwitcher book = args.interactableObject.transform.GetComponent<BookVisualSwitcher>();
        if (book != null)
        {
            book.SetOpen(true); // Only open THIS one
        }
    }

    private void OnBookRemoved(SelectExitEventArgs args)
    {
        // The occupant is the removed book
        BookVisualSwitcher book = args.interactableObject.transform.GetComponent<BookVisualSwitcher>();
        if (book != null)
        {
            book.SetOpen(false); // Only close THIS one
        }
    }
}
