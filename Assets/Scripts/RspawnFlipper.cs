using UnityEngine;

public class RespawnFlipper : MonoBehaviour
{
    private float respawnTime = 3.5f;
    private bool isRespawning = false;

    private void OnDisable()
    {
        if (!gameObject.activeSelf && !isRespawning)
        {
            Invoke("Respawn", respawnTime);
            isRespawning = true;
        }
    }

    private void Respawn()
    {
        gameObject.SetActive(true);
        isRespawning = false;
    }
}
