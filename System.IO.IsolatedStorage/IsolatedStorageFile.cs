using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Storage;
using Windows.Storage.Search;

namespace System.IO.IsolatedStorage
{
    public class IsolatedStorageFile : IDisposable
    {
        StorageFolder storageFolder;

        private IsolatedStorageFile()
        {
            storageFolder = ApplicationData.Current.LocalFolder;
        }

        static public IsolatedStorageFile GetUserStoreForApplication()
        {
            return new IsolatedStorageFile();
        }

        public void Dispose()
        {
        }

        public void CreateDirectory(string dir)
        {
            storageFolder.CreateFolderAsync(dir).AsTask().Wait();
        }

        public IsolatedStorageFileStream CreateFile(string path)
        {
            return OpenFile(path, FileMode.Create);
        }

        public IsolatedStorageFileStream OpenFile(string path, FileMode mode)
        {
            switch (mode)
            {
                case FileMode.Create:
                    return OpenFile(path, mode, FileAccess.Write);
                case FileMode.Open:
                    return OpenFile(path, mode, FileAccess.Read);
            }
            return null;
        }

        public IsolatedStorageFileStream OpenFile(string path, FileMode mode, FileAccess access)
        {
            Stream stream = null;
            switch (mode)
            {
                case FileMode.Create:
                    stream = Task.Run(
                        async () =>
                        {
                            try
                            {
                                var storageFile = await storageFolder.GetFileAsync(path);
                                return await storageFile.OpenStreamForWriteAsync();
                            }
                            catch (IOException e)
                            {
                                throw new IsolatedStorageException(e.Message, e);
                            }
                        }).Result;
                    break;

                case FileMode.Open:
                    stream = Task.Run(
                        async () =>
                        {
                            try
                            {
                                var storageFile = await storageFolder.GetFileAsync(path);
                                return await storageFile.OpenStreamForReadAsync();
                            }
                            catch (IOException e)
                            {
                                throw new IsolatedStorageException(e.Message, e);
                            }
                        }).Result;
                    break;
            }
            return new IsolatedStorageFileStream(stream);
        }

        public bool DirectoryExists(string directoryName)
        {
            return Task.Run(
                async () =>
                {
                    var folder = await storageFolder.GetFolderAsync(directoryName);
                    return folder != null;
                }).Result;
        }

        public bool FileExists(string fileName)
        {
            return Task.Run(
                async () =>
                {
                    var file = await storageFolder.GetFileAsync(fileName);
                    return file != null;
                }).Result;
        }

        public string[] GetFileNames(string path)
        {
            var files = Task.Run(
                async () =>
                {
                    var folder = await storageFolder.GetFolderAsync(path);
                    return await folder.GetFilesAsync();
                }).Result;
            var result = new string[files.Count];
            int index = 0;
            foreach (var file in files)
                result[index++] = file.Name;
            return result;
        }

        public void DeleteDirectory(string path)
        {
            Task.Run(
                async () =>
                {
                    var folder = await storageFolder.GetFolderAsync(path);
                    await folder.DeleteAsync();
                }).Wait();
        }

        public void DeleteFile(string path)
        {
            Task.Run(
                async () =>
                {
                    var file = await storageFolder.GetFileAsync(path);
                    await file.DeleteAsync();
                }).Wait();
        }
    }
}
