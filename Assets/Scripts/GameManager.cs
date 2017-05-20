using UnityEngine;

public class GameManager : MonoBehaviour {

    private Timer timer_;
    private bool firstMove = true;

    public AudioSource audio;

    void Start()
    {
        timer_ = GetComponent<Timer>();
        timer_.Alarm += Alarm;
        var player = FindObjectOfType<PlayerController>();
        timer_.Alarm += player.AlarmHandler;
        player.OnMoved += playerMoved;

        audio = GetComponent<AudioSource>();
    }

	void Update () {
       
	}

    void playerMoved(DIRECTION dir)
    {
        if(firstMove)
        {
            firstMove = false;
            timer_.StartTimer();
        }
        NextTurn();
    }

    void Alarm(STATE state)
    {
        if (state == STATE.TIMEOVER)
        {
            NextTurn();
            Debug.Log("Time over");
        }
        else if(state == STATE.TIMEOUT)
        {
            audio.Play();
        }
    }

    int turn = 0;
    void NextTurn()
    {
        timer_.ResetTimer();
        //Debug.Log("Turno: ");//+ (++turn));
    }
}
