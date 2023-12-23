using System.Collections.Generic;
using UnityEngine;
using MEC;

namespace Wildsong
{
    public class OptimizedRepeater : MonoBehaviour
    {
        [SerializeField] private float _refreshTimePerSecond = 15;

        private CoroutineHandle _coroutine;

        protected virtual void Start()
        {
            _coroutine = Timing.RunCoroutine(UpdateCoroutine().CancelWith(gameObject));
        }

        protected virtual void OnEnable()
        {
            _coroutine = Timing.RunCoroutine(UpdateCoroutine().CancelWith(gameObject));
        }

        protected virtual void OnDisable()
        {
            Timing.KillCoroutines(_coroutine);
        }

        private IEnumerator<float> UpdateCoroutine()
        {
            float waitTime = 1/_refreshTimePerSecond;
            while (true)
            {
                yield return Timing.WaitForSeconds(waitTime);
                DoRepeatedLogic(waitTime);
            }
        }

        protected virtual void DoRepeatedLogic(float delta)
        {
        }

        protected virtual void OnDestroy()
        {
            Timing.KillCoroutines(_coroutine);
        }
    }
}