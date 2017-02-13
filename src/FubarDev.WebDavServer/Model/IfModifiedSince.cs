﻿// <copyright file="IfModifiedSince.cs" company="Fubar Development Junker">
// Copyright (c) Fubar Development Junker. All rights reserved.
// </copyright>

using System;
using System.Collections.Generic;

using FubarDev.WebDavServer.FileSystem;
using FubarDev.WebDavServer.Props.Converters;

using JetBrains.Annotations;

namespace FubarDev.WebDavServer.Model
{
    public class IfModifiedSince : IIfMatcher
    {
        public IfModifiedSince(DateTime lastWriteTimeUtc)
        {
            LastWriteTimeUtc = lastWriteTimeUtc;
        }

        public DateTime LastWriteTimeUtc { get; }

        public static IfModifiedSince Parse(string s)
        {
            return new IfModifiedSince(DateTimeRfc1123Converter.Parse(s));
        }

        public bool IsMatch(IEntry entry, EntityTag etag, [ItemNotNull, NotNull] IReadOnlyCollection<Uri> stateTokens)
        {
            return entry.LastWriteTimeUtc > LastWriteTimeUtc;
        }
    }
}
