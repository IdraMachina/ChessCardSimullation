using GameData.CardStrategy;
using UnityEngine;

namespace GameData.CardStrategy.UnityDebug
{
    /// <summary>
    /// UnityDebugアセンブリからRuntimeアセンブリを参照できることを確認する最小スタブです。
    /// </summary>
    public sealed class UnityDebugCompileCheck : MonoBehaviour
    {
        /// <summary>
        /// Runtimeアセンブリのコンパイル確認用識別子を取得します。
        /// </summary>
        public string RuntimeAssemblyName => RuntimeCompileCheck.AssemblyName;
    }
}
