using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;
using TMPro;
using UnityEngine.Playables;
using PixelCrushers.DialogueSystem;

public class MissionOne : Mission
{
    public delegate void ChangeObjective(Objective nextObj);
    public static event ChangeObjective onChangeObj;
    private GameObject secretary;

    private Objective currentObjective;

    public event Objective.CompleteObjective onCompleteObj;

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
    public MissionOne()
    {
        objectives = new List<Objective>();
        quizQuestions = new List<QuizQuestion>();
        //objectives[0].checkIfComplete = this.x;
        ////////////////////////////////////////////////////////////////////////////////////////////////////////////
        objectives.Add(new Objective("ﺍﺩﺧﻞ ﺍﻟﻤﺒﻨﻲ", 10, 10, false, this.checkFirstObjectiveComplete));

        objectives.Add(new Objective("ﺗﺤﺪﺙ ﺍﻟﻲ ﺍﻟﻤﻀﻴﻔﻪ", 10, 10, false, this.checkSecondObjectiveComplete));

        objectives.Add(new Objective("ﺍﺿﻐﻂ I ﻟﻔﺘﺢ ﺍﻟﺘﺎﺑﻠﺖ ﺍﻟﺨﺎﺹ ﺑﻚ ﺛﻢ ﺍﻓﺘﺢ ﺑﺮﻧﺎﻣﺞ ﺍﻷﺳﺌﻠﺔ", 10, 10, false, this.checkThirdObjectiveComplete));
        
        objectives.Add(new Objective("ﺍﺟﺐ ﻋﻦ ﺍﻷﺳﺌﻠﺔ", 10, 10, false, this.checkFourthObjectiveComplete));

        objectives.Add(new Objective("ﺍﻏﻠﻖ ﺍﻟﺒﺮﻧﺎﻣﺞ ﻭ ﺍﺿﻐﻂ I ﻻﻏﻼﻕ ﺍﻟﺘﺎﺑﻠﺖ", 10, 10, false, this.checkFifthObjectiveComplete));
        ///////////////////////////////////////////////////////////////////////////////////////////////////////////

        objectives.Add(new Objective("ﺍﺫﻫﺐ ﺍﻟﻲ ﺍﻟﻤﻜﺎﺗﺐ", 10, 10, false, this.checkFirstObjectiveComplete));

        objectives.Add(new Objective("ﺗﺤﺪﺙ ﻣﻊ ﺍﻟﻤﻮﻇﻒ ﻋﻦ ﺍﻷﺳﻬﻢ", 10, 10, false, this.checkSecondObjectiveComplete));

        objectives.Add(new Objective("ﺍﺿﻐﻂ I ﻟﻔﺘﺢ ﺍﻟﺘﺎﺑﻠﺖ ﺍﻟﺨﺎﺹ ﺑﻚ ﺛﻢ ﺍﻓﺘﺢ ﺑﺮﻧﺎﻣﺞ ﺍﻷﺳﺌﻠﺔ", 10, 10, false, this.checkThirdObjectiveComplete));
        
        objectives.Add(new Objective("ﺍﺟﺐ ﻋﻦ ﺍﻷﺳﺌﻠﺔ", 20, 20, false, this.checkFourthObjectiveComplete));

        objectives.Add(new Objective("ﺍﻏﻠﻖ ﺍﻟﺒﺮﻧﺎﻣﺞ ﻭ ﺍﺿﻐﻂ I ﻻﻏﻼﻕ ﺍﻟﺘﺎﺑﻠﺖ", 10, 10, false, this.checkFifthObjectiveComplete));

        ///////////////////////////////////////////////////////////////////////////////////////////////////////////
        
        objectives.Add(new Objective("ﺍﺫﻫﺐ ﺍﻟﻲ ﺍﻟﻤﻮﻇﻒ ﺍﻟﺘﺎﻟﻲ", 10, 10, false, this.checkFirstObjectiveComplete));

        objectives.Add(new Objective("ﺗﺤﺪﺙ ﻣﻊ ﺍﻟﻤﻮﻇﻒ ﻋﻦ ﺍﻟﺴﻨﺪﺍﺕ", 10, 10, false, this.checkSecondObjectiveComplete));

        objectives.Add(new Objective("ﺍﺿﻐﻂ I ﻟﻔﺘﺢ ﺍﻟﺘﺎﺑﻠﺖ ﺍﻟﺨﺎﺹ ﺑﻚ ﺛﻢ ﺍﻓﺘﺢ ﺑﺮﻧﺎﻣﺞ ﺍﻷﺳﺌﻠﺔ", 10, 10, false, this.checkThirdObjectiveComplete));
        
        objectives.Add(new Objective("ﺍﺟﺐ ﻋﻦ ﺍﻷﺳﺌﻠﺔ", 30, 30, false, this.checkFourthObjectiveComplete));

        objectives.Add(new Objective("ﺍﻏﻠﻖ ﺍﻟﺒﺮﻧﺎﻣﺞ ﻭ ﺍﺿﻐﻂ I ﻻﻏﻼﻕ ﺍﻟﺘﺎﺑﻠﺖ", 10, 10, false, this.checkFifthObjectiveComplete));

        ///////////////////////////////////////////////////////////////////////////////////////////////////////////
        
        objectives.Add(new Objective("ﺍﺫﻫﺐ ﺍﻟﻲ ﺍﻟﺴﻤﺴﺎﺭ ﻓﻲ ﺍﻟﻄﺎﺑﻖ ﺍﻟﻌﻠﻮﻱ", 10, 10, false, this.checkFirstObjectiveComplete));

        objectives.Add(new Objective("ﺗﺤﺪﺙ ﻣﻊ ﺍﻟﺴﻤﺴﺎﺭ", 10, 10, false, this.checkSecondObjectiveComplete));




        objectives.Add(new Objective("ﺍﻓﺘﺢ ﺍﻟﻮﺭﻗﻪ ﺍﻣﺎﻣﻚ", 10, 10, false, this.checkIfNotePickedObjectiveComplete));




        objectives.Add(new Objective("ﺍﺿﻐﻂ I ﻟﻔﺘﺢ ﺍﻟﺘﺎﺑﻠﺖ ﺍﻟﺨﺎﺹ ﺑﻚ ﺛﻢ ﺍﻓﺘﺢ ﺑﺮﻧﺎﻣﺞ ﺍﻷﺳﺌﻠﺔ", 10, 10, false, this.checkThirdObjectiveComplete));
        
        objectives.Add(new Objective("ﺍﺟﺐ ﻋﻦ ﺍﻷﺳﺌﻠﺔ", 40, 40, false, this.checkFourthObjectiveComplete));

        objectives.Add(new Objective("ﺍﻏﻠﻖ ﺍﻟﺒﺮﻧﺎﻣﺞ ﻭ ﺍﺿﻐﻂ I ﻻﻏﻼﻕ ﺍﻟﺘﺎﺑﻠﺖ", 10, 10, false, this.checkFifthObjectiveComplete));
        

        quizQuestions.Add(new QuizQuestion(" ﻣﺎ ﻫﻲ ﻃﺒﻴﻌﻪ ﺍﻷﺳﺘﺜﻤﺎﺭ ﻓﻲ ﺍﻟﺒﻮﺭﺻﻪ ؟", new List<string>(){"ﺃﺳﺘﺜﻘﻤﺎﺭ ﻗﺼﻴﺮ ﺍﻷﺟﻞ", "ﺃﺳﺘﺜﻤﺎﺭ ﻃﻮﻳﻞ ﺍﻷﺟﻞ", "ﺃﺳﺘﺜﻤﺎﺭ ﻭﻫﻤﻲ","ﻛﻞ ﻣﺎ ﺳﺒﻖ"}, 1));
        quizQuestions.Add(new QuizQuestion("ﻣﻦ ﻣﻤﻴﺰﺍﺕ ﺍﻟﺒﻮﺭﺻﻪ ؟",  new List<string>(){"ﺳﻮﻕ ﻣﻨﻈﻤﺔ ﻟﺸﺮﺍﺀ ﻭ ﺑﻴﻊ ﺍﻷﻭﺭﺍﻕ ﺍﻟﻤﺎﻟﻴﺔ", "ﺳﻮﻕ ﻣﻨﻈﻤﺔ ﻟﺸﺮﺍﺀ ﻭ ﺑﻴﻊ ﺍﻟﺒﻀﺎﺋﻊ", "ﺳﻮﻕ ﺗﺪﺍﻭﻝ ﻭﻫﻤﻲ","ﻛﻞ ﻣﺎ ﺳﺒﻖ"}, 0));
        quizQuestions.Add(new QuizQuestion("ﻣﺎ ﻫﻲ ﺍﻷﺷﻴﺎﺀ ﺍﻟﺘﻲ ﺗﺆﺛﺮ ﻋﻠﻲ ﺳﻌﺮ ﺍﻷﻭﺭﺍﻕ ﺍﻟﻤﺎﻟﻴﺔ ؟",  new List<string>(){"ﺍﻟﻌﺮﺽ ﻭ ﺍﻟﻄﻠﺐ", "ﺍﻟﻤﻨﺎﺥ ﺍﻟﻌﺎﻡ ﻟﻠﺪﻭﻝ", "ﺍﻟﺸﺆﻥ ﺍﻟﺘﻌﻠﻴﻤﻴﻪ","ﻛﻞ ﻣﺎ ﺳﺒﻖ"}, 0));
        quizQuestions.Add(new QuizQuestion("ﻣﺎ ﻫﻲ ﻣﺤﺘﻮﻳﺎﺕ ﺍﻷﻭﺭﺍﻕ ﺍﻟﻤﺎﻟﻴﺔ ؟",  new List<string>(){"ﺍﻷﺳﻬﻢ", "ﺍﻟﺴﻨﺪﺍﺕ", "ﻭﺛﺎﺋﻖ ﺻﻨﺎﺩﻳﻖ ﺍﻟﻤﺆﺷﺮ","ﻛﻞ ﻣﺎ ﺳﺒﻖ"}, 3));
        quizQuestions.Add(new QuizQuestion("ﻣﺎ ﻫﻮ ﺍﻟﻤﺼﻄﻠﺢ ﺍﻟﺬﻱ ﻳﻄﻠﻖ ﻋﻠﻲ ﺍﻷﺳﻬﻢ ﺍﻭ ﺍﻟﺴﻨﺪﺍﺕ ﻋﻨﺪﻣﺎ ﺗﻘﺮﺭ ﺍﻟﺸﺮﻛﺔ ﺑﻴﻌﻬﻢ ﻓﻲ ﺳﻮﻕ ﺍﻟﺒﻮﺭﺻﺔ ؟",  new List<string>(){"ﺍﻟﻄﺮﺡ", "ﺍﻷﺭﺑﺎﺡ", "ﺍﻟﻤﺆﺷﺮ","ﻛﻞ ﻣﺎ ﺳﺒﻖ"}, 0));



        quizQuestions.Add(new QuizQuestion("ﻣﺎ ﻫﻲ ﺍﻷﺷﻴﺎﺀ ﺍﻟﺘﻲ ﺗﻘﻮﻡ ﺑﻬﺎ ﺍﻟﺸﺮﻛﺎﺕ ﻟﻠﺤﺼﻮﻝ ﻋﻠﻲ ﺗﻤﻮﻳﻞ ؟", new List<string>(){"ﻣﻦ ﺧﻼﻝ ﺑﻴﻊ ﺍﻷﺳﻬﻢ", "ﻣﻦ ﺧﻼﻝ ﺍﻷﻗﺘﺮﺍﺽ", "ﻛﻞ ﻣﻦ  ﺃ & ﺏ","ﻣﻦ ﺧﻼﻝ ﺯﻳﺎﺩﻩ ﺍﻷﻧﺘﺎﺝ"}, 1));
        quizQuestions.Add(new QuizQuestion("ﻣﺎ ﻫﻲ ﺍﻟﻔﺘﺮﺍﺕ ﻟﺮﺩ ﻗﻴﻤﻪ ﺍﻟﻔﺎﺋﺪﻩ ﺍﻟﺨﺎﺻﻪ ﺑﺎﻟﺴﻨﺪﺍﺕ ؟",  new List<string>(){"3 ﺃﺷﻬﺮ", "6 ﺃﺷﻬﺮ", "21 ﺍﺷﻬﺮ","ﻛﻞ ﻣﺎ ﺳﺒﻖ"}, 3));
        quizQuestions.Add(new QuizQuestion("ﻣﺎ ﻫﻮ ﺍﻷﻗﻞ ﺧﻄﻮﺭﻩ ﻓﻲ ﺍﻷﺳﺘﺜﻤﺎﺭ ؟",  new List<string>(){"ﺍﻷﺳﺘﺜﻤﺎﺭ ﻓﻲ ﺍﻷﺳﻬﻢ", "ﺍﻷﺳﺘﺜﻤﺎﺭ ﻓﻲ ﺍﻟﺴﻨﺪﺍﺕ", "ﺍﻻﺳﺘﺜﻤﺎﺭ ﻓﻲ ﻭﺛﺎﺋﻖ ﺻﻨﺎﺩﻳﻖ ﺍﻟﻤﺆﺷﺮ","ﻛﻞ ﻣﺎ ﺳﺒﻖ"}, 1));
        quizQuestions.Add(new QuizQuestion("ﻛﻴﻔﻴﻪ ﺷﺮﺍﺀ ﺍﻷﺳﻬﻢ ﺃﻭ ﺍﻟﺴﻨﺪﺍﺕ ؟",  new List<string>(){"ﻣﻦ ﺷﺮﻛﻪ ﻭﺳﺎﻃﻪ ﻣﺎﻟﻴﻪ", "ﻣﻦ ﺧﻼﻝ ﺷﺮﻛﺎﺀ", "ﻣﻦ ﺍﻟﺒﻮﺭﺻﻪ","ﻛﻞ ﻣﺎ ﺳﺒﻖ"}, 0));
        quizQuestions.Add(new QuizQuestion("ﺍﻟﺨﺼﺎﺋﺺ ﺍﻟﺘﻲ ﻣﻦ ﺧﻼﻟﻬﺎ ﺗﺘﻤﻜﻦ ﻣﻦ ﺃﺧﺘﻴﺎﺭ ﺷﺮﻛﻪ ﺍﻟﺴﻤﺴﺮﻩ ؟",  new List<string>(){"ﻟﺪﻳﻬﺎ ﺗﺪﺍﻭﻝ ﺍﻟﻜﺘﺮﻭﻧﻲ", "ﻟﺪﻳﻬﺎ ﺧﺪﻣﻪ ﻋﻤﻼﺀ ﻭ ﺳﺮﻋﻪ ﻓﻲ ﺍﻟﺮﺩ", "ﺗﻜﻮﻥ ﺍﻟﻌﻤﻮﻟﺔ ﺍﻟﺨﺎﺻﻪ ﺑﻬﺎ ﻓﻲ ﺍﻟﻤﺘﻮﺳﻂ","ﻛﻞ ﻣﺎ ﺳﺒﻖ"}, 3));


        quizQuestions.Add(new QuizQuestion("ﻣﺎ ﻫﻮ ﻣﻔﻬﻮﻡ ﺍﻟﻤﺆﺷﺮ ؟", new List<string>(){"ﻫﻮ ﻣﺘﻮﺳﻂ ﺍﺳﻌﺎﺭ ﺍﺳﻬﻢ ﺍﻟﺸﺮﻛﺎﺕ ﺍﻟﻤﻜﻮﻧﺔ ﻟﻪ", "ﻫﻮ ﺍﻟﺤﺪ ﺍﻷﺩﻧﻲ ﻟﺴﻌﺮ ﺍﺳﻬﻢ ﺍﻟﺸﺮﻛﺎﺕ ﺍﻟﻤﻜﻮﻧﺔ ﻟﻪ", "ﻫﻮ ﺍﻟﺤﺪ ﺍﻷﻗﺼﻲ ﻟﺴﻌﺮ ﺍﺳﻬﻢ ﺍﻟﺸﺮﻛﺎﺕ ﺍﻟﻤﻜﻮﻧﺔ ﻟﻪ","ﻛﻞ ﻣﺎ ﺳﺒﻖ"}, 0));
        quizQuestions.Add(new QuizQuestion("ﻣﺎ ﻫﻮ ﻣﺆﺷﺮ 03 XGE ؟",  new List<string>(){"ﻫﻮ ﻣﺆﺷﺮ ﺳﻌﺮﻱ ﻳﻘﻴﺲ ﺍﺩﺍﺀ ﺍﻋﻠﻰ 03 ﺷﺮﻛﻪ ﻣﻦ ﺣﻴﺚ ﺍﻟﺴﻴﻮﻟﺔ ﻭﺍﻟﻨﺸﺎﻁ ﻓﻲ ﺍﻟﺒﻮﺭﺻﻪ ﺍﻟﻤﺼﺮﻳﺔ", "ﻫﻮ ﻣﺆﺷﺮ ﺳﻌﺮﻱ ﻳﻘﻴﺲ ﺍﺩﺍﺀ ﺍﻋﻠﻰ 02 ﺷﺮﻛﻪ ﻣﻦ ﺣﻴﺚ ﺍﻟﺴﻴﻮﻟﺔ ﻭﺍﻟﻨﺸﺎﻁ ﻓﻲ ﺍﻟﺒﻮﺭﺻﻪ ﺍﻟﻤﺼﺮﻳﺔ", "ﻫﻮ ﻣﺆﺷﺮ ﺳﻌﺮﻱ ﻳﻘﻴﺲ ﺍﺩﺍﺀ ﺍﺩﻧﻲ 03 ﺷﺮﻛﻪ ﻣﻦ ﺣﻴﺚ ﺍﻟﺴﻴﻮﻟﺔ ﻭﺍﻟﻨﺸﺎﻁ ﻓﻲ ﺍﻟﺒﻮﺭﺻﻪ ﺍﻟﻤﺼﺮﻳﺔ","ﻫﻮ ﻣﺆﺷﺮ ﺳﻌﺮﻱ ﻳﻘﻴﺲ ﺍﺩﺍﺀ ﺍﺩﻧﻲ 02 ﺷﺮﻛﻪ ﻣﻦ ﺣﻴﺚ ﺍﻟﺴﻴﻮﻟﺔ ﻭﺍﻟﻨﺸﺎﻁ ﻓﻲ ﺍﻟﺒﻮﺭﺻﻪ ﺍﻟﻤﺼﺮﻳﺔ"}, 0));
        quizQuestions.Add(new QuizQuestion("ﻣﺎ ﻫﻮ  ﻣﻔﻬﻮﻡ ﺳﻌﺮ ﺍﻻﻏﻼﻕ ؟",  new List<string>(){"ﻫﻮ ﺍﻟﺴﻌﺮ ﺍﻟﻨﻬﺎﺋﻲ ﺍﻟﺬﻱ ﻳﺘﻢ ﺗﺪﺍﻭﻟﻪ ﺧﻼﻝ ﺳﺎﻋﺎﺕ ﺍﻟﺴﻮﻕ ﺍﻟﻌﺎﺩﻳﺔ", "ﻫﻮ ﺍﻟﺴﻌﺮ ﺍﻟﻤﺒﺪﺃﻱ ﺍﻟﺬﻱ ﻳﺘﻢ ﺗﺪﺍﻭﻟﻪ ﺧﻼﻝ ﺳﺎﻋﺎﺕ ﺍﻟﺴﻮﻕ ﺍﻟﻌﺎﺩﻳﺔ", "ﻫﻮ ﺍﻟﺴﻌﺮ ﺍﻟﻤﺘﻮﺳﻂ ﺍﻟﺬﻱ ﻳﺘﻢ ﺗﺪﺍﻭﻟﻪ ﺧﻼﻝ ﺳﺎﻋﺎﺕ ﺍﻟﺴﻮﻕ ﺍﻟﻌﺎﺩﻳﺔ","ﻛﻞ ﻣﺎ ﺳﺒﻖ"}, 0));
        quizQuestions.Add(new QuizQuestion("ﻛﻴﻔﻴﻪ ﺍﻟﺤﺼﻮﻝ ﻋﻠﻲ ﺍﻟﻜﻮﺩ ﺍﻟﺨﺎﺹ ﺑﺎﻟﺘﺪﺍﻭﻝ ؟",  new List<string>(){"ﻳﺘﻢ ﺍﻟﺤﺼﻮﻝ ﻋﻠﻴﻪ ﻣﻦ ﺧﻼﻝ ﺍﻟﺘﻌﺎﻗﺪ ﻣﻊ ﺍﻱ ﺷﺮﻛﻪ ﻭﺳﺎﻃﺔ ﻣﺎﻟﻴﻪ", "ﻳﺘﻢ ﺍﻟﺤﺼﻮﻝ ﻋﻠﻴﻪ ﺑﺪﻭﻥ ﺍﻱ ﺷﺮﻭﻁ ﻣﺴﺒﻘﻪ", "ﻳﺘﻢ ﺍﻟﺤﺼﻮﻝ ﻋﻠﻴﻪ ﺑﻤﺠﺮﺩ ﺩﺧﻮﻟﻚ ﺍﻟﺒﻮﺭﺻﻪ","ﻛﻞ ﻣﺎ ﺳﺒﻖ"}, 0));
        quizQuestions.Add(new QuizQuestion("ﻛﻴﻒ ﺗﻜﻮﻥ ﺣﻤﺎﻳﻪ ﺍﻣﻮﺍﻟﻚ ﻣﻦ ﺍﻟﻨﺼﺐ ﻭ ﺍﻻﺣﺘﻴﺎﻝ ؟",  new List<string>(){"ﻣﻦ ﺧﻼﻝ ﺻﻨﺪﻭﻕ ﺣﻤﺎﻳﻪ ﺍﻟﻤﺴﺘﺜﻤﺮ ﺑﻴﻌﻮﺿﻚ ﻭﻓﻘﺎ ﻟﻠﻘﻮﺍﻋﺪ ﺍﻟﻤﻌﻤﻮﻝ ﺑﻬﺎ", "ﻻ ﻳﻮﺟﺪ ﺍﻱ ﺣﻤﺎﻳﺎﺕ ﺍﻭ ﺿﻤﺎﻧﺎﺕ", "ﻻ ﻳﻮﺟﺪ ﻧﺼﺐ ﺍﻭ ﺍﺣﺘﻴﺎﻝ ﻣﻦ ﺍﻷﺳﺎﺱ","ﻛﻞ ﻣﻦ ﺏ ﻭ ﺝ"}, 0));





        quizQuestions.Add(new QuizQuestion("ﻛﻴﻒ ﻳﻜﻮﻥ ﺍﺧﺘﻴﺎﺭ ﺍﻟﺴﻤﺴﺎﺭ ؟", new List<string>(){"ﺍﻥ ﻳﻜﻮﻥ ﻣﺴﺠﻞ ﺣﻴﺚ ﺍﻥ ﺍﻟﻬﻴﺌﺔ ﺍﻟﻌﺎﻣﺔ ﻟﻠﺮﻗﺎﺑﺔ ﺍﻟﻤﺎﻟﻴﺔ ﻭﺍﻟﺒﻮﺭﺻﺔ ﺍﻟﻤﺼﺮﻳﺔ", "ﺍﻥ ﻳﻜﻮﻥ ﻣﺴﺠﻞ ﻓﻲ ﺍﻟﻬﻴﺌﺔ ﺍﻟﻌﺎﻣﺔ ﻟﻠﺮﻗﺎﺑﺔ ﻋﻠﻲ ﺍﻟﺠﻮﺩﻩ", "ﺍﻥ ﻳﻜﻮﻥ ﺳﻴﺊ ﺍﻟﺴﻤﻌﻪ","ﻛﻞ ﻣﻦ ﺃ ﻭ ﺏ"}, 0));
        quizQuestions.Add(new QuizQuestion("ﻣﺎ ﻣﻴﺰﻩ ﺍﻥ ﻳﻜﻮﻥ ﺍﻟﺴﻤﺴﺎﺭ ﻣﺴﺠﻞ ﻓﻲ ﺍﻟﻬﻴﺌﻪ ﺍﻟﻌﺎﻣﻪ ﻟﻠﺮﻗﺎﺑﻪ ﺍﻟﻤﺎﻟﻴﻪ ؟",  new List<string>(){"ﺍﻥ ﺍﻟﻬﻴﺌﺔ ﺍﻟﻌﺎﻣﺔ ﻟﻠﺮﻗﺎﺑﺔ ﺍﻟﻤﺎﻟﻴﺔ ﻭﺍﻟﺒﻮﺭﺻﺔ ﺍﻟﻤﺼﺮﻳﺔ ﺑﺘﺤﺘﻔﻆ ﺑﺴﺠﻼﺕ ﺗﺎﺭﻳﺨﻴﻪ ﻟﻜﻞ ﻣﻨﻔﺬﻱ ﺷﺮﻛﺎﺕ ﺍﻟﺴﻤﺴﺮﺓ", "ﺍﻥ ﻳﻜﻮﻥ ﻣﻦ ﺍﻟﺴﻬﻞ ﺗﺘﺒﻊ ﺍﻧﺠﺎﺯﺍﺗﻪ", "ﺍﻥ ﻳﻜﻮﻥ ﻣﻦ ﺍﻟﺴﻬﻞ ﻋﻠﻲ ﺍﻟﺴﻤﺴﺎﺭ ﺍﻳﺠﺎﺩﻩ ﻋﻨﺪ ﺣﺪﻭﺙ ﺍﻱ ﻣﺸﻜﻠﻪ","ﻛﻞ ﻣﺎ ﺳﺒﻖ"}, 0));
        
        quizQuestions.Add(new QuizQuestion("ﻧﻘﺎﻁ ﺍﻟﺘﻔﺮﻳﻖ ﺑﻴﻦ ﺍﺛﻨﻴﻦ ﻣﻦ ﺍﻟﻤﻨﻔﺬﻳﻦ ؟",  new List<string>(){"ﻃﻠﺐ ﺍﻟﻜﺘﻴﺐ ﺍﻟﺨﺎﺹ ﺑﻪ", "ﺍﻟﺴﺆﺍﻝ ﻋﻦ ﺍﻟﻌﻤﻮﻟﻪ ﻭ ﺍﻟﻤﻔﺎﺿﻠﻪ ﻣﻦ ﺧﻼﻟﻬﺎ", "ﺍﻟﺴﺆﺍﻝ ﻋﻦ ﻋﻼﻗﺘﻪ ﺍﻷﺟﺘﻤﺎﻋﻴﻪ","ﻛﻞ ﻣﻦ ﺃ ﻭ ﺏ"}, 3));
        
        quizQuestions.Add(new QuizQuestion("ﻣﺎ ﻫﻲ ﺍﺳﺒﺎﺏ ﺍﻟﻤﺸﺎﻛﻞ ﺑﻴﻦ ﺍﻟﻤﺴﺘﺜﻤﺮ ﻭ ﺍﻟﺴﻤﺴﺎﺭ ؟",  new List<string>(){"ﺑﺴﺒﺐ ﺍﻥ ﺗﻮﻗﻌﺎﺕ ﺍﻟﻤﺴﺘﺜﻤﺮ ﺗﻜﻮﻥ ﻏﻴﺮ ﻭﺍﻗﻌﻴﻪ", "ﺍﻟﻌﻤﻠﻴﺎﺕ ﺍﻟﺘﻲ ﻳﻤﻜﻦ ﺍﻥ ﺗﺘﻢ ﺑﺪﻭﻥ ﺍﺫﻥ ﻣﺴﺒﻖ ﻣﻦ ﺍﻟﻤﺴﺘﺜﻤﺮ", "ﺑﺴﺒﺐ ﻋﺪﻡ ﺗﺒﺎﺩﻝ ﺍﻟﺜﻘﻪ ﻭ ﺍﻟﻤﻌﻠﻮﻣﺎﺕ ﻓﻴﻤﺎ ﺑﻴﻨﻬﻤﺎ","ﻛﻞ ﻣﻦ ﺃ ﻭ ﺏ"}, 3));
        
        quizQuestions.Add(new QuizQuestion("ﻣﻦ ﻣﻤﻴﺰﺍﺕ ﺍﻷﺳﺘﺜﻤﺎﺭ ﻓﻲ ﺍﻟﺒﻮﺭﺻﻪ ﺍﻟﻤﺼﺮﻳﺔ ؟",  new List<string>(){"ﺍﺭﺑﺎﺡ ﺍﻟﺸﺮﻛﻪ ﺗﻮﺯﻉ ﻋﻠﻲ ﻣﺴﺎﻫﻤﻴﻬﺎ ﻓﻲ ﺻﻮﺭﻩ ﻛﻮﺑﻮﻥ", "ﺍﻟﻌﺎﺋﺪ ﺍﻟﺮﺃﺱ ﺍﻟﻤﺎﻟﻲ ﻭ ﻫﻮ ﺍﻟﻔﺮﻕ ﺑﻴﻦ ﺳﻌﺮ ﺍﻟﺒﻴﻊ ﻭ ﺳﻌﺮ ﺷﺮﺍﺀ ﺍﻟﺴﻬﻢ", "ﺑﺴﺒﺐ ﺳﻬﻮﻟﻪ ﺍﻟﻤﻜﺴﺐ","ﻛﻞ ﻣﻦ أ ﻭ ب"}, 3));




        currentObjective = objectives[0].instance;

        Objective.onCompleteObj += checkObjComplete;

        dialogues = new List<Dialogue>();
       
        

    }
    void Start() {
        //cutscenePoints = new List<GameObject>();
        secretary = GameObject.FindGameObjectWithTag("Female NPC - Secretary");
        onCompleteObj =  currentObjective.setOnCompleteObj(this);
        var firstDialogueLines = new List<DialogueLine>();
        // firstDialogueLines.Add(new DialogueLine(secretary, "Reciptionist",0, "لا عليك فذلك من واجبنا يسعدنا نجاحك"));
        // firstDialogueLines.Add(new DialogueLine(GameObject.FindGameObjectWithTag("Player"), "Player",1, "اممم معذره لما كان كل ذلك الثناء قد كان كمان انجب طفلا للتو"));
        //notes = notesParent.transform.getChi
        // dialogues.Add(new Dialogue(GameObject.FindGameObjectWithTag("Player"), secretary, firstDialogueLines));
        if(newsPaperParent.transform.childCount > 0){
             for(var i = 0 ; i < newsPaperParent.transform.childCount ; i++){
                 newsPapers.Add(newsPaperParent.transform.GetChild(i).gameObject.transform.GetChild(1).gameObject); 
                //  360
             }
             newsPapers[0].AddComponent<Newspaper>();
             newsPapers[0].GetComponent<Newspaper>().changeNewspaperSprite((Sprite) Resources.Load("Sprites/Missions/MissionOne/Newspaper/NP_MissionOne_01", typeof(Sprite)), (Material)Resources.Load("Materials/Missons/MissionOne/Newspapers/NP_MissionOne_Material", typeof(Material)));
             Newspaper.onNotifyClosenessToNewspaper += this.showOpenNewspaperToggle;
        }

         if(notesParent.transform.childCount > 0){
             for(var i = 0 ; i < notesParent.transform.childCount ; i++){
                 notes.Add(notesParent.transform.GetChild(i).gameObject.transform.GetChild(1).gameObject); 
                //  360
             }
            notes[0].AddComponent<Note>();
            notes[0].GetComponent<Note>().title = "First Note";
            notes[0].GetComponent<Note>().content = "Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book. It has survived not only five centuries, but also the leap into electronic typesetting, remaining essentially unchanged. It was popularised in the 1960s with the release of Letraset sheets containing Lorem Ipsum passages, and more recently with desktop publishing software like Aldus PageMaker including versions of Lorem Ipsum.";

            notes[1].AddComponent<Note>();
            notes[1].GetComponent<Note>().title = "Second Note";
            notes[1].GetComponent<Note>().content = "Lorem Ipsum is simply dummy text of the print";
            //notesParent.transform.GetChild(0).gameObject.GetComponent<Note>().title = "First Note";
            // newNote = new Note("First Note", "Lorem 1", notesParent.transform.GetChild(0).gameObject);
            //Debug.Log(notesParent.transform.GetChild(0).gameObject.transform.GetChild(1).gameObject.GetComponent<Note>().content);   
            Note.onNotifyClosenessToNote += this.showOpenNoteToggle;
            InvokeRepeating("checkObjectivesVoid", 1.0f, 0.5f);
        }
    }

