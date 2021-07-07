#!/bin/bash

(
cd ~/competitive/Answer
oj t -c "dotnet run" -d "${OLDPWD}"/tests
)
cp -b --suffix=_$(date +%Y%m%d_%H%M%S) ~/competitive/Answer/Program.cs ~/competitive/Answer/HandMadeMain.cs ~/competitive/Answer/Combined.csx .
