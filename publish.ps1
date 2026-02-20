# Remove publish folder if it exists
if (Test-Path "./publish") {
    Remove-Item "./publish" -Recurse -Force
}

# Run dotnet publish
dotnet publish -c Release -f net8.0 -o ./publish

# Remove old tar/zip if it exists
if (Test-Path "./publish/publish.tar") {
    Remove-Item "./publish/publish.tar" -Force
}

# Create the tar file from publish contents
tar -cvf ./publish/publish.tar -C ./publish .