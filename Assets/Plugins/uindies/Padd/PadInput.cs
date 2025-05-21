// Copyright (c) catsnipe
// Released under the MIT license

// Permission is hereby granted, free of charge, to any person obtaining a 
// copy of this software and associated documentation files (the 
// "Software"), to deal in the Software without restriction, including 
// without limitation the rights to use, copy, modify, merge, publish, 
// distribute, sublicense, and/or sell copies of the Software, and to 
// permit persons to whom the Software is furnished to do so, subject to 
// the following conditions:
   
// The above copyright notice and this permission notice shall be 
// included in all copies or substantial portions of the Software.
   
// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, 
// EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF 
// MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND 
// NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE 
// LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION 
// OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION 
// WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.

using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Controls;

[Serializable]
public enum ePad
{
    None           = 0,
    [InspectorName("Up Arrow")]
    VecUp          = 1,
    UpArrow        = 1,
    [InspectorName("Right Arrow")]
    VecRight       = 2,
    RightArrow     = 2,
    [InspectorName("Left Arrow")]
    VecLeft        = 3,
    LeftArrow      = 3,
    [InspectorName("Down Arrow")]
    VecDown        = 4,
    DownArrow      = 4,

    UpButton       = 5,
    [InspectorName("Up Button")]
    Triangle       = 5,
    [InspectorName("Up Button")]
    YButton        = 5,
    [InspectorName("Up Button")]
    XSwitch        = 5,

    RightButton    = 6,
    [InspectorName("Right Button")]
    Circle         = 6,
    [InspectorName("Right Button")]
    BButton        = 6,
    [InspectorName("Right Button")]
    ASwitch        = 6,

    LeftButton     = 7,
    [InspectorName("Left Button")]
    Square         = 7,
    [InspectorName("Left Button")]
    XButton        = 7,
    [InspectorName("Left Button")]
    YSwitch        = 7,

    DownButton     = 8,
    [InspectorName("Down Button")]
    Cross          = 8,
    [InspectorName("Down Button")]
    AButton        = 8,
    [InspectorName("Down Button")]
    BSwitch        = 8,

    L1             = 9,
    R1             = 10,
    L2             = 11,
    R2             = 12,
    L3             = 13,
    R3             = 14,
    Select         = 15,
    Start          = 16,
    [InspectorName("Start")]
    Share          = 16,
    Touch1         = 17,
    Touch2         = 18,
    Touch3         = 19,
    MenuUp         = 20,
    MenuRight      = 21,
    MenuLeft       = 22,
    MenuDown       = 23,
    MenuOK         = 24,
    MenuCancel     = 25,
    MouseLeft      = 26,
    MouseMiddle    = 27,
    MouseRight     = 28,
    Click          = 29,
    AnyKey         = 30,
    PadMax         = 31,
};

public enum ePadControllerType
{
    None,
    Pad,
    Keyboard,
    Mouse,
    Touch,
}

public partial class PadInput
{
    public const ulong B_None        = (ulong)1 << (int)ePad.None;
    public const ulong B_UpArrow     = (ulong)1 << (int)ePad.UpArrow;
    public const ulong B_RightArrow  = (ulong)1 << (int)ePad.RightArrow;
    public const ulong B_LeftArrow   = (ulong)1 << (int)ePad.LeftArrow;
    public const ulong B_DownArrow   = (ulong)1 << (int)ePad.DownArrow;
    public const ulong B_UpButton    = (ulong)1 << (int)ePad.UpButton;
    public const ulong B_RightButton = (ulong)1 << (int)ePad.RightButton;
    public const ulong B_LeftButton  = (ulong)1 << (int)ePad.LeftButton;
    public const ulong B_DownButton  = (ulong)1 << (int)ePad.DownButton;
    public const ulong B_L1          = (ulong)1 << (int)ePad.L1;
    public const ulong B_R1          = (ulong)1 << (int)ePad.R1;
    public const ulong B_L2          = (ulong)1 << (int)ePad.L2;
    public const ulong B_R2          = (ulong)1 << (int)ePad.R2;
    public const ulong B_L3          = (ulong)1 << (int)ePad.L3;
    public const ulong B_R3          = (ulong)1 << (int)ePad.R3;
    public const ulong B_Select      = (ulong)1 << (int)ePad.Select;
    public const ulong B_Start       = (ulong)1 << (int)ePad.Start;
    public const ulong B_Touch1      = (ulong)1 << (int)ePad.Touch1;
    public const ulong B_Touch2      = (ulong)1 << (int)ePad.Touch2;
    public const ulong B_Touch3      = (ulong)1 << (int)ePad.Touch3;
    public const ulong B_MenuUp      = (ulong)1 << (int)ePad.MenuUp;
    public const ulong B_MenuRight   = (ulong)1 << (int)ePad.MenuRight;
    public const ulong B_MenuLeft    = (ulong)1 << (int)ePad.MenuLeft;
    public const ulong B_MenuDown    = (ulong)1 << (int)ePad.MenuDown;
    public const ulong B_MenuOK      = (ulong)1 << (int)ePad.MenuOK;
    public const ulong B_MenuCancel  = (ulong)1 << (int)ePad.MenuCancel;
    public const ulong B_MouseLeft   = (ulong)1 << (int)ePad.MouseLeft;
    public const ulong B_MouseMiddle = (ulong)1 << (int)ePad.MouseMiddle;
    public const ulong B_MouseRight  = (ulong)1 << (int)ePad.MouseRight;
    public const ulong B_Click       = (ulong)1 << (int)ePad.Click;
    public const ulong B_AnyKey      = (ulong)1 << (int)ePad.AnyKey;

