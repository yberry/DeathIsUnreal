// Copyright 1998-2012 Epic Games, Inc. All Rights Reserved.

using UnrealBuildTool;
using System;
using System.IO;
using System.Collections.Generic;

public class AudiokineticTools : ModuleRules
{
	public static string GetDefaultVersionFileName()
	{
		return Path.Combine(UnrealBuildTool.UnrealBuildTool.EngineDirectory.FullName, "Build" + Path.DirectorySeparatorChar + "Build.version");
	}

	public AudiokineticTools(TargetInfo Target)
	{
        PCHUsage = PCHUsageMode.UseSharedPCHs;
		PrivateIncludePaths.Add("AudiokineticTools/Private");
        PrivateIncludePathModuleNames.AddRange(
            new string[]
            {
                "TargetPlatform",
                "MainFrame",
				"MovieSceneTools",
                "LevelEditor"
            });

        PublicIncludePathModuleNames.AddRange(
            new string[] 
            { 
                "AssetTools",
                "ContentBrowser",
                "Matinee"
            });

        PublicDependencyModuleNames.AddRange(
            new string[] 
            { 
                "AkAudio",
                "Core",
                "InputCore",
                "CoreUObject",
                "Engine",
                "UnrealEd",
                "Slate",
                "SlateCore",
                "Matinee",
                "EditorStyle",
				"Json",
				"XmlParser",
				"WorkspaceMenuStructure",
				"DirectoryWatcher",
                "Projects",
				"Sequencer",
                "PropertyEditor"
            });

        PrivateDependencyModuleNames.AddRange(
            new string[]
            {
				"MovieScene",
				"MovieSceneTools",
				"MovieSceneTracks"
			});

		BuildVersion Version;
		if (BuildVersion.TryRead(GetDefaultVersionFileName(), out Version))
		{
			if (Version.MajorVersion == 4 && Version.MinorVersion >= 15)
			{
				PrivateDependencyModuleNames.Add("MatineeToLevelSequence");
			}
		}
	}
}
