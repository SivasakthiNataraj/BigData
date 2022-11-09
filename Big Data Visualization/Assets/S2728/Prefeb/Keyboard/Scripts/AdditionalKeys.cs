using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AdditionalKeys : MonoBehaviour
{
    //public EmployeeDetails _empreference;
    [SerializeField]
    private SpriteRenderer _sprite;
    [SerializeField]
    private Sprite _changesprite;
    private Sprite _normalsprite;
    int _delay = 0;
    public GameManager _gameManager;

    public KeyboardScript _keyboardreference;

    private void Start()
    {
        _normalsprite = _sprite.sprite;
        //_empreference = GameObject.Find("Main_menu_Screen").GetComponent<EmployeeDetails>();
        _keyboardreference = GameObject.Find("Keyboard").GetComponent<KeyboardScript>();
        _gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.name == "L_Touch_Pointer" || other.name == "R_Touch_Pointer")
        {
            if (_delay == 0 && this.gameObject.name == "Backspace")
            {
                _sprite.sprite = _changesprite;
                StartCoroutine(Button_Normal());
                StartCoroutine(Type_Normal());
                _gameManager.backspace();
            }
            else if (_delay == 0 && this.gameObject.name == "Caps_lower")
            {
                _keyboardreference._caps = true;
                _keyboardreference.ChangeKeyboard();
            }
            else if (_delay == 0 && this.gameObject.name == "Caps_UPPER")
            {
                _keyboardreference._caps = false;
                _keyboardreference.ChangeKeyboard();
            }
            else if (_delay == 0 && this.gameObject.name == "123")
            {
                _keyboardreference._num = true;
                _keyboardreference.NumpadEnable();
            }
            else if (_delay == 0 && this.gameObject.name == "num_done")
            {
                _keyboardreference._num = false;
                _keyboardreference.ChangeKeyboard();
            }
            else if (_delay == 0 && this.gameObject.name == "done")
            {
                _keyboardreference.AllkeyboardDisable();
            }
            _gameManager.Button_Press();
        }
    }

    

    IEnumerator Button_Normal()
    {
        yield return new WaitForSeconds(0.15f);
        _sprite.sprite = _normalsprite;
        _gameManager.Button_Release();
    }

    IEnumerator Type_Normal()
    {
        yield return new WaitForSeconds(0.22f);
        _delay = 0;
    }

    //private void OnTriggerExit(Collider other)
    //{
    //    if (other.name == "L_Touch_Pointer" || other.name == "R_Touch_Pointer")
    //    {
    //        _gameManager.Button_Release();
    //    }
    //}
}
