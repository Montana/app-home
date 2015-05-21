@echo off
if "%1" == "apply" goto :applyall
if "%1" == "add" goto :add

:add
cd ../src/%2/
call dnx . ef migration add %3

exit

:applyall
cd ../src/Branch.Service.Halo4/
call dnx . ef migration apply

cd ../Branch.Service.XboxLive/
call dnx . ef migration apply

#cd ../Branch.Web/
#call dnx . ef migration apply

exit
