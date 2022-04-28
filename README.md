# Aspose.PSD-Docker-Sample
Aspose.PSD Docker Sample

This repository demonstrate ability to use Aspose.PSD in the docker container under the Linux.

Please read the annotations carefully.

## Dockerfile
 ```
#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/runtime:6.0 AS base
WORKDIR /app

# To use the ability to update the text layers you need to add the following packages to your container
RUN apt-get update
RUN yes | apt-get install -y apt-transport-https
RUN yes | apt-get install -y libgdiplus
RUN yes | apt-get install -y libc6-dev

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build

WORKDIR /src
COPY ["AsposePsdDockerSample/AsposePsdDockerSample.csproj", "AsposePsdDockerSample/"]
RUN dotnet restore "AsposePsdDockerSample/AsposePsdDockerSample.csproj"
COPY . .
WORKDIR "/src/AsposePsdDockerSample"
RUN dotnet build "AsposePsdDockerSample.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "AsposePsdDockerSample.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "AsposePsdDockerSample.dll"]
 ```
 
## Examples of the some apps that can be made with Aspose.PSD
PSD & PSB Viewer: https://products.aspose.app/psd/viewer
Image Format Conversion utility: https://products.aspose.app/psd/conversion
Extracting of the Layers Data (For HTML design, for example): https://products.aspose.app/psd/extract
Compression of PSD file using undocumented features of PSD Format: https://products.aspose.app/psd/compress
Watermarking of the PSD Files: https://products.aspose.app/psd/watermark
Merging severall images to one PSD File: https://products.aspose.app/psd/merger
Fast portolio creation: https://products.aspose.app/psd/create-portfolio
Quick PSD Editor: https://products.aspose.app/psd/template-editor
Complex PSD Editors with the brush features: https://products.aspose.app/psd/editor
Online Resizing of PSD Files: https://products.aspose.app/psd/resize
Aspose.PSD supports font replacements using free fonts: https://products.aspose.app/psd/font-replace