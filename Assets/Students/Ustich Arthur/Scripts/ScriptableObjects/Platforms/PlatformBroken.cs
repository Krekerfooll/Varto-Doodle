using UnityEngine;

namespace Ustich.Arthur.DoodleJump
{
    [CreateAssetMenu(fileName = "PlatformBroken", menuName = "Ustich/PlatformType/PlatformBroken", order = 1)]
    public class PlatformBroken : PlatformData
    {
        [SerializeField] private Sprite _sprite;
        [Space]
        [Header("Destroy Action Setting")]
        [SerializeField] private bool _executeOnAwake;
        [SerializeField] private string _tag;
        [SerializeField] private ObjectToDestroyType _objectToDestroyType;
        [SerializeField] private float _delay;

        [Space]
        [Header("Play Audio Collision Action Settings")]
        [SerializeField] private AudioClip _clip;

        public override GameObject SpawnPlatform(GameObject Target, Vector2 SpawnedPosition, Transform Parent)
        {
            var _object = Instantiate(_objectPrefab, SpawnedPosition, Quaternion.identity, Parent);
            _object.GetComponent<ColorChangable>().CanChangeColor = _colorChangeble;
            _object.GetComponent<SpriteRenderer>().sprite = _sprite;
            _object.GetComponent<EnableCollider>().ColliderInit(Target.transform);
            AddDestoyAction(ref _object);
            AddPlayAudioCollisionAction(ref _object);
            return _object;
        }

        private void AddDestoyAction(ref GameObject gameObject)
        {
            if(gameObject.GetComponent<ActionDestroy>() == null)
                gameObject.AddComponent<ActionDestroy>();

            gameObject.GetComponent<ActionDestroy>().Tags.Add(_tag);
            gameObject.GetComponent<ActionDestroy>()._ObjectToDestroyType = _objectToDestroyType;
            gameObject.GetComponent<ActionDestroy>()._Delay = _delay;
        }

        private void AddPlayAudioCollisionAction(ref GameObject gameObject)
        {
            if(gameObject.GetComponent<AudioSource>() == null)
                gameObject.AddComponent<AudioSource>();

            if (gameObject.GetComponent<PlayAudioCollisionAction>() == null)
                gameObject.AddComponent<PlayAudioCollisionAction>();

            gameObject.GetComponent<PlayAudioCollisionAction>().AudioSource = gameObject.GetComponent<AudioSource>();
            gameObject.GetComponent<PlayAudioCollisionAction>().AudioClip = _clip;
            gameObject.GetComponent<PlayAudioCollisionAction>().Tags.Add(_tag);
        }
    }
}