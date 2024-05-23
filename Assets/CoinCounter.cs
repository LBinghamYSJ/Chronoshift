using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CoinCounter : MonoBehaviour
{

    public static CoinCounter Instance;

    private int CoinCollectCount;

    private float Timer;

    [SerializeField] private Text CoinText;
    [SerializeField] private Text TimerText;

    private void Awake()
    {
        Instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        CoinText.text = "x" + CoinCollectCount.ToString();
        TimerText.text = TimerText.ToString();
        Timer = 0.0f;
    }

    void Update()
    {
        Timer += 1 * Time.deltaTime;
        TimerText.text = Timer.ToString("F2");
    }

    public void IncreaseCoinCount()
    {
        CoinCollectCount += 1;
        CoinText.text = "x" + CoinCollectCount.ToString();
    }
}
