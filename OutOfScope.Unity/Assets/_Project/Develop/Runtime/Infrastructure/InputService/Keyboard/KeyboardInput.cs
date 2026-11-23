using _Project.Develop.Runtime.Utils.Reactive.Event;
using UnityEngine;
using VContainer.Unity;

namespace _Project.Develop.Runtime.Infrastructure.InputService.Keyboard
{
    public class KeyboardInput : IInputService, ITickable
    {
        private readonly ReactiveEvent<int> _numPadKeyPressed = new();

        public KeyboardInput()
        {
            Exit = new KeyboardKey(KeyCode.Escape);
            Continue = new KeyboardKey(KeyCode.Space);
        }

        public IReadOnlyReactiveEvent<int> NumPadKeyPressed => _numPadKeyPressed;

        public IKey Exit { get; }
        public IKey Continue { get; }

        public void Tick()
        {
            for (int i = 1; i < 10; i++)
            {
                KeyCode key = KeyCode.Alpha0 + i;
                
                if (Input.GetKeyDown(key))
                    _numPadKeyPressed.Invoke(i);
            }
        }
    }
}