    /// <summary>
    /// 何を押しても次の画面に進めたい場合などに使用
    /// </summary>
    public const ulong B_MenuAnyNext = B_MenuOK | B_MenuCancel | B_Touch1;
    /// <summary>
    /// 矢印キーで使用
    /// </summary>
    public const ulong B_Arrow       = B_UpArrow | B_RightArrow | B_LeftArrow | B_DownArrow;
    /// <summary>
    /// メニュー矢印キーで使用
    /// </summary>
    public const ulong B_MenuArrow   = B_MenuUp | B_MenuRight | B_MenuLeft | B_MenuDown;
    
    public const int   TOUCH_MAX     = 3;

    /// <summary>
    /// アナログスティックやトリガーの入力値、前回との差分などを返します
    /// </summary>
    public class PadVector
    {
        /// <summary>
        /// 現在値（0～1）
        /// </summary>
        public Vector2       Position;
        /// <summary>
        /// １フレームに移動した量
        /// </summary>
        public Vector2       Move;
        /// <summary>
        /// 移動があれば true
        /// </summary>
        public bool          IsMoved;

        const float          ADJUST_LIMIT = 0.2f;

        /// <summary>
        /// Pad の Vector を更新します
        /// </summary>
        public void Update(Vector2 v)
        {
            if (v.x >= -ADJUST_LIMIT && v.x <= ADJUST_LIMIT)
            {
                v.x = 0;
            }
            if (v.y >= -ADJUST_LIMIT && v.y <= ADJUST_LIMIT)
            {
                v.y = 0;
            }

            if (Position.x != v.x || Position.y != v.y)
            {
                IsMoved = true;
                Move    = v - Position;
                Position  = v;
            }
            else
            {
                Move    = Vector2.zero;
                IsMoved = false;
            }
        }

        /// <summary>
        /// 情報をクリア
        /// </summary>
        public void Clear()
        {
            Position = Vector2.zero;
            Move     = Vector2.zero;
            IsMoved  = false;
        }
    }

    /// <summary>
    /// マウス、タッチの情報
    /// </summary>
    public class TouchVector
    {
        /// <summary>
        /// マウスの生情報（画面外でも取得）
        /// </summary>
        public Vector2       MouseRawPosition;
        /// <summary>
        /// 開始位置
        /// </summary>
        public Vector2       StartPosition;
        /// <summary>
        /// 現在の位置
        /// </summary>
        public Vector2       Position;
        /// <summary>
        /// １フレームに移動した量
        /// </summary>
        public Vector2       Move;
        /// <summary>
        /// １フレームに移動した量（マウスクリックしながら）
        /// </summary>
        public Vector2       TouchMove;
        /// <summary>
        /// タッチしてから今までにドラッグ移動した量
        /// </summary>
        public Vector2       TouchMoveAll;
        /// <summary>
        /// ホイールの移動量
        /// </summary>
        public float         MouseWheel;
        /// <summary>
        /// 移動があれば true
        /// </summary>
        public bool          IsMoved;

        Vector2              topPosition = Vector2.zero;

        /// <summary>
        /// Vector を更新します
        /// </summary>
        public void Update(Vector2 v, bool touch)
        {
            if (touch == true)
            {
                if (topPosition == Vector2.zero)
                {
                    topPosition = v;
                }
                Vector2 pre  = TouchMoveAll;

                TouchMoveAll = v - topPosition;
                TouchMove    = TouchMoveAll - pre;
            }
            else
            {
                topPosition  = Vector2.zero;
                TouchMove    = Vector2.zero;
                TouchMoveAll = Vector2.zero;
            }

            if (Position.x != v.x || Position.y != v.y)
            {
                IsMoved  = true;
                if (Position.x != 0 || Position.y != 0)
                {
                    Move = v - Position;
                }
                Position = v;
            }
            else
            if (MouseWheel != 0)
            {
                if (IsMoved == false)
                {
                    IsMoved = true;
                    TouchMove.y    = -MouseWheel / 2;
                    TouchMoveAll.y = -MouseWheel / 2;
                }
            }
            else
            {
                Move    = Vector2.zero;
                IsMoved = false;
            }
        }

        /// <summary>
        /// 情報をコピー
        /// </summary>
        public void Copy(TouchVector vec)
        {
            StartPosition    = vec.StartPosition ;
            MouseRawPosition = vec.MouseRawPosition;
            Position         = vec.Position      ;
            Move             = vec.Move          ;
            TouchMove        = vec.TouchMove     ;
            TouchMoveAll     = vec.TouchMoveAll  ;
            MouseWheel       = vec.MouseWheel    ;
            IsMoved          = vec.IsMoved       ;
            topPosition      = vec.topPosition   ;
        }

        /// <summary>
        /// 情報をクリア
        /// </summary>
        public void Clear()
        {
            StartPosition    = Vector2.zero;
            MouseRawPosition = Vector2.zero;
            Position         = Vector2.zero;
            Move             = Vector2.zero;
            TouchMove        = Vector2.zero;
            TouchMoveAll     = Vector2.zero;
            topPosition      = Vector2.zero;

            MouseWheel       = 0;
            IsMoved          = false;
        }

        /// <summary>
        /// 開始位置を設定
        /// </summary>
        public void SetStartPosition(Vector2 v)
        {
            StartPosition = v;
        }
        
        /// <summary>
        /// 開始位置から移動したかチェック
        /// </summary>
        /// <returns>true..移動した</returns>
        public bool CheckMovePositionFromStart()
        {
            Vector2 v = Position - StartPosition;
            return v.x != 0 || v.y != 0;
        }

        float cubicOut(float t)
        {
            t -= 1;
            float v = t * t * t + 1;
            return v;
        }
    }