    private void checkFirstObjectiveComplete(Objective obj){
        Debug.Log("This: "+ this);
        Debug.Log("obj: "+ obj.instance);
        //Debug.Log(GameObject.FindGameObjectWithTag("Player").transform.position);
        //Debug.Log(cutscenePoints[this.currentIndex].transform.position);
        Debug.Log("x: "+ GameObject.FindGameObjectWithTag("Player").transform.position);
        Debug.Log("y: "+ this.currentIndex);
        if(Vector3.Distance(GameObject.FindGameObjectWithTag("Player").transform.position,cutscenePoints[this.currentIndex].gameObject.transform.position) <= 5){
            if(onCompleteObj != null){
                onCompleteObj();
                obj.instance.isComplete = true;
                Debug.Log("INNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNN");
                //canvas.transform.GetChild(2).gameObject.transform.GetChild(0).gameObject.GetComponent<Text>().text = "Press E to Speak";
                //canvas.transform.GetChild(2).gameObject.SetActive(true);
                this.currentIndex++;
            }
            }
    }
    private void checkSecondObjectiveComplete(Objective obj){
        if(!GameObject.FindObjectOfType<DialogueSystemController>().isConversationActive)
        {
            if(onCompleteObj != null){
                if (objectives.IndexOf(obj) == 16) {
                    notesParent.transform.GetChild(2).gameObject.SetActive(true);
                    notes.Add(notesParent.transform.GetChild(2).gameObject);
                    notes[2].AddComponent<Note>();
                    notes[2].GetComponent<Note>().title = "Your Code";
                    notes[2].GetComponent<Note>().content = "YXWQEQW920000232";
                }
                onCompleteObj();
                obj.instance.isComplete = true;
                this.activeCutScene = null;
                //this.prepareFirstQuiz();
                quizAppButton.onClick.AddListener(delegate {this.quizAppButtonClicked(obj); });
                //Debug.Log("dONE 2");
            }
        }
    }
    void quizAppButtonClicked(Objective obj){
        currentObjective.checkIfComplete(new Objective());
    }
    private void checkThirdObjectiveComplete(Objective obj){
        if(String.IsNullOrEmpty(obj.title) && inventoryManager.transform.GetChild(0).gameObject.active && GameObject.FindObjectOfType<InventoryManager>().finishedQuiz == false){
            if(onCompleteObj != null){
                onCompleteObj();
                currentObjective.isComplete = true;
                //Debug.Log("dONE 2");
                quizAppButton.onClick.RemoveListener(delegate {this.quizAppButtonClicked(obj); });
            }
        }
        
    }
    private void checkFourthObjectiveComplete(Objective obj){
        if(GameObject.FindObjectOfType<InventoryManager>().checkForObjForth()){
            if(onCompleteObj != null){
                onCompleteObj();
                obj.instance.isComplete = true;
                // quizQuestions = 
                //Debug.Log("dONE 2");
            }
        }
    }
    private void checkFifthObjectiveComplete(Objective obj){
        if(!inventoryManager.transform.GetChild(0).gameObject.active){
            if(onCompleteObj != null){
                onCompleteObj();
                obj.instance.isComplete = true;
                //Debug.Log("dONE 2");
            }
            
        }
    }

