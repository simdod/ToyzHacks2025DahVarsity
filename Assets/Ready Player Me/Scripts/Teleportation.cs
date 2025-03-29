using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleportAbility : MonoBehaviour
{
    public float teleportDistance = 10f; // Distance to teleport forward
    public GameObject teleportEffect; // Assign a teleport particle effect
    public float teleportCooldown = 2f; // Cooldown between teleports
    private bool canTeleport = true;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.T) && canTeleport) // Press 'T' to teleport
        {
            StartCoroutine(Teleport());
        }
    }

    IEnumerator Teleport()
    {
        canTeleport = false; // Prevent teleport spamming

        // Play teleport effect at the current position
        if (teleportEffect)
        {
            Instantiate(teleportEffect, transform.position, Quaternion.identity);
        }

        // Hide player before teleporting
        GetComponent<CharacterController>().enabled = false; // Disable movement briefly

        yield return new WaitForSeconds(0.3f); // Short delay for effect

        // Calculate new position
        Vector3 teleportDirection = transform.forward * teleportDistance;
        Vector3 newPosition = transform.position + teleportDirection;

        // Check for obstacles using a Raycast
        if (!Physics.Raycast(transform.position, transform.forward, teleportDistance))
        {
            transform.position = newPosition;
        }

        // Play teleport effect at the new position
        if (teleportEffect)
        {
            Instantiate(teleportEffect, transform.position, Quaternion.identity);
        }

        // Re-enable movement
        GetComponent<CharacterController>().enabled = true;

        // Cooldown
        yield return new WaitForSeconds(teleportCooldown);
        canTeleport = true;
    }
}

