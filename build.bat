echo "building branch %APPVEYOR_REPO_BRANCH% commited by %APPVEYOR_REPO_COMMIT_AUTHOR%"

call dnvm upgrade -r coreclr -a x86

call nuget sources Add -name VNext -source https://www.myget.org/F/aspnetcidev/api/v3/index.json

call dnu restore

call dnu commands install Project.Json.Patcher

cd src\Project.Json.Patcher

call Project.Json.Patcher patch -v %APPVEYOR_BUILD_VERSION%

call dnu pack --configuration release --out ..\..\artifacts