﻿// Copyright (c) Microsoft. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

using System.Collections.Generic;
using System.IO;

namespace Microsoft.Protocols.TestManager.PTMService.Abstractions
{
    /// <summary>
    /// Interface of storage node.
    /// </summary>
    public interface IStorageNode
    {
        /// <summary>
        /// Name of the node.
        /// </summary>
        string Name { get; }

        /// <summary>
        /// The absolute path of node.
        /// </summary>
        string AbsolutePath { get; }

        /// <summary>
        /// The parent node.
        /// </summary>
        IStorageNode Parent { get; }

        /// <summary>
        /// Create a child node.
        /// </summary>
        /// <param name="name">The name of child node.</param>
        /// <returns>The child node.</returns>
        IStorageNode CreateNode(string name);

        /// <summary>
        /// Get a child node.
        /// </summary>
        /// <param name="name">The name of child node.</param>
        /// <returns>The child node.</returns>
        IStorageNode GetNode(string name);

        /// <summary>
        /// Get all children nodes.
        /// </summary>
        /// <returns>The name of all children nodes.</returns>
        IEnumerable<string> GetNodes();

        /// <summary>
        /// Remove a child node.
        /// </summary>
        /// <param name="name">The name of child node.</param>
        void RemoveNode(string name);

        /// <summary>
        /// Create a file.
        /// </summary>
        /// <param name="name">The name of file.</param>
        /// <param name="content">The content of file.</param>
        void CreateFile(string name, Stream content);

        /// <summary>
        /// Read the content of a file.
        /// </summary>
        /// <param name="name">The name of file.</param>
        /// <returns>The content of file.</returns>
        Stream ReadFile(string name);

        /// <summary>
        /// Remove a file.
        /// </summary>
        /// <param name="name">The name of file.</param>
        void RemoveFile(string name);

        /// <summary>
        /// Get all files.
        /// </summary>
        /// <returns>The name of all files.</returns>
        IEnumerable<string> GetFiles();
    }
}
