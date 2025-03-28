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
using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

public class Padd : MonoBehaviour
{
    static Padd     paddObject;
    static PadInput padInput;

    [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.AfterSceneLoad)]
    static void afterSceneLoad()
    {
        paddObject = FindFirstObjectByType<Padd>(FindObjectsInactive.Include);
        if (paddObject == null)
        {
            GameObject obj = new GameObject("Padd", typeof(Padd));
            paddObject = obj.GetComponent<Padd>();
        }

        padInput = new PadInput();
    }

    /// <summary>
    /// update
    /// </summary>
    void Update()
    {
        padInput?.Update();
    }
    
    /// <summary>
    /// ディスプレイの仮想サイズを設定. CanvasScaler.referenceResolution と同じ値にするのが基本
    /// </summary>
    public static void SetVirtualSize(float width, float height)
    {
        padInput?.SetVirtualSize(width, height);
    }

    /// <summary>
    /// set pad config
    /// </summary>
    public static void SetPadConfig(PadInput.PadConfig config)
    {
        padInput?.SetPadConfig(config);
    }

    /// <summary>
    /// get pad config
    /// </summary>
    public static PadInput.PadConfig GetPadConfig()
    {
        if (padInput == null)
        {
            return null;
        }
        return padInput.GetPadConfig();
    }
    
    /// <summary>
    /// set key config
    /// </summary>
    public static void SetKeyConfig(PadInput.KeyConfig config)
    {
        padInput?.SetKeyConfig(config);
    }

    /// <summary>
    /// get key config
    /// </summary>
    public static PadInput.KeyConfig GetKeyConfig()
    {
        return padInput?.GetKeyConfig();
    }

    /// <summary>
    /// パッドボタンに対応したキーボードリストを取得する
    /// </summary>
    public static PadInput.PadWork GetPadWork(ePad padButton)
    {
        if (padInput == null)
        {
            return null;
        }
        return padInput?.GetPadWork(padButton);
    }

    /// <summary>
    /// AB スワップがオンになっているか確認
    /// </summary>
    /// <returns>true..オン（↓→逆転）、false..オフ（↓→そのまま）</returns>
    public static bool CheckSwapAB()
    {
        if (padInput == null)
        {
            return false;
        }
        return padInput.CheckSwapAB();
    }

    /// <summary>
    /// set enabled of input
    /// </summary>
    public static void SetEnabled(bool enabled)
    {
        padInput?.SetEnabled(enabled);
    }

    /// <summary>
    /// get enabled of input
    /// </summary>
    public static bool GetEnabled()
    {
        if (padInput == null)
        {
            return false;
        }
        return padInput.GetEnabled();
    }

    /// <summary>
    /// アナログスティック（左）を取得
    /// </summary>
    /// <returns>-1（左上）～ 1（右下）、変化あったフレームは IsMoved == true</returns>
    public static PadInput.PadVector GetAxisL()
    {
        if (padInput == null)
        {
            return null;
        }
        return padInput.GetAxisL();
    }

    /// <summary>
    /// アナログスティック（右）を取得
    /// </summary>
    /// <returns>-1（左上）～ 1（右下）、変化あったフレームは IsMoved == true</returns>
    public static PadInput.PadVector GetAxisR()
    {
        if (padInput == null)
        {
            return null;
        }
        return padInput.GetAxisR();
    }

    /// <summary>
    /// トリガーのアナログ値（L2, R2）を取得。L2 が X、R2 が Y
    /// </summary>
    /// <returns>-1（押していない）～ 1（深く押している）、変化あったフレームは IsMoved == true</returns>
    public static PadInput.PadVector GetTrigger()
    {
        if (padInput == null)
        {
            return null;
        }
        return padInput.GetTrigger();
    }

    /// <summary>
    /// マウスの座標（画面サイズによって変動）を取得します
    /// </summary>
    /// <returns>左0～右画面最大サイズ（横）、下0～上画面最大サイズ（縦）、変化あったフレームは IsMoved == true</returns>
    public static PadInput.TouchVector GetMouse()
    {
        if (padInput == null)
        {
            return null;
        }
        return padInput.GetMouse();
    }

    /// <summary>
    /// タッチスクリーンの座標（画面サイズによって変動）を取得します
    /// </summary>
    /// <returns>左0～右画面最大サイズ（横）、下0～上画面最大サイズ（縦）、変化あったフレームは IsMoved == true</returns>
    public static PadInput.TouchVector GetTouchPos(int no)
    {
        if (padInput == null)
        {
            return null;
        }
        return padInput.GetTouchPos(no);
    }

    /// <summary>
    /// マウスホイールのスクロール値を取得
    /// </summary>
    public static float GetMouseWheel()
    {
        if (padInput == null)
        {
            return 0;
        }
        return padInput.GetMouseWheel();
    }

    /// <summary>
    /// 該当のボタンが押されているかチェック
    /// </summary>
    /// <param name="button">確認するボタン</param>
    /// <returns>押されていれば true</returns>
    public static bool GetKey(ePad button)
    {
        if (padInput == null)
        {
            return false;
        }
        return padInput.GetKey(button);
    }

    /// <summary>
    /// 該当のボタンが押されているかチェック
    /// </summary>
    /// <param name="buttonBit">PadInput.PAD_XXXXX 指定。OR で複数指定可能</param>
    /// <returns>押されていれば true</returns>
    public static bool GetKey(ulong buttonBit)
    {
        if (padInput == null)
        {
            return false;
        }
        return padInput.GetKey(buttonBit);
    }

    /// <summary>
    /// 該当のボタンが押した瞬間かチェック
    /// </summary>
    /// <param name="button">確認するボタン</param>
    /// <returns>押された瞬間なら true</returns>
    public static bool GetKeyDown(ePad button)
    {
        if (padInput == null)
        {
            return false;
        }
        return padInput.GetKeyDown(button);
    }

    /// <summary>
    /// 該当のボタンが押した瞬間かチェック
    /// </summary>
    /// <param name="buttonBit">PadInput.PAD_XXXXX 指定。OR で複数指定可能</param>
    /// <returns>押された瞬間なら true</returns>
    public static bool GetKeyDown(ulong buttonBit)
    {
        if (padInput == null)
        {
            return false;
        }
        return padInput.GetKeyDown(buttonBit);
    }

    /// <summary>
    /// 該当のボタンが離した瞬間かチェック
    /// </summary>
    /// <param name="button">確認するボタン</param>
    /// <returns>離した瞬間なら true</returns>
    public static bool GetKeyUp(ePad button)
    {
        if (padInput == null)
        {
            return false;
        }
        return padInput.GetKeyUp(button);
    }

    /// <summary>
    /// 該当のボタンが離した瞬間かチェック
    /// </summary>
    /// <param name="buttonBit">PadInput.PAD_XXXXX 指定。OR で複数指定可能</param>
    /// <returns>離した瞬間なら true</returns>
    public static bool GetKeyUp(ulong buttonBit)
    {
        if (padInput == null)
        {
            return false;
        }
        return padInput.GetKeyUp(buttonBit);
    }

    /// <summary>
    /// 該当のボタンのリピートチェック。一定間隔でオン
    /// </summary>
    /// <param name="button">確認するボタン</param>
    /// <returns>リピートオンされた瞬間なら true</returns>
    public static bool GetKeyDelay(ePad button)
    {
        if (padInput == null)
        {
            return false;
        }
        return padInput.GetKeyDelay(button);
    }

    /// <summary>
    /// 該当のボタンのリピートチェック。一定間隔でオン
    /// </summary>
    /// <param name="buttonBit">PadInput.PAD_XXXXX 指定。OR で複数指定可能</param>
    /// <returns>リピートオンされた瞬間なら true</returns>
    public static bool GetKeyDelay(ulong buttonBit)
    {
        if (padInput == null)
        {
            return false;
        }
        return padInput.GetKeyDelay(buttonBit);
    }
    
    /// <summary>
    /// 最後に操作されたコントローラーの種類を取得
    /// </summary>
    public static ePadControllerType GetLastControllerType()
    {
        if (padInput == null)
        {
            return ePadControllerType.None;
        }
        return padInput.GetLastControllerType();
    }

    /// <summary>
    /// Input 直接コール
    /// </summary>
    public static bool NativeKey(Key key)
    {
        if (padInput == null)
        {
            return false;
        }
        return padInput.NativeKey(key);
    }

    /// <summary>
    /// Input 直接コール
    /// </summary>
    public static bool NativeKeyDown(Key key)
    {
        if (padInput == null)
        {
            return false;
        }
        return padInput.NativeKeyDown(key);
    }

    /// <summary>
    /// 予約キーの設定. 次の Update で判定される
    /// </summary>
    public static void SetReserveKey(ePad button)
    {
        padInput?.SetReserveKey(button);
    }

    /// <summary>
    /// 予約キーの設定. 次の Update で判定される
    /// </summary>
    public static void SetReserveKey(ulong buttonBit)
    {
        padInput?.SetReserveKey(buttonBit);
    }

}
