﻿// Copyright (c) Microsoft. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

using Microsoft.Protocols.TestTools;

namespace Microsoft.Protocols.TestSuites.FileSharing.Common.Adapter
{
    public interface ISutCommonControlAdapter : IAdapter
    {
        /// <summary>
        /// Get users from domain or local computer.
        /// </summary>
        /// <param name="target">Name of the domain or local computer. Use FQDN for domain.</param>
        /// <param name="adminUserName">Name of the user who has administrative privileges.</param>
        /// <returns>JSON string of all users returned.</returns>
        [MethodHelp("Get users from domain or local computer.")]
        string GetUsers(string target, string adminUserName);

        /// <summary>
        /// Get groups from domain or local computer.
        /// </summary>
        /// <param name="target">Name of the domain or local computer. Use FQDN for domain.</param>
        /// <param name="adminUserName">Name of the user who has administrative privileges.</param>
        /// <returns>JSON string of all groups returned.</returns>
        [MethodHelp("Get groups from domain or local computer.")]
        string GetGroups(string target, string adminUserName);

        /// <summary>
        /// Get group members from domain or local computer.
        /// </summary>
        /// <param name="target">Name of the domain or local computer. Use FQDN for domain.</param>
        /// <param name="adminUserName">Name of the user who has administrative privileges.</param>
        /// <param name="groupName">Name of the queried group.</param>
        /// <returns>JSON string of all group members returned.</returns>
        [MethodHelp("Get group members from domain or local computer.")]
        string GetGroupMembers(string target, string adminUserName, string groupName);

        /// <summary> 
        /// Get the SID of a user from domain or local computer.
        /// </summary>
        /// <param name="target">Name of the domain or local computer. Use FQDN for domain.</param>
        /// <param name="adminUserName">Name of the user who has administrative privileges.</param>
        /// <param name="userName">Name of the queried user.</param>
        /// <returns>The SDDL form of the user SID returned.</returns>
        [MethodHelp("Get SID of a user from domain or local computer.")]
        string GetUserSid(string target, string adminUserName, string userName);

        /// <summary> 
        /// Get the memberships of a user from domain or local computer.
        /// </summary>
        /// <param name="target">Name of the domain or local computer. Use FQDN for domain.</param>
        /// <param name="adminUserName">Name of the user who has administrative privileges.</param>
        /// <param name="userName">Name of the queried user.</param>
        /// <returns>JSON string of all user memberships returned.</returns>
        [MethodHelp("Get the memberships of a user from domain or local computer.")]
        string GetUserMemberships(string target, string adminUserName, string userName);
    }
}

