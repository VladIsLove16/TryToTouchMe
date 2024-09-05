using System;
using System.Linq;
using UniRx;

public class AngryLevelController
{
    private MoneyManager MoneyManager;

    public ReactiveProperty<AngryLevel> ReactiveAngryLevel = new() { Value = 0 };
    public AngryLevelController(MoneyManager moneyManager)
    {
        MoneyManager = moneyManager;
        MoneyManager.Money.Subscribe(money => SetAngryLevel(money));
    }
    public AngryLevel GetAngryLevel()
    {
        return ReactiveAngryLevel.Value;
    }
    private void SetAngryLevel(int money)
    {
        AngryLevel level = Enum.GetValues(typeof(AngryLevel))
            .Cast<AngryLevel>()
            .Where(level => money >= (int)level)
            .DefaultIfEmpty(AngryLevel.None)
            .Max();
        if (level == AngryLevel.TheEnd)
            ReactiveAngryLevel.Value = 0;
        else
            ReactiveAngryLevel.Value = level;
    }
}
public enum AngryLevel
{
    NotInGame = -2,
    None = -1, //0
    Cold = 0,             // Холодное состояние
    Tranquil = 2,         // Спокойствие
    Calm = 5,            // Спокойствие с легким раздражением
    SlightlyAnnoyed = 15,  // Легкое раздражение
    Irritated = 32,        // Начало раздражения
    Annoyed = 50,          // Умеренное раздражение
    Upset = 72,            // Сильно раздражен
    Angry = 98,           // Ярость
    Frustrated = 128,       // Раздражение
    VeryAngry = 162,        // Очень злой
    Furious = 200,         // Яростный
    Enraged = 242,         // В ярости
    Infuriated = 288,      // Обостренное раздражение
    Outraged = 338,        // Взбешенный
    Rage = 392,           // Гнев
    Insane = 450,         // Безумие
    Frenzied = 512,       // В бешенстве
    Agitated = 578,       // Встревоженный
    Irate = 648,         // Явно раздражен
    Livid = 722,         // Ярость
    EnragedExtreme = 800, // Экстремальное раздражение
    Seething = 882,       // Кипящий
    Boiling = 968,        // Кипящий
    Wrathful = 1058,       // Яростный
    Fiery = 1152,          // Пламенный
    Uncontrollable = 1240, // Неконтролируемый
    Berserk = 1332,        // Бешеный
    Mad = 1428,            // Безумный
    Frenetic = 1528,       // Нервный
    Wild = 1740,
    TheEnd = 2000
}// Дикий


