using UnityEngine;

public class BoilerRespawner : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        // check if the entering object is respawnable
        RespawnableObject respawnable = other.GetComponent<RespawnableObject>();
        if (respawnable != null)
        {
            // make it disappear from the boiler and reappear at its original spot
            respawnable.Respawn();
        }
    }
}
