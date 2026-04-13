using UnityEngine;

public class PortalIdle : MonoBehaviour
{
    private Animator myAnimator;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        myAnimator = GetComponent<Animator>();

        myAnimator.SetBool("Portal", true);

    }
}