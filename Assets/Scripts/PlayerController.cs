using UnityEngine;
using UnityEngine.Events;

namespace Assets.Scripts
{
    public class PlayerController : MonoBehaviour
    {
        private Rigidbody _rb;
        //private Camera _camera;
        public float Speed = 200f;
        public float GrowFactor = 0.1f;
        public UnityEvent GrowPickupFound;
        public UnityEvent ShrinkPickupFound;

        private void Awake()
        {
            _rb = GetComponent<Rigidbody>();
            //_camera = gameObject.GetComponentInChildren<Camera>();
        }
    
        public void Move(Vector3 movement)
        {
            _rb.velocity = movement * Speed;
        }

        public void Grow(bool grow)
        {
            var next = grow ? GrowFactor : -GrowFactor;
            transform.localScale += new Vector3(next, next, next);
            //_camera.transform.position.Set(_camera.transform.position.x, _camera.transform.position.y - next, _camera.transform.position.z);
        }
    
        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.CompareTag("PickupGrow"))
            {
                other.gameObject.SetActive(false);
                GrowPickupFound.Invoke();
            }
        }
    }
}
