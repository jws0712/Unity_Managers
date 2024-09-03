namespace UnityFunctions.FSM.Step1.Coroutions
{
    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;

    public enum PlayerState { Idle = 0, Walk, Run, Attack }

    public class PlayerController_2 : MonoBehaviour
    {
        private PlayerState playerState;

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
        }

        private void ChangeState(PlayerState newSate)
        {
            StopCoroutine(playerState.ToString());
            playerState = newSate;
            StartCoroutine(playerState.ToString());
        }

        private IEnumerator Idle()
        {
            //Enter
            Debug.Log("�� ����");

            //Execute
            while(true)
            {
                Debug.Log("��");
                yield return null;
            }
        }

        private IEnumerator Walk()
        {
            //Enter
            Debug.Log("�ȱ� ����");

            //Execute
            while (true)
            {
                Debug.Log("�ȱ�");
                yield return null;
            }
        }

        private IEnumerator Run()
        {
            //Enter
            Debug.Log("�ٱ� ����");

            //Execute
            while (true)
            {
                Debug.Log("�ٱ�");
                yield return null;
            }
        }

        private IEnumerator Attack()
        {
            //Enter
            Debug.Log("���� ����");

            //Execute
            while (true)
            {
                Debug.Log("����");
                yield return null;
            }
        }
    }

}