using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextBox : MonoBehaviour
{
    public float letterTime = 0.1f;
    public GameObject upperPosition;
    public float timeMoveUpS = 0.5f;
    public float timeMoveDownS = 0.25f;
    public float positionThreshold = 0.1f;
    public Text displayText;
    [Space]
    public bool debug = false;

    private float originalYPos;
    private float upperYPos;

    private static string message;
    private static bool show;
    private static bool hide;

    private bool positionUp = false;
    private bool positionDown = false;
    private static bool open;
    public static bool Open { get { return open; } }

    private long lastTime = 0;
    private static string actualTextDisplayed;
    private static int actualCharIndex = 0;

    // Start is called before the first frame update
    void Start()
    {
        originalYPos = transform.localPosition.y;
        upperYPos = upperPosition.transform.localPosition.y;
        positionDown = true;
        positionUp = false;

        //transform.position = new Vector3(transform.position.x, upperPosition.transform.position.y, transform.position.z);
    }

    // Update is called once per frame
    void Update()
    {
        //calculate time as Time.deltaTime does not work if Time.timeScale is 0!
        long nowTime = DateTime.Now.Ticks / TimeSpan.TicksPerMillisecond;
        float delta = (nowTime - lastTime) / 1000.0f;
        lastTime = nowTime;

        positionDown = transform.localPosition.y <= originalYPos;
        positionUp = transform.localPosition.y >= upperYPos;

        float deltaY = 0;

        if (show & !positionUp)
        {
            //move up
            deltaY = delta * (upperYPos - originalYPos) / timeMoveUpS;
            open = false;
        }
        else
        {
            if (positionUp)
            {
                StartCoroutine(DisplayMessage());
                transform.localPosition = new Vector3(transform.localPosition.x, upperPosition.transform.localPosition.y, transform.localPosition.z);
            }
            else
            {
                open = false;
                displayText.text = "";
            }
        }

        if (hide & !positionDown)
        {
            //move down
            deltaY = delta * (originalYPos - upperYPos) / timeMoveUpS;
        }
        else
        {
            if (positionDown)
            {
                transform.localPosition = new Vector3(transform.localPosition.x, originalYPos, transform.localPosition.z);
                hide = false;
            }
        }

        //move TextBox
        transform.localPosition = new Vector3(transform.localPosition.x, transform.localPosition.y + deltaY, transform.localPosition.z);

    }

    private IEnumerator DisplayMessage()
    {
        
        if(actualCharIndex +1 < message.Length)
        {
            actualTextDisplayed += message[actualCharIndex];
            actualCharIndex++;
        }
        else
        {
            actualTextDisplayed = message;
            open = true;
        }
        displayText.text = actualTextDisplayed;
        yield return new WaitForSeconds(0);
    }

    public static void Show(string message)
    {
        actualTextDisplayed = "";
        actualCharIndex = 0;
        hide = false;
        show = true;
        TextBox.message = message;
        open = true;
        //pause game
        Time.timeScale = 0;
    }

    public static void Hide()
    {
        actualTextDisplayed = "";
        actualCharIndex = 0;
        hide = true;
        show = false;
        TextBox.message = "";
        open = false;
        //unpause game
        Time.timeScale = 1;
    }

    public void HideNonStatic()
    {
        actualTextDisplayed = "";
        actualCharIndex = 0;
        hide = true;
        show = false;
        TextBox.message = "";
        open = false;
        //unpause game
        Time.timeScale = 1;
    }
}
