using TMPro;
using UniRx;
using UnityEngine;

public class UI : MonoBehaviour
{
    public MainGamePlay mGamePlay;
    private MoneyManager moneyManager;
    public TextMeshProUGUI MoneyText;
    public TextMeshProUGUI MoneyIntText;
    public TextMeshProUGUI AngryLevel;
    private void Awake()
    {
    }
    private void Start()
    {
        moneyManager = mGamePlay.MoneyManager;
        moneyManager.Money.SubscribeToText(MoneyText);
        moneyManager.MoneyInt.SubscribeToText(MoneyIntText);
        mGamePlay.AngryLevelController.ReactiveAngryLevel.SubscribeToText(AngryLevel);
    }
}