    class PadInfo
    {
        public ulong              Button;
        public ulong              ButtonDown;
        public ulong              ButtonUp;
        public ulong              ButtonDelay;
        public PadVector          AxisL   = new PadVector();
        public PadVector          AxisR   = new PadVector();
        public PadVector          Trigger = new PadVector();
        public TouchVector        Mouse   = new TouchVector();
        public List<TouchVector>  TouchPos = new List<TouchVector>();

        public ePadControllerType LastControllerType;  

#if UNITY_STANDALONE || UNITY_EDITOR
        public bool               KeyboardConnect;
        public bool               GamePadConnect;
#endif
        public bool               MouseConnect;

        /// <summary>.ctor</summary>
        public PadInfo()
        {
            for (int i = 0; i < TOUCH_MAX; i++)
            {
                TouchPos.Add(new TouchVector());
            }

            LastControllerType = ePadControllerType.None;

#if UNITY_STANDALONE || UNITY_EDITOR
            KeyboardConnect = true;
            MouseConnect    = true;
#endif
        }

        /// <summary>clear</summary>
        public void Clear()
        {
            Button       = 0;
            ButtonDown   = 0;
            ButtonUp     = 0;
            ButtonDelay  = 0;
        }
    }

    class RepeatCounter
    {
        public float    RepeatTime  = 0;
        public int      RepeatCount = 0;
    }

    public class PadWork
    {
        public Key[]    KeyBinds;

        /// <summary>
        /// .ctor
        /// </summary>
        public PadWork(Key[] keyBinds)
        {
            KeyBinds = keyBinds;
        }
    }

    /// <summary>
    /// キーコンフィグ用データ
    /// </summary>
    [Serializable]
    public class KeyConfig
    {
        /// <summary>
        /// キーバインド変更（１つのボタンに複数のキー可能）
        /// </summary>
        public Key[]	VecU;
        public Key[]	VecR;
        public Key[]	VecL;
        public Key[]	VecD;
        public Key[]	ButU;
        public Key[]	ButR;
        public Key[]	ButL;
        public Key[]	ButD;
        public Key[]	L1;
        public Key[]	R1;
        public Key[]	L2;
        public Key[]	R2;
        public Key[]	L3;
        public Key[]	R3;
        public Key[]	Select;
        public Key[]	Start;
        public Key[]	Touch1;

        /// <summary>
        /// .ctor
        /// </summary>
        public KeyConfig()
        {
            VecU   = new Key[] { Key.UpArrow, Key.W };
            VecD   = new Key[] { Key.DownArrow, Key.S };
            VecL   = new Key[] { Key.LeftArrow, Key.A };
            VecR   = new Key[] { Key.RightArrow, Key.D };
            ButD   = new Key[] { Key.Z, Key.Enter };
            ButR   = new Key[] { Key.X, Key.Escape };
            ButL   = new Key[] { Key.C };
            ButU   = new Key[] { Key.V };
            L1     = new Key[] { Key.F1 };
            R1     = new Key[] { Key.F2 };
            L2     = new Key[] { Key.F3 };
            R2     = new Key[] { Key.F4 };
            L3     = new Key[] { Key.B };
            R3     = new Key[] { Key.N };
            Select = new Key[] { Key.Digit1 };
            Start  = new Key[] { Key.Digit2 };
            Touch1 = new Key[] { Key.Digit3 };
        }
    }

    /// <summary>
    /// パッドコンフィグ用データ
    /// </summary>
    [Serializable]
    public class PadConfig
    {
        /// <summary>
        /// １つ目のディレイタイム（秒）
        /// </summary>
        public float    FirstDelay;
        /// <summary>
        /// ２つ目以降のディレイタイム（秒）
        /// </summary>
        public float    SecondDelay;
        /// <summary>
        /// MenuUp, MenuDown, MenuLeft, MenuRight を左スティックでも許可する
        /// </summary>
        public bool     LeftStickMenu;
        /// <summary>
        /// MenuUp, MenuDown, MenuLeft, MenuRight を右スティックでも許可する
        /// </summary>
        public bool     RightStickMenu;
        /// <summary>
        /// AB ボタン入れ替え
        /// </summary>
        public bool     SwapAB;
        /// <summary>
        /// タッチ（マウス操作）オンオフ
        /// </summary>
        public bool     TouchEnabled;
        /// <summary>
        /// パッド入力入れ替え用
        /// </summary>
        public ePad[]   Pad;

        /// <summary>
        /// .ctor
        /// </summary>
        public PadConfig()
        {
            FirstDelay     = 0.25f;
            SecondDelay    = 0.04f;
            LeftStickMenu  = true;
            RightStickMenu = true;
            TouchEnabled   = true;

            Pad = new ePad[(int)ePad.PadMax];
            for (int i = 0; i < Pad.Length; i++)
            {
                ePad epad = (ePad)Enum.ToObject(typeof(ePad), i);
                Pad[i] = epad;
            }
        }
    }

    Vector2          virtualSize = new Vector2(1920, 1080);
    PadInfo          pad;
    PadConfig        padConfig;
    KeyConfig        keyConfig;
    PadWork[]        padWorks;
    RepeatCounter[]  repCounts;
    ulong            reserveButton;
    bool             isEnabled;
    
#if UNITY_STANDALONE || UNITY_EDITOR || UNITY_SWITCH
    static Vector2 _axisL   = new Vector2();
    static Vector2 _axisR   = new Vector2();
    static Vector2 _trigger = new Vector2();
#endif
#if UNITY_STANDALONE || UNITY_EDITOR
    static Vector2 _mouse   = new Vector2();
#endif

#if UNITY_IOS || UNITY_ANDROID || UNITY_SWITCH
    static ePad[]  touchPads = new ePad[TOUCH_MAX] { ePad.Touch1, ePad.Touch2, ePad.Touch3 };
#endif

