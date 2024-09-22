using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using UnityEngine.Events;

public class UIButton : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerClickHandler
{
    Sprite normalImage;
    [SerializeField] Sprite hoverImage;
    [SerializeField] Sprite clickImage;
    [SerializeField] float clickTime = 0.2f;
    [SerializeField] UnityEvent onClick;

    bool entered;

    Image image;

    private void Awake()
    {
        image = GetComponent<Image>();
        normalImage = image.sprite;
        if (!hoverImage)
        {
            hoverImage = normalImage;
        }
        if (!clickImage)
        {
            clickImage = normalImage;
        }
    }
    public void OnPointerClick(PointerEventData eventData)
    {
        image.sprite = clickImage;
        StartCoroutine(WaitClick());
        Click();
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        entered = true;
        image.sprite = hoverImage;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        image.sprite = normalImage;
        entered = false;
    }

    IEnumerator WaitClick()
    {
        yield return new WaitForSeconds(clickTime);
        if (entered)
        {
            image.sprite = hoverImage;
        }
        else
        {
            image.sprite = normalImage;
        }
    }
    void Click()
    {
        if (onClick != null)
        {
            onClick.Invoke();
        }
    }
}
