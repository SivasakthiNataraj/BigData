using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyboardScript : MonoBehaviour
{

    public GameObject lowerkeysBorard;
    public GameObject uppercaseBoard;
    public GameObject numpad;
    public GameObject higlightDisable;
    public GameObject _keyboard;

    public bool _caps = false;
    public bool _num = false;
    private int delay = 0;



    [SerializeField]
    //private GameManager _gameManager;

    // Start is called before the first frame update
    void Start()
    {
        //_gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    public void ChangeKeyboard()
    {
        if (delay == 0 && _num == false)
        {
            delay = 1;
            if (_caps == true)
            {
                uppercaseBoard.SetActive(true);
                lowerkeysBorard.SetActive(false);
                numpad.SetActive(false);
            }
            else if (_caps == false)
            {
                lowerkeysBorard.SetActive(true);
                uppercaseBoard.SetActive(false);
                numpad.SetActive(false);
            }
            StartCoroutine(Type_Normal());
        }
    }

    public void NumpadEnable()
    {
        lowerkeysBorard.SetActive(false);
        uppercaseBoard.SetActive(false);
        numpad.SetActive(true);
    }

    public void AllkeyboardDisable()
    {
       // _gameManager._buttonclick = true;
        lowerkeysBorard.SetActive(true);
        uppercaseBoard.SetActive(false);
        numpad.SetActive(false);
        higlightDisable.SetActive(false);
        _keyboard.SetActive(false);
    }

    IEnumerator Type_Normal()
    {
        yield return new WaitForSeconds(0.22f);
        delay = 0;
    }
}