    /// <summary>
    /// .ctor
    /// </summary>
    public PadInput()
    {
        pad       = new PadInfo();
        padConfig = new PadConfig();
        keyConfig = new KeyConfig();
        padWorks  = new PadWork[(int)ePad.PadMax];
        repCounts = new RepeatCounter[(int)ePad.PadMax];
        for (int i = 0; i < repCounts.Length; i++)
        {
            repCounts[i] = new RepeatCounter();
        }

        setKeyConfig(keyConfig);

#if UNITY_SWITCH
        pad.LastControllerType = ePadControllerType.Pad;
        initializeSwitch();
#elif UNITY_STANDALONE
        pad.LastControllerType = ePadControllerType.Pad;
#elif UNITY_IOS || UNITY_ANDROID
        pad.LastControllerType = ePadControllerType.Touch;
#endif

        isEnabled = true;
    }

    /// <summary>
    /// update
    /// </summary>
    public void Update()
    {
        var preButton = pad.Button;

        pad.Clear();

        // 予約ボタン
        pad.Button |= reserveButton;
        reserveButton = 0;

        if (isEnabled == true)
        {
#if UNITY_IOS || UNITY_ANDROID
            if (padConfig.TouchEnabled == true)
            {
                getRawControl_Touch();
            }
#endif
#if UNITY_STANDALONE || UNITY_EDITOR
            getRawControl_Keyboard();
            getRawControl_Pad();

            if (padConfig.TouchEnabled == true)
            {
                getRawControl_Mouse(preButton);
            }
#endif
#if UNITY_SWITCH
            getRawControl_Switch();
#endif

            // MENU_XXX など
            getReserveControl(preButton);
        }

        // push
        pad.ButtonDown   =  pad.Button & ~preButton;
        // release
        pad.ButtonUp     = ~pad.Button &  preButton;

//DDisp.Log($"{pad.LastControllerType}");
//DDisp.Log($"{pad.Button.ToString("X16")}");
        // repeat
        pad.ButtonDelay =  pad.ButtonDown;

        float time = Time.time;

        for (int i = 0; i < (int)ePad.PadMax; i++)
        {
            ulong button_bit = (ulong)1 << i;

            if ((pad.Button & button_bit) != 0)
            {
                RepeatCounter work = repCounts[i];
                if (work == null)
                {
                    continue;
                }

                if ((pad.ButtonDown & button_bit) != 0)
                {
                    work.RepeatCount = 0;
                }

                if (work.RepeatCount == 0)
                {
                    work.RepeatTime = time;
                    work.RepeatCount++;
                }
                else
                if (work.RepeatCount == 1)
                {
                    if (work.RepeatTime + padConfig.FirstDelay < time)
                    {
                        pad.ButtonDelay |= button_bit;
                        work.RepeatTime += padConfig.FirstDelay;
                        work.RepeatCount++;
                    }
                }
                else
                {
                    if (work.RepeatTime + padConfig.SecondDelay < time)
                    {
                        pad.ButtonDelay |= button_bit;
                        work.RepeatTime += padConfig.SecondDelay;
                        work.RepeatCount++;
                    }
                }
            }
        }
    }

    /// <summary>
    /// ディスプレイの仮想サイズを設定. CanvasScaler.referenceResolution と同じ値にするのが基本
    /// </summary>
    public void SetVirtualSize(float width, float height)
    {
        virtualSize = new Vector2(width, height);
    }

    /// <summary>
    /// ディスプレイの仮想サイズを取得
    /// </summary>
    public Vector2 GetVirtualSize()
    {
        return virtualSize;
    }

    /// <summary>
    /// パッドコンフィグ設定
    /// </summary>
    public void SetPadConfig(PadConfig config)
    {
        padConfig = config;
    }

    /// <summary>
    /// 現在のパッドコンフィグを取得
    /// </summary>
    public PadConfig GetPadConfig()
    {
        using (var memoryStream = new System.IO.MemoryStream())
        {
            var binaryFormatter = new System.Runtime.Serialization.Formatters.Binary.BinaryFormatter();
            binaryFormatter.Serialize(memoryStream, padConfig);
            memoryStream.Seek(0, System.IO.SeekOrigin.Begin);
            return (PadConfig)binaryFormatter.Deserialize(memoryStream);
        }
    }

    /// <summary>
    /// キーコンフィグ設定
    /// </summary>
    public void SetKeyConfig(KeyConfig config)
    {
        keyConfig = config;
        setKeyConfig(keyConfig);
    }

    /// <summary>
    /// 現在のキーコンフィグを取得
    /// </summary>
    public KeyConfig GetKeyConfig()
    {
        using (var memoryStream = new System.IO.MemoryStream())
        {
            var binaryFormatter = new System.Runtime.Serialization.Formatters.Binary.BinaryFormatter();
            binaryFormatter.Serialize(memoryStream, keyConfig);
            memoryStream.Seek(0, System.IO.SeekOrigin.Begin);
            return (KeyConfig)binaryFormatter.Deserialize(memoryStream);
        }
    }

    /// <summary>
    /// パッドボタンに対応したキーボードリストを取得する
    /// </summary>
    public PadWork GetPadWork(ePad padButton)
    {
        if (padButton == ePad.RightButton || padButton == ePad.DownButton)
        {
            if (padConfig.SwapAB == true)
            {
                if (padButton == ePad.RightButton)
                {
                    padButton = ePad.DownButton;
                }
                else
                {
                    padButton = ePad.RightButton;
                }

            }
        }

        return padWorks[(int)padButton];
    }

