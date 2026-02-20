# Variables
# Remove publish folder if it exists
$publishDir = "./publish"
$tarFile = "$publishDir/publish.tar"

# Remove publish folder if it exists
if (Test-Path $publishDir) {
    Remove-Item $publishDir -Recurse -Force
}

# Run dotnet publish and recreate the publish folder with the published files inside 
dotnet publish -c Release -f net8.0 -o $publishDir

# Remove old tar/zip if it exists
if (Test-Path $tarFile) {
    Remove-Item $tarFile -Force
}

# Create the tar file from publish contents
tar -cvf $tarFile -C $publishDir .