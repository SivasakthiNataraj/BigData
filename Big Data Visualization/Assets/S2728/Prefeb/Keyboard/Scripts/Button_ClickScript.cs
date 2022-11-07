using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button_ClickScript : MonoBehaviour
{
    [SerializeField]
    private string alphabet_sent;
    [SerializeField]
    private SpriteRenderer _sprite;
    [SerializeField]
    private Sprite _changesprite;
    private Sprite _normalsprite;
    //public EmployeeDetails _empreference;
    int _delay = 0;

    //public GameManager _gameManager;

    private void Start()
    {
        //_normalsprite = _sprite.sprite;
        //_empreference = GameObject.Find("Main_menu_Screen").GetComponent<EmployeeDetails>();
        //_gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.name == "L_Touch_Pointer" || other.name == "R_Touch_Pointer")
        {
            if (_delay == 0)
            {
                _delay = 1;
                _sprite.sprite = _changesprite;
                if (other.name == "L_Touch_Pointer")
                {
                    //_gameManager.hand = "L";
                }
                else if (other.name == "R_Touch_Pointer")
                {
                    //_gameManager.hand = "R";
                }
                //_gameManager.HapticFeedback();
                StartCoroutine(Button_Normal());
                StartCoroutine(Type_Normal());
                //_empreference.alphabetFunction(alphabet_sent);
            }
            //_gameManager.Button_Press();
        }
    }   

    IEnumerator Button_Normal()
    {
        yield return new WaitForSeconds(0.15f);
        _sprite.sprite = _normalsprite;
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
