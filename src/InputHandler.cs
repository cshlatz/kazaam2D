using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

using System.Collections.Generic;

namespace Kazaam.Input {

    public class InputAction {
        public string ActionName { get; set; }

    }

    /// <summary>
    /// Handles the registration and input management of the engine
    /// </summary>
    public class InputHandler {
        public XNAGame Game { get; set; }

        Dictionary<string, Keys> ActionKeys = new Dictionary<string, Keys>();
        Dictionary<string, GamePadButtons> ActionButtons = new Dictionary<string, GamePadButtons>();

        private KeyboardState _previousKeyboardState; 
        private KeyboardState _currentKeyboardState; 
        private GamePadState _previousGamePadState; 
        private GamePadState _currentGamePadState; 

        public InputHandler(XNAGame game) {
            Game = game;
        }

        public void RegisterAction(string action, Keys key) {
            ActionKeys.Add(action, key);
        }

        public void RegisterAction(string action, GamePadButtons button) {
            ActionButtons.Add(action, button);
        }

        public bool IsActionPressed(string action) {
            if (_currentKeyboardState.IsKeyDown(ActionKeys[action])) {
                return true;
            }

            return false;

        }
            
        /// <summary>
        /// Updates the current keyboard and gamepad state
        /// </summary>
        public void Update() {
            // update the keyboard state
            _previousKeyboardState = _currentKeyboardState;
            _currentKeyboardState = Keyboard.GetState();

            // update the gamepad state
            _previousGamePadState = _currentGamePadState;
            _currentGamePadState = GamePad.GetState(PlayerIndex.One);
        }
    }
}
