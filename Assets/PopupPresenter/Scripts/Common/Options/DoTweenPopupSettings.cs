using System;
using UnityEngine;
using Random = UnityEngine.Random;

namespace SquareDino.Popups
{
    [Serializable]
    public class DoTweenPopupSettings
    {
        public float duration;

        public Vector3 moveOffset = Vector3.up;
        public RandomOptions moveOffsetRandomOptions = RandomOptions.Constant;
        public Vector3 minMoveOffset;
        public Vector3 maxMoveOffset;
        public float moveDuration;
        public AnimationCurve moveCurve = AnimationCurve.Linear(0, 0, 1, 1);

        public float startRotation;
        public float rotateOffset;
        public float rotateDuration;
        public AnimationCurve rotateCurve = AnimationCurve.Linear(0, 0, 1, 1);

        public ScaleOptions scaleOptions = ScaleOptions.Constant;
        public float minScaleFactor = 1;
        public float maxScaleFactor = 1;
        public float scaleDuration;
        public AnimationCurve scaleCurve = AnimationCurve.Linear(0, 0, 1, 1);

        public Gradient colorOverLifeTime;

        public Vector2 GetScaleFactor()
        {
            return new Vector2(minScaleFactor, maxScaleFactor);
        }

        public Vector3 GetMoveOffset()
        {
            switch (moveOffsetRandomOptions)
            {
                case RandomOptions.Constant:
                    return moveOffset;
                case RandomOptions.RandomBetweenTwoConstant:
                    return new Vector3(
                        Random.Range(minMoveOffset.x, maxMoveOffset.x),
                        Random.Range(minMoveOffset.y, maxMoveOffset.y),
                        Random.Range(minMoveOffset.z, maxMoveOffset.z));
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        public float GetRotateOffset()
        {
            return rotateOffset;
        }
    }
}