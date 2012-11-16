using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.GamerServices;

namespace LegendOfGit
{
    class InputManager
    {
        #region Member Variables
        private GamePadState mCurrentGamepadState, mPreviousGamepadState;
        private KeyboardState mCurrentKeyboardState, mPreviousKeyboardState;
        private Buttons mInteractButton, mAttackButton, mPauseButton;
        private Keys mInteractKey, mAttackKey, mUpKey, mDownKey, mLeftKey, mRightKey, mPauseKey;
        #endregion

        #region Singleton Functionality
        private static InputManager instance;
        private InputManager() 
        {
            mCurrentGamepadState  = mPreviousGamepadState  = GamePad.GetState(PlayerIndex.One);
            mCurrentKeyboardState = mPreviousKeyboardState = Keyboard.GetState();
            
            mInteractButton = Buttons.A;
            mAttackButton = Buttons.B;
            mPauseButton = Buttons.Start;

            mInteractKey = Keys.Space;
            mAttackKey = Keys.Enter;
            mPauseKey = Keys.Escape;
            mUpKey = Keys.W;
            mLeftKey = Keys.A;
            mDownKey = Keys.S;
            mRightKey = Keys.D;
        }

        public static InputManager Instance()
        {
            if (instance == null)
                instance = new InputManager();
            return instance;
        }
        #endregion

        #region Button Interface
        public bool IsInteractPressed()
        {
            return (mCurrentGamepadState.IsButtonDown(mInteractButton) && !mPreviousGamepadState.IsButtonDown(mInteractButton))
                || (mCurrentKeyboardState.IsKeyDown(mInteractKey) && !mPreviousKeyboardState.IsKeyDown(mInteractKey));
            
        }
        public bool IsInteractDown()
        {
            return (mCurrentGamepadState.IsButtonDown(mInteractButton) || mCurrentKeyboardState.IsKeyDown(mInteractKey));

        }
        public bool IsAttackPressed()
        {
            return (mCurrentGamepadState.IsButtonDown(mAttackButton) && !mPreviousGamepadState.IsButtonDown(mAttackButton))
                || (mCurrentKeyboardState.IsKeyDown(mAttackKey) && !mPreviousKeyboardState.IsKeyDown(mAttackKey));

        }
        public bool IsAttackDown()
        {
            return (mCurrentGamepadState.IsButtonDown(mAttackButton) || mCurrentKeyboardState.IsKeyDown(mAttackKey));
        }
        public bool IsPausePressed()
        {
            return (mCurrentGamepadState.IsButtonDown(mPauseButton) && !mPreviousGamepadState.IsButtonDown(mPauseButton))
                || (mCurrentKeyboardState.IsKeyDown(mPauseKey) && !mPreviousKeyboardState.IsKeyDown(mPauseKey));

        }
        public bool IsPauseDown()
        {
            return (mCurrentGamepadState.IsButtonDown(mPauseButton) || mCurrentKeyboardState.IsKeyDown(mPauseKey));

        }
        public bool IsUpPressed()
        {
            return (mCurrentGamepadState.IsButtonDown(Buttons.DPadUp))
                || (mCurrentGamepadState.ThumbSticks.Left.Y > 0)
                || (mCurrentKeyboardState.IsKeyDown(mUpKey));
        }
        public bool IsLeftPressed()
        {
            return (mCurrentGamepadState.IsButtonDown(Buttons.DPadLeft))
                || (mCurrentGamepadState.ThumbSticks.Left.X < 0)
                || (mCurrentKeyboardState.IsKeyDown(mLeftKey));
        }
        public bool IsDownPressed()
        {
            return (mCurrentGamepadState.IsButtonDown(Buttons.DPadDown))
                || (mCurrentGamepadState.ThumbSticks.Left.Y < 0)
                || (mCurrentKeyboardState.IsKeyDown(mDownKey));
        }
        public bool IsRightPressed()
        {
            return (mCurrentGamepadState.IsButtonDown(Buttons.DPadRight))
                || (mCurrentGamepadState.ThumbSticks.Left.X > 0)
                || (mCurrentKeyboardState.IsKeyDown(mRightKey));
        }

        public void Update(GameTime aGameTime)
        {
            mPreviousGamepadState = mCurrentGamepadState;
            mPreviousKeyboardState = mCurrentKeyboardState;

            mCurrentGamepadState = GamePad.GetState(PlayerIndex.One);
            mCurrentKeyboardState = Keyboard.GetState();
        }
        #endregion
    }
}
