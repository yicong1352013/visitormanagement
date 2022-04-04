// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

using System.ComponentModel;

namespace CleanArchitecture.Blazor.Domain.Enums;

public enum UploadType : byte
{
    [Description(@"Products")]
    Product,
    [Description(@"VisitorPrictures")]
    VisitorPricture,
    [Description(@"ProfilePictures")]
    ProfilePicture,
    [Description(@"EmployeePictures")]
    EmployeePicture,
    [Description(@"Documents")]
    Document
}
