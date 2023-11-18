using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;

public class Padd : MonoBehaviour
{
    static Padd     paddObject;
    static PadInput padInput = new PadInput();

    [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.AfterSceneLoad)]
    static void afterSceneLoad()
    {
        paddObject = FindObjectOfType<Padd>();
        if (paddObject == null)
        {
            GameObject obj = new GameObject("Padd", typeof(Padd));
            paddObject = obj.GetComponent<Padd>();

        }
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
        padInput.SetVirtualSize(width, height);
    }

    /// <summary>
    /// set pad config
    /// </summary>
    public static void SetPadConfig(PadInput.PadConfig config)
    {
        padInput.SetPadConfig(config);
    }

    /// <summary>
    /// get pad config
    /// </summary>
    public static PadInput.PadConfig GetPadConfig()
    {
        return padInput.GetPadConfig();
    }
    
    /// <summary>
    /// set key config
    /// </summary>
    public static void SetKeyConfig(PadInput.KeyConfig config)
    {
        padInput.SetKeyConfig(config);
    }

    /// <summary>
    /// get key config
    /// </summary>
    public static PadInput.KeyConfig GetKeyConfig()
    {
        return padInput.GetKeyConfig();
    }

    /// <summary>
    /// パッドボタンに対応したキーボードリストを取得する
    /// </summary>
    public static PadInput.PadWork GetPadWork(ePad padButton)
    {
        return padInput.GetPadWork(padButton);
    }

    /// <summary>
    /// set enabled of input
    /// </summary>
    public static void SetEnabled(bool enabled)
    {
        padInput.SetEnabled(enabled);
    }

    /// <summary>
    /// get enabled of input
    /// </summary>
    public static bool GetEnabled()
    {
        return padInput.GetEnabled();
    }

    /// <summary>
    /// アナログスティック（左）を取得
    /// </summary>
    /// <returns>-1（左上）～ 1（右下）、変化あったフレームは IsMoved == true</returns>
    public static PadInput.PadVector GetAxisL()
    {
        return padInput.GetAxisL();
    }

    /// <summary>
    /// アナログスティック（右）を取得
    /// </summary>
    /// <returns>-1（左上）～ 1（右下）、変化あったフレームは IsMoved == true</returns>
    public static PadInput.PadVector GetAxisR()
    {
        return padInput.GetAxisR();
    }

    /// <summary>
    /// トリガーのアナログ値（L2, R2）を取得。L2 が X、R2 が Y
    /// </summary>
    /// <returns>-1（押していない）～ 1（深く押している）、変化あったフレームは IsMoved == true</returns>
    public static PadInput.PadVector GetTrigger()
    {
        return padInput.GetTrigger();
    }

    /// <summary>
    /// マウスの座標（画面サイズによって変動）を取得します
    /// </summary>
    /// <returns>左0～右画面最大サイズ（横）、下0～上画面最大サイズ（縦）、変化あったフレームは IsMoved == true</returns>
    public static PadInput.TouchVector GetMouse()
    {
        return padInput.GetMouse();
    }

    /// <summary>
    /// タッチスクリーンの座標（画面サイズによって変動）を取得します
    /// </summary>
    /// <returns>左0～右画面最大サイズ（横）、下0～上画面最大サイズ（縦）、変化あったフレームは IsMoved == true</returns>
    public static PadInput.TouchVector GetTouchPos(int no)
    {
        return padInput.GetTouchPos(no);
    }

    /// <summary>
    /// マウスホイールのスクロール値を取得
    /// </summary>
    public static float GetMouseWheel()
    {
        return padInput.GetMouseWheel();
    }

    /// <summary>
    /// 該当のボタンが押されているかチェック
    /// </summary>
    /// <param name="button">確認するボタン</param>
    /// <returns>押されていれば true</returns>
    public static bool GetKey(ePad button)
    {
        return padInput.GetKey(button);
    }

    /// <summary>
    /// 該当のボタンが押されているかチェック
    /// </summary>
    /// <param name="buttonBit">PadInput.PAD_XXXXX 指定。OR で複数指定可能</param>
    /// <returns>押されていれば true</returns>
    public static bool GetKey(ulong buttonBit)
    {
        return padInput.GetKey(buttonBit);
    }

    /// <summary>
    /// 該当のボタンが押した瞬間かチェック
    /// </summary>
    /// <param name="button">確認するボタン</param>
    /// <returns>押された瞬間なら true</returns>
    public static bool GetKeyDown(ePad button)
    {
        return padInput.GetKeyDown(button);
    }

    /// <summary>
    /// 該当のボタンが押した瞬間かチェック
    /// </summary>
    /// <param name="buttonBit">PadInput.PAD_XXXXX 指定。OR で複数指定可能</param>
    /// <returns>押された瞬間なら true</returns>
    public static bool GetKeyDown(ulong buttonBit)
    {
        return padInput.GetKeyDown(buttonBit);
    }

    /// <summary>
    /// 該当のボタンが離した瞬間かチェック
    /// </summary>
    /// <param name="button">確認するボタン</param>
    /// <returns>離した瞬間なら true</returns>
    public static bool GetKeyUp(ePad button)
    {
        return padInput.GetKeyUp(button);
    }

    /// <summary>
    /// 該当のボタンが離した瞬間かチェック
    /// </summary>
    /// <param name="buttonBit">PadInput.PAD_XXXXX 指定。OR で複数指定可能</param>
    /// <returns>離した瞬間なら true</returns>
    public static bool GetKeyUp(ulong buttonBit)
    {
        return padInput.GetKeyUp(buttonBit);
    }

    /// <summary>
    /// 該当のボタンのリピートチェック。一定間隔でオン
    /// </summary>
    /// <param name="button">確認するボタン</param>
    /// <returns>リピートオンされた瞬間なら true</returns>
    public static bool GetKeyDelay(ePad button)
    {
        return padInput.GetKeyDelay(button);
    }

    /// <summary>
    /// 該当のボタンのリピートチェック。一定間隔でオン
    /// </summary>
    /// <param name="buttonBit">PadInput.PAD_XXXXX 指定。OR で複数指定可能</param>
    /// <returns>リピートオンされた瞬間なら true</returns>
    public static bool GetKeyDelay(ulong buttonBit)
    {
        return padInput.GetKeyDelay(buttonBit);
    }
    
    /// <summary>
    /// 最後に操作されたコントローラーの種類を取得
    /// </summary>
    public static ePadControllerType GetLastControllerType()
    {
        return padInput.GetLastControllerType();
    }

    /// <summary>
    /// Input 直接コール
    /// </summary>
    public static bool NativeKey(Key key)
    {
        return padInput.NativeKey(key);
    }

    /// <summary>
    /// Input 直接コール
    /// </summary>
    public static bool NativeKeyDown(Key key)
    {
        return padInput.NativeKeyDown(key);
    }

}
