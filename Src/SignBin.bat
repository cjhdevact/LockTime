::Tips Set the CSIGNCERT as your path.
@echo off
path D:\ProjectsTmp\SignPack;%path%
echo 任意键签名 时钟锁屏（LockTime）...
pause > nul
cmd.exe /c signcmd.cmd "%CSIGNCERT%" "%~dp0LockTime\bin\Release\LockTime.exe"
echo.
echo 完成！
echo 任意键退出...
pause > nul