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
        //-------------------------------------serialization----------------------------------
        //----------------------------------------Members-------------------------------------
        //Auto propery
        public ObservableCollection<Member> ItemsCatalog { get; set; }

        //saving into the file
        public async Task SavetoJson(ObservableCollection<Member> items)
        {
            var localFolder = ApplicationData.Current.LocalFolder;
            var jsonFile = await localFolder.CreateFileAsync("item2.txt", CreationCollisionOption.ReplaceExisting);
            var jsonSerializer = new DataContractJsonSerializer(typeof(ObservableCollection<Member>));
            using (var stream = await jsonFile.OpenStreamForWriteAsync())
            {
                jsonSerializer.WriteObject(stream, items);
            }
        }

        //retriving from the file
        public async Task<ObservableCollection<Member>> LoadFromJson()
        {
            var localFolder = ApplicationData.Current.LocalFolder;
            var jsonFile = await localFolder.GetFileAsync("item2.txt");
            var jsonSerializer = new DataContractJsonSerializer(typeof(ObservableCollection<Member>));
            using (var stream = await jsonFile.OpenStreamForReadAsync())
            {
                ItemsCatalog = jsonSerializer.ReadObject(stream) as ObservableCollection<Member>;
            }
            return ItemsCatalog;
        }

        //----------------------------------------Events-------------------------------------
        //Auto propery
        public ObservableCollection<Event> EventCatalog { get; set; }

        //saving into the file
        public async Task SaveEventsToJson(ObservableCollection<Event> events)
        {
            var localFolder = ApplicationData.Current.LocalFolder;
            var jsonFile = await localFolder.CreateFileAsync("events.txt", CreationCollisionOption.ReplaceExisting);
            var jsonSerializer = new DataContractJsonSerializer(typeof(ObservableCollection<Event>));
            using (var stream = await jsonFile.OpenStreamForWriteAsync())
            {
                jsonSerializer.WriteObject(stream, events);
            }
        }

        //retriving from the file
        public async Task<ObservableCollection<Event>> LoadEventsFromJson()
        {
            var localFolder = ApplicationData.Current.LocalFolder;
            var jsonFile = await localFolder.GetFileAsync("events.txt");
            var jsonSerializer = new DataContractJsonSerializer(typeof(ObservableCollection<Event>));
            using (var stream = await jsonFile.OpenStreamForReadAsync())
            {
                EventCatalog = jsonSerializer.ReadObject(stream) as ObservableCollection<Event>;
            }
            return EventCatalog;
        }

        //----------------------------------------Recent bookings-------------------------------------
        //Auto propery
        public ObservableCollection<Booking> BookingCatalog { get; set; }

        //saving into the file
        public async Task SaveBookingsToJson(ObservableCollection<Booking> bookings)
        {
            var localFolder = ApplicationData.Current.LocalFolder;
            var jsonFile = await localFolder.CreateFileAsync("bookings.txt", CreationCollisionOption.ReplaceExisting);
            var jsonSerializer = new DataContractJsonSerializer(typeof(ObservableCollection<Booking>));
            using (var stream = await jsonFile.OpenStreamForWriteAsync())
            {
                jsonSerializer.WriteObject(stream, bookings);
            }
        }

        //retriving from the file
        public async Task<ObservableCollection<Booking>> LoadBookingsFromJson()
        {
            var localFolder = ApplicationData.Current.LocalFolder;
            var jsonFile = await localFolder.GetFileAsync("bookings.txt");
            var jsonSerializer = new DataContractJsonSerializer(typeof(ObservableCollection<Booking>));
            using (var stream = await jsonFile.OpenStreamForReadAsync())
            {
                BookingCatalog = jsonSerializer.ReadObject(stream) as ObservableCollection<Booking>;
            }
            return BookingCatalog;
        }
    }
}
