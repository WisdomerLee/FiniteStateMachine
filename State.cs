using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

///<summary>
///Finite State Machine
///
/// 참고 링크 : https://faramira.com/generic-finite-state-machine-using-csharp/
///</summary>
namespace FiniteStateMachine
{
    //Finite State Machine에 해당되는 기본 클래스 : Finite State Machine(Finite Automaton)의 상태를 표현할 클래스
    //여러 경우에 쓸 수 있게 Generic class타입으로 생성

    public class State<T>
    {
        //상태의 이름 : 입장 준비 상태 등
        public string Name { get; set; }
        //상태의 타입 : 예를 들면 입장,  등의 상태
        public T ID { get; private set; }

        //델리게이트 함수 : 변경 할 수 있도록 일반 형태
        public System.Action OnEnter, OnExit, OnUpdate, OnFixedUpdate;

        //생성자
        public State(T iD)
        {
            ID = iD;
        }
        //생성자
        public State(string name, T iD) : this(iD)
        {
            ID = iD;
        }
        //생성자
        public State(T iD, Action onEnter, Action onExit = null, Action onUpdate = null, Action onFixedUpdate = null) : this(iD)
        {
            OnEnter = onEnter;
            OnExit = onExit;
            OnUpdate = onUpdate;
            OnFixedUpdate = onFixedUpdate;
        }
        //생성자
        public State(string name, T iD, Action onEnter, Action onExit, Action onUpdate, Action onFixedUpdate) : this(name, iD)
        {
            OnEnter = onEnter;
            OnExit = onExit;
            OnUpdate = onUpdate;
            OnFixedUpdate = onFixedUpdate;
        }



        //상태 시작
        public virtual void Enter()
        {
            OnEnter?.Invoke();
        }
        //상태 끝
        public virtual void Exit()
        {
            OnExit?.Invoke();
        }
        //
        public virtual void Update()
        {
            OnUpdate?.Invoke();
        }
        //
        public virtual void FixedUpdate()
        {
            OnFixedUpdate?.Invoke();
        }
    }

}
