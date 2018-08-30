# SelectObjectsByRegex

## 概要

これは正規表現でマッチするコンポーネントを含むオブジェクトを一括選択するUnityエディタ拡張です。
複数の同種コンポーネントをまとめて設定するのを想定しています。

## インストール

[このリポジトリのzipファイル](https://github.com/Taremin/SelectObjectsByRegex/archive/master.zip)をダウンロードして、解凍したものをアセットの `Plugins` フォルダにコピーします。


## 使い方

1. ヒエラルキーで選択するルートとなるオブジェクトを選択
2. ヒエラルキーで右クリックしてコンテキストメニューから `Select Objects By Regex` をクリック
3. `Select Objects By Regex` ウィンドウが開くので `コンポーネント正規表現` に選択したいコンポーネントとマッチする正規表現を書く
   (例: `DynamicBone` を選択したいなら `DynamicBone$` など。最後の `$` はコライダーがマッチするのを防ぐため)
4. `Select Objects By Regex` ウィンドウの `Select` ボタンを押す


## 注意

Unityエディタは複数のオブジェクトを選択しているとき、選択しているすべてのオブジェクトで共通するコンポーネントをまとめて設定できます。
例えば `DynamicBone` を選択したいときに `DynamicBoneCollider` がマッチしてしまうと、`DynamicBoneCollider` の設定してあるオブジェクトには `DynamicBone` コンポーネントが無いため、設定できません。
`DynamicBone` だけを確実にマッチさせるために `DynamicBone$` のように終端を設定したり、コライダーとマッチしないような正規表現にすることが必要です。

## ライセンス

[MIT](./LICENSE)