    private void checkIfNotePickedObjectiveComplete(Objective obj)
    {
        if (inventoryManager.GetComponent<InventoryManager>().notes.Contains(notes[2]))
        {
            if (onCompleteObj != null)
            {
                onCompleteObj();
                obj.instance.isComplete = true;
                //Debug.Log("dONE 2");
            }

        }
    }

    void FixedUpdate(){
        if(this.activeNote != null && Input.GetKeyDown(KeyCode.R)){
            audioSrc.GetComponent<AudioSource>().clip =  (AudioClip) Resources.Load("Audio/paper_flip", typeof(AudioClip));
            OpenNote();
        } else if(this.activeNote == null && Input.GetKeyDown(KeyCode.R)){
            audioSrc.GetComponent<AudioSource>().clip =  (AudioClip) Resources.Load("Audio/Writing_Sound", typeof(AudioClip));
            CloseNote();
        }

        if(this.activeNewspaper != null && Input.GetKeyDown(KeyCode.N)){
            audioSrc.GetComponent<AudioSource>().clip =  (AudioClip) Resources.Load("Audio/paper_flip", typeof(AudioClip));
            OpenNewspaper();
        } else if(this.activeNewspaper == null && Input.GetKeyDown(KeyCode.N)){
            audioSrc.GetComponent<AudioSource>().clip =  (AudioClip) Resources.Load("Audio/paper_flip", typeof(AudioClip));
            //  audioSrc.GetComponent<AudioSource>().clip =  (AudioClip) Resources.Load("Audio/Writing_Sound", typeof(AudioClip));
            CloseNewspaper();
        }
        // Debug.Log(Vector3.Distance(cutscenePoints[0].transform.position, GameObject.FindGameObjectWithTag("Player").transform.position));
        for(var i = 0; i < cutscenePoints.Count; i++){
            if(Input.GetKey(KeyCode.H) && this.activeCutScene != null){
                this.activeCutScene.GetComponent<PlayableDirector>().Stop();
                // this.activeCutScene = null;
            }
            if(finishedCutscenePoints.Exists(c => c == cutscenePoints[i])){
                continue;
            }else {
                if(this.activeCutScene != null){
                   //Debug.Log(this.activeCutScene.GetComponent<PlayableDirector>().state);
                }
                if(Vector3.Distance(cutscenePoints[i].transform.position, GameObject.FindGameObjectWithTag("Player").transform.position) <= 1){
                    cutscenesParent.transform.GetChild(i).gameObject.SetActive(true);
                    this.activeCutScene = cutscenesParent.transform.GetChild(i).gameObject;
                    // cutscenesParent.transform.GetChild(i).gameObject.GetComponent<PlayableDirector>().Play();
                    GameObject.FindGameObjectWithTag("Player").gameObject.GetComponent<PlayerMovement>().allowedToMove = false;
                    //cutscenesParent.transform.GetChild(i).gameObject.GetComponent<PlayableDirector>().played += OnPlayableDirectorStarted;
                    cutscenesParent.transform.GetChild(i).gameObject.GetComponent<PlayableDirector>().stopped += OnPlayableDirectorStopped;
                    // cutscenesParent.transform.GetChild(i).gameObject.GetComponent<PlayableDirector>()
                    if (i == 0) {
                        manAtFirst.GetComponent<DialogueSystemTrigger>().enabled = true;
                        GameObject.FindGameObjectWithTag("Player").GetComponents<DialogueSystemTrigger>()[0].enabled = true;
                    } else if (i == 1) {
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
    void checkObjectivesVoid(){
        //yield return new WaitForSeconds(1f);
        // Debug.Log(objectives.IndexOf(this.currentObjective));
        // Debug.Log(currentObjective.isComplete);
        currentObjective.checkIfComplete(this.currentObjective);
        if(currentObjective.isComplete){
            checkObjComplete();
            onCompleteObj =  currentObjective.setOnCompleteObj(this);
        }else {

        }

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
    void OpenNote(){
        if(!audioSrc.GetComponent<AudioSource>().isPlaying){
            audioSrc.GetComponent<AudioSource>().Play();
        }
        this.activeNote.GetComponent<Note>().disableEffects();
        canvas.transform.GetChild(2).gameObject.SetActive(false);
        canvas.transform.GetChild(2).gameObject.transform.GetChild(0).gameObject.GetComponent<Text>().text = "";
        notesCanvas.gameObject.SetActive(true);
        var noteInInventory = Instantiate(notePrefab ,new Vector3(0, 0, 0), Quaternion.identity);

        noteInInventory.transform.GetChild(0).gameObject.GetComponent<TextMeshProUGUI>().text = this.activeNote.GetComponent<Note>().title;
        noteInInventory.transform.SetParent(notesPanel.transform);
        noteInInventory.GetComponent<Button>().onClick.AddListener(delegate { inventoryManager.GetComponent<InventoryManager>().OnClickNoteButton(noteInInventory);});
        inventoryManager.GetComponent<InventoryManager>().notes.Add(this.activeNote);

        this.activeNote = null;
    }
    void CloseNote(){
        // audioSrc.GetComponent<AudioSource>().clip =  (AudioClip) Resources.Load("Audio/Writing_Sound", typeof(AudioClip));
        if(!audioSrc.GetComponent<AudioSource>().isPlaying){
            audioSrc.GetComponent<AudioSource>().Play();
        }
        noteTitle.text = "";
        noteContent.text = "";
        notesCanvas.gameObject.SetActive(false);
        this.activeNote = null;
    }
    void showOpenNoteToggle(GameObject nearNote){
        audioSrc.GetComponent<AudioSource>().clip =  null;
        isCloseToNote = true;
        canvas.transform.GetChild(2).gameObject.transform.GetChild(0).gameObject.GetComponent<Text>().text = "Press R to Read Note";
        canvas.transform.GetChild(2).gameObject.SetActive(true);
        noteTitle.text = nearNote.GetComponent<Note>().title;
        noteContent.text = nearNote.GetComponent<Note>().content;
        this.activeNote = nearNote;
        Debug.Log("active note: " + this.activeNote);
        nearNote.GetComponent<Note>().isOpened = true;
    }
    void OpenNewspaper(){
        
        if(!audioSrc.GetComponent<AudioSource>().isPlaying){
            audioSrc.GetComponent<AudioSource>().Play();
        }
        this.activeNewspaper.GetComponent<Newspaper>().disableEffects();
        canvas.transform.GetChild(2).gameObject.SetActive(false);
        canvas.transform.GetChild(2).gameObject.transform.GetChild(0).gameObject.GetComponent<Text>().text = "";
        newsPaperCanvas.gameObject.SetActive(true);
        var newspaperInInventory = Instantiate(newsPaperPrefab ,new Vector3(0, 0, 0), Quaternion.identity);

        newspaperInInventory.transform.GetChild(0).gameObject.GetComponent<TextMeshProUGUI>().text = this.activeNewspaper.GetComponent<Newspaper>().sprite.name;
        newspaperInInventory.transform.SetParent(newsPaperPanel.transform);
        newspaperInInventory.GetComponent<Button>().onClick.AddListener(delegate { inventoryManager.GetComponent<InventoryManager>().OnClickNewspaperButton(newspaperInInventory);});
        inventoryManager.GetComponent<InventoryManager>().newspapers.Add(this.activeNewspaper);
        this.activeNewspaper = null;
    }
    void CloseNewspaper(){
        if(!audioSrc.GetComponent<AudioSource>().isPlaying){
            audioSrc.GetComponent<AudioSource>().Play();
        }
        newsPaperImage.GetComponent<Image>().sprite = null;
        newsPaperCanvas.gameObject.SetActive(false);
        this.activeNewspaper = null;
    }
    void showOpenNewspaperToggle(GameObject nearNewsPaper){
        audioSrc.GetComponent<AudioSource>().clip =  null;
        isCloseToNewspaper = true;
        canvas.transform.GetChild(2).gameObject.transform.GetChild(0).gameObject.GetComponent<Text>().text = "Press N to View News";
        canvas.transform.GetChild(2).gameObject.SetActive(true);
        newsPaperImage.GetComponent<Image>().sprite = nearNewsPaper.gameObject.GetComponent<Newspaper>().sprite;
        //noteContent.text = nearNewsPaper.GetComponent<Note>().content;
        this.activeNewspaper = nearNewsPaper;
        nearNewsPaper.GetComponent<Newspaper>().isRead = true;
    }
    void checkObjComplete(){
        
        if(onChangeObj != null){
            if(currentObjective.isComplete){
            if(objectives.IndexOf(this.currentObjective) < objectives.Count){
                this.currentObjective = objectives[objectives.IndexOf(this.currentObjective) + 1];
                objectives[objectives.IndexOf(this.currentObjective) - 1] = null;
                GC.Collect();
                onChangeObj(currentObjective);
            }else {
                onChangeObj(new Objective());
            }
            }
            // Debug.Log(currentIndex + " " + objectives.Count);
            //     if(currentIndex < objectives.Count - 1){
            //         currentIndex++;
            //         currentObjective = objectives[currentIndex];
            //         //objectives.Remove(objectives[objectives.IndexOf(currentObjective) - 1]);
            //         onChangeObj(currentObjective);
            //     }else if(currentIndex == objectives.Count - 1) {
            //         currentObjective = objectives[objectives.Count - 1];
            //         onChangeObj(new Objective());
            //          //onChangeObj(objectives[0]);
            //     }else {

            //         Debug.Log("Done");
            //         onChangeObj(new Objective());
            //     }
            
            }
    }
}
