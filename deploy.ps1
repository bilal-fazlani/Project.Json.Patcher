
cd artifacts\release

"repository- $env:APPVEYOR_REPO_NAME"
"own repo: " 
if($env:APPVEYOR_REPO_NAME -eq 'bilal-fazlani/Project.Json.Patcher'){"true"}else{"false"}

"branch- $env:APPVEYOR_REPO_BRANCH"
"own branch: " 
if($env:APPVEYOR_REPO_BRANCH -eq 'master'){"true"}else{"false"}

"commit author- $env:APPVEYOR_REPO_COMMIT_AUTHOR" 
"is Bilal: "
if($env:APPVEYOR_REPO_COMMIT_AUTHOR -eq 'Bilal Fazlani'){"true"}else{"false"}


if($env:APPVEYOR_REPO_NAME -eq "bilal-fazlani/Project.Json.Patcher" -And $env:APPVEYOR_REPO_BRANCH -eq "master" -And $env:APPVEYOR_REPO_COMMIT_AUTHOR -eq "Bilal Fazlani"){
	nuget push Project.Json.Patcher.$env:APPVEYOR_BUILD_VERSION.nupkg -apikey $env:MY_NUGET_API_KEY
}
else{
	"skipping deployment"
}

cd ../..