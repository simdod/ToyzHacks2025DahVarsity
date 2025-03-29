using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine;
using System.Collections;

public class TeleportBack : MonoBehaviour
{
    public GameObject teleportEffect; // Assign a teleport effect prefab
    public float teleportCooldown = 2f; // Cooldown before teleporting again
    private Vector3 lastTeleportPosition; // Stores last teleport location
    private bool canTeleport = true;

    void Start()
    {
        lastTeleportPosition = transform.position; // Save starting position
    }

    void Update()
    {
        // Save new position when teleporting forward
        if (Input.GetKeyDown(KeyCode.T) && canTeleport)
        {
            StartCoroutine(TeleportForward());
        }

        // Return to last teleport location
        if (Input.GetKeyDown(KeyCode.R) && canTeleport)
        {
            StartCoroutine(TeleportBackToLastPosition());
        }
    }

    IEnumerator TeleportForward()
    {
        canTeleport = false;

        // Save current position before teleporting
        lastTeleportPosition = transform.position;

        if (teleportEffect)
            Instantiate(teleportEffect, transform.position, Quaternion.identity);

        GetComponent<CharacterController>().enabled = false;
        yield return new WaitForSeconds(0.2f); // Short delay

        // Move player forward
        Vector3 newPosition = transform.position + transform.forward * 10f;
        transform.position = newPosition;

        if (teleportEffect)
            Instantiate(teleportEffect, transform.position, Quaternion.identity);

        GetComponent<CharacterController>().enabled = true;
        yield return new WaitForSeconds(teleportCooldown);
        canTeleport = true;
    }

    IEnumerator TeleportBackToLastPosition()
    {
        canTeleport = false;

        if (teleportEffect)
            Instantiate(teleportEffect, transform.position, Quaternion.identity);

        GetComponent<CharacterController>().enabled = false;
        yield return new WaitForSeconds(0.2f);

        // Move player back to last saved position
        transform.position = lastTeleportPosition;

        if (teleportEffect)
            Instantiate(teleportEffect, transform.position, Quaternion.identity);

        GetComponent<CharacterController>().enabled = true;
        yield return new WaitForSeconds(teleportCooldown);
        canTeleport = true;
    }
}

