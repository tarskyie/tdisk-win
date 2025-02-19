Write-Host "tarskyie's TDISK installer v0.1.0"

# Define the source and destination paths
$sourcePath = ".\bin"
$destinationPath = "C:\Program Files\tdisk"

# Check if the source directory exists
if (-Not (Test-Path -Path $sourcePath)) {
    Write-Error "Source path '$sourcePath' does not exist."
    exit 1
}

# Create the destination directory if it does not exist
if (-Not (Test-Path -Path $destinationPath)) {
    try {
        New-Item -ItemType Directory -Path $destinationPath -Force
        Write-Output "Created destination directory '$destinationPath'."
    } catch {
        Write-Error "Failed to create destination directory '$destinationPath'."
        exit 1
    }
}

# Copy the executable file to the destination directory
try {
    Copy-Item -Path "$sourcePath\*.exe" -Destination $destinationPath -Force
    Write-Output "Copied executable to '$destinationPath'."
} catch {
    Write-Error "Failed to copy executable to '$destinationPath'."
    exit 1
}

# Add the destination directory to the system PATH
try {
    $currentPath = [System.Environment]::GetEnvironmentVariable("Path", [System.EnvironmentVariableTarget]::Machine)
    if ($currentPath -notcontains $destinationPath) {
        [System.Environment]::SetEnvironmentVariable("Path", "$currentPath;$destinationPath", [System.EnvironmentVariableTarget]::Machine)
        Write-Output "Added '$destinationPath' to the system PATH."
    } else {
        Write-Output "'$destinationPath' is already in the system PATH."
    }
} catch {
    Write-Error "Failed to add '$destinationPath' to the system PATH."
    exit 1
}

Write-Output "Installation completed successfully."