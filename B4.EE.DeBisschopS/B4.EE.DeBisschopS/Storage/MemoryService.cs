using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;
using B4.EE.DeBisschopS.Models;
using Newtonsoft.Json;
using PCLStorage;

namespace B4.EE.DeBisschopS.Storage
{
    public class MemoryService : IStorage
    {
        public ObservableCollection<Item> ItemList { get; set; }
        public MemoryService()
        {
        }

        // General methods

        public async Task<bool> DoesFileExist(string fileName)
        {
            IFolder folder = FileSystem.Current.LocalStorage;
            ExistenceCheckResult folderexist = await folder.CheckExistsAsync(fileName);
            if (folderexist == ExistenceCheckResult.FileExists)
            {
                return true;

            }
            return false;
        }

        public async Task<IFile> CreateFile(string filename)
        {
            IFolder folder = FileSystem.Current.LocalStorage;
            if (!await DoesFileExist(filename))
            {

                IFile file = await folder.CreateFileAsync(filename, CreationCollisionOption.ReplaceExisting);
                return file;
            }
            IFile fileExists = await folder.GetFileAsync(Constants.ITEMS_LIST_FILENAME);
            return fileExists;
        }

        public async Task<string> ReadAllTextAsync(string fileName)
        {
            if (await DoesFileExist(fileName))
            {
                string content = "";
                IFolder folder = FileSystem.Current.LocalStorage;
                IFile file = await folder.GetFileAsync(fileName);
                content = await file.ReadAllTextAsync();
                return content;
            }
            else
            {
                await CreateFile(fileName);
                return await ReadAllTextAsync(fileName);
            }
        }

        public async Task WriteTextAllAsync(string filename, string content = "")
        {
            if (await DoesFileExist(filename))
            {
                //IFile file = await filename.CreateFile(rootFolder);
                IFolder folder = FileSystem.Current.LocalStorage;
                IFile file = await folder.GetFileAsync(filename);
                await file.WriteAllTextAsync(content);
            }
            else
            {
                await CreateFile(filename);
                await WriteTextAllAsync(filename, content);
            }
        }

        // Methods for ItemList

        public async Task<Item> AddNewItem(string name, int cost, string imageNameF)
        {
            Item newItem = new Item() { Name = name, Cost = cost, ImageNameF = imageNameF };
            ObservableCollection<Item> allItems = await GetAllItems();
            allItems.Add(newItem);
            string newJson = JsonConvert.SerializeObject(allItems);
            await WriteTextAllAsync(Constants.ITEMS_LIST_FILENAME, newJson);
            return newItem;
        }

        public async Task<ObservableCollection<Item>> GetAllItems()
        {
            string readedText = await ReadAllTextAsync(Constants.ITEMS_LIST_FILENAME);

            if (readedText == "")
                return new ObservableCollection<Item>();
            return JsonConvert.DeserializeObject<ObservableCollection<Item>>(readedText);
        }

        // Methods for Settings

        public async Task<Settings> ChangeCurrency(string currencyName)
        {
            Settings settings = new Settings()
            {
                currency = currencyName
            };
            string newJson = JsonConvert.SerializeObject(settings);
            await WriteTextAllAsync(Constants.SETTINGS_FILENAME, newJson);
            return settings;
        }

        public async Task<Settings> GetCurrency()
        {
            string readedText = await ReadAllTextAsync(Constants.SETTINGS_FILENAME);
            return JsonConvert.DeserializeObject<Settings>(readedText);
        }
    }
}
