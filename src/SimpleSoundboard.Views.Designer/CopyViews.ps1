$ErrorActionPreference = "Stop"
$sourceDirectory = Resolve-Path(".")
$targetDirectory = Resolve-Path("..\SimpleSoundboard.Views")
# When new Namespaces have been added their relative paths have to be specified here
$CommonDirectories = @(".\Controls")
$DesignableDirectories= @(".\Views"),@(".\Base")
###########################################
# Functions
###########################################

function Copy-File {
	param (
		$filePath,
		$overwrite = $false
	)
		
	$targetProbingPath = "$targetDirectory$($_.FullName.Substring($sourceDirectory.Path.Length))"

	if ($overwrite -eq $true -OR (-NOT (Test-Path -LiteralPath $targetProbingPath))) {
		$currentTargetDirectory = [System.IO.Path]::GetDirectoryName($targetProbingPath)
		
		if (-NOT (Test-Path -LiteralPath $currentTargetDirectory)) {
			New-Item -Path $currentTargetDirectory -ItemType Directory | Out-Null
		}
		
		Copy-Item -LiteralPath $filePath -Destination $targetProbingPath
	} 	
}
###########################################

try {
	# Initial code files
	$DesignableDirectories | ForEach-Object {
	Get-ChildItem -LiteralPath $_ -Filter "*.cs" -Exclude "*.designer.*" -Recurse | ForEach-Object {
		Copy-File $_.FullName
		}
	}

	# Controls
	$DesignableDirectories | ForEach-Object {
	Get-ChildItem -Path $_ -Include "*.Designer.cs", "*.resx" -Recurse | ForEach-Object {
		Copy-File $_.FullName $true
		}
	}

	# Resources
	Get-ChildItem -Path ".\Properties\Resources*" -Recurse | ForEach-Object {
		Copy-File $_.FullName $true
	}
	
	# Extra stuff
	$CommonDirectories | ForEach-Object {
		Get-ChildItem -LiteralPath $_ -File -Recurse | ForEach-Object {
			Copy-File $_.FullName $true
		}
	}

	# Cleanup (Auto Delete Files that aren't in the Designer Projekt)
	#(@(".\Forms") + $DesignableDirectories) | ForEach-Object {
	#	Get-ChildItem -LiteralPath (Resolve-Path("$($targetDirectory)$($_)")) -File -Recurse | ForEach-Object {
	#		$filePath = $_.FullName
	#		$probingPath = "$sourceDirectory$($filePath.Substring($targetDirectory.Path.Length))"
	#		if (-NOT (Test-Path $probingPath)) {
	#			Remove-Item $filePath
	#		}
	#	} 
	#}
}
catch { 	
	Write-Error "Failed Coyping Files"
}

Exit 0
