using System.Diagnostics;
using UniRx;
using UnityEngine;
public class MoneyManager
{
    public ReactiveProperty<int> Money=new();
    public IntReactiveProperty MoneyInt=new();
    public void AddMoney(int money)
    {
        this.Money.Value += money;
        this.MoneyInt.Value += money;
    }
    public int GetMoney()
    {
        return Money.Value;
    }
    public void SpendMoney(int money)
    {
        Money.Value -= money;
    }
}
