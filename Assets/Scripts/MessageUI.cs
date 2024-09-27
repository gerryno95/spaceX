using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class MessageUI : MonoBehaviour
{
    RectTransform rectTransform;

    [SerializeField] float vel;
    [SerializeField] float fadeVel = 1f;
    [SerializeField] float messageTime = 2f;

    float alphaColor = 0f;
    float height = 0;
    bool isFadeIn = true;
    public bool Ended { get; private set; } = false;
    TextMeshProUGUI textPro;

    private void Awake()
    {
        rectTransform = GetComponent<RectTransform>();
        textPro = GetComponent<TextMeshProUGUI>();
    }

    void Start()
    {
        StartCoroutine(WaitAndFadeOut());
    }


    private void Update()
    {
        rectTransform.localPosition = Vector3.Lerp(rectTransform.localPosition
            , new Vector3(rectTransform.localPosition.x, height, rectTransform.localPosition.z)
            , vel * Time.deltaTime);

        Color col = textPro.color;
        float fadeVel = this.fadeVel;

        if (!isFadeIn)
        {
            fadeVel = -fadeVel;
        }
        alphaColor += fadeVel * Time.deltaTime;
        if (alphaColor > 1f)
        {
            alphaColor = 1f;
        }
        else if (alphaColor <= 0f)
        {
            alphaColor = 0f;
            if (!isFadeIn)
            {
                EndedF();
            }
        }
        col.a = alphaColor;
        textPro.color = col;

    }

    public void SetHeight(float h)
    {
        this.height = h;
    }
    public void FadeOut()
    {
        isFadeIn = false;
    }
    void EndedF()
    {
        Ended = true;
    }

    IEnumerator WaitAndFadeOut()
    {
        yield return new WaitForSeconds(messageTime);
        isFadeIn = false;
    }



}
