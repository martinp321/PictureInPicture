using UnityEngine;
using System.Collections;

public class PictureInPicture : MonoBehaviour
{
    public enum Halign { left, center, right };
    public enum Valign { top, middle, bottom };
    public Halign halign = Halign.left;
    public Valign valign = Valign.top;

    public int width = 50;
    public int height = 50;
    public float xOffset = 0f;
    public float yOffset = 0f;

    public bool update = true;
    private int hsize, vsize, hloc, vloc;

    private void Start()
    {
        AdjustCamera();
    }

    private void Update()
    {
        if (update) AdjustCamera();
    }


    void AdjustCamera()
    {
        hsize = Mathf.RoundToInt(width * 0.01f * Screen.width);
        vsize = Mathf.RoundToInt(height * 0.01f * Screen.height);

        setHorizontalLocation();
        setVerticalLocation();

        Camera camera = GetComponent<Camera>();
        camera.pixelRect = new Rect(hloc, vloc, hsize, vsize);
    }

    private void setVerticalLocation()
    {
        switch (valign)
        {
            case Valign.top:
                vloc = Mathf.RoundToInt((Screen.height - vsize) - (yOffset * .01f * Screen.height));
                break;

            case Valign.bottom:
                vloc = Mathf.RoundToInt(yOffset * .01f * Screen.height);
                break;

            case Valign.middle:
                vloc = Mathf.RoundToInt(((Screen.height * .5f) - (vsize * .5f)) - (yOffset * .01f * Screen.height));
                break;
        }
    }

    private void setHorizontalLocation()
    {
        switch (halign)
        {
            case Halign.left:
                hloc = Mathf.RoundToInt(xOffset * 0.01f * Screen.width);
                break;

            case Halign.right:
                hloc = Mathf.RoundToInt((Screen.width - hsize) - (xOffset * 0.01f * Screen.width));
                break;

            case Halign.center:
                hloc = Mathf.RoundToInt(((Screen.width * 0.5f) - (hsize * 0.5f)) - (xOffset * 0.01f * Screen.height));
                break;
        }
    }
}
