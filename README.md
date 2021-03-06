# HoloLensModule
- Twitter : [@akihiro01051](https://twitter.com/akihiro01051)

## 動作環境
- Windows10 Creators Update
- Unity 2017.4
- Visual Studio 2017
- HoloLens RS4
- Windows MixedReality Device

----------

## 概要
HoloLens開発などのUnityで利用できるスクリプトモジュールです．

## 内容
## Environment : HoloLens特有の機能やFileIOの機能
- FileIOControl.cs
  + ファイルの入出力
- SystemInfomation.cs
  + デバイス情報の取得
- TrackingWorldState.cs
  + デバイスのトラッキング状態を取得
- WorldAnchorControl.cs
  + HoloLens特有のWorldAnchor機能を提供

## Input : HoloLensとImmersiveHMDのGaze,HandGesture機能とGamePad対応
- ButtonControl.cs
  + Colliderを持つGameObjectへのAirtap入力を検知
- HandControler.cs
  + デバイスによってハンドオブジェクトの表示を切り替え
- IFocusInterface.cs
  + GazeのFocus用Interface
- IInputInterface.cs
  + ジェスチャー入力用Interface
- InputControlEvent.cs
  + デバイスからの入力をジェスチャーに変換
- RayCastControl.cs
  + Gaze機能を提供
- XBoxControler.cs
  + XBoxコントローラーの入力を取得

## Network : ネットワーク通信に関する機能
- RestAPIControl.cs
  + RestAPIを提供
- TCPClientManager.cs
  + TCPのクライアント側機能を提供
- TCPServerManager.cs
  + TCPのサーバー側機能を提供
- UDPListenerManager.cs
  + UDPの受信側機能を提供
- UDPSenderManager.cs
  + UDPの送信側機能を提供
- SharingManager.cs
  + UDPによるシェアリング機能を提供

## Utility : boundingboxやデバッグログ取得などの機能
- Bodylocked.cs
  + 視線上に対象オブジェクトを追従させる
- Boundingbox.cs
  + 3Dオブジェクトに枠をつける
- DebugConsole.cs
  + デバックログを取得できる
- SkyboxSetting.cs
  + デバイスによるSkybox設定を切り替え

## Scenes : サンプルシーン集
- Sample.unity
- TCPSample.unity
  + TPC通信のサンプル
- UDPSample.unity
  + UDP通信のサンプル
- SharingSample.unity
  + UDPによるシェアリングのサンプル
