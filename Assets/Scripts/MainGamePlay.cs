using System.Collections;
using UnityEngine;
public class MainGamePlay : MonoBehaviour
{
    public MoneyManager MoneyManager = new();
    [SerializeField]
    private float coolMechanismMultiplier = 0.01f;
    [SerializeField]
    private float coolMechanismDelayMultiplier = 1f;
    [SerializeField]
    private float coolMechanismDelay = 0.5f;
    private float coolMechanismCurrentTimeToCold = 0.25f;
    private float storedCool;
    public AngryLevelController AngryLevelController;
    private void Awake()
    {
        MoneyManager = new();
        AngryLevelController = new AngryLevelController(MoneyManager);
    }
    private void FixedUpdate()
    {
        CoolMechanism();
    }
    public void OnClick()
    {
        MoneyManager.AddMoney(1);
        ResetTimeToCold();
    }
    private void ResetTimeToCold()
    {
        coolMechanismCurrentTimeToCold =Mathf.Clamp(coolMechanismDelay - coolMechanismDelayMultiplier * MoneyManager.GetMoney(),0.25f, coolMechanismDelay);
    }
    private void CoolMechanism()
    {
        if(MoneyManager.GetMoney()>150)
        { 
            coolMechanismCurrentTimeToCold -= Time.deltaTime;
            if (coolMechanismCurrentTimeToCold <= 0)
            {
                storedCool += coolMechanismMultiplier * MoneyManager.GetMoney();
                if (storedCool >= 1)
                { 
                    MoneyManager.SpendMoney(1);
                    storedCool -=1;
                }
            }
        }
    }
}
