cd artifacts\release
if($env:APPVEYOR_REPO_NAME -eq "bilal-fazlani/Project.Json.Patcher" -And $env:APPVEYOR_REPO_BRANCH -eq "master" -And $env:APPVEYOR_REPO_COMMIT_AUTHOR -eq "Bilal Fazlani"){
	nuget push Project.Json.Patcher.$env:APPVEYOR_BUILD_VERSION.nupkg -apikey $env:MY_NUGET_API_KEY
}
else{
	"skipping deployment"
}