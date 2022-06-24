using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;
using TMPro;
using UnityEngine.Playables;
using PixelCrushers.DialogueSystem;

public class MissionTwo : Mission
{
    //public delegate void ChangeObjective(Objective nextObj);
    //public static event ChangeObjective onChangeObj;

    // public delegate void ChangeObjectiveSide(SideObjective nextObj);
    //public static event ChangeObjectiveSide onChangeObjSide;



    private GameObject secretary;

    //private Objective currentObjective;
    //private SideObjective currentSideObjective;

    public Objective currentObjective;

    public Objective currentSideObjective;

    public List<Dialogue> dialogues;
    public List<GameObject> notes;

    public List<GameObject> newsPapers;
    private int currentIndex = 0;
    [SerializeField]
    private Canvas canvas;

    public GameObject dialogueManager;

    public GameObject notesParent;
    public GameObject newsPaperParent;

    public Canvas notesCanvas;
    public Canvas newsPaperCanvas;

    public Image newsPaperImage;
    public TextMeshProUGUI noteTitle;
    public TextMeshProUGUI noteContent;

    private bool isCloseToNote = false;
    private bool isCloseToNewspaper = false;

    private GameObject activeNote;
    private GameObject activeNewspaper;

    public GameObject notePrefab;
    public GameObject newsPaperPrefab;

    public GameObject notesPanel;
    public GameObject newsPaperPanel;

    public GameObject inventoryManager;

    public List<QuizQuestion> quizQuestions;

    public List<GameObject> cutscenePoints;

    public GameObject cutscenesParent;

    public GameObject activeCutScene;

    public Button quizAppButton;

    public GameObject ScoreObj;

    public GameObject audioSrc;

    public List<GameObject> finishedCutscenePoints;

    public GameObject manAtFirst;

    public GameObject firstMaleSecretary;

    public List<GameObject> mainObjectives;

    public List<GameObject> sideObjectives;

    public int currentObjectiveIndex = 0;

    public int currentSideObjectiveIndex = 0;

