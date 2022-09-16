<h1>Bedrock Finder</h1>

A program with which you can find bedrock pattern.\
Can find bases just by screenshot of bedrock pattern.\
Made mainly for anarchy servers (as 2b2t)

Only Windows (.Net 6.0; WinForms)

GPU Calculating round coords to 16.\
If coords of pattern `116 1150`, GPU Bedrock Finder will show `112 1136`

<h1>How to build(publish)</h1>

Sample:\
`cd your_project_path`\
`dotnet publish -p:PublishSingleFile=true -r win-x64 -c Release --self-contained false`

Example:\
`cd C:\Users\u\source\repos\BedrockFinder\BedrockFinder`\
`dotnet publish -p:PublishSingleFile=true -r win-x64 -c Release --self-contained false`