    /// <summary>
    /// AB スワップがオンになっているか確認
    /// </summary>
    /// <returns>true..オン（↓→逆転）、false..オフ（↓→そのまま）</returns>
    public bool CheckSwapAB()
    {
        return padConfig.SwapAB;
    }

    /// <summary>
    /// set enabled of input
    /// </summary>
    public void SetEnabled(bool enabled)
    {
        isEnabled = enabled;
        if (isEnabled == false)
        {
            pad.Clear();
        }
    }

    /// <summary>
    /// get enabled of input
    /// </summary>
    public bool GetEnabled()
    {
        return isEnabled;
    }

    /// <summary>
    /// アナログスティック（左）を取得
    /// </summary>
    /// <returns>-1（左上）～ 1（右下）、変化あったフレームは IsMoved == true</returns>
    public PadVector GetAxisL()
    {
        return pad.AxisL;
    }

    /// <summary>
    /// アナログスティック（右）を取得
    /// </summary>
    /// <returns>-1（左上）～ 1（右下）、変化あったフレームは IsMoved == true</returns>
    public PadVector GetAxisR()
    {
        return pad.AxisR;
    }

    /// <summary>
    /// トリガーのアナログ値（L2, R2）を取得。L2 が X、R2 が Y
    /// </summary>
    /// <returns>-1（押していない）～ 1（深く押している）、変化あったフレームは IsMoved == true</returns>
    public PadVector GetTrigger()
    {
        return pad.Trigger;
    }
    
    /// <summary>
    /// マウスの座標（画面サイズによって変動）を取得します
    /// </summary>
    /// <returns>左0～右画面最大サイズ（横）、下0～上画面最大サイズ（縦）、変化あったフレームは IsMoved == true</returns>
    public TouchVector GetMouse()
    {
        return pad.Mouse;
    }
    
    /// <summary>
    /// タッチスクリーンの座標（画面サイズによって変動）を取得します
    /// </summary>
    /// <returns>左0～右画面最大サイズ（横）、下0～上画面最大サイズ（縦）、変化あったフレームは IsMoved == true</returns>
    public TouchVector GetTouchPos(int no)
    {
        no = Mathf.Clamp(no, 0, 2);
        return pad.TouchPos[no];
    }

    /// <summary>
    /// マウスホイールのスクロール値を取得
    /// </summary>
    public float GetMouseWheel()
    {
        return pad.Mouse.MouseWheel;
    }

    /// <summary>
    /// 該当のボタンが押されているかチェック
    /// </summary>
    /// <param name="button">確認するボタン</param>
    /// <returns>押されていれば true</returns>
    public bool GetKey(ePad button)
    {
        return (pad.Button & (ulong)(1 << (int)button)) != 0;
    }

    /// <summary>
    /// 該当のボタンが押されているかチェック
    /// </summary>
    /// <param name="buttonBit">PadInput.PAD_XXXXX 指定。OR で複数指定可能</param>
    /// <returns>押されていれば true</returns>
    public bool GetKey(ulong buttonBit)
    {
        return (pad.Button & buttonBit) != 0;
    }

    /// <summary>
    /// 該当のボタンが押した瞬間かチェック
    /// </summary>
    /// <param name="button">確認するボタン</param>
    /// <returns>押された瞬間なら true</returns>
    public bool GetKeyDown(ePad button)
    {
        return (pad.ButtonDown & (ulong)(1 << (int)button)) != 0;
    }

    /// <summary>
    /// 該当のボタンが押した瞬間かチェック
    /// </summary>
    /// <param name="buttonBit">PadInput.PAD_XXXXX 指定。OR で複数指定可能</param>
    /// <returns>押された瞬間なら true</returns>
    public bool GetKeyDown(ulong buttonBit)
    {
        return (pad.ButtonDown & buttonBit) != 0;
    }

    /// <summary>
    /// 該当のボタンが離した瞬間かチェック
    /// </summary>
    /// <param name="button">確認するボタン</param>
    /// <returns>離した瞬間なら true</returns>
    public bool GetKeyUp(ePad button)
    {
        return (pad.ButtonUp & (ulong)(1 << (int)button)) != 0;
    }

    /// <summary>
    /// 該当のボタンが離した瞬間かチェック
    /// </summary>
    /// <param name="buttonBit">PadInput.PAD_XXXXX 指定。OR で複数指定可能</param>
    /// <returns>離した瞬間なら true</returns>
    public bool GetKeyUp(ulong buttonBit)
    {
        return (pad.ButtonUp & buttonBit) != 0;
    }

    /// <summary>
    /// 該当のボタンのリピートチェック。一定間隔でオン
    /// </summary>
    /// <param name="button">確認するボタン</param>
    /// <returns>リピートオンされた瞬間なら true</returns>
    public bool GetKeyDelay(ePad button)
    {
        return (pad.ButtonDelay & (ulong)(1 << (int)button)) != 0;
    }

    /// <summary>
    /// 該当のボタンのリピートチェック。一定間隔でオン
    /// </summary>
    /// <param name="buttonBit">PadInput.PAD_XXXXX 指定。OR で複数指定可能</param>
    /// <returns>リピートオンされた瞬間なら true</returns>
    public bool GetKeyDelay(ulong buttonBit)
    {
        
        return (pad.ButtonDelay & buttonBit) != 0;
    }

    /// <summary>
    /// 最後に操作されたコントローラーの種類を取得
    /// </summary>
    public ePadControllerType GetLastControllerType()
    {
        return pad.LastControllerType;
    }

