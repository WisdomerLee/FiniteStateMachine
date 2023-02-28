using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

///<summary>
///Finite State Machine
///
/// ���� ��ũ : https://faramira.com/generic-finite-state-machine-using-csharp/
///</summary>
namespace FiniteStateMachine
{
    //Finite State Machine�� �ش�Ǵ� �⺻ Ŭ���� : Finite State Machine(Finite Automaton)�� ���¸� ǥ���� Ŭ����
    //���� ��쿡 �� �� �ְ� Generic classŸ������ ����

    public class State<T>
    {
        //������ �̸� : ���� �غ� ���� ��
        public string Name { get; set; }
        //������ Ÿ�� : ���� ��� ����,  ���� ����
        public T ID { get; private set; }

        //��������Ʈ �Լ� : ���� �� �� �ֵ��� �Ϲ� ����
        public System.Action OnEnter, OnExit, OnUpdate, OnFixedUpdate;

        //������
        public State(T iD)
        {
            ID = iD;
        }
        //������
        public State(string name, T iD) : this(iD)
        {
            ID = iD;
        }
        //������
        public State(T iD, Action onEnter, Action onExit = null, Action onUpdate = null, Action onFixedUpdate = null) : this(iD)
        {
            OnEnter = onEnter;
            OnExit = onExit;
            OnUpdate = onUpdate;
            OnFixedUpdate = onFixedUpdate;
        }
        //������
        public State(string name, T iD, Action onEnter, Action onExit, Action onUpdate, Action onFixedUpdate) : this(name, iD)
        {
            OnEnter = onEnter;
            OnExit = onExit;
            OnUpdate = onUpdate;
            OnFixedUpdate = onFixedUpdate;
        }



        //���� ����
        public virtual void Enter()
        {
            OnEnter?.Invoke();
        }
        //���� ��
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
