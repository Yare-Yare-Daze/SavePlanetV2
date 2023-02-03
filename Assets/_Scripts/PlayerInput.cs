using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    private float screenWidth;
    private Touch firstTouch;
    private int tapCount;
    private float timeLastTouch1;
    private float timeLastTouch2;
    private bool clockWise = false;

    [SerializeField] private float timeRecognitionDoubleTouch;
    [SerializeField] private PlayerMove playerMove;

    private void Start()
    {
        screenWidth = Screen.width;
    }

    private void Update()
    {
        playerMove.direction = Vector3.zero;

        if(Input.touchCount > 0)
        {
            firstTouch = Input.GetTouch(0);

            if(firstTouch.phase == TouchPhase.Began )
            {
                tapCount++;
                if(tapCount == 2)
                {
                    timeLastTouch2 = Time.time; 
                }
            }

            if(firstTouch.phase == TouchPhase.Stationary || firstTouch.phase == TouchPhase.Moved)
            {
                if(checkTouchPositionXMoreHalfWidthScreen())
                {
                    playerMove.direction = Vector3.back;
                }
                else
                {
                    playerMove.direction = Vector3.forward;
                }

                if(tapCount == 2 && timeLastTouch2 <= (timeLastTouch1 + timeRecognitionDoubleTouch))
                {
                    if(clockWise && checkTouchPositionXMoreHalfWidthScreen() || !clockWise && !checkTouchPositionXMoreHalfWidthScreen())
                    {
                        playerMove.multiplier = 2;
                    }
                }
                else
                {
                    playerMove.multiplier = 1;
                }
            }

            if(firstTouch.phase == TouchPhase.Ended)
            {
                if(tapCount == 1)
                {
                    timeLastTouch1 = Time.time;
                    if (checkTouchPositionXMoreHalfWidthScreen())
                    {
                        clockWise = true;
                    }
                    else
                    {
                        clockWise = false;
                    }
                }
            }
        }
        else if(Time.time > (timeLastTouch1 + timeRecognitionDoubleTouch))
        {
            tapCount = 0;
        }

    }

    private bool checkTouchPositionXMoreHalfWidthScreen()
    {
        return firstTouch.position.x >= screenWidth / 2;
    }
}
