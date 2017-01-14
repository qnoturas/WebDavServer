﻿using System.IO;
using System.Security.Principal;
using System.Threading;

using FubarDev.WebDavServer.FileSystem;
using FubarDev.WebDavServer.FileSystem.DotNet;

using Microsoft.Extensions.Options;

namespace FubarDev.WebDavServer.Sample.AspNetCore.Support
{
    public class TestFileSystemFactory : IFileSystemFactory
    {
        private readonly DotNetFileSystemOptions _options;

        public TestFileSystemFactory(IOptions<DotNetFileSystemOptions> options)
        {
            _options = options.Value;
        }

        public IFileSystem CreateFileSystem(IIdentity identity)
        {
            var userHomeDirectory = Path.Combine(_options.RootPath, identity.IsAuthenticated ? identity.Name : _options.AnonymousUserName);
            return new DotNetFileSystem(_options, userHomeDirectory);
        }
    }
}