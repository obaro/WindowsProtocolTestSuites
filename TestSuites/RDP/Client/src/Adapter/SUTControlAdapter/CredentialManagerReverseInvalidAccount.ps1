# Copyright (c) Microsoft. All rights reserved.
# Licensed under the MIT license. See LICENSE file in the project root for full license information.

#This method is used to trigger change of stored credentials to valid user account.

# Check SUT started the PS Remoting
$isSutPSRemotingStarted = ./Check-PSRemoting.ps1 $PtfProp_SUTName
if(-not $isSutPSRemotingStarted) {return -1}

# Run task to simulate a client initiated disconnect request
$returnValue = ./Run-TaskWithPSRemoting.ps1 $PtfProp_SUTName $PtfProp_CredentialManagerReverseInvalidAccount_Task $PtfProp_SUTUserName
return $returnValue
