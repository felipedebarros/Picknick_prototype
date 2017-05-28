using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

    private Timer timer_;
    private bool firstMove = true;

    #region MovingObjects_Update

    private List<MovingObject> movingObjects_ = new List<MovingObject>();

    public void Subscribe(MovingObject mo) { movingObjects_.Add(mo); }

    private void UpdateMovingObjects()
    {
        foreach(MovingObject mo in movingObjects_)
            mo.nextTurn();
    }

    #endregion

    void Start()
    {
        timer_ = GetComponent<Timer>();
        timer_.Alarm += HandleAlarm;
        var player = FindObjectOfType<PlayerController>();
        player.OnMoved += playerMoved;
        timer_.Alarm += player.HandleTimer;
    }

    void playerMoved(DIRECTION dir)
    {
        if(firstMove)
        {
            timer_.StartTimer();
        }
        NextTurn();
    }

    void HandleAlarm(STATE state)
    {
        if (state == STATE.TIMEOUT)
        {
            NextTurn();
        }
    }

    void NextTurn()
    {
        timer_.StopTimer();
        UpdateMovingObjects();
        timer_.StartTimer();
        Debug.Log("Change turn");
    }
}
