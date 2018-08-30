# SelectObjectsByRegex

## 概要

これは正規表現でマッチするコンポーネントを含むオブジェクトを一括選択するUnityエディタ拡張です。
複数の同種コンポーネントをまとめて設定するのを想定しています。

## インストール

[このリポジトリのzipファイル](https://github.com/Taremin/SelectObjectsByRegex/archive/master.zip)をダウンロードして、解凍したものをアセットの `Plugins` フォルダにコピーします。


## 使い方

1. ヒエラルキーで選択するルートとなるオブジェクトを選択
2. ヒエラルキーで右クリックしてコンテキストメニューから `Select Objects By Regex` をクリック
3. `Select Objects By Regex` ウィンドウが開くので `正規表現` にコピーしたいコンポーネントとマッチする正規表現を書く
   (例: `Dynamic Bone` と `Dynamic Bone Collider` をコピーしたいなら `Dynamic` など)
4. `Select Objects By Regex` ウィンドウSelect Objectの
5. ヒエラルキーでコピー先のオブジェクトを選択
6. `Select Objects By Regex` ウィンドウの `Paste` ボタンを押す


## 注意

コピーするオブジェクトとコンポーネント内で完結しているオブジェクト参照(Dynamic Bone の `root` など)は自動的にコピー先のオブジェクトやコンポーネントに差し替えます。
構造の同一性はオブジェクトの名前で判断しているため、同じ親を持つ同名の子オブジェクトがある場合などで動作がおかしくなる可能性があります。
また、完全に構造が同一でなくても子の名前が同じならできるだけ辿ろうとするため、ボーンの増加などの場合もそのままコピーできます。

## ライセンス

[MIT](./LICENSE)
