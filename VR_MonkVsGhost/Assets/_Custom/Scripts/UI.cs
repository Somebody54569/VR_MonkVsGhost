using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI : MonoBehaviour
{
    [SerializeField] private GameObject gameUI;
    // Start is called before the first frame update
    void Start()
    {
        gameUI.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (OVRInput.GetDown(OVRInput.RawButton.B))
        {
            gameUI.SetActive(true);
        }

        if (OVRInput.GetUp(OVRInput.RawButton.B))
        {
            gameUI.SetActive(false);
        }
    }
}
