using UnityEngine;

public class GameManager : MonoBehaviour {

    private Timer timer_;
    private bool firstMove = true;

    void Start()
    {
        timer_ = GetComponent<Timer>();
        timer_.Alarm += Alarm;
        var player = FindObjectOfType<PlayerController>();
        player.OnMoved += playerMoved;
    }

	void Update () {
       
	}

    void playerMoved(DIRECTION dir)
    {
        if(firstMove)
        {
            timer_.StartTimer();
        }
        NextTurn();
    }

    void Alarm(STATE state)
    {
        if (state == STATE.TIMEOUT)
        {
            NextTurn();
        }
    }

    void NextTurn()
    {
        timer_.ResetTimer();
        //Debug.Log("Change turn");
    }
}
