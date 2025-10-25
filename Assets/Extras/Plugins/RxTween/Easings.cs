using System;
using UnityEngine;

namespace Utils
{
    public static class Easings
    {
        public static float FromTo(float a, float b, float t, Func<float, float> easing)
        {
            return a + (b - a) * easing(Mathf.Clamp(t, 0, 1));
        }

        public static float FromDist(float a, float d, float t, Func<float, float> easing)
        {
            return a + d * easing(Mathf.Clamp(t, 0, 1));
        }

        public static Vector3 FromTo(Vector3 a, Vector3 b, float t, Func<float, float> easing)
        {
            return new Vector3(
                FromTo(a.x, b.x, t, easing),
                FromTo(a.y, b.y, t, easing),
                FromTo(a.z, b.z, t, easing)
            );
        }

        public static Vector3 FromDist(Vector3 a, Vector3 d, float t, Func<float, float> easing)
        {
            return new Vector3(
                FromDist(a.x, d.x, t, easing),
                FromDist(a.y, d.y, t, easing),
                FromDist(a.z, d.z, t, easing)
            );
        }

        public static Quaternion FromTo(Quaternion a, Quaternion b, float t, Func<float, float> easing)
        {
            return new Quaternion(
                FromTo(a.x, b.x, t, easing),
                FromTo(a.y, b.y, t, easing),
                FromTo(a.z, b.z, t, easing),
                FromTo(a.w, b.w, t, easing)
            );
        }

        public static Quaternion FromDist(Quaternion a, Quaternion d, float t, Func<float, float> easing)
        {
            return new Quaternion(
                FromDist(a.x, d.x, t, easing),
                FromDist(a.y, d.y, t, easing),
                FromDist(a.z, d.z, t, easing),
                FromDist(a.w, d.w, t, easing)
            );
        }

        public static float InOut(float t, Func<float, float> easeIn, Func<float, float> easeOut)
        {
            return InOut(0.5f, 0.5f, t, easeIn, easeOut);
        }

        public static float InOut(float tmid, float fmid, float t, Func<float, float> easeIn, Func<float, float> easeOut)
        {
            return t < tmid ?
                FromTo(0f, fmid, t / tmid, easeIn) :
                FromTo(fmid, 1f, (t - tmid) / (1f - tmid), easeOut);
        }

        public static float Linear(float t)
        {
            return t;
        }

        public static float QuadIn(float t)
        {
            return t * t;
        }

        public static float QuadOut(float t)
        {
            return -t * (t - 2f);
        }

        public static float QuadInOut(float t)
        {
            return InOut(t, QuadIn, QuadOut);
        }

        public static float CubicIn(float t)
        {
            return t * t * t;
        }

        public static float CubicOut(float t)
        {
            var tt = t - 1f;
            return tt * tt * tt + 1f;
        }

        public static float CubicInOut(float t)
        {
            return InOut(t, CubicIn, CubicOut);
        }

        public static float QuartIn(float t)
        {
            return t * t * t * t;
        }

        public static float QuartOut(float t)
        {
            var tt = t - 1f;
            return -(tt * tt * tt * tt - 1f);
        }

        public static float QuartInOut(float t)
        {
            return InOut(t, QuartIn, QuartOut);
        }

        public static float QuintIn(float t)
        {
            return t * t * t * t * t;
        }

        public static float QuintOut(float t)
        {
            var tt = t - 1f;
            return tt * tt * tt * tt * tt + 1;
        }

        public static float QuintInOut(float t)
        {
            return InOut(t, QuintIn, QuintOut);
        }

        public static float SineIn(float t)
        {
            return -Mathf.Cos(t * (Mathf.PI * 0.5f)) + 1f;
        }

        public static float SineOut(float t)
        {
            return Mathf.Sin(t * Mathf.PI * 0.5f);
        }

        public static float SineInOut(float t)
        {
            return InOut(t, SineIn, SineOut);
        }

        public static float ExpoIn(float t)
        {
            return Mathf.Pow(2, 10 * (t - 1));
        }

        public static float ExpoOut(float t)
        {
            return -Mathf.Pow(2, -10 * t) + 1;
        }

        public static float ExpoInOut(float t)
        {
            return InOut(t, ExpoIn, ExpoOut);
        }

        public static float CircIn(float t)
        {
            return -Mathf.Sqrt(1 - t * t) + 1;
        }

        public static float CircOut(float t)
        {
            var tt = t - 1;
            return Mathf.Sqrt(1 - tt * tt);
        }

        public static float CircInOut(float t)
        {
            return InOut(t, CircIn, CircOut);
        }
    }
}