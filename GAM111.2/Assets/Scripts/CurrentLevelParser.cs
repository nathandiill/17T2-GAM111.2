using MonsterLove.StateMachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CurrentLevelParser : MonoBehaviour {

    public static CurrentLevelParser Instance;

    void Awake()
    {
        Instance = this;
    }

    public enum States
    {
        Level1,
        Level2,
        Level3,
        Level4,
        Level5,
    }

    public StateMachine<States> fsm;

    void Start()
    {
        fsm = StateMachine<States>.Initialize(this);

        fsm.ChangeState(States.Level1);
    }

    void Level1_Update()
    {
       
    }

    void Level2_Enter()
    {
        Debug.Log("Level2");
    }
}
