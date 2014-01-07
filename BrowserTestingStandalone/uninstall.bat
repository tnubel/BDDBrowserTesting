for /d %%a in (.\Scripts\behav*) do rd %%a /q /s
for /d %%a in (.\Lib\site-packages\splinter*) do rd %%a /q /s
for /d %%a in (.\Lib\site-packages\behav*) do rd %%a /q /s
for /d %%a in (.\Lib\site-packages\selenium*) do rd %%a /q /s
del .\Lib\site-packages\splinter*
del .\Scripts\behav*

copy /Y "Lib\site-packages\easy-install-backup.pth" "Lib\site-packages\easy-install.pth"
ECHO Cleaned successfully