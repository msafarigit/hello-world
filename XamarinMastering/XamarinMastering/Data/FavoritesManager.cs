//#define OFFLINE_SYNC_ENABLED

using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.WindowsAzure.MobileServices;
using System.Linq;
using System.Threading.Tasks;
using XamarinMastering.Common;
using System.Collections.ObjectModel;
using System.Diagnostics;

#if OFFLINE_SYNC_ENABLED
using Microsoft.WindowsAzure.MobileServices.SQLiteStore;
using Microsoft.WindowsAzure.MobileServices.Sync;
#endif

namespace XamarinMastering.Data
{
    /// <summary>
    /// Define Offline Sync Enabled
    /// if "#define OFFLINE_SYNC_ENABLED" is commented this favorite is added to azure server;
    /// </summary>

    public partial class FavoritesManager
    {
        static FavoritesManager defaultInstance = new FavoritesManager();
        MobileServiceClient client;

#if OFFLINE_SYNC_ENABLED
        IMobileServiceSyncTable<Favorite> favoritesTable;
        IMobileServiceSyncTable<Registration> registrationsTable;
#else
        IMobileServiceTable<Favorite> favoritesTable;
        IMobileServiceTable<Registration> registrationsTable;
#endif

        private FavoritesManager()
        {
            this.client = new MobileServiceClient(CoreConstants.ApplicationURL);

#if OFFLINE_SYNC_ENABLED
            MobileServiceSQLiteStore store = new MobileServiceSQLiteStore("localfavorites.db");
            store.DefineTable<Favorite>();
            store.DefineTable<Registration>();

            this.client.SyncContext.InitializeAsync(store);
            this.favoritesTable = client.GetSyncTable<Favorite>();
            this.registrationsTable = client.GetSyncTable<Registration>();
#else
            this.favoritesTable = client.GetTable<Favorite>();
            this.registrationsTable = client.GetTable<Registration>();
#endif
        }

        public static FavoritesManager DefaultManager
        {
            get
            {
                return defaultInstance;
            }
            private set
            {
                defaultInstance = value;
            }
        }

        public MobileServiceClient CurrentClient => client;

        public bool IsOfflineEnabled => favoritesTable is Microsoft.WindowsAzure.MobileServices.Sync.IMobileServiceSyncTable<Favorite>;

        public async Task<ObservableCollection<Favorite>> GetFavoritesAsync(bool syncItems = false)
        {
            try
            {
#if OFFLINE_SYNC_ENABLED
                if (syncItems)
                    await this.SyncAsync();
#endif
                IEnumerable<Favorite> items = await favoritesTable.ToEnumerableAsync();

                return new ObservableCollection<Favorite>(items);
            }
            catch (MobileServiceInvalidOperationException msioe)
            {
                Debug.WriteLine(@"Invalid sync operation: {0}", msioe.Message);
            }
            catch (Exception e)
            {
                Debug.WriteLine(@"Sync error: {0}", e.Message);
            }
            return null;
        }

        public async Task<ObservableCollection<Registration>> GetRegistrationsAsync(bool syncItems = false)
        {
            try
            {
#if OFFLINE_SYNC_ENABLED
                if (syncItems)
                {
                    await this.SyncAsync();
                }
#endif
                IEnumerable<Registration> items = await registrationsTable
                    .ToEnumerableAsync();

                return new ObservableCollection<Registration>(items);
            }
            catch (MobileServiceInvalidOperationException msioe)
            {
                Debug.WriteLine(@"Invalid sync operation: {0}", msioe.Message);
            }
            catch (Exception e)
            {
                Debug.WriteLine(@"Sync error: {0}", e.Message);
            }
            return null;
        }

        public async Task SaveFavoriteAsync(Favorite item)
        {
            try
            {
                if (item.Id == null)
                {
                    await favoritesTable.InsertAsync(item);
                }
                else
                {
                    await favoritesTable.UpdateAsync(item);
                }
            }
            catch (Exception ex)
            {

            }
        }

#if OFFLINE_SYNC_ENABLED
        public async Task SyncAsync()
        {
            ReadOnlyCollection<MobileServiceTableOperationError> syncErrors = null;

            try
            {
                await this.client.SyncContext.PushAsync();
                await this.favoritesTable.PullAsync("allFavorites", this.favoritesTable.CreateQuery());
            }
            catch (MobileServicePushFailedException exc)
            {
                if (exc.PushResult != null)
                {
                    syncErrors = exc.PushResult.Errors;
                }
            }

            if (syncErrors != null)
            {
                foreach (MobileServiceTableOperationError error in syncErrors)
                {
                    if (error.OperationKind == MobileServiceTableOperationKind.Update && error.Result != null)
                    {
                        await error.CancelAndUpdateItemAsync(error.Result);
                    }
                    else
                    {
                        await error.CancelAndDiscardItemAsync();
                    }

                    Debug.WriteLine(@"Error executing sync operation. Item: {0} ({1}). Operation discarded.", error.TableName, error.Item["id"]);
                }
            }
        }
#endif

        public async Task SaveRegistrationAsync(Registration item)
        {
            try
            {
                if (item.Id == null)
                {
                    await registrationsTable.InsertAsync(item);
                }
                else
                {
                    await registrationsTable.UpdateAsync(item);
                }
            }
            catch (Exception ex)
            {

            }
        }

    }
}
