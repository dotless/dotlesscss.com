# This script was derived from the Rhino.Mocks buildscript written by Ayende Rahien.
include .\psake_ext.ps1

properties {
    $config = 'debug'
    $showtestresult = $FALSE
    $base_dir = resolve-path .
    $lib_dir = "$base_dir\lib\"
    $build_dir = "$base_dir\build\" 
    $release_dir = "$base_dir\release\"
    $source_dir = "$base_dir\src"
    $target_dir = "..\dotless\current\"
}

task default -depends Release

task Clean {
    remove-item -force -recurse $build_dir -ErrorAction SilentlyContinue 
    remove-item -force -recurse $release_dir -ErrorAction SilentlyContinue 
}

task Init -depends Clean {
    Write-Host $version

    new-item $build_dir -itemType directory
    new-item $release_dir -itemType directory
    
}

task Build -depends Init {
    msbuild $source_dir\dotlesscss.com\dotlesscss.com.csproj /p:OutDir=$release_dir
    if ($lastExitCode -ne 0) {
        throw "Error: compile failed"
    }
}

task Release -depends Build {
    new-item $target_dir -itemType directory -ErrorAction SilentlyContinue
	#new-item $target_dir\bin -itemType directory -ErrorAction SilentlyContinue
    Copy-Item src\dotlesscss.com\* ..\dotless\current\ -recurse -force
	Copy-Item $release_dir\* ..\dotless\current\bin\ -force
    
    Write-host "-----------------------------"
    Write-Host -ForegroundColor Cyan "dotless website was successfully deployed."
}