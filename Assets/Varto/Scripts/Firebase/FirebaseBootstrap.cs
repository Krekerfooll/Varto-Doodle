using System;
using System.Collections;
using System.Threading.Tasks;
using Firebase;
using Firebase.Auth;
using Firebase.Database;
using UnityEngine;

namespace Varto.Examples.Firebase
{
    public class FirebaseBootstrap : MonoBehaviour
    {
        private const string DATABASE_URL = "https://varto-test-default-rtdb.europe-west1.firebasedatabase.app/";

        public static string Uid { get; private set; }
        public static DatabaseReference Db { get; private set; }
        public static bool IsReady { get; private set; }

        public IEnumerator Init(Action onReady = null, bool force = false)
        {
            if (IsReady && !force)
            {
                onReady?.Invoke();
                yield break;
            }

            IsReady = false;

            var depTask = FirebaseApp.CheckAndFixDependenciesAsync();
            yield return WaitForTask(depTask);

            if (depTask.IsFaulted || depTask.Result != DependencyStatus.Available)
            {
                Debug.LogError($"[FB] Deps: {depTask.Result}");
                yield break;
            }

            var app = FirebaseApp.DefaultInstance;
            var auth = FirebaseAuth.DefaultInstance;

            if (auth.CurrentUser == null)
            {
                var signIn = auth.SignInAnonymouslyAsync();
                yield return WaitForTask(signIn);
                if (signIn.IsFaulted) yield break;
            }

            Uid = auth.CurrentUser.UserId;

            var db = FirebaseDatabase.GetInstance(app, DATABASE_URL);
            db.SetPersistenceEnabled(false);
            Db = db.RootReference;

            IsReady = true;
            onReady?.Invoke();
            Debug.Log($"[FB] Ready, uid={Uid}");
        }

        private static IEnumerator WaitForTask(Task task)
        {
            while (task != null && !task.IsCompleted) yield return null;
            if (task != null && task.IsFaulted) Debug.LogError(task.Exception);
        }
    }
}