    public MissionTwo()
    {
        // Quiz questions
        objectives = new List<Objective>();

        //sideObjectives = new List<Objective>();

        quizQuestions = new List<QuizQuestion>();
        mainObjectives = new List<GameObject>();



        ////////////////////////////////////////////////////////////////////////////////////////////////////////////
        ///

        //sideObjectives.Add(new SideObjective("", 10, 10, false, new Action<SideObjective>(checkFirstSideObjectiveComplete)));

        //sideObjectives.Add(new SideObjective("ﺍﻓﺘﺢ ﺑﺮﻧﺎﻣﺞ tahC ﻭ ﺍﺑﺪﺃ ﻣﺤﺎﺩﺛﻪ ﻣﻊ ﺍﻟﻤﻀﻴﻔﻪ", 10, 10, false, this.checkSecondObjectiveComplete));

        // sideObjectives.Add(new SideObjective("ﺍﻏﻠﻖ ﺍﻟﺒﺮﻧﺎﻣﺞ ﻭ ﺍﻓﺘﺢ ﺑﺮﻧﺎﻣﺞ ﺍﻝ buH tnemtsevnI ﻣﺠﺪﺩﺍ", 10, 10, false, this.checkThirdObjectiveComplete));

        //sideObjectives.Add(new SideObjective("ﺍﺿﻒ ﺗﻌﻠﻴﻘﺎ ﻋﻠﻲ ﺍﻟﺒﻮﺳﺖ ﺣﺎﻭﻝ ﺍﻥ ﺗﺨﺘﺎﺭ ﺍﻟﺘﻌﻠﻴﻖ ﺍﻷﺻﺢ", 10, 10, false, this.checkFourthObjectiveComplete));

        //sideObjectives.Add(new SideObjective("ﺍﻏﻠﻖ ﺍﻟﺒﺮﻧﺎﻣﺞ ﻭ ﺍﺿﻐﻂ I ﻻﻏﻼﻕ ﺍﻟﺘﺎﺑﻠﺖ", 10, 10, false, this.checkFifthObjectiveComplete));

        quizQuestions.Add(new QuizQuestion("ﻣﺎ ﻫﻲ ﺍﻷﺷﻴﺎﺀ ﺍﻟﺘﻲ ﺗﻘﻮﻡ ﺑﻬﺎ ﺍﻟﺸﺮﻛﺎﺕ ﻟﻠﺤﺼﻮﻝ ﻋﻠﻲ ﺗﻤﻮﻳﻞ ؟", new List<string>() { "ﻣﻦ ﺧﻼﻝ ﺑﻴﻊ ﺍﻷﺳﻬﻢ", "ﻣﻦ ﺧﻼﻝ ﺍﻷﻗﺘﺮﺍﺽ", "ﻛﻞ ﻣﻦ  ﺃ & ﺏ", "ﻣﻦ ﺧﻼﻝ ﺯﻳﺎﺩﻩ ﺍﻷﻧﺘﺎﺝ" }, 1));
        quizQuestions.Add(new QuizQuestion("ﻣﺎ ﻫﻲ ﺍﻟﻔﺘﺮﺍﺕ ﻟﺮﺩ ﻗﻴﻤﻪ ﺍﻟﻔﺎﺋﺪﻩ ﺍﻟﺨﺎﺻﻪ ﺑﺎﻟﺴﻨﺪﺍﺕ ؟", new List<string>() { "3 ﺃﺷﻬﺮ", "6 ﺃﺷﻬﺮ", "21 ﺍﺷﻬﺮ", "ﻛﻞ ﻣﺎ ﺳﺒﻖ" }, 3));
        quizQuestions.Add(new QuizQuestion("ﻣﺎ ﻫﻮ ﺍﻷﻗﻞ ﺧﻄﻮﺭﻩ ﻓﻲ ﺍﻷﺳﺘﺜﻤﺎﺭ ؟", new List<string>() { "ﺍﻷﺳﺘﺜﻤﺎﺭ ﻓﻲ ﺍﻷﺳﻬﻢ", "ﺍﻷﺳﺘﺜﻤﺎﺭ ﻓﻲ ﺍﻟﺴﻨﺪﺍﺕ", "ﺍﻻﺳﺘﺜﻤﺎﺭ ﻓﻲ ﻭﺛﺎﺋﻖ ﺻﻨﺎﺩﻳﻖ ﺍﻟﻤﺆﺷﺮ", "ﻛﻞ ﻣﺎ ﺳﺒﻖ" }, 1));
        quizQuestions.Add(new QuizQuestion("ﻛﻴﻔﻴﻪ ﺷﺮﺍﺀ ﺍﻷﺳﻬﻢ ﺃﻭ ﺍﻟﺴﻨﺪﺍﺕ ؟", new List<string>() { "ﻣﻦ ﺷﺮﻛﻪ ﻭﺳﺎﻃﻪ ﻣﺎﻟﻴﻪ", "ﻣﻦ ﺧﻼﻝ ﺷﺮﻛﺎﺀ", "ﻣﻦ ﺍﻟﺒﻮﺭﺻﻪ", "ﻛﻞ ﻣﺎ ﺳﺒﻖ" }, 0));
        quizQuestions.Add(new QuizQuestion("ﺍﻟﺨﺼﺎﺋﺺ ﺍﻟﺘﻲ ﻣﻦ ﺧﻼﻟﻬﺎ ﺗﺘﻤﻜﻦ ﻣﻦ ﺃﺧﺘﻴﺎﺭ ﺷﺮﻛﻪ ﺍﻟﺴﻤﺴﺮﻩ ؟", new List<string>() { "ﻟﺪﻳﻬﺎ ﺗﺪﺍﻭﻝ ﺍﻟﻜﺘﺮﻭﻧﻲ", "ﻟﺪﻳﻬﺎ ﺧﺪﻣﻪ ﻋﻤﻼﺀ ﻭ ﺳﺮﻋﻪ ﻓﻲ ﺍﻟﺮﺩ", "ﺗﻜﻮﻥ ﺍﻟﻌﻤﻮﻟﺔ ﺍﻟﺨﺎﺻﻪ ﺑﻬﺎ ﻓﻲ ﺍﻟﻤﺘﻮﺳﻂ", "ﻛﻞ ﻣﺎ ﺳﺒﻖ" }, 3));


        quizQuestions.Add(new QuizQuestion("ﻣﺎ ﻫﻮ ﻣﻔﻬﻮﻡ ﺍﻟﻤﺆﺷﺮ ؟", new List<string>() { "ﻫﻮ ﻣﺘﻮﺳﻂ ﺍﺳﻌﺎﺭ ﺍﺳﻬﻢ ﺍﻟﺸﺮﻛﺎﺕ ﺍﻟﻤﻜﻮﻧﺔ ﻟﻪ", "ﻫﻮ ﺍﻟﺤﺪ ﺍﻷﺩﻧﻲ ﻟﺴﻌﺮ ﺍﺳﻬﻢ ﺍﻟﺸﺮﻛﺎﺕ ﺍﻟﻤﻜﻮﻧﺔ ﻟﻪ", "ﻫﻮ ﺍﻟﺤﺪ ﺍﻷﻗﺼﻲ ﻟﺴﻌﺮ ﺍﺳﻬﻢ ﺍﻟﺸﺮﻛﺎﺕ ﺍﻟﻤﻜﻮﻧﺔ ﻟﻪ", "ﻛﻞ ﻣﺎ ﺳﺒﻖ" }, 0));
        quizQuestions.Add(new QuizQuestion("ﻣﺎ ﻫﻮ ﻣﺆﺷﺮ 03 XGE ؟", new List<string>() { "ﻫﻮ ﻣﺆﺷﺮ ﺳﻌﺮﻱ ﻳﻘﻴﺲ ﺍﺩﺍﺀ ﺍﻋﻠﻰ 03 ﺷﺮﻛﻪ ﻣﻦ ﺣﻴﺚ ﺍﻟﺴﻴﻮﻟﺔ ﻭﺍﻟﻨﺸﺎﻁ ﻓﻲ ﺍﻟﺒﻮﺭﺻﻪ ﺍﻟﻤﺼﺮﻳﺔ", "ﻫﻮ ﻣﺆﺷﺮ ﺳﻌﺮﻱ ﻳﻘﻴﺲ ﺍﺩﺍﺀ ﺍﻋﻠﻰ 02 ﺷﺮﻛﻪ ﻣﻦ ﺣﻴﺚ ﺍﻟﺴﻴﻮﻟﺔ ﻭﺍﻟﻨﺸﺎﻁ ﻓﻲ ﺍﻟﺒﻮﺭﺻﻪ ﺍﻟﻤﺼﺮﻳﺔ", "ﻫﻮ ﻣﺆﺷﺮ ﺳﻌﺮﻱ ﻳﻘﻴﺲ ﺍﺩﺍﺀ ﺍﺩﻧﻲ 03 ﺷﺮﻛﻪ ﻣﻦ ﺣﻴﺚ ﺍﻟﺴﻴﻮﻟﺔ ﻭﺍﻟﻨﺸﺎﻁ ﻓﻲ ﺍﻟﺒﻮﺭﺻﻪ ﺍﻟﻤﺼﺮﻳﺔ", "ﻫﻮ ﻣﺆﺷﺮ ﺳﻌﺮﻱ ﻳﻘﻴﺲ ﺍﺩﺍﺀ ﺍﺩﻧﻲ 02 ﺷﺮﻛﻪ ﻣﻦ ﺣﻴﺚ ﺍﻟﺴﻴﻮﻟﺔ ﻭﺍﻟﻨﺸﺎﻁ ﻓﻲ ﺍﻟﺒﻮﺭﺻﻪ ﺍﻟﻤﺼﺮﻳﺔ" }, 0));
        quizQuestions.Add(new QuizQuestion("ﻣﺎ ﻫﻮ  ﻣﻔﻬﻮﻡ ﺳﻌﺮ ﺍﻻﻏﻼﻕ ؟", new List<string>() { "ﻫﻮ ﺍﻟﺴﻌﺮ ﺍﻟﻨﻬﺎﺋﻲ ﺍﻟﺬﻱ ﻳﺘﻢ ﺗﺪﺍﻭﻟﻪ ﺧﻼﻝ ﺳﺎﻋﺎﺕ ﺍﻟﺴﻮﻕ ﺍﻟﻌﺎﺩﻳﺔ", "ﻫﻮ ﺍﻟﺴﻌﺮ ﺍﻟﻤﺒﺪﺃﻱ ﺍﻟﺬﻱ ﻳﺘﻢ ﺗﺪﺍﻭﻟﻪ ﺧﻼﻝ ﺳﺎﻋﺎﺕ ﺍﻟﺴﻮﻕ ﺍﻟﻌﺎﺩﻳﺔ", "ﻫﻮ ﺍﻟﺴﻌﺮ ﺍﻟﻤﺘﻮﺳﻂ ﺍﻟﺬﻱ ﻳﺘﻢ ﺗﺪﺍﻭﻟﻪ ﺧﻼﻝ ﺳﺎﻋﺎﺕ ﺍﻟﺴﻮﻕ ﺍﻟﻌﺎﺩﻳﺔ", "ﻛﻞ ﻣﺎ ﺳﺒﻖ" }, 0));
        quizQuestions.Add(new QuizQuestion("ﻛﻴﻔﻴﻪ ﺍﻟﺤﺼﻮﻝ ﻋﻠﻲ ﺍﻟﻜﻮﺩ ﺍﻟﺨﺎﺹ ﺑﺎﻟﺘﺪﺍﻭﻝ ؟", new List<string>() { "ﻳﺘﻢ ﺍﻟﺤﺼﻮﻝ ﻋﻠﻴﻪ ﻣﻦ ﺧﻼﻝ ﺍﻟﺘﻌﺎﻗﺪ ﻣﻊ ﺍﻱ ﺷﺮﻛﻪ ﻭﺳﺎﻃﺔ ﻣﺎﻟﻴﻪ", "ﻳﺘﻢ ﺍﻟﺤﺼﻮﻝ ﻋﻠﻴﻪ ﺑﺪﻭﻥ ﺍﻱ ﺷﺮﻭﻁ ﻣﺴﺒﻘﻪ", "ﻳﺘﻢ ﺍﻟﺤﺼﻮﻝ ﻋﻠﻴﻪ ﺑﻤﺠﺮﺩ ﺩﺧﻮﻟﻚ ﺍﻟﺒﻮﺭﺻﻪ", "ﻛﻞ ﻣﺎ ﺳﺒﻖ" }, 0));
        quizQuestions.Add(new QuizQuestion("ﻛﻴﻒ ﺗﻜﻮﻥ ﺣﻤﺎﻳﻪ ﺍﻣﻮﺍﻟﻚ ﻣﻦ ﺍﻟﻨﺼﺐ ﻭ ﺍﻻﺣﺘﻴﺎﻝ ؟", new List<string>() { "ﻣﻦ ﺧﻼﻝ ﺻﻨﺪﻭﻕ ﺣﻤﺎﻳﻪ ﺍﻟﻤﺴﺘﺜﻤﺮ ﺑﻴﻌﻮﺿﻚ ﻭﻓﻘﺎ ﻟﻠﻘﻮﺍﻋﺪ ﺍﻟﻤﻌﻤﻮﻝ ﺑﻬﺎ", "ﻻ ﻳﻮﺟﺪ ﺍﻱ ﺣﻤﺎﻳﺎﺕ ﺍﻭ ﺿﻤﺎﻧﺎﺕ", "ﻻ ﻳﻮﺟﺪ ﻧﺼﺐ ﺍﻭ ﺍﺣﺘﻴﺎﻝ ﻣﻦ ﺍﻷﺳﺎﺱ", "ﻛﻞ ﻣﻦ ﺏ ﻭ ﺝ" }, 0));





        quizQuestions.Add(new QuizQuestion("ﻛﻴﻒ ﻳﻜﻮﻥ ﺍﺧﺘﻴﺎﺭ ﺍﻟﺴﻤﺴﺎﺭ ؟", new List<string>() { "ﺍﻥ ﻳﻜﻮﻥ ﻣﺴﺠﻞ ﺣﻴﺚ ﺍﻥ ﺍﻟﻬﻴﺌﺔ ﺍﻟﻌﺎﻣﺔ ﻟﻠﺮﻗﺎﺑﺔ ﺍﻟﻤﺎﻟﻴﺔ ﻭﺍﻟﺒﻮﺭﺻﺔ ﺍﻟﻤﺼﺮﻳﺔ", "ﺍﻥ ﻳﻜﻮﻥ ﻣﺴﺠﻞ ﻓﻲ ﺍﻟﻬﻴﺌﺔ ﺍﻟﻌﺎﻣﺔ ﻟﻠﺮﻗﺎﺑﺔ ﻋﻠﻲ ﺍﻟﺠﻮﺩﻩ", "ﺍﻥ ﻳﻜﻮﻥ ﺳﻴﺊ ﺍﻟﺴﻤﻌﻪ", "ﻛﻞ ﻣﻦ ﺃ ﻭ ﺏ" }, 0));
        quizQuestions.Add(new QuizQuestion("ﻣﺎ ﻣﻴﺰﻩ ﺍﻥ ﻳﻜﻮﻥ ﺍﻟﺴﻤﺴﺎﺭ ﻣﺴﺠﻞ ﻓﻲ ﺍﻟﻬﻴﺌﻪ ﺍﻟﻌﺎﻣﻪ ﻟﻠﺮﻗﺎﺑﻪ ﺍﻟﻤﺎﻟﻴﻪ ؟", new List<string>() { "ﺍﻥ ﺍﻟﻬﻴﺌﺔ ﺍﻟﻌﺎﻣﺔ ﻟﻠﺮﻗﺎﺑﺔ ﺍﻟﻤﺎﻟﻴﺔ ﻭﺍﻟﺒﻮﺭﺻﺔ ﺍﻟﻤﺼﺮﻳﺔ ﺑﺘﺤﺘﻔﻆ ﺑﺴﺠﻼﺕ ﺗﺎﺭﻳﺨﻴﻪ ﻟﻜﻞ ﻣﻨﻔﺬﻱ ﺷﺮﻛﺎﺕ ﺍﻟﺴﻤﺴﺮﺓ", "ﺍﻥ ﻳﻜﻮﻥ ﻣﻦ ﺍﻟﺴﻬﻞ ﺗﺘﺒﻊ ﺍﻧﺠﺎﺯﺍﺗﻪ", "ﺍﻥ ﻳﻜﻮﻥ ﻣﻦ ﺍﻟﺴﻬﻞ ﻋﻠﻲ ﺍﻟﺴﻤﺴﺎﺭ ﺍﻳﺠﺎﺩﻩ ﻋﻨﺪ ﺣﺪﻭﺙ ﺍﻱ ﻣﺸﻜﻠﻪ", "ﻛﻞ ﻣﺎ ﺳﺒﻖ" }, 0));

        quizQuestions.Add(new QuizQuestion("ﻧﻘﺎﻁ ﺍﻟﺘﻔﺮﻳﻖ ﺑﻴﻦ ﺍﺛﻨﻴﻦ ﻣﻦ ﺍﻟﻤﻨﻔﺬﻳﻦ ؟", new List<string>() { "ﻃﻠﺐ ﺍﻟﻜﺘﻴﺐ ﺍﻟﺨﺎﺹ ﺑﻪ", "ﺍﻟﺴﺆﺍﻝ ﻋﻦ ﺍﻟﻌﻤﻮﻟﻪ ﻭ ﺍﻟﻤﻔﺎﺿﻠﻪ ﻣﻦ ﺧﻼﻟﻬﺎ", "ﺍﻟﺴﺆﺍﻝ ﻋﻦ ﻋﻼﻗﺘﻪ ﺍﻷﺟﺘﻤﺎﻋﻴﻪ", "ﻛﻞ ﻣﻦ ﺃ ﻭ ﺏ" }, 3));

        quizQuestions.Add(new QuizQuestion("ﻣﺎ ﻫﻲ ﺍﺳﺒﺎﺏ ﺍﻟﻤﺸﺎﻛﻞ ﺑﻴﻦ ﺍﻟﻤﺴﺘﺜﻤﺮ ﻭ ﺍﻟﺴﻤﺴﺎﺭ ؟", new List<string>() { "ﺑﺴﺒﺐ ﺍﻥ ﺗﻮﻗﻌﺎﺕ ﺍﻟﻤﺴﺘﺜﻤﺮ ﺗﻜﻮﻥ ﻏﻴﺮ ﻭﺍﻗﻌﻴﻪ", "ﺍﻟﻌﻤﻠﻴﺎﺕ ﺍﻟﺘﻲ ﻳﻤﻜﻦ ﺍﻥ ﺗﺘﻢ ﺑﺪﻭﻥ ﺍﺫﻥ ﻣﺴﺒﻖ ﻣﻦ ﺍﻟﻤﺴﺘﺜﻤﺮ", "ﺑﺴﺒﺐ ﻋﺪﻡ ﺗﺒﺎﺩﻝ ﺍﻟﺜﻘﻪ ﻭ ﺍﻟﻤﻌﻠﻮﻣﺎﺕ ﻓﻴﻤﺎ ﺑﻴﻨﻬﻤﺎ", "ﻛﻞ ﻣﻦ ﺃ ﻭ ﺏ" }, 3));

        quizQuestions.Add(new QuizQuestion("ﻣﻦ ﻣﻤﻴﺰﺍﺕ ﺍﻷﺳﺘﺜﻤﺎﺭ ﻓﻲ ﺍﻟﺒﻮﺭﺻﻪ ﺍﻟﻤﺼﺮﻳﺔ ؟", new List<string>() { "ﺍﺭﺑﺎﺡ ﺍﻟﺸﺮﻛﻪ ﺗﻮﺯﻉ ﻋﻠﻲ ﻣﺴﺎﻫﻤﻴﻬﺎ ﻓﻲ ﺻﻮﺭﻩ ﻛﻮﺑﻮﻥ", "ﺍﻟﻌﺎﺋﺪ ﺍﻟﺮﺃﺱ ﺍﻟﻤﺎﻟﻲ ﻭ ﻫﻮ ﺍﻟﻔﺮﻕ ﺑﻴﻦ ﺳﻌﺮ ﺍﻟﺒﻴﻊ ﻭ ﺳﻌﺮ ﺷﺮﺍﺀ ﺍﻟﺴﻬﻢ", "ﺑﺴﺒﺐ ﺳﻬﻮﻟﻪ ﺍﻟﻤﻜﺴﺐ", "ﻛﻞ ﻣﻦ أ ﻭ ب" }, 3));




        //currentObjective = objectives[0].instance;
        //currentSideObjective = sideObjectives[0].instance;

        //Objective.onCompleteObj += checkObjComplete;

        //SideObjective.onCompleteObj += checkObjComplete2;

        dialogues = new List<Dialogue>();



    }
    void Start()
    {
        //cutscenePoints = new List<GameObject>();
        secretary = GameObject.FindGameObjectWithTag("Female NPC - Secretary");
        //onCompleteObj =  currentObjective.setOnCompleteObj(this);
        //onCompleteSideObj = currentSideObjective.setOnCompleteObj(this);
        var firstDialogueLines = new List<DialogueLine>();
        // firstDialogueLines.Add(new DialogueLine(secretary, "Reciptionist",0, "لا عليك فذلك من واجبنا يسعدنا نجاحك"));
        // firstDialogueLines.Add(new DialogueLine(GameObject.FindGameObjectWithTag("Player"), "Player",1, "اممم معذره لما كان كل ذلك الثناء قد كان كمان انجب طفلا للتو"));
        //notes = notesParent.transform.getChi
        // dialogues.Add(new Dialogue(GameObject.FindGameObjectWithTag("Player"), secretary, firstDialogueLines));
        if (newsPaperParent.transform.childCount > 0)
        {
            for (var i = 0; i < newsPaperParent.transform.childCount; i++)
            {
                newsPapers.Add(newsPaperParent.transform.GetChild(i).gameObject.transform.GetChild(1).gameObject);
                //  360
            }
            newsPapers[0].AddComponent<Newspaper>();
            newsPapers[0].GetComponent<Newspaper>().changeNewspaperSprite((Sprite)Resources.Load("Sprites/Missions/MissionOne/Newspaper/NP_MissionOne_01", typeof(Sprite)), (Material)Resources.Load("Materials/Missons/MissionOne/Newspapers/NP_MissionOne_Material", typeof(Material)));
            Newspaper.onNotifyClosenessToNewspaper += this.showOpenNewspaperToggle;
        }

        if (notesParent.transform.childCount > 0)
        {
            for (var i = 0; i < notesParent.transform.childCount; i++)
            {
                notes.Add(notesParent.transform.GetChild(i).gameObject.transform.GetChild(1).gameObject);
                //  360
            }
            notes[0].AddComponent<Note>();
            notes[0].GetComponent<Note>().title = "Important points related to Shares and Stocks";
            notes[0].GetComponent<Note>().content = "Stock: It is the value of capital of a company, the unit of which is usually Rs. 100 unless stated otherwise. Stock is always bought, sold or held. 4 percent at 85: It means that Rs. 100 stock can be purchased for Rs. 85 and Rs. 4 is the annual income on Rs. 100 stock or Rs. 85 investment or cash spent. Brokerage: It is the sum of money paid to a stock dealer on the sale and purchase of stocks. It is paid on the face value. Note: While buying, brokerage is added in the purchase price i.e. it increases the purchase price, whereas while selling, it is reduced from the selling price i.e. it reduces the selling price.Stock at par: When the cash price or the selling price of the INR 10 stock is INR 10, the stock is said to be valued at par. Stock above par: When the buying price or the selling price of INR 10 stock is more that INR 10, it is said to be valued at above par. In other words, it is said to be valued at a premium. Cash: It is the money spent or received while buying or selling the stock. Cash is always invested or received. In other words, when cash is spent, it is also called investment. Market Price: The price at which that particular stock is bought or sold, it is called the Market Value or the Market price of the stock. Stock below par: When the buying or the selling price of a stock is less than that of its face value, it is said to be sold at a discount. In other words, it is also said to be sold below par.";

            notes[1].AddComponent<Note>();
            notes[1].GetComponent<Note>().title = "Important Formulas of Stocks and Shares";
            notes[1].GetComponent<Note>().content = "In shares and stock questions, there could be two – three methods to find answer to a particular question. It is advised to remember all the following formulas. \n Stock purchased/sold = Investment × 100/Market Price \n Investment/Cash required = Stock × Market Price/100 \n Income/Dividend = Stock × Rate/100 \n Stock purchased/sold = Income × 100/Rate% \n Investment/Cash required = Income ×Market Price/Rate% \n Income/Dividend = Investment × Rate/Market Price";
            //notesParent.transform.GetChild(0).gameObject.GetComponent<Note>().title = "First Note";
            // newNote = new Note("First Note", "Lorem 1", notesParent.transform.GetChild(0).gameObject);
            //Debug.Log(notesParent.transform.GetChild(0).gameObject.transform.GetChild(1).gameObject.GetComponent<Note>().content);   
            Note.onNotifyClosenessToNote += this.showOpenNoteToggle;
        }
        Debug.Log(gameObject.transform.GetChild(0).gameObject.transform.childCount);
        for (var i = 0; i < gameObject.transform.GetChild(0).gameObject.transform.childCount; i++)
        {
            //Debug.Log(gameObject.transform.GetChild(0).gameObject.transform.GetChild(i).gameObject);
            mainObjectives.Add(gameObject.transform.GetChild(0).gameObject.transform.GetChild(i).gameObject);
        }
        currentObjective = mainObjectives[currentObjectiveIndex].GetComponent<Objective>();
        GameObject.FindObjectOfType<MissionManager>().updateObjectiveTest(currentObjective);

        for (var i = 0; i < gameObject.transform.GetChild(1).gameObject.transform.childCount; i++)
        {
            //Debug.Log(gameObject.transform.GetChild(0).gameObject.transform.GetChild(i).gameObject);
            sideObjectives.Add(gameObject.transform.GetChild(1).gameObject.transform.GetChild(i).gameObject);
        }
        currentSideObjective = sideObjectives[currentSideObjectiveIndex].GetComponent<Objective>();
        GameObject.FindObjectOfType<MissionManager>().updateObjectiveTest2(currentSideObjective);

    }
    private void checkFirstSideObjectiveComplete(SideObjective obj)
    {

    }


