# Cabinet 
[![Build status](https://ci.appveyor.com/api/projects/status/q7c183o0jte2roao/branch/master?svg=true)](https://ci.appveyor.com/project/visualeyes-builder/cabinet/branch/master)
[![Coverage Status](https://coveralls.io/repos/github/visualeyes/cabinet/badge.svg?branch=master)](https://coveralls.io/github/visualeyes/cabinet?branch=master)
[![Cabinet Nuget Version](https://img.shields.io/nuget/v/Cabinet.svg)](https://www.nuget.org/packages/Cabinet/)
[![Cabinet Nuget Downloads](https://img.shields.io/nuget/dt/Cabinet.svg)](https://www.nuget.org/packages/Cabinet/)

Cabinet provides abstractions over various file storage providers.
This allows you to develop IO code without having to worry about where the file is actually stored.

Plugging in a new provider is easy as:
```csharp
cabinetFactory.RegisterFileSystemProvider()
``` 
and 
```csharp
IFileCabinet fileCabinet = cabinetFactory.GetCabinet(new FileSystemCabinetConfig() {
    Directory = @"C:\data\"
})
```

## Getting Started with Cabinet
// TODO: Description

```csharp
IFileCabinetFactory cabinetFactory = new FileCabinetFactory(); // or inject IFileCabinetFactory with IOC

cabinetFactory
    .RegisterFileSystemProvider() // Register a file system provider to store files on disk
    .RegisterS3Provider(); // Register an Amazon S3 provider

IFileCabinet fileCabinet = cabinetFactory.GetCabinet(new FileSystemCabinetConfig() {
    Directory = "C:\data\"
});

IFileCabinet s3Cabinet = cabinetFactory.GetCabinet(new S3CabinetConfig() {
    AmazonS3Config = new AmazonS3Config(),
    BucketName = "test-bucket"
});

string fileKey = "foo/bar.txt";

ICabinetFileInfo file = s3Cabinet.GetFileAsync(fileKey);

using (var stream = file.GetFileReadStream()) {
    ISaveResult saveResult = await fileCabinet.SaveFileAsync(file.Key, stream, HandleExistingMethod.Overwrite);
}

```


## Full Example
// TODO: 