    /// <summary>
    /// Input 直接コール
    /// </summary>
    public bool NativeKey(Key key)
    {
        if (Keyboard.current == null) return false;
        return Keyboard.current[key].isPressed;
    }

    /// <summary>
    /// Input 直接コール
    /// </summary>
    public bool NativeKeyDown(Key key)
    {
        if (Keyboard.current == null) return false;
        return Keyboard.current[key].wasPressedThisFrame;
    }

    /// <summary>
    /// 予約キーの設定. 次の Update で判定される
    /// </summary>
    public void SetReserveKey(ePad button)
    {
        reserveButton |= getPadBit(button);
    }

    /// <summary>
    /// 予約キーの設定. 次の Update で判定される
    /// </summary>
    public void SetReserveKey(ulong buttonBit)
    {
        reserveButton |= buttonBit;
    }

#if UNITY_IOS || UNITY_ANDROID
    /// <summary>
    /// タッチコントロール
    /// </summary>
    void getRawControl_Touch()
    {
        if (Touchscreen.current == null)
        {
            return;
        }

        int touchcnt = Touchscreen.current.touches.Count < TOUCH_MAX ? Touchscreen.current.touches.Count : TOUCH_MAX;

        ulong button = pad.Button;

        for (int i = 0; i < touchcnt; i++)
        {
            TouchControl tctl = Touchscreen.current.touches[i];
            if (tctl.press.isPressed == true)
            {
                pad.Button |= (ulong)1 << (int)touchPads[i];
                if (tctl.press.wasPressedThisFrame == false)
                {
                    Vector2 vec = tctl.position.ReadValue();

                    vec = getVirtualPosition(vec);

                    pad.TouchPos[i].Update(vec, true);
                }
            }
            else
            {
                pad.TouchPos[i].Clear();
            }
        }

        if (pad.Button != button)
        {
            pad.LastControllerType = ePadControllerType.Touch;
        }
    }
#endif

    ulong getPadBit(ePad pad)
    {
        return (ulong)1 << (int)padConfig.Pad[(int)pad];
    }

#if UNITY_STANDALONE || UNITY_EDITOR
    /// <summary>
    /// パッド入力を pad.Button に格納。キーアサインつき
    /// </summary>
    void getRawControl_Pad()
    {
        var gamepad = Gamepad.current;
        if (gamepad == null)
        {
            if (pad.GamePadConnect == true)
            {
                Debug.Log("[gamepad] Disconnect.");
                pad.GamePadConnect = false;
            }
            // 信号切断
            return;
        }
        else
        {
            if (pad.GamePadConnect == false)
            {
                Debug.Log($"[gamepad] Connect. '{gamepad.device.displayName}'");
                pad.GamePadConnect = true;
            }
        }

        _axisL     = gamepad.leftStick.ReadValue();
        _axisR     = gamepad.rightStick.ReadValue();
        _trigger.x = gamepad.leftTrigger.ReadValue();
        _trigger.y = gamepad.rightTrigger.ReadValue();
        pad.AxisL.Update(_axisL);
        pad.AxisR.Update(_axisR);
        pad.Trigger.Update(_trigger);
        
        ulong button = pad.Button;

        if (gamepad.buttonNorth.isPressed == true)      pad.Button |= getPadBit(ePad.UpButton);
        if (gamepad.buttonEast.isPressed == true)       pad.Button |= getPadBit(ePad.RightButton);
        if (gamepad.buttonWest.isPressed == true)       pad.Button |= getPadBit(ePad.LeftButton);
        if (gamepad.buttonSouth.isPressed == true)      pad.Button |= getPadBit(ePad.DownButton);
        if (gamepad.selectButton.isPressed == true)     pad.Button |= getPadBit(ePad.Select);
        if (gamepad.startButton.isPressed == true)      pad.Button |= getPadBit(ePad.Start);
        if (gamepad.dpad.up.isPressed == true)          pad.Button |= getPadBit(ePad.VecUp);
        if (gamepad.dpad.right.isPressed == true)       pad.Button |= getPadBit(ePad.VecRight);
        if (gamepad.dpad.left.isPressed == true)        pad.Button |= getPadBit(ePad.VecLeft);
        if (gamepad.dpad.down.isPressed == true)        pad.Button |= getPadBit(ePad.VecDown);
        if (gamepad.leftShoulder.isPressed == true)     pad.Button |= getPadBit(ePad.L1);
        if (gamepad.rightShoulder.isPressed == true)    pad.Button |= getPadBit(ePad.R1);
        if (gamepad.leftTrigger.isPressed == true)      pad.Button |= getPadBit(ePad.L2);
        if (gamepad.rightTrigger.isPressed == true)     pad.Button |= getPadBit(ePad.R2);
        if (gamepad.leftStickButton.isPressed == true)  pad.Button |= getPadBit(ePad.L3);
        if (gamepad.rightStickButton.isPressed == true) pad.Button |= getPadBit(ePad.R3);
        
        if (pad.Button != button ||
            pad.AxisL.IsMoved == true ||
            pad.AxisR.IsMoved == true ||
            pad.Trigger.IsMoved == true )
        {
            pad.LastControllerType = ePadControllerType.Pad;
        }
//        Debug.Log($"{pad.AnalogL.x} {pad.AnalogL.y} {pad.AnalogR.x} {pad.AnalogR.y} {pad.Trigger.x} {pad.Trigger.y}");
    }

