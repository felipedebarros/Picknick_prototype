using UnityEngine;
using System;
using System.Collections;

public enum STATE { START, TIMEIN, TIMEOUT, NONE };

public class Timer : MonoBehaviour {

    [SerializeField]
    private float timeOut_;
    [SerializeField]
    private float timeIn_;

    private STATE lastState_;

    #region Observer
    private STATE state_ = STATE.NONE;
    private STATE State
    {
        get { return state_; }
        set
        {
            if (state_ != value)
            {
                state_ = value;
                Notify();
            }
        }
    }

    private Action<STATE> stateChanged_;

    private void Notify()
    {
        if (stateChanged_ != null)
            stateChanged_(state_);
    }

    public event Action<STATE> Alarm
    {
        add
        {
            stateChanged_ += value;
        }
        remove
        {
            stateChanged_ -= value;
        }
    }
    #endregion

    public void StartTimer()
    {
        State = STATE.NONE;
        StartCoroutine(Clock());
    }

    public void StopTimer()
    {
        StopAllCoroutines();
    }


    public void ResetTimer() 
    {
        StopTimer();
        StartTimer();
    }

    private IEnumerator Clock()
    {
        yield return new WaitForSeconds(timeIn_);
        State = STATE.TIMEIN;
        yield return new WaitForSeconds(timeOut_);
        State = STATE.TIMEOUT;
    }
}
