#!/bin/bash

(
# カレントディレクトリ変更
cd ~/competitive/Answer
# ディレクトリ作成
mkdir -p ./build
mkdir -p ./obj_windows
mkdir -p ./obj_ubuntu
mkdir -p ../Library/obj_windows
mkdir -p ../Library/obj_ubuntu
# Windows用のデータを退避
mv ./obj/*.json ./obj_windows/
mv ./obj/*.props ./obj_windows/
mv ./obj/*.targets ./obj_windows/
mv ./obj/*.cache ./obj_windows/
mv ../Library/obj/*.json ../Library/obj_windows/
mv ../Library/obj/*.props ../Library/obj_windows/
mv ../Library/obj/*.targets ../Library/obj_windows/
mv ../Library/obj/*.cache ../Library/obj_windows/
# Ubuntu用のデータを配置
mv ./obj_ubuntu/*.json ./obj/
mv ./obj_ubuntu/*.props ./obj/
mv ./obj_ubuntu/*.targets ./obj/
mv ./obj_ubuntu/*.cache ./obj/
mv ../Library/obj_ubuntu/*.json ../Library/obj/
mv ../Library/obj_ubuntu/*.props ../Library/obj/
mv ../Library/obj_ubuntu/*.targets ../Library/obj/
mv ../Library/obj_ubuntu/*.cache ../Library/obj/
# ビルド
dotnet build --nologo -c Release -o ./build/
# Ubuntu用のデータを退避
mv ./obj/*.json ./obj_ubuntu/
mv ./obj/*.props ./obj_ubuntu/
mv ./obj/*.targets ./obj_ubuntu/
mv ./obj/*.cache ./obj_ubuntu/
mv ../Library/obj/*.json ../Library/obj_ubuntu/
mv ../Library/obj/*.props ../Library/obj_ubuntu/
mv ../Library/obj/*.targets ../Library/obj_ubuntu/
mv ../Library/obj/*.cache ../Library/obj_ubuntu/
# Windows用のデータを配置
mv ./obj_windows/*.json ./obj/
mv ./obj_windows/*.props ./obj/
mv ./obj_windows/*.targets ./obj/
mv ./obj_windows/*.cache ./obj/
mv ../Library/obj_windows/*.json ../Library/obj/
mv ../Library/obj_windows/*.props ../Library/obj/
mv ../Library/obj_windows/*.targets ../Library/obj/
mv ../Library/obj_windows/*.cache ../Library/obj/
# テスト
oj t -c "./build/Answer" -d "${OLDPWD}"/tests
)
# ソースコードのコピー
cp -b --suffix=_$(date +%Y%m%d_%H%M%S) ~/competitive/Answer/Program.cs ~/competitive/Answer/HandMadeMain.cs ~/competitive/Answer/Combined.csx .