    /// <summary>
    /// キーボードの入力を pad.Button に変換し、格納
    /// </summary>
    void getRawControl_Keyboard()
    {
        if (Keyboard.current == null)
        {
            if (pad.KeyboardConnect == true)
            {
                Debug.LogWarning("[keyboard] Disconnect.");
                pad.KeyboardConnect = false;
            }
            return;
        }
        else
        {
            if (pad.KeyboardConnect == false)
            {
                Debug.LogWarning("[keyboard] Connect.");
                pad.KeyboardConnect = true;
            }
        }

        ulong button = 0;

        for (int i = 0; i < padWorks.Length; i++)
        {
            if (padWorks[i] == null)
            {
                continue;
            }

            foreach (Key bind in padWorks[i].KeyBinds)
            {
                if (bind == Key.None)
                {
                    continue;
                }
                if (Keyboard.current[bind].isPressed == true)
                {
                    button |= (ulong)1 << i;
                }
            }
        }
        button = swapAB(button);

        pad.Button |= button;

#if UNITY_STANDALONE
        if (pad.Button != button)
        {
            pad.LastControllerType = ePadControllerType.Keyboard;
        }
#endif
    }
#endif

    Vector2 getVirtualPosition(Vector2 pos)
    {
        if (virtualSize.x != Screen.width || virtualSize.y != Screen.height)
        {
            float scale_w = Screen.width  / virtualSize.x;
            float scale_h = Screen.height / virtualSize.y;

            float maskWidth;
            float maskHeight;

            if (Mathf.Abs(scale_w - scale_h) < 0.001f)
            {
                maskWidth  = 0;
                maskHeight = 0;
            }
            else
            if (scale_w > scale_h)
            {
                // 横方向にマスク
                maskWidth = ((Screen.width / scale_h) - virtualSize.x) / 2;
                maskWidth *= scale_h;
                maskHeight = 0;
            }
            else
            {
                // 縦方向にマスク
                maskWidth  = 0;
                maskHeight = ((Screen.height / scale_w) - virtualSize.y) / 2;
                maskHeight *= scale_w;
            }

            if (maskWidth > 0)
            {
                if (pos.x < maskWidth)
                {
                    pos.x = -1;
                }
                else
                if (pos.x > Screen.width - maskWidth)
                {
                    pos.x = virtualSize.x + 1;
                }
                else
                {
                    pos.x = (pos.x - maskWidth) / scale_h;
                }
                pos.y = pos.y *  virtualSize.y / Screen.height;

            }
            else
            if (maskHeight > 0)
            {
                if (pos.y < maskHeight)
                {
                    pos.y = -1;
                }
                else
                if (pos.y > Screen.height - maskHeight)
                {
                    pos.y = virtualSize.y + 1;
                }
                else
                {
                    pos.y = (pos.y - maskHeight) / scale_w;
                }
                pos.x = pos.x * virtualSize.x / Screen.width;
            }
            else
            if (maskHeight == 0)
            {
                pos.x = pos.x * virtualSize.x / Screen.width;
                pos.y = pos.y * virtualSize.y / Screen.height;
            }
        }

        return pos;
    }

#if UNITY_STANDALONE || UNITY_EDITOR
    /// <summary>
    /// マウスの入力を pad.Button に変換し、格納
    /// </summary>
    void getRawControl_Mouse(ulong preButton)
    {
        if (Mouse.current == null)
        {
            if (pad.MouseConnect == true)
            {
                Debug.LogWarning("[mouse] Disconnect.");
                pad.MouseConnect = false;
            }
            return;
        }
        else
        {
            if (pad.MouseConnect == false)
            {
                Debug.LogWarning("[mouse] Connect.");
                pad.MouseConnect = true;
            }
        }

        _mouse = Mouse.current.position.ReadValue();

        _mouse = getVirtualPosition(_mouse);

        pad.Mouse.MouseRawPosition = _mouse;

        // clipping
        if (virtualSize.x == 0 && virtualSize.y == 0)
        {
            if (_mouse.x < 0 || (_mouse.x > Screen.width ) ||
                _mouse.y < 0 || (_mouse.y > Screen.height))
            {
                pad.Mouse.Clear();
                return;
            }
        }
        else
        {
            if (_mouse.x < 0 || (_mouse.x > virtualSize.x) ||
                _mouse.y < 0 || (_mouse.y > virtualSize.y))
            {
                pad.Mouse.Clear();
                return;
            }
        }

        ulong button = pad.Button;

        bool[] pressed =
        {
            Mouse.current.leftButton.isPressed,
            Mouse.current.middleButton.isPressed,
            Mouse.current.rightButton.isPressed,
        };
        ulong[] mouses =
        {
            B_MouseLeft, B_MouseMiddle, B_MouseRight,
        };

        for (int i = 0; i < mouses.Length; i++)
        {
            if (pressed[i] == true)
            {
                pad.Button |= mouses[i];
                if (mouses[i] == B_MouseLeft && (preButton & mouses[i]) == 0)
                {
                    pad.Mouse.SetStartPosition(_mouse);
                }
            }
        }

        float   wheel = Mouse.current.scroll.ReadValue().y;

        if (wheel != pad.Mouse.MouseWheel)
        {
            pad.Button |= B_AnyKey;
        }
        pad.Mouse.MouseWheel = wheel;

        pad.Mouse.Update(_mouse, (pad.Button & B_MouseLeft) != 0);

        // クリックは、押して、移動なしに離したら発生する
        if (
            (preButton & B_MouseLeft)  != 0 && 
            (pad.Button & B_MouseLeft) == 0 &&
            pad.Mouse.CheckMovePositionFromStart() == false
        )
        {
            pad.Button |= B_Click;
        }

#if UNITY_STANDALONE
        if (pressed[0] == true ||
            pressed[1] == true ||
            pressed[2] == true ||
            pad.Mouse.IsMoved == true )
        {
            pad.LastControllerType = ePadControllerType.Mouse;
        }
#endif
    }
#endif

