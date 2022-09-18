using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    [SerializeField] GameObject BG;
    [SerializeField] GameObject BG2;
    [SerializeField] GameObject Ui;
    [SerializeField] GameObject menuButton;
    [SerializeField] private float fadeTime = 1;
    [SerializeField] private CanvasGroup canvasGroup;
    [SerializeField] RectTransform rectTransform;
    [SerializeField] List<GameObject> button = new List<GameObject>();

    int a;

    private void Start()
    {
        if (SceneManager.GetActiveScene().name.Contains("Game"))
        {
            menuButton.SetActive(true);
        }
        if (SceneManager.GetActiveScene().name.Contains("Menu"))
        {
            menuButton.SetActive(false);
        }
        menuButton.SetActive(false);
        //BG.GetComponent<CanvasGroup>().alpha = 1;
        BG2.GetComponent<CanvasGroup>().alpha = 0;
        StartCoroutine("Buttons");
    }
    public void PanelFadeIn()
    {
        BG2.GetComponent<CanvasGroup>().alpha = 1;
        //BG2.transform.DOScale(1f, 0.2f).SetEase(Ease.OutFlash);
        //BG.GetComponent<CanvasGroup>().alpha = 0;
        //
        canvasGroup.alpha = 0;

        rectTransform.transform.localPosition = new Vector3(0, -1000, 0);

        rectTransform.DOAnchorPos(new Vector2(0, 70), fadeTime, false).SetEase(Ease.OutElastic);

       

        canvasGroup.DOFade(1, fadeTime);

        StartCoroutine("ButtonsOut");

    }

    public void PanelFadeOut()
    {
       
       // BG2.transform.DOScale(1f, 0.2f).SetEase(Ease.InFlash);
        // BG.GetComponent<CanvasGroup>().alpha = 1;
       // BG2.GetComponent<CanvasGroup>().alpha = 0;
        canvasGroup.alpha = 1f;
        rectTransform.transform.localPosition = new Vector3(0, 0, 0);
        
        rectTransform.DOAnchorPos(new Vector2(0, -1000f), fadeTime, false).SetEase(Ease.InOutQuint);
        canvasGroup.DOFade(0, fadeTime);
        StartCoroutine("Buttons");
    }

    

    IEnumerator Buttons()
    {

        foreach (var item in button)
        {
            item.transform.localScale = Vector3.zero;
        }
        foreach (var item in button)
        {
            item.transform.DOScale(1f, 0.5f).SetEase(Ease.OutBounce);
            BG.transform.DOScale(1f, 0.5f).SetEase(Ease.OutFlash);
            BG2.transform.DOScale(0f, 0.1f).SetEase(Ease.InFlash);
            yield return new WaitForSeconds(0.25f);
        }

    }
    IEnumerator ButtonsOut()
    {
        foreach (var item in button)
        {
            item.transform.DOScale(0f, 0.5f).SetEase(Ease.InBounce);
            BG.transform.DOScale(0f, 0.1f).SetEase(Ease.InFlash);
            BG2.transform.DOScale(1f, 0.5f).SetEase(Ease.OutFlash);

            yield return new WaitForSeconds(0.2f);
        }

    }

    public void FullscreenButton()
    {
        
        if (Screen.fullScreen == false)
        {
            
            Screen.fullScreen = true;

        }
        else
        {
            
            Screen.fullScreen = false;
        }
       
    }

    public void PlayButton()
    {
        if (SceneManager.GetActiveScene().name.Contains("Game"))
        {
            menuButton.GetComponent<CanvasGroup>().alpha = 1f;
            Ui.GetComponent<CanvasGroup>().alpha = 0f;
            canvasGroup.alpha = 0f;
            menuButton.SetActive(true);
            
        }
        else
        {
            SceneManager.LoadScene("Game");
        }
        
    }

    public void ExitButton()
    {
        Application.Quit();

    }

    public void MenuButton()
    {
        
        menuButton.GetComponent<CanvasGroup>().alpha = 0;
        Ui.GetComponent<CanvasGroup>().alpha = 1;
        menuButton.SetActive(false);
        StartCoroutine("Buttons");
        
    }
}