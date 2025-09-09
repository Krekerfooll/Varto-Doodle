using System.Collections;
using System.Threading.Tasks;
using UnityEngine;
using Varto.Examples.Firebase;
using Varto.Examples.Platforms;
using Varto.Examples.Player;
using Varto.Examples.UI;
using Varto.Examples.Utils;

namespace Varto.Examples.Managers
{
    public class GameManager : MonoBehaviour
    {
        private const string PLAYER_POSITION_SAVE_KEY = "VARTO_DOODLE_PLAYER_POSITION";
        private const string COINS_SAVE_KEY = "VARTO_DOODLE_COINS_COUNT";

        [Header("Refs")]
        [SerializeField] private FirebaseBootstrap _firebase;
        [SerializeField] private Varto_PlayerController _player;
        [SerializeField] private Varto_UiManager _ui;
        [SerializeField] private Varto_PlatformGenerator _platforms;

        [Header("Events")]
        [SerializeField] private string _onCollectCoinEventName;
        [SerializeField] private string _onGameOverEventName;
        [SerializeField] private int _coinsPerEvent = 1;

        [Header("Sync")]
        [SerializeField] private float _autoSaveIntervalSec = 1.0f;

        private Vector3 _lastSafePos; 
        private bool _hasPos; 
        private bool _posDirty;

        private int _coins; 
        private bool _coinsDirty;

        private Coroutine autosaveRoutine;

        private void Start()
        {
            StartCoroutine(BootThenStartGameRoutine());
        }

        private IEnumerator BootThenStartGameRoutine()
        {
            yield return StartCoroutine(_firebase.Init());

            if (!Varto_GameSessionManager.IsRestarting)
            {
                yield return StartCoroutine(LoadCoinsRoutine());
                yield return StartCoroutine(LoadPlayerPosRoutine());
                if (_hasPos) _player.SetPosition(_lastSafePos);
            }

            Varto_GameSessionManager.ClearRestartFlag();

            _platforms.Init();
            _platforms.SetActive(true);
            _ui.Init(_coins);
            _player.Init();

            _player.OnLanded += OnPlayerLanded;
            Varto_GlobalEventSender.OnEvent += OnAnyEvent;
            _ui.OnRestartRequested += OnRestartRequested;

            autosaveRoutine = StartCoroutine(AutoSaveRoutine());
        }

        private void OnDestroy()
        {
            Varto_GlobalEventSender.OnEvent -= OnAnyEvent;
            _ui.OnRestartRequested -= OnRestartRequested;
            if (_player != null) _player.OnLanded -= OnPlayerLanded;
            if (autosaveRoutine != null) StopCoroutine(autosaveRoutine);
        }

        private void OnPlayerLanded(Vector3 pos)
        {
            _lastSafePos = pos; 
            _hasPos = true; 
            _posDirty = true;
        }
        private void OnAnyEvent(string name)
        {
            if (name == _onCollectCoinEventName)
            {
                _ui.AddCoins(_coinsPerEvent);
                _coins = _ui.CoinsCount; 
                _coinsDirty = true;
            }
            else if (name == _onGameOverEventName)
            {
                Destroy(_player.gameObject);
                _platforms.SetActive(false);
                _ui.ShowGameOverScreen();

                PlayerPrefs.DeleteAll();
                PlayerPrefs.Save();

                StartCoroutine(ClearAllDataFromFirebaseRoutine());
            }
        }
        public void OnRestartRequested()
        {
            Varto_GameSessionManager.RestartGameSession();
        }

        private IEnumerator AutoSaveRoutine()
        {
            var wait = new WaitForSeconds(_autoSaveIntervalSec);
            while (true)
            {
                yield return wait;
                yield return StartCoroutine(SaveDataToFirebaseRoutine());
            }
        }
        private IEnumerator SaveDataToFirebaseRoutine()
        {
            var db = FirebaseBootstrap.Db; 
            var uid = FirebaseBootstrap.Uid;

            if (_coinsDirty)
            {
                var t = db.Child($"users/{uid}/{COINS_SAVE_KEY}").SetValueAsync(_coins);
                yield return WaitTaskRoutine(t);
                if (t != null && !t.IsFaulted) _coinsDirty = false;
            }

            if (_posDirty && _hasPos)
            {
                var json = JsonUtility.ToJson(_lastSafePos);
                var t = db.Child($"users/{uid}/{PLAYER_POSITION_SAVE_KEY}").SetValueAsync(json);
                yield return WaitTaskRoutine(t);
                if (t != null && !t.IsFaulted) _posDirty = false;
            }
        }

        private IEnumerator LoadPlayerPosRoutine()
        {
            var db = FirebaseBootstrap.Db;
            var uid = FirebaseBootstrap.Uid;

            var t = db.Child($"users/{uid}/{PLAYER_POSITION_SAVE_KEY}").GetValueAsync();
            yield return WaitTaskRoutine(t);
            if (t != null && !t.IsFaulted && t.Result.Exists && t.Result.Value != null)
            {
                try 
                { 
                    _lastSafePos = JsonUtility.FromJson<Vector3>(t.Result.Value.ToString()); 
                    _hasPos = true; 
                }
                catch 
                { 
                    _hasPos = false; 
                }
            }
        }
        private IEnumerator LoadCoinsRoutine()
        {
            var db = FirebaseBootstrap.Db; 
            var uid = FirebaseBootstrap.Uid;

            var t = db.Child($"users/{uid}/{COINS_SAVE_KEY}").GetValueAsync();
            yield return WaitTaskRoutine(t);
            if (t != null && !t.IsFaulted && t.Result.Exists && t.Result.Value != null)
            {
                if (t.Result.Value is long l) _coins = (int)l;
                else int.TryParse(t.Result.Value.ToString(), out _coins);
            }
            else _coins = 0;
        }
        private IEnumerator ClearAllDataFromFirebaseRoutine()
        {
            var db = FirebaseBootstrap.Db; 
            var uid = FirebaseBootstrap.Uid;

            var t = db.Child($"users/{uid}").RemoveValueAsync();
            yield return WaitTaskRoutine(t);
        }

        private static IEnumerator WaitTaskRoutine(Task task)
        {
            while (task != null && !task.IsCompleted) yield return null;
            if (task != null && task.IsFaulted) Debug.LogWarning(task.Exception?.InnerException?.Message ?? task.Exception?.Message);
        }

        //private void OnApplicationFocus(bool hasFocus)
        //{
        //    if (!hasFocus) StartCoroutine(SaveDataToFirebaseRoutine());
        //}
        //private void OnApplicationPause(bool pause)
        //{
        //    if (pause) StartCoroutine(SaveDataToFirebaseRoutine());
        //}
        //private void OnApplicationQuit()
        //{
        //    StartCoroutine(SaveDataToFirebaseRoutine());
        //}
    }
}
