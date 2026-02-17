# Remove publish folder if it exists
if (Test-Path "./publish") {
    Remove-Item "./publish" -Recurse -Force
}

# Run dotnet publish
dotnet publish -c Release -f net8.0 -o ./publish

# Remove old zip if it exists
if (Test-Path "./publish/publish.zip") {
    Remove-Item "./publish/publish.zip" -Force
}

# Create the zip file from publish contents
Compress-Archive -Path "./publish/*" -DestinationPath "./publish/publish.zip"