using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LauncherController : MonoBehaviour
{
    public Collider bola;
    public KeyCode input;

    public float maxTimeHold;
    public float maxForce;

    public Color normalColor;   // Color when not pressed
    public Color pressedColor;  // Color when space is pressed

    private bool isHold = false;
    private Renderer launcherRenderer;

    private void Start()
    {
        launcherRenderer = GetComponent<Renderer>();
        launcherRenderer.material.color = normalColor; // Set initial color
    }

    private void OnCollisionStay(Collision collision)
    {
        if (collision.collider == bola)
        {
            ReadInput(bola);
        }
    }

    private void ReadInput(Collider collider)
    {
        if (Input.GetKey(input) && !isHold)
        {
            StartCoroutine(StartHold(collider));
        }
    }

    private IEnumerator StartHold(Collider collider)
    {
        isHold = true;

        float force = 0.0f;
        float timeHold = 0.0f;

        // Change color to "pressed" color
        launcherRenderer.material.color = pressedColor;

        while (Input.GetKey(input))
        {
            force = Mathf.Lerp(0, maxForce, timeHold / maxTimeHold);

            yield return new WaitForEndOfFrame();
            timeHold += Time.deltaTime;
        }

        collider.GetComponent<Rigidbody>().AddForce(Vector3.forward * force);

        // Change color back to "normal" color
        launcherRenderer.material.color = normalColor;

        isHold = false;
    }
}
