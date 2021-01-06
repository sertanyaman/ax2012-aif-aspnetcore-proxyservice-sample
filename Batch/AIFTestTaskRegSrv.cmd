sc create AX2012AIFProxySample binPath= %~dp0AX2012AIFProxySample.exe DisplayName= "AIF test relay listener service" start= auto
sc failure AX2012AIFProxySample actions= restart/60000/restart/60000/""/60000 reset= 86400
sc start AX2012AIFProxySample 
sc config AX2012AIFProxySample start=auto obj=Domain\user password=***********
pause
