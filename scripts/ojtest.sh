#!/bin/bash

(
cd ~/competitive/Answer
mkdir -p ./build
dotnet build --nologo -c Release -o ./build/
oj t -c "./build/Answer" -d "${OLDPWD}"/tests
)
cp -b --suffix=_$(date +%Y%m%d_%H%M%S) ~/competitive/Answer/Program.cs ~/competitive/Answer/HandMadeMain.cs ~/competitive/Answer/Combined.csx .
