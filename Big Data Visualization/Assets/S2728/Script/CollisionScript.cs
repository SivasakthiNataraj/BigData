using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CollisionScript : MonoBehaviour
{
    [SerializeField]
    private Image _sprite;
    [SerializeField]
    private Sprite _changesprite;
    private Sprite _normalsprite;
    public bool _clickable = true;

    public GameManager _gameManager;
    public void Start()
    {
        _normalsprite = _sprite.sprite;
        _gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.name == "L_Touch_Pointer" || other.name == "R_Touch_Pointer")
        {
            if(_clickable == true)
            {
                if (this.gameObject.name == "Username")
                {
                    _gameManager.UsernameHighlight();
                }
                else if (this.gameObject.name == "Filename")
                {
                    _gameManager.UsernameHighlight();
                }
                else if (this.gameObject.name == "Login_Button")
                {
                    StartCoroutine(Button_Normal());
                }
                _sprite.sprite = _changesprite;
                _clickable = false;
                _gameManager.Button_Press();
            }
        }
    }
    IEnumerator Button_Normal()
    {
        yield return new WaitForSeconds(0.5f);
        _sprite.sprite = _normalsprite;
        if (this.gameObject.name == "Login_Button")
        {
            _gameManager.ScreenChange();
        }
        _clickable = true;
        _gameManager.Button_Release();
    }

    public void usernameHiglightsDisable()
    {
        _sprite.sprite = _normalsprite;
        _clickable = true;
    }
}
