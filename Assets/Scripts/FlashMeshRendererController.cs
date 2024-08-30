using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlashMeshRendererController : MonoBehaviour
{
    [ColorUsage(false,true)][SerializeField] Color flashColor;
    [SerializeField] float flashVel = 10f;
    [SerializeField] MeshRenderer[] renderers;
    Color[] startColors;

    float flashValue = 0f;

    

    // Start is called before the first frame update
    void Start()
    {
        startColors = new Color[renderers.Length];
        int i = 0;
        foreach (MeshRenderer rend in renderers)
        {
            startColors[i] = rend.material.GetColor("_EmissionColor");
            i++;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (flashValue > 0f)
        {
            flashValue -= Time.deltaTime * flashVel;
            for (int i = 0; i < renderers.Length; i++) {
                renderers[i].material.SetColor("_EmissionColor",Color.Lerp(startColors[i], flashColor, flashValue));
            }
        }
        if (flashVel < 0f)
        {
            flashVel = 0f;
            for (int i = 0; i < renderers.Length; i++)
            {
                renderers[i].material.SetColor("_EmissionColor",Color.Lerp(startColors[i], flashColor, flashValue));
            }
        }

    }

    public void Flash()
    {
        flashValue = 1f;
    }
}