    public void changeMainObjective(GameObject current)
    {
        Debug.Log(currentObjectiveIndex);
        //refreshObjectives();

        if (currentObjectiveIndex < mainObjectives.Count - 1 && current.GetComponent<Objective>().isComplete)
        {
            var nextObj = mainObjectives[currentObjectiveIndex + 1];
            if (nextObj != null)
            {
                GameObject.FindObjectOfType<MissionManager>().updateObjectiveTest(nextObj.GetComponent<Objective>());
                Destroy(mainObjectives[currentObjectiveIndex].gameObject);
                mainObjectives[currentObjectiveIndex + 1].gameObject.SetActive(true);
                currentObjective = nextObj.GetComponent<Objective>();
                currentObjectiveIndex++;
            }

        }
        else if (currentObjectiveIndex == mainObjectives.Count - 1 && current.GetComponent<Objective>().isComplete)
        {
            GameObject.FindObjectOfType<MissionManager>().updateObjectiveTest(new Objective() { title = "Finished" });
        }
    }
    public void changeSideObjective(GameObject current)
    {
        Debug.Log(currentSideObjectiveIndex);
        //refreshObjectives();

        if (currentSideObjectiveIndex < sideObjectives.Count && current.GetComponent<Objective>().isComplete)
        {
            var nextObj = sideObjectives[currentSideObjectiveIndex + 1];
            if (nextObj != null)
            {
                GameObject.FindObjectOfType<MissionManager>().updateObjectiveTest2(nextObj.GetComponent<Objective>());
                Destroy(sideObjectives[currentSideObjectiveIndex].gameObject);
                sideObjectives[currentSideObjectiveIndex + 1].gameObject.SetActive(true);
                currentSideObjective = nextObj.GetComponent<Objective>();
                currentSideObjectiveIndex++;
            }

        }
    }
    void FixedUpdate()
    {
        if (this.activeNote != null && Input.GetKeyDown(KeyCode.R))
        {
            audioSrc.GetComponent<AudioSource>().clip = (AudioClip)Resources.Load("Audio/paper_flip", typeof(AudioClip));
            OpenNote();
        }
        else if (this.activeNote == null && Input.GetKeyDown(KeyCode.R))
        {
            audioSrc.GetComponent<AudioSource>().clip = (AudioClip)Resources.Load("Audio/Writing_Sound", typeof(AudioClip));
            CloseNote();
        }

        if (this.activeNewspaper != null && Input.GetKeyDown(KeyCode.N))
        {
            audioSrc.GetComponent<AudioSource>().clip = (AudioClip)Resources.Load("Audio/paper_flip", typeof(AudioClip));
            OpenNewspaper();
        }
        else if (this.activeNewspaper == null && Input.GetKeyDown(KeyCode.N))
        {
            audioSrc.GetComponent<AudioSource>().clip = (AudioClip)Resources.Load("Audio/paper_flip", typeof(AudioClip));
            //  audioSrc.GetComponent<AudioSource>().clip =  (AudioClip) Resources.Load("Audio/Writing_Sound", typeof(AudioClip));
            CloseNewspaper();
        }
        // Debug.Log(Vector3.Distance(cutscenePoints[0].transform.position, GameObject.FindGameObjectWithTag("Player").transform.position));
        for (var i = 1; i < cutscenePoints.Count; i++)
        {
            if (finishedCutscenePoints.Exists(c => c == cutscenePoints[i]))
            {
                continue;
            }
            else
            {
                if (this.activeCutScene != null)
                {
                    //Debug.Log(this.activeCutScene.GetComponent<PlayableDirector>().state);
                }
                if (Vector3.Distance(cutscenePoints[i].transform.position, GameObject.FindGameObjectWithTag("Player").transform.position) <= 1)
                {
                    cutscenesParent.transform.GetChild(i).gameObject.SetActive(true);
                    this.activeCutScene = cutscenesParent.transform.GetChild(i).gameObject;
                    // cutscenesParent.transform.GetChild(i).gameObject.GetComponent<PlayableDirector>().Play();
                    GameObject.FindGameObjectWithTag("Player").gameObject.GetComponent<PlayerMovement>().allowedToMove = false;
                    //cutscenesParent.transform.GetChild(i).gameObject.GetComponent<PlayableDirector>().played += OnPlayableDirectorStarted;
                    cutscenesParent.transform.GetChild(i).gameObject.GetComponent<PlayableDirector>().stopped += OnPlayableDirectorStopped;
                    // cutscenesParent.transform.GetChild(i).gameObject.GetComponent<PlayableDirector>()
                    if (i == 0)
                    {
                        manAtFirst.GetComponent<DialogueSystemTrigger>().enabled = true;
                        GameObject.FindGameObjectWithTag("Player").GetComponents<DialogueSystemTrigger>()[0].enabled = true;
                    }
                    else if (i == 1)
                    {
                        //firstMaleSecretary.GetComponent<DialogueSystemTrigger>().enabled = true;
                        GameObject.FindGameObjectWithTag("Player").GetComponents<DialogueSystemTrigger>()[1].enabled = true;
                    }
                    else if (i == 2)
                    {
                        GameObject.FindGameObjectWithTag("Player").GetComponents<DialogueSystemTrigger>()[2].enabled = true;
                    }
                    else if (i == 3)
                    {
                        GameObject.FindGameObjectWithTag("Player").GetComponents<DialogueSystemTrigger>()[3].enabled = true;
                    }
                    finishedCutscenePoints.Add(cutscenePoints[i]);
                }
            }
        }
        // StartCoroutine(checkObjectivesIEnum());
    }
    public void StartCutsceneWithConversation() {
        cutscenesParent.transform.GetChild(1).gameObject.SetActive(true);
        this.activeCutScene = cutscenesParent.transform.GetChild(1).gameObject;
        GameObject.FindGameObjectWithTag("Player").gameObject.GetComponent<PlayerMovement>().allowedToMove = false;
        cutscenesParent.transform.GetChild(1).gameObject.GetComponent<PlayableDirector>().stopped += OnPlayableDirectorStopped;
        GameObject.FindGameObjectWithTag("Player").GetComponents<DialogueSystemTrigger>()[1].enabled = true;
        finishedCutscenePoints.Add(cutscenePoints[0]);
        //currentObjective.isComplete = true;
        //currentObjective.transform.parent.parent.GetComponent<MissionTwo>().changeMainObjective(currentObjective.gameObject);
    }
    void OnPlayableDirectorStarted(PlayableDirector aDirector)
    {
        //Debug.Log("Being Played");
        //aDirector.transform.parent.gameObject.SetActive(false);
        GameObject.FindGameObjectWithTag("Player").gameObject.GetComponent<PlayerMovement>().allowedToMove = false;
        // if (director == aDirector)
        //     Debug.Log("PlayableDirector named " + aDirector.name + " is now stopped.");
    }
    void OnPlayableDirectorStopped(PlayableDirector aDirector)
    {
        aDirector.gameObject.SetActive(false);
        GameObject.FindGameObjectWithTag("Player").gameObject.GetComponent<PlayerMovement>().allowedToMove = true;
        // if (director == aDirector)
        //     Debug.Log("PlayableDirector named " + aDirector.name + " is now stopped.");
    }
    // void FixedUpdate() {
    //     //checkObjComplete();
    //     currentObjective.checkIfComplete(currentObjective);
    // }
    void OpenNote()
    {
        if (!audioSrc.GetComponent<AudioSource>().isPlaying)
        {
            audioSrc.GetComponent<AudioSource>().Play();
        }
        this.activeNote.GetComponent<Note>().disableEffects();
        canvas.transform.GetChild(1).gameObject.SetActive(false);
        canvas.transform.GetChild(1).gameObject.transform.GetChild(0).gameObject.GetComponent<Text>().text = "";
        notesCanvas.gameObject.SetActive(true);
        var noteInInventory = Instantiate(notePrefab, new Vector3(0, 0, 0), Quaternion.identity);

        noteInInventory.transform.GetChild(0).gameObject.GetComponent<TextMeshProUGUI>().text = this.activeNote.GetComponent<Note>().title;
        noteInInventory.transform.SetParent(notesPanel.transform);
        noteInInventory.GetComponent<Button>().onClick.AddListener(delegate { inventoryManager.GetComponent<InventoryManager>().OnClickNoteButton(noteInInventory); });
        inventoryManager.GetComponent<InventoryManager>().notes.Add(this.activeNote);
        ES3.Save<int>("notesCollectedLengthMission_2", inventoryManager.GetComponent<InventoryManager>().notes.Count);
        ES3.Save<int>("Note_" + notes.IndexOf(this.activeNote), notes.IndexOf(this.activeNote));
        this.activeNote = null;
    }
    public void prepareNote(int index)
    {
        this.activeNote = notes[index];
        this.activeNote.GetComponent<Note>().disableEffects();
        canvas.transform.GetChild(1).gameObject.SetActive(false);
        canvas.transform.GetChild(1).gameObject.transform.GetChild(0).gameObject.GetComponent<Text>().text = "";
        //notesCanvas.gameObject.SetActive(true);
        var noteInInventory = Instantiate(notePrefab, new Vector3(0, 0, 0), Quaternion.identity);

        noteInInventory.transform.GetChild(0).gameObject.GetComponent<TextMeshProUGUI>().text = this.activeNote.GetComponent<Note>().title;
        noteInInventory.transform.SetParent(notesPanel.transform);
        noteInInventory.GetComponent<Button>().onClick.AddListener(delegate { inventoryManager.GetComponent<InventoryManager>().OnClickNoteButton(noteInInventory); });
        inventoryManager.GetComponent<InventoryManager>().notes.Add(this.activeNote);
        //notes.RemoveAt(index);
        this.activeNote = null;
    }
    void CloseNote()
    {
        // audioSrc.GetComponent<AudioSource>().clip =  (AudioClip) Resources.Load("Audio/Writing_Sound", typeof(AudioClip));
        if (!audioSrc.GetComponent<AudioSource>().isPlaying)
        {
            audioSrc.GetComponent<AudioSource>().Play();
        }
        noteTitle.text = "";
        noteContent.text = "";
        notesCanvas.gameObject.SetActive(false);
        this.activeNote = null;
    }
    void showOpenNoteToggle(GameObject nearNote)
    {
        audioSrc.GetComponent<AudioSource>().clip = null;
        isCloseToNote = true;
        canvas.transform.GetChild(1).gameObject.transform.GetChild(0).gameObject.GetComponent<Text>().text = "Press R to Read Note";
        canvas.transform.GetChild(1).gameObject.SetActive(true);
        noteTitle.text = nearNote.GetComponent<Note>().title;
        noteContent.text = nearNote.GetComponent<Note>().content;
        this.activeNote = nearNote;
        Debug.Log("active note: " + this.activeNote);
        nearNote.GetComponent<Note>().isOpened = true;
        
    }
    void OpenNewspaper()
    {

        if (!audioSrc.GetComponent<AudioSource>().isPlaying)
        {
            audioSrc.GetComponent<AudioSource>().Play();
        }
        this.activeNewspaper.GetComponent<Newspaper>().disableEffects();
        canvas.transform.GetChild(1).gameObject.SetActive(false);
        canvas.transform.GetChild(1).gameObject.transform.GetChild(0).gameObject.GetComponent<Text>().text = "";
        newsPaperCanvas.gameObject.SetActive(true);
        var newspaperInInventory = Instantiate(newsPaperPrefab, new Vector3(0, 0, 0), Quaternion.identity);

        newspaperInInventory.transform.GetChild(0).gameObject.GetComponent<TextMeshProUGUI>().text = this.activeNewspaper.GetComponent<Newspaper>().sprite.name;
        newspaperInInventory.transform.SetParent(newsPaperPanel.transform);
        newspaperInInventory.GetComponent<Button>().onClick.AddListener(delegate { inventoryManager.GetComponent<InventoryManager>().OnClickNewspaperButton(newspaperInInventory); });
        inventoryManager.GetComponent<InventoryManager>().newspapers.Add(this.activeNewspaper);
        ES3.Save<int>("newsPaperCollectedLengthMission_2", inventoryManager.GetComponent<InventoryManager>().newspapers.Count);
        ES3.Save<int>("Note_" + newsPapers.IndexOf(this.activeNewspaper), newsPapers.IndexOf(this.activeNewspaper));
        this.activeNewspaper = null;
    }
    public void prepareNewspaper(int index)
    {


        this.activeNewspaper = newsPapers[index];
        this.activeNewspaper.GetComponent<Newspaper>().disableEffects();
        canvas.transform.GetChild(1).gameObject.SetActive(false);
        canvas.transform.GetChild(1).gameObject.transform.GetChild(0).gameObject.GetComponent<Text>().text = "";
        //newsPaperCanvas.gameObject.SetActive(true);
        var newspaperInInventory = Instantiate(newsPaperPrefab, new Vector3(0, 0, 0), Quaternion.identity);

        newspaperInInventory.transform.GetChild(0).gameObject.GetComponent<TextMeshProUGUI>().text = this.activeNewspaper.GetComponent<Newspaper>().sprite.name;
        newspaperInInventory.transform.SetParent(newsPaperPanel.transform);
        newspaperInInventory.GetComponent<Button>().onClick.AddListener(delegate { inventoryManager.GetComponent<InventoryManager>().OnClickNewspaperButton(newspaperInInventory); });
        inventoryManager.GetComponent<InventoryManager>().newspapers.Add(this.activeNewspaper);
        this.activeNewspaper = null;

    }
    void CloseNewspaper()
    {
        if (!audioSrc.GetComponent<AudioSource>().isPlaying)
        {
            audioSrc.GetComponent<AudioSource>().Play();
        }
        newsPaperImage.GetComponent<Image>().sprite = null;
        newsPaperCanvas.gameObject.SetActive(false);
        this.activeNewspaper = null;
    }
    void showOpenNewspaperToggle(GameObject nearNewsPaper)
    {
        audioSrc.GetComponent<AudioSource>().clip = null;
        isCloseToNewspaper = true;
        canvas.transform.GetChild(1).gameObject.transform.GetChild(0).gameObject.GetComponent<Text>().text = "Press N to View News";
        canvas.transform.GetChild(1).gameObject.SetActive(true);
        newsPaperImage.GetComponent<Image>().sprite = nearNewsPaper.gameObject.GetComponent<Newspaper>().sprite;
        //noteContent.text = nearNewsPaper.GetComponent<Note>().content;
        this.activeNewspaper = nearNewsPaper;
        nearNewsPaper.GetComponent<Newspaper>().isRead = true;
    }
}
