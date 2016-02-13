# Project.Json.Patcher

This is a command line tool that enables you to modify project.json file. You will usually need this when you want to patch project.json file for version increaments, or adding release notes in your CI scripts. It is made on dotnet core so its cross platform.

# Installation

`dnu commands install Project.Json.Patcher`

# Usage

```
Project.Json.Patcher Patch -f project.json -v 1.3.4
```

This will patch modify the version of in project.json file. Note that -f argument is optional if you are in project folder. You can also specify release notes as shown below

```
Project.Json.Patcher Patch -v 1.3.4 -r "Added a new page for logout"
```
