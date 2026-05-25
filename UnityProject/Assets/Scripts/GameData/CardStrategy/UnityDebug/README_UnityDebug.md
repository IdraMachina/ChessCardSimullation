# CardStrategy UnityDebug

このフォルダは、カード型戦略シミュレーションゲームの Runtime 状態を Unity 上で表示・操作・検証するための開発用領域です。

## 方針

- UnityDebug 配下では、MonoBehaviour、UnityEngine、UnityEngine.UI、TextMeshPro を使用してよいものとします。
- UnityDebug 側は Runtime 側を参照してよいものとします。
- Runtime 側から UnityDebug 側を参照する構造にはしません。
- Runtime の状態変更は、Presenter 経由で Runtime API を呼ぶ形に寄せます。
- View 側が BattleRuntime などの内部状態を直接書き換える構造は避けます。
- 盤面、手札、マナ、本陣 HP、ログなどの簡易GUIは、後続タスクでこの配下へ追加します。

## フォルダ用途

- `Presenter`: Runtime API と Unity 表示・入力を仲介する Presenter。
- `View`: 盤面、手札、マナ、本陣 HP、ログなどの表示用 View。
- `Input`: デバッグ操作、クリック入力、検証用コマンド入力など。
- `Scenario`: 検証用の初期状態、手順、簡易シナリオなど。

## UnityView との使い分け

`UnityDebug` は開発中の簡易GUIと検証用コードを置く場所です。
将来的な本番表示や正式UI候補は、`Assets/Scripts/GameData/CardStrategy/UnityView/` に配置します。

このタスクでは、Prefab、Scene、盤面GUI、カードGUI、マナ表示などの具体実装は追加しません。
