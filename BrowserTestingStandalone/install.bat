@echo off
cls
echo *******************************************************************************
echo ************************STANDALONE BROWSER TEST INSTALLATION*******************
echo ************************PRESS ANY KEY WHEN PROMPTED TO DO SO*******************
echo *******************************************************************************
PAUSE
cls
call .\uninstall.bat
.\python.exe add_easyinstall.py
.\Scripts\easy_install.exe behaving
cls
echo Installation complete - you may now run runtests.bat to execute tests.
PAUSE