using UnityEngine;
using System.Linq;

namespace Obstacles
{
    public class SpikeBallPatrolling : SpikeBall
    {
        [SerializeField] Transform[] patrolPoints;
        [SerializeField] float speed = 2f;

        Vector3[] _patrolPositions;
        Vector3 _targetPatrolPoint;
        int _currentPatrolPointIndex;

        void Awake()
        {
            if (ValidatePatrolPoints()) return;
            SetPatrolPoints();
        }

        protected override void Update()
        {
            base.Update();
            PatrolSpikeBall();
        }
        
        bool ValidatePatrolPoints()
        {
            if (patrolPoints.Length < 2)
            {
                Debug.LogError("SpikeBallPatrolling requires at least two patrol points.");
                enabled = false;
                return true;
            }

            return false;
        }

        void SetPatrolPoints()
        {
            _patrolPositions = patrolPoints.Select(p => p.position).ToArray();
            transform.position = _patrolPositions[0];
            _currentPatrolPointIndex = 1;
            _targetPatrolPoint = _patrolPositions[_currentPatrolPointIndex];
        }
        
        void PatrolSpikeBall()
        {
            transform.position = Vector3.MoveTowards(transform.position, _targetPatrolPoint, speed * Time.deltaTime);

            if (transform.position != _targetPatrolPoint) return;

            _currentPatrolPointIndex = (_currentPatrolPointIndex + 1) % _patrolPositions.Length;
            _targetPatrolPoint = _patrolPositions[_currentPatrolPointIndex];
        }
    }
}