    /// <summary>
    /// MENU_XXX などの予約コントロールの設定
    /// </summary>
    void getReserveControl(ulong preButton)
    {
        // UNITY_EDITOR ではマウスをタッチの代わりに見立てる
#if UNITY_STANDALONE || UNITY_EDITOR
        pad.TouchPos[0].Copy(pad.Mouse);
#endif

        if ((pad.Button & B_Touch1) != 0)
        {
            pad.Button |= B_MouseLeft;
        }
        if (
            (preButton & B_Touch1)  != 0 &&
            (pad.Button & B_Touch1) == 0
        )
        {
            pad.Button |= B_Click;
        }

#if UNITY_STANDALONE || UNITY_EDITOR
        if ((pad.Button & B_MouseLeft) != 0)
        {
            pad.Button |= B_Touch1;
        }
#endif
// マウス直選択と決定ボタンが競合するのでやらないこと
//#if UNITY_STANDALONE || UNITY_EDITOR
//        if ((pad.Button & B_MouseLeft) != 0)
//        {
//            pad.Button |= B_Touch1 | B_DownButton;
//        }
//        if ((pad.Button & B_MouseRight) != 0)
//        {
//            pad.Button |= B_RightButton;
//        }
//#endif

        // 決定・キャンセルを入れ替える
        pad.Button = swapAB(pad.Button);
        
        if ((pad.Button & B_LeftArrow) != 0)
        {
            pad.Button |= B_MenuLeft;
        }
        if ((pad.Button & B_RightArrow) != 0)
        {
            pad.Button |= B_MenuRight;
        }
        if ((pad.Button & B_DownArrow) != 0)
        {
            pad.Button |= B_MenuDown;
        }
        if ((pad.Button & B_UpArrow) != 0)
        {
            pad.Button |= B_MenuUp;
        }

        if (padConfig.LeftStickMenu == true)
        {
            if (pad.AxisL.Position.x <= -0.6f)
            {
                pad.Button |= B_MenuLeft;
            }
            if (pad.AxisL.Position.x >=  0.6f)
            {
                pad.Button |= B_MenuRight;
            }
            if (pad.AxisL.Position.y <= -0.6f)
            {
                pad.Button |= B_MenuDown;
            }
            if (pad.AxisL.Position.y >=  0.6f)
            {
                pad.Button |= B_MenuUp;
            }
        }

        if (padConfig.RightStickMenu == true)
        {
            if (pad.AxisR.Position.x <= -0.6f)
            {
                pad.Button |= B_MenuLeft;
            }
            if (pad.AxisR.Position.x >=  0.6f)
            {
                pad.Button |= B_MenuRight;
            }
            if (pad.AxisR.Position.y <= -0.6f)
            {
                pad.Button |= B_MenuDown;
            }
            if (pad.AxisR.Position.y >=  0.6f)
            {
                pad.Button |= B_MenuUp;
            }
        }

        if ((pad.Button & B_DownButton) != 0)
        {
            pad.Button |= B_MenuOK;
        }
        if ((pad.Button & B_RightButton) != 0)
        {
            pad.Button |= B_MenuCancel;
        }

        if (pad.Button != 0)
        {
            pad.Button |= B_AnyKey;
        }
    }
    
    ulong swapAB(ulong button)
    {
        if (padConfig.SwapAB == true)
        {
            ulong buttonDecide = button & B_DownButton;
            ulong buttonCancel = button & B_RightButton;
            
            button &= ~(B_RightButton | B_DownButton);
            if (buttonDecide != 0)
            {
                button |= B_RightButton;
            }
            if (buttonCancel != 0)
            {
                button |= B_DownButton;
            }
        }

        return button;
    }

    /// <summary>
    /// パッドボタンのキーバインド設定
    /// </summary>
    void setKeyConfig(KeyConfig config)
    {
        List<ePad> padButtons = new List<ePad>
        {
            ePad.VecUp,
            ePad.VecRight,
            ePad.VecLeft,
            ePad.VecDown,
            ePad.UpButton,
            ePad.RightButton,
            ePad.LeftButton,
            ePad.DownButton,
            ePad.L1,
            ePad.R1,
            ePad.L2,
            ePad.R2,
            ePad.L3,
            ePad.R3,
            ePad.Select,
            ePad.Start,
            ePad.Touch1,
            ePad.MenuUp,
            ePad.MenuRight,
            ePad.MenuLeft,
            ePad.MenuDown,
        };

        List<Key[]> keyButtons = new List<Key[]>
        {
            config.VecU,
            config.VecR,
            config.VecL,
            config.VecD,
            config.ButU,
            config.ButR,
            config.ButL,
            config.ButD,
            config.L1,
            config.R1,
            config.L2,
            config.R2,
            config.L3,
            config.R3,
            config.Select,
            config.Start,
            config.Touch1,
            config.VecU,
            config.VecR,
            config.VecL,
            config.VecD,
        };

#if UNITY_EDITOR
        System.Text.StringBuilder debugLog = new System.Text.StringBuilder();
        debugLog.AppendLine("[PadInput KeyConfig]");
#endif

        for (int i = 0; i < padButtons.Count; i++)
        {
            var padButton  = padButtons[i];
            var keyButton  = keyButtons[i];

            padWorks[(int)padButton] = new PadWork(keyButton);
#if UNITY_EDITOR
            debugLog.AppendLine($"  {padButton.ToString().PadRight(10, ' ')}: {string.Join(",", keyButton)}");
#endif
        }

#if UNITY_EDITOR
        Debug.Log(debugLog);
#endif
    }
}
