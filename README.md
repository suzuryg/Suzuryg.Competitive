# 導入手順 (WSL1 Ubuntu)

~/.profileに下記を追記して反映
```
PATH=~/.npm-global/bin:$PATH
```

npmのインストールと設定（完了後に再ログイン）
```
sudo apt update
sudo apt install nodejs npm
mkdir ~/.npm-global
npm config set prefix '~/.npm-global'
sudo npm install -g n
sudo n stable
sudo apt purge nodejs npm
```

atcoder-cliのインストールと設定
```
npm install -g atcoder-cli
acc confg default-task-choice all
```

pip3のインストール
```
sudo apt update
sudo apt install python3-pip
```

online-judge-toolsのインストール（完了後に再ログイン）
```
pip3 install online-judge-tools
```

.NET SDKのインストール
```
cd <path-to-work-dir>
wget https://packages.microsoft.com/config/ubuntu/20.10/packages-microsoft-prod.deb -O packages-microsoft-prod.deb
sudo dpkg -i packages-microsoft-prod.deb

sudo apt update; \
  sudo apt install -y apt-transport-https && \
  sudo apt update && \
  sudo apt install -y dotnet-sdk-5.0
  sudo apt install -y dotnet-sdk-3.1
```

シンボリックリンクの設定
```
cd <path-to-vs-dir>
git clone https://github.com/suzuryg/Suzuryg.Competitive.git
ln -s <path-to-vs-dir>/Suzuryg.Competitive ~/competitive
ln -s ~/competitive/scripts/ojtest.sh ~/.local/bin/ojtest
ln -s ~/competitive/scripts/ojsubmit.sh ~/.local/bin/ojsubmit
```

# 使用方法

ログイン
```
acc login
oj login https://atcoder.jp/
```

テストケースのダウンロード
```
cd <path-to-test-dir>
acc n <contest-id>
```

- Visual Studioでコーディング
    - 完了後、スタートアップオブジェクトをSuzuryg.Competitive.Answer.Programに変更

テスト
```
cd <path-to-test-dir>/<contest-id>/<task-id>
ojtest
```

提出
```
cd <path-to-test-dir>/<contest-id>/<task-id>
ojsubmit
```
 
# 参考

- [最強のAtCoder用C#環境を構築する](https://qiita.com/naminodarie/items/dce121a992cbdca69a78)
- [AtCoder を C# で戦う環境を整える（.NET Core）](https://oita.oika.me/2020/05/10/at-coder-csharp/)
