using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices.WindowsRuntime;
using UnityEngine;
///<summary>
///Finite State Machine 
///
///참고 링크: https://faramira.com/generic-finite-state-machine-using-csharp/
///</summary>
namespace FiniteStateMachine
{
    //Finite State Machine : 상태들의 모음으로 구성되어야 함
    //어느 때가 되더라도 특정 상태 중의 한 가지의 상태로'만' 존재 해야 함

    public class FiniteStateAutomaton<T>
    {
        //표현될 수 있는 상태들 모음
        protected Dictionary<T, State<T>> _states;
        //현재 상태
        protected State<T> _currentState;

        //생성될 때 상태들을 초기화 : 추가 삭제 가능하도록
        public FiniteStateAutomaton()
        {
            _states = new Dictionary<T, State<T>>();
        }

        //상태들을 업데이트 할 수 있는 함수가 필요 : 상태 추가, 제거
        public void Add(State<T> state)
        {
            _states.Add(state.ID, state);
        }
        public void Add(T stateID, State<T> state)
        {
            _states.Add(stateID, state);
        }

        //상태를 돌려줄 수 있는 메소드 필요
        public State<T> GetState(T stateID)
        {
            _states.TryGetValue(stateID, out var state);
            return state;
        }
        //현재 상태를 업데이트 할 수 있는 함수
        public void SetCurrentState(State<T> state)
        {
            //이전 상태가 아무것도 없으면 그냥 현재 상태로 업데이트
            //이전 상태가 이미 있으면...?
            //이전 상태가 이미 있으면 무작정 덮어씌울 수 없음 > 상태들 변화에 조건이 있을 수 있음 : 조건을 만족하지 못하면...? 덮어씌우기 가능하지 않게..
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
