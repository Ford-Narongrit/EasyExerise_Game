using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class MenuController : MonoBehaviour
{
    public static MenuController Instance { set; get; }
    [SerializeField] private Animator menuAnimator;

    private void Awake() {
        Instance = this;
    }

    //Buttons
    public void OnBackButton()
    {
        menuAnimator.SetTrigger("StartMenu");
    }

    public void OnSettingButton()
    {
        menuAnimator.SetTrigger("SettingMenu");
    }

    public void OnHealthMenu()
    {
        menuAnimator.SetTrigger("HealthMenu");
    }

    public void OnPlayMenu()
    {
        menuAnimator.SetTrigger("PlayMenu");
    }

    //change Scene
    public void OnRunScene()
    {
        SceneManager.LoadScene("Run");
    }

    public void OnSquatScene()
    {
        SceneManager.LoadScene("Squat");
    }
}
