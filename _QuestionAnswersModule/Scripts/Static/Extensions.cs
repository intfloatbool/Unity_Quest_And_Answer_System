using System.Collections.Generic;
using UnityEngine;

namespace QuestBase._QuestionAnswersModule.Scripts.Static
{
    public static class GameHelper
    {
        public static void DebugLogEditorOnly(object msg)
        {
#if UNITY_EDITOR
            Debug.Log(msg);
#endif
        }

        public static bool CheckForNull<T>(T instance)
        {
            if (instance == null)
            {
                Debug.LogError($"{typeof(T).Name} is missing!");
                return false;
            }

            return true;
        }
    }
    public static class Extensions
    {
        public static void Shuffle<T>(this IList<T> ts) {
            var count = ts.Count;
            var last = count - 1;
            for (var i = 0; i < last; ++i) {
                var r = UnityEngine.Random.Range(i, count);
                var tmp = ts[i];
                ts[i] = ts[r];
                ts[r] = tmp;
            }
        }
    }
}
