using UnityEngine;
using System.Collections;

public class CameraSwitcher : MonoBehaviour
{

    public Camera[] cameras;
    private void Start()
    {
        StartCoroutine(showDifferentCamera());
    }

    IEnumerator showDifferentCamera()
    {
        for (int i = 0; i < cameras.Length; i++)
        {
            cameras[i].enabled = true;
            yield return new WaitForSeconds(4);
        }

    }
}
