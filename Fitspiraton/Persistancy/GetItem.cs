using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Threading.Tasks;
using Windows.Storage;
using Fitspiraton.Model;
using Fitspiraton.ViewModel;

namespace Fitspiraton.Persistancy
{
    public class GetItem
    {
        
            private ObservableCollection<Member> _itemsCatalog;

        public ObservableCollection<Member> ItemsCatalog { get => _itemsCatalog; set => _itemsCatalog = value; }

        public async Task SavetoJson(ObservableCollection<Member> items)
            {
                var localFolder = ApplicationData.Current.LocalFolder;
                var jsonFile = await localFolder.CreateFileAsync("items2.txt", CreationCollisionOption.ReplaceExisting);
                var jsonSerializer = new DataContractJsonSerializer(typeof(ObservableCollection<Member>));
                using (var stream = await jsonFile.OpenStreamForWriteAsync())
                {
                    jsonSerializer.WriteObject(stream, items);
                }
            }

            public async Task<ObservableCollection<Member>> LoadFromJson()
            {
                var localFolder = ApplicationData.Current.LocalFolder;
                var jsonFile = await localFolder.GetFileAsync("myItems.txt");
                var jsonSerializer = new DataContractJsonSerializer(typeof(ObservableCollection<Member>));
                using (var stream = await jsonFile.OpenStreamForReadAsync())
                {
                    ItemsCatalog = jsonSerializer.ReadObject(stream) as ObservableCollection<Member>;
                }

                return ItemsCatalog;
            }

        
    }
}
