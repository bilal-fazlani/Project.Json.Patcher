using System;
using System.IO;
using Microsoft.Dnx.Runtime.Common.CommandLine;
using Newtonsoft.Json;

namespace Project.Json.Patcher
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var app = new CommandLineApplication
            {
                Name = "Project.Json.Patcher",
                Description = "Patch project.json files with new version and release notes",
                FullName = "Project.Json Patcher"
            };

            app.HelpOption("-h|--help");

            app.Command("Patch", commandAppConfing =>
            {
                commandAppConfing.Description = "Patches the project.json file";

                CommandOption fileOption = commandAppConfing.Option("-f|--File <FilePath>",
                    "OPTIONAL. Path to project.json", CommandOptionType.SingleValue);

                CommandOption versionOption = commandAppConfing.Option("-v|--Version <Version>",
                    "Target version of project.json", CommandOptionType.SingleValue);

                CommandOption releaseNotesOption = commandAppConfing.Option("-r|--RealeaseNotes <ReleaseNotes>",
                    "OPTIONAL. Release notes of this version", CommandOptionType.SingleValue);

                commandAppConfing.HelpOption("-h|--help");

                commandAppConfing.OnExecute(() =>
                {

                    string filePath = GetFilePath(fileOption);

                    string version = GetVersion(versionOption);

                    string releaseNotes = releaseNotesOption.Value();

                    Console.WriteLine($"FilePath: {filePath}, " +
                                      $"Version: {version}, " +
                                      $"ReleaseNotes: {releaseNotes}");

                    Patch(filePath, version, releaseNotes);

                    Console.WriteLine("Patching Complete");
                    return 0;
                });

            });

            app.OnExecute(() =>
            {
                app.ShowHelp();
                return 2;
            });

            app.Execute(args);
        }

        private static string GetFilePath(CommandOption filePathOption)
        {
            if (filePathOption.HasValue())
            {
                return filePathOption.Value();
            }
            Console.WriteLine("No project.json file path is provided. Assuming it is present in current directory.");

            return "project.json";
        }

        private static string GetVersion(CommandOption versionOption)
        {
            if (versionOption.HasValue())
            {
                return versionOption.Value();
            }
            Console.Write("Please enter version to be inserted into project.json: ");
            return Console.ReadLine();
        }

        private static void Patch(string filePath, string version, string releaseNotes)
        {
            string json = File.ReadAllText(filePath);
            dynamic jsonObj = JsonConvert.DeserializeObject(json);
            jsonObj["version"] = version;

            if(releaseNotes != null)
                jsonObj["releaseNotes"] = releaseNotes;

            string output = JsonConvert.SerializeObject(jsonObj, Formatting.Indented);
            File.WriteAllText(filePath, output);
        }
    }
}
