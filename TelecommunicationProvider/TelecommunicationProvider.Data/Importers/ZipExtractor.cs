// <copyright  file="ZipExtractor.cs" company="Krypton">
// MIT License
// </copyright>
// <author>Aleksandra92, DragnevaPavlina, alexizvely, The.Bager, pepinho24, grukov</author>

namespace TelecommunicationProvider.Data.Importers
{
    using System;

    using Ionic.Zip;

    public class ZipExtractor
    {
        public void Extract(string sourcePath, string destinationPath)
        {
           
            using (ZipFile zip = ZipFile.Read(sourcePath))
            {
                foreach (ZipEntry entry in zip)
                {
                    entry.Extract(destinationPath, ExtractExistingFileAction.OverwriteSilently);
                }
            }
            Console.WriteLine("Folder is extracted");
        }
    }
}