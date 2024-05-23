using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChestTimer : MonoBehaviour
{

    private float _ChestTimer;

    private Animator _animator;
    private SpriteRenderer CoinSpriteRenderer;
    private GameObject CoinObject;

    private const string _isClosing2 = "isClosing";
    private const string _isOpening2 = "isOpening";

    private void Awake()
    {
        _animator = GetComponent<Animator>();
        CoinObject = this.transform.GetChild(0).gameObject;
        CoinSpriteRenderer = CoinObject.GetComponent<SpriteRenderer>();
    }


    // Start is called before the first frame update
    void Start()
    {
        _ChestTimer = 0.0f;
    }

    // Update is called once per frame
    void Update()
    {
        if (InputManager._isShifting == false)
        {
            _ChestTimer += 1 * Time.deltaTime;
        }
        if (InputManager._isShifting == true)
        {
            if (_ChestTimer > 0.0f)
            {
                _ChestTimer -= 1 * Time.deltaTime;
            }
        }
        if (_ChestTimer >= 5.0f)
        {
            _animator.SetBool(_isOpening2, false);
            _animator.SetBool(_isClosing2, true);
        }
        if (_ChestTimer < 5.0f)
        {
            _animator.SetBool(_isOpening2, true);
            _animator.SetBool(_isClosing2, false);
        }
    }

    public void DisplayCoin()
    {
        if (CoinObject != null)
        {
            CoinSpriteRenderer.enabled = true;
        }
    }

    public void HideCoin()
    {
        if (CoinObject != null)
        {
            CoinSpriteRenderer.enabled = false;
        }
    }
}
