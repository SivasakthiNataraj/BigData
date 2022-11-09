using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameManager : MonoBehaviour
{

    public string _username = null;
    public TMP_InputField[] username_Input;
    int nameIndex = 0;
    int InputID = 0;
    public GameObject keyboard_OBJ,Login_Enabled,Login_Disabled,upload_Enabled,upload_Disabled;
    public GameObject[] usernamePlaceHolder_OBJ;
    public GameObject[] UI_Screens;
    public AudioSource soundEFXSource;
    public AudioClip[] _soundsEfxclip;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void UsernameHighlight()
    {
        usernamePlaceHolder_OBJ[InputID].SetActive(false);
        keyboard_OBJ.SetActive(true);
    }



    public void ScreenChange()
    {
        UI_Screens[0].SetActive(false);
        keyboard_OBJ.SetActive(false);
        UI_Screens[1].SetActive(true);
        InputID = 1;
    }


    public void alphabetFunction(string alphabet)
    {
        if (nameIndex < 15)
        {
            nameIndex++;
            _username = _username + alphabet;
            username_Input[InputID].text = _username;
            if (InputID == 0)
            {
                if (nameIndex == 1)
                {
                    Login_Enabled.SetActive(true);
                    Login_Disabled.SetActive(false);
                }
            }
            else if (InputID == 1)
            {
                if (nameIndex == 1)
                {
                    upload_Enabled.SetActive(true);
                    upload_Disabled.SetActive(false);
                }
            }
            
        }
    }

    public void backspace()
    {
        if (nameIndex > 0)
        {
            _username = _username.Substring(0, _username.Length - 1);
            username_Input[InputID].text = _username;
            nameIndex--;
            if (InputID == 0)
            {
                if (nameIndex == 0)
                {
                    Login_Enabled.SetActive(false);
                    Login_Disabled.SetActive(true);
                    usernamePlaceHolder_OBJ[InputID].SetActive(true);
                }
            }
            else if (InputID == 1)
            {
                if (nameIndex == 0)
                {
                    upload_Enabled.SetActive(false);
                    upload_Disabled.SetActive(true);
                    usernamePlaceHolder_OBJ[InputID].SetActive(true);
                }
            }
            
        }
    }

    public void Button_Press()
    {
        soundEFXSource.clip = _soundsEfxclip[0];
        soundEFXSource.Play();
    }

    public void Button_Release()
    {
        soundEFXSource.clip = _soundsEfxclip[1];
        soundEFXSource.Play();
    }





}
