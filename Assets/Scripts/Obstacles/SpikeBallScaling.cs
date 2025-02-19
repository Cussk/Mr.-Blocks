using UnityEngine;

namespace Obstacles
{
    public class SpikeBallScaling : SpikeBall
    {
        [SerializeField] float minScale = 0.5f;
        [SerializeField] float maxScale = 1.5f;
        [SerializeField] float scalingFactor = 1f;
        [SerializeField] float scalingSpeed = 6f;
        [SerializeField] float scaleDelay = 2f; 
        
        bool _isWaiting;
        float _timer;
        float _currentScale;
        
        void Awake()
        {
            ApplyCurrentScale(minScale);
        }

        protected override void Update()
        {
            base.Update();
            
            if(_isWaiting)
                HandleWaiting();
            else
                ChangeScale();
        }

        void HandleWaiting()
        {
            _timer += Time.deltaTime;

            if (_timer >= scaleDelay)
            {
                _isWaiting = false;
                _timer = 0f;
            }
        }

        void ChangeScale()
        {
            CalculateCurrentScale();
            CheckScaleBoundary();
            ApplyCurrentScale(_currentScale);
        }
        
        void CalculateCurrentScale()
        {
            _currentScale += scalingFactor * scalingSpeed * Time.deltaTime;
            _currentScale = Mathf.Clamp(_currentScale, minScale, maxScale);
        }
        
        void CheckScaleBoundary()
        {
            bool isMaxScale = Mathf.Approximately(_currentScale, maxScale);
            bool isMinScale = Mathf.Approximately(_currentScale, minScale);
            if (isMaxScale || isMinScale)
            {
                scalingFactor = -scalingFactor;
                _isWaiting = true;
            }
        }

        void ApplyCurrentScale(float currentScale)
        { 
            transform.localScale = new Vector3(currentScale, currentScale, 1); 
        }
    }
}
