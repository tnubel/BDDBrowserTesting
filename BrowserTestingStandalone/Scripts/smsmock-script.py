#!"C:\Users\spadmin\Documents\Visual Studio 2012\Projects\BDDBrowserTesting\BrowserTestingStandalone\python.exe"
# EASY-INSTALL-ENTRY-SCRIPT: 'behaving==0.4','console_scripts','smsmock'
__requires__ = 'behaving==0.4'
import sys
from pkg_resources import load_entry_point

if __name__ == '__main__':
    sys.exit(
        load_entry_point('behaving==0.4', 'console_scripts', 'smsmock')()
    )
