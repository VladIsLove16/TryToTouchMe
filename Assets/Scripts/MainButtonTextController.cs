using System.Collections.Generic;
using UnityEngine;
using UniRx;
using System;
using System.Linq;
using UnityEngine.UI;
using TMPro;
using System.Collections;

public class MainButtonTextController : MonoBehaviour
{
    private readonly List<string> angryLevelTexts = new()
    {
          "notreachablelevel"  ,//0
          "Everything is fine."  ,//1
          "You’re still okay, but don’t push it."  ,//2
          "I’d appreciate it if you stopped."  ,//4
          "Stop it, you’re upsetting me."  ,//7
          "I’m irate, don’t push it any further.",
          "You’re really pushing it now."  ,//6
          "You’re losing my patience.",
          "I’m starting to get annoyed."  ,//5
          "Seriously, don’t push your luck."  ,//3
          "Things are running smoothly, all good here."  ,//4
          "All is well, nothing to be concerned about."  ,//3
          "DON'T CLICK ME!"  ,//8
          "DON'T TOUCH ME!"  ,//9
          "I WILL FCKING DESTROY YOU!!!"  , // 11
            "U WON!! CONGRATS!!",
            "YEAH!! THATS it! U won!",
            " Tadaaaaa That is ur prize: 100$ WOW!!",
            "Take it, man, just take it...",
          "You’re about to lose it!"  , //     13 
          "You’ve pushed me too far!"  ,//15
           "I can’t take this anymore!",
            "Something went wrong, u just crashed the game" ,
            "Gamecrashed (really), no joke",
            "Send the report to my email: dontfckingsendmeurreports@mail.ru",
            "error",
           "I’m livid, this is the end!",
            "Get out of my face!" ,// 19
           "I’M FURIOUS, PREPARE YOURSELF!!!"  ,//18// 20
    };
    private readonly List<string> gratitudePhrases = new()
    {
        "Thanks.",
        "I appreciate it.",
        "Very much appreciated.",
        "This is a big help.",
        "The pause is refreshing.",
        "Your kindness is greatly valued.",
        "Enjoying this brief moment of calm.",
        "The break was exactly what I needed.",
        "Your generosity is deeply appreciated.",
        "The moment of peace you provided is very welcomed.",
        "The time you allowed has been a great aid.",
        "Your support has been incredibly uplifting.",
        "Acknowledging and valuing the time you took away.",
        "Feeling much better after this short respite.",
        "The calm you’ve offered has been truly helpful.",
        "The time away has made a noticeable difference.",
        "The respite provided has made a remarkable difference.",
        "This brief downtime has been really appreciated.",
        "This pause has been quite beneficial for my well-being.",
        "The break you gave has been a significant relief.",
        "A substantial pause has made a huge positive difference.",
        "A moment of rest is valuable.",
        "Your extended break has had a genuinely positive impact.",
        "This period of rest has been extraordinarily beneficial.",
        "Your thoughtful break has been immensely valuable.",
        "Feeling rejuvenated thanks to this thoughtful pause.",
        "Your break has been quite helpful.",
        "This opportunity to unwind has been very precious.",
        "I’m profoundly grateful for this incredible break. It’s been immensely helpful.",
    };
    private readonly Dictionary<AngryLevel, string> _angryLevelTextsDict = new();
    private readonly Dictionary<AngryLevel, string> _gratitudeTextsDict = new();
    private TextMeshProUGUI textPro;
    private AngryLevelController AngryLevelController;
    [SerializeField]    
    private  MainGamePlay MainGamePlay;

    private AngryLevel lastAngryLevel = 0;
    private void Start()
    {
        textPro = GetComponentInChildren<TextMeshProUGUI>();
        List<AngryLevel> angryList = Enum.GetValues(typeof(AngryLevel))
            .Cast<AngryLevel>()
            .Where(x => (int)x >=-1)
            .OrderBy(x => x)
            .ToList();
        int i = 0;
        gratitudePhrases.Reverse();
        foreach (string phrase in gratitudePhrases)
        {
            _gratitudeTextsDict[angryList[i++]] = phrase;
        }
        i = 0;
        foreach (string phrase in angryLevelTexts)
        {
            _angryLevelTextsDict[angryList[i++]] = phrase;
        }
        AngryLevelController = MainGamePlay.AngryLevelController;
        AngryLevelController.ReactiveAngryLevel.Subscribe(level => SetAngryText(level));
    }
    private void SetAngryText(AngryLevel angryLevel)
    {
        if (lastAngryLevel <= angryLevel)
        {
            textPro.text = _angryLevelTextsDict[angryLevel];
        }
        else
        {
            textPro.text = _gratitudeTextsDict[angryLevel];
        }
        lastAngryLevel = angryLevel;
    }
}