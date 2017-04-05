using System;
using System.Collections.Generic;
using UnityEngine;
namespace UnityStandardAssets.Characters.ThirdPerson
{
    [RequireComponent(typeof (UnityEngine.AI.NavMeshAgent))]
    [RequireComponent(typeof (ThirdPersonCharacter))]
    public class AICharacterControl : MonoBehaviour
    {
        public UnityEngine.AI.NavMeshAgent agent { get; private set; }             // the navmesh agent required for the path finding
        public ThirdPersonCharacter character { get; private set; } // the character we are controlling
        public Transform target;
        private Player jugador;
        private List<Vector3> posDefensa;

        private void Start()
        {
            // get the components on the object we need ( should not be null due to require component so no need to check )
            //agent = GetComponentInChildren<UnityEngine.AI.NavMeshAgent>();
            
            character = GetComponent<ThirdPersonCharacter>();
            jugador = GetComponent<Player>();
            agent = character.GetComponentInChildren<UnityEngine.AI.NavMeshAgent>();

            agent.updateRotation = false;
	        agent.updatePosition = true;
            this.target = GameObject.FindGameObjectWithTag("Target").transform;
           // Vector3 pos = new Vector3(-12, 0, -11);
            posDefensa = this.Defend(this.target.position);
           // agent.destination = this.target.position;
        }


        private void Update()
        {
            if (target != null)
            {
              
                target.position = this.posDefensa[jugador.id];

                agent.SetDestination(target.position);
                Debug.Log(jugador.id);
            }
                
          //  Debug.Log(target.position);
            if (agent.remainingDistance > agent.stoppingDistance)
                character.Move(agent.desiredVelocity, false, false);
            else
                character.Move(Vector3.zero, false, false);
        }


        public void SetTarget(Transform target)
        {
            this.target = target;
        }
        public List<Vector3> Defend(Vector3 point)
        {
            Vector3 center = point;
            center.z -= 2;
            List<Vector3> alignment = new List<Vector3>();
            alignment.Add(point);
            for (int i = 1; i < 5; i++)
            {
                if (IsOdd(i))
                {
                    alignment.Add(new Vector3(point.x + 2 * i, point.y, point.z));
                }
                else
                {
                    alignment.Add(new Vector3(point.x - 2 * i, point.y, point.z));
                }
            }
            return alignment;
        }

        public static bool IsOdd(int value)
        {
            return value % 2 != 0;
        }


    }
}
