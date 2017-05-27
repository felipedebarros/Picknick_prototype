using UnityEngine;
using System;

public enum DIRECTION {
    UP, DOWN, LEFT, RIGHT
};


public class PlayerController : MonoBehaviour {

    private bool canMove = true;

    #region Observer
    private Action<DIRECTION> moved_;

    private void Notify(DIRECTION dir)
    {
        if (moved_ != null)
            moved_(dir);
    }

    public event Action<DIRECTION> OnMoved
    {
        add
        {
            moved_ += value;
        }
        remove
        {
            moved_ -= value;
        }
    }
    #endregion

	void Update () {
        HandleInput();
	}

    void HandleInput()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            Move(DIRECTION.UP);
            return;
        }
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            Move(DIRECTION.DOWN);
            return;
        }
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            Move(DIRECTION.LEFT);
            return;
        }
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            Move(DIRECTION.RIGHT);
            return;
        }

    }

    void Move(DIRECTION dir)
    {
        if (!canMove) return;
        switch (dir)
        {
            case DIRECTION.UP:
                transform.Translate(0f, 0f, 1f);
                break;
            case DIRECTION.DOWN:
                transform.Translate(0f, 0f, -1f);
                break;
            case DIRECTION.LEFT:
                transform.Translate(-1f, 0f, 0f);
                break;
            case DIRECTION.RIGHT:
                transform.Translate(1f, 0f, 0f);
                break;
        }
        Notify(dir);
    }
}
