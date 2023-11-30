// Copyright (c) Microsoft. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

using System;
using System.Collections.Generic;
using Microsoft.Protocols.TestTools.StackSdk.Security.SspiLib;

namespace Microsoft.Protocols.TestTools.StackSdk.FileAccessService.Smb2
{
    /// <summary>
    /// Contains information to track one connection between server and client
    /// </summary>
    public class Smb2ClientConnection
    {
        /// <summary>
        /// A table of authenticated sessions, as specified in section 3.2.1.5, 
        /// that the client has established on this SMB2 transport connection
        /// </summary>
        public Dictionary<ulong, Smb2ClientSession> SessionTable
        {
            get;
            set;
        }

        /// <summary>
        /// A table of requests that have been issued on this connection and are awaiting a response
        /// </summary>
        public Dictionary<ulong, Smb2PendingRequest> OutstandingRequests
        {
            get;
            set;
        }

        /// <summary>
        /// A table of available sequence numbers for sending requests to the server, as specified in section 3.2.1.1
        /// </summary>
        public List<ulong> SequenceWindow
        {
            get;
            set;
        }

        /// <summary>
        /// A table of opens, as specified in section 3.2.1.8.
        /// The table MUST allow lookup by either file name or by Open.FileId.
        /// </summary>
        public Dictionary<FILEID, Smb2ClientOpen> OpenTable
        {
            get;
            set;
        }

        /// <summary>
        /// A byte array containing the token received during a negotiation and remembered for authentication
        /// </summary>
        public byte[] GssNegotiateToken
        {
            get;
            set;
        }

        /// <summary>
        /// The maximum buffer size, in bytes, that the server will accept on this connection for QUERY_INFO,
        /// QUERY_DIRECTORY, SET_INFO and CHANGE_NOTIFY operations
        /// </summary>
        public uint MaxTransactSize
        {
            get;
            set;
        }

        /// <summary>
        /// The maximum read size, in bytes, that the server will accept in an SMB2 READ Request on this connection
        /// </summary>
        public uint MaxReadSize
        {
            get;
            set;
        }

        /// <summary>
        /// The maximum write size, in bytes, that the server will accept in an SMB2 WRITE Request on this connection
        /// </summary>
        public uint MaxWriteSize
        {
            get;
            set;
        }

        /// <summary>
        /// A globally unique identifier that is generated by the remote server to uniquely identify the remote server
        /// </summary>
        public Guid ServerGuid
        {
            get;
            set;
        }

        /// <summary>
        /// A Boolean indicating whether the server requires requests/responses on this connection to be signed. 
        /// </summary>
        public bool RequireSigning
        {
            get;
            set;
        }

        /// <summary>
        /// A null-terminated Unicode UTF-16 fully qualified domain name, a NetBIOS name, or an IP address of the server machine.
        /// </summary>
        public string ServerName
        {
            get;
            set;
        }

        // SMB 2.1
        /// <summary>
        /// The dialect of SMB2 negotiated with the server. This value MUST be either "2.002", "2.100", or "Unknown"
        /// </summary>
        public string Dialect
        {
            get;
            set;
        }

        /// <summary>
        /// A Boolean indicating whether the server supports leasing functionality.
        /// </summary>
        public bool SupportLeasing
        {
            get;
            set;
        }

        /// <summary>
        /// A Boolean indicating whether the server supports multi-credit operations.
        /// </summary>
        public bool SupportsMultiCredit
        {
            get;
            set;
        }

        /// <summary>
        /// The underlying gss-api
        /// </summary>
        internal ClientSecurityContext Gss
        {
            get;
            set;
        }

        /// <summary>
        ///  A Boolean indicating whether the server supports one-way notifications on this connection.
        /// <summary>
        public bool SupportsNotifications
        {
            get;
            set;
        }

    }
}
