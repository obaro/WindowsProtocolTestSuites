# Copyright (c) Microsoft. All rights reserved.
# Licensed under the MIT license. See LICENSE file in the project root for full license information.

Param(
[String]$scriptsPath  = [System.IO.Path]::GetDirectoryName($myInvocation.MyCommand.Definition)
)

Write-Host "Put current dir as $scriptsPath."
Push-Location $scriptsPath

#----------------------------------------------------------------------------
# Starting script
#----------------------------------------------------------------------------

$settingFile = "$scriptsPath/ParamConfig.xml"
if(Test-Path -Path $settingFile)
{    
    $logPath            = ./Get-Parameter.ps1 $settingFile logPath
    $logFile            = $logPath + "/Config-DriverComputer.ps1.log"
    $userNameInTC       = ./Get-Parameter.ps1 $settingFile userNameInTC
    $userPwdInTC        = ./Get-Parameter.ps1 $settingFile userPwdInTC
    $CredSSPUser        = ./Get-Parameter.ps1 $settingFile CredSSPUser
    $CredSSPPwd         = ./Get-Parameter.ps1 $settingFile CredSSPPwd
    $domainName         = ./Get-Parameter.ps1 $settingFile domainName
    $dcComputerName     = ./Get-Parameter.ps1 $settingFile dcComputerName
    $tcComputerName     = ./Get-Parameter.ps1 $settingFile tcComputerName
    $driverComputerName = ./Get-Parameter.ps1 $settingFile driverComputerName
    $listeningPort      = ./Get-Parameter.ps1 $settingFile RDPListeningPort
    $ipVersion          = ./Get-Parameter.ps1 $settingFile ipVersion
	$securityProtocol   = ./Get-Parameter.ps1 $settingFile securityProtocol
	$negotiationBased   = ./Get-Parameter.ps1 $settingFile negotiationBasedApproach
    $osVersion          = ./Get-Parameter.ps1 $settingFile osVersion
	$RDPVersion         = ./Get-Parameter.ps1 $settingFile RDPVersion
    $workgroupDomain    = ./Get-Parameter.ps1 $settingFile workgroupDomain
    $tcSystemDrive      = ./Get-Parameter.ps1 $settingFile tcSystemDrive
    $agentPort          = ./Get-Parameter.ps1 $settingFile agentPort
    $compressionInTC    = ./Get-Parameter.ps1 $settingFile compressionInTC
    ./Set-Parameter.ps1 $settingFile LogFile $logFile "If no log file path specified, this value should be used."
}

else
{
    Write-Host "$settingFile not found. Will keep the default setting of all the test context info..."
}

$DropConnectionForInvalidRequest = "true"
$SutOsVersion = "" #How to get this value in Linux Driver
$SutOsBuildNumber =  "" #How to get this value in Linux Driver

if([double]$SutOSVersion -ge "10.0")
{
    if([double] $SutOsBuildNumber -eq "15063")
    {
        $RDPVersion = "10.3"
    }

    if([double] $SutOsBuildNumber -ge "15063")
    {
        $DropConnectionForInvalidRequest = "false"
    }
}

#-----------------------------------------------------
# Create $logPath if not exist
#-----------------------------------------------------
if (!(Test-Path -Path $logPath))
{
    New-Item -Type Directory -Path $logPath -Force
}

#-----------------------------------------------------
# Create $logFile if not exist
#-----------------------------------------------------
if (!(Test-Path -Path $logFile))
{
    New-Item -Type File -Path $logFile -Force
}
Start-Transcript $logFile -Append

#-----------------------------------------------------
# Write value for all the parameters
#-----------------------------------------------------
Write-Host "EXECUTING [Config-LinuxDriverComputer.ps1] ..." -foregroundcolor cyan
Write-Host "`$scriptsPath        = $scriptsPath"
Write-Host "`$logPath            = $logPath"       
Write-Host "`$logFile            = $logFile"
Write-Host "`$userNameInTC       = $userNameInTC" 
Write-Host "`$userPwdInTC        = $userPwdInTC"
Write-Host "`$CredSSPUser        = $CredSSPUser" 
Write-Host "`$CredSSPPwd         = $CredSSPPwd"
Write-Host "`$domainName         = $domainName" 
Write-Host "`$dcComputerName     = $dcComputerName"
Write-Host "`$tcComputerName     = $tcComputerName" 
Write-Host "`$driverComputerName = $driverComputerName"
Write-Host "`$listeningPort      = $listeningPort"
Write-Host "`$ipVersion          = $ipVersion"
Write-Host "`$securityProtocol   = $securityProtocol"  
Write-Host "`$negotiationBased   = $negotiationBased"       
Write-Host "`$osVersion          = $osVersion" 
Write-Host "`$RDPVersion         = $RDPVersion" 
Write-Host "`$workgroupDomain    = $workgroupDomain"
Write-Host "`$tcSystemDrive      = $tcSystemDrive"
Write-Host "`$agentPort          = $agentPort"
Write-Host "`$compressionInTC    = $compressionInTC"

#-----------------------------------------------------
# Begin to config Driver Computer
#-----------------------------------------------------

#-----------------------------------------------------
# Create a self-signed certificate and export
#-----------------------------------------------------

# Change file format and permission
function Invoke-Sudo { 
    Write-Host "invoke-sudo $args"
    & /usr/bin/env sudo pwsh -command "& $args" 
}

$createSelfSignedCertificate = "Create-SelfSignedCertificate.sh"
Invoke-Sudo "dos2unix $PSScriptRoot/$createSelfSignedCertificate"
Invoke-Sudo "chmod 777 $PSScriptRoot/$createSelfSignedCertificate"

