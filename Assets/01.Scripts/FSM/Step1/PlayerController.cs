namespace UnityFunctions.FSM.Step1.IF
{
    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;

    public enum PlayerState { Idle = 0, Walk, Run, Attack }

    public class PlayerController : MonoBehaviour
    {
        private PlayerState playerState;

        private bool isChanged = false;

        private void Awake()
        {
            ChangeState(PlayerState.Idle);
        }

        private void Update()
        {
            if(Input.GetKeyDown("1"))
            {
                ChangeState(PlayerState.Idle);
            }
            else if(Input.GetKeyDown("2"))
            {
                ChangeState(PlayerState.Walk);
            }
            else if (Input.GetKeyDown("3"))
            {
                ChangeState(PlayerState.Run);
            }
            else if (Input.GetKeyDown("4"))
            {
                ChangeState(PlayerState.Attack);
            }

            UpdateState();
        }

        private void UpdateState()
        {
            if(playerState == PlayerState.Idle)
            {
                if(isChanged == true)
                {
                    Debug.Log("�� ����");

                    isChanged = false;
                }
                Debug.Log("��");
            }
            else if(playerState == PlayerState.Walk)
            {
                if (isChanged == true)
                {
                    Debug.Log("�ȱ� ����");

                    isChanged = false;
                }
                Debug.Log("�ȱ�");

            }
            else if (playerState == PlayerState.Run)
            {
                if (isChanged == true)
                {
                    Debug.Log("�ٱ� ����");

                    isChanged = false;
                }
                Debug.Log("�ٱ�");

            }
            else if (playerState == PlayerState.Attack)
            {
                if (isChanged == true)
                {
                    Debug.Log("��� ����");

                    isChanged = false;
                }
                Debug.Log("����");

            }
        }

        private void ChangeState(PlayerState newSate)
        {
            playerState = newSate;
            isChanged = true;
        }
    }

}