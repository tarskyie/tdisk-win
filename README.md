# tdisk-win
## Installation ##
### 1. Install using the installer ###
* download the zip archive from Releases
* unzip the archive
* run install-tdisk.ps1 as an administrator
### 2. Install with PowerShell ###
run PowerShell as an administrator.
``` powershell
$tdExeLink = curl https://raw.githubusercontent.com/tarskyie/tdisk-win/refs/heads/master/tdisk-win/Utilities/current_ver.txt
curl -OL $tdExeLink
mkdir ($env:ProgramFiles+"\tdisk")
Move-Item tdisk.exe ($env:ProgramFiles+"\tdisk") -force
$currentPath = [System.Environment]::GetEnvironmentVariable("Path", [System.EnvironmentVariableTarget]::Machine)
[System.Environment]::SetEnvironmentVariable("Path", "$currentPath;($env:ProgramFiles+'\tdisk')", [System.EnvironmentVariableTarget]::Machine)
```
### 3. Install manually with the executable file provided in Releases.