Write-Host "Create a self-signed certificate and export it out..."

if ($workgroupDomain.ToUpper() -eq "DOMAIN")
{
    $certCN = $driverComputerName + "." + $domainName
}
else
{
    $certCN = $driverComputerName
}
$certPwd = "Password01!"
$certFileName = $driverComputerName

if (Test-Path -Path "$env:HOMEDRIVE/$certFileName.cer")
{
    Remove-Item "$env:HOMEDRIVE/$certFileName.cer" -Force
}
if (Test-Path -Path "$env:HOMEDRIVE/$certFileName.pfx")
{
    Remove-Item "$env:HOMEDRIVE/$certFileName.pfx" -Force
}

.$PSScriptRoot/$createSelfSignedCertificate $certFileName $certCN $certPwd "/"

#-----------------------------------------------------
# Modify PTF Config File
#-----------------------------------------------------
$binPath         = $scriptsPath + "/../Bin"
$dataPath        = $scriptsPath + "/../Data"
$DepPtfConfig    = "$binPath/RDP_ClientTestSuite.deployment.ptfconfig"
$PtfConfig       = "$binPath/RDP_ClientTestSuite.ptfconfig"

$agentAddress    = "$tcComputerName" + ":" + $agentPort
Write-Host "Begin to update RDP_ClientTestSuite.ptfconfig..."
./Modify-ConfigFileNode.ps1 $PtfConfig "SUTControl.AgentAddress"     $agentAddress

Write-Host "Begin to update RDP_ClientTestSuite.deployment.ptfconfig..."
./Modify-ConfigFileNode.ps1 $DepPtfConfig "RDP.ServerPort"            $listeningPort
./Modify-ConfigFileNode.ps1 $DepPtfConfig "RDP.IpVersion"             $ipVersion
./Modify-ConfigFileNode.ps1 $DepPtfConfig "RDP.Security.Protocol"     $securityProtocol
./Modify-ConfigFileNode.ps1 $DepPtfConfig "RDP.Security.Negotiation"  $negotiationBased
./Modify-ConfigFileNode.ps1 $DepPtfConfig "CertificatePath"           "$env:HOMEDRIVE/$certFileName.pfx"
./Modify-ConfigFileNode.ps1 $DepPtfConfig "CertificatePassword"       $certPwd
./Modify-ConfigFileNode.ps1 $DepPtfConfig "SUTName"                   $tcComputerName
./Modify-ConfigFileNode.ps1 $DepPtfConfig "SUTUserPassword"           $userPwdInTC
./Modify-ConfigFileNode.ps1 $DepPtfConfig "SUTSystemDrive"            $tcSystemDrive
./Modify-ConfigFileNode.ps1 $DepPtfConfig "RDP.ServerDomain"          $domainName
./Modify-ConfigFileNode.ps1 $DepPtfConfig "RDP.ServerUserName"        $CredSSPUser
./Modify-ConfigFileNode.ps1 $DepPtfConfig "RDP.ServerUserPassword"    $CredSSPPwd
./Modify-ConfigFileNode.ps1 $DepPtfConfig "RDP.Version"               $RDPVersion

if ($compressionInTC.ToUpper() -eq "YES")
{
    ./Modify-ConfigFileNode.ps1 $DepPtfConfig "RDP.Client.SupportCompression"  "true"
}

if ($osVersion.ToUpper() -eq "NONWINDOWS")
{
    ./Modify-ConfigFileNode.ps1 $DepPtfConfig "IsWindowsImplementation"      "false"
	
    # Update default RDP security protocol as RDP/Low/128bit for NonWindows AutoTest
    ./Modify-ConfigFileNode.ps1 $DepPtfConfig "RDP.Security.Protocol" "RDP"    
    ./Modify-ConfigFileNode.ps1 $DepPtfConfig "DropConnectionForInvalidRequest" "true"
}
else
{
    ./Modify-ConfigFileNode.ps1 $DepPtfConfig "IsWindowsImplementation"      "true"
    ./Modify-ConfigFileNode.ps1 $DepPtfConfig "DropConnectionForInvalidRequest" $DropConnectionForInvalidRequest
}

if ($securityProtocol.ToUpper() -eq "RDP")
{
    ./Modify-ConfigFileNode.ps1 $DepPtfConfig "RDP.Security.Encryption.Level" "Low" 
    ./Modify-ConfigFileNode.ps1 $DepPtfConfig "RDP.Security.Encryption.Method" "128bit" 
}
else
{
    ./Modify-ConfigFileNode.ps1 $DepPtfConfig "RDP.Security.Encryption.Level" "None" 
    ./Modify-ConfigFileNode.ps1 $DepPtfConfig "RDP.Security.Encryption.Method" "None" 
}

if ($workgroupDomain.ToUpper() -eq "DOMAIN")
{
    ./Modify-ConfigFileNode.ps1 $DepPtfConfig "SUTUserName"      "$domainName\$userNameInTC"
}
else
{
    ./Modify-ConfigFileNode.ps1 $DepPtfConfig "SUTUserName"      "$userNameInTC"
    ./Modify-ConfigFileNode.ps1 $DepPtfConfig "RDP.ServerDomain" "$driverComputerName"
}

#-----------------------------------------------------
# Finished to config driver computer
#-----------------------------------------------------
Pop-Location
Write-Host "Write signal file: config.finished.signal to system drive."
#cmd /C ECHO CONFIG FINISHED>$env:HOMEDRIVE\config.finished.signal

#----------------------------------------------------------------------------
# Ending script
#----------------------------------------------------------------------------
Write-Host "Config finished."
Write-Host "EXECUTE [Config-LinuxDriverComputer.ps1] FINISHED (NOT VERIFIED)."

exit 0