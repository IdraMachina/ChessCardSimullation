# CardStrategy Runtime

このフォルダは、カード型戦略シミュレーションゲームの中核ロジックを配置するための Runtime 領域です。

## 方針

- Runtime 配下のコードは、原則として UnityEngine に依存しない純 C# として実装します。
- Runtime 配下には、MonoBehaviour、ScriptableObject、GameObject、Transform、Button、TextMeshProUGUI などの Unity 依存型を置きません。
- 盤面、ターン、カード、戦闘、攻城、効果処理などの中核ロジックは、後続タスクでこの配下へ追加します。
- この領域の実装は、後から自動テストを行える構造にします。

## フォルダ用途

- `Core`: 共通定数、enum、ID 型、基本的な結果型など。
- `Board`: 盤面座標、マス、盤面状態など。
- `Cards`: カード定義、カードインスタンス、カード領域など。
- `Battle`: BattleRuntime、ターン進行、陣営状態、ユニット状態など。
- `Effects`: アビリティ、計略、戦術、遺物、状態異常、地形効果などの処理入口。
- `Common`: Runtime 内の複数領域で共有する小さな補助型。
- `Logging`: BattleLog などの検証用ログ処理。

## 注意

このタスクではフォルダ構成のみを作成し、BoardState、BattleRuntime、DamageService、CardZoneState などの本実装は追加しません。
