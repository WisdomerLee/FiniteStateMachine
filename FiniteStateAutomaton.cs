using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices.WindowsRuntime;
using UnityEngine;
///<summary>
///Finite State Machine 
///
///���� ��ũ: https://faramira.com/generic-finite-state-machine-using-csharp/
///</summary>
namespace FiniteStateMachine
{
    //Finite State Machine : ���µ��� �������� �����Ǿ�� ��
    //��� ���� �Ǵ��� Ư�� ���� ���� �� ������ ���·�'��' ���� �ؾ� ��

    public class FiniteStateAutomaton<T>
    {
        //ǥ���� �� �ִ� ���µ� ����
        protected Dictionary<T, State<T>> _states;
        //���� ����
        protected State<T> _currentState;

        //������ �� ���µ��� �ʱ�ȭ : �߰� ���� �����ϵ���
        public FiniteStateAutomaton()
        {
            _states = new Dictionary<T, State<T>>();
        }

        //���µ��� ������Ʈ �� �� �ִ� �Լ��� �ʿ� : ���� �߰�, ����
        public void Add(State<T> state)
        {
            _states.Add(state.ID, state);
        }
        public void Add(T stateID, State<T> state)
        {
            _states.Add(stateID, state);
        }

        //���¸� ������ �� �ִ� �޼ҵ� �ʿ�
        public State<T> GetState(T stateID)
        {
            _states.TryGetValue(stateID, out var state);
            return state;
        }
        //���� ���¸� ������Ʈ �� �� �ִ� �Լ�
        public void SetCurrentState(State<T> state)
        {
            //���� ���°� �ƹ��͵� ������ �׳� ���� ���·� ������Ʈ
            //���� ���°� �̹� ������...?
            //���� ���°� �̹� ������ ������ ����� �� ���� > ���µ� ��ȭ�� ������ ���� �� ���� : ������ �������� ���ϸ�...? ������ �������� �ʰ�..
            if (_currentState == state)
            {
                return;
            }
            _currentState?.Exit();
            _currentState = state;
            _currentState?.Enter();
        }
        public void Update()
        {
            _currentState?.Update();
        }

        public void FixedUpdate()
        {
            _currentState?.FixedUpdate();
        }
    }

}
