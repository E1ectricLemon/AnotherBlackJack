using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class UIcontrol : MonoBehaviour
{
    //BlackjackHands myHand;

    [SerializeField] GameObject[] deckCards;

    public Button playBtn;
    public Button quitBtn;
    public Button ruleBtn;
    public Button returnBtn;
    public Button hitBtn;
    public Button stayBtn;
    public Button compHitBtn;
    public Button compStayBtn;
    public GameObject rulePanel;
    public GameObject playPanel;
    public GameObject winnerPanel;
    public TMP_Text scoreDisplay;
    public TMP_Text compScoreDisplay;
    public TMP_Text winnerDisplay;
    private int randCard;
    private int handCount = 0;
    private int compHandCount = 0;
    private int score = 0;
    private int compScore = 0;
    private bool playerDone = false;
    private bool compDone = false;

    private Vector2[] cardPos =
        { new (160,250), new (200, 250), new (240, 250), new (280, 250), new (320, 250), new (360, 250), new (400, 250) };
    private Vector2[] compCardPos =
        { new (710,250), new (750, 250), new (790, 250), new (830, 250), new (870, 250), new (910, 250), new (950, 250) };



    void Start()
    {
        rulePanel.SetActive(false);
        winnerPanel.gameObject.SetActive(false);
        if (SceneManager.GetActiveScene().name == "Play Mode")
        {
            playBtn.gameObject.SetActive(false);
            StartCards();
        }
    }

    private void StartCards()
    {
        Invoke("CompHit", 1f);
        Invoke("Hit", .5f);
        CompHit();
        Invoke("Hit", 1.5f);
        if (compHandCount == 1)
        {
            Instantiate(deckCards[0], compCardPos[1], new Quaternion(0, 0, 0, 0), playPanel.transform);

        }

    }

    public void Hit()
    {
        
        handCount++;
        if (handCount < 8)
        {
            randCard = Random.Range(1, deckCards.Length);
            Instantiate(deckCards[randCard], cardPos[handCount], new Quaternion(0, 0, 0, 0), playPanel.transform);

            int[] twoPoints = new int[4] { 1, 2, 3, 4 };
            int[] threePoints = new int[4] { 5, 6, 7, 8 };
            int[] fourPoints = new int[4] { 9, 10, 11, 12 };
            int[] fivePoints = new int[4] { 13, 14, 15, 16 };
            int[] sixPoints = new int[4] { 17, 18, 19, 20 };
            int[] sevenPoints = new int[4] { 21, 22, 23, 24 };
            int[] eightPoints = new int[4] { 25, 26, 27, 28 };
            int[] ninePoints = new int[4] { 29, 30, 31, 32 };
            int[] tenPoints = new int[16] { 33, 34, 35, 36, 37, 38, 39, 40, 41, 42, 43, 44, 45, 46, 47, 48 };
            int[] ace = new int[4] { 49, 50, 51, 52 };

            if (twoPoints.Contains(randCard)) { score = score + 2; }
            if (threePoints.Contains(randCard)) { score = score + 3; }
            if (fourPoints.Contains(randCard)) { score = score + 4; }
            if (fivePoints.Contains(randCard)) { score = score + 5; }
            if (sixPoints.Contains(randCard)) { score = score + 6; }
            if (sevenPoints.Contains(randCard)) { score = score + 7; }
            if (eightPoints.Contains(randCard)) { score = score + 8; }
            if (ninePoints.Contains(randCard)) { score = score + 9; }
            if (tenPoints.Contains(randCard)) { score = score + 10; }
            if (ace.Contains(randCard)) { score = score + 11; }

            scoreDisplay.text = score.ToString();
            if (score > 21)
            {
                playerDone = true;
                Stay();
                hitBtn.gameObject.SetActive(false);
                scoreDisplay.text = "You bust";
                CheckWinner();
                Debug.Log("You Bust");
            }

            
        }
    }

    private void CompHit()
    {
        compHandCount++;
        if (compHandCount < 8)
        {
            
            randCard = Random.Range(1, deckCards.Length);
            Instantiate(deckCards[randCard], compCardPos[compHandCount], new Quaternion(0, 0, 0, 0), playPanel.transform);

            int[] twoPoints = new int[4] { 1, 2, 3, 4 };
            int[] threePoints = new int[4] { 5, 6, 7, 8 };
            int[] fourPoints = new int[4] { 9, 10, 11, 12 };
            int[] fivePoints = new int[4] { 13, 14, 15, 16 };
            int[] sixPoints = new int[4] { 17, 18, 19, 20 };
            int[] sevenPoints = new int[4] { 21, 22, 23, 24 };
            int[] eightPoints = new int[4] { 25, 26, 27, 28 };
            int[] ninePoints = new int[4] { 29, 30, 31, 32 };
            int[] tenPoints = new int[16] { 33, 34, 35, 36, 37, 38, 39, 40, 41, 42, 43, 44, 45, 46, 47, 48 };
            int[] ace = new int[4] { 49, 50, 51, 52 };

            if (twoPoints.Contains(randCard)) { compScore = compScore + 2; }
            if (threePoints.Contains(randCard)) { compScore = compScore + 3; }
            if (fourPoints.Contains(randCard)) { compScore = compScore + 4; }
            if (fivePoints.Contains(randCard)) { compScore = compScore + 5; }
            if (sixPoints.Contains(randCard)) { compScore = compScore + 6; }
            if (sevenPoints.Contains(randCard)) { compScore = compScore + 7; }
            if (eightPoints.Contains(randCard)) { compScore = compScore + 8; }
            if (ninePoints.Contains(randCard)) { compScore = compScore + 9; }
            if (tenPoints.Contains(randCard)) { compScore = compScore + 10; }
            if (ace.Contains(randCard)) { compScore = compScore + 11; }

            if (compHandCount > 1 && compScore < 17 && playerDone == true)
            {

                Invoke("CompHit", .5f);
                Debug.Log("CompHit");
            }
            if (compScore >= 17 && compScore <= 21)
            {
                compDone = true;
                CheckWinner();
                Debug.Log("compStay" + compScore);
            }
            if (compScore > 21)
            {
                compDone = true;
                compHitBtn.gameObject.SetActive(false);
                compScoreDisplay.text = compScore.ToString() + " Computer bust";
                CheckWinner();
                Debug.Log("Computer Busts");
            } 
        }
    }

    private void CheckWinner()
    {
        if( compDone == true && playerDone == true)
        {
            winnerPanel.gameObject.SetActive(true);
            if(compScore <= 21 && compScore > score || compScore <= 21 && score > 21)
            {
                winnerDisplay.text = "Computer Wins";
                Debug.Log("computer wins");
            }
            if(score <= 21 && score > compScore || score <= 21 && compScore > 21) 
            {
                winnerDisplay.text = "You Win";
                Debug.Log("player wins");
            }
            if (compScore == score || compScore > 21 && score > 21)
            {
                winnerDisplay.text = "Its a Tie";
                Debug.Log("its a tie");
            }

        }
    }

    public void Stay()
    {
        hitBtn.gameObject.SetActive(false);
        stayBtn.gameObject.SetActive(false);
        playerDone = true;
        CheckWinner();
        if (compScore < 17) 
        {
            Invoke("CompHit", .5f);
        } 
        CheckWinner();
    }


    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape)) { Quit(); }
    }
    public void Quit()
    {
        Application.Quit();
        Debug.Log("Quits");
    }
    public void CloseRules()
    {
        rulePanel.SetActive(false);
        ruleBtn.gameObject.SetActive(true);
    }
    public void OpenRules()
    {
        rulePanel.SetActive(true);
        ruleBtn.gameObject.SetActive(false);
    }
    public void Play()
    {
        SceneManager.LoadScene("Play Mode");
    }

}