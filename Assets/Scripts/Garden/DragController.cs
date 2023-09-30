using System;
using UnityEngine;
using UnityEngine.UI;

namespace Garden
{
    public class DragController : MonoBehaviour
    {
        public DragController Instance;
        private bool _isDragActive = false;
        private Vector2 _screenPosition;
        private Vector3 _worldPosition;
        private Draggable _lastDragged;
        private Child _child;

        private void Awake()
        {
            if (Instance != null)
            {
                throw new Exception("Tried to overide singleton");
            }

            Instance = this;
        }

        private void Update()
        {
            if (_isDragActive)
            {
                if ((Input.GetMouseButtonDown(0) ||
                     (Input.touchCount == 1 && Input.GetTouch(0).phase == TouchPhase.Ended)))
                {
                    Drop();
                    return;
                }
                
            }
            if (Input.touchCount > 0)
            {
                _screenPosition = Input.GetTouch(0).position;
            }
            else
            {
                return;
            }

            _worldPosition = Camera.main.ScreenToWorldPoint(_screenPosition);
            if (_isDragActive)
            {
                Drag();
            }else
            {
                RaycastHit2D hit = Physics2D.Raycast(_worldPosition, Vector2.zero);
                if (hit.collider)
                {
                    Draggable draggable = hit.transform.gameObject.GetComponent<Draggable>();
                    if (draggable)
                    {
                        _lastDragged = draggable;
                        _child = draggable.GetComponent<Child>();
                        InitDrag();
                    }
                }
            }
        }

        void InitDrag()
        {
            _isDragActive = true;
            _child.OnDragStarted();
        }

        void Drag()
        {
            _lastDragged.transform.position = new Vector2(_worldPosition.x, _worldPosition.y);
        }

        void Drop()
        {
            _isDragActive = false;
            _child.OnDragEnded();
        }
    }
}